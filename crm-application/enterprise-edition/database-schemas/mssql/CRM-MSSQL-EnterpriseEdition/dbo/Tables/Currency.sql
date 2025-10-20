CREATE TABLE [dbo].[Currency]
(
	[CurrencyId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CurrencyCode] NCHAR(3) NOT NULL,
	[CurrencyName] NVARCHAR(50) NOT NULL,
    [CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [FK_Currency_MasterDataType] FOREIGN KEY ([MasterDataTypeId]) REFERENCES [dbo].[MasterDataType]([MasterDataTypeId]),
    CONSTRAINT [FK_Currency_CompanyConfiguration] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration]([CompanyConfigurationId]),
    CONSTRAINT [UC_CurrencyCode] UNIQUE ([CurrencyCode])
)
GO

CREATE TRIGGER [TRG_UpdateCurrency]
ON [dbo].[Currency]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[Currency]
    SET 
        [ModifiedTimestampUTC] = SYSUTCDATETIME(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[Currency] c
    INNER JOIN 
        inserted i ON c.[CurrencyId] = i.[CurrencyId];
END
GO