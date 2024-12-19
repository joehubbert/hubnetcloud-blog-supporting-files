CREATE PROCEDURE [dbo].[spUpdatePaymentMethod]
	@paymentMethod NVARCHAR(50),
	@paymentMethodId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[PaymentMethod]
SET 
	[PaymentMethod] = @paymentMethod
WHERE [PaymentMethodId] = @paymentMethodId