CREATE PROCEDURE [dbo].[spGetOrderLineItemDelivery]
	@orderLineItemDeliveryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Order Line Item Delivery Id],
			[Order Line Item Id],
			[Product Id],
			[Product Name],
			[Delivery Method],
			[Shipping Date],
			[Delivery Date],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwOrderLineItemDelivery]
			WHERE [Order Line Item Delivery Id] = @orderLineItemDeliveryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END