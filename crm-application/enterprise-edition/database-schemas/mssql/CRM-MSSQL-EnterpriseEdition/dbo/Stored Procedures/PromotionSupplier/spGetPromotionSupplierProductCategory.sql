CREATE PROCEDURE [dbo].[spGetPromotionSupplierProductCategory]
	@promotionSuppliertProductCategoryId UNIQUEIDENTIFIER
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
			[Modified By],
			[Row Version]
			FROM [dbo].[vwPromotionSupplierProductCategory]
			WHERE [Promotion Supplier Product Category Id] = @promotionSuppliertProductCategoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END