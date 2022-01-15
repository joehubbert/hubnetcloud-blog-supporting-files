// Databricks notebook source
// DBTITLE 1,Parameters
//Define folderPath 
dbutils.widgets.text("rawFilename", "") 
val paramRawFile = dbutils.widgets.get("rawFilename") 

//Define pipelineRunId 
dbutils.widgets.text("pipelineRunId", "") 
val paramPipelineRunId = dbutils.widgets.get("pipelineRunId")

// COMMAND ----------

// DBTITLE 1,Declare and set variables
val dataLake = "abfss://<container>@<accountname>.dfs.core.windows.net" 
val rawFolderPath = ("/raw-data/") 
val rawFullPath = (dataLake + rawFolderPath + paramRawFile) 
val outputFolderPath = "/output-data/" 
val databricksServicePrincipalClientId = dbutils.secrets.get(scope = "databricks-secret-scope", key = "databricks-service-principal-client-id") 
val databricksServicePrincipalClientSecret = dbutils.secrets.get(scope = "databricks-secret-scope", key = "databricks-service-principal-secret") 
val azureADTenant = dbutils.secrets.get(scope = "databricks-secret-scope", key = "azure-ad-tenant-id") 
val endpoint = "https://login.microsoftonline.com/" + azureADTenant + "/oauth2/token" 
val dateTimeFormat = "yyyy_MM_dd_HH_mm"

// COMMAND ----------

// DBTITLE 1,Set storage context and read source data
import org.apache.spark.sql 
spark.conf.set("fs.azure.account.auth.type", "OAuth") 
spark.conf.set("fs.azure.account.oauth.provider.type", "org.apache.hadoop.fs.azurebfs.oauth2.ClientCredsTokenProvider") 
spark.conf.set("fs.azure.account.oauth2.client.id", databricksServicePrincipalClientId) 
spark.conf.set("fs.azure.account.oauth2.client.secret", databricksServicePrincipalClientSecret) 
spark.conf.set("fs.azure.account.oauth2.client.endpoint", endpoint) 

val sourceDf = spark.read.option("multiline",true).json(rawFullPath) 

// COMMAND ----------

// DBTITLE 1,Explode source data columns into tabular format
import org.apache.spark.sql.functions._ 

val explodedDf = sourceDf.select(explode($"tables").as("tables")) 
.select($"tables.columns".as("column"), explode($"tables.rows").as("row")) 
.selectExpr("inline(arrays_zip(column, row))") 
.groupBy() 
.pivot($"column.name") 
.agg(collect_list($"row")) 
.selectExpr("inline(arrays_zip(timeGenerated, userAction, appUrl, successFlag, httpResultCode, durationOfRequestMs, clientType, clientOS, clientCity, clientStateOrProvince, clientCountryOrRegion, clientBrowser, appRoleName, snapshotTimestamp))") 

display(explodedDf)

// COMMAND ----------

// DBTITLE 1,Transform source data
import org.apache.spark.sql.SparkSession 

val pipelineRunIdSparkSession = SparkSession 
    .builder() 
    .appName("Pipeline Run Id Appender") 
    .getOrCreate() 

// Register the transformed DataFrame as a SQL temporary view 

explodedDf.createOrReplaceTempView("transformedDf") 

val transformedDf = spark.sql("""
SELECT DISTINCT 
timeGenerated,
userAction,
appUrl,
successFlag,
httpResultCode,
durationOfRequestMs,
clientType,
clientOS,
clientCity,
clientStateOrProvince,
clientCountryOrRegion,
clientBrowser,
appRoleName,
snapshotTimestamp,
'""" + paramPipelineRunId + """' AS pipelineRunId,
CAST(timeGenerated AS DATE) AS requestDate,
HOUR(timeGenerated) AS requestHour
FROM transformedDf""").toDF 

display(transformedDf)

// COMMAND ----------

// DBTITLE 1,Write transformed data to delta lake
import org.apache.spark.sql.SaveMode

display(spark.sql("CREATE DATABASE IF NOT EXISTS logAnalyticsdb")) 

transformedDf.write 
  .format("delta") 
  .mode("append") 
  .option("mergeSchema","true") 
  .partitionBy("requestDate", "requestHour") 
  .option("path", "/delta/logAnalytics/websiteLogs") 
  .saveAsTable("logAnalyticsdb.websitelogs") 

val transformedDfDelta = spark.read.format("delta") 
  .load("/delta/logAnalytics/websiteLogs") 

display(transformedDfDelta)

// COMMAND ----------

// DBTITLE 1,Remove stale data, optimize and vacuum delta table
import io.delta.tables._

display(spark.sql("""
DELETE 
FROM logAnalyticsdb.websitelogs 
WHERE requestDate < DATE_ADD(CURRENT_TIMESTAMP, -7)
"""))

display(spark.sql("""
OPTIMIZE logAnalyticsdb.websitelogs 
ZORDER BY (snapshotTimestamp)
"""))

val deltaTable = DeltaTable.forPath(spark, "/delta/logAnalytics/websiteLogs")
deltaTable.vacuum()

display(spark.sql("DESCRIBE HISTORY logAnalyticsdb.websitelogs"))

// COMMAND ----------

// DBTITLE 1,Create data frame for output file
import org.apache.spark.sql.SparkSession 

val outputFileSparkSession = SparkSession 
.builder() 
.appName("Output File Generator") 
.getOrCreate() 

val outputDf = spark.sql("""
SELECT DISTINCT 
timeGenerated,
userAction,
appUrl,
successFlag,
httpResultCode,
durationOfRequestMs,
clientType,
clientOS,
clientCity,
clientStateOrProvince,
clientCountryOrRegion,
clientBrowser,
appRoleName,
requestDate,
requestHour,
pipelineRunId
FROM logAnalyticsdb.websitelogs
WHERE pipelineRunId = '""" + paramPipelineRunId + """' 
"""
)
display(outputDf)

// COMMAND ----------

// DBTITLE 1,Create output file in data lake
import org.apache.spark.sql.functions._ 
val currentDateTimeLong = current_timestamp().expr.eval().toString.toLong 
val currentDateTime = new java.sql.Timestamp(currentDateTimeLong/1000).toLocalDateTime.format(java.time.format.DateTimeFormatter.ofPattern(dateTimeFormat)) 
val outputSessionFolderPath = ("appLogs_" + currentDateTime) 
val fullOutputPath = (dataLake + outputFolderPath + outputSessionFolderPath) 

outputDf.write.parquet(fullOutputPath)

// COMMAND ----------

// DBTITLE 1,Display output parameters
dbutils.notebook.exit(outputFolderPath + outputSessionFolderPath)
