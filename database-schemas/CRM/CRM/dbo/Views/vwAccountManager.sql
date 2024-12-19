CREATE VIEW [dbo].[vwAccountManager]
AS

SELECT
[AccountManagerId] AS [Account Manager Id],
[FirstName] AS [First Name],
[LastName] AS [Last Name],
[EmailAddress] AS [Email Address],
[TelephoneNumber] AS [Telephone Number],
[ActiveStatus] AS [Active Status],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[AccountManager]