CREATE PROCEDURE [dbo].[spGetAccountManager]
	@accountManagerId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Account Manager Id],
			[Company Configuration Id],
			[Company Name],
			[First Name],
			[Last Name],
			[Email Address],
			[Telephone Number],
			[Active Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwAccountManager]
			WHERE [Account Manager Id] = @accountManagerId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END