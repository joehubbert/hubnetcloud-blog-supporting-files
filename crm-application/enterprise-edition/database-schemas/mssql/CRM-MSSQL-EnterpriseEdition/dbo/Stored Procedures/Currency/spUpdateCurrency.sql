CREATE PROCEDURE [dbo].[spUpdateCurrency]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@currencyCode NCHAR(3),
	@currencyId UNIQUEIDENTIFIER,
	@currencyName NVARCHAR(50),
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[Currency]
			SET
				[ActiveStatus] = @activeStatus,
				[CompanyConfigurationId] = @companyConfigurationId,
				[CurrencyCode] = @currencyCode,
				[CurrencyName] = @currencyName,
				[MasterDataTypeId] = @masterDataTypeId
			WHERE [CurrencyId] = @currencyId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END