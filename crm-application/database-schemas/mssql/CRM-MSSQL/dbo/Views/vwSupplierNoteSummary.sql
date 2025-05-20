CREATE VIEW [dbo].[vwSupplierNoteSummary]
AS

SELECT
SN.[SupplierId] AS [Supplier Id],
SN.[SupplierNoteId] AS [Supplier Note Id],
SN.[SupplierNoteTitle] AS [Supplier Note Title],
SNT.[SupplierNoteType] AS [Supplier Note Type],
LEFT(SN.[SupplierNote],50) AS [Supplier Note],
SN.[CreatedTimestamp] AS [Created Timestamp],
SN.[CreatedBy] AS [Created By],
SN.[ModifiedTimestamp] AS [Modified Timestamp],
SN.[ModifiedBy] AS [Modified By]
FROM [dbo].[SupplierNote] SN
INNER JOIN [dbo].[SupplierNoteType] SNT ON SN.[SupplierNoteTypeId] = SNT.[SupplierNoteTypeId]