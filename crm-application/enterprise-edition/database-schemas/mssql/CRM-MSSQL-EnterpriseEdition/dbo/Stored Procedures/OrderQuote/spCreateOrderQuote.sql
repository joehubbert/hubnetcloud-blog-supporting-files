CREATE PROCEDURE [dbo].[spCreateOrderQuote]
	@orderFriendlyId NVARCHAR(20),
	@orderQuote VARBINARY(MAX),
	@orderQuoteId UNIQUEIDENTIFIER OUTPUT,
	@orderId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #OrderQuoteTempOutput
			(
				[OrderQuoteId] UNIQUEIDENTIFIER NOT NULL
			)

			DECLARE @orderQuoteDate DATE
			SET @orderQuoteDate = GETUTCDATE();

			DECLARE @orderQuoteFriendlyId NVARCHAR(30)
			DECLARE @orderQuoteFriendlyIdNextSequence NVARCHAR(3)

			SELECT @orderQuoteFriendlyIdNextSequence = ISNULL(MAX(CAST(RIGHT([OrderQuoteFriendlyId], 3) AS INT)), 0) + 1
			FROM [dbo].[OrderQuote]
			WHERE CONVERT(DATE, [OrderQuoteDate]) = @orderQuoteDate

			SELECT @orderQuoteFriendlyId = [dbo].[fnGenerateFriendlyOrderQuoteId](@orderQuoteFriendlyIdNextSequence, @orderQuoteFriendlyId)

			INSERT INTO [dbo].[OrderQuote]
			(
				[OrderId],
				[OrderQuote],
				[OrderQuoteDate],
				[OrderQuoteFriendlyId]
			)
			OUTPUT INSERTED.[OrderQuoteId] INTO #OrderQuoteTempOutput
			VALUES
			(
				@orderId,
				@orderQuote,
				@orderQuoteDate,
				@orderQuoteFriendlyId
			);

			SET @orderQuoteId = (SELECT [OrderQuoteId] FROM #OrderQuoteTempOutput);

			DROP TABLE #OrderQuoteTempOutput;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END