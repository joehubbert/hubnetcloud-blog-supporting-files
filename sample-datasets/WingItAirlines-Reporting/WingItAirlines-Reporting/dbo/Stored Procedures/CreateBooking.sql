CREATE PROCEDURE [dbo].[CreateBooking]
	@agencyUserId INT,
	@routeId INT,
	@ticketTypeId INT,
	@travelDateTime DATETIME
AS

SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
SET LOCK_TIMEOUT 10000;

DECLARE @flightToBook INT
SET @flightToBook = (SELECT [Flight_Schedule_Id] FROM [dbo].[FlightSchedule] WHERE [Route_Id] = @routeId AND [Scheduled_Date_Time_Of_Departure_UTC] = @travelDateTime)

DECLARE @availabilityCheck BIT
SET @availabilityCheck = [dbo].[CheckAirplaneCapacity] (@flightToBook, @ticketTypeId)

DECLARE @agencyId INT
SET @agencyId = (SELECT [Agency_Id] FROM [dbo].[AgencyUser] WHERE [Agency_User_Id] = @agencyUserId)

DECLARE @customerPrice MONEY
SET @customerPrice = [dbo].[CalculateCustomerPrice] (@flightToBook, @ticketTypeId)

DECLARE @agencyCommission MONEY
SET @agencyCommission = [dbo].[CalculateAgencyCommission] (@agencyId, @customerPrice, (SELECT CAST(@travelDateTime AS DATE)))

IF @availabilityCheck = 0
THROW 51000, 'There is not enough capacity on the flight, please try a different flight.', 1
ELSE IF @availabilityCheck = 1
INSERT INTO [dbo].[TicketSale] ([Flight_Schedule_Id], [Ticket_Type_Id], [Ticket_Status_Id], [Customer_Price_Paid], [Agency_Id], [Agency_User_Id], [Agency_Commission])
VALUES 
(
@flightToBook,
@ticketTypeId,
(SELECT [Ticket_Status_Id] FROM [dbo].[TicketStatus] WHERE [Ticket_Status] = 'Confirmed'), 
@customerPrice,
@agencyId,
@agencyUserId,
@agencyCommission
)