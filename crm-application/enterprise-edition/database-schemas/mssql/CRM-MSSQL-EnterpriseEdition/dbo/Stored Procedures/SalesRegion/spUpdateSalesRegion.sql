CREATE PROCEDURE [dbo].[spUpdateSalesRegion]
	@activeStatus BIT,
	@salesRegion NVARCHAR(50),
	@salesRegionId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[SalesRegion]
			SET 
				[ActiveStatus] = @activeStatus,
				[SalesRegion] = @salesRegion
			WHERE [SalesRegionId] = @salesRegionId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END