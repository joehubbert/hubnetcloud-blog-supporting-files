CREATE PROCEDURE [dbo].[spUpdateCustomerLeadStatus]
	@activeStatus BIT,
	@customerLeadStatus NVARCHAR(50),
	@customerLeadStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[CustomerLeadStatus]
			SET 
				[ActiveStatus] = @activeStatus,
				[CustomerLeadStatus] = @customerLeadStatus
			WHERE [CustomerLeadStatusId] = @customerLeadStatusId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END