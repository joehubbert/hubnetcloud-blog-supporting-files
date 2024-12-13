CREATE TABLE [dbo].[PaymentMethod]
(
	[PaymentMethodId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[PaymentMethod] NVARCHAR(50) NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL
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
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[PaymentMethod] pm
    INNER JOIN 
        inserted i ON pm.[PaymentMethodId] = i.[PaymentMethodId];
END
GO