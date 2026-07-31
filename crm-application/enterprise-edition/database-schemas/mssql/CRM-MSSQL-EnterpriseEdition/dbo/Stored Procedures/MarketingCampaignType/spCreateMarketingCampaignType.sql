CREATE PROCEDURE [dbo].[spCreateMarketingCampaignType]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@marketingCampaignType NVARCHAR(50),
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #MarketingCampaignTypeTemp
			(
				[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[MarketingCampaignType] NVARCHAR(50) NOT NULL,
				[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #MarketingCampaignTypeTemp
			(
				[MasterDataTypeId],
				[MarketingCampaignType],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				@masterDataTypeId,
				@marketingCampaignType,
				@companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[MarketingCampaignType] MCT
				INNER JOIN #MarketingCampaignTypeTemp MCTT ON MCT.[MarketingCampaignType] = MCTT.[MarketingCampaignType]
				AND (MCT.[CompanyConfigurationId] = MCTT.[CompanyConfigurationId] OR (MCT.[CompanyConfigurationId] IS NULL AND MCTT.[CompanyConfigurationId] IS NULL))
				WHERE MCT.[MarketingCampaignType] = MCTT.[MarketingCampaignType]
			)
			THROW 50000, 'Marketing Campaign Type already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[MarketingCampaignType] AS target
			USING #MarketingCampaignTypeTemp AS source
			ON target.[MarketingCampaignType] = source.[MarketingCampaignType]
			AND (target.[CompanyConfigurationId] = source.[CompanyConfigurationId] OR (target.[CompanyConfigurationId] IS NULL AND source.[CompanyConfigurationId] IS NULL))
			WHEN NOT MATCHED THEN
			INSERT
			(
				[MasterDataTypeId],
				[MarketingCampaignType],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				source.[MasterDataTypeId],
				source.[MarketingCampaignType],
				source.[CompanyConfigurationId],
				source.[ActiveStatus]
			);

			DROP TABLE #MarketingCampaignTypeTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END