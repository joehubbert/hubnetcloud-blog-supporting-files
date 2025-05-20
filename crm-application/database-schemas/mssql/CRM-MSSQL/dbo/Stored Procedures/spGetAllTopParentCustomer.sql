CREATE PROCEDURE [dbo].[spGetAllTopParentCustomer]
AS

SELECT
[Global Parent Customer Id],
[Top Parent Customer Id],
[Customer Id],
[Account Manager],
[Customer Tier],
[Customer Type],
[Sales Region],
[First Name],
[Last Name],
[Company Name],
[Credit Enabled],
[Credit Limit],
[Payment Days],
[Global Parent Customer],
[Top Parent Customer],
[Active Status],
[Customer Since]
FROM [dbo].[vwCustomer]
WHERE [Top Parent Customer] = 1