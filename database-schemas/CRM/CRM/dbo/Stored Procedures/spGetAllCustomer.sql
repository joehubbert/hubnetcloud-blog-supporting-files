CREATE PROCEDURE [dbo].[spGetAllCustomer]
AS

SELECT
C.[GlobalCustomerParentId] AS [Global Customer Parent Id],
C.[TopParentCustomerId] AS [Top Parent Customer Id],
C.[CustomerId] AS [Customer Id],
CONCAT(AM.[FirstName], ' ', AM.[LastName]) AS [Account Manager],
CONCAT(CTI.[CustomerTierCode], ' ', CTI.[CustomerTierDescription]) AS [Customer Tier],
CTY.[CustomerType] AS [Customer Type],
SR.[SalesRegion] AS [Sales Region],
C.[BillingCompanyName] AS [Billing Company Name],
C.[CreditEnabled] AS [Credit Enabled],
C.[CreditLimit] AS [Credit Limit],
C.[PaymentDays] AS [Payment Days],
C.[ActiveStatus] AS [Active Status],
C.[CustomerSince] AS [Customer Since]
FROM [dbo].[Customer] C
INNER JOIN [dbo].[AccountManager] AM ON C.[AccountManagerId] = AM.[AccountManagerId]
INNER JOIN [dbo].[CustomerTier] CTI ON C.[CustomerTierId] = CTI.[CustomerTierId]
INNER JOIN [dbo].[CustomerType] CTY ON C.[CustomerTypeId] = CTY.[CustomerTypeId]
INNER JOIN [dbo].[SalesRegion] SR ON C.[SalesRegionId] = SR.[SalesRegionId]