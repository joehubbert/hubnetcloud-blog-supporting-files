CREATE PROCEDURE [dbo].[spGetAllSalesSubRegion]
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
			[Active Status]
			FROM [dbo].[vwSalesSubRegion]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END