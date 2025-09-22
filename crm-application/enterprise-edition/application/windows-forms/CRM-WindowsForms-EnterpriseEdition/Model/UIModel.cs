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
                DataSubjectCamelCaseName = "accountManager",
                DataSubjectCreateStoredProcedureName = "spCreateAccountManager",
                DataSubjectDeleteStoredProcedureName = "spDeleteAccountManager",
                DataSubjectFriendlyName = "Account Manager",
                DataSubjectIdFriendlyName = "Account Manager Id",
                DataSubjectIdName = "AccountManagerId",
                DataSubjectPlural = "Account Managers",
                DataSubjectSelectAllStoredProcedureName = "spGetAllAccountManager",
                DataSubjectSelectStoredProcedureName = "spGetAccountManager",
                DataSubjectSortingColumnName = "Last Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "accountManagerId",
                DataSubjectUpdateStoredProcedureName = "spUpdateAccountManager"
            },
            // Associated Customer to Account Manager
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.AssociatedCustomerToAccountManager,
                DataSubjectCamelCaseName = "associatedCustomerToAccountManager",
                DataSubjectFriendlyName = "Associated Customer to Account Manager",
                DataSubjectPlural = "Associated Customers to Account Manager",
                DataSubjectSelectAllStoredProcedureName = "spGetAssociatedCustomerToAccountManager",
                DataSubjectSortingColumnName = "Company Tier",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC
            },
            // Company Configuration
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.CompanyConfiguration,
                DataSubjectCamelCaseName = "companyConfiguration",
                DataSubjectCreateStoredProcedureName = "spCreateCompanyConfiguration",
                DataSubjectDeleteStoredProcedureName = "spDeleteCompanyConfiguration",
                DataSubjectFriendlyName = "Company Configuration",
                DataSubjectIdFriendlyName = "Company Configuration Id",
                DataSubjectIdName = "CompanyConfigurationId",
                DataSubjectPlural = "Company Configurations",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCompanyConfiguration",
                DataSubjectSelectStoredProcedureName = "spGetCompanyConfiguration",
                DataSubjectSortingColumnName = "Company Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "companyConfigurationId",
                DataSubjectUpdateStoredProcedureName = "spUpdateCompanyConfiguration"
            },
            // Country
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.Country,
                DataSubjectCamelCaseName = "country",
                DataSubjectCreateStoredProcedureName = "spCreateCountry",
                DataSubjectDeleteStoredProcedureName = "spDeleteCountry",
                DataSubjectFriendlyName = "Country",
                DataSubjectIdFriendlyName = "Country Id",
                DataSubjectIdName = "CountryId",
                DataSubjectPlural = "Countries",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCountry",
                DataSubjectSelectStoredProcedureName = "spGetCountry",
                DataSubjectSortingColumnName = "Country English Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "countryId",
                DataSubjectUpdateStoredProcedureName = "spUpdateCountry"
            },
            // Currency
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.Currency,
                DataSubjectCamelCaseName = "currency",
                DataSubjectCreateStoredProcedureName = "spCreateCurrency",
                DataSubjectDeleteStoredProcedureName = "spDeleteCurrency",
                DataSubjectFriendlyName = "Currency",
                DataSubjectIdFriendlyName = "Currency Id",
                DataSubjectIdName = "CurrencyId",
                DataSubjectPlural = "Currencies",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCurrency",
                DataSubjectSelectStoredProcedureName = "spGetCurrency",
                DataSubjectSortingColumnName = "Currency Code",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "currencyId",
                DataSubjectUpdateStoredProcedureName = "spUpdateCurrency"
            },
            // Currency Conversion
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.CurrencyConversion,
                DataSubjectCamelCaseName = "currencyConversion",
                DataSubjectCreateStoredProcedureName = "spCreateCurrencyConversion",
                DataSubjectDeleteStoredProcedureName = "spDeleteCurrencyConversion",
                DataSubjectFriendlyName = "Currency Conversion",
                DataSubjectIdFriendlyName = "Currency Conversion Id",
                DataSubjectIdName = "CurrencyConversionId",
                DataSubjectPlural = "Currency Conversions",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCurrencyConversion",
                DataSubjectSelectStoredProcedureName = "spGetCurrencyConversion",
                DataSubjectSortingColumnName = "Currency Conversion Friendly Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "currencyConversionId",
                DataSubjectUpdateStoredProcedureName = "spUpdateCurrencyConversion"
            },
            // Customer
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.Customer,
                DataSubjectCamelCaseName = "customer",
                DataSubjectCreateStoredProcedureName = "spCreateCustomer",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomer",
                DataSubjectFriendlyName = "Customer",
                DataSubjectIdFriendlyName = "Customer Id",
                DataSubjectIdName = "CustomerId",
                DataSubjectPlural = "Customers",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCustomer",
                DataSubjectSelectStoredProcedureName = "spGetCustomer",
                DataSubjectSortingColumnName = "Customer Id",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "customerId",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomer"
            },
            // Customer Contact
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Customer,
                DataSubject = FunctionTitle.CustomerContact,
                DataSubjectCamelCaseName = "customerContact",
                DataSubjectCreateStoredProcedureName = "spCreateCustomerContact",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomerContact",
                DataSubjectFriendlyName = "Customer Contact",
                DataSubjectIdFriendlyName = "Customer Contact Id",
                DataSubjectIdName = "CustomerContactId",
                DataSubjectPlural = "Customer Contacts",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCustomerContactForCustomer",
                DataSubjectSelectStoredProcedureName = "spGetCustomerContact",
                DataSubjectSortingColumnName = "Last Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "customerContactId",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomerContact"
            },
            // Customer Lead
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.CustomerLead,
                DataSubjectCamelCaseName = "customerLead",
                DataSubjectCreateStoredProcedureName = "spCreateCustomerLead",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomerLead",
                DataSubjectFriendlyName = "Customer Lead",
                DataSubjectIdFriendlyName = "Customer Lead Id",
                DataSubjectIdName = "CustomerLeadId",
                DataSubjectPlural = "Customer Leads",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCustomerLeadForCustomer",
                DataSubjectSelectStoredProcedureName = "spGetCustomerLead",
                DataSubjectSortingColumnName = "Created Timestamp UTC",
                DataSubjectSortingColumnOrder = DataSortingOrder.DESC,
                DataSubjectStoredProcedureIdParameterName = "customerLeadId",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomerLead"
            },
            // Customer Lead Note
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.CustomerLead,
                DataSubject = FunctionTitle.CustomerLeadNote,
                DataSubjectCamelCaseName = "customerLeadNote",
                DataSubjectCreateStoredProcedureName = "spCreateCustomerLeadNote",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomerLeadNote",
                DataSubjectFriendlyName = "Customer Lead Note",
                DataSubjectIdFriendlyName = "Customer Lead Note Id",
                DataSubjectIdName = "CustomerLeadNoteId",
                DataSubjectPlural = "Customer Lead Notes",
                DataSubjectSelectAllStoredProcedureName = "spGetAllNoteForCustomerLead",
                DataSubjectSelectStoredProcedureName = "spGetCustomerLeadNote",
                DataSubjectSortingColumnName = "Created Timestamp UTC",
                DataSubjectSortingColumnOrder = DataSortingOrder.DESC,
                DataSubjectStoredProcedureIdParameterName = "customerLeadNoteId",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomerLeadNote"
            },
            // Customer Lead Note Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.CustomerLeadNoteType,
                DataSubjectCamelCaseName = "customerLeadNoteType",
                DataSubjectCreateStoredProcedureName = "spCreateCustomerLeadNoteType",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomerLeadNoteType",
                DataSubjectFriendlyName = "Customer Lead Note Type",
                DataSubjectIdFriendlyName = "Customer Lead Note Type Id",
                DataSubjectIdName = "CustomerLeadNoteTypeId",
                DataSubjectPlural = "Customer Lead Note Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCustomerLeadNoteType",
                DataSubjectSelectStoredProcedureName = "spGetCustomerLeadNoteType",
                DataSubjectSortingColumnName = "Customer Lead Note Type",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "customerLeadNoteTypeId",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomerLeadNoteType"
            },
            // Customer Lead Status
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.CustomerLeadStatus,
                DataSubjectCamelCaseName = "customerLeadStatus",
                DataSubjectCreateStoredProcedureName = "spCreateCustomerLeadStatus",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomerLeadStatus",
                DataSubjectFriendlyName = "Customer Lead Status",
                DataSubjectIdFriendlyName = "Customer Lead Status Id",
                DataSubjectIdName = "CustomerLeadStatusId",
                DataSubjectPlural = "Customer Lead Statuses",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCustomerLeadStatus",
                DataSubjectSelectStoredProcedureName = "spGetCustomerLeadStatus",
                DataSubjectSortingColumnName = "Customer Lead Status",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "customerLeadStatusId",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomerLeadStatus"
            },
            // Customer Lead Status History
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.CustomerLead,
                DataSubject = FunctionTitle.CustomerLeadStatusHistory,
                DataSubjectCamelCaseName = "customerLeadStatusHistory",
                DataSubjectCreateStoredProcedureName = "spCreateCustomerLeadStatusHistory",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomerLeadStatusHistory",
                DataSubjectFriendlyName = "Customer Lead Status History",
                DataSubjectIdFriendlyName = "Customer Lead Status History Id",
                DataSubjectIdName = "CustomerLeadStatusHistoryId",
                DataSubjectPlural = "Customer Lead Status Histories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCustomerLeadStatusHistoryForCustomerLead",
                DataSubjectSelectStoredProcedureName = "spGetCustomerLeadStatusHistory",
                DataSubjectSortingColumnName = "Created Timestamp UTC",
                DataSubjectSortingColumnOrder = DataSortingOrder.DESC,
                DataSubjectStoredProcedureIdParameterName = "customerLeadStatusHistoryId",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomerLeadStatusHistory"
            },
            // Customer Lead Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.CustomerLeadType,
                DataSubjectCamelCaseName = "customerLeadType",
                DataSubjectCreateStoredProcedureName = "spCreateCustomerLeadType",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomerLeadType",
                DataSubjectFriendlyName = "Customer Lead Type",
                DataSubjectIdFriendlyName = "Customer Lead Type Id",
                DataSubjectIdName = "CustomerLeadTypeId",
                DataSubjectPlural = "Customer Lead Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCustomerLeadType",
                DataSubjectSelectStoredProcedureName = "spGetCustomerLeadType",
                DataSubjectSortingColumnName = "Customer Lead Type",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "customerLeadTypeId",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomerLeadType"
            },
            // Customer Note
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Customer,
                DataSubject = FunctionTitle.CustomerNote,
                DataSubjectCamelCaseName = "customerNote",
                DataSubjectCreateStoredProcedureName = "spCreateCustomerNote",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomerNote",
                DataSubjectFriendlyName = "Customer Note",
                DataSubjectIdFriendlyName = "Customer Note Id",
                DataSubjectIdName = "CustomerNoteId",
                DataSubjectPlural = "Customer Notes",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCustomerNoteForCustomer",
                DataSubjectSelectStoredProcedureName = "spGetCustomerNote",
                DataSubjectSortingColumnName = "Created Timestamp UTC",
                DataSubjectSortingColumnOrder = DataSortingOrder.DESC,
                DataSubjectStoredProcedureIdParameterName = "customerNoteId",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomerNote"
            },
            // Customer Note Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.CustomerNoteType,
                DataSubjectCamelCaseName = "customerNoteType",
                DataSubjectCreateStoredProcedureName = "spCreateCustomerNoteType",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomerNoteType",
                DataSubjectFriendlyName = "Customer Note Type",
                DataSubjectIdFriendlyName = "Customer Note Type Id",
                DataSubjectIdName = "CustomerNoteTypeId",
                DataSubjectPlural = "Customer Note Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCustomerNoteType",
                DataSubjectSelectStoredProcedureName = "spGetCustomerNoteType",
                DataSubjectSortingColumnName = "Customer Note Type",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "customerNoteTypeId",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomerNoteType"
            },
            // Customer Tier
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.CustomerTier,
                DataSubjectCamelCaseName = "customerTier",
                DataSubjectCreateStoredProcedureName = "spCreateCustomerTier",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomerTier",
                DataSubjectFriendlyName = "Customer Tier",
                DataSubjectIdFriendlyName = "Customer Tier Id",
                DataSubjectIdName = "CustomerTierId",
                DataSubjectPlural = "Customer Tiers",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCustomerTier",
                DataSubjectSelectStoredProcedureName = "spGetCustomerTier",
                DataSubjectSortingColumnName = "Customer Tier Description",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "customerTierId",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomerTier"
            },
            // Customer Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.CustomerType,
                DataSubjectCamelCaseName = "customerType",
                DataSubjectCreateStoredProcedureName = "spCreateCustomerType",
                DataSubjectDeleteStoredProcedureName = "spDeleteCustomerType",
                DataSubjectFriendlyName = "Customer Type",
                DataSubjectIdFriendlyName = "Customer Type Id",
                DataSubjectIdName = "CustomerTypeId",
                DataSubjectPlural = "Customer Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllCustomerType",
                DataSubjectSelectStoredProcedureName = "spGetCustomerType",
                DataSubjectSortingColumnName = "Customer Type",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "customerTypeId",
                DataSubjectUpdateStoredProcedureName = "spUpdateCustomerType"
            },
            // Delivery Method
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.DeliveryMethod,
                DataSubjectCamelCaseName = "deliveryMethod",
                DataSubjectCreateStoredProcedureName = "spCreateDeliveryMethod",
                DataSubjectDeleteStoredProcedureName = "spDeleteDeliveryMethod",
                DataSubjectFriendlyName = "Delivery Method",
                DataSubjectIdFriendlyName = "Delivery Method Id",
                DataSubjectIdName = "DeliveryMethodId",
                DataSubjectPlural = "Delivery Methods",
                DataSubjectSelectAllStoredProcedureName = "spGetAllDeliveryMethod",
                DataSubjectSelectStoredProcedureName = "spGetDeliveryMethod",
                DataSubjectSortingColumnName = "Delivery Method",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "deliveryMethodId",
                DataSubjectUpdateStoredProcedureName = "spUpdateDeliveryMethod"
            },
            // Global Parent Customer
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.GlobalParentCustomer,
                DataSubjectCamelCaseName = "globalParentCustomer",
                DataSubjectFriendlyName = "Global Parent Customer",
                DataSubjectPlural = "Global Parent Customers",
                DataSubjectSelectAllStoredProcedureName = "spGetAllGlobalParentCustomer",
                DataSubjectSortingColumnName = "Customer Id",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC
            },
            // HTML Template
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.HTMLTemplate,
                DataSubjectCamelCaseName = "htmlTemplate",
                DataSubjectCreateStoredProcedureName = "spCreateHTMLTemplate",
                DataSubjectDeleteStoredProcedureName = "spDeleteHTMLTemplate",
                DataSubjectFriendlyName = "HTML Template",
                DataSubjectIdFriendlyName = "HTML Template Id",
                DataSubjectIdName = "HTMLTemplateId",
                DataSubjectPlural = "HTML Templates",
                DataSubjectSelectAllStoredProcedureName = "spGetAllHTMLTemplate",
                DataSubjectSelectStoredProcedureName = "spGetHTMLTemplate",
                DataSubjectSortingColumnName = "HTML Template Title",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "htmlTemplateId",
                DataSubjectUpdateStoredProcedureName = "spUpdateHTMLTemplate"
            },
            // HTML Template Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.HTMLTemplateType,
                DataSubjectCamelCaseName = "htmlTemplateType",
                DataSubjectCreateStoredProcedureName = "spCreateHTMLTemplateType",
                DataSubjectDeleteStoredProcedureName = "spDeleteHTMLTemplateType",
                DataSubjectFriendlyName = "HTML Template Type",
                DataSubjectIdFriendlyName = "HTML Template Type Id",
                DataSubjectIdName = "HTMLTemplateTypeId",
                DataSubjectPlural = "HTML Template Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllHTMLTemplateType",
                DataSubjectSelectStoredProcedureName = "spGetHTMLTemplateType",
                DataSubjectSortingColumnName = "HTML Template Type",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "htmlTemplateTypeId",
                DataSubjectUpdateStoredProcedureName = "spUpdateHTMLTemplateType"
            },
            // Manufacturer
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.Manufacturer,
                DataSubjectCamelCaseName = "manufacturer",
                DataSubjectCreateStoredProcedureName = "spCreateManufacturer",
                DataSubjectDeleteStoredProcedureName = "spDeleteManufacturer",
                DataSubjectFriendlyName = "Manufacturer",
                DataSubjectIdFriendlyName = "Manufacturer Id",
                DataSubjectIdName = "ManufacturerId",
                DataSubjectPlural = "Manufacturers",
                DataSubjectSelectAllStoredProcedureName = "spGetAllManufacturer",
                DataSubjectSelectStoredProcedureName = "spGetManufacturer",
                DataSubjectSortingColumnName = "Manufacturer Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "manufacturerId",
                DataSubjectUpdateStoredProcedureName = "spUpdateManufacturer"
            },
            // Marketing Campaign
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.MarketingCampaign,
                DataSubjectCamelCaseName = "marketingCampaign",
                DataSubjectCreateStoredProcedureName = "spCreateMarketingCampaign",
                DataSubjectDeleteStoredProcedureName = "spDeleteMarketingCampaign",
                DataSubjectFriendlyName = "Marketing Campaign",
                DataSubjectIdFriendlyName = "Marketing Campaign Id",
                DataSubjectIdName = "MarketingCampaignId",
                DataSubjectPlural = "Marketing Campaigns",
                DataSubjectSelectAllStoredProcedureName = "spGetAllMarketingCampaign",
                DataSubjectSelectStoredProcedureName = "spGetMarketingCampaign",
                DataSubjectSortingColumnName = "Marketing Campaign Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "marketingCampaignId",
                DataSubjectUpdateStoredProcedureName = "spUpdateMarketingCampaign"
            },
            // Marketing Campaign Marketing Channel
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.MarketingCampaign,
                DataSubject = FunctionTitle.MarketingCampaignMarketingChannel,
                DataSubjectCamelCaseName = "marketingCampaignMarketingChannel",
                DataSubjectCreateStoredProcedureName = "spCreateMarketingCampaignMarketingChannel",
                DataSubjectDeleteStoredProcedureName = "spDeleteMarketingCampaignMarketingChannel",
                DataSubjectFriendlyName = "Marketing Campaign Marketing Channel",
                DataSubjectIdFriendlyName = "Marketing Campaign Marketing Channel Id",
                DataSubjectIdName = "MarketingCampaignMarketingChannelId",
                DataSubjectPlural = "Marketing Campaign Marketing Channels",
                DataSubjectSelectAllStoredProcedureName = "spGetAllMarketingCampaignMarketingChannelForMarketingCampaign",
                DataSubjectSelectStoredProcedureName = "spGetMarketingCampaignMarketingChannel",
                DataSubjectSortingColumnName = "Marketing Channel Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "marketingCampaignMarketingChannelId",
                DataSubjectUpdateStoredProcedureName = "spUpdateMarketingCampaignMarketingChannel"
            },
            // Marketing Campaign Status
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.MarketingCampaignStatus,
                DataSubjectCamelCaseName = "marketingCampaignStatus",
                DataSubjectCreateStoredProcedureName = "spCreateMarketingCampaignStatus",
                DataSubjectDeleteStoredProcedureName = "spDeleteMarketingCampaignStatus",
                DataSubjectFriendlyName = "Marketing Campaign Status",
                DataSubjectIdFriendlyName = "Marketing Campaign Status Id",
                DataSubjectIdName = "MarketingCampaignStatusId",
                DataSubjectPlural = "Marketing Campaign Statuses",
                DataSubjectSelectAllStoredProcedureName = "spGetAllMarketingCampaignStatus",
                DataSubjectSelectStoredProcedureName = "spGetMarketingCampaignStatus",
                DataSubjectSortingColumnName = "Marketing Campaign Status",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "marketingCampaignStatusId",
                DataSubjectUpdateStoredProcedureName = "spUpdateMarketingCampaignStatus"
            },
            // Marketing Campaign Status History
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.MarketingCampaign,
                DataSubject = FunctionTitle.MarketingCampaignStatusHistory,
                DataSubjectCamelCaseName = "marketingCampaignStatusHistory",
                DataSubjectCreateStoredProcedureName = "spCreateMarketingCampaignStatusHistory",
                DataSubjectDeleteStoredProcedureName = "spDeleteMarketingCampaignStatusHistory",
                DataSubjectFriendlyName = "Marketing Campaign Status History",
                DataSubjectIdFriendlyName = "Marketing Campaign Status History Id",
                DataSubjectIdName = "MarketingCampaignStatusHistoryId",
                DataSubjectPlural = "Marketing Campaign Status Histories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllMarketingCampaignStatusHistoryForMarketingCampaign",
                DataSubjectSelectStoredProcedureName = "spGetMarketingCampaignStatusHistory",
                DataSubjectSortingColumnName = "Created Timestamp UTC",
                DataSubjectSortingColumnOrder = DataSortingOrder.DESC,
                DataSubjectStoredProcedureIdParameterName = "marketingCampaignStatusHistoryId",
                DataSubjectUpdateStoredProcedureName = "spUpdateMarketingCampaignStatusHistory"
            },
            // Marketing Campaign Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.MarketingCampaignType,
                DataSubjectCamelCaseName = "marketingCampaignType",
                DataSubjectCreateStoredProcedureName = "spCreateMarketingCampaignType",
                DataSubjectDeleteStoredProcedureName = "spDeleteMarketingCampaignType",
                DataSubjectFriendlyName = "Marketing Campaign Type",
                DataSubjectIdFriendlyName = "Marketing Campaign Type Id",
                DataSubjectIdName = "MarketingCampaignTypeId",
                DataSubjectPlural = "Marketing Campaign Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllMarketingCampaignType",
                DataSubjectSelectStoredProcedureName = "spGetMarketingCampaignType",
                DataSubjectSortingColumnName = "Marketing Campaign Type",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "marketingCampaignTypeId",
                DataSubjectUpdateStoredProcedureName = "spUpdateMarketingCampaignType"
            },
            // Marketing Channel
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.MarketingChannel,
                DataSubjectCamelCaseName = "marketingChannel",
                DataSubjectCreateStoredProcedureName = "spCreateMarketingChannel",
                DataSubjectDeleteStoredProcedureName = "spDeleteMarketingChannel",
                DataSubjectFriendlyName = "Marketing Channel",
                DataSubjectIdFriendlyName = "Marketing Channel Id",
                DataSubjectIdName = "MarketingChannelId",
                DataSubjectPlural = "Marketing Channels",
                DataSubjectSelectAllStoredProcedureName = "spGetAllMarketingChannel",
                DataSubjectSelectStoredProcedureName = "spGetMarketingChannel",
                DataSubjectSortingColumnName = "Marketing Channel",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "marketingChannelId",
                DataSubjectUpdateStoredProcedureName = "spUpdateMarketingChannel"
            },
            // Order
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.Order,
                DataSubjectCamelCaseName = "order",
                DataSubjectCreateStoredProcedureName = "spCreateOrder",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrder",
                DataSubjectFriendlyName = "Order",
                DataSubjectIdFriendlyName = "Order Id",
                DataSubjectIdName = "OrderId",
                DataSubjectPlural = "Orders",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrder",
                DataSubjectSelectStoredProcedureName = "spGetOrder",
                DataSubjectSortingColumnName = "Created Timestamp UTC",
                DataSubjectSortingColumnOrder = DataSortingOrder.DESC,
                DataSubjectStoredProcedureIdParameterName = "orderId",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrder"
            },
            // Order Invoice
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Order,
                DataSubject = FunctionTitle.OrderInvoice,
                DataSubjectCamelCaseName = "orderInvoice",
                DataSubjectCreateStoredProcedureName = "spCreateOrderInvoice",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderInvoice",
                DataSubjectFriendlyName = "Order Invoice",
                DataSubjectIdFriendlyName = "Order Invoice Id",
                DataSubjectIdName = "OrderInvoiceId",
                DataSubjectPlural = "Order Invoices",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderInvoiceForOrder",
                DataSubjectSelectStoredProcedureName = "spGetOrderInvoice",
                DataSubjectSortingColumnName = "Order Invoice Id",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "orderInvoiceId",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderInvoice"
            },
            // Order Line Item
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Order,
                DataSubject = FunctionTitle.OrderLineItem,
                DataSubjectCamelCaseName = "orderLineItem",
                DataSubjectCreateStoredProcedureName = "spCreateOrderLineItem",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderLineItem",
                DataSubjectFriendlyName = "Order Line Item",
                DataSubjectIdFriendlyName = "Order Line Item Id",
                DataSubjectIdName = "OrderLineItemId",
                DataSubjectPlural = "Order Line Items",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderLineItemForOrder",
                DataSubjectSelectStoredProcedureName = "spGetOrderLineItem",
                DataSubjectSortingColumnName = "Product Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "orderLineItemId",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderLineItem"
            },
            // Order Line Item Delivery
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.OrderLineItem,
                DataSubject = FunctionTitle.OrderLineItemDelivery,
                DataSubjectCamelCaseName = "orderLineItemDelivery",
                DataSubjectCreateStoredProcedureName = "spCreateOrderLineItemDelivery",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderLineItemDelivery",
                DataSubjectFriendlyName = "Order Line Item Delivery",
                DataSubjectIdFriendlyName = "Order Line Item Delivery Id",
                DataSubjectIdName = "OrderLineItemDeliveryId",
                DataSubjectPlural = "Order Line Item Deliveries",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderLineItemDeliveryForOrderLineItem",
                DataSubjectSelectStoredProcedureName = "spGetOrderLineItemDelivery",
                DataSubjectSortingColumnName = "Created Timestamp UTC",
                DataSubjectSortingColumnOrder = DataSortingOrder.DESC,
                DataSubjectStoredProcedureIdParameterName = "orderLineItemDeliveryId",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderLineItemDelivery"
            },
            // Order Line Item Status
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.OrderLineItem,
                DataSubject = FunctionTitle.OrderLineItemStatus,
                DataSubjectCamelCaseName = "orderLineItemStatus",
                DataSubjectCreateStoredProcedureName = "spCreateOrderLineItemStatus",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderLineItemStatus",
                DataSubjectFriendlyName = "Order Line Item Status",
                DataSubjectIdFriendlyName = "Order Line Item Status Id",
                DataSubjectIdName = "OrderLineItemStatusId",
                DataSubjectPlural = "Order Line Item Statuses",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderLineItemStatus",
                DataSubjectSelectStoredProcedureName = "spGetOrderLineItemStatus",
                DataSubjectSortingColumnName = "Order Line Item Status",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "orderLineItemStatusId",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderLineItemStatus"
            },
            // Order Line Item Status History
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.OrderLineItem,
                DataSubject = FunctionTitle.OrderLineItemStatusHistory,
                DataSubjectCamelCaseName = "orderLineItemStatusHistory",
                DataSubjectCreateStoredProcedureName = "spCreateOrderLineItemStatusHistory",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderLineItemStatusHistory",
                DataSubjectFriendlyName = "Order Line Item Status History",
                DataSubjectIdFriendlyName = "Order Line Item Status History Id",
                DataSubjectIdName = "OrderLineItemStatusHistoryId",
                DataSubjectPlural = "Order Line Item Status Histories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderLineItemStatusHistoryForOrderLineItem",
                DataSubjectSelectStoredProcedureName = "spGetOrderLineItemStatusHistory",
                DataSubjectSortingColumnName = "Created Timestamp UTC",
                DataSubjectSortingColumnOrder = DataSortingOrder.DESC,
                DataSubjectStoredProcedureIdParameterName = "orderLineItemStatusHistoryId",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderLineItemStatusHistory"
            },
            // Order Payment
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Order,
                DataSubject = FunctionTitle.OrderPayment,
                DataSubjectCamelCaseName = "orderPayment",
                DataSubjectCreateStoredProcedureName = "spCreateOrderPayment",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderPayment",
                DataSubjectFriendlyName = "Order Payment",
                DataSubjectIdFriendlyName = "Order Payment Id",
                DataSubjectIdName = "OrderPaymentId",
                DataSubjectPlural = "Order Payments",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderPaymentForOrder",
                DataSubjectSelectStoredProcedureName = "spGetOrderPayment",
                DataSubjectSortingColumnName = "Order Id",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "orderPaymentId",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderPayment"
            },
            // Order Payment Status
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.OrderPaymentStatus,
                DataSubjectCamelCaseName = "orderPaymentStatus",
                DataSubjectCreateStoredProcedureName = "spCreateOrderPaymentStatus",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderPaymentStatus",
                DataSubjectFriendlyName = "Order Payment Status",
                DataSubjectIdFriendlyName = "Order Payment Status Id",
                DataSubjectIdName = "OrderPaymentStatusId",
                DataSubjectPlural = "Order Payment Statuses",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderPaymentStatus",
                DataSubjectSelectStoredProcedureName = "spGetOrderPaymentStatus",
                DataSubjectSortingColumnName = "Order Payment Status",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "orderPaymentStatusId",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderPaymentStatus"
            },
            // Order Payment Status History
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.OrderPayment,
                DataSubject = FunctionTitle.OrderPaymentStatusHistory,
                DataSubjectCamelCaseName = "orderPaymentStatusHistory",
                DataSubjectCreateStoredProcedureName = "spCreateOrderPaymentStatusHistory",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderPaymentStatusHistory",
                DataSubjectFriendlyName = "Order Payment Status History",
                DataSubjectIdFriendlyName = "Order Payment Status History Id",
                DataSubjectIdName = "OrderPaymentStatusHistoryId",
                DataSubjectPlural = "Order Payment Status Histories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderPaymentStatusHistoryForOrderPayment",
                DataSubjectSelectStoredProcedureName = "spGetOrderPaymentStatusHistory",
                DataSubjectSortingColumnName = "Created Timestamp UTC",
                DataSubjectSortingColumnOrder = DataSortingOrder.DESC,
                DataSubjectStoredProcedureIdParameterName = "orderPaymentStatusHistoryId",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderPaymentStatusHistory"
            },
            // Order Quote
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Order,
                DataSubject = FunctionTitle.OrderQuote,
                DataSubjectCamelCaseName = "orderQuote",
                DataSubjectCreateStoredProcedureName = "spCreateOrderQuote",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderQuote",
                DataSubjectFriendlyName = "Order Quote",
                DataSubjectIdFriendlyName = "Order Quote Id",
                DataSubjectIdName = "OrderQuoteId",
                DataSubjectPlural = "Order Quotes",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderQuoteForOrder",
                DataSubjectSelectStoredProcedureName = "spGetOrderQuote",
                DataSubjectSortingColumnName = "Created Timestamp UTC",
                DataSubjectSortingColumnOrder = DataSortingOrder.DESC,
                DataSubjectStoredProcedureIdParameterName = "orderQuoteId",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderQuote"
            },
            // Order Status
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.OrderStatus,
                DataSubjectCamelCaseName = "orderStatus",
                DataSubjectCreateStoredProcedureName = "spCreateOrderStatus",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderStatus",
                DataSubjectFriendlyName = "Order Status",
                DataSubjectIdFriendlyName = "Order Status Id",
                DataSubjectIdName = "OrderStatusId",
                DataSubjectPlural = "Order Statuses",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderStatus",
                DataSubjectSelectStoredProcedureName = "spGetOrderStatus",
                DataSubjectSortingColumnName = "Order Status",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "orderStatusId",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderStatus"
            },
            // Order Status History
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Order,
                DataSubject = FunctionTitle.OrderStatusHistory,
                DataSubjectCamelCaseName = "orderStatusHistory",
                DataSubjectCreateStoredProcedureName = "spCreateOrderStatusHistory",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderStatusHistory",
                DataSubjectFriendlyName = "Order Status History",
                DataSubjectIdFriendlyName = "Order Status History Id",
                DataSubjectIdName = "OrderStatusHistoryId",
                DataSubjectPlural = "Order Status Histories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderStatusHistoryForOrder",
                DataSubjectSelectStoredProcedureName = "spGetOrderStatusHistory",
                DataSubjectSortingColumnName = "Created Timestamp UTC",
                DataSubjectSortingColumnOrder = DataSortingOrder.DESC,
                DataSubjectStoredProcedureIdParameterName = "orderStatusHistoryId",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderStatusHistory"
            },
            // Order Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.OrderType,
                DataSubjectCamelCaseName = "orderType",
                DataSubjectCreateStoredProcedureName = "spCreateOrderType",
                DataSubjectDeleteStoredProcedureName = "spDeleteOrderType",
                DataSubjectFriendlyName = "Order Type",
                DataSubjectIdFriendlyName = "Order Type Id",
                DataSubjectIdName = "OrderTypeId",
                DataSubjectPlural = "Order Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllOrderType",
                DataSubjectSelectStoredProcedureName = "spGetOrderType",
                DataSubjectSortingColumnName = "Order Type",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "orderTypeId",
                DataSubjectUpdateStoredProcedureName = "spUpdateOrderType"
            },
            // Payment Method
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.PaymentMethod,
                DataSubjectCamelCaseName = "paymentMethod",
                DataSubjectCreateStoredProcedureName = "spCreatePaymentMethod",
                DataSubjectDeleteStoredProcedureName = "spDeletePaymentMethod",
                DataSubjectFriendlyName = "Payment Method",
                DataSubjectIdFriendlyName = "Payment Method Id",
                DataSubjectIdName = "PaymentMethodId",
                DataSubjectPlural = "Payment Methods",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPaymentMethod",
                DataSubjectSelectStoredProcedureName = "spGetPaymentMethod",
                DataSubjectSortingColumnName = "Payment Method",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "paymentMethodId",
                DataSubjectUpdateStoredProcedureName = "spUpdatePaymentMethod"
            },
            // Product
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.Product,
                DataSubjectCamelCaseName = "product",
                DataSubjectCreateStoredProcedureName = "spCreateProduct",
                DataSubjectDeleteStoredProcedureName = "spDeleteProduct",
                DataSubjectFriendlyName = "Product",
                DataSubjectIdFriendlyName = "Product Id",
                DataSubjectIdName = "ProductId",
                DataSubjectPlural = "Products",
                DataSubjectSelectAllStoredProcedureName = "spGetAllProduct",
                DataSubjectSelectStoredProcedureName = "spGetProduct",
                DataSubjectSortingColumnName = "Product Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "productId",
                DataSubjectUpdateStoredProcedureName = "spUpdateProduct"
            },
            // Product Category
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.ProductCategory,
                DataSubjectCamelCaseName = "productCategory",
                DataSubjectCreateStoredProcedureName = "spCreateProductCategory",
                DataSubjectDeleteStoredProcedureName = "spDeleteProductCategory",
                DataSubjectFriendlyName = "Product Category",
                DataSubjectIdFriendlyName = "Product Category Id",
                DataSubjectIdName = "ProductCategoryId",
                DataSubjectPlural = "Product Categories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllProductCategory",
                DataSubjectSelectStoredProcedureName = "spGetProductCategory",
                DataSubjectSortingColumnName = "Product Category",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "productCategoryId",
                DataSubjectUpdateStoredProcedureName = "spUpdateProductCategory"
            },
            // Product Family
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.ProductFamily,
                DataSubjectCamelCaseName = "productFamily",
                DataSubjectCreateStoredProcedureName = "spCreateProductFamily",
                DataSubjectDeleteStoredProcedureName = "spDeleteProductFamily",
                DataSubjectFriendlyName = "Product Family",
                DataSubjectIdFriendlyName = "Product Family Id",
                DataSubjectIdName = "ProductFamilyId",
                DataSubjectPlural = "Product Families",
                DataSubjectSelectAllStoredProcedureName = "spGetAllProductFamily",
                DataSubjectSelectStoredProcedureName = "spGetProductFamily",
                DataSubjectSortingColumnName = "Product Family",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "productFamilyId",
                DataSubjectUpdateStoredProcedureName = "spUpdateProductFamily"
            },
            // Product Image
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Product,
                DataSubject = FunctionTitle.ProductImage,
                DataSubjectCamelCaseName = "productImage",
                DataSubjectCreateStoredProcedureName = "spCreateProductImage",
                DataSubjectDeleteStoredProcedureName = "spDeleteProductImage",
                DataSubjectFriendlyName = "Product Image",
                DataSubjectIdFriendlyName = "Product Image Id",
                DataSubjectIdName = "ProductImageId",
                DataSubjectPlural = "Product Images",
                DataSubjectSelectAllStoredProcedureName = "spGetAllProductImageForProduct",
                DataSubjectSelectStoredProcedureName = "spGetProductImage",
                DataSubjectSortingColumnName = "Product Image Id",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "productImageId",
                DataSubjectUpdateStoredProcedureName = "spUpdateProductImage"
            },
            // Product Note
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Product,
                DataSubject = FunctionTitle.ProductNote,
                DataSubjectCamelCaseName = "productNote",
                DataSubjectCreateStoredProcedureName = "spCreateProductNote",
                DataSubjectDeleteStoredProcedureName = "spDeleteProductNote",
                DataSubjectFriendlyName = "Product Note",
                DataSubjectIdFriendlyName = "Product Note Id",
                DataSubjectIdName = "ProductNoteId",
                DataSubjectPlural = "Product Notes",
                DataSubjectSelectAllStoredProcedureName = "spGetAllProductNoteForProduct",
                DataSubjectSelectStoredProcedureName = "spGetProductNote",
                DataSubjectSortingColumnName = "Created Timestamp UTC",
                DataSubjectSortingColumnOrder = DataSortingOrder.DESC,
                DataSubjectStoredProcedureIdParameterName = "productNoteId",
                DataSubjectUpdateStoredProcedureName = "spUpdateProductNote"
            },
            // Product Note Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.ProductNoteType,
                DataSubjectCamelCaseName = "productNoteType",
                DataSubjectCreateStoredProcedureName = "spCreateProductNoteType",
                DataSubjectDeleteStoredProcedureName = "spDeleteProductNoteType",
                DataSubjectFriendlyName = "Product Note Type",
                DataSubjectIdFriendlyName = "Product Note Type Id",
                DataSubjectIdName = "ProductNoteTypeId",
                DataSubjectPlural = "Product Note Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllProductNoteType",
                DataSubjectSelectStoredProcedureName = "spGetProductNoteType",
                DataSubjectSortingColumnName = "Product Note Type",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "productNoteTypeId",
                DataSubjectUpdateStoredProcedureName = "spUpdateProductNoteType"
            },
            // Product Sales Sub Region
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Product,
                DataSubject = FunctionTitle.ProductSalesSubRegion,
                DataSubjectCamelCaseName = "productSalesSubRegion",
                DataSubjectCreateStoredProcedureName = "spCreateProductSalesSubRegion",
                DataSubjectDeleteStoredProcedureName = "spDeleteProductSalesSubRegion",
                DataSubjectFriendlyName = "Product Sales Sub Region",
                DataSubjectIdFriendlyName = "Product Sales Sub Region Id",
                DataSubjectIdName = "ProductSalesSubRegionId",
                DataSubjectPlural = "Product Sales Sub Regions",
                DataSubjectSelectAllStoredProcedureName = "spGetAllProductSalesSubRegionForProduct",
                DataSubjectSelectStoredProcedureName = "spGetProductSalesSubRegion",
                DataSubjectSortingColumnName = "Sales Sub Region",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "productSalesSubRegionId",
                DataSubjectUpdateStoredProcedureName = "spUpdateProductSalesSubRegion"
            },
            // Product Sub Category
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.ProductCategory,
                DataSubject = FunctionTitle.ProductSubCategory,
                DataSubjectCamelCaseName = "productSubCategory",
                DataSubjectCreateStoredProcedureName = "spCreateProductSubCategory",
                DataSubjectDeleteStoredProcedureName = "spDeleteProductSubCategory",
                DataSubjectFriendlyName = "Product Sub Category",
                DataSubjectIdFriendlyName = "Product Sub Category Id",
                DataSubjectIdName = "ProductSubCategoryId",
                DataSubjectPlural = "Product Sub Categories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllProductSubCategory",
                DataSubjectSelectStoredProcedureName = "spGetProductSubCategory",
                DataSubjectSortingColumnName = "Product Sub Category",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "productSubCategoryId",
                DataSubjectUpdateStoredProcedureName = "spUpdateProductSubCategory"
            },
            // Product Supplier
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Product,
                DataSubject = FunctionTitle.ProductSupplier,
                DataSubjectCamelCaseName = "productSupplier",
                DataSubjectCreateStoredProcedureName = "spCreateProductSupplier",
                DataSubjectDeleteStoredProcedureName = "spDeleteProductSupplier",
                DataSubjectFriendlyName = "Product Supplier",
                DataSubjectIdFriendlyName = "Product Supplier Id",
                DataSubjectIdName = "ProductSupplierId",
                DataSubjectPlural = "Product Suppliers",
                DataSubjectSelectAllStoredProcedureName = "spGetAllProductSupplierForProduct",
                DataSubjectSelectStoredProcedureName = "spGetProductSupplier",
                DataSubjectSortingColumnName = "Supplier Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "productSupplierId",
                DataSubjectUpdateStoredProcedureName = "spUpdateProductSupplier"
            },
            // Promotion
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.MarketingCampaign,
                DataSubject = FunctionTitle.Promotion,
                DataSubjectCamelCaseName = "promotion",
                DataSubjectCreateStoredProcedureName = "spCreatePromotion",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotion",
                DataSubjectFriendlyName = "Promotion",
                DataSubjectIdFriendlyName = "Promotion Id",
                DataSubjectIdName = "PromotionId",
                DataSubjectPlural = "Promotions",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionForMarketingCampaign",
                DataSubjectSelectStoredProcedureName = "spGetPromotion",
                DataSubjectSortingColumnName = "Promotion Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "promotionId",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotion"
            },
            // Promotion Manufacturer
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Promotion,
                DataSubject = FunctionTitle.PromotionManufacturer,
                DataSubjectCamelCaseName = "promotionManufacturer",
                DataSubjectCreateStoredProcedureName = "spCreatePromotionManufacturer",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionManufacturer",
                DataSubjectFriendlyName = "Promotion Manufacturer",
                DataSubjectIdFriendlyName = "Promotion Manufacturer Id",
                DataSubjectIdName = "PromotionManufacturerId",
                DataSubjectPlural = "Promotion Manufacturers",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionManufacturerForPromotion",
                DataSubjectSelectStoredProcedureName = "spGetPromotionManufacturer",
                DataSubjectSortingColumnName = "Promotion Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "promotionManufacturerId",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionManufacturer"
            },
            // Promotion Manufacturer Product Category
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.PromotionManufacturer,
                DataSubject = FunctionTitle.PromotionManufacturerProductCategory,
                DataSubjectCamelCaseName = "promotionManufacturerProductCategory",
                DataSubjectCreateStoredProcedureName = "spCreatePromotionManufacturerProductCategory",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionManufacturerProductCategory",
                DataSubjectFriendlyName = "Promotion Manufacturer Product Category",
                DataSubjectIdFriendlyName = "Promotion Manufacturer Product Category Id",
                DataSubjectIdName = "PromotionManufacturerProductCategoryId",
                DataSubjectPlural = "Promotion Manufacturer Product Categories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionManufacturerProductCategoryForPromotion",
                DataSubjectSelectStoredProcedureName = "spGetPromotionManufacturerProductCategory",
                DataSubjectSortingColumnName = "Promotion Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "promotionManufacturerProductCategoryId",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionManufacturerProductCategory"
            },
            // Promotion Manufacturer Product Sub Category
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.PromotionManufacturer,
                DataSubject = FunctionTitle.PromotionManufacturerProductSubCategory,
                DataSubjectCamelCaseName = "promotionManufacturerProductSubCategory",
                DataSubjectCreateStoredProcedureName = "spCreatePromotionManufacturerProductSubCategory",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionManufacturerProductSubCategory",
                DataSubjectFriendlyName = "Promotion Manufacturer Product Sub Category",
                DataSubjectIdFriendlyName = "Promotion Manufacturer Product Sub Category Id",
                DataSubjectIdName = "PromotionManufacturerProductSubCategoryId",
                DataSubjectPlural = "Promotion Manufacturer Product Sub Categories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionManufacturerProductSubCategoryForPromotion",
                DataSubjectSelectStoredProcedureName = "spGetPromotionManufacturerProductSubCategory",
                DataSubjectSortingColumnName = "Promotion Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "promotionManufacturerProductSubCategoryId",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionManufacturerProductSubCategory"
            },
            // Promotion Product
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Promotion,
                DataSubject = FunctionTitle.PromotionProduct,
                DataSubjectCamelCaseName = "promotionProduct",
                DataSubjectCreateStoredProcedureName = "spCreatePromotionProduct",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionProduct",
                DataSubjectFriendlyName = "Promotion Product",
                DataSubjectIdFriendlyName = "Promotion Product Id",
                DataSubjectIdName = "PromotionProductId",
                DataSubjectPlural = "Promotion Products",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionProductForPromotion",
                DataSubjectSelectStoredProcedureName = "spGetPromotionProduct",
                DataSubjectSortingColumnName = "Promotion Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "promotionProductId",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionProduct"
            },
            // Promotion Product Category
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Promotion,
                DataSubject = FunctionTitle.PromotionProductCategory,
                DataSubjectCamelCaseName = "promotionProductCategory",
                DataSubjectCreateStoredProcedureName = "spCreatePromotionProductCategory",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionProductCategory",
                DataSubjectFriendlyName = "Promotion Product Category",
                DataSubjectIdFriendlyName = "Promotion Product Category Id",
                DataSubjectIdName = "PromotionProductCategoryId",
                DataSubjectPlural = "Promotion Product Categories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionProductCategoryForPromotion",
                DataSubjectSelectStoredProcedureName = "spGetPromotionProductCategory",
                DataSubjectSortingColumnName = "Promotion Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "promotionProductCategoryId",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionProductCategory"
            },
            // Promotion Product Family
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Promotion,
                DataSubject = FunctionTitle.PromotionProductFamily,
                DataSubjectCamelCaseName = "promotionProductFamily",
                DataSubjectCreateStoredProcedureName = "spCreatePromotionProductFamily",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionProductFamily",
                DataSubjectFriendlyName = "Promotion Product Family",
                DataSubjectIdFriendlyName = "Promotion Product Family Id",
                DataSubjectIdName = "PromotionProductFamilyId",
                DataSubjectPlural = "Promotion Product Families",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionProductFamilyForPromotion",
                DataSubjectSelectStoredProcedureName = "spGetPromotionProductFamily",
                DataSubjectSortingColumnName = "Promotion Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "promotionProductFamilyId",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionProductFamily"
            },
            // Promotion Product Sub Category
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Promotion,
                DataSubject = FunctionTitle.PromotionProductSubCategory,
                DataSubjectCamelCaseName = "promotionProductSubCategory",
                DataSubjectCreateStoredProcedureName = "spCreatePromotionProductSubCategory",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionProductSubCategory",
                DataSubjectFriendlyName = "Promotion Product Sub Category",
                DataSubjectIdFriendlyName = "Promotion Product Sub Category Id",
                DataSubjectIdName = "PromotionProductSubCategoryId",
                DataSubjectPlural = "Promotion Product Sub Categories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionProductSubCategoryForPromotion",
                DataSubjectSelectStoredProcedureName = "spGetPromotionProductSubCategory",
                DataSubjectSortingColumnName = "Promotion Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "promotionProductSubCategoryId",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionProductSubCategory"
            },
            // Promotion Supplier
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Promotion,
                DataSubject = FunctionTitle.PromotionSupplier,
                DataSubjectCamelCaseName = "promotionSupplier",
                DataSubjectCreateStoredProcedureName = "spCreatePromotionSupplier",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionSupplier",
                DataSubjectFriendlyName = "Promotion Supplier",
                DataSubjectIdFriendlyName = "Promotion Supplier Id",
                DataSubjectIdName = "PromotionSupplierId",
                DataSubjectPlural = "Promotion Suppliers",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionSupplierForPromotion",
                DataSubjectSelectStoredProcedureName = "spGetPromotionSupplier",
                DataSubjectSortingColumnName = "Promotion Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "promotionSupplierId",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionSupplier"
            },
            // Promotion Supplier Product Category
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.PromotionSupplier,
                DataSubject = FunctionTitle.PromotionSupplierProductCategory,
                DataSubjectCamelCaseName = "promotionSupplierProductCategory",
                DataSubjectCreateStoredProcedureName = "spCreatePromotionSupplierProductCategory",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionSupplierProductCategory",
                DataSubjectFriendlyName = "Promotion Supplier Product Category",
                DataSubjectIdFriendlyName = "Promotion Supplier Product Category Id",
                DataSubjectIdName = "PromotionSupplierProductCategoryId",
                DataSubjectPlural = "Promotion Supplier Product Categories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionSupplierProductCategoryForPromotion",
                DataSubjectSelectStoredProcedureName = "spGetPromotionSupplierProductCategory",
                DataSubjectSortingColumnName = "Promotion Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "promotionSupplierProductCategoryId",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionSupplierProductCategory"
            },
            // Promotion Supplier Product Sub Category
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.PromotionSupplier,
                DataSubject = FunctionTitle.PromotionSupplierProductSubCategory,
                DataSubjectCamelCaseName = "promotionSupplierProductSubCategory",
                DataSubjectCreateStoredProcedureName = "spCreatePromotionSupplierProductSubCategory",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionSupplierProductSubCategory",
                DataSubjectFriendlyName = "Promotion Supplier Product Sub Category",
                DataSubjectIdFriendlyName = "Promotion Supplier Product Sub Category Id",
                DataSubjectIdName = "PromotionSupplierProductSubCategoryId",
                DataSubjectPlural = "Promotion Supplier Product Sub Categories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionSupplierProductSubCategoryForPromotion",
                DataSubjectSelectStoredProcedureName = "spGetPromotionSupplierProductSubCategory",
                DataSubjectSortingColumnName = "Promotion Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "promotionSupplierProductSubCategoryId",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionSupplierProductSubCategory"
            },
            // Promotion Target Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.PromotionTargetType,
                DataSubjectCamelCaseName = "promotionTargetType",
                DataSubjectCreateStoredProcedureName = "spCreatePromotionTargetType",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionTargetType",
                DataSubjectFriendlyName = "Promotion Target Type",
                DataSubjectIdFriendlyName = "Promotion Target Type Id",
                DataSubjectIdName = "PromotionTargetTypeId",
                DataSubjectPlural = "Promotion Target Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionTargetType",
                DataSubjectSelectStoredProcedureName = "spGetPromotionTargetType",
                DataSubjectSortingColumnName = "Promotion Target Type",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "promotionTargetTypeId",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionTargetType"
            },
            // Promotion Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.PromotionType,
                DataSubjectCamelCaseName = "promotionType",
                DataSubjectCreateStoredProcedureName = "spCreatePromotionType",
                DataSubjectDeleteStoredProcedureName = "spDeletePromotionType",
                DataSubjectFriendlyName = "Promotion Type",
                DataSubjectIdFriendlyName = "Promotion Type Id",
                DataSubjectIdName = "PromotionTypeId",
                DataSubjectPlural = "Promotion Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllPromotionType",
                DataSubjectSelectStoredProcedureName = "spGetPromotionType",
                DataSubjectSortingColumnName = "Promotion Type",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "promotionTypeId",
                DataSubjectUpdateStoredProcedureName = "spUpdatePromotionType"
            },
            // Sales Region
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.SalesRegion,
                DataSubjectCamelCaseName = "salesRegion",
                DataSubjectCreateStoredProcedureName = "spCreateSalesRegion",
                DataSubjectDeleteStoredProcedureName = "spDeleteSalesRegion",
                DataSubjectFriendlyName = "Sales Region",
                DataSubjectIdFriendlyName = "Sales Region Id",
                DataSubjectIdName = "SalesRegionId",
                DataSubjectPlural = "Sales Regions",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSalesRegion",
                DataSubjectSelectStoredProcedureName = "spGetSalesRegion",
                DataSubjectSortingColumnName = "Sales Region",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "salesRegionId",
                DataSubjectUpdateStoredProcedureName = "spUpdateSalesRegion"
            },
            // Sales Sub Region
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.SalesRegion,
                DataSubject = FunctionTitle.SalesSubRegion,
                DataSubjectCamelCaseName = "salesSubRegion",
                DataSubjectCreateStoredProcedureName = "spCreateSalesSubRegion",
                DataSubjectDeleteStoredProcedureName = "spDeleteSalesSubRegion",
                DataSubjectFriendlyName = "Sales Sub Region",
                DataSubjectIdFriendlyName = "Sales Sub Region Id",
                DataSubjectIdName = "SalesSubRegionId",
                DataSubjectPlural = "Sales Sub Regions",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSalesSubRegionForSalesRegion",
                DataSubjectSelectStoredProcedureName = "spGetSalesSubRegion",
                DataSubjectSortingColumnName = "Sales Sub Region",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "salesSubRegionId",
                DataSubjectUpdateStoredProcedureName = "spUpdateSalesSubRegion"
            },
            // Supplier
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.Supplier,
                DataSubjectCamelCaseName = "supplier",
                DataSubjectCreateStoredProcedureName = "spCreateSupplier",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplier",
                DataSubjectFriendlyName = "Supplier",
                DataSubjectIdFriendlyName = "Supplier Id",
                DataSubjectIdName = "SupplierId",
                DataSubjectPlural = "Suppliers",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplier",
                DataSubjectSelectStoredProcedureName = "spGetSupplier",
                DataSubjectSortingColumnName = "Supplier Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "supplierId",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplier"
            },
            // Supplier Contact
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Supplier,
                DataSubject = FunctionTitle.SupplierContact,
                DataSubjectCamelCaseName = "supplierContact",
                DataSubjectCreateStoredProcedureName = "spCreateSupplierContact",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierContact",
                DataSubjectFriendlyName = "Supplier Contact",
                DataSubjectIdFriendlyName = "Supplier Contact Id",
                DataSubjectIdName = "SupplierContactId",
                DataSubjectPlural = "Supplier Contacts",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierContactForSupplier",
                DataSubjectSelectStoredProcedureName = "spGetSupplierContact",
                DataSubjectSortingColumnName = "Last Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "supplierContactId",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierContact"
            },
            // Supplier Note
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.Supplier,
                DataSubject = FunctionTitle.SupplierNote,
                DataSubjectCamelCaseName = "supplierNote",
                DataSubjectCreateStoredProcedureName = "spCreateSupplierNote",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierNote",
                DataSubjectFriendlyName = "Supplier Note",
                DataSubjectIdFriendlyName = "Supplier Note Id",
                DataSubjectIdName = "SupplierNoteId",
                DataSubjectPlural = "Supplier Notes",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierNoteForSupplier",
                DataSubjectSelectStoredProcedureName = "spGetSupplierNote",
                DataSubjectSortingColumnName = "Created Timestamp UTC",
                DataSubjectSortingColumnOrder = DataSortingOrder.DESC,
                DataSubjectStoredProcedureIdParameterName = "supplierNoteId",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierNote"
            },
            // Supplier Note Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.SupplierNoteType,
                DataSubjectCamelCaseName = "supplierNoteType",
                DataSubjectCreateStoredProcedureName = "spCreateSupplierNoteType",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierNoteType",
                DataSubjectFriendlyName = "Supplier Note Type",
                DataSubjectIdFriendlyName = "Supplier Note Type Id",
                DataSubjectIdName = "SupplierNoteTypeId",
                DataSubjectPlural = "Supplier Note Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierNoteType",
                DataSubjectSelectStoredProcedureName = "spGetSupplierNoteType",
                DataSubjectSortingColumnName = "Supplier Note Type",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "supplierNoteTypeId",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierNoteType"
            },
            // Supplier Order
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.SupplierOrder,
                DataSubjectCamelCaseName = "supplierOrder",
                DataSubjectCreateStoredProcedureName = "spCreateSupplierOrder",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierOrder",
                DataSubjectFriendlyName = "Supplier Order",
                DataSubjectIdFriendlyName = "Supplier Order Id",
                DataSubjectIdName = "SupplierOrderId",
                DataSubjectPlural = "Supplier Orders",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierOrder",
                DataSubjectSelectStoredProcedureName = "spGetSupplierOrder",
                DataSubjectSortingColumnName = "Created Timestamp UTC",
                DataSubjectSortingColumnOrder = DataSortingOrder.DESC,
                DataSubjectStoredProcedureIdParameterName = "supplierOrderId",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrder"
            },
            // Supplier Order Line Item
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.SupplierOrder,
                DataSubject = FunctionTitle.SupplierOrderLineItem,
                DataSubjectCamelCaseName = "supplierOrderLineItem",
                DataSubjectCreateStoredProcedureName = "spCreateSupplierOrderLineItem",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierOrderLineItem",
                DataSubjectFriendlyName = "Supplier Order Line Item",
                DataSubjectIdFriendlyName = "Supplier Order Line Item Id",
                DataSubjectIdName = "SupplierOrderLineItemId",
                DataSubjectPlural = "Supplier Order Line Items",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierOrderLineItemForSupplierOrder",
                DataSubjectSelectStoredProcedureName = "spGetSupplierOrderLineItem",
                DataSubjectSortingColumnName = "Product Name",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "supplierOrderLineItemId",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrderLineItem"
            },
            // Supplier Order Line Item Status
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.SupplierOrderLineItemStatus,
                DataSubjectCamelCaseName = "supplierOrderLineItemStatus",
                DataSubjectCreateStoredProcedureName = "spCreateSupplierOrderLineItemStatus",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierOrderLineItemStatus",
                DataSubjectFriendlyName = "Supplier Order Line Item Status",
                DataSubjectIdFriendlyName = "Supplier Order Line Item Status Id",
                DataSubjectIdName = "SupplierOrderLineItemStatusId",
                DataSubjectPlural = "Supplier Order Line Item Statuses",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierOrderLineItemStatus",
                DataSubjectSelectStoredProcedureName = "spGetSupplierOrderLineItemStatus",
                DataSubjectSortingColumnName = "Supplier Order Line Item Status",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "supplierOrderLineItemStatusId",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrderLineItemStatus"
            },
            // Supplier Order Line Item Status History
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.SupplierOrderLineItem,
                DataSubject = FunctionTitle.SupplierOrderLineItemStatusHistory,
                DataSubjectCamelCaseName = "supplierOrderLineItemStatusHistory",
                DataSubjectCreateStoredProcedureName = "spCreateSupplierOrderLineItemStatusHistory",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierOrderLineItemStatusHistory",
                DataSubjectFriendlyName = "Supplier Order Line Item Status History",
                DataSubjectIdFriendlyName = "Supplier Order Line Item Status History Id",
                DataSubjectIdName = "SupplierOrderLineItemStatusHistoryId",
                DataSubjectPlural = "Supplier Order Line Item Status Histories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierOrderLineItemStatusHistoryForOrderLineItem",
                DataSubjectSelectStoredProcedureName = "spGetSupplierOrderLineItemStatusHistory",
                DataSubjectSortingColumnName = "Created Timestamp UTC",
                DataSubjectSortingColumnOrder = DataSortingOrder.DESC,
                DataSubjectStoredProcedureIdParameterName = "supplierOrderLineItemStatusHistoryId",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrderLineItemStatusHistory"
            },
            // Supplier Order Payment
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.SupplierOrder,
                DataSubject = FunctionTitle.SupplierOrderPayment,
                DataSubjectCamelCaseName = "supplierOrderPayment",
                DataSubjectCreateStoredProcedureName = "spCreateSupplierOrderPayment",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierOrderPayment",
                DataSubjectFriendlyName = "Supplier Order Payment",
                DataSubjectIdFriendlyName = "Supplier Order Payment Id",
                DataSubjectIdName = "SupplierOrderPaymentId",
                DataSubjectPlural = "Supplier Order Payments",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierOrderPaymentForSupplierOrder",
                DataSubjectSelectStoredProcedureName = "spGetSupplierOrderPayment",
                DataSubjectSortingColumnName = "Created Timestamp UTC",
                DataSubjectSortingColumnOrder = DataSortingOrder.DESC,
                DataSubjectStoredProcedureIdParameterName = "supplierOrderPaymentId",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrderPayment"
            },
            // Supplier Order Payment Status
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.SupplierOrderPaymentStatus,
                DataSubjectCamelCaseName = "supplierOrderPaymentStatus",
                DataSubjectCreateStoredProcedureName = "spCreateSupplierOrderPaymentStatus",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierOrderPaymentStatus",
                DataSubjectFriendlyName = "Supplier Order Payment Status",
                DataSubjectIdFriendlyName = "Supplier Order Payment Status Id",
                DataSubjectIdName = "SupplierOrderPaymentStatusId",
                DataSubjectPlural = "Supplier Order Payment Statuses",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierOrderPaymentStatus",
                DataSubjectSelectStoredProcedureName = "spGetSupplierOrderPaymentStatus",
                DataSubjectSortingColumnName = "Supplier Order Payment Status",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "supplierOrderPaymentStatusId",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrderPaymentStatus"
            },
            // Supplier Order Payment Status History
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.SupplierOrderPayment,
                DataSubject = FunctionTitle.SupplierOrderPaymentStatusHistory,
                DataSubjectCamelCaseName = "supplierOrderPaymentStatusHistory",
                DataSubjectCreateStoredProcedureName = "spCreateSupplierOrderPaymentStatusHistory",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierOrderPaymentStatusHistory",
                DataSubjectFriendlyName = "Supplier Order Payment Status History",
                DataSubjectIdFriendlyName = "Supplier Order Payment Status History Id",
                DataSubjectIdName = "SupplierOrderPaymentStatusHistoryId",
                DataSubjectPlural = "Supplier Order Payment Status Histories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierOrderPaymentStatusHistoryForSupplierOrderPayment",
                DataSubjectSelectStoredProcedureName = "spGetSupplierOrderPaymentStatusHistory",
                DataSubjectSortingColumnName = "Created Timestamp UTC",
                DataSubjectSortingColumnOrder = DataSortingOrder.DESC,
                DataSubjectStoredProcedureIdParameterName = "supplierOrderPaymentStatusHistoryId",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrderPaymentStatusHistory"
            },
            // Supplier Order Status
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.SupplierOrderStatus,
                DataSubjectCamelCaseName = "supplierOrderStatus",
                DataSubjectCreateStoredProcedureName = "spCreateSupplierOrderStatus",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierOrderStatus",
                DataSubjectFriendlyName = "Supplier Order Status",
                DataSubjectIdFriendlyName = "Supplier Order Status Id",
                DataSubjectIdName = "SupplierOrderStatusId",
                DataSubjectPlural = "Supplier Order Statuses",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierOrderStatus",
                DataSubjectSelectStoredProcedureName = "spGetSupplierOrderStatus",
                DataSubjectSortingColumnName = "Supplier Order Status",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "supplierOrderStatusId",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrderStatus"
            },
            // Supplier Order Status History
            new DataSubjectModel
            {
                DataParentSubject = FunctionTitle.SupplierOrder,
                DataSubject = FunctionTitle.SupplierOrderStatusHistory,
                DataSubjectCamelCaseName = "supplierOrderStatusHistory",
                DataSubjectCreateStoredProcedureName = "spCreateSupplierOrderStatusHistory",
                DataSubjectDeleteStoredProcedureName = "spDeleteSupplierOrderStatusHistory",
                DataSubjectFriendlyName = "Supplier Order Status History",
                DataSubjectIdFriendlyName = "Supplier Order Status History Id",
                DataSubjectIdName = "SupplierOrderStatusHistoryId",
                DataSubjectPlural = "Supplier Order Status Histories",
                DataSubjectSelectAllStoredProcedureName = "spGetAllSupplierOrderStatusHistoryForSupplierOrder",
                DataSubjectSelectStoredProcedureName = "spGetSupplierOrderStatusHistory",
                DataSubjectSortingColumnName = "Created Timestamp UTC",
                DataSubjectSortingColumnOrder = DataSortingOrder.DESC,
                DataSubjectStoredProcedureIdParameterName = "supplierOrderStatusHistoryId",
                DataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrderStatusHistory"
            },
            // Tax Profile
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.TaxProfile,
                DataSubjectCamelCaseName = "taxProfile",
                DataSubjectCreateStoredProcedureName = "spCreateTaxProfile",
                DataSubjectDeleteStoredProcedureName = "spDeleteTaxProfile",
                DataSubjectFriendlyName = "Tax Profile",
                DataSubjectIdFriendlyName = "Tax Profile Id",
                DataSubjectIdName = "TaxProfileId",
                DataSubjectPlural = "Tax Profiles",
                DataSubjectSelectAllStoredProcedureName = "spGetAllTaxProfile",
                DataSubjectSelectStoredProcedureName = "spGetTaxProfile",
                DataSubjectSortingColumnName = "Tax Profile",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "taxProfileId",
                DataSubjectUpdateStoredProcedureName = "spUpdateTaxProfile"
            },
            // Top Parent Customer
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.TopParentCustomer,
                DataSubjectCamelCaseName = "topParentCustomer",
                DataSubjectFriendlyName = "Top Parent Customer",
                DataSubjectPlural = "Top Parent Customers",
                DataSubjectSelectAllStoredProcedureName = "spGetAllTopParentCustomer",
                DataSubjectSortingColumnName = "Customer Id",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC
            },
            // Wholesale Delivery Type
            new DataSubjectModel
            {
                DataSubject = FunctionTitle.WholesaleDeliveryType,
                DataSubjectCamelCaseName = "wholesaleDeliveryType",
                DataSubjectCreateStoredProcedureName = "spCreateWholesaleDeliveryType",
                DataSubjectDeleteStoredProcedureName = "spDeleteWholesaleDeliveryType",
                DataSubjectFriendlyName = "Wholesale Delivery Type",
                DataSubjectIdFriendlyName = "Wholesale Delivery Type Id",
                DataSubjectIdName = "WholesaleDeliveryTypeId",
                DataSubjectPlural = "Wholesale Delivery Types",
                DataSubjectSelectAllStoredProcedureName = "spGetAllWholesaleDeliveryType",
                DataSubjectSelectStoredProcedureName = "spGetWholesaleDeliveryType",
                DataSubjectSortingColumnName = "Wholesale Delivery Type",
                DataSubjectSortingColumnOrder = DataSortingOrder.ASC,
                DataSubjectStoredProcedureIdParameterName = "wholesaleDeliveryTypeId",
                DataSubjectUpdateStoredProcedureName = "spUpdateWholesaleDeliveryType"
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

    public class DataSubjectLookupResultModel
    {
        public DataSubjectModel DataSubject { get; set; }
        public DataSubjectModel? DataParentSubject { get; set; }
    }

    public class DataSubjectModel
    {
        public FunctionTitle? DataParentSubject { get; set; }
        public FunctionTitle DataSubject { get; set; }
        public string DataSubjectCamelCaseName { get; set; }
        public string? DataSubjectCreateStoredProcedureName { get; set; }
        public string? DataSubjectDeleteStoredProcedureName { get; set; }
        public string DataSubjectFriendlyName { get; set; }
        public string? DataSubjectIdFriendlyName { get; set; }
        public string? DataSubjectIdName { get; set; }
        public string DataSubjectPlural { get; set; }
        public string DataSubjectSelectAllStoredProcedureName { get; set; }
        public string? DataSubjectSelectStoredProcedureName { get; set; }
        public string DataSubjectSortingColumnName { get; set; }
        public DataSortingOrder DataSubjectSortingColumnOrder { get; set; }
        public string? DataSubjectStoredProcedureIdParameterName { get; set; }
        public string? DataSubjectUpdateStoredProcedureName { get; set; }
    }

    public class ModuleGroupFriendlyNameModel
    {
        public ModuleGroup ModuleGroup { get; set; }
        public string ModuleGroupDataSubjectName { get; set; }
        public string ModuleGroupDataSubjectPluralName { get; set; }
        public string ModuleGroupFriendlyName { get; set; }
    }
}