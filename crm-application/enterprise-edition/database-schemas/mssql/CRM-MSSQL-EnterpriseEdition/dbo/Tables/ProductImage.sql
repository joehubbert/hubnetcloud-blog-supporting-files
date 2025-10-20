CREATE TABLE [dbo].[ProductImage]
(
	[ProductImageId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[ProductId] UNIQUEIDENTIFIER NOT NULL,
	[ProductImage] VARBINARY(MAX) NOT NULL,
	[ProductImageAltText] NVARCHAR(150) NULL,
	[ProductImageCaption] NVARCHAR(255) NULL,
	[ProductImageDisplayOrder] TINYINT NOT NULL,
	[ProductImageIsThumbnail] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_ProductImage_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([ProductId])
)
GO

CREATE UNIQUE INDEX [UIX_ProductImage_ThumbnailPerProduct]
ON [dbo].[ProductImage] ([ProductId])
WHERE [ProductImageIsThumbnail] = 1;
GO

CREATE NONCLUSTERED INDEX [NCIX_ProductImage_ProductId]
ON [dbo].[ProductImage] ([ProductId], [ProductImageAltText], [ProductImageCaption], [ProductImageDisplayOrder])
GO

CREATE TRIGGER [TRG_UpdateProductImage]
ON [dbo].[ProductImage]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[ProductImage]
    SET 
        [ModifiedTimestampUTC] = SYSUTCDATETIME(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[ProductImage] pi
    INNER JOIN 
        inserted i ON pi.[ProductId] = i.[ProductId];
END
GO