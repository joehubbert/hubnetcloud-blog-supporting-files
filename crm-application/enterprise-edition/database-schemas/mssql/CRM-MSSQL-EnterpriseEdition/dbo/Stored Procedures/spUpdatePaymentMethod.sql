CREATE PROCEDURE [dbo].[spUpdatePaymentMethod]
	@activeStatus BIT,
	@paymentMethod NVARCHAR(50),
	@paymentMethodId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[PaymentMethod]
			SET 
				[ActiveStatus] = @activeStatus,
				[PaymentMethod] = @paymentMethod
			WHERE [PaymentMethodId] = @paymentMethodId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END