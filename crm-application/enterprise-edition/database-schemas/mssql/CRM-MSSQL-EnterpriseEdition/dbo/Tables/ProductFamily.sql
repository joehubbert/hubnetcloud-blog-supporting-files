CREATE TABLE [dbo].[ProductFamily]
(
	[ProductFamilyId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [ProductFamily] NVARCHAR(50) NOT NULL,
    [CompanyConfigurationId] UNIQUEIDENTIFIER NOT NULL,
    [ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [FK_ProductFamily_CompanyConfiguration] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration]([CompanyConfigurationId]),
    CONSTRAINT [UC_ProductFamily] UNIQUE ([ProductFamily])
)
GO

CREATE TRIGGER [TRG_UpdateProductFamily]
ON [dbo].[ProductFamily]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[ProductFamily]
    SET 
        [ModifiedTimestampUTC] = SYSUTCDATETIME(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[ProductFamily] pf
    INNER JOIN 
        inserted i ON pf.[ProductFamilyId] = i.[ProductFamilyId];
END
GO