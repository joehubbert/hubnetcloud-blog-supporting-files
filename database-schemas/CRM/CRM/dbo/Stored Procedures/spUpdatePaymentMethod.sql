CREATE PROCEDURE [dbo].[spUpdatePaymentMethod]
	@activeStatus BIT,
	@paymentMethod NVARCHAR(50),
	@paymentMethodId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[PaymentMethod]
SET 
	[ActiveStatus] = @activeStatus,
	[PaymentMethod] = @paymentMethod
WHERE [PaymentMethodId] = @paymentMethodId