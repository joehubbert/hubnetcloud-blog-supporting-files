namespace CRM.Model
{
    public class UIModel
    {
        public List<DataSubjectModel> DataSubjects { get; set; } = new List<DataSubjectModel>
        {
            // Account Manager
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.AccountManager,
                DataSubjectCreateStoredProcedureName = "spCreateAccountManager",
                DataSubjectDeleteStoredProcedureName = "spDeleteAccountManager",
                DataSubjectFriendlyName = "Account Manager",
                DataSubjectIdFriendlyName = "Account Manager Id",
                DataSubjectIdName = "AccountManagerId",
                DataSubjectPlural = "Account Managers",
                DataSubjectSelectAllStoredProcedureName = "spGetAllAccountManager",
                DataSubjectSelectStoredProcedureName = "spGetAccountManager",
                DataSubjectUpdateStoredProcedureName = "spUpdateAccountManager",
                DataSubjectUpdateStoredProcedureParameter = "accountManagerId"
            },
            // Company Configuration
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.CompanyConfiguration,
                DataSubjectCreateStoredProcedureName = "spCreateCompanyConfiguration",
                DataSubjectDeleteStoredProcedureName = "spDeleteCompanyConfiguration",
                DataSubjectFriendlyName = "Company Configuration",
                DataSubjectIdFriendlyName = "Company Configuration Id",
                DataSubjectIdName = "CompanyConfigurationId",
                DataSubjectPlural = "Company Configurations",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCompanyConfiguration",
                DataSubjectSelectStoredProcedureName = "spGetCompanyConfiguration",
                DataSubjectUpdateStoredProcedureName = "spUpdateCompanyConfiguration",
                DataSubjectUpdateStoredProcedureParameter = "companyConfigurationId"
            },
            // Country
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.Country,
                DataSubjectCreateStoredProcedureName = "spCreateCountry",
                DataSubjectDeleteStoredProcedureName = "spDeleteCountry",
                DataSubjectFriendlyName = "Country",
                DataSubjectIdFriendlyName = "Country Id",
                DataSubjectIdName = "CountryId",
                DataSubjectPlural = "Countries",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCountry",
                DataSubjectSelectStoredProcedureName = "spGetCountry",
                DataSubjectUpdateStoredProcedureName = "spUpdateCountry",
                DataSubjectUpdateStoredProcedureParameter = "countryId"
            },
            // Currency
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.Currency,
                DataSubjectCreateStoredProcedureName = "spCreateCurrency",
                DataSubjectDeleteStoredProcedureName = "spDeleteCurrency",
                DataSubjectFriendlyName = "Currency",
                DataSubjectIdFriendlyName = "Currency Id",
                DataSubjectIdName = "CurrencyId",
                DataSubjectPlural = "Currencies",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCurrency",
                DataSubjectSelectStoredProcedureName = "spGetCurrency",
                DataSubjectUpdateStoredProcedureName = "spUpdateCurrency",
                DataSubjectUpdateStoredProcedureParameter = "currencyId"
            },
            // Currency Conversion
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.CurrencyConversion,
                DataSubjectCreateStoredProcedureName = "spCreateCurrencyConversion",
                DataSubjectDeleteStoredProcedureName = "spDeleteCurrencyConversion",
                DataSubjectFriendlyName = "Currency Conversion",
                DataSubjectIdFriendlyName = "Currency Conversion Id",
                DataSubjectIdName = "CurrencyConversionId",
                DataSubjectPlural = "Currency Conversions",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCurrencyConversion",
                DataSubjectSelectStoredProcedureName = "spGetCurrencyConversion",
                DataSubjectUpdateStoredProcedureName = "spUpdateCurrencyConversion",
                DataSubjectUpdateStoredProcedureParameter = "currencyConversionId"
            },
            // Customer
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.Customer,
                DataSubjectCreateStoredProcedureName = "spCreateCustomer",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomer",
                DataSubjectFriendlyName = "Customer",
                DataSubjectIdFriendlyName = "Customer Id",
                DataSubjectIdName = "CustomerId",
                DataSubjectPlural = "Customers",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCustomer",
                DataSubjectSelectStoredProcedureName = "spGetCustomer",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomer",
                DataSubjectUpdateStoredProcedureParameter = "customerId"
            },
            // Customer Contact
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Customer,
                DataSubject = FunctionTitle.CustomerContact,
                DataSubjectCreateStoredProcedureName = "spCreateCustomerContact",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomerContact",
                DataSubjectFriendlyName = "Customer Contact",
                DataSubjectIdFriendlyName = "Customer Contact Id",
                DataSubjectIdName = "CustomerContactId",
                DataSubjectPlural = "Customer Contacts",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCustomerContactForCustomer",
                DataSubjectSelectStoredProcedureName = "spGetCustomerContact",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomerContact",
                DataSubjectUpdateStoredProcedureParameter = "customerContactId"
            },
            // Customer Lead
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.CustomerLead,
                DataSubjectCreateStoredProcedureName = "spCreateCustomerLead",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomerLead",
                DataSubjectFriendlyName = "Customer Lead",
                DataSubjectIdFriendlyName = "Customer Lead Id",
                DataSubjectIdName = "CustomerLeadId",
                DataSubjectPlural = "Customer Leads",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCustomerLeadForCustomer",
                DataSubjectSelectStoredProcedureName = "spGetCustomerLead",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomerLead",
                DataSubjectUpdateStoredProcedureParameter = "customerLeadId"
            },
            // Customer Lead Note
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.CustomerLead,
                DataSubject = FunctionTitle.CustomerLeadNote,
                DataSubjectCreateStoredProcedureName = "spCreateCustomerLeadNote",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomerLeadNote",
                DataSubjectFriendlyName = "Customer Lead Note",
                DataSubjectIdFriendlyName = "Customer Lead Note Id",
                DataSubjectIdName = "CustomerLeadNoteId",
                DataSubjectPlural = "Customer Lead Notes",
                DataSubjectSelectAllStoredProcedureName = "spGetAllNoteForCustomerLead",
                DataSubjectSelectStoredProcedureName = "spGetCustomerLeadNote",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomerLeadNote",
                DataSubjectUpdateStoredProcedureParameter = "customerLeadNoteId"
            },
            // Customer Lead Note Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.CustomerLeadNoteType,
                DataSubjectCreateStoredProcedureName = "spCreateCustomerLeadNoteType",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomerLeadNoteType",
                DataSubjectFriendlyName = "Customer Lead Note Type",
                DataSubjectIdFriendlyName = "Customer Lead Note Type Id",
                DataSubjectIdName = "CustomerLeadNoteTypeId",
                DataSubjectPlural = "Customer Lead Note Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCustomerLeadNoteType",
                DataSubjectSelectStoredProcedureName = "spGetCustomerLeadNoteType",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomerLeadNoteType",
                DataSubjectUpdateStoredProcedureParameter = "customerLeadNoteTypeId"
            },
            // Customer Lead Status
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.CustomerLeadStatus,
                DataSubjectCreateStoredProcedureName = "spCreateCustomerLeadStatus",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomerLeadStatus",
                DataSubjectFriendlyName = "Customer Lead Status",
                DataSubjectIdFriendlyName = "Customer Lead Status Id",
                DataSubjectIdName = "CustomerLeadStatusId",
                DataSubjectPlural = "Customer Lead Statuses",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCustomerLeadStatus",
                DataSubjectSelectStoredProcedureName = "spGetCustomerLeadStatus",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomerLeadStatus",
                DataSubjectUpdateStoredProcedureParameter = "customerLeadStatusId"
            },
            // Customer Lead Status History
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.CustomerLead,
                DataSubject = FunctionTitle.CustomerLeadStatusHistory,
                DataSubjectCreateStoredProcedureName = "spCreateCustomerLeadStatusHistory",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomerLeadStatusHistory",
                DataSubjectFriendlyName = "Customer Lead Status History",
                DataSubjectIdFriendlyName = "Customer Lead Status History Id",
                DataSubjectIdName = "CustomerLeadStatusHistoryId",
                DataSubjectPlural = "Customer Lead Status Histories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCustomerLeadStatusHistoryForCustomerLead",
                DataSubjectSelectStoredProcedureName = "spGetCustomerLeadStatusHistory",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomerLeadStatusHistory",
                DataSubjectUpdateStoredProcedureParameter = "customerLeadStatusHistoryId"
            },
            // Customer Lead Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.CustomerLeadType,
                DataSubjectCreateStoredProcedureName = "spCreateCustomerLeadType",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomerLeadType",
                DataSubjectFriendlyName = "Customer Lead Type",
                DataSubjectIdFriendlyName = "Customer Lead Type Id",
                DataSubjectIdName = "CustomerLeadTypeId",
                DataSubjectPlural = "Customer Lead Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCustomerLeadType",
                DataSubjectSelectStoredProcedureName = "spGetCustomerLeadType",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomerLeadType",
                DataSubjectUpdateStoredProcedureParameter = "customerLeadTypeId"
            },
            // Customer Note
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Customer,
                DataSubject = FunctionTitle.CustomerNote,
                DataSubjectCreateStoredProcedureName = "spCreateCustomerNote",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomerNote",
                DataSubjectFriendlyName = "Customer Note",
                DataSubjectIdFriendlyName = "Customer Note Id",
                DataSubjectIdName = "CustomerNoteId",
                DataSubjectPlural = "Customer Notes",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCustomerNoteForCustomer",
                DataSubjectSelectStoredProcedureName = "spGetCustomerNote",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomerNote",
                DataSubjectUpdateStoredProcedureParameter = "customerNoteId"
            },
            // Customer Note Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.CustomerNoteType,
                DataSubjectCreateStoredProcedureName = "spCreateCustomerNoteType",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomerNoteType",
                DataSubjectFriendlyName = "Customer Note Type",
                DataSubjectIdFriendlyName = "Customer Note Type Id",
                DataSubjectIdName = "CustomerNoteTypeId",
                DataSubjectPlural = "Customer Note Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCustomerNoteType",
                DataSubjectSelectStoredProcedureName = "spGetCustomerNoteType",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomerNoteType",
                DataSubjectUpdateStoredProcedureParameter = "customerNoteTypeId"
            },
            // Customer Tier
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.CustomerTier,
                DataSubjectCreateStoredProcedureName = "spCreateCustomerTier",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomerTier",
                DataSubjectFriendlyName = "Customer Tier",
                DataSubjectIdFriendlyName = "Customer Tier Id",
                DataSubjectIdName = "CustomerTierId",
                DataSubjectPlural = "Customer Tiers",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCustomerTier",
                DataSubjectSelectStoredProcedureName = "spGetCustomerTier",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomerTier",
                DataSubjectUpdateStoredProcedureParameter = "customerTierId"
            },
            // Customer Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.CustomerType,
                DataSubjectCreateStoredProcedureName = "spCreateCustomerType",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomerType",
                DataSubjectFriendlyName = "Customer Type",
                DataSubjectIdFriendlyName = "Customer Type Id",
                DataSubjectIdName = "CustomerTypeId",
                DataSubjectPlural = "Customer Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCustomerType",
                DataSubjectSelectStoredProcedureName = "spGetCustomerType",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomerType",
                DataSubjectUpdateStoredProcedureParameter = "customerTypeId"
            },
            // Delivery Method
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.DeliveryMethod,
                DataSubjectCreateStoredProcedureName = "spCreateDeliveryMethod",
                DataSubjectDeleteStoredProcedureName = "spDeleteDeliveryMethod",
                DataSubjectFriendlyName = "Delivery Method",
                DataSubjectIdFriendlyName = "Delivery Method Id",
                DataSubjectIdName = "DeliveryMethodId",
                DataSubjectPlural = "Delivery Methods",
                DataSubjectSelectAllStoredProcedureName = "spGetAllDeliveryMethod",
                DataSubjectSelectStoredProcedureName = "spGetDeliveryMethod",
                DataSubjectUpdateStoredProcedureName = "spUpdateDeliveryMethod",
                DataSubjectUpdateStoredProcedureParameter = "deliveryMethodId"
            },
            // HTML Template
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.HTMLTemplate,
                DataSubjectCreateStoredProcedureName = "spCreateHTMLTemplate",
                DataSubjectDeleteStoredProcedureName = "spDeleteHTMLTemplate",
                DataSubjectFriendlyName = "HTML Template",
                DataSubjectIdFriendlyName = "HTML Template Id",
                DataSubjectIdName = "HTMLTemplateId",
                DataSubjectPlural = "HTML Templates",
                DataSubjectSelectAllStoredProcedureName = "spGetAllHTMLTemplate",
                DataSubjectSelectStoredProcedureName = "spGetHTMLTemplate",
                DataSubjectUpdateStoredProcedureName = "spUpdateHTMLTemplate",
                DataSubjectUpdateStoredProcedureParameter = "htmlTemplateId"
            },
            // HTML Template Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.HTMLTemplateType,
                DataSubjectCreateStoredProcedureName = "spCreateHTMLTemplateType",
                DataSubjectDeleteStoredProcedureName = "spDeleteHTMLTemplateType",
                DataSubjectFriendlyName = "HTML Template Type",
                DataSubjectIdFriendlyName = "HTML Template Type Id",
                DataSubjectIdName = "HTMLTemplateTypeId",
                DataSubjectPlural = "HTML Template Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllHTMLTemplateType",
                DataSubjectSelectStoredProcedureName = "spGetHTMLTemplateType",
                DataSubjectUpdateStoredProcedureName = "spUpdateHTMLTemplateType",
                DataSubjectUpdateStoredProcedureParameter = "htmlTemplateTypeId"
            },
            // Manufacturer
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.Manufacturer,
                DataSubjectCreateStoredProcedureName = "spCreateManufacturer",
                DataSubjectDeleteStoredProcedureName = "spDeleteManufacturer",
                DataSubjectFriendlyName = "Manufacturer",
                DataSubjectIdFriendlyName = "Manufacturer Id",
                DataSubjectIdName = "ManufacturerId",
                DataSubjectPlural = "Manufacturers",
                DataSubjectSelectAllStoredProcedureName = "spGetAllManufacturer",
                DataSubjectSelectStoredProcedureName = "spGetManufacturer",
                DataSubjectUpdateStoredProcedureName = "spUpdateManufacturer",
                DataSubjectUpdateStoredProcedureParameter = "manufacturerId"
            },
            // Marketing Campaign
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.MarketingCampaign,
                DataSubjectCreateStoredProcedureName = "spCreateMarketingCampaign",
                DataSubjectDeleteStoredProcedureName = "spDeleteMarketingCampaign",
                DataSubjectFriendlyName = "Marketing Campaign",
                DataSubjectIdFriendlyName = "Marketing Campaign Id",
                DataSubjectIdName = "MarketingCampaignId",
                DataSubjectPlural = "Marketing Campaigns",
                DataSubjectSelectAllStoredProcedureName = "spGetAllMarketingCampaign",
                DataSubjectSelectStoredProcedureName = "spGetMarketingCampaign",
                DataSubjectUpdateStoredProcedureName = "spUpdateMarketingCampaign",
                DataSubjectUpdateStoredProcedureParameter = "marketingCampaignId"
            },
            // Marketing Campaign Marketing Channel
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.MarketingCampaign,
                DataSubject = FunctionTitle.MarketingCampaignMarketingChannel,
                DataSubjectCreateStoredProcedureName = "spCreateMarketingCampaignMarketingChannel",
                DataSubjectDeleteStoredProcedureName = "spDeleteMarketingCampaignMarketingChannel",
                DataSubjectFriendlyName = "Marketing Campaign Marketing Channel",
                DataSubjectIdFriendlyName = "Marketing Campaign Marketing Channel Id",
                DataSubjectIdName = "MarketingCampaignMarketingChannelId",
                DataSubjectPlural = "Marketing Campaign Marketing Channels",
                DataSubjectSelectAllStoredProcedureName = "spGetAllMarketingCampaignMarketingChannelForMarketingCampaign",
                DataSubjectSelectStoredProcedureName = "spGetMarketingCampaignMarketingChannel",
                DataSubjectUpdateStoredProcedureName = "spUpdateMarketingCampaignMarketingChannel",
                DataSubjectUpdateStoredProcedureParameter = "marketingCampaignMarketingChannelId"
            },
            // Marketing Campaign Status
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.MarketingCampaignStatus,
                DataSubjectCreateStoredProcedureName = "spCreateMarketingCampaignStatus",
                DataSubjectDeleteStoredProcedureName = "spDeleteMarketingCampaignStatus",
                DataSubjectFriendlyName = "Marketing Campaign Status",
                DataSubjectIdFriendlyName = "Marketing Campaign Status Id",
                DataSubjectIdName = "MarketingCampaignStatusId",
                DataSubjectPlural = "Marketing Campaign Statuses",
                DataSubjectSelectAllStoredProcedureName = "spGetAllMarketingCampaignStatus",
                DataSubjectSelectStoredProcedureName = "spGetMarketingCampaignStatus",
                DataSubjectUpdateStoredProcedureName = "spUpdateMarketingCampaignStatus",
                DataSubjectUpdateStoredProcedureParameter = "marketingCampaignStatusId"
            },
            // Marketing Campaign Status History
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.MarketingCampaign,
                DataSubject = FunctionTitle.MarketingCampaignStatusHistory,
                DataSubjectCreateStoredProcedureName = "spCreateMarketingCampaignStatusHistory",
                DataSubjectDeleteStoredProcedureName = "spDeleteMarketingCampaignStatusHistory",
                DataSubjectFriendlyName = "Marketing Campaign Status History",
                DataSubjectIdFriendlyName = "Marketing Campaign Status History Id",
                DataSubjectIdName = "MarketingCampaignStatusHistoryId",
                DataSubjectPlural = "Marketing Campaign Status Histories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllMarketingCampaignStatusHistoryForMarketingCampaign",
                DataSubjectSelectStoredProcedureName = "spGetMarketingCampaignStatusHistory",
                DataSubjectUpdateStoredProcedureName = "spUpdateMarketingCampaignStatusHistory",
                DataSubjectUpdateStoredProcedureParameter = "marketingCampaignStatusHistoryId"
            },
            // Marketing Campaign Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.MarketingCampaignType,
                DataSubjectCreateStoredProcedureName = "spCreateMarketingCampaignType",
                DataSubjectDeleteStoredProcedureName = "spDeleteMarketingCampaignType",
                DataSubjectFriendlyName = "Marketing Campaign Type",
                DataSubjectIdFriendlyName = "Marketing Campaign Type Id",
                DataSubjectIdName = "MarketingCampaignTypeId",
                DataSubjectPlural = "Marketing Campaign Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllMarketingCampaignType",
                DataSubjectSelectStoredProcedureName = "spGetMarketingCampaignType",
                DataSubjectUpdateStoredProcedureName = "spUpdateMarketingCampaignType",
                DataSubjectUpdateStoredProcedureParameter = "marketingCampaignTypeId"
            },
            // Marketing Channel
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.MarketingChannel,
                DataSubjectCreateStoredProcedureName = "spCreateMarketingChannel",
                DataSubjectDeleteStoredProcedureName = "spDeleteMarketingChannel",
                DataSubjectFriendlyName = "Marketing Channel",
                DataSubjectIdFriendlyName = "Marketing Channel Id",
                DataSubjectIdName = "MarketingChannelId",
                DataSubjectPlural = "Marketing Channels",
                DataSubjectSelectAllStoredProcedureName = "spGetAllMarketingChannel",
                DataSubjectSelectStoredProcedureName = "spGetMarketingChannel",
                DataSubjectUpdateStoredProcedureName = "spUpdateMarketingChannel",
                DataSubjectUpdateStoredProcedureParameter = "marketingChannelId"
            },
            // Order
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.Order,
                DataSubjectCreateStoredProcedureName = "spCreateOrder",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrder",
                DataSubjectFriendlyName = "Order",
                DataSubjectIdFriendlyName = "Order Id",
                DataSubjectIdName = "OrderId",
                DataSubjectPlural = "Orders",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrder",
                DataSubjectSelectStoredProcedureName = "spGetOrder",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrder",
                DataSubjectUpdateStoredProcedureParameter = "orderId"
            },
            // Order Invoice
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Order,
                DataSubject = FunctionTitle.OrderInvoice,
                DataSubjectCreateStoredProcedureName = "spCreateOrderInvoice",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderInvoice",
                DataSubjectFriendlyName = "Order Invoice",
                DataSubjectIdFriendlyName = "Order Invoice Id",
                DataSubjectIdName = "OrderInvoiceId",
                DataSubjectPlural = "Order Invoices",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderInvoiceForOrder",
                DataSubjectSelectStoredProcedureName = "spGetOrderInvoice",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderInvoice",
                DataSubjectUpdateStoredProcedureParameter = "orderInvoiceId"
            },
            // Order Line Item
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Order,
                DataSubject = FunctionTitle.OrderLineItem,
                DataSubjectCreateStoredProcedureName = "spCreateOrderLineItem",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderLineItem",
                DataSubjectFriendlyName = "Order Line Item",
                DataSubjectIdFriendlyName = "Order Line Item Id",
                DataSubjectIdName = "OrderLineItemId",
                DataSubjectPlural = "Order Line Items",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderLineItemForOrder",
                DataSubjectSelectStoredProcedureName = "spGetOrderLineItem",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderLineItem",
                DataSubjectUpdateStoredProcedureParameter = "orderLineItemId"
            },
            // Order Line Item Status
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.OrderLineItem,
                DataSubject = FunctionTitle.OrderLineItemStatus,
                DataSubjectCreateStoredProcedureName = "spCreateOrderLineItemStatus",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderLineItemStatus",
                DataSubjectFriendlyName = "Order Line Item Status",
                DataSubjectIdFriendlyName = "Order Line Item Status Id",
                DataSubjectIdName = "OrderLineItemStatusId",
                DataSubjectPlural = "Order Line Item Statuses",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderLineItemStatus",
                DataSubjectSelectStoredProcedureName = "spGetOrderLineItemStatus",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderLineItemStatus",
                DataSubjectUpdateStoredProcedureParameter = "orderLineItemStatusId"
            },
            // Order Line Item Status History
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.OrderLineItem,
                DataSubject = FunctionTitle.OrderLineItemStatusHistory,
                DataSubjectCreateStoredProcedureName = "spCreateOrderLineItemStatusHistory",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderLineItemStatusHistory",
                DataSubjectFriendlyName = "Order Line Item Status History",
                DataSubjectIdFriendlyName = "Order Line Item Status History Id",
                DataSubjectIdName = "OrderLineItemStatusHistoryId",
                DataSubjectPlural = "Order Line Item Status Histories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderLineItemStatusHistoryForOrderLineItem",
                DataSubjectSelectStoredProcedureName = "spGetOrderLineItemStatusHistory",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderLineItemStatusHistory",
                DataSubjectUpdateStoredProcedureParameter = "orderLineItemStatusHistoryId"
            },
            // Order Payment
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Order,
                DataSubject = FunctionTitle.OrderPayment,
                DataSubjectCreateStoredProcedureName = "spCreateOrderPayment",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderPayment",
                DataSubjectFriendlyName = "Order Payment",
                DataSubjectIdFriendlyName = "Order Payment Id",
                DataSubjectIdName = "OrderPaymentId",
                DataSubjectPlural = "Order Payments",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderPaymentForOrder",
                DataSubjectSelectStoredProcedureName = "spGetOrderPayment",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderPayment",
                DataSubjectUpdateStoredProcedureParameter = "orderPaymentId"
            },
            // Order Payment Status
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.OrderPaymentStatus,
                DataSubjectCreateStoredProcedureName = "spCreateOrderPaymentStatus",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderPaymentStatus",
                DataSubjectFriendlyName = "Order Payment Status",
                DataSubjectIdFriendlyName = "Order Payment Status Id",
                DataSubjectIdName = "OrderPaymentStatusId",
                DataSubjectPlural = "Order Payment Statuses",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderPaymentStatus",
                DataSubjectSelectStoredProcedureName = "spGetOrderPaymentStatus",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderPaymentStatus",
                DataSubjectUpdateStoredProcedureParameter = "orderPaymentStatusId"
            },
            // Order Payment Status History
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.OrderPayment,
                DataSubject = FunctionTitle.OrderPaymentStatusHistory,
                DataSubjectCreateStoredProcedureName = "spCreateOrderPaymentStatusHistory",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderPaymentStatusHistory",
                DataSubjectFriendlyName = "Order Payment Status History",
                DataSubjectIdFriendlyName = "Order Payment Status History Id",
                DataSubjectIdName = "OrderPaymentStatusHistoryId",
                DataSubjectPlural = "Order Payment Status Histories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderPaymentStatusHistoryForOrderPayment",
                DataSubjectSelectStoredProcedureName = "spGetOrderPaymentStatusHistory",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderPaymentStatusHistory",
                DataSubjectUpdateStoredProcedureParameter = "orderPaymentStatusHistoryId"
            },
            // Order Quote
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.OrderQuote,
                DataSubjectCreateStoredProcedureName = "spCreateOrderQuote",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderQuote",
                DataSubjectFriendlyName = "Order Quote",
                DataSubjectIdFriendlyName = "Order Quote Id",
                DataSubjectIdName = "OrderQuoteId",
                DataSubjectPlural = "Order Quotes",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderQuoteForOrder",
                DataSubjectSelectStoredProcedureName = "spGetOrderQuote",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderQuote",
                DataSubjectUpdateStoredProcedureParameter = "orderQuoteId"
            },
            // Order Status
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.OrderStatus,
                DataSubjectCreateStoredProcedureName = "spCreateOrderStatus",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderStatus",
                DataSubjectFriendlyName = "Order Status",
                DataSubjectIdFriendlyName = "Order Status Id",
                DataSubjectIdName = "OrderStatusId",
                DataSubjectPlural = "Order Statuses",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderStatus",
                DataSubjectSelectStoredProcedureName = "spGetOrderStatus",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderStatus",
                DataSubjectUpdateStoredProcedureParameter = "orderStatusId"
            },
            // Order Status History
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Order,
                DataSubject = FunctionTitle.OrderStatusHistory,
                DataSubjectCreateStoredProcedureName = "spCreateOrderStatusHistory",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderStatusHistory",
                DataSubjectFriendlyName = "Order Status History",
                DataSubjectIdFriendlyName = "Order Status History Id",
                DataSubjectIdName = "OrderStatusHistoryId",
                DataSubjectPlural = "Order Status Histories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderStatusHistoryForOrder",
                DataSubjectSelectStoredProcedureName = "spGetOrderStatusHistory",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderStatusHistory",
                DataSubjectUpdateStoredProcedureParameter = "orderStatusHistoryId"
            },
            // Order Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.OrderType,
                DataSubjectCreateStoredProcedureName = "spCreateOrderType",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderType",
                DataSubjectFriendlyName = "Order Type",
                DataSubjectIdFriendlyName = "Order Type Id",
                DataSubjectIdName = "OrderTypeId",
                DataSubjectPlural = "Order Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderType",
                DataSubjectSelectStoredProcedureName = "spGetOrderType",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderType",
                DataSubjectUpdateStoredProcedureParameter = "orderTypeId"
            },
            // Payment Method
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.PaymentMethod,
                DataSubjectCreateStoredProcedureName = "spCreatePaymentMethod",
                DataSubjectDeleteStoredProcedureName = "spDeletePaymentMethod",
                DataSubjectFriendlyName = "Payment Method",
                DataSubjectIdFriendlyName = "Payment Method Id",
                DataSubjectIdName = "PaymentMethodId",
                DataSubjectPlural = "Payment Methods",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPaymentMethod",
                DataSubjectSelectStoredProcedureName = "spGetPaymentMethod",
                DataSubjectUpdateStoredProcedureName = "spUpdatePaymentMethod",
                DataSubjectUpdateStoredProcedureParameter = "paymentMethodId"
            },
            // Product
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.Product,
                DataSubjectCreateStoredProcedureName = "spCreateProduct",
                DataSubjectDeleteStoredProcedureName = "spDeleteProduct",
                DataSubjectFriendlyName = "Product",
                DataSubjectIdFriendlyName = "Product Id",
                DataSubjectIdName = "ProductId",
                DataSubjectPlural = "Products",
                DataSubjectSelectAllStoredProcedureName = "spGetAllProduct",
                DataSubjectSelectStoredProcedureName = "spGetProduct",
                DataSubjectUpdateStoredProcedureName = "spUpdateProduct",
                DataSubjectUpdateStoredProcedureParameter = "productId"
            },
            // Product Category
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.ProductCategory,
                DataSubjectCreateStoredProcedureName = "spCreateProductCategory",
                DataSubjectDeleteStoredProcedureName = "spDeleteProductCategory",
                DataSubjectFriendlyName = "Product Category",
                DataSubjectIdFriendlyName = "Product Category Id",
                DataSubjectIdName = "ProductCategoryId",
                DataSubjectPlural = "Product Categories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllProductCategory",
                DataSubjectSelectStoredProcedureName = "spGetProductCategory",
                DataSubjectUpdateStoredProcedureName = "spUpdateProductCategory",
                DataSubjectUpdateStoredProcedureParameter = "productCategoryId"
            },
            // Product Family
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.ProductFamily,
                DataSubjectCreateStoredProcedureName = "spCreateProductFamily",
                DataSubjectDeleteStoredProcedureName = "spDeleteProductFamily",
                DataSubjectFriendlyName = "Product Family",
                DataSubjectIdFriendlyName = "Product Family Id",
                DataSubjectIdName = "ProductFamilyId",
                DataSubjectPlural = "Product Families",
                DataSubjectSelectAllStoredProcedureName = "spGetAllProductFamily",
                DataSubjectSelectStoredProcedureName = "spGetProductFamily",
                DataSubjectUpdateStoredProcedureName = "spUpdateProductFamily",
                DataSubjectUpdateStoredProcedureParameter = "productFamilyId"
            },
            // Product Image
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Product,
                DataSubject = FunctionTitle.ProductImage,
                DataSubjectCreateStoredProcedureName = "spCreateProductImage",
                DataSubjectDeleteStoredProcedureName = "spDeleteProductImage",
                DataSubjectFriendlyName = "Product Image",
                DataSubjectIdFriendlyName = "Product Image Id",
                DataSubjectIdName = "ProductImageId",
                DataSubjectPlural = "Product Images",
                DataSubjectSelectAllStoredProcedureName = "spGetAllProductImageForProduct",
                DataSubjectSelectStoredProcedureName = "spGetProductImage",
                DataSubjectUpdateStoredProcedureName = "spUpdateProductImage",
                DataSubjectUpdateStoredProcedureParameter = "productImageId"
            },
            // Product Note
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Product,
                DataSubject = FunctionTitle.ProductNote,
                DataSubjectCreateStoredProcedureName = "spCreateProductNote",
                DataSubjectDeleteStoredProcedureName = "spDeleteProductNote",
                DataSubjectFriendlyName = "Product Note",
                DataSubjectIdFriendlyName = "Product Note Id",
                DataSubjectIdName = "ProductNoteId",
                DataSubjectPlural = "Product Notes",
                DataSubjectSelectAllStoredProcedureName = "spGetAllProductNoteForProduct",
                DataSubjectSelectStoredProcedureName = "spGetProductNote",
                DataSubjectUpdateStoredProcedureName = "spUpdateProductNote",
                DataSubjectUpdateStoredProcedureParameter = "productNoteId"
            },
            // Product Note Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.ProductNoteType,
                DataSubjectCreateStoredProcedureName = "spCreateProductNoteType",
                DataSubjectDeleteStoredProcedureName = "spDeleteProductNoteType",
                DataSubjectFriendlyName = "Product Note Type",
                DataSubjectIdFriendlyName = "Product Note Type Id",
                DataSubjectIdName = "ProductNoteTypeId",
                DataSubjectPlural = "Product Note Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllProductNoteType",
                DataSubjectSelectStoredProcedureName = "spGetProductNoteType",
                DataSubjectUpdateStoredProcedureName = "spUpdateProductNoteType",
                DataSubjectUpdateStoredProcedureParameter = "productNoteTypeId"
            },
            // Product Sales Sub Region
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Product,
                DataSubject = FunctionTitle.ProductSalesSubRegion,
                DataSubjectCreateStoredProcedureName = "spCreateProductSalesSubRegion",
                DataSubjectDeleteStoredProcedureName = "spDeleteProductSalesSubRegion",
                DataSubjectFriendlyName = "Product Sales Sub Region",
                DataSubjectIdFriendlyName = "Product Sales Sub Region Id",
                DataSubjectIdName = "ProductSalesSubRegionId",
                DataSubjectPlural = "Product Sales Sub Regions",
                DataSubjectSelectAllStoredProcedureName = "spGetAllProductSalesSubRegionForProduct",
                DataSubjectSelectStoredProcedureName = "spGetProductSalesSubRegion",
                DataSubjectUpdateStoredProcedureName = "spUpdateProductSalesSubRegion",
                DataSubjectUpdateStoredProcedureParameter = "productSalesSubRegionId"
            },
            // Product Sub Category
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.ProductCategory,
                DataSubject = FunctionTitle.ProductSubCategory,
                DataSubjectCreateStoredProcedureName = "spCreateProductSubCategory",
                DataSubjectDeleteStoredProcedureName = "spDeleteProductSubCategory",
                DataSubjectFriendlyName = "Product Sub Category",
                DataSubjectIdFriendlyName = "Product Sub Category Id",
                DataSubjectIdName = "ProductSubCategoryId",
                DataSubjectPlural = "Product Sub Categories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllProductSubCategory",
                DataSubjectSelectStoredProcedureName = "spGetProductSubCategory",
                DataSubjectUpdateStoredProcedureName = "spUpdateProductSubCategory",
                DataSubjectUpdateStoredProcedureParameter = "productSubCategoryId"
            },
            // Product Supplier
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Product,
                DataSubject = FunctionTitle.ProductSupplier,
                DataSubjectCreateStoredProcedureName = "spCreateProductSupplier",
                DataSubjectDeleteStoredProcedureName = "spDeleteProductSupplier",
                DataSubjectFriendlyName = "Product Supplier",
                DataSubjectIdFriendlyName = "Product Supplier Id",
                DataSubjectIdName = "ProductSupplierId",
                DataSubjectPlural = "Product Suppliers",
                DataSubjectSelectAllStoredProcedureName = "spGetAllProductSupplierForProduct",
                DataSubjectSelectStoredProcedureName = "spGetProductSupplier",
                DataSubjectUpdateStoredProcedureName = "spUpdateProductSupplier",
                DataSubjectUpdateStoredProcedureParameter = "productSupplierId"
            },
            // Promotion
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.MarketingCampaign,
                DataSubject = FunctionTitle.Promotion,
                DataSubjectCreateStoredProcedureName = "spCreatePromotion",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotion",
                DataSubjectFriendlyName = "Promotion",
                DataSubjectIdFriendlyName = "Promotion Id",
                DataSubjectIdName = "PromotionId",
                DataSubjectPlural = "Promotions",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionForMarketingCampaign",
                DataSubjectSelectStoredProcedureName = "spGetPromotion",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotion",
                DataSubjectUpdateStoredProcedureParameter = "promotionId"
            },
            // Promotion Manufacturer
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Promotion,
                DataSubject = FunctionTitle.PromotionManufacturer,
                DataSubjectCreateStoredProcedureName = "spCreatePromotionManufacturer",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionManufacturer",
                DataSubjectFriendlyName = "Promotion Manufacturer",
                DataSubjectIdFriendlyName = "Promotion Manufacturer Id",
                DataSubjectIdName = "PromotionManufacturerId",
                DataSubjectPlural = "Promotion Manufacturers",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionManufacturerForPromotion",
                DataSubjectSelectStoredProcedureName = "spGetPromotionManufacturer",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionManufacturer",
                DataSubjectUpdateStoredProcedureParameter = "promotionManufacturerId"
            },
            // Promotion Manufacturer Product Category
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.PromotionManufacturer,
                DataSubject = FunctionTitle.PromotionManufacturerProductCategory,
                DataSubjectCreateStoredProcedureName = "spCreatePromotionManufacturerProductCategory",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionManufacturerProductCategory",
                DataSubjectFriendlyName = "Promotion Manufacturer Product Category",
                DataSubjectIdFriendlyName = "Promotion Manufacturer Product Category Id",
                DataSubjectIdName = "PromotionManufacturerProductCategoryId",
                DataSubjectPlural = "Promotion Manufacturer Product Categories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionManufacturerProductCategoryForPromotion",
                DataSubjectSelectStoredProcedureName = "spGetPromotionManufacturerProductCategory",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionManufacturerProductCategory",
                DataSubjectUpdateStoredProcedureParameter = "promotionManufacturerProductCategoryId"
            },
            // Promotion Manufacturer Product Sub Category
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.PromotionManufacturer,
                DataSubject = FunctionTitle.PromotionManufacturerProductSubCategory,
                DataSubjectCreateStoredProcedureName = "spCreatePromotionManufacturerProductSubCategory",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionManufacturerProductSubCategory",
                DataSubjectFriendlyName = "Promotion Manufacturer Product Sub Category",
                DataSubjectIdFriendlyName = "Promotion Manufacturer Product Sub Category Id",
                DataSubjectIdName = "PromotionManufacturerProductSubCategoryId",
                DataSubjectPlural = "Promotion Manufacturer Product Sub Categories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionManufacturerProductSubCategoryForPromotion",
                DataSubjectSelectStoredProcedureName = "spGetPromotionManufacturerProductSubCategory",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionManufacturerProductSubCategory",
                DataSubjectUpdateStoredProcedureParameter = "promotionManufacturerProductSubCategoryId"
            },
            // Promotion Product
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Promotion,
                DataSubject = FunctionTitle.PromotionProduct,
                DataSubjectCreateStoredProcedureName = "spCreatePromotionProduct",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionProduct",
                DataSubjectFriendlyName = "Promotion Product",
                DataSubjectIdFriendlyName = "Promotion Product Id",
                DataSubjectIdName = "PromotionProductId",
                DataSubjectPlural = "Promotion Products",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionProductForPromotion",
                DataSubjectSelectStoredProcedureName = "spGetPromotionProduct",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionProduct",
                DataSubjectUpdateStoredProcedureParameter = "promotionProductId"
            },
            // Promotion Product Category
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Promotion,
                DataSubject = FunctionTitle.PromotionProductCategory,
                DataSubjectCreateStoredProcedureName = "spCreatePromotionProductCategory",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionProductCategory",
                DataSubjectFriendlyName = "Promotion Product Category",
                DataSubjectIdFriendlyName = "Promotion Product Category Id",
                DataSubjectIdName = "PromotionProductCategoryId",
                DataSubjectPlural = "Promotion Product Categories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionProductCategoryForPromotion",
                DataSubjectSelectStoredProcedureName = "spGetPromotionProductCategory",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionProductCategory",
                DataSubjectUpdateStoredProcedureParameter = "promotionProductCategoryId"
            },
            // Promotion Product Family
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Promotion,
                DataSubject = FunctionTitle.PromotionProductFamily,
                DataSubjectCreateStoredProcedureName = "spCreatePromotionProductFamily",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionProductFamily",
                DataSubjectFriendlyName = "Promotion Product Family",
                DataSubjectIdFriendlyName = "Promotion Product Family Id",
                DataSubjectIdName = "PromotionProductFamilyId",
                DataSubjectPlural = "Promotion Product Families",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionProductFamilyForPromotion",
                DataSubjectSelectStoredProcedureName = "spGetPromotionProductFamily",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionProductFamily",
                DataSubjectUpdateStoredProcedureParameter = "promotionProductFamilyId"
            },
            // Promotion Product Sub Category
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Promotion,
                DataSubject = FunctionTitle.PromotionProductSubCategory,
                DataSubjectCreateStoredProcedureName = "spCreatePromotionProductSubCategory",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionProductSubCategory",
                DataSubjectFriendlyName = "Promotion Product Sub Category",
                DataSubjectIdFriendlyName = "Promotion Product Sub Category Id",
                DataSubjectIdName = "PromotionProductSubCategoryId",
                DataSubjectPlural = "Promotion Product Sub Categories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionProductSubCategoryForPromotion",
                DataSubjectSelectStoredProcedureName = "spGetPromotionProductSubCategory",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionProductSubCategory",
                DataSubjectUpdateStoredProcedureParameter = "promotionProductSubCategoryId"
            },
            // Promotion Supplier
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Promotion,
                DataSubject = FunctionTitle.PromotionSupplier,
                DataSubjectCreateStoredProcedureName = "spCreatePromotionSupplier",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionSupplier",
                DataSubjectFriendlyName = "Promotion Supplier",
                DataSubjectIdFriendlyName = "Promotion Supplier Id",
                DataSubjectIdName = "PromotionSupplierId",
                DataSubjectPlural = "Promotion Suppliers",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionSupplierForPromotion",
                DataSubjectSelectStoredProcedureName = "spGetPromotionSupplier",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionSupplier",
                DataSubjectUpdateStoredProcedureParameter = "promotionSupplierId"
            },
            // Promotion Supplier Product Category
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.PromotionSupplier,
                DataSubject = FunctionTitle.PromotionSupplierProductCategory,
                DataSubjectCreateStoredProcedureName = "spCreatePromotionSupplierProductCategory",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionSupplierProductCategory",
                DataSubjectFriendlyName = "Promotion Supplier Product Category",
                DataSubjectIdFriendlyName = "Promotion Supplier Product Category Id",
                DataSubjectIdName = "PromotionSupplierProductCategoryId",
                DataSubjectPlural = "Promotion Supplier Product Categories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionSupplierProductCategoryForPromotion",
                DataSubjectSelectStoredProcedureName = "spGetPromotionSupplierProductCategory",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionSupplierProductCategory",
                DataSubjectUpdateStoredProcedureParameter = "promotionSupplierProductCategoryId"
            },
            // Promotion Supplier Product Sub Category
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.PromotionSupplier,
                DataSubject = FunctionTitle.PromotionSupplierProductSubCategory,
                DataSubjectCreateStoredProcedureName = "spCreatePromotionSupplierProductSubCategory",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionSupplierProductSubCategory",
                DataSubjectFriendlyName = "Promotion Supplier Product Sub Category",
                DataSubjectIdFriendlyName = "Promotion Supplier Product Sub Category Id",
                DataSubjectIdName = "PromotionSupplierProductSubCategoryId",
                DataSubjectPlural = "Promotion Supplier Product Sub Categories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionSupplierProductSubCategoryForPromotion",
                DataSubjectSelectStoredProcedureName = "spGetPromotionSupplierProductSubCategory",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionSupplierProductSubCategory",
                DataSubjectUpdateStoredProcedureParameter = "promotionSupplierProductSubCategoryId"
            },
            // Promotion Target Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.PromotionTargetType,
                DataSubjectCreateStoredProcedureName = "spCreatePromotionTargetType",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionTargetType",
                DataSubjectFriendlyName = "Promotion Target Type",
                DataSubjectIdFriendlyName = "Promotion Target Type Id",
                DataSubjectIdName = "PromotionTargetTypeId",
                DataSubjectPlural = "Promotion Target Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionTargetType",
                DataSubjectSelectStoredProcedureName = "spGetPromotionTargetType",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionTargetType",
                DataSubjectUpdateStoredProcedureParameter = "promotionTargetTypeId"
            },
            // Promotion Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.PromotionType,
                DataSubjectCreateStoredProcedureName = "spCreatePromotionType",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionType",
                DataSubjectFriendlyName = "Promotion Type",
                DataSubjectIdFriendlyName = "Promotion Type Id",
                DataSubjectIdName = "PromotionTypeId",
                DataSubjectPlural = "Promotion Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionType",
                DataSubjectSelectStoredProcedureName = "spGetPromotionType",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionType",
                DataSubjectUpdateStoredProcedureParameter = "promotionTypeId"
            },
            // Sales Region
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.SalesRegion,
                DataSubjectCreateStoredProcedureName = "spCreateSalesRegion",
                DataSubjectDeleteStoredProcedureName = "spDeleteSalesRegion",
                DataSubjectFriendlyName = "Sales Region",
                DataSubjectIdFriendlyName = "Sales Region Id",
                DataSubjectIdName = "SalesRegionId",
                DataSubjectPlural = "Sales Regions",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSalesRegion",
                DataSubjectSelectStoredProcedureName = "spGetSalesRegion",
                DataSubjectUpdateStoredProcedureName = "spUpdateSalesRegion",
                DataSubjectUpdateStoredProcedureParameter = "salesRegionId"
            },
            // Sales Sub Region
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.SalesRegion,
                DataSubject = FunctionTitle.SalesSubRegion,
                DataSubjectCreateStoredProcedureName = "spCreateSalesSubRegion",
                DataSubjectDeleteStoredProcedureName = "spDeleteSalesSubRegion",
                DataSubjectFriendlyName = "Sales Sub Region",
                DataSubjectIdFriendlyName = "Sales Sub Region Id",
                DataSubjectIdName = "SalesSubRegionId",
                DataSubjectPlural = "Sales Sub Regions",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSalesSubRegionForSalesRegion",
                DataSubjectSelectStoredProcedureName = "spGetSalesSubRegion",
                DataSubjectUpdateStoredProcedureName = "spUpdateSalesSubRegion",
                DataSubjectUpdateStoredProcedureParameter = "salesSubRegionId"
            },
            // Supplier
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.Supplier,
                DataSubjectCreateStoredProcedureName = "spCreateSupplier",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplier",
                DataSubjectFriendlyName = "Supplier",
                DataSubjectIdFriendlyName = "Supplier Id",
                DataSubjectIdName = "SupplierId",
                DataSubjectPlural = "Suppliers",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplier",
                DataSubjectSelectStoredProcedureName = "spGetSupplier",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplier",
                DataSubjectUpdateStoredProcedureParameter = "supplierId"
            },
            // Supplier Contact
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Supplier,
                DataSubject = FunctionTitle.SupplierContact,
                DataSubjectCreateStoredProcedureName = "spCreateSupplierContact",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierContact",
                DataSubjectFriendlyName = "Supplier Contact",
                DataSubjectIdFriendlyName = "Supplier Contact Id",
                DataSubjectIdName = "SupplierContactId",
                DataSubjectPlural = "Supplier Contacts",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierContactForSupplier",
                DataSubjectSelectStoredProcedureName = "spGetSupplierContact",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierContact",
                DataSubjectUpdateStoredProcedureParameter = "supplierContactId"
            },
            // Supplier Note
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Supplier,
                DataSubject = FunctionTitle.SupplierNote,
                DataSubjectCreateStoredProcedureName = "spCreateSupplierNote",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierNote",
                DataSubjectFriendlyName = "Supplier Note",
                DataSubjectIdFriendlyName = "Supplier Note Id",
                DataSubjectIdName = "SupplierNoteId",
                DataSubjectPlural = "Supplier Notes",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierNoteForSupplier",
                DataSubjectSelectStoredProcedureName = "spGetSupplierNote",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierNote",
                DataSubjectUpdateStoredProcedureParameter = "supplierNoteId"
            },
            // Supplier Note Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.SupplierNoteType,
                DataSubjectCreateStoredProcedureName = "spCreateSupplierNoteType",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierNoteType",
                DataSubjectFriendlyName = "Supplier Note Type",
                DataSubjectIdFriendlyName = "Supplier Note Type Id",
                DataSubjectIdName = "SupplierNoteTypeId",
                DataSubjectPlural = "Supplier Note Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierNoteType",
                DataSubjectSelectStoredProcedureName = "spGetSupplierNoteType",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierNoteType",
                DataSubjectUpdateStoredProcedureParameter = "supplierNoteTypeId"
            },
            // Supplier Order
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.SupplierOrder,
                DataSubjectCreateStoredProcedureName = "spCreateSupplierOrder",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierOrder",
                DataSubjectFriendlyName = "Supplier Order",
                DataSubjectIdFriendlyName = "Supplier Order Id",
                DataSubjectIdName = "SupplierOrderId",
                DataSubjectPlural = "Supplier Orders",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierOrder",
                DataSubjectSelectStoredProcedureName = "spGetSupplierOrder",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrder",
                DataSubjectUpdateStoredProcedureParameter = "supplierOrderId"
            },
            // Supplier Order Line Item
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.SupplierOrder,
                DataSubject = FunctionTitle.SupplierOrderLineItem,
                DataSubjectCreateStoredProcedureName = "spCreateSupplierOrderLineItem",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierOrderLineItem",
                DataSubjectFriendlyName = "Supplier Order Line Item",
                DataSubjectIdFriendlyName = "Supplier Order Line Item Id",
                DataSubjectIdName = "SupplierOrderLineItemId",
                DataSubjectPlural = "Supplier Order Line Items",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierOrderLineItemForSupplierOrder",
                DataSubjectSelectStoredProcedureName = "spGetSupplierOrderLineItem",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrderLineItem",
                DataSubjectUpdateStoredProcedureParameter = "supplierOrderLineItemId"
            },
            // Supplier Order Line Item Status
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.SupplierOrderLineItemStatus,
                DataSubjectCreateStoredProcedureName = "spCreateSupplierOrderLineItemStatus",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierOrderLineItemStatus",
                DataSubjectFriendlyName = "Supplier Order Line Item Status",
                DataSubjectIdFriendlyName = "Supplier Order Line Item Status Id",
                DataSubjectIdName = "SupplierOrderLineItemStatusId",
                DataSubjectPlural = "Supplier Order Line Item Statuses",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierOrderLineItemStatus",
                DataSubjectSelectStoredProcedureName = "spGetSupplierOrderLineItemStatus",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrderLineItemStatus",
                DataSubjectUpdateStoredProcedureParameter = "supplierOrderLineItemStatusId"
            },
            // Supplier Order Line Item Status History
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.SupplierOrderLineItem,
                DataSubject = FunctionTitle.SupplierOrderLineItemStatusHistory,
                DataSubjectCreateStoredProcedureName = "spCreateSupplierOrderLineItemStatusHistory",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierOrderLineItemStatusHistory",
                DataSubjectFriendlyName = "Supplier Order Line Item Status History",
                DataSubjectIdFriendlyName = "Supplier Order Line Item Status History Id",
                DataSubjectIdName = "SupplierOrderLineItemStatusHistoryId",
                DataSubjectPlural = "Supplier Order Line Item Status Histories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierOrderLineItemStatusHistoryForOrderLineItem",
                DataSubjectSelectStoredProcedureName = "spGetSupplierOrderLineItemStatusHistory",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrderLineItemStatusHistory",
                DataSubjectUpdateStoredProcedureParameter = "supplierOrderLineItemStatusHistoryId"
            },
            // Supplier Order Payment
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.SupplierOrder,
                DataSubject = FunctionTitle.SupplierOrderPayment,
                DataSubjectCreateStoredProcedureName = "spCreateSupplierOrderPayment",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierOrderPayment",
                DataSubjectFriendlyName = "Supplier Order Payment",
                DataSubjectIdFriendlyName = "Supplier Order Payment Id",
                DataSubjectIdName = "SupplierOrderPaymentId",
                DataSubjectPlural = "Supplier Order Payments",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierOrderPaymentForSupplierOrder",
                DataSubjectSelectStoredProcedureName = "spGetSupplierOrderPayment",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrderPayment",
                DataSubjectUpdateStoredProcedureParameter = "supplierOrderPaymentId"
            },
            // Supplier Order Payment Status
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.SupplierOrderPaymentStatus,
                DataSubjectCreateStoredProcedureName = "spCreateSupplierOrderPaymentStatus",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierOrderPaymentStatus",
                DataSubjectFriendlyName = "Supplier Order Payment Status",
                DataSubjectIdFriendlyName = "Supplier Order Payment Status Id",
                DataSubjectIdName = "SupplierOrderPaymentStatusId",
                DataSubjectPlural = "Supplier Order Payment Statuses",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierOrderPaymentStatus",
                DataSubjectSelectStoredProcedureName = "spGetSupplierOrderPaymentStatus",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrderPaymentStatus",
                DataSubjectUpdateStoredProcedureParameter = "supplierOrderPaymentStatusId"
            },
            // Supplier Order Payment Status History
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.SupplierOrderPayment,
                DataSubject = FunctionTitle.SupplierOrderPaymentStatusHistory,
                DataSubjectCreateStoredProcedureName = "spCreateSupplierOrderPaymentStatusHistory",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierOrderPaymentStatusHistory",
                DataSubjectFriendlyName = "Supplier Order Payment Status History",
                DataSubjectIdFriendlyName = "Supplier Order Payment Status History Id",
                DataSubjectIdName = "SupplierOrderPaymentStatusHistoryId",
                DataSubjectPlural = "Supplier Order Payment Status Histories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierOrderPaymentStatusHistoryForSupplierOrderPayment",
                DataSubjectSelectStoredProcedureName = "spGetSupplierOrderPaymentStatusHistory",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrderPaymentStatusHistory",
                DataSubjectUpdateStoredProcedureParameter = "supplierOrderPaymentStatusHistoryId"
            },
            // Supplier Order Status
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.SupplierOrderStatus,
                DataSubjectCreateStoredProcedureName = "spCreateSupplierOrderStatus",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierOrderStatus",
                DataSubjectFriendlyName = "Supplier Order Status",
                DataSubjectIdFriendlyName = "Supplier Order Status Id",
                DataSubjectIdName = "SupplierOrderStatusId",
                DataSubjectPlural = "Supplier Order Statuses",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierOrderStatus",
                DataSubjectSelectStoredProcedureName = "spGetSupplierOrderStatus",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrderStatus",
                DataSubjectUpdateStoredProcedureParameter = "supplierOrderStatusId"
            },
            // Supplier Order Status History
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.SupplierOrder,
                DataSubject = FunctionTitle.SupplierOrderStatusHistory,
                DataSubjectCreateStoredProcedureName = "spCreateSupplierOrderStatusHistory",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierOrderStatusHistory",
                DataSubjectFriendlyName = "Supplier Order Status History",
                DataSubjectIdFriendlyName = "Supplier Order Status History Id",
                DataSubjectIdName = "SupplierOrderStatusHistoryId",
                DataSubjectPlural = "Supplier Order Status Histories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierOrderStatusHistoryForSupplierOrder",
                DataSubjectSelectStoredProcedureName = "spGetSupplierOrderStatusHistory",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrderStatusHistory",
                DataSubjectUpdateStoredProcedureParameter = "supplierOrderStatusHistoryId"
            },
            // Tax Profile
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.TaxProfile,
                DataSubjectCreateStoredProcedureName = "spCreateTaxProfile",
                DataSubjectDeleteStoredProcedureName = "spDeleteTaxProfile",
                DataSubjectFriendlyName = "Tax Profile",
                DataSubjectIdFriendlyName = "Tax Profile Id",
                DataSubjectIdName = "TaxProfileId",
                DataSubjectPlural = "Tax Profiles",
                DataSubjectSelectAllStoredProcedureName = "spGetAllTaxProfile",
                DataSubjectSelectStoredProcedureName = "spGetTaxProfile",
                DataSubjectUpdateStoredProcedureName = "spUpdateTaxProfile",
                DataSubjectUpdateStoredProcedureParameter = "taxProfileId"
            },
            // Wholesale Delivery Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.WholesaleDeliveryType,
                DataSubjectCreateStoredProcedureName = "spCreateWholesaleDeliveryType",
                DataSubjectDeleteStoredProcedureName = "spDeleteWholesaleDeliveryType",
                DataSubjectFriendlyName = "Wholesale Delivery Type",
                DataSubjectIdFriendlyName = "Wholesale Delivery Type Id",
                DataSubjectIdName = "WholesaleDeliveryTypeId",
                DataSubjectPlural = "Wholesale Delivery Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllWholesaleDeliveryType",
                DataSubjectSelectStoredProcedureName = "spGetWholesaleDeliveryType",
                DataSubjectUpdateStoredProcedureName = "spUpdateWholesaleDeliveryType",
                DataSubjectUpdateStoredProcedureParameter = "wholesaleDeliveryTypeId"
            }
        };
        public List<ModuleGroupFriendlyNameModel> ModuleGroupFriendlyNames { get; set; } = new List<ModuleGroupFriendlyNameModel>
        {
            new ModuleGroupFriendlyNameModel { ModuleGroup = ModuleGroup.CompanyManagement, ModuleGroupDataSubjectName = "Company", ModuleGroupDataSubjectPluralName = "Companies", ModuleGroupFriendlyName = "Company Management" },
            new ModuleGroupFriendlyNameModel { ModuleGroup = ModuleGroup.CustomerManagement, ModuleGroupDataSubjectName = "Customer", ModuleGroupDataSubjectPluralName = "Customers", ModuleGroupFriendlyName = "Customer Management" },
            new ModuleGroupFriendlyNameModel { ModuleGroup = ModuleGroup.MarketingManagement, ModuleGroupDataSubjectName = "Marketing Campaign", ModuleGroupDataSubjectPluralName = "Marketing Campaigns", ModuleGroupFriendlyName = "Marketing Management" },
            new ModuleGroupFriendlyNameModel { ModuleGroup = ModuleGroup.OrderManagement, ModuleGroupDataSubjectName = "Order", ModuleGroupDataSubjectPluralName = "Orders", ModuleGroupFriendlyName = "Order Management" },
            new ModuleGroupFriendlyNameModel { ModuleGroup = ModuleGroup.ProductManagement, ModuleGroupDataSubjectName = "Product", ModuleGroupDataSubjectPluralName = "Products", ModuleGroupFriendlyName = "Product Management" },
            new ModuleGroupFriendlyNameModel { ModuleGroup = ModuleGroup.SupplierManagement, ModuleGroupDataSubjectName = "Supplier", ModuleGroupDataSubjectPluralName = "Suppliers", ModuleGroupFriendlyName = "Supplier Management" }
        };      
    }

    public class DataSubjectModel
    {
        public FunctionTitle? DataParentSubject { get; set; }
        public FunctionTitle DataSubject { get; set; }
        public string DataSubjectCreateStoredProcedureName { get; set; }
        public string DataSubjectDeleteStoredProcedureName { get; set; }
        public string DataSubjectFriendlyName { get; set; }
        public string DataSubjectIdFriendlyName { get; set; }
        public string DataSubjectIdName { get; set; }
        public string DataSubjectPlural { get; set; }
        public string DataSubjectSelectAllStoredProcedureName { get; set; }
        public string DataSubjectSelectStoredProcedureName { get; set; }
        public string DataSubjectUpdateStoredProcedureName { get; set; }
        public string DataSubjectUpdateStoredProcedureParameter { get; set; }

    }

    public class ModuleGroupFriendlyNameModel
    {
        public ModuleGroup ModuleGroup { get; set; }
        public string ModuleGroupDataSubjectName { get; set; }
        public string ModuleGroupDataSubjectPluralName { get; set; }
        public string ModuleGroupFriendlyName { get; set; }
    }
}