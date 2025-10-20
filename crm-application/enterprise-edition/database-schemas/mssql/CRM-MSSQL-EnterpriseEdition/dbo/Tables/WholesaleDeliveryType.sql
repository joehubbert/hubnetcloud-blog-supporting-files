CREATE TABLE [dbo].[WholesaleDeliveryType]
(
	[WholesaleDeliveryTypeId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[WholesaleDeliveryType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [UC_WholesaleDeliveryType] UNIQUE ([WholesaleDeliveryType])
)
GO

CREATE TRIGGER [TRG_UpdateWholesaleDeliveryType]
ON [dbo].[WholesaleDeliveryType]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[WholesaleDeliveryType]
	SET 
		[ModifiedTimestampUTC] = GETUTCDATE(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[WholesaleDeliveryType] wdt
	INNER JOIN 
		inserted i ON wdt.[WholesaleDeliveryTypeId] = i.[WholesaleDeliveryTypeId];
END
GO