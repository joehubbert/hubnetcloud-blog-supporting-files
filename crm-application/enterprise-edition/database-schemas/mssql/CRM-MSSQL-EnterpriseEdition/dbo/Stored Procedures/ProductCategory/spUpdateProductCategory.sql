CREATE PROCEDURE [dbo].[spUpdateProductCategory]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER,
	@productCategory NVARCHAR(50),
	@productCategoryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[ProductCategory]
			SET 
				[ActiveStatus] = @activeStatus,
				[CompanyConfigurationId] = @companyConfigurationId,
				[ProductCategory] = @productCategory
			WHERE [ProductCategoryId] = @productCategoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END