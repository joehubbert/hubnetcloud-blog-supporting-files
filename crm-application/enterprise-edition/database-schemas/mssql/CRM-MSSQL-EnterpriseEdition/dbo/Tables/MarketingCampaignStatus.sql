CREATE TABLE [dbo].[MarketingCampaignStatus]
(
	[MarketingCampaignStatusId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[MarketingCampaignStatus] NVARCHAR(50) NOT NULL,
    [ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [UC_MarketingCampaignStatus_MarketingCampaignStatus] UNIQUE ([MarketingCampaignStatus])
)
GO

CREATE TRIGGER [TRG_UpdateMarketingCampaignStatus]
ON [dbo].[MarketingCampaignStatus]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[MarketingCampaignStatus]
    SET 
        [ModifiedTimestampUTC] = SYSUTCDATETIME(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[MarketingCampaignStatus] mcs
    INNER JOIN 
        inserted i ON mcs.[MarketingCampaignStatusId] = i.[MarketingCampaignStatusId];
END
GO