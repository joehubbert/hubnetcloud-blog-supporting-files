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
			[VAT Number],
			[Website URL],
			[Bank Account Balance],
			[Bank Account Currency Id],
			[Bank Account Currency Code],
			[Bank Account Currency Name],
			[Bank Account Number],
			[Bank Account Name],
			[Bank Sort Code],
			[Bank IBAN],
			[Bank SWIFT],
			[Bank Address Line 1],
			[Bank Address Line 2],
			[Bank Address Line 3],
			[Bank Address Line 4],
			[Bank Address Line 5],
			[Vipps Id]
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
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