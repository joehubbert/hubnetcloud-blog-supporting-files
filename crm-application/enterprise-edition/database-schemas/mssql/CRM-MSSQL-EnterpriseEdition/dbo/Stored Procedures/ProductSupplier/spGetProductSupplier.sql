CREATE PROCEDURE [dbo].[spGetProductSupplier]
	@productSupplierId UNIQUEIDENTIFIER
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
			[Wholesale Price Per Carton]
			[Wholesale Price Per Unit],
			[Supplier Id],
			[Supplier Name],
			[Supplier Product Code],
			[Delivery Lead Time Days],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwProductSupplier]
			WHERE [Product Supplier Id] = @productSupplierId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END