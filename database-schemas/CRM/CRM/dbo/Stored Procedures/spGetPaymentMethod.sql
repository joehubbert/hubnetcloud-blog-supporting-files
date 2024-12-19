CREATE PROCEDURE [dbo].[spGetPaymentMethod]
	@paymentMethodId UNIQUEIDENTIFIER
AS

SELECT
[Payment Method Id],
[Payment Method]
FROM [dbo].[vwPaymentMethod]
WHERE [Payment Method Id] = @paymentMethodId