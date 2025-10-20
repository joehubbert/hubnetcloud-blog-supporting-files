CREATE VIEW [dbo].[vwSupplierOrderPaymentStatus]
AS

SELECT
[SupplierOrderPaymentStatusId] AS [Supplier Order Payment Status Id],
[SupplierOrderPaymentStatus] AS [Supplier Order Payment Status],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] [Modified By],
[RowVersion] AS [Row Version]
FROM [dbo].[SupplierOrderPaymentStatus]