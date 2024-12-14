CREATE PROCEDURE [dbo].[DeletePaymentMethod]
	@paymentMethodId UNIQUEIDENTIFIER
AS
DELETE FROM [dbo].[PaymentMethod]
WHERE [PaymentMethodId] = @paymentMethodId