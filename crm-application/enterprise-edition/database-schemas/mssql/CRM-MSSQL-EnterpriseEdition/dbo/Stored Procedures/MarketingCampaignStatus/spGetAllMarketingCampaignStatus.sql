CREATE PROCEDURE [dbo].[spGetAllMarketingCampaignStatus]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Marketing Campaign Status Id],
			[Marketing Campaign Status],
			[Active Status]
			FROM [dbo].[vwMarketingCampaignStatus]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END