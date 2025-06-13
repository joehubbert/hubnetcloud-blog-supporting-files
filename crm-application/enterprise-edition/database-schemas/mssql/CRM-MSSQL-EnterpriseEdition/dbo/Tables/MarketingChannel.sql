CREATE TABLE [dbo].[MarketingChannel]
(
	[MarketingChannelId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[MarketingChannel] NVARCHAR(50) NOT NULL,
    [ActiveStatus] BIT NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
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
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[MarketingChannel] pm
    INNER JOIN 
        inserted i ON pm.[MarketingChannelId] = i.[MarketingChannelId];
END
GO