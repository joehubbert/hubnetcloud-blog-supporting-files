CREATE PROCEDURE [dbo].[spGetCustomerNote]
	@customerNoteId UNIQUEIDENTIFIER
AS

SELECT
[Customer Note Id],
[Customer Note Title],
[Customer Note Type],
[Customer Note]
FROM [dbo].[vwCustomerNote]
WHERE [Customer Note Id] = @customerNoteId