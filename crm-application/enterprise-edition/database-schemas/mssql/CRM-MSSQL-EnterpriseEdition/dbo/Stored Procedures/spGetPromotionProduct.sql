CREATE PROCEDURE [dbo].[spGetPromotionProduct]
	@promotionProductId UNIQUEIDENTIFIER
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
			[Product Name],
			[Created Timestmap],
			[Created By],
			[Modified Timestamp],
			[Modified By]
			FROM [dbo].[vwPromotionProduct]
			WHERE [Promotion Product Id] = @promotionProductId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END