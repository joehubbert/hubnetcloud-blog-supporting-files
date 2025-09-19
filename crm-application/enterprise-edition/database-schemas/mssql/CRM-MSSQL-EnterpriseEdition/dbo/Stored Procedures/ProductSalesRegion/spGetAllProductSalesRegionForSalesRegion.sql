CREATE PROCEDURE [dbo].[spGetAllProductSalesRegionForSalesRegion]
	@salesRegionId UNIQUEIDENTIFIER
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
			WHERE [Sales Region Id] = @salesRegionId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END