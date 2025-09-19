CREATE PROCEDURE [dbo].[spGetCustomerLeadStatus]
	@customerLeadStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Customer Lead Status Id],
			[Customer Lead Status],
			[Active Status]
			FROM [dbo].[vwCustomerLeadStatus]
			WHERE [Customer Lead Status Id] = @customerLeadStatusId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END