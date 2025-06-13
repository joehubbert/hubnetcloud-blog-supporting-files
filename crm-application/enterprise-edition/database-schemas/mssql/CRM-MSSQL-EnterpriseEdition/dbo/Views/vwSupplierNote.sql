CREATE VIEW [dbo].[vwSupplierNote]
AS

SELECT
SN.[SupplierNoteId] AS [Supplier Note Id],
SN.[SupplierNoteTitle] AS [Supplier Note Title],
SNT.[SupplierNoteTypeId] AS [Supplier Note Type Id],
SNT.[SupplierNoteType] AS [Supplier Note Type],
SN.[SupplierNote] AS [Supplier Note],
SN.[CreatedTimestamp] AS [Created Timestamp],
SN.[CreatedBy] AS [Created By],
SN.[ModifiedTimestamp] AS [Modified Timestamp],
SN.[ModifiedBy] AS [Modified By]
FROM [dbo].[SupplierNote] SN
INNER JOIN [dbo].[SupplierNoteType] SNT ON SN.[SupplierNoteTypeId] = SNT.[SupplierNoteTypeId]