CREATE PROCEDURE [dbo].[spGetAllSupplierOrder]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Supplier Order Id],
			[Supplier Order Internal Reference],
			[Supplier Id],
			[Supplier Name],
			[Supplier Order Status],
			[Payment Method],
			[Total Order Value],
			[Currency Code],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwSupplierOrder]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END