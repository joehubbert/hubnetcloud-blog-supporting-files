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
[Active Status]
FROM [dbo].[vwProduct]
WHERE [Product Id] = @productId