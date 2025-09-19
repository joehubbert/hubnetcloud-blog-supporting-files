CREATE PROCEDURE [dbo].[spCreateMarketingCampaignMarketingChannel]
	@marketingCampaignId UNIQUEIDENTIFIER,
	@marketingChannelId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #MarketingCampaignMarketingChannelTemp
			(
				[MarketingCampaignId] UNIQUEIDENTIFIER NOT NULL,
				[MarketingChannelId] UNIQUEIDENTIFIER NOT NULL
			)

			INSERT INTO #MarketingCampaignMarketingChannelTemp
			(
				[MarketingCampaignId],
				[MarketingChannelId]
			)
			VALUES
			(
				@marketingCampaignId,
				@marketingChannelId
			)

			MERGE INTO [dbo].[MarketingCampaignMarketingChannel] AS target
			USING #MarketingCampaignMarketingChannelTemp AS source
			ON target.[MarketingCampaignId] = source.[MarketingCampaignId]
			AND target.[MarketingChannelId] = source.[MarketingChannelId]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[MarketingCampaignId],
				[MarketingChannelId]
			)
			VALUES
			(
				source.[MarketingCampaignId],
				source.[MarketingChannelId]
			);

			DROP TABLE #MarketingCampaignMarketingChannelTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END