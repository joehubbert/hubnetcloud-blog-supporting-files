CREATE TABLE [dbo].[AgencyCommission]
(
	[Agency_Commission_Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Agency_Id] INT NOT NULL,
	[Agency_Commission_Rate] FLOAT NOT NULL,
	[Valid_From] DATE NOT NULL,
	[Valid_To] DATE NOT NULL
)
GO

ALTER TABLE [dbo].[AgencyCommission]
ADD CONSTRAINT [FK_AgencyCommission_Agency]
FOREIGN KEY([Agency_Id])
REFERENCES [dbo].[Agency] ([Agency_Id])
GO

ALTER TABLE [dbo].[AgencyCommission]
ADD CONSTRAINT [CC_Agency_Commission_Max_Agency_Commission]
CHECK ([Agency_Commission_Rate] <= 0.20)
GO