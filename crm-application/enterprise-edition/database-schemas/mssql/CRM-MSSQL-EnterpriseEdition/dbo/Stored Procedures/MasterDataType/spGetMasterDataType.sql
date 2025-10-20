CREATE PROCEDURE [dbo].[spGetMasterDataType]
	@masterDataTypeId UNIQUEIDENTIFIER
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
			[Active Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwMasterDataType]
			WHERE [Master Data Type Id] = @masterDataTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END