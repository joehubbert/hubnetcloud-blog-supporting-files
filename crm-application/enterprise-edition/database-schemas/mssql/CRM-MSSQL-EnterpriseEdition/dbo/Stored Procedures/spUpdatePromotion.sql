CREATE PROCEDURE [dbo].[spUpdatePromotion]
	@activeStatus BIT,
	@marketingCampaignId UNIQUEIDENTIFIER,
	@promotionBuyQuantity INT,
	@promotionCode NVARCHAR(15),
	@promotionDescription NVARCHAR(255),
	@promotionEndTimestamp DATETIME2,
	@promotionGetQuantity INT,
	@promotionId UNIQUEIDENTIFIER,
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

			UPDATE [dbo].[Promotion]
			SET
				[ActiveStatus] = @activeStatus,
				[MarketingCampaignId] = @marketingCampaignId,
				[PromotionBuyQuantity] = @promotionBuyQuantity,
				[PromotionCode] = @promotionCode,
				[PromotionDescription] = @promotionDescription,
				[PromotionEndTimestamp] = @promotionEndTimestamp,
				[PromotionGetQuantity] = @promotionGetQuantity,
				[PromotionName] = @promotionName,
				[PromotionStartTimestamp] = @promotionStartTimestamp,
				[PromotionTargetTypeId] = @promotionTargetTypeId,
				[PromotionTypeId] = @promotionTypeId,
				[PromotionValue] = @promotionValue
			WHERE [PromotionId] = @promotionId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END