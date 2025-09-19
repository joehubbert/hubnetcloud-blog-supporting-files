CREATE PROCEDURE [dbo].[spUpdateMarketingCampaign]
	@activeStatus BIT,
	@actualCost MONEY,
	@budget MONEY,
	@companyConfigurationId UNIQUEIDENTIFIER,
	@forecastedRevenue MONEY,
	@marketingCampaignDescription NVARCHAR(255) = NULL,
	@marketingCampaignEndTimestampUTC DATETIME2 = NULL,
	@marketingCampaignGoal NVARCHAR(255) = NULL,
	@marketingCampaignId UNIQUEIDENTIFIER OUTPUT,
	@marketingCampaignName NVARCHAR(100),
	@marketingCampaignStartTimestampUTC DATETIME2,
	@marketingCampaignTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[MarketingCampaign]
			SET
				[ActiveStatus] = @activeStatus,
				[ActualCost] = @actualCost,
				[Budget] = @budget,
				[CompanyConfigurationId] = @companyConfigurationId,
				[ForecastedRevenue] = @forecastedRevenue,
				[MarketingCampaignDescription] = @marketingCampaignDescription,
				[MarketingCampaignEndTimestampUTC] = @marketingCampaignEndTimestampUTC,
				[MarketingCampaignGoal] = @marketingCampaignGoal,
				[MarketingCampaignName] = @marketingCampaignName,
				[MarketingCampaignStartTimestampUTC] = @marketingCampaignStartTimestampUTC,
				[MarketingCampaignTypeId] = @marketingCampaignTypeId
			WHERE
				[MarketingCampaignId] = @marketingCampaignId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END