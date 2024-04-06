CREATE FUNCTION [dbo].[CalculateCustomerPrice]
(
	@flightScheduleId INT,
	@ticketTypeId INT
)
RETURNS MONEY
AS

BEGIN
	DECLARE @flightDate DATE
	DECLARE @fareRateToApply FLOAT
	DECLARE @result MONEY
	DECLARE @ticketTypeDescription NVARCHAR(30)

	--Gets date of flight
	SET @flightDate = (SELECT CAST([Scheduled_DateTime_Departure_UTC] AS DATE) FROM [dbo].[FlightSchedule] WHERE [Flight_Schedule_Id] = @flightScheduleId)

	--Looks up the correct ticket type based in integer being passed into function
	SET @ticketTypeDescription = (SELECT [Ticket_Type] FROM [dbo].[TicketType] WHERE [Ticket_Type_Id] = @ticketTypeId)

	--Gets fare rate based on date of flight
	SET @fareRateToApply = 
	(SELECT 
	CASE
	WHEN @ticketTypeDescription = 'Economy Class'
	THEN [Passenger_Fare_Pence_Per_Mile_Economy_Class]
	WHEN @ticketTypeDescription = 'Premium Economy Class'
	THEN [Passenger_Fare_Pence_Per_Mile_Premium_Economy_Class]
	WHEN @ticketTypeDescription = 'Business Class'
	THEN [Passenger_Fare_Pence_Per_Mile_Business_Class]
	END
	FROM [dbo].[PassengerFare] 
	WHERE @flightDate BETWEEN [Valid_From] AND [Valid_To])

	--Calculates the price that the customer should pay based on miles * the fare rate
	SET @result = (SELECT SUM(R.[Route_Distance_Nautical_Miles] * @fareRateToApply)
	FROM [dbo].[FlightSchedule] FS
	INNER JOIN [dbo].[Route] R ON FS.[Route_Id] = R.[Route_Id]
	WHERE FS.[Flight_Schedule_Id] = @flightScheduleId)

	RETURN @result
END