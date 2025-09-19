CREATE PROCEDURE [dbo].[spGetAllProductFamily]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Product Family Id],
			[Product Family],
			[Company Configuration Id],
			[Company Name],
			[Active Status]
			FROM [dbo].[vwProductFamily]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END