CREATE VIEW [dbo].[vwHTMLTemplateType]
AS

SELECT
[HTMLTemplateTypeId] AS [HTML Template Type Id],
[HTMLTemplateType] AS [HTML Template Type],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By]
FROM [dbo].[HTMLTemplateType]