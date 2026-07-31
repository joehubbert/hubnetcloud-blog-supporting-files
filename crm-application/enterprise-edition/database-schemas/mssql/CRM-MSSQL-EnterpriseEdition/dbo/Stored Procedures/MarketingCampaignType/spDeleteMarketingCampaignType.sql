CREATE PROCEDURE [dbo].[spDeleteMarketingCampaignType]
	@marketingCampaignTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

		DELETE MCT
		FROM [dbo].[MarketingCampaignType] MCT
		INNER JOIN [dbo].[MasterDataType] MDT ON MCT.[MasterDataTypeId] = MDT.[MasterDataTypeId]
		WHERE MCT.[MarketingCampaignTypeId] = @marketingCampaignTypeId
		AND MDT.[IsCustom] = 1

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END