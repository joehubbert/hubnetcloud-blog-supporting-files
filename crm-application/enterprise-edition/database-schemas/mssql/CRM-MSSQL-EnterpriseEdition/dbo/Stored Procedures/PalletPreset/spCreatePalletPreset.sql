CREATE PROCEDURE [dbo].[spCreatePalletPreset]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@masterDataTypeId UNIQUEIDENTIFIER,
	@palletAreaCentimeterSquared DECIMAL(10, 2),
	@palletDepthMillimeter INT,
	@palletHeightMillimeter INT,
	@palletPresetCode NVARCHAR(20),
	@palletPresetName NVARCHAR(50),
	@palletTareWeightKilogram DECIMAL(12, 3),
	@palletVolumeCubicCentimeter DECIMAL(12, 3),
	@palletWidthMillimeter INT
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #PalletPresetTemp
			(
				[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[PalletPresetName] NVARCHAR(50) NOT NULL,
				[PalletPresetCode] NVARCHAR(20) NOT NULL,
				[PalletDepthMillimeter] INT NOT NULL,
				[PalletHeightMillimeter] INT NOT NULL,
				[PalletWidthMillimeter] INT NOT NULL,
				[PalletAreaCentimeterSquared] DECIMAL(10, 2) NOT NULL,
				[PalletVolumeCubicCentimeter] DECIMAL(12, 3) NOT NULL,
				[PalletTareWeightKilogram] DECIMAL(12, 3) NULL,
				[ActiveStatus] BIT NOT NULL
			);

			INSERT INTO #PalletPresetTemp
			(
				[MasterDataTypeId],
				[CompanyConfigurationId],
				[PalletPresetName],
				[PalletPresetCode],
				[PalletDepthMillimeter],
				[PalletHeightMillimeter],
				[PalletWidthMillimeter],
				[PalletAreaCentimeterSquared],
				[PalletVolumeCubicCentimeter],
				[PalletTareWeightKilogram],
				[ActiveStatus]
			)
			VALUES
			(
				@masterDataTypeId,
				@companyConfigurationId,
				@palletPresetName,
				@palletPresetCode,
				@palletDepthMillimeter,
				@palletHeightMillimeter,
				@palletWidthMillimeter,
				@palletAreaCentimeterSquared,
				@palletVolumeCubicCentimeter,
				@palletTareWeightKilogram,
				@activeStatus
			);

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[PalletPreset] PP
				INNER JOIN #PalletPresetTemp PPT ON PP.[PalletPresetCode] = PPT.[PalletPresetCode]
				WHERE PP.[PalletPresetCode] = PPT.[PalletPresetCode]
			)
			THROW 50000, 'Pallet Preset with the same code already exists, please use a different code.', 1;
			ELSE
			MERGE INTO [dbo].[PalletPreset] AS target
			USING #PalletPresetTemp AS source
			ON target.[PalletPresetCode] = source.[PalletPresetCode]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[MasterDataTypeId],
				[CompanyConfigurationId],
				[PalletPresetName],
				[PalletPresetCode],
				[PalletDepthMillimeter],
				[PalletHeightMillimeter],
				[PalletWidthMillimeter],
				[PalletAreaCentimeterSquared],
				[PalletVolumeCubicCentimeter],
				[PalletTareWeightKilogram],
				[ActiveStatus]
			)
			VALUES
			(
				source.[MasterDataTypeId],
				source.[CompanyConfigurationId],
				source.[PalletPresetName],
				source.[PalletPresetCode],
				source.[PalletDepthMillimeter],
				source.[PalletHeightMillimeter],
				source.[PalletWidthMillimeter],
				source.[PalletAreaCentimeterSquared],
				source.[PalletVolumeCubicCentimeter],
				source.[PalletTareWeightKilogram],
				source.[ActiveStatus]
			);

			DROP TABLE #PalletPresetTemp;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END