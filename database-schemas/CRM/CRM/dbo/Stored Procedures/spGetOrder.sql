CREATE PROCEDURE [dbo].[spGetOrder]
	@orderId UNIQUEIDENTIFIER
AS

SELECT
[Order Id],
[Customer Id],
[Customer Name], 
[Order Status],
[Payment Method],
[Total Order Value],
[Currency Code],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwOrder]
WHERE [Order Id] = @orderId