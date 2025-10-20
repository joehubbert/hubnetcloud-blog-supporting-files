CREATE TABLE [dbo].[ProductSalesSubRegion]
(
	[ProductSalesSubRegionId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[ProductId] UNIQUEIDENTIFIER NOT NULL,
	[SalesSubRegionId] UNIQUEIDENTIFIER NOT NULL,
	[EffectiveDate] DATE NOT NULL,
	[ExpiryDate] DATE NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_ProductSalesSubRegion_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([ProductId]),
	CONSTRAINT [FK_ProductSalesSubRegion_SalesSubRegionId] FOREIGN KEY ([SalesSubRegionId]) REFERENCES [dbo].[SalesSubRegion]([SalesSubRegionId]),
	CONSTRAINT [UC_ProductSalesSubRegion_ProductId_SalesSubRegionId_EffectiveDate] UNIQUE ([ProductId], [SalesSubRegionId], [EffectiveDate])
)
GO

CREATE NONCLUSTERED INDEX [NCIX_ProductSalesSubRegion_ProductId_SalesSubRegionId]
ON [dbo].[ProductSalesSubRegion] ([ProductId], [SalesSubRegionId])
GO

CREATE TRIGGER [TRG_UpdateProductSalesSubRegion]
ON [dbo].[ProductSalesSubRegion]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[ProductSalesSubRegion]
	SET 
		[ModifiedTimestampUTC] = SYSUTCDATETIME(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[ProductSalesSubRegion] pssr
	INNER JOIN 
		inserted i ON pssr.[ProductSalesSubRegionId] = i.[ProductSalesSubRegionId];
END
GO