CREATE PROCEDURE [dbo].[spCompleteOrder]
    @companyConfigurationId UNIQUEIDENTIFIER,
    @paymentMethodId UNIQUEIDENTIFIER,
    @orderId UNIQUEIDENTIFIER
AS
BEGIN
    BEGIN TRY
        SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
        BEGIN TRANSACTION;

        DECLARE @orderLineItemStatusId UNIQUEIDENTIFIER;
        DECLARE @orderPaymentStatusId UNIQUEIDENTIFIER;
        DECLARE @orderPaymentId UNIQUEIDENTIFIER;
        DECLARE @totalPayment MONEY = 0;

        -- Get the 'Shipped' status ID for line items
        SELECT @orderLineItemStatusId = [OrderLineItemStatusId]
        FROM [dbo].[OrderLineItemStatus]
        WHERE [OrderLineItemStatus] = 'Shipped';

        -- Get the 'Settled' status ID for payments
        SELECT @orderPaymentStatusId = [OrderPaymentStatusId]
        FROM [dbo].[OrderPaymentStatus]
        WHERE [OrderPaymentStatus] = 'Settled';

        -- Cursor to iterate through all line items for the order
        DECLARE lineitem_cursor CURSOR FOR
            SELECT [OrderLineItemId], [LineItemTotal]
            FROM [dbo].[OrderLineItem]
            WHERE [OrderId] = @orderId;

        DECLARE @orderLineItemId UNIQUEIDENTIFIER;
        DECLARE @lineItemTotal MONEY;

        OPEN lineitem_cursor;
        FETCH NEXT FROM lineitem_cursor INTO @orderLineItemId, @lineItemTotal;

        WHILE @@FETCH_STATUS = 0
        BEGIN
            -- Mark line item as shipped
            EXEC [dbo].[spCreateOrderLineItemStatusHistory]
                @orderLineItemId = @orderLineItemId,
                @orderLineItemStatusId = @orderLineItemStatusId;

            -- Add to total payment
            SET @totalPayment = @totalPayment + @lineItemTotal;

            FETCH NEXT FROM lineitem_cursor INTO @orderLineItemId, @lineItemTotal;
        END

        CLOSE lineitem_cursor;
        DEALLOCATE lineitem_cursor;

        -- Create a single payment for the total
        EXEC [dbo].[spCreateOrderPayment]
            @orderId = @orderId,
            @orderPaymentId = @orderPaymentId OUTPUT,
            @orderPaymentStatusId = @orderPaymentStatusId,
            @paymentAmount = @totalPayment,
            @paymentMethodId = @paymentMethodId;

        -- Update company bank balance
        DECLARE @originalCompanyConfigurationBankBalance MONEY;
        SELECT @originalCompanyConfigurationBankBalance = [BankAccountBalance]
        FROM [dbo].[CompanyConfiguration]
        WHERE [CompanyConfigurationId] = @companyConfigurationId;

        DECLARE @updatedCompanyConfigurationBankBalance MONEY;
        SET @updatedCompanyConfigurationBankBalance = @originalCompanyConfigurationBankBalance + @totalPayment;

        EXEC [dbo].[spUpdateCompanyConfigurationBankBalance]
            @bankAccountBalance = @updatedCompanyConfigurationBankBalance,
            @companyConfigurationId = @companyConfigurationId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        THROW @ErrorSeverity, @ErrorMessage, @ErrorState;
    END CATCH
END