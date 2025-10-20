CREATE TABLE [dbo].[OrderPaymentStatusHistory]
(
	[OrderPaymentStatusHistoryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[OrderPaymentId] UNIQUEIDENTIFIER NOT NULL,
	[OrderPaymentStatusId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_OrderPaymentStatusHistory_OrderPaymentId] FOREIGN KEY ([OrderPaymentId]) REFERENCES [dbo].[OrderPayment]([OrderPaymentId]),
	CONSTRAINT [FK_OrderPaymentStatusHistory_OrderPaymentStatusId] FOREIGN KEY ([OrderPaymentStatusId]) REFERENCES [dbo].[OrderPaymentStatus]([OrderPaymentStatusId])
)
GO

CREATE NONCLUSTERED INDEX [NCIX_OrderPaymentStatusHistory_OrderPaymentId]
ON [dbo].[OrderPaymentStatusHistory] ([OrderPaymentId])
GO

CREATE TRIGGER [TRG_UpdateOrderPaymentStatusHistory]
ON [dbo].[OrderPaymentStatusHistory]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[OrderPaymentStatusHistory]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[OrderPaymentStatusHistory] opsh
    INNER JOIN 
        inserted i ON opsh.[OrderPaymentStatusHistoryId] = i.[OrderPaymentStatusHistoryId];
END
GO