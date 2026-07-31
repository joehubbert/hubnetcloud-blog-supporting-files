CREATE PROCEDURE [dbo].[spGetAllMarketingCampaignType]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Marketing Campaign Type Id],
			[Master Data Type Id],
			[Master Data Type],
			[Master Data Type Code],
			[Is Custom],
			[Marketing Campaign Type],
			[Company Configuration Id],
			[Company Name],
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