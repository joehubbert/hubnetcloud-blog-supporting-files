CREATE TABLE [dbo].[MarketingCampaignType]
(
	[MarketingCampaignTypeId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[MarketingCampaignType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [UC_MarketingCampaignType_MarketingCampaignType] UNIQUE ([MarketingCampaignType])
)
GO

CREATE TRIGGER [TRG_UpdateMarketingCampaignType]
ON [dbo].[MarketingCampaignType]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[MarketingCampaignType]
	SET 
		[ModifiedTimestamp] = GETUTCDATE(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[MarketingCampaignType] mct
	INNER JOIN 
		inserted i ON mct.[MarketingCampaignTypeId] = i.[MarketingCampaignTypeId];
END
GO