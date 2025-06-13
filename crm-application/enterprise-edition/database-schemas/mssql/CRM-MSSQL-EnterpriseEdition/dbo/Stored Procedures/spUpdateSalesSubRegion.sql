CREATE PROCEDURE [dbo].[spUpdateSalesSubRegion]
	@activeStatus BIT,
	@salesRegionId UNIQUEIDENTIFIER,
	@salesSubRegion NVARCHAR(50),
	@salesSubRegionId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[SalesSubRegion]
			SET 
				[ActiveStatus] = @activeStatus,
				[SalesRegionId] = @salesRegionId,
				[SalesSubRegion] = @salesSubRegion
			WHERE [SalesSubRegionId] = @salesSubRegionId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END