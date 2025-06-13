CREATE TABLE [dbo].[MarketingCampaign]
(
	[MarketingCampaignId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CompanyConfigurationId] UNIQUEIDENTIFIER NOT NULL,
	[MarketingCampaignTypeId] UNIQUEIDENTIFIER NOT NULL,
	[MarketingCampaignName] NVARCHAR(100) NOT NULL,
	[MarketingCampaignDescription] NVARCHAR(255) NULL,
	[MarketingCampaignGoal] NVARCHAR(255) NULL,
	[MarketingCampaignStartTimestamp] DATETIME2 NOT NULL,
	[MarketingCampaignEndTimestamp] DATETIME2 NULL,
	[Budget] MONEY NOT NULL,
	[ActualCost] MONEY NULL,
	[ForecastedRevenue] MONEY NOT NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_MarketingCampaign_CompanyConfigurationId] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration]([CompanyConfigurationId]),
	CONSTRAINT [FK_MarketingCampaign_MarketingCampaignTypeId] FOREIGN KEY ([MarketingCampaignTypeId]) REFERENCES [dbo].[MarketingCampaignType]([MarketingCampaignTypeId])
)
GO

CREATE TRIGGER [TRG_UpdateMarketingCampaign]
ON [dbo].[MarketingCampaign]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[MarketingCampaign]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[MarketingCampaign] mc
    INNER JOIN 
        inserted i ON mc.[MarketingCampaignId] = i.[MarketingCampaignId];
END
GO