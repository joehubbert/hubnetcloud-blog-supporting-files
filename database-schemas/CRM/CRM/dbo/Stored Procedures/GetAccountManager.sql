CREATE PROCEDURE [dbo].[GetAccountManager]
	@accountManagerId UNIQUEIDENTIFIER
AS

SELECT
[FirstName],
[LastName],
[EmailAddress],
[TelephoneNumber],
[ActiveStatus]
FROM [dbo].[AccountManager]
WHERE [AccountManagerId] = @accountManagerId