CREATE PROCEDURE [dbo].[spUpdateOrderLineItemStatus]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@orderLineItemStatus NVARCHAR(50),
	@orderLineItemStatusId UNIQUEIDENTIFIER,
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[OrderLineItemStatus]
			SET 
				[ActiveStatus] = @activeStatus,
				[CompanyConfigurationId] = @companyConfigurationId,
				[OrderLineItemStatus] = @orderLineItemStatus,
				[MasterDataTypeId] = @masterDataTypeId
			WHERE [OrderLineItemStatusId] = @orderLineItemStatusId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END