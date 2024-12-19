CREATE PROCEDURE [dbo].[spUpdateSupplier]
    @activeStatus BIT,
	@addressLine1 NVARCHAR(50),
    @addressLine2 NVARCHAR(50),
    @addressLine3 NVARCHAR(50),
    @addressLine4 NVARCHAR(50),
    @addressLine5 NVARCHAR(50),
    @companyName NVARCHAR(50),
    @emailAddress NVARCHAR(50),
    @paymentCurrencyId UNIQUEIDENTIFIER,
    @paymentDays INT,
    @supplierId UNIQUEIDENTIFIER,
    @telephoneNumber NVARCHAR(50)
AS

UPDATE [dbo].[Supplier]
SET
    [ActiveStatus] = @activeStatus,
    [AddressLine1] = @addressLine1,
    [AddressLine2] = @addressLine2,
    [AddressLine3] = @addressLine3,
    [AddressLine4] = @addressLine4,
    [AddressLine5] = @addressLine5,
    [CompanyName] = @companyName,
    [EmailAddress] = @emailAddress,
    [PaymentCurrencyId] = @paymentCurrencyId,
    [PaymentDays] = @paymentDays,
    [TelephoneNumber] = @telephoneNumber
WHERE [SupplierId] = @supplierId