CREATE PROCEDURE [dbo].[spGetAllSalesRegion]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Sales Region Id],
			[Sales Region],
			[Company Configuration Id],
			[Company Name],
			[Active Status]
			FROM [dbo].[vwSalesRegion]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END