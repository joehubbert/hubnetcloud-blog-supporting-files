CREATE TABLE [dbo].[CustomerLeadStatusHistory]
(
	[CustomerLeadStatusHistoryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CustomerLeadId] UNIQUEIDENTIFIER NOT NULL,
	[CustomerLeadStatusId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [FK_CustomerLeadStatusHistory_CustomerLeadId] FOREIGN KEY ([CustomerLeadId]) REFERENCES [dbo].[CustomerLead]([CustomerLeadId]),
    CONSTRAINT [FK_CustomerLeadStatusHistory_CustomerLeadStatusId] FOREIGN KEY ([CustomerLeadStatusId]) REFERENCES [dbo].[CustomerLeadStatus]([CustomerLeadStatusId])
)
GO

CREATE NONCLUSTERED INDEX [NCIX_CustomerLeadStatusHistory_CustomerLeadId]
ON [dbo].[CustomerLeadStatusHistory] ([CustomerLeadId])
GO

CREATE TRIGGER [TRG_UpdateCustomerLeadStatusHistory]
ON [dbo].[CustomerLeadStatusHistory]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[CustomerLeadStatusHistory]
    SET 
        [ModifiedTimestampUTC] = SYSUTCDATETIME(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[CustomerLeadStatusHistory] clsh
    INNER JOIN 
        inserted i ON clsh.[CustomerLeadStatusHistoryId] = i.[CustomerLeadStatusHistoryId];
END
GO