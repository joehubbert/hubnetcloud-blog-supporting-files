CREATE TABLE [dbo].[portalUser]
(
	[portalUserId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[portalUserEmailAddress] NVARCHAR(50) NOT NULL
)