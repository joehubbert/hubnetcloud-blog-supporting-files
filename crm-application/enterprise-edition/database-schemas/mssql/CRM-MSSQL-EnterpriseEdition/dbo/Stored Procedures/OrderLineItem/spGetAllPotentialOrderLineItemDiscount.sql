CREATE PROCEDURE [dbo].[spGetAllPotentialOrderLineItemDiscount]
    @originalQuantity INT,
	@outputDiscount DECIMAL(5,2) OUTPUT,
    @outputFinalLineItemTotal MONEY OUTPUT,
    @outputFinalPrice MONEY OUTPUT,
    @outputOriginalLineItemTotal MONEY OUTPUT,
    @outputOriginalQuantity INT OUTPUT,
    @outputPromotionCode NVARCHAR(15) OUTPUT,
    @outputPromotionType NVARCHAR(50) OUTPUT,
    @outputPromotionTypeId UNIQUEIDENTIFIER OUTPUT,
    @outputSuggestedQuantity INT OUTPUT,
    @outputUnitPrice MONEY OUTPUT,
    @productId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

            SELECT
                @outputDiscount = [Discount],
                @outputOriginalQuantity = [OriginalQuantity],
                @outputSuggestedQuantity = [SuggestedQuantity],
                @outputUnitPrice = [UnitPrice],
                @outputFinalPrice = [FinalPrice],
                @outputOriginalLineItemTotal = [OriginalLineItemTotal],
                @outputFinalLineItemTotal = [FinalLineItemTotal],
                @outputPromotionCode = [PromotionCode],
                @outputPromotionType = [PromotionType],
                @outputPromotionTypeId = [PromotionTypeId]
            FROM [dbo].[fnLookupPotentialOrderLineItemDiscount](@productId, @originalQuantity)

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END