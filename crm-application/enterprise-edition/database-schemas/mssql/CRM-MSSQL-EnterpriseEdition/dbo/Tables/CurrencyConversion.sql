CREATE TABLE [dbo].[CurrencyConversion]
(
	[CurrencyConversionId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CompanyConfigurationId] UNIQUEIDENTIFIER NOT NULL,
	[BaseCurrencyId] UNIQUEIDENTIFIER NOT NULL,
	[TargetCurrencyId] UNIQUEIDENTIFIER NOT NULL,
	[BaseCurrencyConversionRate] DECIMAL(18, 8) NOT NULL,
	[TargetCurrencyConversionRate] DECIMAL(18, 8) NOT NULL,
	[EffectiveDate] DATE NOT NULL,
	[ExpiryDate] DATE NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_CurrencyConversion_CompanyConfigurationId] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration]([CompanyConfigurationId]),
	CONSTRAINT [FK_CurrencyConversion_BaseCurrencyId] FOREIGN KEY ([BaseCurrencyId]) REFERENCES [dbo].[Currency]([CurrencyId]),
	CONSTRAINT [FK_CurrencyConversion_TargetCurrencyId] FOREIGN KEY ([TargetCurrencyId]) REFERENCES [dbo].[Currency]([CurrencyId]),
	CONSTRAINT [CC_CurrencyConversion_BaseCurrencyConversionRate] CHECK ([BaseCurrencyConversionRate] = 1),
	CONSTRAINT [CC_CurrencyConversion_TargetCurrencyConversionRate] CHECK ([TargetCurrencyConversionRate] > 0),
	CONSTRAINT [CC_CurrencyConversion_EffectiveDate] CHECK ([EffectiveDate] <= SYSUTCDATETIME()),
	CONSTRAINT [CC_CurrencyConversion_ExpiryDate] CHECK (
		([ExpiryDate] IS NULL OR [ExpiryDate] > SYSUTCDATETIME())
		AND ([EffectiveDate] < [ExpiryDate])),
	CONSTRAINT [UC_CurrencyConversion_Unique] UNIQUE (
		[BaseCurrencyId], [TargetCurrencyId], [EffectiveDate], [ExpiryDate]
	),
	INDEX [NCIX_CurrencyConversion_BaseCurrencyId_TargetCurrencyId] NONCLUSTERED
	(
		[BaseCurrencyId], [TargetCurrencyId]
	)
)
GO

CREATE TRIGGER [TRG_UpdateCurrencyConversion]
ON [dbo].[CurrencyConversion]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[CurrencyConversion]
    SET 
        [ModifiedTimestampUTC] = SYSUTCDATETIME(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[CurrencyConversion] cc
    INNER JOIN 
        inserted i ON cc.[CurrencyConversionId] = i.[CurrencyConversionId];
END
GO