CREATE PROCEDURE [dbo].[spGetAllOrderForProduct]
	@productId UNIQUEIDENTIFIER
AS

SELECT
[Product Id],
[Order Id],
[Product Quantity],
[Product Order Value]
FROM [dbo].[vwOrderProduct]
WHERE [Product Id] = @productId