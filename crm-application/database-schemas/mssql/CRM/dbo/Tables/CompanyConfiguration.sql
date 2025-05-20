CREATE TABLE [dbo].[CompanyConfiguration]
(
	[CompanyId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CompanyName] NVARCHAR(50) NOT NULL,
    [CompanyLogo] VARBINARY(MAX) NULL,
    [AddressLine1] NVARCHAR(50) NOT NULL,
    [AddressLine2] NVARCHAR(50) NULL,
    [AddressLine3] NVARCHAR(50) NOT NULL,
    [AddressLine4] NVARCHAR(50) NOT NULL,
    [AddressLine5] NVARCHAR(50) NOT NULL,
    [TelephoneNumber] NVARCHAR(50) NOT NULL,
    [EmailAddress] NVARCHAR(50) NOT NULL,
    [VATNumber] NVARCHAR(50) NULL,
    [CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL
)
GO

CREATE TRIGGER [TRG_UpdateCompanyConfiguration]
ON [dbo].[CompanyConfiguration]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[CompanyConfiguration]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[CompanyConfiguration] c
    INNER JOIN 
        inserted i ON c.[CompanyId] = i.[CompanyId];
END
GO