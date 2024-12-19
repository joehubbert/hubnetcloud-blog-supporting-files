CREATE VIEW [dbo].[vwSupplierNoteSummary]
AS

SELECT
SN.[SupplierId] AS [Supplier Id],
SN.[SupplierNoteId] AS [Supplier Note Id],
SN.[SupplierNoteTitle] AS [Supplier Note Title],
SNT.[SupplierNoteType] AS [Supplier Note Type],
LEFT(SN.[SupplierNote],50) AS [Supplier Note],
CAST(SN.[CreatedTimestamp] AS DATE) AS [Date Logged],
SN.[CreatedBy] AS [Logged By]
FROM [dbo].[SupplierNote] SN
INNER JOIN [dbo].[SupplierNoteType] SNT ON SN.[SupplierNoteTypeId] = SNT.[SupplierNoteTypeId]