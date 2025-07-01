CREATE PROCEDURE [dbo].[spUpdateOrder]
	@customerId UNIQUEIDENTIFIER,
	@internalReference NVARCHAR(50),
	@orderId UNIQUEIDENTIFIER,
	@purchaseOrderNumber NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[Order]
			SET 
				[CustomerId] = @customerId,
				[InternalReference] = @internalReference,
				[PurchaseOrderNumber] = @purchaseOrderNumber
			WHERE [OrderId] = @orderId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END