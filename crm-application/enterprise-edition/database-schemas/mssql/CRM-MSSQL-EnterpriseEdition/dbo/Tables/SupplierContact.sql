CREATE TABLE [dbo].[SupplierContact]
(
	[SupplierContactId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[SupplierId] UNIQUEIDENTIFIER NOT NULL,
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
	CONSTRAINT [FK_SupplierContact_Supplier] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier]([SupplierId])
)
GO

CREATE TRIGGER [TRG_UpdateSupplierContact]
ON [dbo].[SupplierContact]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[SupplierContact]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[SupplierContact] sc
    INNER JOIN 
        inserted i ON sc.[SupplierContactId] = i.[SupplierContactId];
END
GO