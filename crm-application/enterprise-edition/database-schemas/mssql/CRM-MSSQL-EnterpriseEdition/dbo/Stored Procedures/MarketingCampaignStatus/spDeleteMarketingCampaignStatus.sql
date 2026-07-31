CREATE PROCEDURE [dbo].[spDeleteMarketingCampaignStatus]
	@marketingCampaignStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

		DELETE MCS
		FROM [dbo].[MarketingCampaignStatus] MCS
		INNER JOIN [dbo].[MasterDataType] MDT ON MCS.[MasterDataTypeId] = MDT.[MasterDataTypeId]
		WHERE MCS.[MarketingCampaignStatusId] = @marketingCampaignStatusId
		AND MDT.[IsCustom] = 1

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END