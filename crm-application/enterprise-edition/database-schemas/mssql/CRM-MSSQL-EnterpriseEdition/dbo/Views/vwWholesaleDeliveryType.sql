CREATE VIEW [dbo].[vwWholesaleDeliveryType]
AS

SELECT
[WholesaleDeliveryTypeId] AS [Wholesale Delivery Type Id],
[WholesaleDeliveryType] AS [Wholesale Delivery Type],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By]
FROM [dbo].[WholesaleDeliveryType]