CREATE PROCEDURE [dbo].[spGetWholesaleDeliveryType]
	@wholesaleDeliveryTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Wholesale Delivery Type Id],
			[Wholesale Delivery Type],
			[Active Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwWholesaleDeliveryType]
			WHERE [Wholesale Delivery Type Id] = @wholesaleDeliveryTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END