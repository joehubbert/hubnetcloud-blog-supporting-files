CREATE VIEW [dbo].[vwTicketSale]
AS 
SELECT 
[Ticket_Sale_Id] AS [Ticket Sale Id],
[Flight_Schedule_Id] AS [Flight Schedule Id],
[Ticket_Type_Id] AS [Ticket Type Id],
[Ticket_Status_Id] AS [Ticket Status Id],
[Ticket_Sale_Timestamp] AS [Ticket Sale Timestamp],
[Ticket_Sale_Date] AS [Ticket Sale Date],
[Customer_Price_Paid] AS [Customer Price Paid],
[Agency_Id] AS [Agency Id],
[Agency_User_Id] AS [Agency User Id],
[Agency_Commission] AS [Agency Commission]
FROM [dbo].[TicketSale]