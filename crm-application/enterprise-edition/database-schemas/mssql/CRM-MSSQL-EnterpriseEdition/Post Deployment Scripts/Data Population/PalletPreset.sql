CREATE TABLE #PalletPresetTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[PalletPresetName] NVARCHAR(50) NOT NULL,
	[PalletPresetCode] NVARCHAR(20) NOT NULL,
	[PalletDepthMillimeter] INT NOT NULL,
	[PalletHeightMillimeter] INT NOT NULL,
	[PalletWidthMillimeter] INT NOT NULL,
	[PalletAreaCentimeterSquared] DECIMAL(10, 2) NOT NULL,
	[PalletVolumeCubicCentimeter] DECIMAL(12, 3) NOT NULL,
	[PalletTareWeightKilogram] DECIMAL(12, 3) NULL,
    [ActiveStatus] BIT NOT NULL
)

-- Declare Built-In Master Data Type
DECLARE @builtInMasterDataTypeIdPalletPreset UNIQUEIDENTIFIER
SET @builtInMasterDataTypeIdPalletPreset = (SELECT [MasterDataTypeId] FROM [dbo].[MasterDataType] WHERE [MasterDataTypeCode] = 'BUILTIN' AND [IsCustom] = 0)

INSERT INTO #PalletPresetTemp 
(
	[MasterDataTypeId],
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
	@builtInMasterDataTypeIdPalletPreset,
	N'EPAL EUR-1 (1200×800)',
	N'EUR1',
	800,
	144,
	1200,
	CONVERT(DECIMAL(10,2), (1200*800)/100.0),
	CONVERT(DECIMAL(12,3), (1200*800*144)/1000.0),
	CAST(25.000 AS DECIMAL(12,3)),
	1
),
(
    @builtInMasterDataTypeIdPalletPreset,
    N'EPAL EUR-2 (1200×1000)',
    N'EUR2',
    1000,
    144,
    1200,
    CONVERT(DECIMAL(10,2), (1200*1000)/100.0),
    CONVERT(DECIMAL(12,3), (1200*1000*144)/1000.0),
    CAST(25.000 AS DECIMAL(12,3)),
    1
),
(
    @builtInMasterDataTypeIdPalletPreset,
    N'EPAL EUR-3 (1000×1200)',
    N'EUR3',
    1200,
    144,
    1000,
    CONVERT(DECIMAL(10,2), (1000*1200)/100.0),
    CONVERT(DECIMAL(12,3), (1000*1200*144)/1000.0),
    CAST(25.000 AS DECIMAL(12,3)),
    1
),
(
    @builtInMasterDataTypeIdPalletPreset,
    N'EPAL EUR-6 (800×600)',
    N'EUR6',
    600,
    144,
    800,
    CONVERT(DECIMAL(10,2), (800*600)/100.0),
    CONVERT(DECIMAL(12,3), (800*600*144)/1000.0),
    CAST(12.000 AS DECIMAL(12,3)),
    1
),
(
    @builtInMasterDataTypeIdPalletPreset,
    N'ISO Pallet (1200×1000)',
    N'ISO_1200x1000',
    1000,
    144,
    1200,
    CONVERT(DECIMAL(10,2), (1200*1000)/100.0),
    CONVERT(DECIMAL(12,3), (1200*1000*144)/1000.0),
    CAST(25.000 AS DECIMAL(12,3)),
    1
),
(
    @builtInMasterDataTypeIdPalletPreset,
    N'GMA (48×40 in)',
    N'GMA_48x40',
    1016,
    140,
    1219,
    CONVERT(DECIMAL(10,2), (1219*1016)/100.0),
    CONVERT(DECIMAL(12,3), (1219*1016*140)/1000.0),
    CAST(20.000 AS DECIMAL(12,3)),
    1
),
(
    @builtInMasterDataTypeIdPalletPreset,
    N'Australian (1165×1165)',
    N'AU_1165',
    1165,
    150,
    1165,
    CONVERT(DECIMAL(10,2), (1165*1165)/100.0),
    CONVERT(DECIMAL(12,3), (1165*1165*150)/1000.0),
    CAST(22.000 AS DECIMAL(12,3)),
    1
),
(
    @builtInMasterDataTypeIdPalletPreset,
    N'North American 42×42',
    N'NA_42x42',
    1067,
    140,
    1067,
    CONVERT(DECIMAL(10,2), (1067*1067)/100.0),
    CONVERT(DECIMAL(12,3), (1067*1067*140)/1000.0),
    CAST(18.000 AS DECIMAL(12,3)),
    1
),
(
    @builtInMasterDataTypeIdPalletPreset,
    N'North American 48×48',
    N'NA_48x48',
    1219,
    140,
    1219,
    CONVERT(DECIMAL(10,2), (1219*1219)/100.0),
    CONVERT(DECIMAL(12,3), (1219*1219*140)/1000.0),
    CAST(25.000 AS DECIMAL(12,3)),
    1
),
(
    @builtInMasterDataTypeIdPalletPreset,
    N'Quarter Euro (600×400)',
    N'EURO_QTR_60x40',
    400,
    144,
    600,
    CONVERT(DECIMAL(10,2), (600*400)/100.0),
    CONVERT(DECIMAL(12,3), (600*400*144)/1000.0),
    CAST(9.000 AS DECIMAL(12,3)),
    1
)

MERGE INTO [dbo].[PalletPreset] AS target
USING #PalletPresetTemp AS source
ON target.[PalletPresetCode] = source.[PalletPresetCode]
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataTypeId],
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

DROP TABLE #PalletPresetTemp