CREATE TABLE [dbo].[PromotionProduct]
(
	[PromotionProductId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[PromotionId] UNIQUEIDENTIFIER NOT NULL,
	[ProductId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_PromotionProduct_PromotionId] FOREIGN KEY ([PromotionId]) REFERENCES [dbo].[Promotion]([PromotionId]),
	CONSTRAINT [FK_PromotionProduct_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([ProductId]),
	CONSTRAINT [UC_PromotionProduct_PromotionId_ProductId] UNIQUE ([PromotionId], [ProductId])
)
GO

CREATE INDEX [NCIX_PromotionProduct_ProductId] ON [dbo].[PromotionProduct] ([ProductId])
GO

CREATE TRIGGER [TRG_UpdatePromotionProduct]
ON [dbo].[PromotionProduct]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[PromotionProduct]
    SET 
        [ModifiedTimestampUTC] = SYSUTCDATETIME(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[PromotionProduct] pp
    INNER JOIN 
        inserted i ON pp.[PromotionProductId] = i.[PromotionProductId];
END
GO