CREATE PROCEDURE [dbo].[spUpdateSupplierOrderLineItemStatus]
	@activeStatus BIT,
    @companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@supplierOrderLineItemStatus NVARCHAR(50),
	@supplierOrderLineItemStatusId UNIQUEIDENTIFIER,
    @masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[SupplierOrderLineItemStatus]
			SET
                [ActiveStatus] = @activeStatus,
                [CompanyConfigurationId] = @companyConfigurationId,
				[SupplierOrderLineItemStatus] = @supplierOrderLineItemStatus,
                [MasterDataTypeId] = @masterDataTypeId
			WHERE [SupplierOrderLineItemStatusId] = @supplierOrderLineItemStatusId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
