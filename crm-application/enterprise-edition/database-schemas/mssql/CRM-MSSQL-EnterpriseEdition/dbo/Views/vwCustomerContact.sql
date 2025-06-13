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
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[CustomerContact]