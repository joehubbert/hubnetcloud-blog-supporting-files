CREATE PROCEDURE [dbo].[spGetAllDeliveryMethod]
AS

SELECT
[Delivery Method Id],
[Delivery Method],
[Delivery Cost],
[Delivery Time Days],
[Tax Profile],
[Tax Rate],
[Delivery Method Active Status]
FROM [dbo].[vwDeliveryMethod]