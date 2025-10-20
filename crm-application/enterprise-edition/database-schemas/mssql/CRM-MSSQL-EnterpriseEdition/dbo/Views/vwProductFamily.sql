CREATE VIEW [dbo].[vwProductFamily]

AS
SELECT
PF.[ProductFamilyId] AS [Product Family Id],
PF.[ProductFamily] AS [Product Family],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
PF.[ActiveStatus] AS [Active Status],
PF.[CreatedTimestampUTC] AS [Created Timestamp UTC],
PF.[CreatedBy] AS [Created By],
PF.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
PF.[ModifiedBy] AS [Modified By],
PF.[RowVersion] AS [Row Version]
FROM [dbo].[ProductFamily] PF
INNER JOIN [dbo].[CompanyConfiguration] CC ON PF.[CompanyConfigurationId] = CC.[CompanyConfigurationId]