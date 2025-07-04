CREATE PROCEDURE [dbo].[spUpdateCompanyConfiguration]
    @addressLine1 NVARCHAR(50),
    @addressLine2 NVARCHAR(50) = NULL,
    @addressLine3 NVARCHAR(50),
    @addressLine4 NVARCHAR(50),
    @addressLine5 UNIQUEIDENTIFIER,
    @bankAccountAddressLine1 NVARCHAR(50),
    @bankAccountAddressLine2 NVARCHAR(50) = NULL,
    @bankAccountAddressLine3 NVARCHAR(50),
    @bankAccountAddressLine4 NVARCHAR(50),
    @bankAccountAddressLine5 UNIQUEIDENTIFIER,
    @bankAccountBalance MONEY = NULL,
    @bankAccountCurrencyId UNIQUEIDENTIFIER,
    @bankAccountIBAN NVARCHAR(50),
    @bankAccountNumber NVARCHAR(50),
    @bankAccountName NVARCHAR(50),
    @bankAccountVippsId NVARCHAR(20) = NULL,   
    @bankAccountSortCode NVARCHAR(50) = NULL,    
    @bankAccountSWIFTCode NVARCHAR(50),
    @companyConfigurationId UNIQUEIDENTIFIER,
    @companyLogo VARBINARY(MAX) = NULL,
	@companyName NVARCHAR(50),
    @emailAddress NVARCHAR(50),
    @emailTopLevelDomain NVARCHAR(50)NULL,
    @telephoneNumber NVARCHAR(50),
    @vatNumber NVARCHAR(50) = NULL,
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
                [BankAccountAddressLine1] = @bankAccountAddressLine1,
                [BankAccountAddressLine2] = @bankAccountAddressLine2,
                [BankAccountAddressLine3] = @bankAccountAddressLine3,
                [BankAccountAddressLine4] = @bankAccountAddressLine4,
                [BankAccountAddressLine5] = @bankAccountAddressLine5,
                [BankAccountCurrencyId] = @bankAccountCurrencyId,
                [BankAccountIBAN] = @bankAccountIBAN,
                [BankAccountNumber] = @bankAccountNumber,
                [BankAccountName] = @bankAccountName,               
                [BankAccountSortCode] = @bankAccountSortCode,
                [BankAccountSWIFTCode] = @bankAccountSWIFTCode,
                [BankAccountVippsId] = @bankAccountVippsId,
                [EmailAddress] = @emailAddress,
                [EmailTopLevelDomain] = @emailTopLevelDomain,
                [CompanyLogo] = @companyLogo,
                [CompanyName] = @companyName,                
                [TelephoneNumber] = @telephoneNumber,
                [VATNumber] = @vatNumber,
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