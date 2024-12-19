CREATE PROCEDURE [dbo].[spGetAllSupplierNoteType]
AS

SELECT
[SupplierNoteTypeId] AS [Supplier Note Type ID],
[SupplierNoteType] AS [Supplier Note Type]
FROM [dbo].[SupplierNoteType]