CREATE PROCEDURE [dbo].[spGetSupplier]
	@supplierId UNIQUEIDENTIFIER
AS

SELECT
[Supplier Id],
[Supplier Name],
[Address Line 1],
[Address Line 2],
[Address Line 3],
[Address Line 4],
[Address Line 5],
[Telephone Number],
[Email Address],
[Payment Days],
[Payment Currency],
[Payment Currency Id],
[VAT Number],
[Active Status],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwSupplier]
WHERE [Supplier Id] = @supplierId