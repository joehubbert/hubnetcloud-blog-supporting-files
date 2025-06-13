CREATE PROCEDURE [dbo].[spUpdateMarketingCampaignStatus]
	@activeStatus BIT,
	@marketingCampaignStatus NVARCHAR(50),
	@marketingCampaignStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[MarketingCampaignStatus]
			SET 
				[ActiveStatus] = @activeStatus,
				[MarketingCampaignStatus] = @marketingCampaignStatus
			WHERE [MarketingCampaignStatusId] = @marketingCampaignStatusId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END