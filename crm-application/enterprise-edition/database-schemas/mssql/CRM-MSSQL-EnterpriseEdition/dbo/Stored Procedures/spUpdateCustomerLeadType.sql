CREATE PROCEDURE [dbo].[spUpdateCustomerLeadType]
	@activeStatus BIT,
	@customerLeadType NVARCHAR(50),
	@customerLeadTypeDescription NVARCHAR(255) = NULL,
	@customerLeadTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[CustomerLeadType]
			SET
				[ActiveStatus] = @activeStatus,
				[CustomerLeadType] = @customerLeadType,
				[CustomerLeadTypeDescription] = @customerLeadTypeDescription
			WHERE [CustomerLeadTypeId] = @customerLeadTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END