CREATE PROCEDURE [dbo].[spGetAllAccountManager]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Account Manager Id],
			[Company Configuration Id],
			[Company Configuration Name],
			[First Name],
			[Last Name],
			[Email Address],
			[Telephone Number],
			[Active Status]
			FROM [dbo].[vwAccountManager]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END