CREATE PROCEDURE [dbo].[spUpdateCompanyConfiguration]
    @addressLine1 NVARCHAR(50),
    @addressLine2 NVARCHAR(50) = NULL,
    @addressLine3 NVARCHAR(50),
    @addressLine4 NVARCHAR(50),
    @addressLine5 NVARCHAR(50),
	@companyId UNIQUEIDENTIFIER,
	@companyName NVARCHAR(50),
    @emailAddress NVARCHAR(50),
    @telephoneNumber NVARCHAR(50),
    @vatNumber NVARCHAR(50) = NULL
AS

UPDATE [dbo].[CompanyConfiguration]
SET
    [AddressLine1] = @addressLine1,
    [AddressLine2] = @addressLine2,
    [AddressLine3] = @addressLine3,
    [AddressLine4] = @addressLine4,
    [AddressLine5] = @addressLine5,
    [CompanyName] = @companyName,
    [EmailAddress] = @emailAddress,
    [TelephoneNumber] = @telephoneNumber,
    [VATNumber] = @vatNumber
WHERE [CompanyId] = @companyId