CREATE PROCEDURE [dbo].[spDeleteMarketingCampaignMarketingChannel]
	@marketingCampaignMarketingChannelId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

		DELETE FROM [dbo].[MarketingCampaignMarketingChannel]
		WHERE [MarketingCampaignMarketingChannelId] = @marketingCampaignMarketingChannelId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END