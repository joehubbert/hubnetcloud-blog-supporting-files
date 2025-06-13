CREATE PROCEDURE [dbo].[spGetAllMarketingCampaignStatusHistoryForMarketingCampaign]
	@marketingCampaignId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Marketing Campaign Status History Id],
			[Marketing Campaign Id],
			[Marketing Campaign Status Id],
			[Marketing Campaign Status],
			[Created Timestamp],
			[Created By],
			[Modified Timestamp],
			[Modified By]
			FROM [dbo].[vwMarketingCampaignStatusHistory]
			WHERE [Marketing Campaign Id] = @marketingCampaignId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END