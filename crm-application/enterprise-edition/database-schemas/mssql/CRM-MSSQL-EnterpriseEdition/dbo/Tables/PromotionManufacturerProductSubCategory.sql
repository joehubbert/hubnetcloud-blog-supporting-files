CREATE TABLE [dbo].[PromotionManufacturerProductSubCategory]
(
	[PromotionManufacturerProductSubCategoryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[PromotionId] UNIQUEIDENTIFIER NOT NULL,
	[ManufacturerId] UNIQUEIDENTIFIER NOT NULL,
	[ProductSubCategoryId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_PromotionManufacturerProductSubCategory_ProductSubCategoryId] FOREIGN KEY ([ProductSubCategoryId]) REFERENCES [dbo].[ProductSubCategory]([ProductSubCategoryId]),
	CONSTRAINT [FK_PromotionManufacturerProductSubCategory_PromotionId] FOREIGN KEY ([PromotionId]) REFERENCES [dbo].[Promotion]([PromotionId]),
	CONSTRAINT [FK_PromotionManufacturerProductSubCategory_ManufacturerId] FOREIGN KEY ([ManufacturerId]) REFERENCES [dbo].[Manufacturer]([ManufacturerId]),
	CONSTRAINT [UC_PromotionManufacturer_PromotionId_ManufacturerId_ProductSubCategoryId] UNIQUE ([PromotionId], [ManufacturerId], [ProductSubCategoryId])
)
GO

CREATE INDEX [NCIX_PromotionManufacturerProductSubCategory_ManufacturerId] ON [dbo].[PromotionManufacturerProductSubCategory] ([ManufacturerId])
GO

CREATE INDEX [NCIX_PromotionManufacturerProductSubCategory_ManufacturerId_ProductSubCategoryId] ON [dbo].[PromotionManufacturerProductSubCategory] ([ManufacturerId], [ProductSubCategoryId])
GO

CREATE TRIGGER [TRG_UpdatePromotionManufacturerProductSubCategory]
ON [dbo].[PromotionManufacturerProductSubCategory]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[PromotionManufacturerProductSubCategory]
    SET 
        [ModifiedTimestampUTC] = SYSUTCDATETIME(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[PromotionManufacturerProductSubCategory] pmpsc
    INNER JOIN 
        inserted i ON pmpsc.[PromotionManufacturerProductSubCategoryId] = i.[PromotionManufacturerProductSubCategoryId];
END
GO