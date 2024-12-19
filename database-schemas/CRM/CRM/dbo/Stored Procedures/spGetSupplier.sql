CREATE PROCEDURE [dbo].[spGetSupplier]
	@supplierId UNIQUEIDENTIFIER
AS

SELECT
[Supplier Id],
[Company Name],
[Address Line 1],
[Address Line 2],
[Address Line 3],
[Address Line 4],
[Address Line 5],
[Telephone Number],
[Email Address],
[Payment Days],
[Payment Currency]
FROM [dbo].[vwSupplier]
WHERE [Supplier Id] = @supplierId