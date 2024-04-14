CREATE VIEW [dbo].[vwFlightCapacity]
AS
SELECT 
TS.[Ticket_Sale_Date] AS [Ticket Sale Date],
R.[Route_Number] AS [Route Number],
SUM(IIF(TT.[Ticket_Type] = 'Economy Class', 1, 0)) AS [Economy Class Tickets Sold],
A.[Economy_Class_Seat_Count] AS [Ecomomy Class Seat Capacity],
CEILING(SUM(A.[Economy_Class_Seat_Count] * 0.65)) AS [Ecomomy Class Minimum Sales Target],
SUM(IIF(TT.[Ticket_Type] = 'Premium Economy Class', 1, 0)) AS [Premium Economy Class Tickets Sold],
A.[Premium_Economy_Class_Seat_Count] AS [Premium Ecomomy Class Seat Capacity],
CEILING(SUM(A.[Premium_Economy_Class_Seat_Count] * 0.47)) AS [Premium Ecomomy Class Minimum Sales Target],
SUM(IIF(TT.[Ticket_Type] = 'Business Class', 1, 0)) AS [Business Class Tickets Sold],
A.[Business_Class_Seat_Count] AS [Business Class Seat Capacity],
CEILING(SUM(A.[Business_Class_Seat_Count] * 0.38)) AS [Business Class Minimum Sales Target]
FROM [dbo].[TicketSale] TS
INNER JOIN [dbo].[FlightSchedule] FS ON TS.[Flight_Schedule_Id] = FS.[Flight_Schedule_Id]
INNER JOIN [dbo].[Airplane] A ON FS.[Airplane_Id] = A.[Airplane_Id]
INNER JOIN [dbo].[Route] R ON FS.[Route_Id] = R.[Route_Id]
INNER JOIN [dbo].[TicketStatus] TST ON TS.[Ticket_Status_Id] = TST.[Ticket_Status_Id]
INNER JOIN [dbo].[TicketType] TT ON TS.[Ticket_Type_Id] = TT.[Ticket_Type_Id]
WHERE TST.[Ticket_Status] = 'Confirmed'
GROUP BY TS.[Ticket_Sale_Date], R.[Route_Number], A.[Economy_Class_Seat_Count], A.[Premium_Economy_Class_Seat_Count], A.[Business_Class_Seat_Count]