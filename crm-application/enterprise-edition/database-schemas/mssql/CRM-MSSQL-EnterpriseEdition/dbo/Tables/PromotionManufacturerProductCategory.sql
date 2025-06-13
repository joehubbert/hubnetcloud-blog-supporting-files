CREATE TABLE [dbo].[PromotionManufacturerProductCategory]
(
	[PromotionManufacturerProductCategoryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[PromotionId] UNIQUEIDENTIFIER NOT NULL,
	[ManufacturerId] UNIQUEIDENTIFIER NOT NULL,
	[ProductCategoryId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_PromotionManufacturerProductCategory_ProductCategoryId] FOREIGN KEY ([ProductCategoryId]) REFERENCES [dbo].[ProductCategory]([ProductCategoryId]),
	CONSTRAINT [FK_PromotionManufacturerProductCategory_PromotionId] FOREIGN KEY ([PromotionId]) REFERENCES [dbo].[Promotion]([PromotionId]),
	CONSTRAINT [FK_PromotionManufacturerProductCategory_ManufacturerId] FOREIGN KEY ([ManufacturerId]) REFERENCES [dbo].[Manufacturer]([ManufacturerId]),
	CONSTRAINT [UC_PromotionManufacturer_PromotionId_ManufacturerId_ProductCategoryId] UNIQUE ([PromotionId], [ManufacturerId], [ProductCategoryId])
)
GO

CREATE INDEX [IX_PromotionManufacturerProductCategory_ManufacturerId] ON [dbo].[PromotionManufacturerProductCategory] ([ManufacturerId])
GO

CREATE INDEX [IX_PromotionManufacturerProductCategory_ManufacturerId_ProductCategoryId] ON [dbo].[PromotionManufacturerProductCategory] ([ManufacturerId], [ProductCategoryId])
GO

CREATE TRIGGER [TRG_UpdatePromotionManufacturerProductCategory]
ON [dbo].[PromotionManufacturerProductCategory]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[PromotionManufacturerProductCategory]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[PromotionManufacturerProductCategory] pmpc
    INNER JOIN 
        inserted i ON pmpc.[PromotionManufacturerProductCategoryId] = i.[PromotionManufacturerProductCategoryId];
END
GO