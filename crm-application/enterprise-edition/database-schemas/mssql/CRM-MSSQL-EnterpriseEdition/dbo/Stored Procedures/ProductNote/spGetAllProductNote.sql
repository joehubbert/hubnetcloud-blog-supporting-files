CREATE PROCEDURE [dbo].[spGetAllProductNote]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Product Note Id],
			[Product Note Title],
			[Product Note Type Id],
			[Product Note Type],
			[Product Note]
			FROM [dbo].[vwProductNote]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END