CREATE TABLE [dbo].[DeliveryMethod]
(
	[DeliveryMethodId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[TaxProfileId] UNIQUEIDENTIFIER NOT NULL,
	[DeliveryMethod] NVARCHAR(50) NOT NULL,
	[DeliveryCost] MONEY NOT NULL,
	[DeliveryTimeDays] INT NOT NULL,
	CONSTRAINT [FK_DeliveryMethod_TaxProfileId] FOREIGN KEY ([TaxProfileId]) REFERENCES [dbo].[TaxProfile]([TaxProfileId])
)