CREATE TABLE [dbo].[ProductSalesRegion]
(
	[ProductSalesRegionId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[ProductId] UNIQUEIDENTIFIER NOT NULL,
	[SalesRegionId] UNIQUEIDENTIFIER NOT NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_ProductSalesRegion_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([ProductId]),
	CONSTRAINT [FK_ProductSalesRegion_SalesRegionId] FOREIGN KEY ([SalesRegionId]) REFERENCES [dbo].[SalesRegion]([SalesRegionId])
)
GO

CREATE TRIGGER [TRG_UpdateProductSalesRegion]
ON [dbo].[ProductSalesRegion]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[ProductSalesRegion]
	SET 
		[ModifiedTimestamp] = GETUTCDATE(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[ProductSalesRegion] psr
	INNER JOIN 
		inserted i ON psr.[ProductSalesRegionId] = i.[ProductSalesRegionId];
END
GO