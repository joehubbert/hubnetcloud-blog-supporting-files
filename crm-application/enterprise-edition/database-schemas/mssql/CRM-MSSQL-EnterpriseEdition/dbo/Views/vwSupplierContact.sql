CREATE VIEW [dbo].[vwSupplierContact]
AS

SELECT
[SupplierId] AS [Supplier Id],
[SupplierContactId] AS [Supplier Contact Id],
[FirstName] AS [Supplier Contact First Name],
[LastName] AS [Supplier Contact Last Name],
[EmailAddress] AS [Supplier Contact Email Address],
[TelephoneNumber] AS [Supplier Contact Telephone Number],
[Role] AS [Supplier Contact Role],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By]
FROM [dbo].[SupplierContact]