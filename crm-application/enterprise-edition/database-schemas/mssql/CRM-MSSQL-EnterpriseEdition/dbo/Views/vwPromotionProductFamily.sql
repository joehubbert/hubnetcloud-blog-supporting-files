CREATE VIEW [dbo].[vwPromotionProductFamily]
AS

SELECT
PPF.[PromotionProductFamilyId] AS [Promotion Product Family Id],
P.[PromotionId] AS [Promotion Id],
P.[PromotionName] AS [Promotion Name],
PF.[ProductFamilyId] AS [Product Family Id],
PF.[ProductFamily] AS [Product Family],
PPF.[CreatedTimestampUTC] AS [Created Timestamp UTC],
PPF.[CreatedBy] AS [Created By],
PPF.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
PPF.[ModifiedBy] AS [Modified By]
FROM [dbo].[PromotionProductFamily] PPF
INNER JOIN [dbo].[ProductFamily] PF ON PPF.[ProductFamilyId] = PF.[ProductFamilyId]
INNER JOIN [dbo].[Promotion] P ON PPF.[PromotionId] = P.[PromotionId]