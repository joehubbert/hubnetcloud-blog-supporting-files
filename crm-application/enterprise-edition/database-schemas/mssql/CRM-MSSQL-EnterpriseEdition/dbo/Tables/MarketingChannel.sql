CREATE TABLE [dbo].[MarketingChannel]
(
	[MarketingChannelId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[MarketingChannel] NVARCHAR(50) NOT NULL,
    [CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
    [ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [FK_MarketingChannel_MasterDataType] FOREIGN KEY ([MasterDataTypeId]) REFERENCES [dbo].[MasterDataType]([MasterDataTypeId]),
    CONSTRAINT [FK_MarketingChannel_CompanyConfiguration] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration]([CompanyConfigurationId]),
    CONSTRAINT [UC_MarketingChannel] UNIQUE ([MarketingChannel])
)
GO

CREATE TRIGGER [TRG_UpdateMarketingChannel]
ON [dbo].[MarketingChannel]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[MarketingChannel]
    SET 
        [ModifiedTimestampUTC] = SYSUTCDATETIME(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[MarketingChannel] pm
    INNER JOIN 
        inserted i ON pm.[MarketingChannelId] = i.[MarketingChannelId];
END
GO