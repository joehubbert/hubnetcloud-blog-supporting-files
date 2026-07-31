CREATE PROCEDURE [dbo].[spGetAllMarketingCampaignStatus]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Marketing Campaign Status Id],
			[Master Data Type Id],
			[Master Data Type],
			[Master Data Type Code],
			[Is Custom],
			[Marketing Campaign Status],
			[Company Configuration Id],
			[Company Name],
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