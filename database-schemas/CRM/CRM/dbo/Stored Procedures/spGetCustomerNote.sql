CREATE PROCEDURE [dbo].[spGetCustomerNote]
	@customerNoteId UNIQUEIDENTIFIER
AS

SELECT
CN.[CustomerNoteId] AS [Customer Note Id],
CN.[CustomerNoteTitle] AS [Customer Note Title],
CNT.[CustomerNoteType] AS [Customer Note Type],
CN.[CustomerNote] AS [Customer Note]
FROM [dbo].[CustomerNote] CN
INNER JOIN [dbo].[CustomerNoteType] CNT ON CN.[CustomerNoteTypeId] = CNT.[CustomerNoteTypeId]
WHERE CN.[CustomerNoteId] = @customerNoteId