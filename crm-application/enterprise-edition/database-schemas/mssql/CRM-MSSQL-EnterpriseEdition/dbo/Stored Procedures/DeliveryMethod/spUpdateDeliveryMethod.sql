CREATE PROCEDURE [dbo].[spUpdateDeliveryMethod]
	@activeStatus BIT,
	@deliveryMethod NVARCHAR(50),
	@deliveryMethodId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[DeliveryMethod]
			SET 
				[ActiveStatus] = @activeStatus,
				[DeliveryMethod] = @deliveryMethod
			WHERE [DeliveryMethodId] = @deliveryMethodId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END