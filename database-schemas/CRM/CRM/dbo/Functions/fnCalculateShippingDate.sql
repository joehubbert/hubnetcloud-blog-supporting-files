CREATE FUNCTION [dbo].[fnCalculateShippingDate]
(
	@deliveryDate DATE,
	@deliveryMethodId UNIQUEIDENTIFIER
)
RETURNS DATE
AS

BEGIN
	DECLARE @deliveryTimeDays INT
	DECLARE @result DATE

	SET @deliveryTimeDays = (SELECT [DeliveryTimeDays] FROM [dbo].[DeliveryMethod] WHERE DeliveryMethodId = @deliveryMethodId)

	WITH 
	WorkingDaysCTE AS
	(
		SELECT @deliveryTimeDays, 
			DATEADD(DAY, -ROW_NUMBER() OVER (ORDER BY (SELECT NULL)), @deliveryDate) AS WorkingDay
		FROM [master].sys.all_objects
		WHERE 
			TYPE = 'P' 
			AND DATEPART(WEEKDAY, DATEADD(DAY, -ROW_NUMBER() OVER (ORDER BY (SELECT NULL)), @deliveryDate)) BETWEEN 2 AND 6
	)
	SELECT @result = MIN(WorkingDay) FROM WorkingDaysCTE

	RETURN @result
END