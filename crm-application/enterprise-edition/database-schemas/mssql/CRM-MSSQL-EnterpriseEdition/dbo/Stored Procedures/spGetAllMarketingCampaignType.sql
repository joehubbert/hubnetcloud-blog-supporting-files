CREATE PROCEDURE [dbo].[spGetAllMarketingCampaignType]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Marketing Campaign Type Id],
			[Marketing Campaign Type],
			[Active Status]
			FROM [dbo].[vwMarketingCampaignType]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END