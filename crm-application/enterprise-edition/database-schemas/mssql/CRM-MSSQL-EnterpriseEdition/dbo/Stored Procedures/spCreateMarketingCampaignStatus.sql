CREATE PROCEDURE [dbo].[spCreateMarketingCampaignStatus]
	@activeStatus BIT,
	@marketingCampaignStatus NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #MarketingCampaignStatusTemp
			(
				[MarketingCampaignStatus] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #MarketingCampaignStatusTemp
			(
				[MarketingCampaignStatus],
				[ActiveStatus]
			)
			VALUES
			(
				@marketingCampaignStatus,
				@activeStatus
			)

			IF EXISTS
			(
			SELECT *
			FROM [dbo].[MarketingCampaignStatus] MCS
			INNER JOIN #MarketingCampaignStatusTemp MCST ON MCS.[MarketingCampaignStatus] = MCST.[MarketingCampaignStatus]
			WHERE OS.[MarketingCampaignStatus] = MCST.[MarketingCampaignStatus]
			)
			THROW 50000, 'Marketing Campaign Status already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[MarketingCampaignStatus] AS target
			USING #MarketingCampaignStatusTemp AS source
			ON target.[MarketingCampaignStatus] = source.[MarketingCampaignStatus]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[MarketingCampaignStatus],
				[ActiveStatus]
			)
			VALUES
			(
				source.[MarketingCampaignStatus],
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