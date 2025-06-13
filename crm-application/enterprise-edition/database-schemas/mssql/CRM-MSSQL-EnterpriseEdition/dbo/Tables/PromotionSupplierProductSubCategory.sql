CREATE TABLE [dbo].[PromotionSupplierProductSubCategory]
(
	[PromotionSupplierProductSubCategoryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[PromotionId] UNIQUEIDENTIFIER NOT NULL,
	[SupplierId] UNIQUEIDENTIFIER NOT NULL,
	[ProductSubCategoryId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_PromotionSupplierProductSubCategory_ProductSubCategoryId] FOREIGN KEY ([ProductSubCategoryId]) REFERENCES [dbo].[ProductSubCategory]([ProductSubCategoryId]),
	CONSTRAINT [FK_PromotionSupplierProductSubCategory_PromotionId] FOREIGN KEY ([PromotionId]) REFERENCES [dbo].[Promotion]([PromotionId]),
	CONSTRAINT [FK_PromotionSupplierProductSubCategory_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier]([SupplierId]),
	CONSTRAINT [UC_PromotionSupplier_PromotionId_SupplierId_ProductSubCategoryId] UNIQUE ([PromotionId], [SupplierId], [ProductSubCategoryId])
)
GO

CREATE INDEX [IX_PromotionSupplierProductSubCategory_SupplierId] ON [dbo].[PromotionSupplierProductSubCategory] ([SupplierId])
GO

CREATE INDEX [IX_PromotionSupplierProductSubCategory_SupplierId_ProductSubCategoryId] ON [dbo].[PromotionSupplierProductSubCategory] ([SupplierId], [ProductSubCategoryId])
GO

CREATE TRIGGER [TRG_UpdatePromotionSupplierProductSubCategory]
ON [dbo].[PromotionSupplierProductSubCategory]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[PromotionSupplierProductSubCategory]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[PromotionSupplierProductSubCategory] pspsc
    INNER JOIN 
        inserted i ON pspsc.[PromotionSupplierProductSubCategoryId] = i.[PromotionSupplierProductSubCategoryId];
END
GO