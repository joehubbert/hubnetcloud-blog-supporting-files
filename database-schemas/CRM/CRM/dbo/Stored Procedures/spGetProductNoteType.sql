CREATE PROCEDURE [dbo].[spGetProductNoteType]
	@productNoteTypeId UNIQUEIDENTIFIER
AS

SELECT
[ProductNoteTypeId] AS [Product Note Type Id],
[ProductNoteType] AS [Product Note Type]
FROM [dbo].[ProductNoteType]
WHERE [ProductNoteTypeId] = @productNoteTypeId