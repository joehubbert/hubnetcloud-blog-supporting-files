CREATE FUNCTION [dbo].[CalculateAgencyCommission]
(
	@agencyId INT,
	@customerPricePaid MONEY,
	@flightDate DATE
)
RETURNS MONEY
AS

BEGIN
	DECLARE @agencyCommissionRate FLOAT
	DECLARE @result MONEY

	SET @agencyCommissionRate = (SELECT [Agency_Commission_Rate] FROM [AgencyCommission] WHERE [Agency_Id] = @agencyId AND @flightDate BETWEEN [Valid_From] AND [Valid_To])
	SET @result = (SELECT SUM(@customerPricePaid * @agencyCommissionRate))
	RETURN @result
END