#Set Global Variables
$ErrorActionPreference = 'SilentlyContinue'
$resourcePrefix = 'pbiedemo'
$scriptExecutionTimestamp = (Get-Date).ToString("yyyy-MM-dd-HH-mm")

#Read parameters from user
$azureAccountId = Read-Host "Azure Account Email Address:"
$resourceGroupName = 'PBIEmbeddedDemo'
$resourceLocation = Read-Host "Azure Region Name e.g. westeurope:"
$subscriptionName = Read-Host "Azure Subscription Name:"
$websiteURLSuffix = Read-Host "Website URL Suffix .e.g. :"
$workingDirectory = Read-Host "Enter working directory e.g. 'W:\hubnetcloud-blog-supporting-files\power-bi-embedded-reporting\infrastructure' :"

#Set Working Directory
Set-Location $workingDirectory

#Authenticate to Azure
Connect-AzAccount -AccountId $azureAccountId -Subscription $subscriptionName

#Get Object Id of Signed In User
$azureAccountObjectId = (Get-AzContext).Account.ExtendedProperties.HomeAccountId.Split('.')[0]

#Get current public IP Address of your machine
$publicIpAddress = (Invoke-WebRequest -uri "http://ifconfig.me/ip").Content

#Check to see if target resource group exists, if not, create it
$rgCheck = Get-AzResourceGroup -Name $resourceGroupName -Location $resourceLocation
if(!$rgCheck)
{
    New-AzResourceGroup -Name $resourceGroupName -Location $resourceLocation
}

#Compute Parameter Object
$templateParameters = @{
    "azureAccountId" = $azureAccountId;
    "azureAccountObjectId" = $azureAccountObjectId;
    "publicIpAddress" = $publicIpAddress;
    "resourceLocation" = $resourceLocation;
    "resourcePrefix" = $resourcePrefix;
    "websiteURLSuffix" = $websiteURLSuffix
}

#Deploy Bicep Template
New-AzResourceGroupDeployment `
-Name "$resourcePrefix-$scriptExecutionTimestamp" `
-TemplateFile .\infrastructureDeploy.bicep ` `
-TemplateParameterObject $templateParameters