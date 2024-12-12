CREATE PROCEDURE [dbo].[GetAllAccountManager]
AS

SELECT
[AccountManagerId] AS [Account Manager Id],
[FirstName] AS [First Name],
[LastName] AS [Last Name],
[EmailAddress] AS [E-Mail Address],
[TelephoneNumber] AS [Telephone Number],
[ActiveStatus] AS [Active Status]
FROM [dbo].[AccountManager]