CREATE PROCEDURE [dbo].[spUpdateCustomerType]
	@activeStatus BIT,
	@customerType NVARCHAR(50),
	@customerTypeDescription NVARCHAR(255) = NULL,
	@customerTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[CustomerType]
			SET 
				[ActiveStatus] = @activeStatus,
				[CustomerType] = @customerType,
				[CustomerTypeDescription] = @customerTypeDescription
			WHERE [CustomerTypeId] = @customerTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END