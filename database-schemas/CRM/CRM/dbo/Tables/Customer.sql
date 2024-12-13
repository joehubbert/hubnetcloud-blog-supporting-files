﻿CREATE TABLE [dbo].[Customer]
(
	[CustomerId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
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
    [CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    CONSTRAINT [FK_Customer_GlobalParentId] FOREIGN KEY ([GlobalCustomerParentId]) REFERENCES [dbo].[Customer]([CustomerId]),
    CONSTRAINT [FK_Customer_TopParentCustomerId] FOREIGN KEY ([TopParentCustomerId]) REFERENCES [dbo].[Customer]([CustomerId]),
    CONSTRAINT [FK_Customer_AccountManager] FOREIGN KEY ([AccountManagerId]) REFERENCES [dbo].[AccountManager]([AccountManagerId]),
    CONSTRAINT [FK_Customer_CustomerTier] FOREIGN KEY ([CustomerTierId]) REFERENCES [dbo].[CustomerTier]([CustomerTierId]),
    CONSTRAINT [FK_Customer_SalesRegion] FOREIGN KEY ([SalesRegionId]) REFERENCES [dbo].[SalesRegion]([SalesRegionId])
)
GO

CREATE TRIGGER [TRG_UpdateCustomer]
ON [dbo].[Customer]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[Customer]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[Customer] c
    INNER JOIN 
        inserted i ON c.[CustomerId] = i.[CustomerId];
END
GO