CREATE TABLE [dbo].[AgencyUser]
(
	[Agency_User_Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Agency_Id] INT NOT NULL,
	[Agency_User_Email] NVARCHAR(50) NOT NULL,
	[Agency_User_First_Name] NVARCHAR(50) NOT NULL,
	[Agency_User_Last_Name] NVARCHAR(50) NOT NULL
)
GO

ALTER TABLE [dbo].[AgencyUser]
ADD CONSTRAINT [FK_AgencyUser_Agency]
FOREIGN KEY([Agency_Id])
REFERENCES [dbo].[Agency] ([Agency_Id])
GO