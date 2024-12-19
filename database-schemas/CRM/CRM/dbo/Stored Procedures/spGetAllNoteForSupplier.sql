CREATE PROCEDURE [dbo].[spGetAllNoteForSupplier]
	@supplierId UNIQUEIDENTIFIER
AS

SELECT
[Supplier Note Id],
[Supplier Note Title],
[Supplier Note Type],
[Supplier Note],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwSupplierNoteSummary]
WHERE [Supplier Id] = @supplierId