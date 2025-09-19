CREATE PROCEDURE [dbo].[spGetMarketingChannel]
	@marketingChannelId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Marketing Channel Id],
			[Marketing Channel],
			[Active Status]
			FROM [dbo].[vwMarketingChannel]
			WHERE [Marketing Channel Id] = @marketingChannelId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END