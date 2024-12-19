CREATE PROCEDURE [dbo].[spGetAllDeliveryMethod]
AS

SELECT
DM.[DeliveryMethodId] AS [Delivery Method Id],
DM.[DeliveryMethod] AS [Delivery Method],
DM.[DeliveryCost] AS [Delivery Cost],
DM.[DeliveryTimeDays] AS [Delivery Time Days],
TP.[TaxProfile] AS [Tax Profile],
TP.[TaxRate] AS [Tax Rate]
FROM [dbo].[DeliveryMethod] DM
INNER JOIN [dbo].[TaxProfile] TP ON DM.[TaxProfileId] = TP.[TaxProfileId]