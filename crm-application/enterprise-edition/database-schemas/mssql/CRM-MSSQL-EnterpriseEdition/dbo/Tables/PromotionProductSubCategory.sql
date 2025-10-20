CREATE TABLE [dbo].[PromotionProductSubCategory]
(
	[PromotionProductSubCategoryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[PromotionId] UNIQUEIDENTIFIER NOT NULL,
	[ProductSubCategoryId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_PromotionProductSubCategory_ProductSubCategoryId] FOREIGN KEY ([ProductSubCategoryId]) REFERENCES [dbo].[ProductSubCategory]([ProductSubCategoryId]),
	CONSTRAINT [FK_PromotionProductSubCategory_PromotionId] FOREIGN KEY ([PromotionId]) REFERENCES [dbo].[Promotion]([PromotionId]),
	CONSTRAINT [UC_PromotionProduct_PromotionId_ProductSubCategoryId] UNIQUE ([PromotionId], [ProductSubCategoryId])
)
GO

CREATE INDEX [NCIX_PromotionProductSubCategory_ProductId_ProductSubCategoryId] ON [dbo].[PromotionProductSubCategory] ([ProductSubCategoryId])
GO

CREATE TRIGGER [TRG_UpdatePromotionProductSubCategory]
ON [dbo].[PromotionProductSubCategory]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[PromotionProductSubCategory]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[PromotionProductSubCategory] pppsc
    INNER JOIN 
        inserted i ON pppsc.[PromotionProductSubCategoryId] = i.[PromotionProductSubCategoryId];
END
GO