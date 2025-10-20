CREATE VIEW [dbo].[vwOrder]
AS

SELECT
O.[OrderId] AS [Order Id],
OT.[OrderTypeId] AS [Order Type Id],
OT.[OrderType] AS [Order Type],
O.[PurchaseOrderNumber] AS [Purchase Order Number],
O.[InternalReference] AS [Internal Reference],
CUS.[CustomerId] AS [Customer Id],
CUS.[BillingCompanyName] AS [Customer Name], 
OS.[OrderStatus] AS [Order Status],
PM.[PaymentMethod] AS [Payment Method],
VOV.[TotalOrderValue] AS [Total Order Value],
CUR.[CurrencyCode] AS [Currency Code],
O.[CreatedTimestampUTC] AS [Created Timestamp UTC],
O.[CreatedBy] AS [Created By],
O.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
O.[ModifiedBy] AS [Modified By],
O.[RowVersion] AS [Row Version]
FROM [dbo].[Order] O
INNER JOIN [dbo].[Customer] CUS ON O.[CustomerId] = CUS.[CustomerId]
INNER JOIN [dbo].[Currency] CUR ON CUS.[PaymentCurrencyId] = CUR.[CurrencyId]
INNER JOIN [dbo].[OrderPayment] OP ON O.[OrderId] = OP.[OrderId]
INNER JOIN (
    SELECT OSH1.[OrderId], OS.[OrderStatus]
    FROM [dbo].[OrderStatusHistory] OSH1
    INNER JOIN (
        SELECT [OrderId], MAX([CreatedTimestampUTC]) AS [MaxCreatedTimestampUTC]
        FROM [dbo].[OrderStatusHistory]
        GROUP BY [OrderId]
    ) OSH2 ON OSH1.[OrderId] = OSH2.[OrderId] AND OSH1.[CreatedTimestampUTC] = OSH2.[MaxCreatedTimestampUTC]
    INNER JOIN [dbo].[OrderStatus] OS ON OSH1.[OrderStatusId] = OS.[OrderStatusId]
) OS ON O.[OrderId] = OS.[OrderId]
INNER JOIN [dbo].[OrderType] OT ON O.[OrderTypeId] = OT.[OrderTypeId]
INNER JOIN [dbo].[PaymentMethod] PM ON OP.[PaymentMethodId] = PM.[PaymentMethodId]
INNER JOIN [dbo].[vwOrderValue] VOV ON O.[OrderId] = VOV.[OrderId]