CREATE PROCEDURE [dbo].[spGetPromotionSupplier]
	@promotionSupplierId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Promotion Supplier Id],
			[Promotion Id],
			[Promotion Name],
			[Supplier Id],
			[Supplier Name],
			[Created Timestmap],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwPromotionSupplier]
			WHERE [Promotion Supplier Id] = @promotionSupplierId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END