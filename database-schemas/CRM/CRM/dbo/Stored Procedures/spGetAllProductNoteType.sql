CREATE PROCEDURE [dbo].[spGetAllProductNoteType]
AS

SELECT
[ProductNoteTypeId] AS [Product Note Type Id],
[ProductNoteType] AS [Product Note Type]
FROM [dbo].[ProductNoteType]