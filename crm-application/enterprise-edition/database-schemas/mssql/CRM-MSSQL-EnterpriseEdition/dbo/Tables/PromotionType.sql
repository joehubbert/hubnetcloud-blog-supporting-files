CREATE TABLE [dbo].[PromotionType]
(
	[PromotionTypeId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[PromotionType] NVARCHAR(50) NOT NULL,
	[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_PromotionType_MasterDataType] FOREIGN KEY ([MasterDataTypeId]) REFERENCES [dbo].[MasterDataType]([MasterDataTypeId]),
	CONSTRAINT [FK_PromotionType_CompanyConfiguration] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration]([CompanyConfigurationId]),
	CONSTRAINT [UC_PromotionType_CompanyConfigurationId] UNIQUE ([PromotionType], [CompanyConfigurationId])
)
GO

CREATE TRIGGER [TRG_UpdatePromotionType]
ON [dbo].[PromotionType]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[PromotionType]
	SET 
		[ModifiedTimestampUTC] = SYSUTCDATETIME(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[PromotionType] pt
	INNER JOIN 
		inserted i ON pt.[PromotionTypeId] = i.[PromotionTypeId];
END
GO