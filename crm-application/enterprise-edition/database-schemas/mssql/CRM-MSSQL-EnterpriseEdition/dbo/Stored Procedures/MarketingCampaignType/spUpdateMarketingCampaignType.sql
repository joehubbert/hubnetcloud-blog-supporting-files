CREATE PROCEDURE [dbo].[spUpdateMarketingCampaignType]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@marketingCampaignType NVARCHAR(50),
	@marketingCampaignTypeId UNIQUEIDENTIFIER,
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[MarketingCampaignType]
			SET
				[ActiveStatus] = @activeStatus,
				[CompanyConfigurationId] = @companyConfigurationId,
				[MarketingCampaignType] = @marketingCampaignType,
				[MasterDataTypeId] = @masterDataTypeId
			WHERE [MarketingCampaignTypeId] = @marketingCampaignTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END