CREATE PROCEDURE [dbo].[DeleteAccountManager]
	@accountManagerId UNIQUEIDENTIFIER
AS

DELETE
FROM [dbo].[AccountManager]
WHERE [AccountManagerId] = @accountManagerId