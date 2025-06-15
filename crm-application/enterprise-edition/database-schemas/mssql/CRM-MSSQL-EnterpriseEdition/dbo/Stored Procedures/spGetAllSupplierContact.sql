CREATE PROCEDURE [dbo].[spGetAllSupplierContact]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Supplier Id],
			[Supplier Contact Id],
			[Supplier Contact First Name],
			[Supplier Contact Last Name],
			[Supplier Contact Email Address],
			[Supplier Contact Telephone Number],
			[Supplier Contact Role],
			[Active Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwSupplierContact]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END