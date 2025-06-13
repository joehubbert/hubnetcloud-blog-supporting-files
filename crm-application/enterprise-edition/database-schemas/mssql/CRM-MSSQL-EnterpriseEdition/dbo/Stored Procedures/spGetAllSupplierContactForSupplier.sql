CREATE PROCEDURE [dbo].[spGetAllSupplierContactForSupplier]
	@supplierId UNIQUEIDENTIFIER
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
			[Created Timestamp],
			[Created By],
			[Modified Timestamp],
			[Modified By]
			FROM [dbo].[vwSupplierContact]
			WHERE [Supplier Id] = @supplierId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END