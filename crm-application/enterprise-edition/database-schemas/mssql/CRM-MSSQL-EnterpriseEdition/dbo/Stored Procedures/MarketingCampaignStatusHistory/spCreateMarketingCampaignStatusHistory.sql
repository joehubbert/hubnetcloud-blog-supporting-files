CREATE PROCEDURE [dbo].[spCreateMarketingCampaignStatusHistory]
	@marketingCampaignId UNIQUEIDENTIFIER,
	@marketingCampaignStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			INSERT INTO [dbo].[MarketingCampaignStatusHistory]
			(
				[MarketingCampaignId],
				[MarketingCampaignStatusId]
			)
			VALUES
			(
				@marketingCampaignId,
				@marketingCampaignStatusId
			)

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END