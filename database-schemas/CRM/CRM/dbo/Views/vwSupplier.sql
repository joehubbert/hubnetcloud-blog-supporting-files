CREATE VIEW [dbo].[vwSupplier]
AS

SELECT
S.[SupplierId] AS [Supplier Id],
S.[CompanyName] AS [Company Name],
S.[AddressLine1] AS [Address Line 1],
S.[AddressLine2] AS [Address Line 2],
S.[AddressLine3] AS [Address Line 3],
S.[AddressLine4] AS [Address Line 4],
S.[AddressLine5] AS [Address Line 5],
S.[TelephoneNumber] AS [Telephone Number],
S.[EmailAddress] AS [Email Address],
S.[PaymentDays] AS [Payment Days],
C.[CurrencyCode] AS [Payment Currency],
S.[CreatedTimestamp] AS [Created Timestamp],
S.[CreatedBy] AS [Created By],
S.[ModifiedTimestamp] AS [Modified Timestamp],
S.[ModifiedBy] AS [Modified By]
FROM [dbo].[Supplier] S
INNER JOIN [dbo].[Currency] C ON S.[PaymentCurrencyId] = C.[CurrencyId]