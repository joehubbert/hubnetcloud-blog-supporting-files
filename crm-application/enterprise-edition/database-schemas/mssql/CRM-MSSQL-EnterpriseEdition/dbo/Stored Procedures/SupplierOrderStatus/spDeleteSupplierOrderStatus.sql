CREATE PROCEDURE [dbo].[spDeleteSupplierOrderStatus]
	@supplierOrderStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

        DELETE E
        FROM [dbo].[SupplierOrderStatus] E
        INNER JOIN [dbo].[MasterDataType] MDT ON E.[MasterDataTypeId] = MDT.[MasterDataTypeId]
        WHERE E.[SupplierOrderStatusId] = @supplierOrderStatusId
        AND MDT.[IsCustom] = 1

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
