CREATE TABLE [dbo].[DeliveryMethod]
(
	[DeliveryMethodId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[TaxProfileId] UNIQUEIDENTIFIER NOT NULL,
	[DeliveryMethod] NVARCHAR(50) NOT NULL,
	[DeliveryCost] MONEY NOT NULL,
	[DeliveryTimeDays] INT NOT NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_DeliveryMethod_TaxProfileId] FOREIGN KEY ([TaxProfileId]) REFERENCES [dbo].[TaxProfile]([TaxProfileId]),
	CONSTRAINT [UC_DeliveryMethod_DeliveryMethod] UNIQUE ([DeliveryMethod])
)
GO

CREATE TRIGGER [TRG_UpdateDeliveryMethod]
ON [dbo].[DeliveryMethod]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[DeliveryMethod]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[DeliveryMethod] dm
    INNER JOIN 
        inserted i ON dm.[DeliveryMethodId] = i.[DeliveryMethodId];
END
GO