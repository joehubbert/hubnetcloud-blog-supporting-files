CREATE PROCEDURE [dbo].[spGetAllPaymentMethod]
AS

SELECT
[Payment Method Id],
[Payment Method]
FROM [dbo].[vwPaymentMethod]