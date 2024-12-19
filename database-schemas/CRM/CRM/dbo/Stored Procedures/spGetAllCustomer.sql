CREATE PROCEDURE [dbo].[spGetAllCustomer]
AS

SELECT
[Global Customer Parent Id],
[Top Parent Customer Id],
[Customer Id],
[Account Manager],
[Customer Tier],
[Customer Type],
[Sales Region],
[Billing Company Name],
[Credit Enabled],
[Credit Limit],
[Payment Days],
[Active Status],
[Customer Since]
FROM [dbo].[vwCustomer]