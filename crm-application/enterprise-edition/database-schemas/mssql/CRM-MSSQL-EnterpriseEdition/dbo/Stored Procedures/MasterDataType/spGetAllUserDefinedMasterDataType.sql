CREATE PROCEDURE [dbo].[spGetAllUserDefinedMasterDataType]
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
			WHERE [User Defined] = 1

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END