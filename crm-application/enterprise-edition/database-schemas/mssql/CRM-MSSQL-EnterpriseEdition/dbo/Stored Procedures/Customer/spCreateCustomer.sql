CREATE PROCEDURE [dbo].[spCreateCustomer]
    @accountManagerId UNIQUEIDENTIFIER,
    @activeStatus BIT,
    @billingAddressLine1 NVARCHAR(50),
    @billingAddressLine2 NVARCHAR(50) = NULL,
    @billingAddressLine3 NVARCHAR(50),
    @billingAddressLine4 NVARCHAR(50),
    @billingAddressLine5 UNIQUEIDENTIFIER,
    @billingCompanyName NVARCHAR(50) = NULL,
    @billingEmailAddress NVARCHAR(50),
    @billingFirstName NVARCHAR(20),
    @billingLastName NVARCHAR(30),
    @billingTelephoneNumber NVARCHAR(50),
    @companyConfigurationId UNIQUEIDENTIFIER,
    @companyName NVARCHAR(50) = NULL,
    @creditEnabled BIT,
    @creditLimit MONEY,
    @customerSince DATE,
    @customerTierId UNIQUEIDENTIFIER,
    @customerTypeId UNIQUEIDENTIFIER,
    @emailAddress NVARCHAR(50),
    @firstName NVARCHAR(30),
    @globalParentCustomer BIT,
    @globalParentCustomerId UNIQUEIDENTIFIER = NULL,
    @lastName NVARCHAR(30),
    @paymentCurrencyId UNIQUEIDENTIFIER,
    @paymentDays TINYINT,
    @salesSubRegionId UNIQUEIDENTIFIER,
    @shippingAddressLine1 NVARCHAR(50),
    @shippingAddressLine2 NVARCHAR(50) = NULL,
    @shippingAddressLine3 NVARCHAR(50),
    @shippingAddressLine4 NVARCHAR(50),
    @shippingAddressLine5 UNIQUEIDENTIFIER,
    @shippingCompanyName NVARCHAR(50) = NULL,
    @shippingEmailAddress NVARCHAR(50),
    @shippingFirstName NVARCHAR(20),
    @shippingLastName NVARCHAR(30),
    @shippingTelephoneNumber NVARCHAR(50),
    @telephoneNumber NVARCHAR(13),
    @topParentCustomer BIT,
    @topParentCustomerId UNIQUEIDENTIFIER = NULL,
    @vatNumber NVARCHAR(50) = NULL,
    @vatRegistered BIT
    
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

            CREATE TABLE #CustomerTemp
            (
                [GlobalParentCustomerId] UNIQUEIDENTIFIER NULL,
                [TopParentCustomerId] UNIQUEIDENTIFIER NULL,
                [CompanyConfigurationId] UNIQUEIDENTIFIER NOT NULL,
                [AccountManagerId] UNIQUEIDENTIFIER NOT NULL,
                [CustomerTierId] UNIQUEIDENTIFIER NOT NULL,
                [CustomerTypeId] UNIQUEIDENTIFIER NOT NULL,
                [SalesSubRegionId] UNIQUEIDENTIFIER NOT NULL,
                [PaymentCurrencyId] UNIQUEIDENTIFIER NOT NULL,
                [FirstName] NVARCHAR(30) NOT NULL,
                [LastName] NVARCHAR(30) NOT NULL,
                [CompanyName] NVARCHAR(50) NULL,
                [TelephoneNumber] NVARCHAR(13) NOT NULL,
                [EmailAddress] NVARCHAR(50) NOT NULL,
                [BillingFirstName] NVARCHAR(20) NOT NULL,
                [BillingLastName] NVARCHAR(30) NOT NULL,
                [BillingCompanyName] NVARCHAR(50) NULL,
                [BillingAddressLine1] NVARCHAR(50) NOT NULL,
                [BillingAddressLine2] NVARCHAR(50) NULL,
                [BillingAddressLine3] NVARCHAR(50) NOT NULL,
                [BillingAddressLine4] NVARCHAR(50) NOT NULL,
                [BillingAddressLine5] UNIQUEIDENTIFIER NOT NULL,
                [BillingTelephoneNumber] NVARCHAR(50) NOT NULL,
                [BillingEmailAddress] NVARCHAR(50) NOT NULL,
                [ShippingFirstName] NVARCHAR(20) NOT NULL,
                [ShippingLastName] NVARCHAR(30) NOT NULL,
                [ShippingCompanyName] NVARCHAR(50) NULL,
                [ShippingAddressLine1] NVARCHAR(50) NOT NULL,
                [ShippingAddressLine2] NVARCHAR(50) NULL,
                [ShippingAddressLine3] NVARCHAR(50) NOT NULL,
                [ShippingAddressLine4] NVARCHAR(50) NOT NULL,
                [ShippingAddressLine5] UNIQUEIDENTIFIER NOT NULL,
                [ShippingTelephoneNumber] NVARCHAR(50) NOT NULL,
                [ShippingEmailAddress] NVARCHAR(50) NOT NULL,
                [CreditEnabled] BIT NOT NULL,
                [CreditLimit] MONEY NOT NULL,
                [PaymentDays] TINYINT NOT NULL,
                [VATRegistered] BIT NOT NULL,
                [VATNumber] NVARCHAR(50) NULL,
                [GlobalParentCustomer] BIT NOT NULL,
                [TopParentCustomer] BIT NOT NULL,
                [ActiveStatus] BIT NOT NULL,
                [CustomerSince] DATE NOT NULL
            )

            INSERT INTO #CustomerTemp
            (
                [GlobalParentCustomerId],
                [TopParentCustomerId],
                [CompanyConfigurationId],
                [AccountManagerId],
                [CustomerTierId],
                [CustomerTypeId],
                [SalesSubRegionId],
                [PaymentCurrencyId],
                [FirstName],
                [LastName],
                [CompanyName],
                [TelephoneNumber],
                [EmailAddress],
                [BillingFirstName],
                [BillingLastName],
                [BillingCompanyName],
                [BillingAddressLine1],
                [BillingAddressLine2],
                [BillingAddressLine3],
                [BillingAddressLine4],
                [BillingAddressLine5],
                [BillingTelephoneNumber],
                [BillingEmailAddress],
                [ShippingFirstName],
                [ShippingLastName],
                [ShippingCompanyName],
                [ShippingAddressLine1],
                [ShippingAddressLine2],
                [ShippingAddressLine3],
                [ShippingAddressLine4],
                [ShippingAddressLine5],
                [ShippingTelephoneNumber],
                [ShippingEmailAddress],
                [CreditEnabled],
                [CreditLimit],
                [PaymentDays],
                [VATRegistered],
                [VATNumber],
                [GlobalParentCustomer],
                [TopParentCustomer],
                [ActiveStatus],
                [CustomerSince]
            )
            VALUES
            (
                @globalParentCustomerId,
                @topParentCustomerId,
                @companyConfigurationId,
                @accountManagerId,
                @customerTierId,
                @customerTypeId,
                @salesSubRegionId,
                @paymentCurrencyId,
                @firstName,
                @lastName,
                @companyName,
                @telephoneNumber,
                @emailAddress,
                @billingFirstName,
                @billingLastName,
                @billingCompanyName,
                @billingAddressLine1,
                @billingAddressLine2,
                @billingAddressLine3,
                @billingAddressLine4,
                @billingAddressLine5,
                @billingTelephoneNumber,
                @billingEmailAddress,
                @shippingFirstName,
                @shippingLastName,
                @shippingCompanyName,
                @shippingAddressLine1,
                @shippingAddressLine2,
                @shippingAddressLine3,
                @shippingAddressLine4,
                @shippingAddressLine5,
                @shippingTelephoneNumber,
                @shippingEmailAddress,
                @creditEnabled,
                @creditLimit,
                @paymentDays,
                @vatRegistered,
                @vatNumber,
                @globalParentCustomer,
                @topParentCustomer,
                @activeStatus,
                @customerSince
            )

            IF EXISTS
            (
                SELECT *
                FROM [dbo].[Customer] C
                INNER JOIN #CustomerTemp CT ON C.[CompanyConfigurationId] = CT.[CompanyConfigurationId]
                AND C.[FirstName] = CT.[FirstName]
                AND C.[LastName] = CT.[LastName]
                AND C.[CompanyName] = CT.[CompanyName]
                AND C.[TelephoneNumber] = CT.[TelephoneNumber]
                AND C.[EmailAddress] = CT.[EmailAddress]
                AND C.[BillingFirstName] = CT.[BillingFirstName]
                AND C.[BillingLastName] = CT.[BillingLastName]
                AND C.[BillingCompanyName] = CT.[BillingCompanyName]
                AND C.[BillingAddressLine1] = CT.[BillingAddressLine1]
                AND C.[BillingAddressLine2] = CT.[BillingAddressLine2]
                AND C.[BillingAddressLine3] = CT.[BillingAddressLine3]
                AND C.[BillingAddressLine4] = CT.[BillingAddressLine4]
                AND C.[BillingAddressLine5] = CT.[BillingAddressLine5]
                AND C.[BillingTelephoneNumber] = CT.[BillingTelephoneNumber]
                AND C.[BillingEmailAddress] = CT.[BillingEmailAddress]
                AND C.[ShippingFirstName] = CT.[ShippingFirstName]
                AND C.[ShippingLastName] = CT.[ShippingLastName]
                AND C.[ShippingCompanyName] = CT.[ShippingCompanyName]
                AND C.[ShippingAddressLine1] = CT.[ShippingAddressLine1]
                AND C.[ShippingAddressLine2] = CT.[ShippingAddressLine2]
                AND C.[ShippingAddressLine3] = CT.[ShippingAddressLine3]
                AND C.[ShippingAddressLine4] = CT.[ShippingAddressLine4]
                AND C.[ShippingAddressLine5] = CT.[ShippingAddressLine5]
                AND C.[ShippingTelephoneNumber] = CT.[ShippingTelephoneNumber]
                AND C.[ShippingEmailAddress] = CT.[ShippingEmailAddress]
                WHERE C.[CompanyConfigurationId] = CT.[CompanyConfigurationId]
                AND C.[FirstName] = CT.[FirstName]
                AND C.[LastName] = CT.[LastName]
                AND C.[CompanyName] = CT.[CompanyName]
                AND C.[TelephoneNumber] = CT.[TelephoneNumber]
                AND C.[EmailAddress] = CT.[EmailAddress]
                AND C.[BillingFirstName] = CT.[BillingFirstName]
                AND C.[BillingLastName] = CT.[BillingLastName]
                AND C.[BillingCompanyName] = CT.[BillingCompanyName]
                AND C.[BillingAddressLine1] = CT.[BillingAddressLine1]
                AND C.[BillingAddressLine2] = CT.[BillingAddressLine2]
                AND C.[BillingAddressLine3] = CT.[BillingAddressLine3]
                AND C.[BillingAddressLine4] = CT.[BillingAddressLine4]
                AND C.[BillingAddressLine5] = CT.[BillingAddressLine5]
                AND C.[BillingTelephoneNumber] = CT.[BillingTelephoneNumber]
                AND C.[BillingEmailAddress] = CT.[BillingEmailAddress]
                AND C.[ShippingFirstName] = CT.[ShippingFirstName]
                AND C.[ShippingLastName] = CT.[ShippingLastName]
                AND C.[ShippingCompanyName] = CT.[ShippingCompanyName]
                AND C.[ShippingAddressLine1] = CT.[ShippingAddressLine1]
                AND C.[ShippingAddressLine2] = CT.[ShippingAddressLine2]
                AND C.[ShippingAddressLine3] = CT.[ShippingAddressLine3]
                AND C.[ShippingAddressLine4] = CT.[ShippingAddressLine4]
                AND C.[ShippingAddressLine5] = CT.[ShippingAddressLine5]
                AND C.[ShippingTelephoneNumber] = CT.[ShippingTelephoneNumber]
                AND C.[ShippingEmailAddress] = CT.[ShippingEmailAddress]
            )
            THROW 50000, 'Customer already exists, please update the existing record.', 1;
            ELSE
            MERGE INTO [dbo].[Customer] AS target
            USING #CustomerTemp AS source
            ON target.[GlobalParentCustomerId] = source.[GlobalParentCustomerId]
            AND target.[TopParentCustomerId] = source.[TopParentCustomerId]
            AND target.[CompanyConfigurationId] = source.[CompanyConfigurationId]
            AND target.[AccountManagerId] = source.[AccountManagerId]
            AND target.[CustomerTierId] = source.[CustomerTierId]
            AND target.[CustomerTypeId] = source.[CustomerTypeId]
            AND target.[SalesSubRegionId] = source.[SalesSubRegionId]
            AND target.[PaymentCurrencyId] = source.[PaymentCurrencyId]
            AND target.[FirstName] = source.[FirstName]
            AND target.[LastName] = source.[LastName]
            AND target.[CompanyName] = source.[CompanyName]
            AND target.[TelephoneNumber] = source.[TelephoneNumber]
            AND target.[EmailAddress] = source.[EmailAddress]
            AND target.[BillingFirstName] = source.[BillingFirstName]
            AND target.[BillingLastName] = source.[BillingLastName]
            AND target.[BillingCompanyName] = source.[BillingCompanyName]
            AND target.[BillingAddressLine1] = source.[BillingAddressLine1]
            AND target.[BillingAddressLine2] = source.[BillingAddressLine2]
            AND target.[BillingAddressLine3] = source.[BillingAddressLine3]
            AND target.[BillingAddressLine4] = source.[BillingAddressLine4]
            AND target.[BillingAddressLine5] = source.[BillingAddressLine5]
            AND target.[BillingTelephoneNumber] = source.[BillingTelephoneNumber]
            AND target.[BillingEmailAddress] = source.[BillingEmailAddress]
            AND target.[ShippingFirstName] = source.[ShippingFirstName]
            AND target.[ShippingLastName] = source.[ShippingLastName]
            AND target.[ShippingCompanyName] = source.[ShippingCompanyName]
            AND target.[ShippingAddressLine1] = source.[ShippingAddressLine1]
            AND target.[ShippingAddressLine2] = source.[ShippingAddressLine2]
            AND target.[ShippingAddressLine3] = source.[ShippingAddressLine3]
            AND target.[ShippingAddressLine4] = source.[ShippingAddressLine4]
            AND target.[ShippingAddressLine5] = source.[ShippingAddressLine5]
            AND target.[ShippingTelephoneNumber] = source.[ShippingTelephoneNumber]
            AND target.[ShippingEmailAddress] = source.[ShippingEmailAddress]
            AND target.[CreditEnabled] = source.[CreditEnabled]
            AND target.[CreditLimit] = source.[CreditLimit]
            AND target.[PaymentDays] = source.[PaymentDays]
            AND target.[VATRegistered] = source.[VATRegistered]
            AND target.[VATNumber] = source.[VATNumber]
            AND target.[GlobalParentCustomer] = source.[GlobalParentCustomer]
            AND target.[TopParentCustomer] = source.[TopParentCustomer]
            AND target.[ActiveStatus] = source.[ActiveStatus]
            AND target.[CustomerSince] = source.[CustomerSince]
            WHEN NOT MATCHED THEN
            INSERT
            (
                [GlobalParentCustomerId],
                [TopParentCustomerId],
                [CompanyConfigurationId],
                [AccountManagerId],
                [CustomerTierId],
                [CustomerTypeId],
                [SalesSubRegionId],
                [PaymentCurrencyId],
                [FirstName],
                [LastName],
                [CompanyName],
                [TelephoneNumber],
                [EmailAddress],
                [BillingFirstName],
                [BillingLastName],
                [BillingCompanyName],
                [BillingAddressLine1],
                [BillingAddressLine2],
                [BillingAddressLine3],
                [BillingAddressLine4],
                [BillingAddressLine5],
                [BillingTelephoneNumber],
                [BillingEmailAddress],
                [ShippingFirstName],
                [ShippingLastName],
                [ShippingCompanyName],
                [ShippingAddressLine1],
                [ShippingAddressLine2],
                [ShippingAddressLine3],
                [ShippingAddressLine4],
                [ShippingAddressLine5],
                [ShippingTelephoneNumber],
                [ShippingEmailAddress],
                [CreditEnabled],
                [CreditLimit],
                [PaymentDays],
                [VATRegistered],
                [VATNumber],
                [GlobalParentCustomer],
                [TopParentCustomer],
                [ActiveStatus],
                [CustomerSince]
            )
            VALUES
            (
                source.[GlobalParentCustomerId],
                source.[TopParentCustomerId],
                source.[CompanyConfigurationId],
                source.[AccountManagerId],
                source.[CustomerTierId],
                source.[CustomerTypeId],
                source.[SalesSubRegionId],
                source.[PaymentCurrencyId],
                source.[FirstName],
                source.[LastName],
                source.[CompanyName],
                source.[TelephoneNumber],
                source.[EmailAddress],
                source.[BillingFirstName],
                source.[BillingLastName],
                source.[BillingCompanyName],
                source.[BillingAddressLine1],
                source.[BillingAddressLine2],
                source.[BillingAddressLine3],
                source.[BillingAddressLine4],
                source.[BillingAddressLine5],
                source.[BillingTelephoneNumber],
                source.[BillingEmailAddress],
                source.[ShippingFirstName],
                source.[ShippingLastName],
                source.[ShippingCompanyName],
                source.[ShippingAddressLine1],
                source.[ShippingAddressLine2],
                source.[ShippingAddressLine3],
                source.[ShippingAddressLine4],
                source.[ShippingAddressLine5],
                source.[ShippingTelephoneNumber],
                source.[ShippingEmailAddress],
                source.[CreditEnabled],
                source.[CreditLimit],
                source.[PaymentDays],
                source.[VATRegistered],
                source.[VATNumber],
                source.[GlobalParentCustomer],
                source.[TopParentCustomer],
                source.[ActiveStatus],
                source.[CustomerSince]
            );

            DROP TABLE #CustomerTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END