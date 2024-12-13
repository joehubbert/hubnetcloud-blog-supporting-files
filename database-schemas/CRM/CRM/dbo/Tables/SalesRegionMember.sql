CREATE TABLE [dbo].[SalesRegionMember]
(
	[SalesRegionMemberId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[SalesRegionId] UNIQUEIDENTIFIER NOT NULL,
	[SalesRegionMember] NVARCHAR(50) NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_SalesRegionMember_SalesRegionId] FOREIGN KEY ([SalesRegionId]) REFERENCES [dbo].[SalesRegion]([SalesRegionId])
)
GO

CREATE TRIGGER [TRG_UpdateSalesRegionMember]
ON [dbo].[SalesRegionMember]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[SalesRegionMember]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[SalesRegionMember] srm
    INNER JOIN 
        inserted i ON srm.[SalesRegionMemberId] = i.[SalesRegionMemberId];
END
GO