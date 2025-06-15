CREATE PROCEDURE [dbo].[spUpdateCustomer]
    @accountManagerId UNIQUEIDENTIFIER,
    @activeStatus BIT,
    @companyConfigurationId UNIQUEIDENTIFIER,
    @creditEnabled BIT,
    @creditLimit MONEY,
    @customerId UNIQUEIDENTIFIER,
    @customerSince DATE,
    @customerTierId UNIQUEIDENTIFIER,
    @customerTypeId UNIQUEIDENTIFIER,
    @emailAddress NVARCHAR(50),
    @globalParentCustomer BIT,
    @globalParentCustomerId UNIQUEIDENTIFIER = NULL,
    @salesSubRegionId UNIQUEIDENTIFIER,
    @billingFirstName NVARCHAR(20),
    @billingLastName NVARCHAR(30),
    @billingCompanyName NVARCHAR(50),
    @billingAddressLine1 NVARCHAR(50),
    @billingAddressLine2 NVARCHAR(50) = NULL,
    @billingAddressLine3 NVARCHAR(50),
    @billingAddressLine4 NVARCHAR(50),
    @billingAddressLine5 UNIQUEIDENTIFIER,
    @billingTelephoneNumber NVARCHAR(50),
    @billingEmailAddress NVARCHAR(50),
    @paymentCurrencyId UNIQUEIDENTIFIER,
    @paymentDays TINYINT,
    @shippingFirstName NVARCHAR(20),
    @shippingLastName NVARCHAR(30),
    @shippingCompanyName NVARCHAR(50),
    @shippingAddressLine1 NVARCHAR(50),
    @shippingAddressLine2 NVARCHAR(50) = NULL,
    @shippingAddressLine3 NVARCHAR(50),
    @shippingAddressLine4 NVARCHAR(50),
    @shippingAddressLine5 UNIQUEIDENTIFIER,
    @shippingTelephoneNumber NVARCHAR(50),
    @shippingEmailAddress NVARCHAR(50),
    @telephoneNumber NVARCHAR(13),
    @topParentCustomer BIT,
    @topParentCustomerId UNIQUEIDENTIFIER = NULL,
    @vatNumber NVARCHAR(50) = NULL
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

            UPDATE [dbo].[Customer]
            SET 
                [AccountManagerId] = @accountManagerId,
                [ActiveStatus] = @activeStatus,
                [CompanyConfigurationId] = @companyConfigurationId,
                [CreditEnabled] = @creditEnabled,
                [CreditLimit] = @creditLimit,
                [CustomerSince] = @customerSince,
                [CustomerTierId] = @customerTierId,
                [CustomerTypeId] = @customerTypeId,
                [EmailAddress] = @emailAddress,
                [GlobalParentCustomer] = @globalParentCustomer,
                [GlobalParentCustomerId] = @globalParentCustomerId,
                [SalesSubRegionId] = @salesSubRegionId,
                [BillingFirstName] = @billingFirstName,
                [BillingLastName] = @billingLastName,
                [BillingCompanyName] = @billingCompanyName,
                [BillingAddressLine1] = @billingAddressLine1,
                [BillingAddressLine2] = @billingAddressLine2,
                [BillingAddressLine3] = @billingAddressLine3,
                [BillingAddressLine4] = @billingAddressLine4,
                [BillingAddressLine5] = @billingAddressLine5,
                [BillingTelephoneNumber] = @billingTelephoneNumber,
                [BillingEmailAddress] = @billingEmailAddress,
                [PaymentCurrencyId] = @paymentCurrencyId,
                [PaymentDays] = @paymentDays,
                [ShippingFirstName] = @shippingFirstName,
                [ShippingLastName] = @shippingLastName,
                [ShippingCompanyName] = @shippingCompanyName,
                [ShippingAddressLine1] = @shippingAddressLine1,
                [ShippingAddressLine2] = @shippingAddressLine2,
                [ShippingAddressLine3] = @shippingAddressLine3,
                [ShippingAddressLine4] = @shippingAddressLine4,
                [ShippingAddressLine5] = @shippingAddressLine5,
                [ShippingTelephoneNumber] = @shippingTelephoneNumber,
                [ShippingEmailAddress] = @shippingEmailAddress,
                [TelephoneNumber] = @telephoneNumber,
                [TopParentCustomer] = @topParentCustomer,
                [TopParentCustomerId] = @topParentCustomerId,
                [VATNumber] = @vatNumber
            WHERE [CustomerId] = @customerId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END