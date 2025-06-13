CREATE PROCEDURE [dbo].[spCompleteOrderLineItem]
	@companyConfigurationId UNIQUEIDENTIFIER,
	@paymentMethodId UNIQUEIDENTIFIER,
	@orderLineItemId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			BEGIN TRY
			-- Declare variables to hold product information
			DECLARE @lineItemTotal MONEY
			DECLARE @orderId UNIQUEIDENTIFIER
			DECLARE @orderLineItemStatusId UNIQUEIDENTIFIER
			DECLARE @orderPaymentId UNIQUEIDENTIFIER
			DECLARE @orderPaymentStatusId UNIQUEIDENTIFIER

			SELECT @orderLineItemStatusId = [OrderLineItemStatusId] FROM [dbo].[OrderLineItemStatus] WHERE [OrderLineItemStatus] = 'Shipped'

			EXEC [dbo].[spCreateOrderLineItemStatusHistory]
				@orderLineItemId = @orderLineItemId,
				@orderLineItemStatusId = @orderLineItemStatusId

			-- Retrieve order line item information
			SELECT @lineItemTotal = [LineItemTotal],
			@orderId = [OrderId]
			FROM [dbo].[OrderLineItem]
			WHERE [OrderLineItemId] = @orderLineItemId

			SELECT @orderPaymentStatusId = [OrderPaymentStatusId] FROM [dbo].[OrderPaymentStatus] WHERE [OrderPaymentStatus] = 'Settled'

			EXEC [dbo].[spCreateOrderPayment]
			@orderId = @orderId,
			@orderPaymentId = @orderPaymentId OUTPUT,
			@orderPaymentStatusId = @orderPaymentStatusId,
			@paymentAmount = @lineItemTotal,
			@paymentMethodId = @paymentMethodId

			DECLARE @originalCompanyConfigurationBankBalance MONEY
			SELECT @originalCompanyConfigurationBankBalance = [BankAccountBalance] FROM [dbo].[CompanyConfiguration] WHERE [CompanyConfigurationId] = @companyConfigurationId

			DECLARE @updatedCompanyConfigurationBankBalance MONEY
			SET @updatedCompanyConfigurationBankBalance = @originalCompanyConfigurationBankBalance + @lineItemTotal

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