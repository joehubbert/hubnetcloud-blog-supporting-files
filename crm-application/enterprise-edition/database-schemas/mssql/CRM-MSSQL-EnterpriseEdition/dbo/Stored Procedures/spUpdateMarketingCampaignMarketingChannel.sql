CREATE PROCEDURE [dbo].[spUpdateMarketingCampaignMarketingChannel]
	@marketingCampaignId UNIQUEIDENTIFIER,
	@marketingCampaignMarketingChannelId UNIQUEIDENTIFIER,
	@marketingChannelId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[MarketingCampaignMarketingChannel]
			SET 
				[MarketingCampaignId] = @marketingCampaignId,
				[MarketingChannelId] = @marketingChannelId
			WHERE [MarketingCampaignMarketingChannelId] = @marketingCampaignMarketingChannelId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END