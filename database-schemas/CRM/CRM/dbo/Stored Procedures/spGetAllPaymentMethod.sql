CREATE PROCEDURE [dbo].[spGetAllPaymentMethod]
AS

SELECT
[Payment Method Id],
[Payment Method],
[Active Status]
FROM [dbo].[vwPaymentMethod]