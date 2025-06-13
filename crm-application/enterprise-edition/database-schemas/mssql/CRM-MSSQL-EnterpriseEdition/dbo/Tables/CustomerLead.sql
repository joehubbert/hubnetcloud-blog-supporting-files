CREATE TABLE [dbo].[CustomerLead]
(
	[CustomerLeadId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CustomerId] UNIQUEIDENTIFIER NOT NULL,
	[CustomerContactId] UNIQUEIDENTIFIER NULL,
	[CustomerLeadTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CustomerLeadTitle] NVARCHAR(50) NOT NULL,
	[CustomerLead] NVARCHAR(4000) NOT NULL,
	[CustomerLeadTargetDate] DATE NULL,
	[CustomerLeadMarketingChannelId] UNIQUEIDENTIFIER NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_CustomerLead_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer]([CustomerId]),
	CONSTRAINT [FK_CustomerLead_CustomerContact] FOREIGN KEY ([CustomerContactId]) REFERENCES [dbo].[CustomerContact]([CustomerContactId]),
	CONSTRAINT [FK_CustomerLead_CustomerLeadType] FOREIGN KEY ([CustomerLeadTypeId]) REFERENCES [dbo].[CustomerLeadType]([CustomerLeadTypeId]),
	CONSTRAINT [FK_CustomerLead_MarketingChannel] FOREIGN KEY ([CustomerLeadMarketingChannelId]) REFERENCES [dbo].[MarketingChannel]([MarketingChannelId])
)
GO

CREATE INDEX [IX_CustomerLead_CustomerId] ON [dbo].[CustomerLead] ([CustomerId])
GO

CREATE INDEX [IX_CustomerLead_CustomerLeadTypeId] ON [dbo].[CustomerLead] ([CustomerLeadTypeId])
GO

CREATE INDEX [IX_CustomerLead_CustomerLeadMarketingChannelId] ON [dbo].[CustomerLead] ([CustomerLeadMarketingChannelId])
GO

CREATE TRIGGER [TRG_UpdateCustomerLead]
ON [dbo].[CustomerLead]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[CustomerLead]
	SET 
		[ModifiedTimestamp] = GETUTCDATE(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[CustomerLead] cl
	INNER JOIN 
		inserted i ON cl.[CustomerLeadId] = i.[CustomerLeadId];
END
GO