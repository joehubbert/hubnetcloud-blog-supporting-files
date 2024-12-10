CREATE TABLE [dbo].[OperationLog]
(
	[Correlation_Id] UNIQUEIDENTIFIER NOT NULL,
	[Job_Id] UNIQUEIDENTIFIER NOT NULL,
	[Job_Type] NVARCHAR(50) NOT NULL,
	[Job_Cadence] NVARCHAR(50) NOT NULL,
	[Operation_Timestamp_UTC] DATETIME2 NOT NULL,
	[Operation_Date] DATE NOT NULL,
	[Database_Name] NVARCHAR(100) NOT NULL,
	[Operation_Type] NVARCHAR(50) NOT NULL,
	[Operation_Message] NVARCHAR(MAX) NOT NULL, 
	[Operation_Outcome] NVARCHAR(10) NOT NULL
)
GO

ALTER TABLE [dbo].[OperationLog]
ADD CONSTRAINT [DV_Operation_Timestamp_UTC] DEFAULT GETUTCDATE() FOR [Operation_Timestamp_UTC]
GO

ALTER TABLE [dbo].[OperationLog]
ADD CONSTRAINT [DV_Operation_Date] DEFAULT GETUTCDATE() FOR [Operation_Date]
GO

ALTER TABLE [dbo].[OperationLog]
ADD CONSTRAINT [CC_Operation_Outcome] CHECK ([Operation_Outcome] IN ('Failed', 'Successful', 'No Action', 'Information'))
GO

CREATE NONCLUSTERED INDEX [IX_OperationLog_Correlation_Id] ON [dbo].[OperationLog] ([Operation_Date] DESC, [Job_Id], [Operation_Type])
GO