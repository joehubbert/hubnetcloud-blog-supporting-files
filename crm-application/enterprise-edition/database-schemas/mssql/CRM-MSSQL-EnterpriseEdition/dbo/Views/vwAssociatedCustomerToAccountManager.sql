CREATE VIEW [dbo].[vwAssociatedCustomerToAccountManager]
AS
SELECT
C.[CustomerId] AS [Customer Id],
C.[AccountManagerId] AS [Account Manager Id],
C.[FirstName] AS [First Name],
C.[LastName] AS [Last Name],
C.[CompanyName] AS [Company Name],
CTIER.[CustomerTierDescription] AS [Customer Tier],
CTYPE.[CustomerType] AS [Customer Type],
C.[CustomerSince] AS [Customer Since],
COUNT(NULLIF(O.[OrderId], NULL)) AS [Total Orders],
COUNT(NULLIF(VOO.[Order Id], NULL)) AS [Outstanding Orders],
AVG(VOV.[TotalOrderValue]) AS [Average Order Value],
(SUM(CASE WHEN OPS.[OrderPaymentStatus] != 'Settled' AND PM.[PaymentMethod] = 'Account Credit' THEN VOV.[TotalOrderValue] ELSE 0 END) / C.[CreditLimit]) * 100 AS [Credit Limit Used Percentage]
FROM [dbo].[Customer] C
INNER JOIN [dbo].[CustomerTier] CTIER ON C.[CustomerTierId] = CTIER.[CustomerTierId]
INNER JOIN [dbo].[CustomerType] CTYPE ON C.[CustomerTypeId] = CTYPE.[CustomerTypeId]
LEFT JOIN [dbo].[Order] O ON C.[CustomerId] = O.[CustomerId]
INNER JOIN [dbo].[OrderPayment] OP ON O.[OrderId] = OP.[OrderId]
INNER JOIN [dbo].[OrderPaymentStatusHistory] OPSH ON O.[OrderId] = OP.[OrderId]
INNER JOIN [dbo].[OrderPaymentStatus] OPS ON OPSH.[OrderPaymentStatusId] = OPS.[OrderPaymentStatusId]
INNER JOIN [dbo].[PaymentMethod] PM ON OP.[PaymentMethodId] = PM.[PaymentMethodId]
LEFT JOIN [dbo].[vwOrderValue] VOV ON O.[OrderId] = VOV.[OrderId] AND C.[CustomerId] = VOV.[CustomerId]
LEFT JOIN [dbo].[vwOrderOutstanding] VOO ON C.[CustomerId] = VOO.[Customer Id]
WHERE C.[AccountManagerId] IS NOT NULL
GROUP BY
C.[AccountManagerId],
C.[CustomerId],
C.[FirstName],
C.[LastName],
C.[CompanyName],
CTIER.[CustomerTierDescription],
CTYPE.[CustomerType],
C.[CustomerSince],
C.[CreditLimit]