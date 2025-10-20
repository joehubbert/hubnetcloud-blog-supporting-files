CREATE VIEW [dbo].[vwAccountManager]
AS

SELECT
AM.[AccountManagerId] AS [Account Manager Id],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
AM.[FirstName] AS [First Name],
AM.[LastName] AS [Last Name],
AM.[EmailAddress] AS [Email Address],
AM.[TelephoneNumber] AS [Telephone Number],
AM.[ActiveStatus] AS [Active Status],
AM.[CreatedTimestampUTC] AS [Created Timestamp UTC],
AM.[CreatedBy] AS [Created By],
AM.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
AM.[ModifiedBy] AS [Modified By],
AM.[RowVersion] AS [Row Version]
FROM [dbo].[AccountManager] AM
INNER JOIN [dbo].[CompanyConfiguration] CC ON AM.[CompanyConfigurationId] = CC.[CompanyConfigurationId]