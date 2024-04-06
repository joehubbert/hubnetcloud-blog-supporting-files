CREATE VIEW [dbo].[vwAgencyUser]
AS
SELECT
[Agency_User_Id] AS [Agency User Id],
[Agency_Id] AS [Agency Id],
[Agency_User_Email] AS [Agency User Email],
[Agency_User_First_Name] AS [Agency User First Name],
[Agency_User_Last_Name] AS [Agency User Last Name]
FROM [dbo].[AgencyUser]