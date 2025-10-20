CREATE PROCEDURE [dbo].[spCreateOrderInvoice]
	@orderFriendlyId NVARCHAR(20),
	@orderInvoice VARBINARY(MAX),
	@orderInvoiceId UNIQUEIDENTIFIER OUTPUT,
	@orderId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #OrderInvoiceTempOutput
			(
				[OrderInvoiceId] UNIQUEIDENTIFIER NOT NULL
			)

			DECLARE @orderInvoiceDate DATE
			SET @orderInvoiceDate = SYSUTCDATETIME();

			DECLARE @orderInvoiceFriendlyId NVARCHAR(30)
			DECLARE @orderInvoiceFriendlyIdNextSequence NVARCHAR(3)

			SELECT @orderInvoiceFriendlyIdNextSequence = ISNULL(MAX(CAST(RIGHT([OrderInvoiceFriendlyId], 3) AS INT)), 0) + 1
			FROM [dbo].[OrderInvoice]
			WHERE CONVERT(DATE, [OrderInvoiceDate]) = @orderInvoiceDate

			SELECT @orderInvoiceFriendlyId = [dbo].[fnGenerateFriendlyOrderInvoiceId](@orderInvoiceFriendlyIdNextSequence, @orderInvoiceFriendlyId)

			INSERT INTO [dbo].[OrderInvoice]
			(
				[OrderId],
				[OrderInvoice],
				[OrderInvoiceDate],
				[OrderInvoiceFriendlyId]
			)
			OUTPUT INSERTED.[OrderInvoiceId] INTO #OrderInvoiceTempOutput
			VALUES
			(
				@orderId,
				@orderInvoice,
				@orderInvoiceDate,
				@orderInvoiceFriendlyId
			);

			SET @orderInvoiceId = (SELECT [OrderInvoiceId] FROM #OrderInvoiceTempOutput);

			DROP TABLE #OrderInvoiceTempOutput;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END