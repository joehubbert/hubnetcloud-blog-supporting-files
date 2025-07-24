CREATE TABLE [dbo].[PromotionProductFamily]
(
	[PromotionProductFamilyId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[PromotionId] UNIQUEIDENTIFIER NOT NULL,
	[ProductFamilyId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_PromotionProductFamily_ProductFamilyId] FOREIGN KEY ([ProductFamilyId]) REFERENCES [dbo].[ProductFamily]([ProductFamilyId]),
	CONSTRAINT [FK_PromotionProductFamily_PromotionId] FOREIGN KEY ([PromotionId]) REFERENCES [dbo].[Promotion]([PromotionId]),
	CONSTRAINT [UC_PromotionProductFamily_PromotionId_ProductFamilyId] UNIQUE ([PromotionId], [ProductFamilyId])
)
GO

CREATE INDEX [IX_PromotionProductFamily_ProductId_ProductFamilyId] ON [dbo].[PromotionProductFamily] ([ProductFamilyId])
GO

CREATE TRIGGER [TRG_UpdatePromotionProductFamily]
ON [dbo].[PromotionProductFamily]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[PromotionProductFamily]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[PromotionProductFamily] ppf
    INNER JOIN 
        inserted i ON ppf.[PromotionProductFamilyId] = i.[PromotionProductFamilyId];
END
GO