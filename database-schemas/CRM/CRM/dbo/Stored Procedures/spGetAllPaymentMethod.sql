CREATE PROCEDURE [dbo].[spGetAllPaymentMethod]
AS

SELECT
[PaymentMethodId] AS [Payment Method Id],
[PaymentMethod] AS [Payment Method]
FROM [dbo].[PaymentMethod]