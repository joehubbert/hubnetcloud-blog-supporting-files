CREATE PROCEDURE [dbo].[spGetCompanyConfiguration]
	@companyId UNIQUEIDENTIFIER
AS

SELECT
[Company Id],
[Company Name],
[Address Line 1],
[Address Line 2],
[Address Line 3],
[Address Line 4],
[Address Line 5],
[Telephone Number],
[Email Address],
[VAT Number],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwCompanyConfiguration]
WHERE [Company Id] = @companyId