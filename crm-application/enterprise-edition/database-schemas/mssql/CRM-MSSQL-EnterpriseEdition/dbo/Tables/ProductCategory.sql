CREATE TABLE [dbo].[ProductCategory]
(
	[ProductCategoryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [ProductCategory] NVARCHAR(50) NOT NULL,
    [CompanyConfigurationId] UNIQUEIDENTIFIER NOT NULL,
    [ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [FK_ProductCategory_CompanyConfiguration] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration]([CompanyConfigurationId]),
    CONSTRAINT [UC_ProductCategory] UNIQUE ([ProductCategory])
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
        [ModifiedTimestampUTC] = SYSUTCDATETIME(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[ProductCategory] pc
    INNER JOIN 
        inserted i ON pc.[ProductCategoryId] = i.[ProductCategoryId];
END
GO