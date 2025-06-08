namespace CRM_WindowsForms.Presentation
{
    public partial class CompanyManagement : Form
    {
        public CompanyManagement()
        {
            InitializeComponent();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlAccountManagementTabPageTabControlAccountManagerTabPageCreateAccountManagerButton_Click(object sender, EventArgs e)
        {
            CreateAccountManager createAccountManager = new CreateAccountManager();
            createAccountManager.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlAccountManagementTabPageTabControlAccountManagerTabPageViewAllAccountManagerButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("AccountManager", "CompanyManagement");
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerNoteTabPageCreateCustomerNoteTypeButton_Click(object sender, EventArgs e)
        {
            CreateMetadataSimple createMetadataSimple = new CreateMetadataSimple("CustomerNoteType");
            createMetadataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerNoteTabPageViewAllCustomerNoteTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("CustomerNoteType", "CompanyManagement");
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerTierTabPageCreateCustomerTierButton_Click(object sender, EventArgs e)
        {
            CreateCustomerTier createCustomerTier = new CreateCustomerTier();
            createCustomerTier.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerTierTabPageViewAllCustomerTierButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("CustomerTier", "CompanyManagement");
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerTypeTabPageCreateCustomerTypeButton_Click(object sender, EventArgs e)
        {
            CreateMetadataSimple createMetadataSimple = new CreateMetadataSimple("CustomerType");
            createMetadataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerTypeTabPageViewAllCustomerTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("CustomerType", "CompanyManagement");
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlCurrencyTabPageCreateCurrencyButton_Click(object sender, EventArgs e)
        {
            CreateCurrency createCurrency = new CreateCurrency();
            createCurrency.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlCurrencyTabPageViewAllCurrencyButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("Currency", "CompanyManagement");
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlCurrencyConversionTabPageCreateCurrencyConversionButton_Click(object sender, EventArgs e)
        {
            CreateCurrencyConversion createCurrencyConversion = new CreateCurrencyConversion();
            createCurrencyConversion.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlCurrencyConversionTabPageViewAllCurrencyConversionButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("CurrencyConversion", "CompanyManagement");
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlPaymentMethodTabPageCreatePaymentMethodButton_Click(object sender, EventArgs e)
        {
            CreateMetadataSimple createMetadataSimple = new CreateMetadataSimple("PaymentMethod");
            createMetadataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlPaymentMethodTabPageViewAllPaymentMethodButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("PaymentMethod", "CompanyManagement");
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlTaxProfileTabPageCreateTaxProfileButton_Click(object sender, EventArgs e)
        {
            CreateTaxProfile createTaxProfile = new CreateTaxProfile();
            createTaxProfile.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlTaxProfileTabPageViewAllTaxProfileButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("TaxProfile", "CompanyManagement");
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlLogisticsTabPageTabControlDeliveryMethodTabPageCreateDeliveryMethodButton_Click(object sender, EventArgs e)
        {
            CreateDeliveryMethod createDeliveryMethod = new CreateDeliveryMethod();
            createDeliveryMethod.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlLogisticsTabPageTabControlDeliveryMethodTabPageViewAllDeliveryMethodButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("DeliveryMethod", "CompanyManagement");
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMarketingTabPageTabControlMarketingChannelTabPageCreateMarketingChannelButton_Click(object sender, EventArgs e)
        {
            CreateMetadataSimple createMetadataSimple = new CreateMetadataSimple("MarketingChannel");
            createMetadataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMarketingTabPageTabControlMarketingChannelTabPageViewAllMarketingChannelButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("MarketingChannel", "CompanyManagement");
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlOrderTabPageTabControlOrderLineItemStatusTabPageCreateOrderLineItemStatusButton_Click(object sender, EventArgs e)
        {
            CreateMetadataSimple createMetadataSimple = new CreateMetadataSimple("OrderLineItemStatus");
            createMetadataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlOrderTabPageTabControlOrderStatusTabPageCreateOrderStatusButton_Click(object sender, EventArgs e)
        {
            CreateMetadataSimple createMetadataSimple = new CreateMetadataSimple("OrderStatus");
            createMetadataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlOrderTabPageTabControlOrderLineItemStatusTabPageViewAllOrderLineItemStatusButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("OrderLineItemStatus", "CompanyManagement");
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlOrderTabPageTabControlOrderStatusTabPageViewAllOrderStatusButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("OrderStatus", "CompanyManagement");
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlProductTabPageTabControlProductCategoryTabPageCreateProductCategoryButton_Click(object sender, EventArgs e)
        {
            CreateMetadataSimple createMetadataSimple = new CreateMetadataSimple("ProductCategory");
            createMetadataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlProductTabPageTabControlProductCategoryTabPageViewAllProductCategoryButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("ProductCategory", "CompanyManagement");
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlProductTabPageTabControlProductSubCategoryTabPageCreateProductSubCategoryButton_Click(object sender, EventArgs e)
        {
            CreateMetadataAdvanced createMetadataAdvanced = new CreateMetadataAdvanced("ProductSubCategory");
            createMetadataAdvanced.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlProductTabPageTabControlProductSubCategoryTabPageViewAllProductSubCategoryButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("ProductSubCategory", "CompanyManagement");
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlProductTabPageTabControlProductNoteTypeTabPageCreateProductNoteTypeButton_Click(object sender, EventArgs e)
        {
            CreateMetadataSimple createMetadataSimple = new CreateMetadataSimple("ProductNoteType");
            createMetadataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlProductTabPageTabControlProductNoteTypeTabPageViewAllProductNoteTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("ProductNoteType", "CompanyManagement");
            viewAllData.Show();
        }

        private void companyManagementTabControMasterDataManagementTabPagelTabControlSalesGeographyTabPageTabControlSalesRegionTabPageCreateSalesRegionButton_Click(object sender, EventArgs e)
        {
            CreateMetadataSimple createMetadataSimple = new CreateMetadataSimple("SalesRegion");
            createMetadataSimple.Show();
        }

        private void companyManagementTabControMasterDataManagementTabPagelTabControlSalesGeographyTabPageTabControlSalesRegionTabPageViewAllSalesRegionButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("SalesRegion", "CompanyManagement");
            viewAllData.Show();
        }

        private void companyManagementTabControMasterDataManagementTabPagelTabControlSalesGeographyTabPageTabControlSalesSubRegionTabPageCreateSalesSubRegionButton_Click(object sender, EventArgs e)
        {
            CreateMetadataAdvanced createMetadataAdvanced = new CreateMetadataAdvanced("SalesSubRegion");
            createMetadataAdvanced.Show();
        }

        private void companyManagementTabControMasterDataManagementTabPagelTabControlSalesGeographyTabPageTabControlSalesSubRegionTabPageViewAllSalesSubRegionButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("SalesSubRegion", "CompanyManagement");
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlSupplierTabPageTabControlSupplierNoteTypeTabPageCreateSupplierNoteTypeButton_Click(object sender, EventArgs e)
        {
            CreateMetadataSimple createMetadataSimple = new CreateMetadataSimple("SupplierNoteType");
            createMetadataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlSupplierTabPageTabControlSupplierNoteTypeTabPageViewAllSupplierNoteTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("SupplierNoteType", "CompanyManagement");
            viewAllData.Show();
        }
    }
}