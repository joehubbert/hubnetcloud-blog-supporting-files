CREATE PROCEDURE [dbo].[spCreateCompanyConfiguration]
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
    @bankAccountCurrencyId UNIQUEIDENTIFIER,
    @bankAccountIBAN NVARCHAR(50),
    @bankAccountNumber NVARCHAR(50),
    @bankAccountName NVARCHAR(50),
    @bankAccountOpeningBalance MONEY, 
    @bankAccountSortCode NVARCHAR(50) = NULL,    
    @bankAccountSWIFTCode NVARCHAR(50),
    @bankAccountVippsId NVARCHAR(20) = NULL,
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

            CREATE TABLE #CompanyConfigurationTemp
            (
	            [CompanyName] NVARCHAR(50) NOT NULL,
                [CompanyLogo] VARBINARY(MAX) NULL,
                [AddressLine1] NVARCHAR(50) NOT NULL,
                [AddressLine2] NVARCHAR(50) NULL,
                [AddressLine3] NVARCHAR(50) NOT NULL,
                [AddressLine4] NVARCHAR(50) NOT NULL,
                [AddressLine5] UNIQUEIDENTIFIER NOT NULL,
                [TelephoneNumber] NVARCHAR(50) NOT NULL,
                [EmailAddress] NVARCHAR(50) NOT NULL,
                [EmailTopLevelDomain] NVARCHAR(50) NOT NULL,
                [VATNumber] NVARCHAR(50) NULL,
                [WebsiteURL] NVARCHAR(50) NULL,
                [BankAccountBalance] MONEY NOT NULL,
                [BankAccountCurrencyId] UNIQUEIDENTIFIER NOT NULL,
                [BankAccountNumber] NVARCHAR(50) NOT NULL,
                [BankAccountName] NVARCHAR(50) NOT NULL,
                [BankAccountSortCode] NVARCHAR(50) NULL,
                [BankAccountIBAN] NVARCHAR(50) NULL,
                [BankAccountSWIFTCode] NVARCHAR(50) NULL,
                [BankAccountAddressLine1] NVARCHAR(50) NOT NULL,
                [BankAccountAddressLine2] NVARCHAR(50) NULL,
                [BankAccountAddressLine3] NVARCHAR(50) NOT NULL,
                [BankAccountAddressLine4] NVARCHAR(50) NOT NULL,
                [BankAccountAddressLine5] UNIQUEIDENTIFIER NOT NULL,
                [BankAccountVippsId] NVARCHAR(20) NULL
            )

            INSERT INTO #CompanyConfigurationTemp
            (
                [CompanyName],
                [CompanyLogo],
                [AddressLine1],
                [AddressLine2],
                [AddressLine3],
                [AddressLine4],
                [AddressLine5],
                [TelephoneNumber],
                [EmailAddress],
                [EmailTopLevelDomain],
                [VATNumber],
                [WebsiteURL],
                [BankAccountBalance],
                [BankAccountCurrencyId],
                [BankAccountNumber],
                [BankAccountName],
                [BankAccountSortCode],
                [BankAccountIBAN],
                [BankAccountSWIFTCode],
                [BankAccountAddressLine1],
                [BankAccountAddressLine2],
                [BankAccountAddressLine3],
                [BankAccountAddressLine4],
                [BankAccountAddressLine5],
                [BankAccountVippsId]
            )
            VALUES
            (
                @companyName,
                @companyLogo,
                @addressLine1,
                @addressLine2,
                @addressLine3,
                @addressLine4,
                @addressLine5,
                @telephoneNumber,
                @emailAddress,
                @emailTopLevelDomain,
                @vatNumber,
                @websiteURL,
                @bankAccountOpeningBalance,
                @bankAccountCurrencyId,
                @bankAccountNumber,
                @bankAccountName,
                @bankAccountSortCode,
                @bankAccountIBAN,
                @bankAccountSWIFTCode,
                @bankAccountAddressLine1,
                @bankAccountAddressLine2,
                @bankAccountAddressLine3,
                @bankAccountAddressLine4,
                @bankAccountAddressLine5,
                @bankAccountVippsId
            )

            IF EXISTS
            (
            SELECT *
            FROM [dbo].[CompanyConfiguration] C
            INNER JOIN #CompanyConfigurationTemp CT ON C.[CompanyName] = CT.[CompanyName]
            AND C.[VATNumber] = CT.[VATNumber]
            WHERE C.[CompanyName] = CT.[CompanyName]
            AND C.[VATNumber] = CT.[VATNumber]
            )
            THROW 50000, 'Company already exists, please update the existing record.', 1;
            ELSE
            MERGE INTO [dbo].[CompanyConfiguration] AS target
            USING #CompanyConfigurationTemp AS source
            ON target.[AddressLine1] = source.[AddressLine1]
            AND target.[AddressLine2] = source.[AddressLine2]
            AND target.[AddressLine3] = source.[AddressLine3]
            AND target.[AddressLine4] = source.[AddressLine4]
            AND target.[AddressLine5] = source.[AddressLine5]
            AND target.[CompanyName] = source.[CompanyName]
            AND target.[EmailAddress] = source.[EmailAddress]
            AND target.[EmailTopLevelDomain] = source.[EmailTopLevelDomain]
            AND target.[TelephoneNumber] = source.[TelephoneNumber]
            AND target.[VATNumber] = source.[VATNumber]
            AND target.[WebsiteURL] = source.[WebsiteURL]
            AND target.[BankAccountBalance] = source.[BankAccountBalance]
            AND target.[BankAccountCurrencyId] = source.[BankAccountCurrencyId]
            AND target.[BankAccountNumber] = source.[BankAccountNumber]
            AND target.[BankAccountName] = source.[BankAccountName]
            AND target.[BankAccountSortCode] = source.[BankAccountSortCode]
            AND target.[BankAccountIBAN] = source.[BankAccountIBAN]
            AND target.[BankAccountSWIFTCode] = source.[BankAccountSWIFTCode]
            AND target.[BankAccountAddressLine1] = source.[BankAccountAddressLine1]
            AND target.[BankAccountAddressLine2] = source.[BankAccountAddressLine2]
            AND target.[BankAccountAddressLine3] = source.[BankAccountAddressLine3]
            AND target.[BankAccountAddressLine4] = source.[BankAccountAddressLine4]
            AND target.[BankAccountAddressLine5] = source.[BankAccountAddressLine5]
            AND target.[BankAccountVippsId] = source.[BankAccountVippsId]
            WHEN NOT MATCHED THEN
            INSERT
            (
                [CompanyName],
                [CompanyLogo],
                [AddressLine1],
                [AddressLine2],
                [AddressLine3],
                [AddressLine4],
                [AddressLine5],
                [TelephoneNumber],
                [EmailAddress],
                [EmailTopLevelDomain],
                [VATNumber],
                [WebsiteURL],
                [BankAccountBalance],
                [BankAccountCurrencyId],
                [BankAccountNumber],
                [BankAccountName],
                [BankAccountSortCode],
                [BankAccountIBAN],
                [BankAccountSWIFTCode],
                [BankAccountAddressLine1],
                [BankAccountAddressLine2],
                [BankAccountAddressLine3],
                [BankAccountAddressLine4],
                [BankAccountAddressLine5],
                [BankAccountVippsId]
            )
            VALUES
            (
                source.[CompanyName],
                source.[CompanyLogo],
                source.[AddressLine1],
                source.[AddressLine2],
                source.[AddressLine3],
                source.[AddressLine4],
                source.[AddressLine5],
                source.[TelephoneNumber],
                source.[EmailAddress],
                source.[EmailTopLevelDomain],
                source.[VATNumber],
                source.[WebsiteURL],
                source.[BankAccountBalance],
                source.[BankAccountCurrencyId],
                source.[BankAccountNumber],
                source.[BankAccountName],
                source.[BankAccountSortCode],
                source.[BankAccountIBAN],
                source.[BankAccountSWIFTCode],
                source.[BankAccountAddressLine1],
                source.[BankAccountAddressLine2],
                source.[BankAccountAddressLine3],
                source.[BankAccountAddressLine4],
                source.[BankAccountAddressLine5],
                source.[BankAccountVippsId]
            );

            DROP TABLE #CompanyConfigurationTemp;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END