CREATE TABLE [dbo].[Manufacturer]
(
	[ManufacturerId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[ManufacturerName] NVARCHAR(50) NOT NULL,
    [AddressLine1] NVARCHAR(50) NOT NULL,
    [AddressLine2] NVARCHAR(50) NULL,
    [AddressLine3] NVARCHAR(50) NOT NULL,
    [AddressLine4] NVARCHAR(50) NOT NULL,
    [AddressLine5] UNIQUEIDENTIFIER NOT NULL,
    [TelephoneNumber] NVARCHAR(50) NOT NULL,
    [EmailAddress] NVARCHAR(50) NOT NULL,
    [VATRegistered] BIT NOT NULL,
    [VATNumber] NVARCHAR(50) NULL,
    [ActiveStatus] BIT NOT NULL,
    [CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [FK_Manufacturer_AddressLine5] FOREIGN KEY ([AddressLine5]) REFERENCES [dbo].[Country]([CountryId]),
    CONSTRAINT [UC_Manufacturer_ManufacturerName] UNIQUE ([ManufacturerName])
)
GO

CREATE TRIGGER [TRG_UpdateManufacturer]
ON [dbo].[Manufacturer]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[Manufacturer]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[Manufacturer] m
    INNER JOIN 
        inserted i ON m.[ManufacturerId] = i.[ManufacturerId];
END
GO