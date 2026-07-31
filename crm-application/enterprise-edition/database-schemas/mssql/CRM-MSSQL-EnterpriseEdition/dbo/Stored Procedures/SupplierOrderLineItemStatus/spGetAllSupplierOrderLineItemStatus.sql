CREATE PROCEDURE [dbo].[spGetAllSupplierOrderLineItemStatus]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Supplier Order Line Item Status Id],
            [Master Data Type Id],
            [Master Data Type],
            [Master Data Type Code],
            [Is Custom],
			[Supplier Order Line Item Status],
            [Company Configuration Id],
            [Company Name],
			[Active Status]
			FROM [dbo].[vwSupplierOrderLineItemStatus]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
