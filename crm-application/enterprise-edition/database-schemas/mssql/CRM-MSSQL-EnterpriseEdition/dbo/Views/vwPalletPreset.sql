CREATE VIEW [dbo].[vwPalletPreset]
AS

SELECT
PP.[PalletPresetId] AS [Pallet Preset Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
PP.[PalletPresetName] AS [Pallet Preset Name],
PP.[PalletPresetCode] AS [Pallet Preset Code],
PP.[PalletDepthMillimeter] AS [Pallet Depth Millimeter],
PP.[PalletHeightMillimeter] AS [Pallet Height Millimeter],
PP.[PalletWidthMillimeter] AS [Pallet Width Millimeter],
PP.[PalletAreaCentimeterSquared] AS [Pallet Area Centimeter Squared],
PP.[PalletVolumeCubicCentimeter] AS [Pallet Volume Cubic Centimeter],
PP.[PalletTareWeightKilogram] AS [Pallet Tare Weight Kilogram],
PP.[ActiveStatus] AS [Active Status],
PP.[CreatedTimestampUTC] AS [Created Timestamp UTC],
PP.[CreatedBy] AS [Created By],
PP.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
PP.[ModifiedBy] AS [Modified By],
PP.[RowVersion] AS [Row Version]
FROM [dbo].[PalletPreset] PP
INNER JOIN [dbo].[MasterDataType] MDT ON PP.[MasterDataTypeId] = MDT.[MasterDataTypeId]