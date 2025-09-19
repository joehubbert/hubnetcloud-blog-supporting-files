CREATE PROCEDURE [dbo].[spUpdateProductFamily]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER,
	@productFamily NVARCHAR(50),
	@productFamilyId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[ProductFamily]
			SET 
				[ActiveStatus] = @activeStatus,
				[CompanyConfigurationId] = @companyConfigurationId,
				[ProductFamily] = @productFamily
			WHERE [ProductFamilyId] = @productFamilyId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END