CREATE PROCEDURE [dbo].[spGetAllNoteForCustomer]
	@customerId UNIQUEIDENTIFIER
AS

SELECT
CN.[CustomerNoteId] AS [Customer Note Id],
CN.[CustomerNoteTitle] AS [Customer Note Title],
CNT.[CustomerNoteType] AS [Customer Note Type],
LEFT(CN.[CustomerNote],50) AS [Customer Note],
CAST(CN.[CreatedTimestamp] AS DATE) AS [Date Logged],
CN.[CreatedBy] AS [Logged By]
FROM [dbo].[CustomerNote] CN
INNER JOIN [dbo].[CustomerNoteType] CNT ON CN.[CustomerNoteTypeId] = CNT.[CustomerNoteTypeId]
WHERE CN.[CustomerId] = @customerId