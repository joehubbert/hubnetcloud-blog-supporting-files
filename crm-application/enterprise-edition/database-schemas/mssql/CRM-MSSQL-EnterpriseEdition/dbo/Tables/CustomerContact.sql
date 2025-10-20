CREATE TABLE [dbo].[CustomerContact]
(
	[CustomerContactId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CustomerId] UNIQUEIDENTIFIER NOT NULL,
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	[EmailAddress] NVARCHAR(50) NOT NULL,
	[TelephoneNumber] NVARCHAR(13) NOT NULL,
	[Role] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_CustomerContact_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer]([CustomerId])
)
GO

CREATE TRIGGER [TRG_UpdateCustomerContact]
ON [dbo].[CustomerContact]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[CustomerContact]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[CustomerContact] cc
    INNER JOIN 
        inserted i ON cc.[CustomerContactId] = i.[CustomerContactId];
END
GO