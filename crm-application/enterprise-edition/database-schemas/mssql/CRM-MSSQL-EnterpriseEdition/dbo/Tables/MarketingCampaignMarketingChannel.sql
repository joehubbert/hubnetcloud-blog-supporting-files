CREATE TABLE [dbo].[MarketingCampaignMarketingChannel]
(
	[MarketingCampaignMarketingChannelId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[MarketingCampaignId] UNIQUEIDENTIFIER NOT NULL,
	[MarketingChannelId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_MarketingCampaignMarketingChannel_MarketingCampaignId] FOREIGN KEY ([MarketingCampaignId]) REFERENCES [dbo].[MarketingCampaign]([MarketingCampaignId]),
	CONSTRAINT [FK_MarketingCampaignMarketingChannel_MarketingChannelId] FOREIGN KEY ([MarketingChannelId]) REFERENCES [dbo].[MarketingChannel]([MarketingChannelId]),
	CONSTRAINT [UC_MarketingCampaignMarketingChannel_MarketingCampaignId_MarketingChannelId] UNIQUE ([MarketingCampaignId], [MarketingChannelId])
)
GO

CREATE TRIGGER [TRG_UpdateMarketingCampaignMarketingChannel]
ON [dbo].[MarketingCampaignMarketingChannel]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[MarketingCampaignMarketingChannel]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[MarketingCampaignMarketingChannel] mcmc
    INNER JOIN 
        inserted i ON mcmc.[MarketingCampaignMarketingChannelId] = i.[MarketingCampaignMarketingChannelId];
END
GO