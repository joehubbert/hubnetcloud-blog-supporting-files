CREATE TABLE [dbo].[CustomerLeadStatus]
(
	[CustomerLeadStatusId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CustomerLeadStatus] NVARCHAR(50) NOT NULL,
    [ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    CONSTRAINT [UC_CustomerLeadStatus_CustomerLeadStatus] UNIQUE ([CustomerLeadStatus])
)
GO

CREATE TRIGGER [TRG_UpdateCustomerLeadStatus]
ON [dbo].[CustomerLeadStatus]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[CustomerLeadStatus]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[CustomerLeadStatus] cls
    INNER JOIN 
        inserted i ON cls.[CustomerLeadStatusId] = i.[CustomerLeadStatusId];
END
GO