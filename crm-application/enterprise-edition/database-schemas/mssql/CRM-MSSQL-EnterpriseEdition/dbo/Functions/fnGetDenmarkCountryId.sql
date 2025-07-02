CREATE FUNCTION [dbo].[fnGetDenmarkCountryId]()
RETURNS UNIQUEIDENTIFIER
AS
BEGIN
    RETURN (SELECT TOP 1 [CountryId] FROM [dbo].[Country] WHERE [CountryEnglishName] = 'Denmark')
END
GO