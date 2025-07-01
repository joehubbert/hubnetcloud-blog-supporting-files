CREATE VIEW [dbo].[vwOrderQuote]
AS 

SELECT
O.[OrderId] AS [Order Id],
C.[CustomerId] AS [Customer Id],
OQ.[OrderQuoteId] AS [Order Quote Id],
OQ.[OrderQuote] AS [Order Quote],
OQ.[OrderQuoteDate] AS [Order Quote Date],
OQ.[OrderQuoteFriendlyId] AS [Order Quote Friendly Id]
FROM [dbo].[OrderQuote] OQ
INNER JOIN [dbo].[Order] O ON OQ.[OrderId] = O.[OrderId]
INNER JOIN [dbo].[Customer] C ON O.[CustomerId] = C.[CustomerId]