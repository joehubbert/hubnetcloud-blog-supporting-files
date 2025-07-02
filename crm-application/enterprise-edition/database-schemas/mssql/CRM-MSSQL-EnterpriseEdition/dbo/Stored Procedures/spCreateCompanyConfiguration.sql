CREATE PROCEDURE [dbo].[spCreateCompanyConfiguration]
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
                [BankSortCode] NVARCHAR(50) NULL,
                [BankIBAN] NVARCHAR(50) NULL,
                [BankSWIFT] NVARCHAR(50) NULL,
                [BankAddressLine1] NVARCHAR(50) NOT NULL,
                [BankAddressLine2] NVARCHAR(50) NULL,
                [BankAddressLine3] NVARCHAR(50) NOT NULL,
                [BankAddressLine4] NVARCHAR(50) NOT NULL,
                [BankAddressLine5] UNIQUEIDENTIFIER NOT NULL,
                [VippsId] NVARCHAR(20) NULL
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
                [BankSortCode],
                [BankIBAN],
                [BankSWIFT],
                [BankAddressLine1],
                [BankAddressLine2],
                [BankAddressLine3],
                [BankAddressLine4],
                [BankAddressLine5],
                [VippsId]
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
                @bankAccountBalance,
                @bankAccountCurrencyId,
                @bankAccountNumber,
                @bankAccountName,
                @bankSortCode,
                @bankIBAN,
                @bankSWIFT,
                @bankAddressLine1,
                @bankAddressLine2,
                @bankAddressLine3,
                @bankAddressLine4,
                @bankAddressLine5,
                @vippsId
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
            AND target.[BankSortCode] = source.[BankSortCode]
            AND target.[BankIBAN] = source.[BankIBAN]
            AND target.[BankSWIFT] = source.[BankSWIFT]
            AND target.[BankAddressLine1] = source.[BankAddressLine1]
            AND target.[BankAddressLine2] = source.[BankAddressLine2]
            AND target.[BankAddressLine3] = source.[BankAddressLine3]
            AND target.[BankAddressLine4] = source.[BankAddressLine4]
            AND target.[BankAddressLine5] = source.[BankAddressLine5]
            AND target.[VippsId] = source.[VippsId]
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
                [BankSortCode],
                [BankIBAN],
                [BankSWIFT],
                [BankAddressLine1],
                [BankAddressLine2],
                [BankAddressLine3],
                [BankAddressLine4],
                [BankAddressLine5],
                [VippsId]
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
                source.[BankSortCode],
                source.[BankIBAN],
                source.[BankSWIFT],
                source.[BankAddressLine1],
                source.[BankAddressLine2],
                source.[BankAddressLine3],
                source.[BankAddressLine4],
                source.[BankAddressLine5],
                source.[VippsId]
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