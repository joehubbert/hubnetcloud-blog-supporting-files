CREATE PROCEDURE [dbo].[spUpdatePromotion]
	@activeStatus BIT,
	@marketingCampaignId UNIQUEIDENTIFIER,
	@promotionBuyQuantity INT,
	@promotionCode NVARCHAR(15),
	@promotionDescription NVARCHAR(255),
	@promotionEndTimestampUTC DATETIME2,
	@promotionGetQuantity INT,
	@promotionId UNIQUEIDENTIFIER,
	@promotionName NVARCHAR(50),
	@promotionStartTimestampUTC DATETIME2,
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
				[PromotionEndTimestampUTC] = @promotionEndTimestampUTC,
				[PromotionGetQuantity] = @promotionGetQuantity,
				[PromotionName] = @promotionName,
				[PromotionStartTimestampUTC] = @promotionStartTimestampUTC,
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