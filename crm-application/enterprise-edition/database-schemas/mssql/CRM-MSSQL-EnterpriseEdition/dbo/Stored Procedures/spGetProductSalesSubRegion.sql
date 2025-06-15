CREATE PROCEDURE [dbo].[spGetProductSalesSubRegion]
	@productSalesSubRegionId UNIQUEIDENTIFIER
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
			[Sales Region],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwProductSalesSubRegion]
			WHERE [Product Sales Sub Region Id] = @productSalesSubRegionId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END