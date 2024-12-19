CREATE PROCEDURE [dbo].[spGetPaymentMethod]
	@paymentMethodId UNIQUEIDENTIFIER
AS

SELECT
[PaymentMethodId] AS [Payment Method Id],
[PaymentMethod] AS [Payment Method]
FROM [dbo].[PaymentMethod]
WHERE [PaymentMethodId] = @paymentMethodId