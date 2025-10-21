CREATE TABLE [dbo].[MasterDataType]
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[MasterDataType] NVARCHAR(50) NOT NULL,
	[MasterDataTypeCode] NVARCHAR(20) NOT NULL,
	[IsCustom] BIT NOT NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [UC_MasterDataType_MasterDataType] UNIQUE ([MasterDataType]),
	CONSTRAINT [UC_MasterDataType_MasterDataTypeCode] UNIQUE ([MasterDataTypeCode])
)
GO

CREATE TRIGGER [TRG_UpdateMasterDataType]
ON [dbo].[MasterDataType]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[MasterDataType]
	SET 
		[ModifiedTimestampUTC] = SYSUTCDATETIME(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[MasterDataType] mdt
	INNER JOIN 
		inserted i ON mdt.[MasterDataTypeId] = i.[MasterDataTypeId];
END
GO