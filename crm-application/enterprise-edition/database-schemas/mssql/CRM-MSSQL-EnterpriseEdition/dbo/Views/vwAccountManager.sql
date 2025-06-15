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
AM.[CreatedTimestamp] AS [Created Timestamp],
AM.[CreatedBy] AS [Created By],
AM.[ModifiedTimestamp] AS [Modified Timestamp],
AM.[ModifiedBy] AS [Modified By]
FROM [dbo].[AccountManager] AM
INNER JOIN [dbo].[CompanyConfiguration] CC ON AM.[CompanyConfigurationId] = CC.[CompanyConfigurationId]