CREATE PROCEDURE [dbo].[spUpdateOrderStatus]
	@activeStatus BIT,
    @companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@orderStatus NVARCHAR(50),
	@orderStatusId UNIQUEIDENTIFIER,
    @masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[OrderStatus]
			SET
                [ActiveStatus] = @activeStatus,
                [CompanyConfigurationId] = @companyConfigurationId,
				[OrderStatus] = @orderStatus,
                [MasterDataTypeId] = @masterDataTypeId
			WHERE [OrderStatusId] = @orderStatusId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
