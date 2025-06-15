CREATE TABLE [dbo].[CustomerLeadType]
(
	[CustomerLeadTypeId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CustomerLeadType] NVARCHAR(50) NOT NULL,
	[CustomerLeadTypeDescription] NVARCHAR(255) NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [UC_CustomerLeadType_CustomerLeadType] UNIQUE ([CustomerLeadType])
)
GO

CREATE TRIGGER [TRG_UpdateCustomerLeadType]
ON [dbo].[CustomerLeadType]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[CustomerLeadType]
	SET 
		[ModifiedTimestampUTC] = GETUTCDATE(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[CustomerLeadType] clt
	INNER JOIN 
		inserted i ON clt.[CustomerLeadTypeId] = i.[CustomerLeadTypeId];
END
GO