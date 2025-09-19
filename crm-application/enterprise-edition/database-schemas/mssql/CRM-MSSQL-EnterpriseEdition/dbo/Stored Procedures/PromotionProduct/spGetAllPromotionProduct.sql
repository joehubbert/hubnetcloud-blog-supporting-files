CREATE PROCEDURE [dbo].[spGetAllPromotionProduct]
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

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END