CREATE FUNCTION [dbo].[CheckAirplaneCapacity]
(
	@flightScheduleId INT,
	@ticketType INT
)
RETURNS BIT
AS
BEGIN
	DECLARE @airplaneId INT
	DECLARE @airplaneCapacityAvailabilityTicketType INT
	DECLARE @airplaneCapacityTicketType INT
	DECLARE @existingTicketSales INT
	DECLARE @result BIT
	DECLARE @ticketTypeDescription NVARCHAR(30)

	--Looks up the airplane assigned to the flight schedule
	SET @airplaneId = (SELECT [Airplane_Id] FROM [dbo].[FlightSchedule] WHERE [Flight_Schedule_Id] = @flightScheduleId)
	
	--Looks up the correct ticket type based in integer being passed into function
	SET @ticketTypeDescription = (SELECT [Ticket_Type] FROM [dbo].[TicketType] WHERE [Ticket_Type_Id] = @ticketType)

	--Looks up the airplane capacity for the chosen ticket type
	SET @airplaneCapacityTicketType =
	(
	SELECT
	CASE
	WHEN @ticketTypeDescription = 'Economy Class'
	THEN [Economy_Class_Seat_Count]
	WHEN @ticketTypeDescription = 'Premium Economy Class'
	THEN [Premium_Economy_Class_Seat_Count]
	WHEN @ticketTypeDescription = 'Business Class'
	THEN [Business_Class_Seat_Count]
	END
	FROM [dbo].[Airplane]
	WHERE [Airplane_Id] = @airplaneId
	)

	--Looks up the amount of existing bookings for ticket type on flight
	SET @existingTicketSales =
	(
	SELECT COUNT(TS.[Ticket_Sale_Id])
	FROM [dbo].[TicketSale] TS
	INNER JOIN [dbo].[FlightSchedule] FS ON TS.[Flight_Schedule_Id] = FS.[Flight_Schedule_Id]
	INNER JOIN [dbo].[TicketType] TT ON TS.[Ticket_Type_Id] = TT.[Ticket_Type_Id]
	INNER JOIN [dbo].[Airplane] A ON FS.[Airplane_Id] = A.[Airplane_Id]
	WHERE TT.[Ticket_Type] = @ticketTypeDescription
	AND FS.[Flight_Schedule_Id] = @flightScheduleId
	AND A.[Airplane_Id] = @airplaneId
	)

	--Check for existing bookings for ticket type on flight and check remaining capacity for airplane
	SET @airplaneCapacityAvailabilityTicketType =
	(
	SELECT
	SUM(@airplaneCapacityTicketType - @existingTicketSales)
	)

	SET @result = (SELECT IIF(@airplaneCapacityAvailabilityTicketType > 0, 1, 0))
	RETURN @result
END