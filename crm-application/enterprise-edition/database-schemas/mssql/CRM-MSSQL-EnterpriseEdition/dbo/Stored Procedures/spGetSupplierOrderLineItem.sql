CREATE PROCEDURE [dbo].[spGetSupplierOrderLineItem]
	@supplierOrderLineItemId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Supplier Order Id],
			[Supplier Order Line Item Id],
			[Supplier Order Line Item Status Id],
			[Supplier Order Line Item Status],
			[Product Id],
			[Product Name],
			[Wholesale Price Per Unit],
			[Wholesale Carton Quantity],
			[Wholesale Unit Quantity Per Carton],
			[Total Line Item Price],
			[Created Timestamp],
			[Created By],
			[Modified Timestamp],
			[Modified By]
			FROM [dbo].[vwSupplierOrderLineItem]
			WHERE [Supplier Order Line Item Id] = @supplierOrderLineItemId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END