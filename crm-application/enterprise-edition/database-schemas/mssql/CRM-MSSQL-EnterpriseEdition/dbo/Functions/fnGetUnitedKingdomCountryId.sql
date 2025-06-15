CREATE FUNCTION [dbo].[fnGetUnitedKingdomCountryId]()
RETURNS UNIQUEIDENTIFIER
AS
BEGIN
    RETURN (SELECT TOP 1 [CountryId] FROM [dbo].[Country] WHERE [CountryName] = 'United Kingdom')
END
GO