CREATE PROCEDURE [dbo].[spCreateOrder]
	@customerId UNIQUEIDENTIFIER,
	@internalReference NVARCHAR(50) = NULL,
	@orderId UNIQUEIDENTIFIER OUTPUT,
	@orderTypeId UNIQUEIDENTIFIER,
	@purchaseOrderNumber NVARCHAR(50) = NULL
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #OrderTempOutput
			(
				[OrderId] UNIQUEIDENTIFIER NOT NULL
			);

			DECLARE @orderDate DATE
			SET @orderDate = SYSUTCDATETIME()

			DECLARE @orderFriendlyId NVARCHAR(20)
			DECLARE @orderFriendlyIdNextSequence NVARCHAR(6)

			SELECT @orderFriendlyIdNextSequence = ISNULL(MAX(CAST(RIGHT([OrderFriendlyId], 6) AS INT)), 0) + 1
			FROM [dbo].[Order]
			WHERE CONVERT(DATE, [OrderDate]) = @orderDate

			SELECT @orderFriendlyId = [dbo].[fnGenerateFriendlyOrderId](@orderDate, @orderFriendlyIdNextSequence)

			INSERT INTO [dbo].[Order]
			(
				[CustomerId],
				[OrderTypeId],
				[OrderDate],
				[OrderFriendlyId],
				[PurchaseOrderNumber],
				[InternalReference]
			)
			OUTPUT INSERTED.[OrderId] INTO #OrderTempOutput
			VALUES
			(
				@customerId,
				@orderTypeId,
				@orderDate,
				@orderFriendlyId,
				@purchaseOrderNumber,
				@internalReference
			);

			SET @orderId = (SELECT [OrderId] FROM #OrderTempOutput);
			DROP TABLE #OrderTempOutput;

			DECLARE @orderStatusId UNIQUEIDENTIFIER;
			SELECT @orderStatusId = [OrderStatusId] FROM [dbo].[OrderStatus] WHERE [OrderStatus] = 'New';

			EXEC [dbo].[spCreateOrderStatusHistory]
				@orderId = @orderId,
				@orderStatusId = @orderStatusId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END