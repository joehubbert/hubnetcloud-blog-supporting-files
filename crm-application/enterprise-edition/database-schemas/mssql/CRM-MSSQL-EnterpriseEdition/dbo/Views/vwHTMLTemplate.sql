CREATE VIEW [dbo].[vwHTMLTemplate]
AS

SELECT
HTMLT.[HTMLTemplateId] AS [HTML Template Id],
HTMLT.[CompanyConfigurationId] AS [Company Configuration Id],
HTMLT.[HTMLTemplateTitle] AS [HTML Template Title],
HTMLTT.[HTMLTemplateTypeId] AS [HTML Template Type Id],
HTMLTT.[HTMLTemplateType] AS [HTML Template Type],
HTMLT.[HTMLTemplate] AS [HTML Template],
HTMLT.[CreatedTimestampUTC] AS [Created Timestamp UTC],
HTMLT.[CreatedBy] AS [Created By],
HTMLT.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
HTMLT.[ModifiedBy] AS [Modified By],
HTMLT.[RowVersion] AS [Row Version]
FROM [dbo].[HTMLTemplate] HTMLT
INNER JOIN [dbo].[HTMLTemplateType] HTMLTT ON HTMLT.[HTMLTemplateTypeId] = HTMLTT.[HTMLTemplateTypeId]