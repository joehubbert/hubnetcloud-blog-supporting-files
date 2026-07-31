CREATE PROCEDURE [dbo].[spUpdateWholesaleDeliveryType]
	@activeStatus BIT,
    @companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@wholesaleDeliveryType NVARCHAR(50),
	@wholesaleDeliveryTypeId UNIQUEIDENTIFIER,
    @masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[WholesaleDeliveryType]
			SET
                [ActiveStatus] = @activeStatus,
                [CompanyConfigurationId] = @companyConfigurationId,
				[WholesaleDeliveryType] = @wholesaleDeliveryType,
                [MasterDataTypeId] = @masterDataTypeId
			WHERE [WholesaleDeliveryTypeId] = @wholesaleDeliveryTypeId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
