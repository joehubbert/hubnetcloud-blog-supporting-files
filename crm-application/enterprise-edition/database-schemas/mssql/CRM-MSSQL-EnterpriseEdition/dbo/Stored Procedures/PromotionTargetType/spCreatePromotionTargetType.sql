CREATE PROCEDURE [dbo].[spCreatePromotionTargetType]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@promotionTargetType NVARCHAR(50),
	@promotionTargetTypeDescription NVARCHAR(255) = NULL,
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #PromotionTargetTypeTemp
			(
				[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[PromotionTargetType] NVARCHAR(50) NOT NULL,
				[PromotionTargetTypeDescription] NVARCHAR(255) NULL,
				[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #PromotionTargetTypeTemp
			(
				[MasterDataTypeId],
				[PromotionTargetType],
				[PromotionTargetTypeDescription],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				@masterDataTypeId,
				@promotionTargetType,
				@promotionTargetTypeDescription,
				@companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[PromotionTargetType] PTT
				INNER JOIN #PromotionTargetTypeTemp PTTT ON PTT.[PromotionTargetType] = PTTT.[PromotionTargetType]
				AND (PTT.[CompanyConfigurationId] = PTTT.[CompanyConfigurationId] OR (PTT.[CompanyConfigurationId] IS NULL AND PTTT.[CompanyConfigurationId] IS NULL))
				WHERE PTT.[PromotionTargetType] = PTTT.[PromotionTargetType]
			)
			THROW 50000, 'Promotion Target Type already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[PromotionTargetType] AS target
			USING #PromotionTargetTypeTemp AS source
			ON target.[PromotionTargetType] = source.[PromotionTargetType]
			AND (target.[CompanyConfigurationId] = source.[CompanyConfigurationId] OR (target.[CompanyConfigurationId] IS NULL AND source.[CompanyConfigurationId] IS NULL))
			WHEN NOT MATCHED THEN
			INSERT
			(
				[MasterDataTypeId],
				[PromotionTargetType],
				[PromotionTargetTypeDescription],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				source.[MasterDataTypeId],
				source.[PromotionTargetType],
				source.[PromotionTargetTypeDescription],
				source.[CompanyConfigurationId],
				source.[ActiveStatus]
			);

			DROP TABLE #PromotionTargetTypeTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END