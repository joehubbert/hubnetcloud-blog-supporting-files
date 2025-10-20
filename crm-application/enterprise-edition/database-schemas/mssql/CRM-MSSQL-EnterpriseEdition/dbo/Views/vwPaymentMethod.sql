CREATE VIEW [dbo].[vwPaymentMethod]
AS

SELECT
[PaymentMethodId] AS [Payment Method Id],
[PaymentMethod] AS [Payment Method],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By],
[RowVersion] AS [Row Version]
FROM [dbo].[PaymentMethod]