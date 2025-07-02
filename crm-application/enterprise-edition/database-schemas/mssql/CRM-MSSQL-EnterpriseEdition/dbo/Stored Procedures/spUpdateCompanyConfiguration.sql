CREATE PROCEDURE [dbo].[spUpdateCompanyConfiguration]
    @addressLine1 NVARCHAR(50),
    @addressLine2 NVARCHAR(50) = NULL,
    @addressLine3 NVARCHAR(50),
    @addressLine4 NVARCHAR(50),
    @addressLine5 UNIQUEIDENTIFIER,
    @bankAccountBalance MONEY,
    @bankAccountCurrencyId UNIQUEIDENTIFIER,
    @bankAccountNumber NVARCHAR(50),
    @bankAccountName NVARCHAR(50),
    @bankAddressLine1 NVARCHAR(50),
    @bankAddressLine2 NVARCHAR(50) = NULL,
    @bankAddressLine3 NVARCHAR(50),
    @bankAddressLine4 NVARCHAR(50),
    @bankAddressLine5 UNIQUEIDENTIFIER,
    @bankIBAN NVARCHAR(50),
    @bankSortCode NVARCHAR(50) = NULL,    
    @bankSWIFT NVARCHAR(50),
    @companyConfigurationId UNIQUEIDENTIFIER,
    @companyLogo VARBINARY(MAX) = NULL,
	@companyName NVARCHAR(50),
    @emailAddress NVARCHAR(50),
    @emailTopLevelDomain NVARCHAR(50)NULL,
    @telephoneNumber NVARCHAR(50),
    @vatNumber NVARCHAR(50) = NULL,
    @vippsId NVARCHAR(20) = NULL,
    @websiteURL NVARCHAR(50) = NULL
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
                [BankAccountCurrencyId] = @bankAccountCurrencyId,
                [BankAccountNumber] = @bankAccountNumber,
                [BankAccountName] = @bankAccountName,
                [BankAddressLine1] = @bankAddressLine1,
                [BankAddressLine2] = @bankAddressLine2,
                [BankAddressLine3] = @bankAddressLine3,
                [BankAddressLine4] = @bankAddressLine4,
                [BankAddressLine5] = @bankAddressLine5,
                [BankIBAN] = @bankIBAN,
                [BankSortCode] = @bankSortCode,
                [BankSWIFT] = @bankSWIFT,
                [EmailAddress] = @emailAddress,
                [EmailTopLevelDomain] = @emailTopLevelDomain,
                [CompanyLogo] = @companyLogo,
                [CompanyName] = @companyName,                
                [TelephoneNumber] = @telephoneNumber,
                [VATNumber] = @vatNumber,
                [VippsId] = @vippsId,
                [WebsiteURL] = @websiteURL
            WHERE [CompanyConfigurationId] = @companyConfigurationId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END