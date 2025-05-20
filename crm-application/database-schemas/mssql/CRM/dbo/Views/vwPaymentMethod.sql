CREATE VIEW [dbo].[vwPaymentMethod]
AS

SELECT
[PaymentMethodId] AS [Payment Method Id],
[PaymentMethod] AS [Payment Method],
[ActiveStatus] AS [Active Status],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[PaymentMethod]