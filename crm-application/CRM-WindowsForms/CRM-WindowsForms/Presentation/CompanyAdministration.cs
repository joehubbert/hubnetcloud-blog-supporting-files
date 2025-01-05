namespace CRM_WindowsForms.Presentation
{
    public partial class CompanyAdministration : Form
    {
        public CompanyAdministration()
        {
            InitializeComponent();
        }

        private void companyAdministrationAccountManagementCreateAccountManagerButton_Click(object sender, EventArgs e)
        {
            CreateAccountManager addNewAccountManager = new CreateAccountManager();
            addNewAccountManager.Show();
        }

        private void companyAdministrationAccountManagementViewAllAccountManagerButton_Click(object sender, EventArgs e)
        {
            ViewAllAccountManager viewAllAccountManager = new ViewAllAccountManager();
            viewAllAccountManager.Show();
        }

        private void companyAdministrationMasterDataManagementCreateCustomerNoteTypeButton_Click(object sender, EventArgs e)
        {
            CreateCustomerNoteType createCustomerNoteType = new CreateCustomerNoteType();
            createCustomerNoteType.Show();
        }

        private void companyAdministrationMasterDataManagementViewAllCustomerNoteTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllCustomerNoteType viewAllCustomerNoteType = new ViewAllCustomerNoteType();
            viewAllCustomerNoteType.Show();
        }

        private void companyAdministrationMasterDataManagementCreateCustomerTierButton_Click(object sender, EventArgs e)
        {
            CreateCustomerTier createCustomerTier = new CreateCustomerTier();
            createCustomerTier.Show();
        }

        private void companyAdministrationMasterDataManagementViewAllCustomerTierButton_Click(object sender, EventArgs e)
        {
            ViewAllCustomerTier viewAllCustomerTier = new ViewAllCustomerTier();
            viewAllCustomerTier.Show();
        }

        private void companyAdministrationMasterDataManagementCreateCustomerTypeButton_Click(object sender, EventArgs e)
        {
            CreateCustomerType createCustomerType = new CreateCustomerType();
            createCustomerType.Show();
        }

        private void companyAdministrationMasterDataManagementViewAllCustomerTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllCustomerType viewAllCustomerType = new ViewAllCustomerType();
            viewAllCustomerType.Show();
        }

        private void companyAdministrationMasterDataManagementCreateDeliveryMethodButton_Click(object sender, EventArgs e)
        {
            CreateDeliveryMethod createDeliveryMethod = new CreateDeliveryMethod();
            createDeliveryMethod.Show();
        }

        private void companyAdministrationMasterDataManagementViewAllDeliveryMethodButton_Click(object sender, EventArgs e)
        {
            ViewAllDeliveryMethod viewAllDeliveryMethod = new ViewAllDeliveryMethod();
            viewAllDeliveryMethod.Show();
        }

        private void companyAdministrationMasterDataManagementCreateOrderStatusButton_Click(object sender, EventArgs e)
        {
            CreateOrderStatus createOrderStatus = new CreateOrderStatus();
            createOrderStatus.Show();
        }

        private void companyAdministrationMasterDataManagementViewAllOrderStatusButton_Click(object sender, EventArgs e)
        {
            ViewAllOrderStatus viewAllOrderStatus = new ViewAllOrderStatus();
            viewAllOrderStatus.Show();
        }

        private void companyAdministrationMasterDataManagementCreatePaymentMethodButton_Click(object sender, EventArgs e)
        {
            CreatePaymentMethod createPaymentMethod = new CreatePaymentMethod();
            createPaymentMethod.Show();
        }

        private void companyAdministrationMasterDataManagementViewAllPaymentMethodButton_Click(object sender, EventArgs e)
        {
            ViewAllPaymentMethod viewAllPaymentMethod = new ViewAllPaymentMethod();
            viewAllPaymentMethod.Show();
        }

        private void companyAdministrationMasterDataManagementCreateProductCategoryButton_Click(object sender, EventArgs e)
        {
            CreateProductCategory createProductCategory = new CreateProductCategory();
            createProductCategory.Show();
        }

        private void companyAdministrationMasterDataManagementViewAllProductCategoryButton_Click(object sender, EventArgs e)
        {
            ViewAllProductCategory viewAllProductCategory = new ViewAllProductCategory();
            viewAllProductCategory.Show();
        }

        private void companyAdministrationMasterDataManagementCreateProductNoteTypeButton_Click(object sender, EventArgs e)
        {
            CreateProductNoteType createProductNoteType = new CreateProductNoteType();
            createProductNoteType.Show();
        }

        private void companyAdministrationMasterDataManagementViewAllProductNoteTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllProductNoteType viewAllProductNoteType = new ViewAllProductNoteType();
            viewAllProductNoteType.Show();
        }

        private void companyAdministrationMasterDataManagementCreateSalesRegionButton_Click(object sender, EventArgs e)
        {
            CreateSalesRegion createSalesRegion = new CreateSalesRegion();
            createSalesRegion.Show();
        }

        private void companyAdministrationMasterDataManagementViewAllSalesRegionButton_Click(object sender, EventArgs e)
        {
            ViewAllSalesRegion viewAllSalesRegion = new ViewAllSalesRegion();
            viewAllSalesRegion.Show();
        }

        private void companyAdministrationMasterDataManagementCreateSupplierNoteTypeButton_Click(object sender, EventArgs e)
        {
            CreateSupplierNoteType createSupplierNoteType = new CreateSupplierNoteType();
            createSupplierNoteType.Show();
        }

        private void companyAdministrationMasterDataManagementViewAllSupplierNoteTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllSupplierNoteType viewAllSupplierNoteType = new ViewAllSupplierNoteType();
            viewAllSupplierNoteType.Show();
        }

        private void companyAdministrationFinanceManagementCreateCurrencyButton_Click(object sender, EventArgs e)
        {
            CreateCurrency createCurrency = new CreateCurrency();
            createCurrency.Show();
        }

        private void companyAdministrationFinanceManagementViewAllCurrencyButton_Click(object sender, EventArgs e)
        {
            ViewAllCurrency viewAllCurrency = new ViewAllCurrency();
            viewAllCurrency.Show();
        }

        private void companyAdministrationFinanceManagementCreateTaxProfileButton_Click(object sender, EventArgs e)
        {
            CreateTaxProfile createTaxProfile = new CreateTaxProfile();
            createTaxProfile.Show();
        }

        private void companyAdministrationFinanceManagementViewAllTaxProfileButton_Click(object sender, EventArgs e)
        {
            ViewAllTaxProfile viewAllTaxProfile = new ViewAllTaxProfile();
            viewAllTaxProfile.Show();
        }
    }
}