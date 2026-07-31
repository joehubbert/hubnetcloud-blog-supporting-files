CREATE PROCEDURE [dbo].[spUpdatePromotionTargetType]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@promotionTargetType NVARCHAR(50),
	@promotionTargetTypeDescription NVARCHAR(255) = NULL,
	@promotionTargetTypeId UNIQUEIDENTIFIER,
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[PromotionTargetType]
			SET 
				[ActiveStatus] = @activeStatus,
				[CompanyConfigurationId] = @companyConfigurationId,
				[PromotionTargetType] = @promotionTargetType,
				[PromotionTargetTypeDescription] = @promotionTargetTypeDescription,
				[MasterDataTypeId] = @masterDataTypeId
			WHERE [PromotionTargetTypeId] = @promotionTargetTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END