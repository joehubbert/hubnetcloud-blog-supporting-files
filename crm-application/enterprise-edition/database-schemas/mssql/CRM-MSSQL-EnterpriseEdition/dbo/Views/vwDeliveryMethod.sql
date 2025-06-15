CREATE VIEW [dbo].[vwDeliveryMethod]
AS

SELECT
DM.[DeliveryMethodId] AS [Delivery Method Id],
DM.[DeliveryMethod] AS [Delivery Method],
DM.[DeliveryCost] AS [Delivery Cost],
DM.[DeliveryTimeDays] AS [Delivery Time Days],
TP.[TaxProfile] AS [Tax Profile],
TP.[TaxRate] AS [Tax Rate],
DM.[ActiveStatus] AS [Delivery Method Active Status],
DM.[CreatedTimestampUTC] AS [Created Timestamp UTC],
DM.[CreatedBy] AS [Created By],
DM.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
DM.[ModifiedBy] AS [Modified By]
FROM [dbo].[DeliveryMethod] DM
INNER JOIN [dbo].[TaxProfile] TP ON DM.[TaxProfileId] = TP.[TaxProfileId]