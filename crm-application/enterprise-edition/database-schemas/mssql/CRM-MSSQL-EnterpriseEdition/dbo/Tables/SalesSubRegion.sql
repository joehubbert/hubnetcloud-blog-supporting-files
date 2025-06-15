CREATE TABLE [dbo].[SalesSubRegion]
(
	[SalesSubRegionId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[SalesRegionId] UNIQUEIDENTIFIER NOT NULL,
	[SalesSubRegion] NVARCHAR(50) NOT NULL,
    [ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_SalesSubRegion_SalesRegionId] FOREIGN KEY ([SalesRegionId]) REFERENCES [dbo].[SalesRegion]([SalesRegionId])
)
GO

CREATE NONCLUSTERED INDEX [IX_SalesSubRegion_SalesRegionId]
ON [dbo].[SalesSubRegion] ([SalesRegionId])
GO

CREATE TRIGGER [TRG_UpdateSalesSubRegion]
ON [dbo].[SalesSubRegion]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[SalesSubRegion]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[SalesSubRegion] srm
    INNER JOIN 
        inserted i ON srm.[SalesSubRegionId] = i.[SalesSubRegionId];
END
GO