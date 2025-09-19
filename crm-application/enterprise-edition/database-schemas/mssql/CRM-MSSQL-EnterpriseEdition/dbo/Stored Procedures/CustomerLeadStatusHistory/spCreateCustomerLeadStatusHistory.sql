CREATE PROCEDURE [dbo].[spCreateCustomerLeadStatusHistory]
	@customerLeadId UNIQUEIDENTIFIER,
	@customerLeadStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			INSERT INTO [dbo].[CustomerLeadStatusHistory]
			(
				[CustomerLeadId],
				[CustomerLeadStatusId]
			)
			VALUES
			(
				@customerLeadId,
				@customerLeadStatusId
			)

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END