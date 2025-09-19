CREATE PROCEDURE [dbo].[spCancelOrder]
	@orderId UNIQUEIDENTIFIER
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
		WHERE O.[OrderId] = @orderId
	)

	DECLARE @orderLineItemStatusId UNIQUEIDENTIFIER
	SET @orderLineItemStatusId = (SELECT [OrderLineItemStatusId] FROM [dbo].[OrderLineItemStatus] WHERE [OrderLineItemStatus] = 'Cancelled')

	DECLARE @orderPaymentStatusId UNIQUEIDENTIFIER
	SET @orderPaymentStatusId = (SELECT [OrderPaymentStatusId] FROM [dbo].[OrderPaymentStatus] WHERE [OrderPaymentStatus] = 'Refunded')

	DECLARE @orderStatusId UNIQUEIDENTIFIER
	SET @orderStatusId = (SELECT [OrderStatusId] FROM [dbo].[OrderStatus] WHERE [OrderStatus] =  'Cancelled')

	DECLARE @originalOrderPaymentAmount MONEY
    SET @originalOrderPaymentAmount = (
        SELECT TOP 1 [PaymentAmount]
        FROM [dbo].[OrderPayment]
        WHERE [OrderId] = @orderId
        ORDER BY [CreatedTimestampUTC] ASC
    )

	DECLARE @originalOrderPaymentMethodId UNIQUEIDENTIFIER
	SET @originalOrderPaymentMethodId = (
		SELECT TOP 1 [PaymentMethodId]
		FROM [dbo].[OrderPayment]
		WHERE [OrderId] = @orderId
		ORDER BY [CreatedTimestampUTC] ASC
	)

	-- Get order line items for the order
		CREATE TABLE #OrderLineItemTemp
		(
			[OrderLineItemId] UNIQUEIDENTIFIER NOT NULL
		)
		INSERT INTO #OrderLineItemTemp
		SELECT 
		[OrderLineItemId]
		FROM [dbo].[OrderLineItem] OLI
		WHERE OLI.[OrderId] = @orderId

	-- Update OrderLineItem status to 'Cancelled'
        -- Loop over each row in #OrderLineItemTemp and execute spCreateOrderLineItemStatusHistory
        DECLARE @orderLineItemId UNIQUEIDENTIFIER

        DECLARE orderLineItem_cursor CURSOR FOR
        SELECT [OrderLineItemId] FROM #OrderLineItemTemp

        OPEN orderLineItem_cursor
        FETCH NEXT FROM orderLineItem_cursor INTO @orderLineItemId

        WHILE @@FETCH_STATUS = 0
        BEGIN
        EXEC [dbo].[spCreateOrderLineItemStatusHistory]
        @orderLineItemId = @orderLineItemId,
        @orderLineItemStatusId = @orderLineItemStatusId

        FETCH NEXT FROM orderLineItem_cursor INTO @orderLineItemId
        END

        CLOSE orderLineItem_cursor
        DEALLOCATE orderLineItem_cursor

	-- Adjust quantities in the Product table
		UPDATE P
		SET P.[UnitStockQuantityHeld] = P.[UnitStockQuantityHeld] + OLI.[Quantity]
		FROM [dbo].[Product] P
		INNER JOIN [dbo].[OrderLineItem] OLI ON P.[ProductId] = OLI.[ProductId]
		WHERE OLI.[OrderId] = @orderId

	-- Update Order status
		EXEC [dbo].[spCreateOrderStatusHistory]
			@orderId = @orderId,
			@orderStatusId = @orderStatusId

	-- Create refund payment
		DECLARE @refundPaymentAmount MONEY
		SET @refundPaymentAmount = @originalOrderPaymentAmount * -1

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

	    DROP TABLE #OrderLineItemTemp
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