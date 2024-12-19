CREATE PROCEDURE [dbo].[spGetAccountManager]
	@accountManagerId UNIQUEIDENTIFIER
AS

SELECT
[AccountManagerId] AS [Account Manager Id],
[FirstName] AS [First Name],
[LastName] AS [Last Name],
[EmailAddress] AS [Email Address],
[TelephoneNumber] AS [Telephone Number],
[ActiveStatus] AS [Active Status]
FROM [dbo].[AccountManager]
WHERE [AccountManagerId] = @accountManagerId