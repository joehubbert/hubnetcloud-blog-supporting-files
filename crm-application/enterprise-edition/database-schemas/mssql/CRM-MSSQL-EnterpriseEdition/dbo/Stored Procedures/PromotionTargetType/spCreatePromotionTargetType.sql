CREATE PROCEDURE [dbo].[spCreatePromotionTargetType]
	@activeStatus BIT,
	@promotionTargetType NVARCHAR(50),
	@promotionTargetTypeDescription NVARCHAR(255) = NULL
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #PromotionTargetTypeTemp
			(
				[PromotionTargetType] NVARCHAR(50) NOT NULL,
				[PromotionTargetTypeDescription] NVARCHAR(255) NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #PromotionTargetTypeTemp
			(
				[PromotionTargetType],
				[PromotionTargetTypeDescription],
				[ActiveStatus]
			)
			VALUES
			(
				@promotionTargetType,
				@promotionTargetTypeDescription,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[PromotionTargetType] PTT
				INNER JOIN #PromotionTargetTypeTemp PTTT ON PTT.[PromotionTargetType] = PTTT.[PromotionTargetType]
				WHERE PTT.[PromotionTargetType] = PTTT.[PromotionTargetType]
			)
			THROW 50000, 'Promotion Target Type already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[PromotionTargetType] AS target
			USING #PromotionTargetTypeTemp AS source
			ON target.[PromotionTargetType] = source.[PromotionTargetType]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[PromotionTargetType],
				[PromotionTargetTypeDescription],
				[ActiveStatus]
			)
			VALUES
			(
				source.[PromotionTargetType],
				source.[PromotionTargetTypeDescription],
				source.[ActiveStatus]
			);

			DROP TABLE #PromotionTargetTypeTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END