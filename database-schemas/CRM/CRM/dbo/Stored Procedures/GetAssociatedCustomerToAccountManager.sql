CREATE PROCEDURE [dbo].[GetAssociatedCustomerToAccountManager]
	@accountManagerId UNIQUEIDENTIFIER
AS

SELECT
[Customer Id],
[Customer Billing First Name],
[Customer Billing Last Name],
[Customer Billing Company Name],
[Customer Tier],
[Customer Type],
[Customer Since],
[Average Order Value],
[Credit Limit Used Percentage]
FROM [dbo].[vwAssociatedCustomerToAccountManager]
WHERE [Account Manager Id] = @accountManagerId