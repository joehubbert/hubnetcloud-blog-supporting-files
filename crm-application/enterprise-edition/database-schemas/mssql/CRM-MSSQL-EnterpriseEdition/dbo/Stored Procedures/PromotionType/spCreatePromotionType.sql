CREATE PROCEDURE [dbo].[spCreatePromotionType]
	@activeStatus BIT,
	@promotionType NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #PromotionTypeTemp
			(
				[PromotionType] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #PromotionTypeTemp
			(
				[PromotionType],
				[ActiveStatus]
			)
			VALUES
			(
				@promotionType,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[PromotionType] P
				INNER JOIN #PromotionTypeTemp PT ON P.[PromotionType] = PT.[PromotionType]
				WHERE P.[PromotionType] = PT.[PromotionType]
			)
			THROW 50000, 'Promotion Type already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[PromotionType] AS target
			USING #PromotionTypeTemp AS source
			ON target.[PromotionType] = source.[PromotionType]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[PromotionType],
				[ActiveStatus]
			)
			VALUES
			(
				source.[PromotionType],
				source.[ActiveStatus]
			);

			DROP TABLE #PromotionTypeTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END