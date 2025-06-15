CREATE PROCEDURE [dbo].[spGetAllProductSupplierForSupplier]
	@supplierId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Product Supplier Id],
			[Product Id],
			[Product Name],
			[Wholesale Price Per Unit],
			[Supplier Id],
			[Supplier Name],
			[Supplier Product Code],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwProductSupplier]
			WHERE [Supplier Id] = @supplierId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END