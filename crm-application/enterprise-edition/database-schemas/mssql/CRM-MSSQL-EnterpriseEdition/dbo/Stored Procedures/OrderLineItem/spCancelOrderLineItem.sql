CREATE PROCEDURE [dbo].[spCancelOrderLineItem]
	@orderLineItemId UNIQUEIDENTIFIER
AS

BEGIN TRY
	SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
	BEGIN TRANSACTION
	BEGIN

	DECLARE @companyConfigurationId UNIQUEIDENTIFIER
	SET @companyConfigurationId = (
		SELECT CC.[CompanyConfigurationId]
		FROM [dbo].[CompanyConfiguration] CC
		INNER JOIN [dbo].[Customer] C ON C.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
		INNER JOIN [dbo].[Order] O ON O.[CustomerId] = C.[CustomerId]
		INNER JOIN [dbo].[OrderLineItem] OLI ON OLI.[OrderId] = O.[OrderId]
		WHERE OLI.[OrderLineItemId] = @orderLineItemId
	)

	DECLARE @orderLineItemStatusId UNIQUEIDENTIFIER
	SET @orderLineItemStatusId = (SELECT [OrderLineItemStatusId] FROM [dbo].[OrderLineItemStatus] WHERE [OrderLineItemStatus] = 'Cancelled')

	DECLARE @orderPaymentStatusId UNIQUEIDENTIFIER
	SET @orderPaymentStatusId = (SELECT [OrderPaymentStatusId] FROM [dbo].[OrderPaymentStatus] WHERE [OrderPaymentStatus] = 'Partially Refunded')

	DECLARE @originalLineItemAmount MONEY
    SET @originalLineItemAmount = (
        SELECT [LineItemTotal]
        FROM [dbo].[OrderLineItem]
        WHERE [OrderLineItemId] = @orderLineItemId
    )

	DECLARE @orderId UNIQUEIDENTIFIER
    SET @orderId = (
        SELECT [OrderId]
        FROM [dbo].[OrderLineItem]
        WHERE [OrderLineItemId] = @orderLineItemId
    )

	DECLARE @originalOrderPaymentMethodId UNIQUEIDENTIFIER
	SET @originalOrderPaymentMethodId = (
		SELECT TOP 1 [PaymentMethodId]
		FROM [dbo].[OrderPayment]
		WHERE [OrderId] = @orderId
		ORDER BY [CreatedTimestampUTC] ASC
	)

	-- Update OrderLineItem status to 'Cancelled'
        EXEC [dbo].[spCreateOrderLineItemStatusHistory]
        @orderLineItemId = @orderLineItemId,
        @orderLineItemStatusId = @orderLineItemStatusId

	-- Adjust quantities in the Product table
		UPDATE P
		SET P.[UnitStockQuantityHeld] = P.[UnitStockQuantityHeld] + OLI.[Quantity]
		FROM [dbo].[Product] P
		INNER JOIN [dbo].[OrderLineItem] OLI ON P.[ProductId] = OLI.[ProductId]

	-- Create refund payment
		DECLARE @refundPaymentAmount MONEY
		SET @refundPaymentAmount = @originalLineItemAmount * -1

		DECLARE @refundPaymentId UNIQUEIDENTIFIER

		EXEC [dbo].[spCreateOrderPayment]
			@orderId = @orderId,
			@orderPaymentId = @refundPaymentId OUTPUT,
			@orderPaymentStatusId = @orderPaymentStatusId,
			@paymentAmount = @refundPaymentAmount,
			@paymentMethodId = @originalOrderPaymentMethodId

		DECLARE @originalCompanyConfigurationBankBalance MONEY
		SELECT @originalCompanyConfigurationBankBalance = [BankAccountBalance] FROM [dbo].[CompanyConfiguration] WHERE [CompanyConfigurationId] = @companyConfigurationId

		DECLARE @updatedCompanyConfigurationBankBalance MONEY
		SET @updatedCompanyConfigurationBankBalance = @originalCompanyConfigurationBankBalance + @refundPaymentAmount

		EXEC [dbo].[spUpdateCompanyConfigurationBankBalance]
			@bankAccountBalance = @updatedCompanyConfigurationBankBalance,
			@companyConfigurationId = @companyConfigurationId

		EXEC [dbo].[spCreateOrderPaymentStatusHistory]
			@orderPaymentId = @refundPaymentId,
			@orderPaymentStatusId = @orderPaymentStatusId
	END
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
		-- Handle any errors that occur during the transaction
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION

		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

		-- Rethrow the error to the caller
		THROW @ErrorSeverity, @ErrorMessage, @ErrorState;
END CATCH