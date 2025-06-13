CREATE PROCEDURE [dbo].[spGetAllActivePromotion]
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
			[Promotion Start Timestamp],
			[Promotion End Timestamp],
			[Active Status],
			[Created Timestamp],
			[Created By],
			[Modified Timestamp],
			[Modified By]
			FROM [dbo].[vwActivePromotion]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END