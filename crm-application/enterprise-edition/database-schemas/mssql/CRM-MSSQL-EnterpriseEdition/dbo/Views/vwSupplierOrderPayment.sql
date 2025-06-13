CREATE VIEW [dbo].[vwSupplierOrderPayment]
AS

SELECT
SOP.[SupplierOrderId] AS [Supplier Order Id],
SOP.[SupplierOrderPaymentId] AS [Supplier Order Payment Id],
PM.[PaymentMethodId] AS [Payment Method Id],
PM.[PaymentMethod] AS [Payment Method],
SOP.[PaymentAmount] AS [Payment Amount]
FROM [dbo].[SupplierOrderPayment] SOP
INNER JOIN [dbo].[PaymentMethod] PM ON SOP.[PaymentMethodId] = PM.[PaymentMethodId]