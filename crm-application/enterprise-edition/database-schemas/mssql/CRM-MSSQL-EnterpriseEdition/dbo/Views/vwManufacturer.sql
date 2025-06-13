CREATE VIEW [dbo].[vwManufacturer]
AS

SELECT
[ManufacturerId] AS [Manufacturer Id],
[ManufacturerName] AS [Manufacturer Name],
[AddressLine1] AS [Address Line 1],
[AddressLine2] AS [Address Line 2],
[AddressLine3] AS [Address Line 3],
[AddressLine4] AS [Address Line 4],
[AddressLine5] AS [Address Line 5],
[TelephoneNumber] AS [Telephone Number],
[EmailAddress] AS [Email Address],
[VATNumber] AS [VAT Number],
[ActiveStatus] AS [Active Status],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[Manufacturer]