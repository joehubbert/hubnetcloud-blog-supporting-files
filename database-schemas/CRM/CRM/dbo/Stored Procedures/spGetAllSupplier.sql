CREATE PROCEDURE [dbo].[spGetAllSupplier]
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
[VAT Number]
FROM [dbo].[vwSupplier]