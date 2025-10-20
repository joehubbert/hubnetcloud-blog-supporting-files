CREATE TABLE [dbo].[PromotionSupplier]
(
	[PromotionSupplierId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[PromotionId] UNIQUEIDENTIFIER NOT NULL,
	[SupplierId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_PromotionSupplier_PromotionId] FOREIGN KEY ([PromotionId]) REFERENCES [dbo].[Promotion]([PromotionId]),
	CONSTRAINT [FK_PromotionSupplier_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier]([SupplierId]),
	CONSTRAINT [UC_PromotionSupplier_PromotionId_SupplierId] UNIQUE ([PromotionId], [SupplierId])
)
GO

CREATE INDEX [NCIX_PromotionSupplier_SupplierId] ON [dbo].[PromotionSupplier] ([SupplierId])
GO

CREATE TRIGGER [TRG_UpdatePromotionSupplier]
ON [dbo].[PromotionSupplier]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[PromotionSupplier]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[PromotionSupplier] ps
    INNER JOIN 
        inserted i ON ps.[PromotionSupplierId] = i.[PromotionSupplierId];
END
GO