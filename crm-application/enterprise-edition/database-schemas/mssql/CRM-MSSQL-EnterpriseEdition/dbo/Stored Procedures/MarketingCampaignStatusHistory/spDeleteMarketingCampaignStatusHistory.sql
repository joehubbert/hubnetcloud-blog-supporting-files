CREATE PROCEDURE [dbo].[spDeleteMarketingCampaignStatusHistory]
	@marketingCampaignStatusHistoryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

		DELETE FROM [dbo].[MarketingCampaignStatusHistory]
		WHERE [MarketingCampaignStatusHistoryId] = @marketingCampaignStatusHistoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END