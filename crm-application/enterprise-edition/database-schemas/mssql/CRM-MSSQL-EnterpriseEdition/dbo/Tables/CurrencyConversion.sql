CREATE TABLE [dbo].[CurrencyConversion]
(
	[CurrencyConversionId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CompanyConfigurationId] UNIQUEIDENTIFIER NOT NULL,
	[CurrencyAId] UNIQUEIDENTIFIER NOT NULL,
	[CurrencyBId] UNIQUEIDENTIFIER NOT NULL,
	[ConversionRate] DECIMAL(18, 6) NOT NULL,
	[EffectiveDate] DATE NOT NULL,
	[ExpiryDate] DATE NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_CurrencyConversion_CompanyConfigurationId] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration]([CompanyConfigurationId]),
	CONSTRAINT [FK_CurrencyConversion_CurrencyAId] FOREIGN KEY ([CurrencyAId]) REFERENCES [dbo].[Currency]([CurrencyId]),
	CONSTRAINT [FK_CurrencyConversion_CurrencyBId] FOREIGN KEY ([CurrencyBId]) REFERENCES [dbo].[Currency]([CurrencyId]),
	CONSTRAINT [CC_CurrencyConversion_ConversionRate] CHECK ([ConversionRate] > 0),
	CONSTRAINT [CC_CurrencyConversion_EffectiveDate] CHECK ([EffectiveDate] <= GETUTCDATE()),
	CONSTRAINT [CC_CurrencyConversion_ExpiryDate] CHECK (
		([ExpiryDate] IS NULL OR [ExpiryDate] > GETUTCDATE())
		AND ([EffectiveDate] < [ExpiryDate])),
	CONSTRAINT [UC_CurrencyConversion_Unique] UNIQUE (
		[CurrencyAId], [CurrencyBId], [EffectiveDate], [ExpiryDate]
	),
	INDEX [IX_CurrencyConversion_CurrencyAId_CurrencyBId] NONCLUSTERED
	(
		[CurrencyAId], [CurrencyBId]
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
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[CurrencyConversion] cc
    INNER JOIN 
        inserted i ON cc.[CurrencyConversionId] = i.[CurrencyConversionId];
END
GO