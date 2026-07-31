CREATE PROCEDURE [dbo].[spUpdateDeliveryMethod]
	@activeStatus BIT,
    @companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@deliveryMethod NVARCHAR(50),
	@deliveryMethodId UNIQUEIDENTIFIER,
    @masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[DeliveryMethod]
			SET 
				[ActiveStatus] = @activeStatus,
                [CompanyConfigurationId] = @companyConfigurationId,
				[DeliveryMethod] = @deliveryMethod,
                [MasterDataTypeId] = @masterDataTypeId
			WHERE [DeliveryMethodId] = @deliveryMethodId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
