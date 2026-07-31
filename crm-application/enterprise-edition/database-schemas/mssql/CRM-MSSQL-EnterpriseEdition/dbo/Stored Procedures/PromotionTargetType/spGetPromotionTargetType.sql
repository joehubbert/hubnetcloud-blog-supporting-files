CREATE PROCEDURE [dbo].[spGetPromotionTargetType]
	@promotionTargetTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Promotion Target Type Id],
			[Master Data Type Id],
			[Master Data Type],
			[Master Data Type Code],
			[Is Custom],
			[Promotion Target Type],
			[Promotion Target Type Description],
			[Company Configuration Id],
			[Company Name],
			[Active Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwPromotionTargetType]
			WHERE [Promotion Target Type Id] = @promotionTargetTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END