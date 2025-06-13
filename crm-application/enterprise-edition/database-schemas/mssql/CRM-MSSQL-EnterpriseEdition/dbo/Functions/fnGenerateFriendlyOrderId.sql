CREATE FUNCTION [dbo].[fnGenerateFriendlyOrderId]
(
    @orderDate DATE,
    @sequence INT
)
RETURNS NVARCHAR(20)
AS
BEGIN
    RETURN FORMAT(@orderDate, 'yyyyMMdd') + '-' + RIGHT('000000' + CAST(@sequence AS NVARCHAR(6)), 6)
END