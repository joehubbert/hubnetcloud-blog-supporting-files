CREATE PROCEDURE [dbo].[spGetAllCustomerLead]
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
			[Customer Lead Id],
			[Customer Lead Title],
			[Customer Lead Type Id],
			[Customer Lead Type],
			[Customer Lead],
			[Customer Lead Target Date],
			[Marketing Channel Id],
			[Marketing Channel],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwCustomerLead]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END