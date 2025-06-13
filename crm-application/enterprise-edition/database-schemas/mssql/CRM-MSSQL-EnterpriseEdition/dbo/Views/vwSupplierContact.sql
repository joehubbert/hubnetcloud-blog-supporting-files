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
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[SupplierContact]