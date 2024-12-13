CREATE TABLE [dbo].[Supplier]
(
	[SupplierId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CompanyName] NVARCHAR(50) NOT NULL, 
    [AddressLine1] NVARCHAR(50) NOT NULL, 
    [AddressLine2] NVARCHAR(50) NULL, 
    [AddressLine3] NVARCHAR(50) NOT NULL, 
    [AddressLine4] NVARCHAR(50) NOT NULL, 
    [AddressLine5] NVARCHAR(50) NOT NULL, 
    [TelephoneNumber] NVARCHAR(50) NOT NULL,
    [EmailAddress] NVARCHAR(50) NOT NULL,
    [PaymentDays] INT NOT NULL,
    [ActiveStatus] BIT NOT NULL,
    [CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL
)
GO

CREATE TRIGGER [TRG_UpdateSupplier]
ON [dbo].[Supplier]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[Supplier]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[Supplier] s
    INNER JOIN 
        inserted i ON s.[SupplierId] = i.[SupplierId];
END
GO