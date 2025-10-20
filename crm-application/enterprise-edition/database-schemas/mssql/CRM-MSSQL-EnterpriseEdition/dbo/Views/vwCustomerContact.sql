CREATE VIEW [dbo].[vwCustomerContact]
AS

SELECT
[CustomerId] AS [Customer Id],
[CustomerContactId] AS [Customer Contact Id],
[FirstName] AS [Customer Contact First Name],
[LastName] AS [Customer Contact Last Name],
[EmailAddress] AS [Customer Contact Email Address],
[TelephoneNumber] AS [Customer Contact Telephone Number],
[Role] AS [Customer Contact Role],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By],
[RowVersion] AS [Row Version]
FROM [dbo].[CustomerContact]