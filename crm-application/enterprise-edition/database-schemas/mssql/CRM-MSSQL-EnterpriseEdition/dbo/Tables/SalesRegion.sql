CREATE TABLE [dbo].[SalesRegion]
(
	[SalesRegionId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[SalesRegion] NVARCHAR(50) NOT NULL,
    [CompanyConfigurationId] UNIQUEIDENTIFIER NOT NULL,
    [ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    CONSTRAINT [FK_SalesRegion_CompanyConfiguration] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration]([CompanyConfigurationId]),
    CONSTRAINT [UC_SalesRegion] UNIQUE ([SalesRegion])
)
GO

CREATE TRIGGER [TRG_UpdateSalesRegion]
ON [dbo].[SalesRegion]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[SalesRegion]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[SalesRegion] sr
    INNER JOIN 
        inserted i ON sr.[SalesRegionId] = i.[SalesRegionId];
END
GO