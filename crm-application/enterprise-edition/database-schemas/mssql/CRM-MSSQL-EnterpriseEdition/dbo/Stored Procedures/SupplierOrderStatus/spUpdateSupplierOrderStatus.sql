CREATE PROCEDURE [dbo].[spUpdateSupplierOrderStatus]
	@activeStatus BIT,
    @companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@supplierOrderStatus NVARCHAR(50),
	@supplierOrderStatusId UNIQUEIDENTIFIER,
    @masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[SupplierOrderStatus]
			SET
                [ActiveStatus] = @activeStatus,
                [CompanyConfigurationId] = @companyConfigurationId,
				[SupplierOrderStatus] = @supplierOrderStatus,
                [MasterDataTypeId] = @masterDataTypeId
			WHERE [SupplierOrderStatusId] = @supplierOrderStatusId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
