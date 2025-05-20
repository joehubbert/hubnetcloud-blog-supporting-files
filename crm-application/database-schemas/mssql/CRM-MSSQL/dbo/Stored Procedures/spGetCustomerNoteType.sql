CREATE PROCEDURE [dbo].[spGetCustomerNoteType]
	@customerNoteTypeId UNIQUEIDENTIFIER
AS

SELECT
[Customer Note Type Id],
[Customer Note Type],
[Active Status],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwCustomerNoteType]
WHERE [Customer Note Type Id] = @customerNoteTypeId