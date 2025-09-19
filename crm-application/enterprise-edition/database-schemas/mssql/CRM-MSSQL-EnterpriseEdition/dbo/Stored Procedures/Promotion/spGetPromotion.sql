CREATE PROCEDURE [dbo].[spGetPromotion]
	@promotionId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Promotion Id],
			[Marketing Campaign Id],
			[Marketing Campaign Name],
			[Promotion Name],
			[Promotion Description],
			[Promotion Code],
			[Promotion Target Type Id],
			[Promotion Target Type],
			[Promotion Type Id],
			[Promotion Type],
			[Promotion Value],
			[Promotion Buy Quantity],
			[Promotion Get Quantity],
			[Promotion Start Timestamp UTC],
			[Promotion End Timestamp UTC],
			[Active Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwPromotion]
			WHERE [Promotion Id] = @promotionId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END