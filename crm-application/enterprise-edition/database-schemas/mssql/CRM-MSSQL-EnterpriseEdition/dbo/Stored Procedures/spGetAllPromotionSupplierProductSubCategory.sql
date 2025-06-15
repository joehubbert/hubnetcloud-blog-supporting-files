CREATE PROCEDURE [dbo].[spGetAllPromotionSupplierProductSubCategory]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Promotion Supplier Product Sub Category Id],
			[Promotion Id],
			[Promotion Name],
			[Supplier Id],
			[Supplier Name],
			[Product Sub Category Id],
			[Product Sub Category],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwPromotionSupplierProductSubCategory]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END