CREATE FUNCTION [dbo].[fnGenerateFriendlyOrderQuoteId]
(
    @quoteSequence INT,
    @orderFriendlyId NVARCHAR(20)
)
RETURNS NVARCHAR(24)
AS
BEGIN
    RETURN 'QUO-' + @orderFriendlyId + '-' + RIGHT('000' + CAST(@quoteSequence AS NVARCHAR(3)), 3)
END