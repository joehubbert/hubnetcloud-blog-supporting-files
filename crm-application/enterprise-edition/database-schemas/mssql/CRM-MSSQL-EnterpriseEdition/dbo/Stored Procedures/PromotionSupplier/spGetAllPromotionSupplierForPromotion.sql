CREATE PROCEDURE [dbo].[spGetAllPromotionSupplierForPromotion]
	@promotionId UNIQUEIDENTIFIER
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
			[Supplier Name]
			FROM [dbo].[vwPromotionSupplier]
			WHERE [Promotion Id] = @promotionId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END