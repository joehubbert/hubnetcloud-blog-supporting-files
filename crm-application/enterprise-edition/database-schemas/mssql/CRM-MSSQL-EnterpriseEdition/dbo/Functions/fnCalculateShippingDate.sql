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

	;WITH WorkingDaysCTE AS
	(
		SELECT 
			DATEADD(DAY, -ROW_NUMBER() OVER (ORDER BY (SELECT NULL)), @deliveryDate) AS WorkingDay,
			ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS RowNum
		FROM [master].sys.all_objects
		WHERE 
			type = 'P'
	)
	SELECT @result = MIN(WorkingDay)
	FROM WorkingDaysCTE
	WHERE 
		DATEPART(WEEKDAY, WorkingDay) BETWEEN 2 AND 6
		AND RowNum <= @deliveryTimeDays

	RETURN @result
END