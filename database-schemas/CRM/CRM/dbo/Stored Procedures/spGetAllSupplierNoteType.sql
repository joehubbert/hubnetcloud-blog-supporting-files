CREATE PROCEDURE [dbo].[spGetAllSupplierNoteType]
AS

SELECT
[Supplier Note Type Id],
[Supplier Note Type],
[Active Status]
FROM [dbo].[vwSupplierNoteType]