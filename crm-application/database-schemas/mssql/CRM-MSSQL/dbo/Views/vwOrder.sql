CREATE VIEW [dbo].[vwOrder]
AS

SELECT
O.[OrderId] AS [Order Id],
O.[CustomerId] AS [Customer Id],
CUS.[BillingCompanyName] AS [Customer Name], 
OS.[OrderStatus] AS [Order Status],
PM.[PaymentMethod] AS [Payment Method],
VOV.[TotalOrderValue] AS [Total Order Value],
CUR.[CurrencyCode] AS [Currency Code],
O.[CreatedTimestamp] AS [Created Timestamp],
O.[CreatedBy] AS [Created By],
O.[ModifiedTimestamp] AS [Modified Timestamp],
O.[ModifiedBy] AS [Modified By]
FROM [dbo].[Order] O
INNER JOIN [dbo].[Currency] CUR ON O.[PaymentMethodId] = CUR.[CurrencyId]
INNER JOIN [dbo].[Customer] CUS ON O.[CustomerId] = CUS.[CustomerId]
INNER JOIN [dbo].[OrderStatus] OS ON O.[OrderStatusId] = O.[OrderStatusId]
INNER JOIN [dbo].[PaymentMethod] PM ON O.[PaymentMethodId] = PM.[PaymentMethodId]
INNER JOIN [dbo].[vwOrderValue] VOV ON O.[OrderId] = VOV.[OrderId]