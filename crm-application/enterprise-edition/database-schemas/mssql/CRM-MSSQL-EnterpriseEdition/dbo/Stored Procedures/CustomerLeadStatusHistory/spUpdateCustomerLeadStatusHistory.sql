CREATE PROCEDURE [dbo].[spUpdateCustomerLeadStatusHistory]
	@customerLeadStatusHistoryId UNIQUEIDENTIFIER,
	@customerLeadStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[CustomerLeadStatusHistory]
			SET
				[CustomerLeadStatusId] = @customerLeadStatusId
			WHERE [CustomerLeadStatusHistoryId] = @customerLeadStatusHistoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END