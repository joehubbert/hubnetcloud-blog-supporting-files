CREATE TABLE [dbo].[Customer]
(
	[CustomerId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [GlobalParentCustomerId] UNIQUEIDENTIFIER NULL,
    [TopParentCustomerId] UNIQUEIDENTIFIER NULL,
    [CompanyConfigurationId] UNIQUEIDENTIFIER NOT NULL,
    [AccountManagerId] UNIQUEIDENTIFIER NOT NULL,
    [CustomerTierId] UNIQUEIDENTIFIER NOT NULL,
    [CustomerTypeId] UNIQUEIDENTIFIER NOT NULL,
    [PaymentCurrencyId] UNIQUEIDENTIFIER NOT NULL,
    [SalesSubRegionId] UNIQUEIDENTIFIER NOT NULL,
    [FirstName] NVARCHAR(30) NOT NULL,
    [LastName] NVARCHAR(30) NOT NULL,
    [CompanyName] NVARCHAR(50) NULL,
    [TelephoneNumber] NVARCHAR(13) NOT NULL,
    [EmailAddress] NVARCHAR(50) NOT NULL,
    [BillingFirstName] NVARCHAR(30) NOT NULL,
    [BillingLastName] NVARCHAR(30) NOT NULL,
    [BillingCompanyName] NVARCHAR(50) NULL,
    [BillingAddressLine1] NVARCHAR(50) NOT NULL,
    [BillingAddressLine2] NVARCHAR(50) NULL,
    [BillingAddressLine3] NVARCHAR(50) NOT NULL,
    [BillingAddressLine4] NVARCHAR(50) NOT NULL,
    [BillingAddressLine5] UNIQUEIDENTIFIER NOT NULL,
    [BillingTelephoneNumber] NVARCHAR(13) NOT NULL,
    [BillingEmailAddress] NVARCHAR(50) NOT NULL,
    [ShippingFirstName] NVARCHAR(30) NOT NULL,
    [ShippingLastName] NVARCHAR(30) NOT NULL,
    [ShippingCompanyName] NVARCHAR(50) NULL,
    [ShippingAddressLine1] NVARCHAR(50) NOT NULL,
    [ShippingAddressLine2] NVARCHAR(50) NULL,
    [ShippingAddressLine3] NVARCHAR(50) NOT NULL,
    [ShippingAddressLine4] NVARCHAR(50) NOT NULL,
    [ShippingAddressLine5] UNIQUEIDENTIFIER NOT NULL,
    [ShippingTelephoneNumber] NVARCHAR(13) NOT NULL,
    [ShippingEmailAddress] NVARCHAR(50) NOT NULL,
    [CreditEnabled] BIT NOT NULL,
    [CreditLimit] MONEY NOT NULL,
    [PaymentDays] TINYINT NOT NULL,
    [VATRegistered] BIT NOT NULL,
    [VATNumber] NVARCHAR(50) NULL,
    [GlobalParentCustomer] BIT NOT NULL,
    [TopParentCustomer] BIT NOT NULL,
    [ActiveStatus] BIT NOT NULL,
    [CustomerSince] DATE NOT NULL,
    [CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    CONSTRAINT [CC_Customer_GlobalParent_TopParent] CHECK (NOT ([GlobalParentCustomer] = 1 AND [TopParentCustomer] = 1)),
    CONSTRAINT [FK_Customer_GlobalParentCustomerId] FOREIGN KEY ([GlobalParentCustomerId]) REFERENCES [dbo].[Customer]([CustomerId]),
    CONSTRAINT [FK_Customer_TopParentCustomerId] FOREIGN KEY ([TopParentCustomerId]) REFERENCES [dbo].[Customer]([CustomerId]),
    CONSTRAINT [FK_Customer_AccountManager] FOREIGN KEY ([AccountManagerId]) REFERENCES [dbo].[AccountManager]([AccountManagerId]),
    CONSTRAINT [FK_Customer_BillingAddressLine5] FOREIGN KEY ([BillingAddressLine5]) REFERENCES [dbo].[Country]([CountryId]),
    CONSTRAINT [FK_Customer_CompanyConfiguration] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration]([CompanyConfigurationId]),
    CONSTRAINT [FK_Customer_CustomerTier] FOREIGN KEY ([CustomerTierId]) REFERENCES [dbo].[CustomerTier]([CustomerTierId]),
    CONSTRAINT [FK_Customer_CustomerType] FOREIGN KEY ([CustomerTypeId]) REFERENCES [dbo].[CustomerType]([CustomerTypeId]),
    CONSTRAINT [FK_Customer_PaymentCurrency] FOREIGN KEY ([PaymentCurrencyId]) REFERENCES [dbo].[Currency]([CurrencyId]),
    CONSTRAINT [FK_Customer_SalesSubRegion] FOREIGN KEY ([SalesSubRegionId]) REFERENCES [dbo].[SalesSubRegion]([SalesSubRegionId]),
    CONSTRAINT [FK_Customer_ShippingAddressLine5] FOREIGN KEY ([ShippingAddressLine5]) REFERENCES [dbo].[Country]([CountryId])
)
GO

CREATE NONCLUSTERED INDEX [IX_Customer_CompanyConfiguration_AccountManager]
ON [dbo].[Customer] ([CompanyConfigurationId], [AccountManagerId])
GO

CREATE NONCLUSTERED INDEX [IX_Customer_AccountManager_CustomerTier]
ON [dbo].[Customer] ([AccountManagerId], [CustomerTierId])
GO

CREATE NONCLUSTERED INDEX [IX_Customer_CreditEnabled]
ON [dbo].[Customer] ([CreditEnabled])
GO

CREATE NONCLUSTERED INDEX [IX_Customer_GlobalParentCustomer]
ON [dbo].[Customer] ([GlobalParentCustomer])
GO

CREATE NONCLUSTERED INDEX [IX_Customer_TopParentCustomer]
ON [dbo].[Customer] ([TopParentCustomer])
GO

CREATE TRIGGER [TRG_UpdateCustomer]
ON [dbo].[Customer]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[Customer]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[Customer] c
    INNER JOIN 
        inserted i ON c.[CustomerId] = i.[CustomerId];
END
GO