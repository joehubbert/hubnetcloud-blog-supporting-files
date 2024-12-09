CREATE PROCEDURE [dbo].[AddOperationLogMessage]
	@correlationId UNIQUEIDENTIFIER,
	@databaseName NVARCHAR(100),
	@jobCadence NVARCHAR(50),
	@jobId UNIQUEIDENTIFIER,
	@jobType NVARCHAR(50),
	@operationType NVARCHAR(256),
	@operationMessage NVARCHAR(MAX),
	@operationOutcome NVARCHAR(10)
AS

INSERT INTO [dbo].[OperationLog] ([Correlation_Id], [Job_Id], [Job_Type], [Job_Cadence], [Database_Name], [Operation_Type], [Operation_Message], [Operation_Outcome])
VALUES (@correlationId, @jobId, @jobType, @jobCadence, @databaseName, @operationType, @operationMessage, @operationOutcome)