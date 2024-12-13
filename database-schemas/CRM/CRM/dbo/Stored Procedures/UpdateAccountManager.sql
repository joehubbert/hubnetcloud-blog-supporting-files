CREATE PROCEDURE [dbo].[UpdateAccountManager]
	@accountManagerId UNIQUEIDENTIFIER,
	@firstName NVARCHAR(50),
	@lastName NVARCHAR(50),
	@emailAddress NVARCHAR(50),
	@telephoneNumber NVARCHAR(50),
	@activeStatus BIT
AS

UPDATE [dbo].[AccountManager]
SET [FirstName] = @firstName,
	[LastName] = @lastName,
	[EmailAddress] = @emailAddress,
	[TelephoneNumber] = @telephoneNumber,
	[ActiveStatus] = @activeStatus
WHERE [AccountManagerId] = @accountManagerId