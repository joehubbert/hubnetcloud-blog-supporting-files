CREATE PROCEDURE [dbo].[spGetAllProduct]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Product Id],
			[Product Category Id],
			[Product Category],
			[Product Sub Category Id],
			[Product Sub Category],
			[Product Family Id],
			[Product Family],
			[Product Name],
			[Product Description],
			[Manufacturer Id],
			[Manufacturer Name],
			[Manufacturer Part Number],
			[Product Country Of Origin Id],
			[Product Country Of Origin],
			[Wholesale Carton Barcode],
			[Wholesale Unit Quantity Per Carton],
			[Wholesale Carton Stock Quantity Held],
			[Wholesale Carton Weight Kilogram],
			[Wholesale Carton Height Centimeter],
			[Wholesale Carton Width Centimeter],
			[Wholesale Carton Depth Centimeter],
			[Wholesale Reorder Flag],
			[Unit Barcode],
			[Unit Selling Price],
			[Unit Minimum Order Quantity],
			[Unit Minimum Stock Quantity],
			[Unit Stock Quantity Held],
			[Unit Weight Kilogram],
			[Unit Height Centimeter],
			[Unit Width Centimeter],
			[Unit Depth Centimeter],
			[Active Status]
			FROM [dbo].[vwProduct]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END