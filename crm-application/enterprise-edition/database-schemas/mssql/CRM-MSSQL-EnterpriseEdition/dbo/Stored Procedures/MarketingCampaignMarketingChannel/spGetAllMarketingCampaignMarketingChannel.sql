CREATE PROCEDURE [dbo].[spGetAllMarketingCampaignMarketingChannel]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Marketing Campaign Marketing Channel Id],
			[Marketing Campaign Id],
			[Marketing Campaign Name],
			[Marketing Channel Id],
			[Marketing Channel],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwMarketingCampaignMarketingChannel]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END