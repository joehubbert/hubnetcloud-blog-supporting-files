CREATE VIEW [dbo].[vwSupplierNoteType]
AS

SELECT
[SupplierNoteTypeId] AS [Supplier Note Type Id],
[SupplierNoteType] AS [Supplier Note Type],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[SupplierNoteType]