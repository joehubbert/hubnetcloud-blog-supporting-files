CREATE PROCEDURE [dbo].[spGetAllSupplierOrderLineItemForSupplierOrder]
	@supplierOrderId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Supplier Order Id],
			[Supplier Order Line Item Id],
			[Product Name],
			[Wholesale Price Per Unit],
			[Wholesale Carton Quantity],
			[Wholesale Unit Quantity Per Carton]
			[Total Line Item Price],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwSupplierOrderLineItem]
			WHERE [Supplier Order Id] = @supplierOrderId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END