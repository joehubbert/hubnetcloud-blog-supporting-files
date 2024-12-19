CREATE PROCEDURE [dbo].[spGetAllSupplierNoteType]
AS

SELECT
[Supplier Note Type Id],
[Supplier Note Type]
FROM [dbo].[vwSupplierNoteType]