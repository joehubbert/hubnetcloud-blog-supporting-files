CREATE VIEW [dbo].[vwSupplierOrderPaymentStatus]
AS

SELECT
[SupplierOrderPaymentStatusId] AS [Supplier Order Payment Status Id],
[SupplierOrderPaymentStatus] AS [Supplier Order Payment Status],
[ActiveStatus] AS [Active Status]
FROM [dbo].[SupplierOrderPaymentStatus]