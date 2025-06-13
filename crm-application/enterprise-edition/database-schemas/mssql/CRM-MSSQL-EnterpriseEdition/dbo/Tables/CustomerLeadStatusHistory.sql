CREATE TABLE [dbo].[CustomerLeadStatusHistory]
(
	[CustomerLeadStatusHistoryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CustomerLeadId] UNIQUEIDENTIFIER NOT NULL,
	[CustomerLeadStatusId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    CONSTRAINT [FK_CustomerLeadStatusHistory_CustomerLeadId] FOREIGN KEY ([CustomerLeadId]) REFERENCES [dbo].[CustomerLead]([CustomerLeadId]),
    CONSTRAINT [FK_CustomerLeadStatusHistory_CustomerLeadStatusId] FOREIGN KEY ([CustomerLeadStatusId]) REFERENCES [dbo].[CustomerLeadStatus]([CustomerLeadStatusId])
)
GO

CREATE NONCLUSTERED INDEX [IX_CustomerLeadStatusHistory_CustomerLeadId]
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
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[CustomerLeadStatusHistory] clsh
    INNER JOIN 
        inserted i ON clsh.[CustomerLeadStatusHistoryId] = i.[CustomerLeadStatusHistoryId];
END
GO