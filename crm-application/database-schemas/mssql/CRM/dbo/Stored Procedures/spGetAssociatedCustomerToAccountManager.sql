CREATE PROCEDURE [dbo].[spGetAssociatedCustomerToAccountManager]
	@accountManagerId UNIQUEIDENTIFIER
AS

SELECT
[Customer Id],
[First Name],
[Last Name],
[Company Name],
[Customer Tier],
[Customer Type],
[Customer Since],
[Average Order Value],
[Credit Limit Used Percentage]
FROM [dbo].[vwAssociatedCustomerToAccountManager]
WHERE [Account Manager Id] = @accountManagerId