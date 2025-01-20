CREATE PROCEDURE [dbo].[spUpdateSupplier]
    @activeStatus BIT,
	@addressLine1 NVARCHAR(50),
    @addressLine2 NVARCHAR(50),
    @addressLine3 NVARCHAR(50),
    @addressLine4 NVARCHAR(50),
    @addressLine5 NVARCHAR(50),
    @emailAddress NVARCHAR(50),
    @paymentCurrencyId UNIQUEIDENTIFIER,
    @paymentDays TINYINT,
    @supplierId UNIQUEIDENTIFIER,
    @supplierName NVARCHAR(50),
    @telephoneNumber NVARCHAR(50),
    @vatNumber NVARCHAR(50) = NULL
AS

UPDATE [dbo].[Supplier]
SET
    [ActiveStatus] = @activeStatus,
    [AddressLine1] = @addressLine1,
    [AddressLine2] = @addressLine2,
    [AddressLine3] = @addressLine3,
    [AddressLine4] = @addressLine4,
    [AddressLine5] = @addressLine5,
    [EmailAddress] = @emailAddress,
    [PaymentCurrencyId] = @paymentCurrencyId,
    [PaymentDays] = @paymentDays,
    [SupplierName] = @supplierName,
    [TelephoneNumber] = @telephoneNumber,
    [VATNumber] = @vatNumber
WHERE [SupplierId] = @supplierId