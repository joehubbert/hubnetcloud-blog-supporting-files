CREATE TABLE [dbo].[PromotionProductCategory]
(
	[PromotionProductCategoryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[PromotionId] UNIQUEIDENTIFIER NOT NULL,
	[ProductCategoryId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_PromotionProductCategory_ProductCategoryId] FOREIGN KEY ([ProductCategoryId]) REFERENCES [dbo].[ProductCategory]([ProductCategoryId]),
	CONSTRAINT [FK_PromotionProductCategory_PromotionId] FOREIGN KEY ([PromotionId]) REFERENCES [dbo].[Promotion]([PromotionId]),
	CONSTRAINT [UC_PromotionProductCategory_PromotionId_ProductCategoryId] UNIQUE ([PromotionId], [ProductCategoryId])
)
GO

CREATE INDEX [IX_PromotionProductCategory_ProductId_ProductCategoryId] ON [dbo].[PromotionProductCategory] ([ProductCategoryId])
GO

CREATE TRIGGER [TRG_UpdatePromotionProductCategory]
ON [dbo].[PromotionProductCategory]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[PromotionProductCategory]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[PromotionProductCategory] ppc
    INNER JOIN 
        inserted i ON ppc.[PromotionProductCategoryId] = i.[PromotionProductCategoryId];
END
GO