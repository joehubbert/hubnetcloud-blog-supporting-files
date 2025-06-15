CREATE PROCEDURE [dbo].[spUpdateCustomerTier]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER,
	@customerTier NVARCHAR(50),
	@customerTierCode NCHAR(1),
	@customerTierId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[CustomerTier]
			SET 
				[ActiveStatus] = @activeStatus,
				[CompanyConfigurationId] = @companyConfigurationId,
				[CustomerTierCode] = @customerTierCode,
				[CustomerTierDescription] = @customerTier
			WHERE [CustomerTierId] = @customerTierId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END