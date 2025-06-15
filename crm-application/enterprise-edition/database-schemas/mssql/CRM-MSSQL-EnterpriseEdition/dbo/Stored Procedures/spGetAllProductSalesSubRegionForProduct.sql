CREATE PROCEDURE [dbo].[spGetAllProductSalesSubRegionForProduct]
	@productId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Product Sales Sub Region Id],
			[Product Id],
			[Product Name],
			[Sales Sub Region Id],
			[Sales Sub Region],
			[Sales Region Id],
			[Sales Region]
			FROM [dbo].[vwProductSalesSubRegion]
			WHERE [Product Id] = @productId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END