CREATE PROCEDURE [dbo].[spGetAllSystemDefinedMasterDataType]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Master Data Type Id],
			[Master Data Type],
			[System Defined],
			[User Defined],
			[Active Status]
			FROM [dbo].[vwMasterDataType]
			WHERE [System Defined] = 1

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END