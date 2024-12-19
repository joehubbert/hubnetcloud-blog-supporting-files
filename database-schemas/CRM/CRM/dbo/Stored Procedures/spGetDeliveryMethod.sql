CREATE PROCEDURE [dbo].[spGetDeliveryMethod]
	@deliveryMethodId UNIQUEIDENTIFIER
AS

SELECT
[Delivery Method Id],
[Delivery Method],
[Delivery Cost],
[Delivery Time Days],
[Tax Profile],
[Tax Rate]
FROM [dbo].[vwDeliveryMethod]
WHERE [Delivery Method Id] = @deliveryMethodId