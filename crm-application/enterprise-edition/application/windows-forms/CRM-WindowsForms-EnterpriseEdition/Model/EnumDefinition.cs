namespace CRM.Model
{
    public enum DataOperationType
    {
        Create,
        Delete,
        MeasurementConversion,
        Select,
        SelectNoParameter,
        Update
    }

    public enum DataSortingOrder
    {
        ASC,
        DESC
    }

    public enum DatabaseEngine
    {
        AzureDatabaseForMySQL,
        AzureDatabaseForPostgreSQL,
        AzureSQLDatabase,
        AzureSQLManagedInstance,
        MicrosoftSQLServer,
        MySQL,
        PostgreSQL
    }

    public enum  Delimeter
    {
        Comma,
        Period
    }

    public enum FunctionTitle
    {
        AccountManager,
        AssociatedCustomerToAccountManager,
        CompanyConfiguration,
        Country,
        Currency,
        CurrencyConversion,
        Customer,
        CustomerContact,
        CustomerLead,
        CustomerLeadNote,
        CustomerLeadNoteType,
        CustomerLeadStatus,
        CustomerLeadStatusHistory,
        CustomerLeadType,
        CustomerNote,
        CustomerNoteType,
        CustomerTier,
        CustomerType,
        DeliveryMethod,
        GlobalParentCustomer,
        HTMLTemplate,
        HTMLTemplateType,
        Manufacturer,
        MarketingCampaign,
        MarketingCampaignMarketingChannel,
        MarketingCampaignStatus,
        MarketingCampaignStatusHistory,
        MarketingCampaignType,
        MarketingChannel,
        Order,
        OrderInvoice,
        OrderLineItem,
        OrderLineItemDelivery,
        OrderLineItemStatus,
        OrderLineItemStatusHistory,
        OrderPayment,
        OrderPaymentStatus,
        OrderPaymentStatusHistory,
        OrderQuote,
        OrderStatus,
        OrderStatusHistory,
        OrderType,
        PaymentMethod,
        Product,
        ProductCategory,
        ProductFamily,
        ProductImage,
        ProductNote,
        ProductNoteType,
        ProductSalesSubRegion,
        ProductSubCategory,
        ProductSupplier,
        Promotion,
        PromotionManufacturer,
        PromotionManufacturerProductCategory,
        PromotionManufacturerProductSubCategory,
        PromotionProduct,
        PromotionProductCategory,
        PromotionProductFamily,
        PromotionProductSubCategory,
        PromotionSupplier,
        PromotionSupplierProductCategory,
        PromotionSupplierProductSubCategory,
        PromotionTargetType,
        PromotionType,
        SalesRegion,
        SalesSubRegion,
        Supplier,
        SupplierContact,
        SupplierNote,
        SupplierNoteType,
        SupplierOrder,
        SupplierOrderLineItem,
        SupplierOrderLineItemStatus,
        SupplierOrderLineItemStatusHistory,
        SupplierOrderPayment,
        SupplierOrderPaymentStatus,
        SupplierOrderPaymentStatusHistory,
        SupplierOrderStatus,
        SupplierOrderStatusHistory,
        TaxProfile,
        TopParentCustomer,
        WholesaleDeliveryType
    }

    public enum MeasurementType
    {
        Area,
        Distance,
        Liquid,
        Temperature,
        Volume,
        Weight
    }

    public enum MSSQLAuthenticationType
    {
        EntraId,
        SQLServer,
        Windows
    }

    public enum  MySQLAuthenticationType
    {
        EntraId,
        Native
    }

    public enum MySQLSSLMode
    {
        Disabled,
        Required,
        Preferred,
        VerifyCA,
        VerifyFull
    }

    public enum LanguageRegionCode
    {
        czCZ,
        daDK,
        deDE,
        enGB,
        esES,
        fi,
        frFR,
        itIT,
        jaJP,
        ko,
        nbNO,
        nlNL,
        plPL,
        ptPT,
        svSE,
        zh
    }

    public enum ModuleGroup
    {
        CompanyManagement,
        CustomerManagement,
        MarketingManagement,
        OrderManagement,
        ProductManagement,
        SupplierManagement
    }

    public enum PostgreSQLAuthenticationType
    {
        EntraId,
        Native
    }

    public enum PostgreSQLSSLMode
    {
        Allow,
        Disable,
        Prefer,
        Require,
        VerifyCA,
        VerifyFull
    }

    public enum UnitType
    {
        Imperial,
        Metric
    }
}