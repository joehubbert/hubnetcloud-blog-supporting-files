CREATE VIEW [dbo].[vwAgencyCommission]
AS
SELECT
[Agency_Commission_Id] AS [Agency Commission Id],
[Agency_Id] AS [Agency Id],
[Agency_Commission_Rate] AS [Agency Commission Rate],
[Valid_From] AS [Valid From],
[Valid_To] AS [Valid To]
FROM [dbo].[AgencyCommission]