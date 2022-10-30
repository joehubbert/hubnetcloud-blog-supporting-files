CREATE TABLE [dbo].[PassengerFare]
(
	[Passenger_Fare_Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Passenger_Fare_Pence_Per_Mile_Economy_Class] FLOAT NOT NULL,
	[Passenger_Fare_Pence_Per_Mile_Premium_Economy_Class] FLOAT NOT NULL,
	[Passenger_Fare_Pence_Per_Mile_Business_Class] FLOAT NOT NULL,
	[Valid_From] DATE NOT NULL,
	[Valid_To] DATE NOT NULL
)