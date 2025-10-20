CREATE VIEW [dbo].[vwPromotionTargetType]
AS

SELECT
[PromotionTargetTypeId] AS [Promotion Target Type Id],
[PromotionTargetType] AS [Promotion Target Type],
[PromotionTargetTypeDescription] AS [Promotion Target Type Description],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By],
[RowVersion] AS [Row Version]
FROM [dbo].[PromotionTargetType] PTT