CREATE TABLE [dbo].[SalesRegionMember]
(
	[SalesRegionMemberId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[SalesRegionId] UNIQUEIDENTIFIER NOT NULL,
	[SalesRegionMember] NVARCHAR(50) NOT NULL,
	CONSTRAINT [FK_SalesRegionMember_SalesRegionId] FOREIGN KEY ([SalesRegionId]) REFERENCES [dbo].[SalesRegion]([SalesRegionId])
)