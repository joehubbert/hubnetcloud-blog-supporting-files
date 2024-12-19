CREATE PROCEDURE [dbo].[spGetCustomerNoteType]
	@customerNoteTypeId UNIQUEIDENTIFIER
AS

SELECT
[Customer Note Type Id],
[Customer Note Type]
FROM [dbo].[vwCustomerNoteType]
WHERE [Customer Note Type Id] = @customerNoteTypeId