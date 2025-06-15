CREATE TABLE [dbo].[PromotionTargetType]
(
	[PromotionTargetTypeId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[PromotionTargetType] NVARCHAR(50) NOT NULL,
	[PromotionTargetTypeDescription] NVARCHAR(255) NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
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
		[ModifiedTimestampUTC] = GETUTCDATE(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[PromotionTargetType] ptt
	INNER JOIN 
		inserted i ON ptt.[PromotionTargetTypeId] = i.[PromotionTargetTypeId];
END
GO