CREATE PROCEDURE [dbo].[CreateCustomer]
	@globalCustomerParentId UNIQUEIDENTIFIER = NULL,
	@topParentCustomerId UNIQUEIDENTIFIER = NULL,
    @accountManagerId UNIQUEIDENTIFIER,
    @customerTierId UNIQUEIDENTIFIER,
    @customerTypeId UNIQUEIDENTIFIER,
    @salesRegionId UNIQUEIDENTIFIER,
    @billingFirstName NVARCHAR(20),
    @billingLastName NVARCHAR(30),
    @billingCompanyName NVARCHAR(50),
    @billingAddressLine1 NVARCHAR(50),
    @billingAddressLine2 NVARCHAR(50) = NULL,
    @billingAddressLine3 NVARCHAR(50),
    @billingAddressLine4 NVARCHAR(50),
    @billingAddressLine5 NVARCHAR(50),
    @billingTelephoneNumber NVARCHAR(50),
    @billingEmailAddress NVARCHAR(50),
    @shippingFirstName NVARCHAR(20),
    @shippingLastName NVARCHAR(30),
    @shippingCompanyName NVARCHAR(50),
    @shippingAddressLine1 NVARCHAR(50),
    @shippingAddressLine2 NVARCHAR(50) = NULL,
    @shippingAddressLine3 NVARCHAR(50),
    @shippingAddressLine4 NVARCHAR(50),
    @shippingAddressLine5 NVARCHAR(50),
    @shippingTelephoneNumber NVARCHAR(50),
    @shippingEmailAddress NVARCHAR(50),
    @creditEnabled BIT,
    @creditLimit MONEY = NULL,
    @paymentDays INT,
    @activeStatus BIT,
    @customerSince DATE
AS
CREATE TABLE #Customer
(
    [GlobalCustomerParentId] UNIQUEIDENTIFIER NULL,
    [TopParentCustomerId] UNIQUEIDENTIFIER NULL,
    [AccountManagerId] UNIQUEIDENTIFIER NOT NULL,
    [CustomerTierId] UNIQUEIDENTIFIER NOT NULL,
    [CustomerTypeId] UNIQUEIDENTIFIER NOT NULL,
    [SalesRegionId] UNIQUEIDENTIFIER NOT NULL,
    [BillingFirstName] NVARCHAR(20) NOT NULL,
    [BillingLastName] NVARCHAR(30) NOT NULL,
    [BillingCompanyName] NVARCHAR(50) NOT NULL,
    [BillingAddressLine1] NVARCHAR(50) NOT NULL,
    [BillingAddressLine2] NVARCHAR(50) NULL,
    [BillingAddressLine3] NVARCHAR(50) NOT NULL,
    [BillingAddressLine4] NVARCHAR(50) NOT NULL,
    [BillingAddressLine5] NVARCHAR(50) NOT NULL,
    [BillingTelephoneNumber] NVARCHAR(50) NOT NULL,
    [BillingEmailAddress] NVARCHAR(50) NOT NULL,
    [ShippingFirstName] NVARCHAR(20) NOT NULL,
    [ShippingLastName] NVARCHAR(30) NOT NULL,
    [ShippingCompanyName] NVARCHAR(50) NOT NULL,
    [ShippingAddressLine1] NVARCHAR(50) NOT NULL,
    [ShippingAddressLine2] NVARCHAR(50) NULL,
    [ShippingAddressLine3] NVARCHAR(50) NOT NULL,
    [ShippingAddressLine4] NVARCHAR(50) NOT NULL,
    [ShippingAddressLine5] NVARCHAR(50) NOT NULL,
    [ShippingTelephoneNumber] NVARCHAR(50) NOT NULL,
    [ShippingEmailAddress] NVARCHAR(50) NOT NULL,
    [CreditEnabled] BIT NOT NULL,
    [CreditLimit] MONEY NULL,
    [PaymentDays] INT NOT NULL,
    [ActiveStatus] BIT NOT NULL,
    [CustomerSince] DATE NOT NULL,
    CONSTRAINT [FK_Customer_GlobalParentId] FOREIGN KEY ([GlobalCustomerParentId]) REFERENCES [dbo].[Customer]([CustomerId]),
    CONSTRAINT [FK_Customer_TopParentCustomerId] FOREIGN KEY ([TopParentCustomerId]) REFERENCES [dbo].[Customer]([CustomerId]),
    CONSTRAINT [FK_Customer_AccountManager] FOREIGN KEY ([AccountManagerId]) REFERENCES [dbo].[AccountManager]([AccountManagerId]),
    CONSTRAINT [FK_Customer_CustomerTier] FOREIGN KEY ([CustomerTierId]) REFERENCES [dbo].[CustomerTier]([CustomerTierId]),
    CONSTRAINT [FK_Customer_SalesRegion] FOREIGN KEY ([SalesRegionId]) REFERENCES [dbo].[SalesRegion]([SalesRegionId])
)

INSERT INTO #Customer
(
    [GlobalCustomerParentId],
    [TopParentCustomerId],
    [AccountManagerId],
    [CustomerTierId],
    [CustomerTypeId],
    [SalesRegionId],
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
    [ActiveStatus],
    [CustomerSince]
)
VALUES
(
    @globalCustomerParentId,
    @topParentCustomerId,
    @accountManagerId,
    @customerTierId,
    @customerTypeId,
    @salesRegionId,
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
    @activeStatus,
    @customerSince
)

IF EXISTS
(
SELECT *
FROM [dbo].[Customer]
WHERE [BillingFirstName] = @billingFirstName
AND [BillingLastName] = @billingLastName
AND [BillingCompanyName] = @billingCompanyName
AND [BillingAddressLine1] = @billingAddressLine1
AND [BillingAddressLine2] = @billingAddressLine2
AND [BillingAddressLine3] = @billingAddressLine3
AND [BillingAddressLine4] = @billingAddressLine4
AND [BillingAddressLine5] = @billingAddressLine5
AND [BillingTelephoneNumber] = @billingTelephoneNumber
AND [BillingEmailAddress] = @billingEmailAddress
AND [ShippingFirstName] = @shippingFirstName
AND [ShippingLastName] = @shippingLastName
AND [ShippingCompanyName] = @shippingCompanyName
AND [ShippingAddressLine1] = @shippingAddressLine1
AND [ShippingAddressLine2] = @shippingAddressLine2
AND [ShippingAddressLine3] = @shippingAddressLine3
AND [ShippingAddressLine4] = @shippingAddressLine4
AND [ShippingAddressLine5] = @shippingAddressLine5
AND [ShippingTelephoneNumber] = @shippingTelephoneNumber
AND [ShippingEmailAddress] = @shippingEmailAddress
)

THROW 50000, 'Customer already exists, please update the existing record.', 1;
ELSE

MERGE INTO [dbo].[Customer] AS target
USING #Customer AS source
ON target.[GlobalCustomerParentId] = source.[GlobalCustomerParentId]
AND target.[TopParentCustomerId] = source.[TopParentCustomerId]
AND target.[AccountManagerId] = source.[AccountManagerId]
AND target.[CustomerTierId] = source.[CustomerTierId]
AND target.[CustomerTypeId] = source.[CustomerTypeId]
AND target.[SalesRegionId] = source.[SalesRegionId]
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
AND target.[ActiveStatus] = source.[ActiveStatus]
AND target.[CustomerSince] = source.[CustomerSince]
WHEN NOT MATCHED THEN
INSERT
(
    [GlobalCustomerParentId],
    [TopParentCustomerId],
    [AccountManagerId],
    [CustomerTierId],
    [CustomerTypeId],
    [SalesRegionId],
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
    [ActiveStatus],
    [CustomerSince]
)
VALUES
(
    source.[GlobalCustomerParentId],
    source.[TopParentCustomerId],
    source.[AccountManagerId],
    source.[CustomerTierId],
    source.[CustomerTypeId],
    source.[SalesRegionId],
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
    source.[ActiveStatus],
    source.[CustomerSince]
);