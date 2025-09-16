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
			[Wholesale Flag],
			[Wholesale Carton Flag],
			[Wholesale Carton Barcode],
			[Wholesale Unit Quantity Per Carton],
			[Wholesale Unit Quantity Per Pallet],
			[Wholesale Unit Stacking Height Per Pallet],
			[Wholesale Carton Stock Quantity Held],
			[Wholesale Carton Packaging Weight Kilogram],
			[Wholesale Carton Height Centimeter],
			[Wholesale Carton Width Centimeter],
			[Wholesale Carton Depth Centimeter],
			[Wholesale Carton Volume Cubic Centimeter],
			[Wholesale Carton Total Weight Kilogram],
			[Wholesale Delivery Type Id],
			[Wholesale Delivery Type],
			[Wholesale Pallet Flag],
			[Wholesale Pallet Barcode],
			[Wholesale Carton Quantity Per Pallet],
			[Wholesale Carton Stacking Height Per Pallet],
			[Wholesale Pallet Height Centimeter],
			[Wholesale Pallet Width Centimeter],
			[Wholesale Pallet Depth Centimeter],
			[Wholesale Pallet Volume Cubic Centimeter],
			[Wholesale Pallet Weight Kilogram],
			[Wholesale Pallet Total Height Centimeter],
			[Wholesale Pallet Total Volume Cubic Centimeter],
			[Wholesale Pallet Total Weight Kilogram],
			[Wholesale Reorder Flag],
			[Unit Barcode],
			[Unit Selling Price],
			[Unit Minimum Stock Quantity],
			[Unit Stock Quantity Held],
			[Unit Weight Kilogram],
			[Unit Height Centimeter],
			[Unit Width Centimeter],
			[Unit Depth Centimeter],
			[Unit Volume Cubic Centimeter],
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