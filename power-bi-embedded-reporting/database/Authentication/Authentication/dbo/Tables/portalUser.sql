CREATE TABLE [dbo].[portalUser]
(
	[portalUserId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[portalRoleId] INT NOT NULL,
	[portalUserEmailAddress] NVARCHAR(50) NOT NULL,
	CONSTRAINT FK_portalUser_portalRole_portalRoleId FOREIGN KEY (portalRoleId)
    REFERENCES [dbo].[portalRole](portalRoleId)
)