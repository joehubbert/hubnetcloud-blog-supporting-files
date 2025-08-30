using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CompanyManagement : Form
    {
        private Guid _companyConfigurationId;
        private ActiveCompanyConfigurationHelper? _companyConfigHelper;

        public CompanyManagement()
        {
            InitializeComponent();
            LoadActiveCompanyConfigurationAsync();
        }

        private async void LoadActiveCompanyConfigurationAsync()
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(companyManagementStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.LoadAsync();
        }

        private void companyManagementTabControlCompanyConfigurationTabPageTabControlCompanyConfigurationTabPageCreateCompanyConfigurationButton_Click(object sender, EventArgs e)
        {
            CreateCompanyConfiguration createCompanyConfiguration = new CreateCompanyConfiguration();
            createCompanyConfiguration.Show();
        }

        private void companyManagementTabControlCompanyConfigurationTabPageTabControlCompanyConfigurationTabPageSetActiveCompanyConfigrationButton_Click(object sender, EventArgs e)
        {
            ActiveCompanyConfiguration activeCompanyConfiguration = new ActiveCompanyConfiguration();
            activeCompanyConfiguration.Show();
        }

        private void companyManagementTabControlCompanyConfigurationTabPageTabControlCompanyConfigurationTabPageViewAllCompanyConfigurationButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("CompanyConfiguration", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlAccountManagementTabPageTabControlAccountManagerTabPageCreateAccountManagerButton_Click(object sender, EventArgs e)
        {
            CreateAccountManager createAccountManager = new CreateAccountManager();
            createAccountManager.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlAccountManagementTabPageTabControlAccountManagerTabPageViewAllAccountManagerButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("AccountManager", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerLeadNoteTypeTabPageCreateCustomerLeadNoteType_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("CustomerLeadNoteType", "CustomerManagement");
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerLeadNoteTypeTabPageViewAllCustomerLeadNoteType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("CustomerLeadNoteType", "CustomerManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerLeadStatusTabPageCreateCustomerLeadStatusButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("CustomerLeadStatus", "CustomerManagement");
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerLeadStatusTabPageViewAllCustomerLeadStatusButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("CustomerLeadStatus", "CustomerManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerLeadTypeTabPageCreateCustomerLeadTypeButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataEnhanced createMasterDataEnhanced = new CreateMasterDataEnhanced("CustomerLeadType", "CustomerManagement");
            createMasterDataEnhanced.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerLeadTypeTabPageViewAllCustomerLeadTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("CustomerLeadType", "CustomerManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerNoteTypeTabPageCreateCustomerNoteTypeButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("CustomerNoteType", "CustomerManagement");
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerNoteTypeTabPageViewAllCustomerNoteTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("CustomerNoteType", "CustomerManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerTierTabPageCreateCustomerTierButton_Click(object sender, EventArgs e)
        {
            CreateCustomerTier createCustomerTier = new CreateCustomerTier();
            createCustomerTier.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerTierTabPageViewAllCustomerTierButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("CustomerTier", "CustomerManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerTypeTabPageCreateCustomerTypeButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataEnhanced createMasterDataEnhanced = new CreateMasterDataEnhanced("CustomerType", "CustomerManagement");
            createMasterDataEnhanced.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerTypeTabPageViewAllCustomerTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("CustomerType", "CustomerManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlCurrencyTabPageCreateCurrencyButton_Click(object sender, EventArgs e)
        {
            CreateCurrency createCurrency = new CreateCurrency();
            createCurrency.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlCurrencyTabPageViewAllCurrencyButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("Currency", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlCurrencyConversionTabPageCreateCurrencyConversionButton_Click(object sender, EventArgs e)
        {
            CreateCurrencyConversion createCurrencyConversion = new CreateCurrencyConversion();
            createCurrencyConversion.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlCurrencyConversionTabPageViewAllCurrencyConversionButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("CurrencyConversion", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlPaymentMethodTabPageCreatePaymentMethodButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("PaymentMethod", "CompanyManagement");
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlPaymentMethodTabPageViewAllPaymentMethodButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("PaymentMethod", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlTaxProfileTabPageCreateTaxProfileButton_Click(object sender, EventArgs e)
        {
            CreateTaxProfile createTaxProfile = new CreateTaxProfile();
            createTaxProfile.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlTaxProfileTabPageViewAllTaxProfileButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("TaxProfile", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlLogisticsTabPageTabControlDeliveryMethodTabPageCreateDeliveryMethodButton_Click(object sender, EventArgs e)
        {
            CreateDeliveryMethod createDeliveryMethod = new CreateDeliveryMethod();
            createDeliveryMethod.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlLogisticsTabPageTabControlDeliveryMethodTabPageViewAllDeliveryMethodButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("DeliveryMethod", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMarketingTabPageTabControlMarketingCampaignStatusTabPageCreateMarketingCampaignStatusButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("MarketingCampaignStatus", "MarketingManagement");
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMarketingTabPageTabControlMarketingCampaignStatusTabPageViewAllMarketingCampaignStatusButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("MarketingCampaignStatus", "MarketingManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMarketingTabPageTabControlMarketingCampaignTypeTabPageCreateMarketingCampaignTypeButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("MarketingCampaignType", "MarketingManagement");
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMarketingTabPageTabControlMarketingCampaignTypeTabPageViewAllMarketingCampaignTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("MarketingCampaignType", "MarketingManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMarketingTabPageTabControlMarketingChannelTabPageCreateMarketingChannelButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("MarketingChannel", "MarketingManagement");
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMarketingTabPageTabControlMarketingChannelTabPageViewAllMarketingChannelButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("MarketingChannel", "MarketingManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlPromotionTargetTypeTabPageCreatePromotionTargetTypeButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataEnhanced createMasterDataEnhanced = new CreateMasterDataEnhanced("PromotionTargetType", "MarketingManagement");
            createMasterDataEnhanced.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlPromotionTargetTypeTabPageViewAllPromotionTargetType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("PromotionTargetType", "MarketingManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMarketingTabPageTabControlPromotionTypeTabPageCreatePromotionTypeButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("PromotionType", "MarketingManagement");
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMarketingTabPageTabControlPromotionTypeTabPageViewAllPromotionTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("PromotionType", "MarketingManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMiscellaneousTabPageTabControlCountryTabPageCreateCountryButton_Click(object sender, EventArgs e)
        {
            CreateCountry createCountry = new CreateCountry();
            createCountry.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMiscellaneousTabPageTabControlCountryTabPageViewAllCountryButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("Country", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMiscellaneousTabPageTabControlHTMLTemplateTypeTabPageCreateHTMLTemplateTypeButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("HTMLTemplateType", "CompanyManagement");
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMiscellaneousTabPageTabControlHTMLTemplateTypeTabPageViewAllHTMLTemplateTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("HTMLTemplateType", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlOrderTabPageTabControlOrderLineItemStatusTabPageCreateOrderLineItemStatusButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("OrderLineItemStatus", "OrderManagement");
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlOrderTabPageTabControlOrderLineItemStatusTabPageViewAllOrderLineItemStatusButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("OrderLineItemStatus", "OrderManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlOrderTabPageTabControlOrderPaymentStatusTabPageCreateOrderPaymentStatusButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("OrderPaymentStatus", "OrderManagement");
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlOrderTabPageTabControlOrderPaymentStatusTabPageViewAllOrderPaymentStatusButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("OrderPaymentStatus", "OrderManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlOrderTabPageTabControlOrderStatusTabPageCreateOrderStatusButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("OrderStatus", "OrderManagement");
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlOrderTabPageTabControlOrderStatusTabPageViewAllOrderStatusButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("OrderStatus", "OrderManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlOrderTabPageTabControlOrderTypeTabPageCreateOrderTypeButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("OrderType", "OrderManagement");
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlOrderTabPageTabControlOrderTypeTabPageViewAllOrderTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("OrderType", "OrderManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlProductTabPageTabControlProductCategoryTabPageCreateProductCategoryButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("ProductCategory", "ProductManagement");
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlProductTabPageTabControlProductCategoryTabPageViewAllProductCategoryButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("ProductCategory", "ProductManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlProductTabPageTabControlProductFamilyTabPageCreateProductFamilyButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("ProductFamily", "ProductManagement");
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlProductTabPageTabControlProductFamilyTabPageViewAllProductFamilyButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("ProductFamily", "ProductManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlProductTabPageTabControlProductSubCategoryTabPageCreateProductSubCategoryButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataAdvanced createMasterDataAdvanced = new CreateMasterDataAdvanced("ProductSubCategory", "ProductManagement");
            createMasterDataAdvanced.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlProductTabPageTabControlProductSubCategoryTabPageViewAllProductSubCategoryButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("ProductSubCategory", "ProductManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlProductTabPageTabControlProductNoteTypeTabPageCreateProductNoteTypeButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("ProductNoteType", "ProductManagement");
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlProductTabPageTabControlProductNoteTypeTabPageViewAllProductNoteTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("ProductNoteType", "ProductManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControMasterDataManagementTabPagelTabControlSalesGeographyTabPageTabControlSalesRegionTabPageCreateSalesRegionButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("SalesRegion", "CompanyManagement");
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControMasterDataManagementTabPagelTabControlSalesGeographyTabPageTabControlSalesRegionTabPageViewAllSalesRegionButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("SalesRegion", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControMasterDataManagementTabPagelTabControlSalesGeographyTabPageTabControlSalesSubRegionTabPageCreateSalesSubRegionButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataAdvanced createMasterDataAdvanced = new CreateMasterDataAdvanced("SalesSubRegion", "CompanyManagement");
            createMasterDataAdvanced.Show();
        }

        private void companyManagementTabControMasterDataManagementTabPagelTabControlSalesGeographyTabPageTabControlSalesSubRegionTabPageViewAllSalesSubRegionButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("SalesSubRegion", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlSupplierTabPageTabControlSupplierNoteTypeTabPageCreateSupplierNoteTypeButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("SupplierNoteType", "SupplierManagement");
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlSupplierTabPageTabControlSupplierNoteTypeTabPageViewAllSupplierNoteTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("SupplierNoteType", "SupplierManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlSupplierTabPageTabControlSupplierOrderLineItemStatusTabPageCreateSupplierOrderLineItemStatusButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("SupplierOrderLineItemStatus", "SupplierManagement");
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlSupplierTabPageTabControlSupplierOrderLineItemStatusTabPageViewAllSupplierOrderLineItemStatus_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("SupplierOrderLineItemStatus", "SupplierManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlSupplierTabPageTabControlSupplierOrderPaymentStatusTabPageCreateSupplierOrderPaymentStatusButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("SupplierOrderPaymentStatus", "SupplierManagement");
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlSupplierTabPageTabControlSupplierOrderPaymentStatusTabPageViewAllSupplierOrderPaymentStatusButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("SupplierOrderPaymentStatus", "SupplierManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlSupplierTabPageTabControlSupplierOrderStatusTabPageCreateSupplierOrderStatusButtom_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("SupplierOrderStatus", "SupplierManagement");
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlSupplierTabPageTabControlSupplierOrderStatusTabPageViewAllSupplierOrderStatusButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("SupplierOrderStatus", "SupplierManagement", null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlSupplierTabPageTabControlWholesaleDeliveryTypeTabPageCreateWholesaleDeliveryTypeButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("WholesaleDeliveryType", "SupplierManagement");
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlSupplierTabPageTabControlWholesaleDeliveryTypeTabPageViewAllWholesaleDeliveryTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("WholesaleDeliveryType", "SupplierManagement", null);
            viewAllData.Show();
        }

        private async void changeActiveCompanyConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(companyManagementStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.ShowChangeDialogAndReloadAsync(this);
        }
    }
}