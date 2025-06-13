CREATE PROCEDURE [dbo].[spCreateMarketingCampaign]
	@activeStatus BIT,
	@actualCost MONEY,
	@budget MONEY,
	@companyConfigurationId UNIQUEIDENTIFIER,
	@forecastedRevenue MONEY,
	@marketingCampaignDescription NVARCHAR(255) = NULL,
	@marketingCampaignEndTimestamp DATETIME2 = NULL,
	@marketingCampaignGoal NVARCHAR(255) = NULL,
	@marketingCampaignId UNIQUEIDENTIFIER OUTPUT,
	@marketingCampaignName NVARCHAR(100),
	@marketingCampaignStartTimestamp DATETIME2,
	@marketingCampaignTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #MarketingCampaignTempOutput
			(
				[MarketingCampaignId] UNIQUEIDENTIFIER NOT NULL
			);

			INSERT INTO [dbo].[MarketingCampaign]
			(
				[CompanyConfigurationId],
				[MarketingCampaignTypeId],
				[MarketingCampaignName],
				[MarketingCampaignDescription],
				[MarketingCampaignGoal],
				[MarketingCampaignStartTimestamp],
				[MarketingCampaignEndTimestamp],
				[Budget],
				[ActualCost],
				[ForecastedRevenue],
				[ActiveStatus]
			)
			OUTPUT INSERTED.[MarketingCampaignId] INTO #MarketingCampaignTempOutput
			VALUES
			(
				@companyConfigurationId,
				@marketingCampaignTypeId,
				@marketingCampaignName,
				@marketingCampaignDescription,
				@marketingCampaignGoal,
				@marketingCampaignStartTimestamp,
				@marketingCampaignEndTimestamp,
				@budget,
				@actualCost,
				@forecastedRevenue,
				@activeStatus
			);

			SET @marketingCampaignId = (SELECT [MarketingCampaignId] FROM #MarketingCampaignTempOutput);
			DROP TABLE #MarketingCampaignTempOutput;

			DECLARE @marketingCampaignStatusNewId UNIQUEIDENTIFIER
			DECLARE @marketingCampaignStatusAwaitingApprovalId UNIQUEIDENTIFIER

			SET @marketingCampaignStatusNewId = (SELECT [MarketingCampaignStatusId] FROM [dbo].[MarketingCampaignStatus] WHERE [MarketingCampaignStatus] = 'New');
			SET @marketingCampaignStatusAwaitingApprovalId = (SELECT [MarketingCampaignStatusId] FROM [dbo].[MarketingCampaignStatus] WHERE [MarketingCampaignStatus] = 'Pending Approval');

			EXEC [dbo].[spCreateMarketingCampaignStatusHistory]
				@marketingCampaignId = @marketingCampaignId,
				@marketingCampaignStatusId = @marketingCampaignStatusNewId;
						
			EXEC [dbo].[spCreateMarketingCampaignStatusHistory]
				@marketingCampaignId = @marketingCampaignId,
				@marketingCampaignStatusId = @marketingCampaignStatusNewId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END