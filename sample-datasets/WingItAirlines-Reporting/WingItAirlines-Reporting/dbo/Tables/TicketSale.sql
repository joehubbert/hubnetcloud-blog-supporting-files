CREATE TABLE [dbo].[TicketSale]
(
	[Ticket_Sale_Id] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Flight_Schedule_Id] BIGINT NOT NULL,
	[Ticket_Type_Id] INT NOT NULL,
	[Ticket_Status_Id] INT NOT NULL,
	[Ticket_Sale_Timestamp] DATETIME2 NOT NULL,
	[Ticket_Sale_Date] AS CAST([Ticket_Sale_Timestamp] AS DATE) PERSISTED,
	[Customer_Price_Paid] MONEY NOT NULL,
	[Agency_Id] INT NOT NULL,
	[Agency_User_Id] INT NOT NULL,
	[Agency_Commission] MONEY NOT NULL
)
GO

ALTER TABLE [dbo].[TicketSale]
ADD CONSTRAINT [FK_TicketSale_Flight_Schedule]
FOREIGN KEY([Flight_Schedule_Id])
REFERENCES [dbo].[FlightSchedule] ([Flight_Schedule_Id])
GO

ALTER TABLE [dbo].[TicketSale]
ADD CONSTRAINT [FK_TicketSale_TicketType]
FOREIGN KEY([Ticket_Type_Id])
REFERENCES [dbo].[TicketType] ([Ticket_Type_Id])
GO

ALTER TABLE [dbo].[TicketSale]
ADD CONSTRAINT [FK_TicketSale_Agency]
FOREIGN KEY([Agency_Id])
REFERENCES [dbo].[Agency] ([Agency_Id])
GO

ALTER TABLE [dbo].[TicketSale]
ADD CONSTRAINT [FK_TicketSale_AgencyUser]
FOREIGN KEY([Agency_User_Id])
REFERENCES [dbo].[AgencyUser] ([Agency_User_Id])
GO

CREATE INDEX [IDX_TicketSale]
ON [dbo].[TicketSale]
(
[Ticket_Sale_Date],
[Agency_Id],
[Ticket_Type_Id]
)