CREATE TABLE [dbo].[PromotionSupplierProductCategory]
(
	[PromotionSupplierProductCategoryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[PromotionId] UNIQUEIDENTIFIER NOT NULL,
	[SupplierId] UNIQUEIDENTIFIER NOT NULL,
	[ProductCategoryId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_PromotionSupplierProductCategory_ProductCategoryId] FOREIGN KEY ([ProductCategoryId]) REFERENCES [dbo].[ProductCategory]([ProductCategoryId]),
	CONSTRAINT [FK_PromotionSupplierProductCategory_PromotionId] FOREIGN KEY ([PromotionId]) REFERENCES [dbo].[Promotion]([PromotionId]),
	CONSTRAINT [FK_PromotionSupplierProductCategory_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier]([SupplierId]),
	CONSTRAINT [UC_PromotionSupplier_PromotionId_SupplierId_ProductCategoryId] UNIQUE ([PromotionId], [SupplierId], [ProductCategoryId])
)
GO

CREATE INDEX [NCIX_PromotionSupplierProductCategory_SupplierId] ON [dbo].[PromotionSupplierProductCategory] ([SupplierId])
GO

CREATE INDEX [NCIX_PromotionSupplierProductCategory_SupplierId_ProductCategoryId] ON [dbo].[PromotionSupplierProductCategory] ([SupplierId], [ProductCategoryId])
GO

CREATE TRIGGER [TRG_UpdatePromotionSupplierProductCategory]
ON [dbo].[PromotionSupplierProductCategory]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[PromotionSupplierProductCategory]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[PromotionSupplierProductCategory] pspc
    INNER JOIN 
        inserted i ON pspc.[PromotionSupplierProductCategoryId] = i.[PromotionSupplierProductCategoryId];
END
GO