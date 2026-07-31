CREATE PROCEDURE [dbo].[spCreateMarketingChannel]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@marketingChannel NVARCHAR(50),
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #MarketingChannelTemp
			(
				[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[MarketingChannel] NVARCHAR(50) NOT NULL,
				[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #MarketingChannelTemp
			(
				[MasterDataTypeId],
				[MarketingChannel],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				@masterDataTypeId,
				@marketingChannel,
				@companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[MarketingChannel] MC
				INNER JOIN #MarketingChannelTemp MCT ON MC.[MarketingChannel] = MCT.[MarketingChannel]
				AND (MC.[CompanyConfigurationId] = MCT.[CompanyConfigurationId] OR (MC.[CompanyConfigurationId] IS NULL AND MCT.[CompanyConfigurationId] IS NULL))
				WHERE MC.[MarketingChannel] = MCT.[MarketingChannel]
			)
			THROW 50000, 'Marketing Channel already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[MarketingChannel] AS target
			USING #MarketingChannelTemp AS source
			ON target.[MarketingChannel] = source.[MarketingChannel]
			AND (target.[CompanyConfigurationId] = source.[CompanyConfigurationId] OR (target.[CompanyConfigurationId] IS NULL AND source.[CompanyConfigurationId] IS NULL))
			WHEN NOT MATCHED THEN
			INSERT
			(
				[MasterDataTypeId],
				[MarketingChannel],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				source.[MasterDataTypeId],
				source.[MarketingChannel],
				source.[CompanyConfigurationId],
				source.[ActiveStatus]
			);

			DROP TABLE #MarketingChannelTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END