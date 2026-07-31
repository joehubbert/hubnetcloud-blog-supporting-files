CREATE PROCEDURE [dbo].[spUpdateMarketingCampaignStatus]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@marketingCampaignStatus NVARCHAR(50),
	@marketingCampaignStatusId UNIQUEIDENTIFIER,
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[MarketingCampaignStatus]
			SET 
				[ActiveStatus] = @activeStatus,
				[CompanyConfigurationId] = @companyConfigurationId,
				[MarketingCampaignStatus] = @marketingCampaignStatus,
				[MasterDataTypeId] = @masterDataTypeId
			WHERE [MarketingCampaignStatusId] = @marketingCampaignStatusId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END