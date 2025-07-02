CREATE FUNCTION [dbo].[fnGetFinlandCountryId]()
RETURNS UNIQUEIDENTIFIER
AS
BEGIN
    RETURN (SELECT TOP 1 [CountryId] FROM [dbo].[Country] WHERE [CountryEnglishName] = 'Finland')
END
GO