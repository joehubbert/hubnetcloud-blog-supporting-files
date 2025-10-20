CREATE PROCEDURE [dbo].[spGetPalletPreset]
	@palletPresetId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Pallet Preset Id],
			[Master Data Type Id],
			[Master Data Type],
			[System Defined],
			[User Defined],
			[Pallet Preset Name],
			[Pallet Preset Code],
			[Pallet Depth Millimeter],
			[Pallet Height Millimeter],
			[Pallet Width Millimeter],
			[Pallet Area Centimeter Squared],
			[Pallet Volume Cubic Centimeter],
			[Pallet Tare Weight Kilogram],
			[Active Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwPalletPreset]
			WHERE [Pallet Preset Id] = @palletPresetId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END