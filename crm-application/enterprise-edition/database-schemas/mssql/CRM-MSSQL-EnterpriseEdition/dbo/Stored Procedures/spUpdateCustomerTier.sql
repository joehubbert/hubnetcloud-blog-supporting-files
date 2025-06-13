CREATE PROCEDURE [dbo].[spUpdateCustomerTier]
	@activeStatus BIT,
	@customerTier NVARCHAR(50),
	@customerTierCode NCHAR(1),
	@customerTierId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[CustomerTier]
			SET 
				[ActiveStatus] = @activeStatus,
				[CustomerTierCode] = @customerTierCode,
				[CustomerTierDescription] = @customerTier
			WHERE [CustomerTierId] = @customerTierId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END