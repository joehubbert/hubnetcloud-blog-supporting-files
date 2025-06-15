CREATE TABLE [dbo].[CustomerType]
(
	[CustomerTypeId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [CompanyConfigurationId] UNIQUEIDENTIFIER NOT NULL,
	[CustomerType] NVARCHAR(50) NOT NULL,
    [CustomerTypeDescription] NVARCHAR(255) NULL,
    [ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    CONSTRAINT [FK_CustomerType_CompanyConfiguration] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration] ([CompanyConfigurationId]),
    CONSTRAINT [UC_CustomerType_CustomerType] UNIQUE ([CustomerType])
)
GO

CREATE TRIGGER [TRG_UpdateCustomerType]
ON [dbo].[CustomerType]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[CustomerType]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[CustomerType] ct
    INNER JOIN 
        inserted i ON ct.[CustomerTypeId] = i.[CustomerTypeId];
END
GO