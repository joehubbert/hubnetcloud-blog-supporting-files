CREATE PROCEDURE [dbo].[spGetAccountManager]
	@accountManagerId UNIQUEIDENTIFIER
AS

SELECT
[Account Manager Id],
[First Name],
[Last Name],
[Email Address],
[Telephone Number],
[Active Status],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwAccountManager]
WHERE [Account Manager Id] = @accountManagerId