CREATE PROCEDURE [dbo].[spCreateMarketingCampaignType]
	@activeStatus BIT,
	@marketingCampaignType NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #MarketingCampaignTypeTemp
			(
				[MarketingCampaignType] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #MarketingCampaignTypeTemp
			(
				[MarketingCampaignType],
				[ActiveStatus]
			)
			VALUES
			(
				@marketingCampaignType,
				@activeStatus
			)

			IF EXISTS
			(
			SELECT *
			FROM [dbo].[MarketingCampaignType] MCT
			INNER JOIN #MarketingCampaignTypeTemp MCTT ON MCT.[MarketingCampaignType] = MCTT.[MarketingCampaignType]
			WHERE MCT.[MarketingCampaignType] = MCTT.[MarketingCampaignType]
			)
			THROW 50000, 'Marketing Campaign Type already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[MarketingCampaignType] AS target
			USING #MarketingCampaignTypeTemp AS source
			ON target.[MarketingCampaignType] = source.[MarketingCampaignType]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[MarketingCampaignType],
				[ActiveStatus]
			)
			VALUES
			(
				source.[MarketingCampaignType],
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