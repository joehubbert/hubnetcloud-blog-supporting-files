CREATE TABLE [dbo].[ProductCategory]
(
	[ProductCategoryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [ProductCategory] NVARCHAR(50) NOT NULL
)