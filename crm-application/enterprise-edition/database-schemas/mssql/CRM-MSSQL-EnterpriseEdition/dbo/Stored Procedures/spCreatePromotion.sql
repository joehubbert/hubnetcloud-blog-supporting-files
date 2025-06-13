CREATE PROCEDURE [dbo].[spCreatePromotion]
	@activeStatus BIT,
	@marketingCampaignId UNIQUEIDENTIFIER,
	@promotionBuyQuantity INT,
	@promotionCode NVARCHAR(15),
	@promotionDescription NVARCHAR(255) ,
	@promotionEndTimestamp DATETIME2 ,
	@promotionGetQuantity INT,
	@promotionId UNIQUEIDENTIFIER OUTPUT,
	@promotionName NVARCHAR(50),
	@promotionStartTimestamp DATETIME2,
	@promotionTargetTypeId UNIQUEIDENTIFIER,
	@promotionTypeId UNIQUEIDENTIFIER,
	@promotionValue DECIMAL(18, 2)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #PromotionTempOutput
			(
				[PromotionId] UNIQUEIDENTIFIER NOT NULL
			);

			INSERT INTO [dbo].[Promotion]
			(
				[MarketingCampaignId],
				[PromotionName],
				[PromotionDescription],
				[PromotionCode],
				[PromotionTargetTypeId],
				[PromotionTypeId],
				[PromotionValue],
				[PromotionBuyQuantity],
				[PromotionGetQuantity],
				[PromotionStartTimestamp],
				[PromotionEndTimestamp],
				[ActiveStatus]
			)
			OUTPUT INSERTED.[PromotionId] INTO #PromotionTempOutput
			VALUES
			(
				@marketingCampaignId,
				@promotionName,
				@promotionDescription,
				@promotionCode,
				@promotionTargetTypeId,
				@promotionTypeId,
				@promotionValue,
				@promotionBuyQuantity,
				@promotionGetQuantity,
				@promotionStartTimestamp,
				@promotionEndTimestamp,
				@activeStatus
			)

			SET @promotionId = (SELECT [PromotionId] FROM #PromotionTempOutput);
			DROP TABLE #PromotionTempOutput;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END