namespace CRM_WindowsForms.Presentation
{
    public partial class CompanyAdministration : Form
    {
        public CompanyAdministration()
        {
            InitializeComponent();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlAccountManagementTabPageCreateAccountManagerButton_Click(object sender, EventArgs e)
        {
            CreateAccountManager createAccountManager = new CreateAccountManager();
            createAccountManager.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlAccountManagementTabPageViewAllAccountManagerButton_Click(object sender, EventArgs e)
        {
            ViewAllAccountManager viewAllAccountManager = new ViewAllAccountManager();
            viewAllAccountManager.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlCustomerTabPageCreateCustomerNoteTypeButton_Click(object sender, EventArgs e)
        {
            CreateCustomerNoteType createCustomerNoteType = new CreateCustomerNoteType();
            createCustomerNoteType.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlCustomerTabPageViewAllCustomerNoteTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllCustomerNoteType viewAllCustomerNoteType = new ViewAllCustomerNoteType();
            viewAllCustomerNoteType.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlCustomerTabPageCreateCustomerTierButton_Click(object sender, EventArgs e)
        {
            CreateCustomerTier createCustomerTier = new CreateCustomerTier();
            createCustomerTier.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlCustomerTabPageViewAllCustomerTierButton_Click(object sender, EventArgs e)
        {
            ViewAllCustomerTier viewAllCustomerTier = new ViewAllCustomerTier();
            viewAllCustomerTier.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlCustomerTabPageCreateCustomerTypeButton_Click(object sender, EventArgs e)
        {
            CreateCustomerType createCustomerType = new CreateCustomerType();
            createCustomerType.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlCustomerTabPageViewAllCustomerTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllCustomerType viewAllCustomerType = new ViewAllCustomerType();
            viewAllCustomerType.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlFinanceTabPageCreateCurrencyButton_Click(object sender, EventArgs e)
        {
            CreateCurrency createCurrency = new CreateCurrency();
            createCurrency.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlFinanceTabPageViewAllCurrencyButton_Click(object sender, EventArgs e)
        {
            ViewAllCurrency viewAllCurrency = new ViewAllCurrency();
            viewAllCurrency.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlFinanceTabPageCreatePaymentMethodButton_Click(object sender, EventArgs e)
        {
            CreatePaymentMethod createPaymentMethod = new CreatePaymentMethod();
            createPaymentMethod.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlFinanceTabPageViewAllPaymentMethodButton_Click(object sender, EventArgs e)
        {
            ViewAllPaymentMethod viewAllPaymentMethod = new ViewAllPaymentMethod();
            viewAllPaymentMethod.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlFinanceTabPageCreateTaxProfileButton_Click(object sender, EventArgs e)
        {
            CreateTaxProfile createTaxProfile = new CreateTaxProfile();
            createTaxProfile.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlFinanceTabPageViewAllTaxProfileButton_Click(object sender, EventArgs e)
        {
            ViewAllTaxProfile viewAllTaxProfile = new ViewAllTaxProfile();
            viewAllTaxProfile.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlLogisticsTabPageCreateDeliveryMethodButton_Click(object sender, EventArgs e)
        {
            CreateDeliveryMethod createDeliveryMethod = new CreateDeliveryMethod();
            createDeliveryMethod.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlLogisticsTabPageViewAllDeliveryMethodButton_Click(object sender, EventArgs e)
        {
            ViewAllDeliveryMethod viewAllDeliveryMethod = new ViewAllDeliveryMethod();
            viewAllDeliveryMethod.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlMiscellaneousTabPageCreateOrderStatusButton_Click(object sender, EventArgs e)
        {
            CreateOrderStatus createOrderStatus = new CreateOrderStatus();
            createOrderStatus.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlMiscellaneousTabPageViewAllOrderStatusButton_Click(object sender, EventArgs e)
        {
            ViewAllOrderStatus viewAllOrderStatus = new ViewAllOrderStatus();
            viewAllOrderStatus.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlProductTabPageCreateProductCategoryButton_Click(object sender, EventArgs e)
        {
            CreateProductCategory createProductCategory = new CreateProductCategory();
            createProductCategory.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlProductTabPageViewAllProductCategoryButton_Click(object sender, EventArgs e)
        {
            ViewAllProductCategory viewAllProductCategory = new ViewAllProductCategory();
            viewAllProductCategory.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlProductTabPageCreateProductNoteTypeButton_Click(object sender, EventArgs e)
        {
            CreateProductNoteType createProductNoteType = new CreateProductNoteType();
            createProductNoteType.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlProductTabPageViewAllProductNoteTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllProductNoteType viewAllProductNoteType = new ViewAllProductNoteType();
            viewAllProductNoteType.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlSalesGeographyTabPageCreateSalesRegionButton_Click(object sender, EventArgs e)
        {
            CreateSalesRegion createSalesRegion = new CreateSalesRegion();
            createSalesRegion.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlSalesGeographyTabPageViewAllSalesRegionButton_Click(object sender, EventArgs e)
        {
            ViewAllSalesRegion viewAllSalesRegion = new ViewAllSalesRegion();
            viewAllSalesRegion.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlSalesGeographyTabPageCreateSalesSubRegionButton_Click(object sender, EventArgs e)
        {
            CreateSalesSubRegion createSalesSubRegion = new CreateSalesSubRegion();
            createSalesSubRegion.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlSalesGeographyTabPageViewAllSalesSubRegionButton_Click(object sender, EventArgs e)
        {
            ViewAllSalesSubRegion viewAllSalesSubRegion = new ViewAllSalesSubRegion();
            viewAllSalesSubRegion.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlSupplierTabPageCreateSupplierNoteTypeButton_Click(object sender, EventArgs e)
        {
            CreateSupplierNoteType createSupplierNoteType = new CreateSupplierNoteType();
            createSupplierNoteType.Show();
        }

        private void companyAdministrationTabControlMasterDataManagementTabPageTabControlSupplierTabPageViewAllSupplierNoteTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllSupplierNoteType viewAllSupplierNoteType = new ViewAllSupplierNoteType();
            viewAllSupplierNoteType.Show();
        }
    }
}