CREATE PROCEDURE [dbo].[spGetAllPromotionTargetType]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Promotion Target Type Id],
			[Promotion Target Type],
			[Promotion Target Type Description],
			[Active Status]
			FROM [dbo].[vwPromotionTargetType]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END