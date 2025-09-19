CREATE PROCEDURE [dbo].[spGetMarketingCampaign]
	@marketingCampaignId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Marketing Campaign Id],
			[Company Configuration Id],
			[Company Configuration Company Name],
			[Marketing Campaign Type Id],
			[Marketing Campaign Type],
			[Marketing Campaign Name],
			[Marketing Campaign Description],
			[Marketing Campaign Goal],
			[Marketing Campaign Start TimestampUTC],
			[Marketing Campaign End TimestampUTC],
			[Marketing Campaign Start Date],
			[Marketing Campaign End Date],
			[Marketing Campaign Budget],
			[Marketing Campaign Actual Cost],
			[Marketing Campaign Budget vs Actual Cost],
			[Marketing Campaign Budget vs Actual Cost Percentage],
			[Marketing Campaign Forecasted Revenue],
			[Marketing Campaign Gross Revenue],
			[Marketing Campaign Forecasted Revenue vs Gross Revenue],
			[Marketing Campaign Gross Revenue vs Net Revenue],
			[Marketing Campaign Average Order Value],
			[Active Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwMarketingCampaign]
			WHERE [Marketing Campaign Id] = @marketingCampaignId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END