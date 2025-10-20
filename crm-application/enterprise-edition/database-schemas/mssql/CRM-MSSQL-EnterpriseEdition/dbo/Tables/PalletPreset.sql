CREATE TABLE [dbo].[PalletPreset]
(
	[PalletPresetId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[PalletPresetName] NVARCHAR(50) NOT NULL,
	[PalletPresetCode] NVARCHAR(20) NOT NULL,
	[PalletDepthMillimeter] INT NOT NULL,
	[PalletHeightMillimeter] INT NOT NULL,
	[PalletWidthMillimeter] INT NOT NULL,
	[PalletAreaCentimeterSquared] DECIMAL(10, 2) NOT NULL,
	[PalletVolumeCubicCentimeter] DECIMAL(12, 3) NOT NULL,
	[PalletTareWeightKilogram] DECIMAL(12, 3) NOT NULL,
    [ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [UC_PalletPreset_PalletPresetCode] UNIQUE ([PalletPresetCode]),
	CONSTRAINT [FK_PalletPreset_MasterDataType] FOREIGN KEY ([MasterDataTypeId]) REFERENCES [dbo].[MasterDataType]([MasterDataTypeId])
)
GO

CREATE TRIGGER [TRG_UpdatePalletPreset]
ON [dbo].[PalletPreset]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[PalletPreset]
	SET 
		[ModifiedTimestampUTC] = SYSUTCDATETIME(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[PalletPreset] pp
	INNER JOIN 
		inserted i ON pp.[PalletPresetId] = i.[PalletPresetId];
END
GO