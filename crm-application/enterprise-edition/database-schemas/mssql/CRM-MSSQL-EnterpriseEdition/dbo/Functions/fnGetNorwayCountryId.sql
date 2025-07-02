CREATE FUNCTION [dbo].[fnGetNorwayCountryId]()
RETURNS UNIQUEIDENTIFIER
AS
BEGIN
    RETURN (SELECT TOP 1 [CountryId] FROM [dbo].[Country] WHERE [CountryEnglishName] = 'Norway')
END
GO