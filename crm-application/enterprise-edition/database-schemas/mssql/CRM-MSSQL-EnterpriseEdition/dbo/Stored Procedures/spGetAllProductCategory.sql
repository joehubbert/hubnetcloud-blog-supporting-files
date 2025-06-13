CREATE PROCEDURE [dbo].[spGetAllProductCategory]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Product Category Id],
			[Product Category],
			[Company Configuration Id],
			[Company Name],
			[Active Status]
			FROM [dbo].[vwProductCategory]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END