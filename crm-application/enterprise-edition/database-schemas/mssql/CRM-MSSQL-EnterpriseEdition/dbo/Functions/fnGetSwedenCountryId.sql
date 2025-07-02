CREATE FUNCTION [dbo].[fnGetSwedenCountryId]()
RETURNS UNIQUEIDENTIFIER
AS
BEGIN
    RETURN (SELECT TOP 1 [CountryId] FROM [dbo].[Country] WHERE [CountryEnglishName] = 'Sweden')
END
GO