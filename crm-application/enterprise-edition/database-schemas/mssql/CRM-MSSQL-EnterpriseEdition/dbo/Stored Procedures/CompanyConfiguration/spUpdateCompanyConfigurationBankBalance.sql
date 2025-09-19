CREATE PROCEDURE [dbo].[spUpdateCompanyConfigurationBankBalance]
	@bankAccountBalance MONEY,
	@companyConfigurationId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[CompanyConfiguration]
			SET
				[BankAccountBalance] = @bankAccountBalance
			WHERE [CompanyConfigurationId] = @companyConfigurationId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END