CREATE PROCEDURE [dbo].[spUpdateMarketingCampaignType]
	@activeStatus BIT,
	@marketingCampaignType NVARCHAR(50),
	@marketingCampaignTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[MarketingCampaignType]
			SET
				[ActiveStatus] = @activeStatus,
				[MarketingCampaignType] = @marketingCampaignType
			WHERE [MarketingCampaignTypeId] = @marketingCampaignTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END