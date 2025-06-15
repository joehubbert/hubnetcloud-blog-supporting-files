CREATE VIEW [dbo].[vwCustomerType]
AS

SELECT
CT.[CustomerTypeId] AS [Customer Type Id],
CT.[CustomerType] AS [Customer Type],
CT.[CustomerTypeDescription] AS [Customer Type Description],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
CT.[ActiveStatus] AS [Active Status],
CT.[CreatedTimestampUTC] AS [Created Timestamp UTC],
CT.[CreatedBy] AS [Created By],
CT.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
CT.[ModifiedBy] AS [Modified By]
FROM [dbo].[CustomerType] CT
INNER JOIN [dbo].[CompanyConfiguration] CC ON CT.[CompanyConfigurationId] = CC.[CompanyConfigurationId]