CREATE PROCEDURE [dbo].[spGetAllSupplierOrderLineItem]
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
			[Created Timestamp],
			[Created By],
			[Modified Timestamp],
			[Modified By]
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