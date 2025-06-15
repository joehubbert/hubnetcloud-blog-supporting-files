CREATE TABLE [dbo].[Promotion]
(
	[PromotionId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[MarketingCampaignId] UNIQUEIDENTIFIER NOT NULL,
	[PromotionName] NVARCHAR(50) NOT NULL,
	[PromotionDescription] NVARCHAR(255) NOT NULL,
	[PromotionCode] NVARCHAR(15) NOT NULL,
	[PromotionTargetTypeId] UNIQUEIDENTIFIER NOT NULL,
	[PromotionTypeId] UNIQUEIDENTIFIER NOT NULL,
	[PromotionValue] DECIMAL(18, 2) NOT NULL,
	[PromotionBuyQuantity] INT NOT NULL,
	[PromotionGetQuantity] INT NOT NULL,
	[PromotionStartTimestampUTC] DATETIME2 NOT NULL,
	[PromotionEndTimestampUTC] DATETIME2 NOT NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_Promotion_MarketingCampaignId] FOREIGN KEY ([MarketingCampaignId]) REFERENCES [dbo].[MarketingCampaign]([MarketingCampaignId]),
	CONSTRAINT [FK_Promotion_PromotionTargetTypeId] FOREIGN KEY ([PromotionTargetTypeId]) REFERENCES [dbo].[PromotionTargetType]([PromotionTargetTypeId]),
	CONSTRAINT [FK_Promotion_PromotionTypeId] FOREIGN KEY ([PromotionTypeId]) REFERENCES [dbo].[PromotionType]([PromotionTypeId]),
	CONSTRAINT [UC_Promotion_PromotionCode] UNIQUE ([PromotionCode])
)
GO

CREATE INDEX [IX_Promotion_PromotionTargetTypeId] ON [dbo].[Promotion] ([PromotionTargetTypeId])
GO

CREATE INDEX [IX_Promotion_PromotionTypeId] ON [dbo].[Promotion] ([PromotionTypeId])
GO

CREATE TRIGGER [TRG_UpdatePromotion]
ON [dbo].[Promotion]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[Promotion]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[Promotion] p
    INNER JOIN 
        inserted i ON p.[PromotionId] = i.[PromotionId];
END
GO