CREATE PROCEDURE [dbo].[spGetAllPalletPreset]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Pallet Preset Id],
			[Master Data Type Id],
			[Master Data Type],
			[Master Data Type Code],
			[Is Custom],
			[Pallet Preset Name],
			[Pallet Preset Code],
			[Pallet Depth Millimeter],
			[Pallet Height Millimeter],
			[Pallet Width Millimeter],
			[Pallet Area Centimeter Squared],
			[Pallet Volume Cubic Centimeter],
			[Pallet Tare Weight Kilogram],
			[Active Status]
			FROM [dbo].[vwPalletPreset]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END