CREATE PROCEDURE [dbo].[spGetCustomerNoteType]
	@customerNoteTypeId UNIQUEIDENTIFIER
AS

SELECT
[CustomerNoteTypeId] AS [Customer Note Type Id],
[CustomerNoteType] AS [Customer Note Type]
FROM [dbo].[CustomerNoteType]
WHERE [CustomerNoteTypeId] = @customerNoteTypeId