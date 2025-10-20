CREATE TABLE [dbo].[MarketingChannel]
(
	[MarketingChannelId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[MarketingChannel] NVARCHAR(50) NOT NULL,
    [ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [UC_MarketingChannel] UNIQUE ([MarketingChannel])
)
GO

CREATE TRIGGER [TRG_UpdateMarketingChannel]
ON [dbo].[MarketingChannel]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[MarketingChannel]
    SET 
        [ModifiedTimestampUTC] = SYSUTCDATETIME(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[MarketingChannel] pm
    INNER JOIN 
        inserted i ON pm.[MarketingChannelId] = i.[MarketingChannelId];
END
GO