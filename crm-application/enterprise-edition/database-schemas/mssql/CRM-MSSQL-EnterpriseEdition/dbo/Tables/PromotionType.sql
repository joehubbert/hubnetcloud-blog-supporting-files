CREATE TABLE [dbo].[PromotionType]
(
	[PromotionTypeId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[PromotionType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [UC_PromotionType] UNIQUE ([PromotionType])
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
		[ModifiedTimestampUTC] = GETUTCDATE(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[PromotionType] pt
	INNER JOIN 
		inserted i ON pt.[PromotionTypeId] = i.[PromotionTypeId];
END
GO