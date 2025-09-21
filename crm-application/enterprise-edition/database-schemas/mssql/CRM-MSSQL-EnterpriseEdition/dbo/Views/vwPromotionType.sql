CREATE VIEW [dbo].[vwPromotionType]
AS

SELECT
[PromotionTypeId] AS [Promotion Type Id],
[PromotionType] AS [Promotion Type],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By]
FROM [dbo].[PromotionType]