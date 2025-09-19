CREATE PROCEDURE [dbo].[spUpdateWholesaleDeliveryType]
	@activeStatus BIT,
	@wholesaleDeliveryType NVARCHAR(50),
	@wholesaleDeliveryTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[WholesaleDeliveryType]
			SET
				[ActiveStatus] = @activeStatus,
				[WholesaleDeliveryType] = @wholesaleDeliveryType
			WHERE [WholesaleDeliveryTypeId] = @wholesaleDeliveryTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END