CREATE PROCEDURE [dbo].[spGetCustomerLead]
	@customerLeadId UNIQUEIDENTIFIER
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
			[Created Timestamp],
			[Created By],
			[Modified Timestamp],
			[Modified By]
			FROM [dbo].[vwCustomerLead]
			WHERE [Customer Lead Id] = @customerLeadId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END