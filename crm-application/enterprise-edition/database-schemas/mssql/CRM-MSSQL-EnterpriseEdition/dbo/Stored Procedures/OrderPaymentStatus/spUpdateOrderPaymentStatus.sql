CREATE PROCEDURE [dbo].[spUpdateOrderPaymentStatus]
	@activeStatus BIT,
    @companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@orderPaymentStatus NVARCHAR(50),
	@orderPaymentStatusId UNIQUEIDENTIFIER,
    @masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[OrderPaymentStatus]
			SET
                [ActiveStatus] = @activeStatus,
                [CompanyConfigurationId] = @companyConfigurationId,
				[OrderPaymentStatus] = @orderPaymentStatus,
                [MasterDataTypeId] = @masterDataTypeId
			WHERE [OrderPaymentStatusId] = @orderPaymentStatusId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
