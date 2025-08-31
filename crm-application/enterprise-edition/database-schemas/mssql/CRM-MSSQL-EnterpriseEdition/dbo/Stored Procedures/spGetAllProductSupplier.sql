CREATE PROCEDURE [dbo].[spGetAllProductSupplier]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Product Supplier Id],
			[Product Id],
			[Product Name],
			[Wholesale Price Per Pallet],
			[Wholesale Price Per Carton],
			[Wholesale Price Per Unit],
			[Supplier Id],
			[Supplier Name],
			[Supplier Product Code]
			FROM [dbo].[vwProductSupplier]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END