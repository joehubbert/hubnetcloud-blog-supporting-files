CREATE PROCEDURE [dbo].[spUpdatePaymentMethod]
	@activeStatus BIT,
    @companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@paymentMethod NVARCHAR(50),
	@paymentMethodId UNIQUEIDENTIFIER,
    @masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[PaymentMethod]
			SET
                [ActiveStatus] = @activeStatus,
                [CompanyConfigurationId] = @companyConfigurationId,
				[PaymentMethod] = @paymentMethod,
                [MasterDataTypeId] = @masterDataTypeId
			WHERE [PaymentMethodId] = @paymentMethodId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
