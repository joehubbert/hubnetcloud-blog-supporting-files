CREATE PROCEDURE [dbo].[spUpdateCompanyConfiguration]
    @addressLine1 NVARCHAR(50),
    @addressLine2 NVARCHAR(50) = NULL,
    @addressLine3 NVARCHAR(50),
    @addressLine4 NVARCHAR(50),
    @addressLine5 UNIQUEIDENTIFIER,
	@companyConfigurationId UNIQUEIDENTIFIER,
    @companyLogo VARBINARY(MAX) = NULL,
	@companyName NVARCHAR(50),
    @emailAddress NVARCHAR(50),
    @telephoneNumber NVARCHAR(50),
    @vatNumber NVARCHAR(50) = NULL,
    @websiteURL NVARCHAR(50) = NULL,
    @bankAccountCurrencyId UNIQUEIDENTIFIER,
    @bankAccountNumber NVARCHAR(50),
    @bankAccountName NVARCHAR(50),
    @bankSortCode NVARCHAR(50) = NULL,
    @bankIBAN NVARCHAR(50),
    @bankSWIFT NVARCHAR(50),
    @bankAddressLine1 NVARCHAR(50),
    @bankAddressLine2 NVARCHAR(50) = NULL,
    @bankAddressLine3 NVARCHAR(50),
    @bankAddressLine4 NVARCHAR(50),
    @bankAddressLine5 UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

            UPDATE [dbo].[CompanyConfiguration]
            SET
                [AddressLine1] = @addressLine1,
                [AddressLine2] = @addressLine2,
                [AddressLine3] = @addressLine3,
                [AddressLine4] = @addressLine4,
                [AddressLine5] = @addressLine5,
                [CompanyLogo] = @companyLogo,
                [CompanyName] = @companyName,
                [EmailAddress] = @emailAddress,
                [TelephoneNumber] = @telephoneNumber,
                [VATNumber] = @vatNumber,
                [WebsiteURL] = @websiteURL,
                [BankAccountCurrencyId] = @bankAccountCurrencyId,
                [BankAccountNumber] = @bankAccountNumber,
                [BankAccountName] = @bankAccountName,
                [BankSortCode] = @bankSortCode,
                [BankIBAN] = @bankIBAN,
                [BankSWIFT] = @bankSWIFT,
                [BankAddressLine1] = @bankAddressLine1,
                [BankAddressLine2] = @bankAddressLine2,
                [BankAddressLine3] = @bankAddressLine3,
                [BankAddressLine4] = @bankAddressLine4,
                [BankAddressLine5] = @bankAddressLine5
            WHERE [CompanyConfigurationId] = @companyConfigurationId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END