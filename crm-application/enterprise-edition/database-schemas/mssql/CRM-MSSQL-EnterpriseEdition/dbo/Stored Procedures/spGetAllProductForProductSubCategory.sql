CREATE PROCEDURE [dbo].[spGetAllProductForProductSubCategory]
	@productSubCategoryId UNIQUEIDENTIFIER
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
			[Wholesale Carton Flag],
			[Wholesale Carton Barcode],
			[Wholesale Unit Quantity Per Carton],
			[Wholesale Carton Stock Quantity Held],
			[Wholesale Carton Weight Kilogram],
			[Wholesale Carton Height Centimeter],
			[Wholesale Carton Width Centimeter],
			[Wholesale Carton Depth Centimeter],
			[Wholesale Pallet Flag],
			[Wholesale Carton Quantity Per Pallet],
			[Wholesale Pallet Height Centimeter],
			[Wholesale Pallet Width Centimeter],
			[Wholesale Pallet Depth Centimeter],
			[Wholesale Pallet Weight Kilogram],
			[Wholesale Pallet Total Height Centimeter],
			[Wholesale Pallet Total Width Centimeter],
			[Wholesale Pallet Total Depth Centimeter],
			[Wholesale Pallet Total Weight Kilogram],
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
			WHERE [Product Sub Category Id] = @productSubCategoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END