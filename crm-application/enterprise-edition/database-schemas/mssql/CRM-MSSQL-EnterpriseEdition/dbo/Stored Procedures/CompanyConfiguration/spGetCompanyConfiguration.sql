CREATE PROCEDURE [dbo].[spGetCompanyConfiguration]
	@companyConfigurationId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Company Configuration Id],
			[Company Name],
			[Company Logo],
			[Address Line 1],
			[Address Line 2],
			[Address Line 3],
			[Address Line 4],
			[Address Line 5],
			[Telephone Number],
			[Email Address],
			[Email Top Level Domain],
			[VAT Registered],
			[VAT Number],
			[Website URL],
			[Bank Account Balance],
			[Bank Account Currency Id],
			[Bank Account Currency Code],
			[Bank Account Currency Name],
			[Bank Account Number],
			[Bank Account Name],
			[Bank Account Sort Code],
			[Bank Account IBAN],
			[Bank Account SWIFT Code],
			[Bank Account Address Line 1],
			[Bank Account Address Line 2],
			[Bank Account Address Line 3],
			[Bank Account Address Line 4],
			[Bank Account Address Line 5],
			[Bank Account Vipps Id],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Active Status]
			FROM [dbo].[vwCompanyConfiguration]
			WHERE [Company Configuration Id] = @companyConfigurationId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END