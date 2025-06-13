CREATE TABLE [dbo].[PromotionManufacturer]
(
	[PromotionManufacturerId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[PromotionId] UNIQUEIDENTIFIER NOT NULL,
	[ManufacturerId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_PromotionManufacturer_PromotionId] FOREIGN KEY ([PromotionId]) REFERENCES [dbo].[Promotion]([PromotionId]),
	CONSTRAINT [FK_PromotionManufacturer_ManufacturerId] FOREIGN KEY ([ManufacturerId]) REFERENCES [dbo].[Manufacturer]([ManufacturerId]),
	CONSTRAINT [UC_PromotionManufacturer_PromotionId_ManufacturerId] UNIQUE ([PromotionId], [ManufacturerId])
)
GO

CREATE INDEX [IX_PromotionManufacturer_ManufacturerId] ON [dbo].[PromotionManufacturer] ([ManufacturerId])
GO

CREATE TRIGGER [TRG_UpdatePromotionManufacturer]
ON [dbo].[PromotionManufacturer]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[PromotionManufacturer]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[PromotionManufacturer] pm
    INNER JOIN 
        inserted i ON pm.[PromotionManufacturerId] = i.[PromotionManufacturerId];
END
GO