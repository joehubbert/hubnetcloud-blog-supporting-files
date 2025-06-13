CREATE PROCEDURE [dbo].[spUpdateMarketingCampaignStatusHistory]
	@marketingCampaignStatusHistoryId UNIQUEIDENTIFIER,
	@marketingCampaignStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[MarketingCampaignStatusHistory]
			SET
				[MarketingCampaignStatusId] = @marketingCampaignStatusId
			WHERE [MarketingCampaignStatusHistoryId] = @marketingCampaignStatusHistoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END