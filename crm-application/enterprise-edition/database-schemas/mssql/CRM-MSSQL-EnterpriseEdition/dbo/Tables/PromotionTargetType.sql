CREATE TABLE [dbo].[PromotionTargetType]
(
	[PromotionTargetTypeId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[PromotionTargetType] NVARCHAR(50) NOT NULL,
	[PromotionTargetTypeDescription] NVARCHAR(255) NULL,
	[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_PromotionTargetType_MasterDataType] FOREIGN KEY ([MasterDataTypeId]) REFERENCES [dbo].[MasterDataType]([MasterDataTypeId]),
	CONSTRAINT [FK_PromotionTargetType_CompanyConfiguration] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration]([CompanyConfigurationId]),
	CONSTRAINT [UC_PromotionTargetType_PromotionTargetType] UNIQUE ([PromotionTargetType])
)
GO

CREATE TRIGGER [TRG_UpdatePromotionTargetType]
ON [dbo].[PromotionTargetType]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[PromotionTargetType]
	SET 
		[ModifiedTimestampUTC] = SYSUTCDATETIME(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[PromotionTargetType] ptt
	INNER JOIN 
		inserted i ON ptt.[PromotionTargetTypeId] = i.[PromotionTargetTypeId];
END
GO