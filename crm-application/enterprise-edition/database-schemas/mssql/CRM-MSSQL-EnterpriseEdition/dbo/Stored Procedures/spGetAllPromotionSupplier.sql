CREATE PROCEDURE [dbo].[spGetAllPromotionSupplier]
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

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END