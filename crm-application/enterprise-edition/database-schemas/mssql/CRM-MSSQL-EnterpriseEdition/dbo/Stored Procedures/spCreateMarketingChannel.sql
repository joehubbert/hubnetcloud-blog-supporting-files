CREATE PROCEDURE [dbo].[spCreateMarketingChannel]
	@activeStatus BIT,
	@marketingChannel NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #MarketingChannelTemp
			(
				[MarketingChannel] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #MarketingChannelTemp
			(
				[MarketingChannel],
				[ActiveStatus]
			)
			VALUES
			(
				@marketingChannel,
				@activeStatus
			)

			IF EXISTS
			(
			SELECT *
			FROM [dbo].[MarketingChannel] MC
			INNER JOIN #MarketingChannelTemp MCT ON MC.[MarketingChannel] = MCT.[MarketingChannel]
			WHERE MC.[MarketingChannel] = MCT.[MarketingChannel]
			)
			THROW 50000, 'Marketing Channel already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[MarketingChannel] AS target
			USING #MarketingChannelTemp AS source
			ON target.[MarketingChannel] = source.[MarketingChannel]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[MarketingChannel],
				[ActiveStatus]
			)
			VALUES
			(
				source.[MarketingChannel],
				source.[ActiveStatus]
			);

			DROP TABLE #MarketingChannelTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END