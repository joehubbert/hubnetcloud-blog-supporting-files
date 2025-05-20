CREATE PROCEDURE [dbo].[spGetAllAccountManager]
AS

SELECT
[Account Manager Id],
[First Name],
[Last Name],
[Email Address],
[Telephone Number],
[Active Status]
FROM [dbo].[vwAccountManager]