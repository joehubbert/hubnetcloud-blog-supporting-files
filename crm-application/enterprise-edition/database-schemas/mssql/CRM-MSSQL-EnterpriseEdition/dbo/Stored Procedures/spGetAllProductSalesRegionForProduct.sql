CREATE PROCEDURE [dbo].[spGetAllProductSalesRegionForProduct]
	@productId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Product Id],
			[Product Name],
			[Sales Region Id],
			[Sales Region]
			FROM [dbo].[vwProductSalesRegion]
			WHERE [Product Id] = @productId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END