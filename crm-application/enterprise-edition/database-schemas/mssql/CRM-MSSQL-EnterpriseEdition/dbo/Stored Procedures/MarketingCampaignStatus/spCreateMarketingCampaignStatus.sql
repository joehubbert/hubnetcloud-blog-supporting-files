CREATE PROCEDURE [dbo].[spCreateMarketingCampaignStatus]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@marketingCampaignStatus NVARCHAR(50),
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #MarketingCampaignStatusTemp
			(
				[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[MarketingCampaignStatus] NVARCHAR(50) NOT NULL,
				[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #MarketingCampaignStatusTemp
			(
				[MasterDataTypeId],
				[MarketingCampaignStatus],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				@masterDataTypeId,
				@marketingCampaignStatus,
				@companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[MarketingCampaignStatus] MCS
				INNER JOIN #MarketingCampaignStatusTemp MCST ON MCS.[MarketingCampaignStatus] = MCST.[MarketingCampaignStatus]
				WHERE MCS.[MarketingCampaignStatus] = MCST.[MarketingCampaignStatus]
			)
			THROW 50000, 'Marketing Campaign Status already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[MarketingCampaignStatus] AS target
			USING #MarketingCampaignStatusTemp AS source
			ON target.[MarketingCampaignStatus] = source.[MarketingCampaignStatus]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[MasterDataTypeId],
				[MarketingCampaignStatus],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				source.[MasterDataTypeId],
				source.[MarketingCampaignStatus],
				source.[CompanyConfigurationId],
				source.[ActiveStatus]
			);

			DROP TABLE #MarketingCampaignStatusTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END