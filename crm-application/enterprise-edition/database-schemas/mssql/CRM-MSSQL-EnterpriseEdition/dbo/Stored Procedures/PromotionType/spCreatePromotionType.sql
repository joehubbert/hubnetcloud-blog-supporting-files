CREATE PROCEDURE [dbo].[spCreatePromotionType]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@promotionType NVARCHAR(50),
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #PromotionTypeTemp
			(
				[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[PromotionType] NVARCHAR(50) NOT NULL,
				[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #PromotionTypeTemp
			(
				[MasterDataTypeId],
				[PromotionType],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				@masterDataTypeId,
				@promotionType,
				@companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[PromotionType] P
				INNER JOIN #PromotionTypeTemp PT ON P.[PromotionType] = PT.[PromotionType]
				AND (P.[CompanyConfigurationId] = PT.[CompanyConfigurationId] OR (P.[CompanyConfigurationId] IS NULL AND PT.[CompanyConfigurationId] IS NULL))
				WHERE P.[PromotionType] = PT.[PromotionType]
			)
			THROW 50000, 'Promotion Type already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[PromotionType] AS target
			USING #PromotionTypeTemp AS source
			ON target.[PromotionType] = source.[PromotionType]
			AND (target.[CompanyConfigurationId] = source.[CompanyConfigurationId] OR (target.[CompanyConfigurationId] IS NULL AND source.[CompanyConfigurationId] IS NULL))
			WHEN NOT MATCHED THEN
			INSERT
			(
				[MasterDataTypeId],
				[PromotionType],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				source.[MasterDataTypeId],
				source.[PromotionType],
				source.[CompanyConfigurationId],
				source.[ActiveStatus]
			);

			DROP TABLE #PromotionTypeTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END