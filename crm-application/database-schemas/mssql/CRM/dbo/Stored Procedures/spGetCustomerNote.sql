CREATE PROCEDURE [dbo].[spGetCustomerNote]
	@customerNoteId UNIQUEIDENTIFIER
AS

SELECT
[Customer Note Id],
[Customer Note Title],
[Customer Note Type],
[Customer Note],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwCustomerNote]
WHERE [Customer Note Id] = @customerNoteId