CREATE PROCEDURE [dbo].[spUpdateTaxProfile]
	@activeStatus BIT,
	@taxProfile NVARCHAR(50),
	@taxProfileId UNIQUEIDENTIFIER,
	@taxRate DECIMAL(5, 2)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[TaxProfile]
			SET 
				[ActiveStatus] = @activeStatus,
				[TaxProfile] = @taxProfile,
				[TaxRate] = @taxRate
			WHERE [TaxProfileId] = @taxProfileId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END