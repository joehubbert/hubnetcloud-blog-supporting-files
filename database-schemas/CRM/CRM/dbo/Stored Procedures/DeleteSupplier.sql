CREATE PROCEDURE [dbo].[DeleteSupplier]
	@supplierId UNIQUEIDENTIFIER
AS
DELETE FROM [dbo].[Supplier]
WHERE [SupplierId] = @supplierId