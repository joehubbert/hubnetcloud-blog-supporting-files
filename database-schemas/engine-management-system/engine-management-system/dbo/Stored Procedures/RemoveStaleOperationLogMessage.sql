CREATE PROCEDURE [dbo].[RemoveStaleOperationLogMessage]
	@historyToKeep INT,
	@operationType NVARCHAR(256)
AS

DELETE FROM [dbo].[OperationLog]
WHERE [Operation_Timestamp_UTC] <= DATEADD(DD,@historyToKeep,GETUTCDATE())
AND [Operation_Type] = @operationType