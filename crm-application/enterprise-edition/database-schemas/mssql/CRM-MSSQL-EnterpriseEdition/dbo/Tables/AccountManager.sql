CREATE TABLE [dbo].[AccountManager]
(
	[AccountManagerId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CompanyConfigurationId] UNIQUEIDENTIFIER NOT NULL,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[EmailAddress] NVARCHAR(50) NOT NULL,
	[TelephoneNumber] NVARCHAR(13) NOT NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_AccountManager_CompanyConfiguration] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration] ([CompanyConfigurationId]),
	CONSTRAINT [UC_AccountManager_EmailAddress] UNIQUE ([EmailAddress])
)
GO

CREATE TRIGGER [TRG_UpdateAccountManager]
ON [dbo].[AccountManager]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[AccountManager]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[AccountManager] am
    INNER JOIN 
        inserted i ON am.[AccountManagerId] = i.[AccountManagerId];
END
GO