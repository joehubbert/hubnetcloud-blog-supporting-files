CREATE TABLE [dbo].[ProductSubCategory]
(
	[ProductSubCategoryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[ProductCategoryId] UNIQUEIDENTIFIER NOT NULL,
	[ProductSubCategory] NVARCHAR(50) NOT NULL,
    [ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_ProductSubCategory_ProductCategoryId] FOREIGN KEY ([ProductCategoryId]) REFERENCES [dbo].[ProductCategory]([ProductCategoryId]),
	CONSTRAINT [UC_ProductSubCategory] UNIQUE ([ProductSubCategory])
)
GO

CREATE TRIGGER [TRG_UpdateProductSubCategory]
ON [dbo].[ProductSubCategory]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[ProductSubCategory]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[ProductSubCategory] psc
    INNER JOIN 
        inserted i ON psc.[ProductSubCategoryId] = i.[ProductSubCategoryId];
END
GO