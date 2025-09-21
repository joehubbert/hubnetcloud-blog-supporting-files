CREATE PROCEDURE [dbo].[spGetAllPromotionProductForPromotion]
	@promotionId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Promotion Product Id],
			[Promotion Id],
			[Promotion Name],
			[Product Id],
			[Product Name]
			FROM [dbo].[vwPromotionProduct]
			WHERE [Promotion Id] = @promotionId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END