CREATE VIEW [dbo].[vwPassengerFare]
AS 
SELECT 
[Passenger_Fare_Id] AS [Passenger Fare Id],
[Passenger_Fare_Pence_Per_Mile_Economy_Class] AS [Passenger Fare Pence Per Mile Economy Class],
[Passenger_Fare_Pence_Per_Mile_Premium_Economy_Class] AS [Passenger Fare Pence Per Mile Premium Economy Class],
[Passenger_Fare_Pence_Per_Mile_Business_Class] AS [Passenger Fare Pence Per Mile Business Class],
[Valid_From] AS [Valid From],
[Valid_To] AS [Valid To]
FROM [dbo].[PassengerFare]