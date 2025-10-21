CREATE PROCEDURE [dbo].[spGetAllDeploymentLog]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Deployment Log Id],
			[Database Version],
			[Created Timestamp UTC],
			[Created By]
			FROM [dbo].[vwDeploymentLog]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END