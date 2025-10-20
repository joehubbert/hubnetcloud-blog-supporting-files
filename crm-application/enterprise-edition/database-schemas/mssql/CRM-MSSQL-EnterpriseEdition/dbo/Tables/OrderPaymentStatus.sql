CREATE TABLE [dbo].[OrderPaymentStatus]
(
	[OrderPaymentStatusId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[OrderPaymentStatus] NVARCHAR(50) NOT NULL,
    [ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [UC_OrderPaymentStatus_OrderPaymentStatus] UNIQUE ([OrderPaymentStatus])
)
GO

CREATE TRIGGER [TRG_UpdateOrderPaymentStatus]
ON [dbo].[OrderPaymentStatus]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[OrderPaymentStatus]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[OrderPaymentStatus] ops
    INNER JOIN 
        inserted i ON ops.[OrderPaymentStatusId] = i.[OrderPaymentStatusId];
END
GO