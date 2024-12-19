CREATE PROCEDURE [dbo].[spGetProduct]
	@productId UNIQUEIDENTIFIER
AS

SELECT
[Product Id],
[Product Category Id],
[Product Category],
[Supplier Name],
[Product Name],
[Wholesale Price Per Unit],
[Wholesale Unit Quantity Per Carton],
[Wholesale Reorder Flag],
[Unit Selling Price],
[Unit Stock Quantity Held],
[Active Status],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwProduct]
WHERE [Product Id] = @productId