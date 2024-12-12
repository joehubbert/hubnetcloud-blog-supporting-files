CREATE TABLE [dbo].[CustomerTier]
(
	[CustomerTierId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CustomerTierCode] NCHAR(1) NOT NULL,
	[CustomerTierDescription] NVARCHAR(50) NOT NULL
)