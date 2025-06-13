CREATE PROCEDURE [dbo].[spCreateOrderLineItemStatus]
	@activeStatus BIT,
	@orderLineItemStatus NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #OrderLineItemStatusTemp
			(
				[OrderLineItemStatus] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #OrderLineItemStatusTemp
			(
				[OrderLineItemStatus],
				[ActiveStatus]
			)
			VALUES
			(
				@orderLineItemStatus,
				@activeStatus
			)

			IF EXISTS
			(
			SELECT *
			FROM [dbo].[OrderLineItemStatus] OLIS
			INNER JOIN #OrderLineItemStatusTemp OLIST ON OLIS.[OrderLineItemStatus] = OLIST.[OrderLineItemStatus]
			WHERE OLIS.[OrderLineItemStatus] = OLIST.[OrderLineItemStatus]
			)
			THROW 50000, 'Order Line Item Status already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[OrderLineItemStatus] AS target
			USING #OrderLineItemStatusTemp AS source
			ON target.[OrderLineItemStatus] = source.[OrderLineItemStatus]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[OrderLineItemStatus],
				[ActiveStatus]
			)
			VALUES
			(
				source.[OrderLineItemStatus],
				source.[ActiveStatus]
			);

			DROP TABLE #OrderLineItemStatusTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END