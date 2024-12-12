CREATE PROCEDURE [dbo].[GetAccountManager]
	@accountManagerId UNIQUEIDENTIFIER
AS

SELECT *
FROM [dbo].[AccountManager]
WHERE [AccountManagerId] = @accountManagerId