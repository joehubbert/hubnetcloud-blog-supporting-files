CREATE FUNCTION [dbo].[CalculateRouteDistance]
(
	@departureAirportId INT,
	@destinationAirportId INT
)
RETURNS FLOAT
AS

BEGIN
	DECLARE @departureAirportLocation GEOGRAPHY
	DECLARE @destinationAirportLocation GEOGRAPHY
	DECLARE @result FLOAT;

	SET @departureAirportLocation = (SELECT [Airport_Geo_Location] FROM [dbo].[Airport] WHERE [Airport_Id] = @departureAirportId)
	SET @destinationAirportLocation = (SELECT [Airport_Geo_Location] FROM [dbo].[Airport] WHERE [Airport_Id] = @destinationAirportId)

	--Calculates distance in miles
	SET @result = (@departureAirportLocation.STDistance(@destinationAirportLocation) * 0.000621371) * 0.86897624
	RETURN @result
END