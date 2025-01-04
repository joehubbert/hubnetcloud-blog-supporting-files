CREATE PROCEDURE [dbo].[spCreateSupplier]
    @activeStatus BIT,
	@addressLine1 NVARCHAR(50),
    @addressLine2 NVARCHAR(50),
    @addressLine3 NVARCHAR(50),
    @addressLine4 NVARCHAR(50),
    @addressLine5 NVARCHAR(50),
    @companyName NVARCHAR(50),
    @emailAddress NVARCHAR(50),
    @paymentCurrencyId UNIQUEIDENTIFIER,
    @paymentDays TINYINT,
    @telephoneNumber NVARCHAR(50),
    @vatNumber NVARCHAR(50) = NULL
AS

CREATE TABLE #SupplierTemp
(
	[CompanyName] NVARCHAR(50) NOT NULL, 
    [AddressLine1] NVARCHAR(50) NOT NULL, 
    [AddressLine2] NVARCHAR(50) NULL, 
    [AddressLine3] NVARCHAR(50) NOT NULL, 
    [AddressLine4] NVARCHAR(50) NOT NULL, 
    [AddressLine5] NVARCHAR(50) NOT NULL, 
    [TelephoneNumber] NVARCHAR(50) NOT NULL,
    [EmailAddress] NVARCHAR(50) NOT NULL,
    [PaymentDays] TINYINT NOT NULL,
    [PaymentCurrencyId] UNIQUEIDENTIFIER NOT NULL,
    [VATNumber] NVARCHAR(50) NULL,
    [ActiveStatus] BIT NOT NULL
    CONSTRAINT [FK_Supplier_Currency] FOREIGN KEY ([PaymentCurrencyId]) REFERENCES [dbo].[Currency]([CurrencyId])
)

INSERT INTO #SupplierTemp
(
    [CompanyName], 
    [AddressLine1], 
    [AddressLine2], 
    [AddressLine3], 
    [AddressLine4], 
    [AddressLine5], 
    [TelephoneNumber],
    [EmailAddress],
    [PaymentDays],
    [PaymentCurrencyId],
    [VATNumber],
    [ActiveStatus]
)
VALUES
(
    @companyName, 
    @addressLine1, 
    @addressLine2, 
    @addressLine3, 
    @addressLine4, 
    @addressLine5, 
    @telephoneNumber,
    @emailAddress,
    @paymentDays,
    @paymentCurrencyId,
    @vatNumber,
    @activeStatus
)

IF EXISTS
(
SELECT *
FROM [dbo].[Supplier] S
INNER JOIN #SupplierTemp ST ON S.[ActiveStatus] = ST.[ActiveStatus]
AND S.[AddressLine1] = ST.[AddressLine1]
AND S.[AddressLine2] = ST.[AddressLine2]
AND S.[AddressLine3] = ST.[AddressLine3]
AND S.[AddressLine4] = ST.[AddressLine4]
AND S.[AddressLine5] = ST.[AddressLine5]
AND S.[CompanyName] = ST.[CompanyName]
AND S.[EmailAddress] = ST.[EmailAddress]
AND S.[PaymentCurrencyId] = ST.[PaymentCurrencyId]
AND S.[PaymentDays] = ST.[PaymentDays]
AND S.[TelephoneNumber] = ST.[TelephoneNumber]
AND S.[VATNumber] = ST.[VATNumber]
WHERE S.[ActiveStatus] = ST.[ActiveStatus]
AND S.[AddressLine1] = ST.[AddressLine1]
AND S.[AddressLine2] = ST.[AddressLine2]
AND S.[AddressLine3] = ST.[AddressLine3]
AND S.[AddressLine4] = ST.[AddressLine4]
AND S.[AddressLine5] = ST.[AddressLine5]
AND S.[CompanyName] = ST.[CompanyName]
AND S.[EmailAddress] = ST.[EmailAddress]
AND S.[PaymentCurrencyId] = ST.[PaymentCurrencyId]
AND S.[PaymentDays] = ST.[PaymentDays]
AND S.[TelephoneNumber] = ST.[TelephoneNumber]
AND S.[VATNumber] = ST.[VATNumber]
)
THROW 50000, 'Supplier already exists, please update the existing record.', 1;
ELSE
MERGE INTO [dbo].[Supplier] AS target
USING #SupplierTemp AS source
ON target.[AddressLine1] = source.[AddressLine1]
AND target.[AddressLine2] = source.[AddressLine2]
AND target.[AddressLine3] = source.[AddressLine3]
AND target.[AddressLine4] = source.[AddressLine4]
AND target.[AddressLine5] = source.[AddressLine5]
AND target.[CompanyName] = source.[CompanyName]
AND target.[VATNumber] = source.[VATNumber]
WHEN NOT MATCHED THEN
INSERT
(
    [CompanyName], 
    [AddressLine1], 
    [AddressLine2], 
    [AddressLine3], 
    [AddressLine4], 
    [AddressLine5], 
    [TelephoneNumber],
    [EmailAddress],
    [PaymentDays],
    [PaymentCurrencyId],
    [VATNumber],
    [ActiveStatus]
)
VALUES
(
    source.[CompanyName], 
    source.[AddressLine1], 
    source.[AddressLine2], 
    source.[AddressLine3], 
    source.[AddressLine4], 
    source.[AddressLine5], 
    source.[TelephoneNumber],
    source.[EmailAddress],
    source.[PaymentDays],
    source.[PaymentCurrencyId],
    source.[VATNumber],
    source.[ActiveStatus]
);

DROP TABLE #SupplierTemp;