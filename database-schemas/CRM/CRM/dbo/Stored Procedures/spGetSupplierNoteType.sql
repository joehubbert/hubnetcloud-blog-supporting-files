CREATE PROCEDURE [dbo].[spGetSupplierNoteType]
	@supplierNoteTypeId UNIQUEIDENTIFIER
AS

SELECT
[Supplier Note Type Id],
[Supplier Note Type],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwSupplierNoteType]
WHERE [Supplier Note Type Id] = @supplierNoteTypeId