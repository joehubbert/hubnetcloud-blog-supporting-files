CREATE PROCEDURE [dbo].[spGetSupplierOrderLineItemStatus]
	@supplierOrderLineItemStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Supplier Order Line Item Status Id],
			[Supplier Order Line Item Status],
			[Active Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwSupplierOrderLineItemStatus]
			WHERE [Supplier Order Line Item Status Id] = @supplierOrderLineItemStatusId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END