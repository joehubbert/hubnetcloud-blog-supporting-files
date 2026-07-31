CREATE PROCEDURE [dbo].[spUpdateSupplierOrderPaymentStatus]
	@activeStatus BIT,
    @companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@supplierOrderPaymentStatus NVARCHAR(50),
	@supplierOrderPaymentStatusId UNIQUEIDENTIFIER,
    @masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[SupplierOrderPaymentStatus]
			SET
                [ActiveStatus] = @activeStatus,
                [CompanyConfigurationId] = @companyConfigurationId,
				[SupplierOrderPaymentStatus] = @supplierOrderPaymentStatus,
                [MasterDataTypeId] = @masterDataTypeId
			WHERE [SupplierOrderPaymentStatusId] = @supplierOrderPaymentStatusId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
