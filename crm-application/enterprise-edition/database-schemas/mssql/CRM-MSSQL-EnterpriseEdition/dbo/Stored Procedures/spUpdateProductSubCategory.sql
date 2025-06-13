CREATE PROCEDURE [dbo].[spUpdateProductSubCategory]
	@activeStatus BIT,
	@productCategoryId UNIQUEIDENTIFIER,
	@productSubCategory NVARCHAR(50),
	@productSubCategoryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[ProductSubCategory]
			SET 
				[ActiveStatus] = @activeStatus,
				[ProductCategoryId] = @productCategoryId,
				[ProductSubCategory] = @productSubCategory
			WHERE [ProductSubCategoryId] = @productSubCategoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END