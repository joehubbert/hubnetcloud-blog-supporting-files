CREATE PROCEDURE [dbo].[spGetAllCustomer]
AS

SELECT
[Global Parent Customer Id],
[Top Parent Customer Id],
[Customer Id],
[Account Manager],
[Customer Tier],
[Customer Type],
[Sales Region],
[Sales Sub Region],
[First Name],
[Last Name],
[Company Name],
[Credit Enabled],
[Credit Limit],
[Payment Days],
[VAT Number],
[Global Parent Customer],
[Top Parent Customer],
[Active Status],
[Customer Since]
FROM [dbo].[vwCustomer]