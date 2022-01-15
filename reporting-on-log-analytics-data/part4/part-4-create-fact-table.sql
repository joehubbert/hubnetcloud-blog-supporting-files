--Run in the context of reportingDatabase

CREATE TABLE [dbo].[FactHubnetCloudWebsiteStats](
    [Request_Timestamp_UTC] DATETIME2 NULL,
    [Request_Date_UTC] DATE NULL,
    [Request_Hour_UTC] TINYINT NULL,
    [Request_User_Action] NVARCHAR(500) NULL,
    [Request_App_URL] NVARCHAR(500) NULL,
    [Request_Success_Flag] BIT NULL,
    [Request_Http_Code] INT NULL,
    [Request_Duration_Ms] FLOAT NULL,
    [Request_Client_Type] NVARCHAR(50) NULL,
    [Request_Client_OS] NVARCHAR(50) NULL,
    [Request_Client_Browser] NVARCHAR(50) NULL,
    [Request_Client_City] NVARCHAR(50) NULL,
    [Request_Client_State_Or_Province] NVARCHAR(50) NULL,
    [Request_ClientCountryOrRegion] NVARCHAR(50) NULL,
    [Request_App_Role_Name] NVARCHAR(50)
)