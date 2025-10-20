CREATE PROCEDURE [dbo].[spUpdatePalletPreset]
	@activeStatus BIT,
	@masterDataTypeId UNIQUEIDENTIFIER,
	@palletAreaCentimeterSquared DECIMAL(10, 2),
	@palletDepthMillimeter INT,
	@palletHeightMillimeter INT,
	@palletPresetCode NVARCHAR(20),
	@palletPresetId UNIQUEIDENTIFIER,
	@palletPresetName NVARCHAR(50),
	@palletTareWeightKilogram DECIMAL(12, 3),
	@palletVolumeCubicCentimeter DECIMAL(12, 3),
	@palletWidthMillimeter INT
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[PalletPreset]
			SET 
				[ActiveStatus] = @activeStatus,
				[MasterDataTypeId] = @masterDataTypeId,
				[PalletAreaCentimeterSquared] = @palletAreaCentimeterSquared,
				[PalletDepthMillimeter] = @palletDepthMillimeter,
				[PalletHeightMillimeter] = @palletHeightMillimeter,
				[PalletPresetCode] = @palletPresetCode,
				[PalletPresetName] = @palletPresetName,
				[PalletTareWeightKilogram] = @palletTareWeightKilogram,
				[PalletVolumeCubicCentimeter] = @palletVolumeCubicCentimeter,
				[PalletWidthMillimeter] = @palletWidthMillimeter
			WHERE [PalletPresetId] = @palletPresetId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END