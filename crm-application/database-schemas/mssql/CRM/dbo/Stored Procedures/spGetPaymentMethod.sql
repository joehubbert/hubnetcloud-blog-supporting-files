CREATE PROCEDURE [dbo].[spGetPaymentMethod]
	@paymentMethodId UNIQUEIDENTIFIER
AS

SELECT
[Payment Method Id],
[Payment Method],
[Active Status],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwPaymentMethod]
WHERE [Payment Method Id] = @paymentMethodId