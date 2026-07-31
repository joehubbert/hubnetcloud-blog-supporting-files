CREATE PROCEDURE [dbo].[spUpdatePromotionType]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@promotionType NVARCHAR(50),
	@promotionTypeId UNIQUEIDENTIFIER,
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[PromotionType]
			SET
				[ActiveStatus] = @activeStatus,
				[CompanyConfigurationId] = @companyConfigurationId,
				[PromotionType] = @promotionType,
				[MasterDataTypeId] = @masterDataTypeId
			WHERE [PromotionTypeId] = @promotionTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END