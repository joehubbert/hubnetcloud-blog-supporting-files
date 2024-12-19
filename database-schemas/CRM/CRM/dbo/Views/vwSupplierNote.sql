CREATE VIEW [dbo].[vwSupplierNote]
AS

SELECT
SN.[SupplierNoteId] AS [Supplier Note Id],
SN.[SupplierNoteTitle] AS [Supplier Note Title],
SNT.[SupplierNoteType] AS [Supplier Note Type],
SN.[SupplierNote] AS [Supplier Note]
FROM [dbo].[SupplierNote] SN
INNER JOIN [dbo].[SupplierNoteType] SNT ON SN.[SupplierNoteTypeId] = SNT.[SupplierNoteTypeId]