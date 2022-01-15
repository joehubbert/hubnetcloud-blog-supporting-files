--Run in the context of reportingDatabase

CREATE PROCEDURE [dbo].[sp_MergeWebsiteStatsToLive]
    @adfPipelineRunId NVARCHAR(36)
AS

--Selects all of our newly added records into a temp table and join to the correct records in the dimension tables where required. 
--In this case, it's only DimHTTPCode where we want to return a value from as we are pulling the primary/surrogate key column from that table instead
--of writing the HTTP Code value explicitly each time. We are not doing any joins to DimDate as it is a 1-1 join with the same value on each
--side of the relationship. We will also rename columns in the temp table so they match the schema of the final fact table

SELECT 
STG.[timeGenerated] AS [Request_Timestamp_UTC],
STG.[requestDate] AS [Request_Date_UTC],
STG.[requestHour] AS [Request_Hour_UTC],
STG.[userAction] AS [Request_User_Action],
STG.[appUrl] AS [Request_App_URL],
STG.[successFlag] AS [Request_Success_Flag],
DHC.[Http_Code_Key] AS [Request_HTTP_Code],
STG.[durationOfRequestMs] AS [Request_Duration_Milliseconds],
STG.[clientType] AS [Request_Client_Type],
STG.[clientOS] AS [Request_Client_OS],
STG.[clientBrowser] AS [Request_Client_Browser],
STG.[clientCity] AS [Request_Client_City],
STG.[clientStateOrProvince] AS [Request_Client_State_Or_Province],
STG.[clientCountryOrRegion] AS [Request_Client_Country_Or_Region],
STG.[appRoleName] AS [Request_App_Role_Name]
INTO #WebsiteStatsNewRecords
FROM [dbo].[staging_factHubnetCloudWebsiteStats] STG 
LEFT JOIN [dbo].[DimHTTPCode] DHC ON STG.[httpResultCode] = DHC.[Http_Error_Code] 
WHERE STG.[adfPipelineRunId] = @adfPipelineRunId

--Now we're going to merge in any records that do not already exist in the fact table so we avoid data duplication

MERGE INTO [dbo].[FactHubnetCloudWebsiteStats] DST
USING #WebsiteStatsNewRecords SRC
ON DST.[Request_Timestamp_UTC] = SRC.[Request_Timestamp_UTC]
AND DST.[Request_Date_UTC] = SRC.[Request_Date_UTC]
AND DST.[Request_Hour_UTC] = SRC.[Request_Hour_UTC]
AND DST.[Request_User_Action] = SRC.[Request_User_Action]
AND DST.[Request_App_URL] = SRC.[Request_App_URL]
AND DST.[Request_Success_Flag] = SRC.[Request_Success_Flag]
AND DST.[Request_HTTP_Code] = SRC.[Request_HTTP_Code]
AND DST.[Request_Duration_Milliseconds] = SRC.[Request_Duration_Milliseconds]
AND DST.[Request_Client_Type] = SRC.[Request_Client_Type]
AND DST.[Request_Client_OS] = SRC.[Request_Client_OS]
AND DST.[Request_Client_Browser] = SRC.[Request_Client_Browser]
AND DST.[Request_Client_City] = SRC.[Request_Client_City]
AND DST.[Request_Client_State_Or_Province] = SRC.[Request_Client_State_Or_Province]
AND DST.[Request_Client_Country_Or_Region] = SRC.[Request_Client_Country_Or_Region]
AND DST.[Request_App_Role_Name] = SRC.[Request_App_Role_Name]
WHEN NOT MATCHED BY TARGET THEN INSERT
(
[Request_Timestamp_UTC],
[Request_Date_UTC],
[Request_Hour_UTC],
[Request_User_Action],
[Request_App_URL],
[Request_Success_Flag],
[Request_HTTP_Code],
[Request_Duration_Milliseconds],
[Request_Client_Type],
[Request_Client_OS],
[Request_Client_Browser],
[Request_Client_City],
[Request_Client_State_Or_Province],
[Request_Client_Country_Or_Region],
[Request_App_Role_Name]
)
VALUES
(
SRC.[Request_Timestamp_UTC],
SRC.[Request_Date_UTC],
SRC.[Request_Hour_UTC],
SRC.[Request_User_Action],
SRC.[Request_App_URL],
SRC.[Request_Success_Flag],
SRC.[Request_HTTP_Code],
SRC.[Request_Duration_Milliseconds],
SRC.[Request_Client_Type],
SRC.[Request_Client_OS],
SRC.[Request_Client_Browser],
SRC.[Request_Client_City],
SRC.[Request_Client_State_Or_Province],
SRC.[Request_Client_Country_Or_Region],
SRC.[Request_App_Role_Name]
);

--Some logic to control the size of your staging table by only keeping limited history, in this case, 1 week

DELETE FROM [dbo].[staging_factHubnetCloudWebsiteStats]
WHERE [adfCopyTimestamp] < DATEADD(WEEK,-1,GETUTCDATE())