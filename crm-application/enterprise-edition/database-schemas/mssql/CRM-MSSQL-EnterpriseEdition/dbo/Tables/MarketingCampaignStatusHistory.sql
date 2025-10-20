CREATE TABLE [dbo].[MarketingCampaignStatusHistory]
(
	[MarketingCampaignStatusHistoryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[MarketingCampaignId] UNIQUEIDENTIFIER NOT NULL,
	[MarketingCampaignStatusId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [FK_MarketingCampaignStatusHistory_MarketingCampaignId] FOREIGN KEY ([MarketingCampaignId]) REFERENCES [dbo].[MarketingCampaign]([MarketingCampaignId]),
    CONSTRAINT [FK_MarketingCampaignStatusHistory_MarketingCampaignStatusId] FOREIGN KEY ([MarketingCampaignStatusId]) REFERENCES [dbo].[MarketingCampaignStatus]([MarketingCampaignStatusId])
)
GO

CREATE NONCLUSTERED INDEX [NCIX_MarketingCampaignStatusHistory_MarketingCampaignId]
ON [dbo].[MarketingCampaignStatusHistory] ([MarketingCampaignId])
GO

CREATE TRIGGER [TRG_UpdateMarketingCampaignStatusHistory]
ON [dbo].[MarketingCampaignStatusHistory]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[MarketingCampaignStatusHistory]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[MarketingCampaignStatusHistory] mcsh
    INNER JOIN 
        inserted i ON mcsh.[MarketingCampaignStatusHistoryId] = i.[MarketingCampaignStatusHistoryId];
END
GO