CREATE PROCEDURE [dbo].[spGetAllPromotionSupplierProductCategoryForSupplier]
	@supplierId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Promotion Supplier Product Category Id],
			[Promotion Id],
			[Promotion Name],
			[Supplier Id],
			[Supplier Name],
			[Product Category Id],
			[Product Category],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwPromotionSupplierProductCategory]
			WHERE [Supplier Id] = @supplierId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END