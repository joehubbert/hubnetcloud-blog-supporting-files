CREATE TABLE [dbo].[ProductCategory]
(
	[ProductCategoryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [ProductCategory] NVARCHAR(50) NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL
)
GO

CREATE TRIGGER [TRG_UpdateProductCategory]
ON [dbo].[ProductCategory]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[ProductCategory]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[ProductCategory] pc
    INNER JOIN 
        inserted i ON pc.[ProductCategoryId] = i.[ProductCategoryId];
END
GO