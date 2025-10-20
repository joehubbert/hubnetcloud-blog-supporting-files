CREATE VIEW [dbo].[vwSupplierNoteType]
AS

SELECT
[SupplierNoteTypeId] AS [Supplier Note Type Id],
[SupplierNoteType] AS [Supplier Note Type],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By],
[RowVersion] AS [Row Version]
FROM [dbo].[SupplierNoteType]