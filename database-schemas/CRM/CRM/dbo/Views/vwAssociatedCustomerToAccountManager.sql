CREATE VIEW [dbo].[vwAssociatedCustomerToAccountManager]
AS
SELECT
C.[CustomerId] AS [Customer Id],
C.[AccountManagerId] AS [Account Manager Id],
C.[BillingFirstName] AS [Customer Billing First Name],
C.[BillingLastName] AS [Customer Billing Last Name],
C.[BillingCompanyName] AS [Customer Billing Company Name],
CTIER.[CustomerTierDescription] AS [Customer Tier],
CTYPE.[CustomerType] AS [Customer Type],
C.[CustomerSince] AS [Customer Since],
AVG(VOV.[TotalOrderValue]) AS [Average Order Value],
(SUM(CASE WHEN OS.[OrderStatus] != 'Settled' AND PM.[PaymentMethod] = 'Account Credit' THEN VOV.[TotalOrderValue] ELSE 0 END) / C.[CreditLimit]) * 100 AS [Credit Limit Used Percentage]
FROM [dbo].[Customer] C
INNER JOIN [dbo].[CustomerTier] CTIER ON C.[CustomerTierId] = CTIER.[CustomerTierId]
INNER JOIN [dbo].[CustomerType] CTYPE ON C.[CustomerTypeId] = CTYPE.[CustomerTypeId]
INNER JOIN [dbo].[Order] O ON C.[CustomerId] = O.[CustomerId]
INNER JOIN [dbo].[OrderStatus] OS ON O.[OrderStatusId] = OS.[OrderStatusId]
INNER JOIN [dbo].[PaymentMethod] PM ON O.[PaymentMethodId] = PM.[PaymentMethodId]
INNER JOIN [dbo].[vwOrderValue] VOV ON O.[OrderId] = VOV.[OrderId] AND C.[CustomerId] = VOV.[CustomerId]
GROUP BY
C.[CustomerId],
C.[BillingFirstName],
C.[BillingLastName],
C.[BillingCompanyName],
CTIER.[CustomerTierDescription],
CTYPE.[CustomerType],
C.[CustomerSince],
C.[CreditLimit]