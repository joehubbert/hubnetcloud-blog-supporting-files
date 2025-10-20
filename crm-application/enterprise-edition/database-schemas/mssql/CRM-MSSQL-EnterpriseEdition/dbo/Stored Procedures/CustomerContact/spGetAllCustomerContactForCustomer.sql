CREATE PROCEDURE [dbo].[spGetAllCustomerContactForCustomer]
	@customerId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Customer Id],
			[Customer Contact Id],
			[Customer Contact First Name],
			[Customer Contact Last Name],
			[Customer Contact Email Address],
			[Customer Contact Telephone Number],
			[Customer Contact Role],
			[Active Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwCustomerContact]
			WHERE [Customer Id] = @customerId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END