CREATE PROCEDURE [dbo].[spGetSupplierOrderPaymentStatus]
	@supplierOrderPaymentStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Supplier Order Payment Status Id],
            [Master Data Type Id],
            [Master Data Type],
            [Master Data Type Code],
            [Is Custom],
			[Supplier Order Payment Status],
            [Company Configuration Id],
            [Company Name],
			[Active Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwSupplierOrderPaymentStatus]
			WHERE [Supplier Order Payment Status Id] = @supplierOrderPaymentStatusId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
