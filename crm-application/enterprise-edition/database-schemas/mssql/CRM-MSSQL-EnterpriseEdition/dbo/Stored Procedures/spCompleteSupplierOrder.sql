CREATE PROCEDURE [dbo].[spCompleteSupplierOrder]
    @companyConfigurationId UNIQUEIDENTIFIER,
    @paymentMethodId UNIQUEIDENTIFIER,
    @supplierOrderId UNIQUEIDENTIFIER
AS
BEGIN
    BEGIN TRY
        SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
        BEGIN TRANSACTION;

        DECLARE @supplierOrderLineItemStatusId UNIQUEIDENTIFIER;
        DECLARE @supplierOrderPaymentStatusId UNIQUEIDENTIFIER;
        DECLARE @supplierOrderPaymentId UNIQUEIDENTIFIER;
        DECLARE @totalPayment MONEY = 0;

        -- Get the 'Delivered' status ID for line items
        SELECT @supplierOrderLineItemStatusId = [SupplierOrderLineItemStatusId]
        FROM [dbo].[SupplierOrderLineItemStatus]
        WHERE [SupplierOrderLineItemStatus] = 'Delivered';

        -- Get the 'Settled' status ID for payments
        SELECT @supplierOrderPaymentStatusId = [SupplierOrderPaymentStatusId]
        FROM [dbo].[SupplierOrderPaymentStatus]
        WHERE [SupplierOrderPaymentStatus] = 'Settled';

        -- Cursor to iterate through all line items for the order
        DECLARE lineitem_cursor CURSOR FOR
            SELECT [SupplierOrderLineItemId], [LineItemTotal]
            FROM [dbo].[SupplierOrderLineItem]
            WHERE [SupplierOrderId] = @supplierOrderId;

        DECLARE @supplierOrderLineItemId UNIQUEIDENTIFIER;
        DECLARE @lineItemTotal MONEY;

        OPEN lineitem_cursor;
        FETCH NEXT FROM lineitem_cursor INTO @supplierOrderLineItemId, @lineItemTotal;

        WHILE @@FETCH_STATUS = 0
        BEGIN
            -- Mark line item as delivered
            EXEC [dbo].[spCreateSupplierOrderLineItemStatusHistory]
                @supplierOrderLineItemId = @supplierOrderLineItemId,
                @supplierOrderLineItemStatusId = @supplierOrderLineItemStatusId;

            -- Add to total payment
            SET @totalPayment = @totalPayment + @lineItemTotal;

            FETCH NEXT FROM lineitem_cursor INTO @supplierOrderLineItemId, @lineItemTotal;
        END

        CLOSE lineitem_cursor;
        DEALLOCATE lineitem_cursor;

        -- Create a single payment for the total
        EXEC [dbo].[spCreateSupplierOrderPayment]
            @supplierOrderId = @supplierOrderId,
            @supplierOrderPaymentId = @supplierOrderPaymentId OUTPUT,
            @supplierOrderPaymentStatusId = @supplierOrderPaymentStatusId,
            @paymentAmount = @totalPayment,
            @paymentMethodId = @paymentMethodId;

        -- Update company bank balance
        DECLARE @originalCompanyConfigurationBankBalance MONEY;
        SELECT @originalCompanyConfigurationBankBalance = [BankAccountBalance]
        FROM [dbo].[CompanyConfiguration]
        WHERE [CompanyConfigurationId] = @companyConfigurationId;

        DECLARE @updatedCompanyConfigurationBankBalance MONEY;
        SET @updatedCompanyConfigurationBankBalance = @originalCompanyConfigurationBankBalance - @totalPayment;

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
