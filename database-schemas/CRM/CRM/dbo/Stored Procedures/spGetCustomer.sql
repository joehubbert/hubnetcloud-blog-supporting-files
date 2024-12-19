CREATE PROCEDURE [dbo].[spGetCustomer]
	@customerId UNIQUEIDENTIFIER
AS

SELECT
C.[GlobalCustomerParentId] AS [Global Customer Parent Id],
C.[TopParentCustomerId] AS [Top Parent Customer Id],
C.[CustomerId] AS [Customer Id],
CONCAT(AM.[FirstName], ' ', AM.[LastName]) AS [Account Manager],
AM.[AccountManagerId] AS [Account Manager Id],
CONCAT(CTI.[CustomerTierCode], ' ', CTI.[CustomerTierDescription]) AS [Customer Tier],
CTI.[CustomerTierId] AS [Customer Tier Id],
CTY.[CustomerType] AS [Customer Type],
SR.[SalesRegion] AS [Sales Region],
SR.[SalesRegionId] AS [Sales Region Id],
C.[BillingCompanyName] AS [Billing Customer Name],
C.[BillingFirstName] AS [Billing First Name],
C.[BillingLastName] AS [Billing Last Name],
C.[BillingCompanyName] AS [Billing Company Name],
C.[BillingAddressLine1] AS [Billing Address Line 1],
C.[BillingAddressLine2] AS [Billing Address Line 2],
C.[BillingAddressLine3] AS [Billing Address Line 3],
C.[BillingAddressLine4] AS [Billing Address Line 4],
C.[BillingAddressLine5] AS [Billing Address Line 5],
C.[BillingTelephoneNumber] AS [Billing Telephone Number],
C.[BillingEmailAddress] AS [Billing Email Address],
C.[ShippingFirstName] AS [Shipping First Name],
C.[ShippingLastName] AS [Shipping Last Name],
C.[ShippingCompanyName]	AS [Shipping Company Name],
C.[ShippingAddressLine1] AS [Shipping Address Line 1],
C.[ShippingAddressLine2] AS [Shipping Address Line 2],
C.[ShippingAddressLine3] AS [Shipping Address Line 3],
C.[ShippingAddressLine4] AS [Shipping Address Line 4],
C.[ShippingAddressLine5] AS [Shipping Address Line 5],
C.[ShippingTelephoneNumber] AS [Shipping Telephone Number],
C.[ShippingEmailAddress] AS [Shipping Email Address],
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
WHERE C.[CustomerId] = @customerId