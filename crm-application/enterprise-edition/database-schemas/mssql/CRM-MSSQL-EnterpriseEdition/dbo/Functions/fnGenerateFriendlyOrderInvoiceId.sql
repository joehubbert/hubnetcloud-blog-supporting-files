CREATE FUNCTION [dbo].[fnGenerateFriendlyOrderInvoiceId]
(
    @invoiceSequence INT,
    @orderFriendlyId NVARCHAR(20)
)
RETURNS NVARCHAR(24)
AS
BEGIN
    RETURN 'INV-' + @orderFriendlyId + '-' + RIGHT('000' + CAST(@invoiceSequence AS NVARCHAR(3)), 3)
END