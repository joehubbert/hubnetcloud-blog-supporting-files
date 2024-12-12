CREATE TABLE [dbo].[Supplier]
(
	[SupplierId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[CompanyName] NVARCHAR(50) NOT NULL, 
    [AddressLine1] NVARCHAR(50) NOT NULL, 
    [AddressLine2] NVARCHAR(50) NULL, 
    [AddressLine3] NVARCHAR(50) NOT NULL, 
    [AddressLine4] NVARCHAR(50) NOT NULL, 
    [AddressLine5] NVARCHAR(50) NOT NULL, 
    [TelephoneNumber] NVARCHAR(50) NOT NULL,
    [EmailAddress] NVARCHAR(50) NOT NULL,
    [PaymentDays] INT NOT NULL
)