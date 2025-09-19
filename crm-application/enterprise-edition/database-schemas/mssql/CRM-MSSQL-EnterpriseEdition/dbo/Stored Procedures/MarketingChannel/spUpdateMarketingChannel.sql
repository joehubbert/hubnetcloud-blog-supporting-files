CREATE PROCEDURE [dbo].[spUpdateMarketingChannel]
	@marketingChannel NVARCHAR(50),
	@marketingChannelId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[MarketingChannel]
			SET
				[MarketingChannel] = @marketingChannel
			WHERE [MarketingChannelId] = @marketingChannelId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END