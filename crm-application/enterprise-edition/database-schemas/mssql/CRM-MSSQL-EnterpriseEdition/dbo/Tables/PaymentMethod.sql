CREATE TABLE [dbo].[PaymentMethod]
(
	[PaymentMethodId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[PaymentMethod] NVARCHAR(50) NOT NULL,
    [ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    CONSTRAINT [UC_PaymentMethod] UNIQUE ([PaymentMethod])
)
GO

CREATE TRIGGER [TRG_UpdatePaymentMethod]
ON [dbo].[PaymentMethod]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[PaymentMethod]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[PaymentMethod] pm
    INNER JOIN 
        inserted i ON pm.[PaymentMethodId] = i.[PaymentMethodId];
END
GO