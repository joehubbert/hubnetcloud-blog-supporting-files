﻿CREATE TABLE [dbo].[CustomerTier]
(
	[CustomerTierId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[CustomerTierCode] NCHAR(1) NOT NULL,
	[CustomerTierDescription] NVARCHAR(50) NOT NULL
)