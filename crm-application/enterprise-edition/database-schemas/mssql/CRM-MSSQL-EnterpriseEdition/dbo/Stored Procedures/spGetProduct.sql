CREATE PROCEDURE [dbo].[spGetProduct]
	@productId UNIQUEIDENTIFIER
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
			[Product Name],
			[Manufacturer Id],
			[Manufacturer Name],
			[Product Image],
			[Wholesale Unit Quantity Per Carton],
			[Wholesale Carton Stock Quantity Held],
			[Wholesale Reorder Flag],
			[Unit Selling Price],
			[Unit Minimum Order Quantity],
			[Unit Minimum Stock Quantity],
			[Unit Stock Quantity Held],
			[Active Status],
			[Created Timestamp],
			[Created By],
			[Modified Timestamp],
			[Modified By]
			FROM [dbo].[vwProduct]
			WHERE [Product Id] = @productId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END