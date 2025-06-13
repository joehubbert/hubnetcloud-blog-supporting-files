CREATE PROCEDURE [dbo].[spCompleteSupplierOrderLineItem]
	@companyConfigurationId UNIQUEIDENTIFIER,
	@paymentMethodId UNIQUEIDENTIFIER,
	@supplierOrderLineItemId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			BEGIN TRY
			-- Declare variables to hold product and productsupplier information
			DECLARE @lineItemTotal MONEY
			DECLARE @supplierOrderId UNIQUEIDENTIFIER
			DECLARE @supplierOrderLineItemStatusId UNIQUEIDENTIFIER
			DECLARE @supplierOrderPaymentId UNIQUEIDENTIFIER
			DECLARE @supplierOrderPaymentStatusId UNIQUEIDENTIFIER

			SELECT @supplierOrderLineItemStatusId = [SupplierOrderLineItemStatusId]
			FROM [dbo].[SupplierOrderLineItemStatus]
			WHERE [SupplierOrderLineItemStatus] = 'Delivered'

			EXEC [dbo].[spCreateSupplierOrderLineItemStatusHistory]
				@supplierOrderLineItemId = @supplierOrderLineItemId,
				@supplierOrderLineItemStatusId = @supplierOrderLineItemStatusId

			-- Retrieve supplier order line item information
			SELECT @lineItemTotal = [LineItemTotal],
			@supplierOrderId = [SupplierOrderId]
			FROM [dbo].[SupplierOrderLineItem]
			WHERE [SupplierOrderLineItemId] = @supplierOrderLineItemId

			SELECT @supplierOrderPaymentStatusId = [SupplierOrderPaymentStatusId]
			FROM [dbo].[SupplierOrderPaymentStatus]
			WHERE [SupplierOrderPaymentStatus] = 'Settled'

			EXEC [dbo].[spCreateSupplierOrderPayment]
			@supplierOrderId = @supplierOrderId,
			@supplierOrderPaymentId = @supplierOrderPaymentId OUTPUT,
			@supplierOrderPaymentStatusId = @supplierOrderPaymentStatusId,
			@paymentAmount = @lineItemTotal,
			@paymentMethodId = @paymentMethodId

			DECLARE @originalCompanyConfigurationBankBalance MONEY
			SELECT @originalCompanyConfigurationBankBalance = [BankAccountBalance]
			FROM [dbo].[CompanyConfiguration]
			WHERE [CompanyConfigurationId] = @companyConfigurationId

			DECLARE @updatedCompanyConfigurationBankBalance MONEY
			SET @updatedCompanyConfigurationBankBalance = @originalCompanyConfigurationBankBalance - @lineItemTotal

			EXEC [dbo].[spUpdateCompanyConfigurationBankBalance]
				@bankAccountBalance = @updatedCompanyConfigurationBankBalance,
				@companyConfigurationId = @companyConfigurationId

			END TRY
			BEGIN CATCH
			-- Handle any errors that occur during the transaction
			DECLARE @ErrorMessage NVARCHAR(4000);
			DECLARE @ErrorSeverity INT;
			DECLARE @ErrorState INT;

			SELECT 
				@ErrorMessage = ERROR_MESSAGE(),
				@ErrorSeverity = ERROR_SEVERITY(),
				@ErrorState = ERROR_STATE();

			-- Rethrow the error to the caller
			THROW @ErrorSeverity, @ErrorMessage, @ErrorState
			END CATCH

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END