CREATE TABLE [dbo].[Manufacturer]
(
	[ManufacturerId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[ManufacturerName] NVARCHAR(50) NOT NULL,
    [AddressLine1] NVARCHAR(50) NOT NULL,
    [AddressLine2] NVARCHAR(50) NULL,
    [AddressLine3] NVARCHAR(50) NOT NULL,
    [AddressLine4] NVARCHAR(50) NOT NULL,
    [AddressLine5] NVARCHAR(50) NOT NULL,
    [TelephoneNumber] NVARCHAR(50) NOT NULL,
    [EmailAddress] NVARCHAR(50) NOT NULL,
    [VATNumber] NVARCHAR(50) NULL,
    [ActiveStatus] BIT NOT NULL,
    [CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
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
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[Manufacturer] m
    INNER JOIN 
        inserted i ON m.[ManufacturerId] = i.[ManufacturerId];
END
GO