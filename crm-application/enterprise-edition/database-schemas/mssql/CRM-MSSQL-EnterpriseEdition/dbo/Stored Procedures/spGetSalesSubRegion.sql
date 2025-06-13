CREATE PROCEDURE [dbo].[spGetSalesSubRegion]
	@salesSubRegionId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Sales Sub Region Id],
			[Sales Region Id],
			[Sales Region],
			[Sales Sub Region],
			[Active Status],
			[Created Timestamp],
			[Created By],
			[Modified Timestamp],
			[Modified By]
			FROM [dbo].[vwSalesSubRegion]
			WHERE [Sales Sub Region Id] = @salesSubRegionId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END