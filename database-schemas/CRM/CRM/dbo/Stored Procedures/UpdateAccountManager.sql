CREATE PROCEDURE [dbo].[UpdateAccountManager]
	@accountManagerId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[AccountManager]

WHERE [AccountManagerId] = @accountManagerId