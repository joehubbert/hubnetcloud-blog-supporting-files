--Run in the context of reportingDatabase

CREATE TABLE [dbo].[staging_factHubnetCloudWebsiteStats](
    [timeGenerated] DATETIME2 NULL,
    [userAction] NVARCHAR(500) NULL,
    [appUrl] NVARCHAR(500) NULL,
    [successFlag] BIT NULL,
    [httpResultCode] INT NULL,
    [durationOfRequestMs] FLOAT NULL,
    [clientType] NVARCHAR(50) NULL,
    [clientOS] NVARCHAR(50) NULL,
    [clientCity] NVARCHAR(50) NULL,
    [clientStateOrProvince] NVARCHAR(50) NULL,
    [clientCountryOrRegion] NVARCHAR(50) NULL,
    [clientBrowser] NVARCHAR(50) NULL,
    [appRoleName] NVARCHAR(50) NULL,
    [requestDate] DATE NULL,
    [requestHour] TINYINT NULL,
    [adfPipelineRunId] NVARCHAR(50),
    [adfCopyTimestamp] DATETIME2
)

ALTER TABLE [dbo].[staging_factHubnetCloudWebsiteStats] ADD DEFAULT GETUTCDATE() FOR [adfCopyTimestamp]