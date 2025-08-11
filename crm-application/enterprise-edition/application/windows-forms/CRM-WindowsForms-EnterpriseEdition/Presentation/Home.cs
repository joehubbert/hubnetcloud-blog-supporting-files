using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class Home : Form
    {
        private Guid _companyConfigurationId;
        private ActiveCompanyConfigurationHelper? _companyConfigHelper;

        public Home()
        {
            InitializeComponent();
            LoadActiveCompanyConfigurationAsync();
        }

        private async void LoadActiveCompanyConfigurationAsync()
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(homeStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.LoadAsync();
        }

        private void homeNavAppConfiguration_Click(object sender, EventArgs e)
        {
            AppConfiguration appConfiguration = new AppConfiguration();
            appConfiguration.Show();
        }

        private void homeNavCompanyManagement_Click(object sender, EventArgs e)
        {
            CompanyManagement companyManagement = new CompanyManagement();
            companyManagement.Show();
        }

        private void homeNavCustomerManagement_Click(object sender, EventArgs e)
        {
            ModuleHomeSimple moduleHomeSimple = new ModuleHomeSimple("CustomerManagement");
            moduleHomeSimple.Show();
        }

        private void homeNavMarketingManagement_Click(object sender, EventArgs e)
        {
            ModuleHomeSimple moduleHomeSimple = new ModuleHomeSimple("MarketingManagement");
            moduleHomeSimple.Show();
        }

        private void homeNavOrderManagement_Click(object sender, EventArgs e)
        {
            ModuleHomeSimple moduleHomeSimple = new ModuleHomeSimple("OrderManagement");
            moduleHomeSimple.Show();
        }

        private void homeNavProductManagement_Click(object sender, EventArgs e)
        {
            ModuleHomeSimple moduleHomeSimple = new ModuleHomeSimple("ProductManagement");
            moduleHomeSimple.Show();
        }

        private void homeNavSupplierManagementButton_Click(object sender, EventArgs e)
        {
            ModuleHomeSimple moduleHomeSimple = new ModuleHomeSimple("SupplierManagement");
            moduleHomeSimple.Show();
        }

        private void homeMenuStripHelpAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void homeMenuStripHelpEasterEggChess_Click(object sender, EventArgs e)
        {
            Chess chess = new Chess();
            chess.Show();
        }

        private void homeMenuStripHelpEasterEggFreeCell_Click(object sender, EventArgs e)
        {
            FreeCell freeCell = new FreeCell();
            freeCell.Show();
        }

        private void homeMenuStripHelpEasterEggHearts_Click(object sender, EventArgs e)
        {
            Hearts hearts = new Hearts();
            hearts.Show();
        }

        private void homeMenuStripHelpEasterEggMinesweeper_Click(object sender, EventArgs e)
        {
            Minesweeper mineSweeper = new Minesweeper();
            mineSweeper.Show();
        }

        private void homeMenuStripHelpEasterEggSolitaire_Click(object sender, EventArgs e)
        {
            Solitaire solitaire = new Solitaire();
            solitaire.Show();
        }

        private void homeMenuStripHelpEasterEggSpiderSolitaire_Click(object sender, EventArgs e)
        {
            using var dlg = new SpiderSolitaireDifficulty(1); // or your default suit count
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                var spiderSolitaire = new SpiderSolitaire(dlg.SelectedSuitCount);
                spiderSolitaire.Show();
            }
        }

        private void homeMenuStripHelpEasterEggSudoku_Click(object sender, EventArgs e)
        {
            Sudoku sudoku = new Sudoku();
            sudoku.Show();
        }

        private void homeMenuStripModuleCompanyManagement_Click(object sender, EventArgs e)
        {
            CompanyManagement companyManagement = new CompanyManagement();
            companyManagement.Show();
        }

        private void homeMenuStripModuleCompanyManagementCompanyConfigurationCreateCompanyConfiguration_Click(object sender, EventArgs e)
        {
            CreateCompanyConfiguration createCompanyConfiguration = new CreateCompanyConfiguration();
            createCompanyConfiguration.Show();
        }

        private void homeMenuStripModuleCompanyManagementCompanyConfigurationSetActiveCompanyConfiguration_Click(object sender, EventArgs e)
        {
            ActiveCompanyConfiguration activeCompanyConfiguration = new ActiveCompanyConfiguration();
            activeCompanyConfiguration.Show();
        }

        private void homeMenuStripModuleCompanyManagementCompanyConfigurationViewAllCompanyConfiguration_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("CompanyConfiguration", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementAccountManagementAccountManagerCreateAccountManager_Click(object sender, EventArgs e)
        {
            CreateAccountManager createAccountManager = new CreateAccountManager();
            createAccountManager.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementAccountManagementAccountManagerViewAllAccountManager_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("AccountManager", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerLeadNoteTypeCreateCustomerLeadNoteType_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("CustomerLeadNoteType", "CustomerManagement");
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerLeadNoteTypeViewAllCustomerLeadNoteType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("CustomerLeadNoteType", "CustomerManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerLeadStatusCreateCustomerLeadStatus_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("CustomerLeadStatus", "CustomerManagement");
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerLeadStatusViewAllCustomerLeadStatus_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("CustomerLeadStatus", "CustomerManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerLeadTypeCreateCustomerLeadType_Click(object sender, EventArgs e)
        {
            CreateMasterDataEnhanced createMasterDataEnhanced = new CreateMasterDataEnhanced("CustomerLeadType", "CustomerManagement");
            createMasterDataEnhanced.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerLeadTypeViewAllCustomerLeadType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("CustomerLeadType", "CustomerManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerNoteTypeCreateCustomerNoteType_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("CustomerNoteType", "CustomerManagement");
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerNoteTypeViewAllCustomerNoteType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("CustomerNoteType", "CustomerManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerTierCreateCustomerTier_Click(object sender, EventArgs e)
        {
            CreateCustomerTier createCustomerTier = new CreateCustomerTier();
            createCustomerTier.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerTierViewAllCustomerTier_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("CustomerTier", "CustomerManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerTypeCreateCustomerType_Click(object sender, EventArgs e)
        {
            CreateMasterDataEnhanced createMasterDataEnhanced = new CreateMasterDataEnhanced("CustomerType", "CustomerManagement");
            createMasterDataEnhanced.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerTypeViewAllCustomerType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("CustomerType", "CustomerManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementFinanceCurrencyCreateCurrency_Click(object sender, EventArgs e)
        {
            CreateCurrency createCurrency = new CreateCurrency();
            createCurrency.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementFinanceCurrencyViewAllCurrency_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("Currency", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementFinanceCurrencyConversionCreateCurrencyConversion_Click(object sender, EventArgs e)
        {
            CreateCurrencyConversion createCurrencyConversion = new CreateCurrencyConversion();
            createCurrencyConversion.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementFinanceCurrencyConversionViewAllCurrencyConversion_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("CurrencyConversion", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementFinancePaymentMethodCreatePaymentMethod_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("PaymentMethod", "CompanyManagement");
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementFinancePaymentMethodViewAllPaymentMethod_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("PaymentMethod", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementFinanceTaxProfileCreateTaxProfile_Click(object sender, EventArgs e)
        {
            CreateTaxProfile createTaxProfile = new CreateTaxProfile();
            createTaxProfile.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementFinanceTaxProfileViewAllTaxProfile_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("TaxProfile", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementLogisticsDeliveryMethodCreateDeliveryMethod_Click(object sender, EventArgs e)
        {
            CreateDeliveryMethod createDeliveryMethod = new CreateDeliveryMethod();
            createDeliveryMethod.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementLogisticsDeliveryMethodViewAllDeliveryMethod_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("DeliveryMethod", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMarketingMarketingCampaignStatusCreateMarketingCampaignStatus_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("MarketingCampaignStatus", "MarketingManagement");
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMarketingMarketingCampaignStatusViewAllMarketingCampaignStatus_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("MarketingCampaignStatus", "MarketingManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMarketingMarketingCampaignTypeCreateMarketingCampaignType_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("MarketingCampaignType", "MarketingManagement");
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMarketingMarketingCampaignTypeViewAllMarketingCampaignType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("MarketingCampaignType", "MarketingManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMarketingMarketingChannelCreateMarketingChannel_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("MarketingChannel", "MarketingManagement");
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMarketingMarketingChannelViewAllMarketingChannel_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("MarketingChannel", "MarketingManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMarketingPromotionTargetTypeCreatePromotionTargetType_Click(object sender, EventArgs e)
        {
            CreateMasterDataEnhanced createMasterDataEnhanced = new CreateMasterDataEnhanced("PromotionTargetType", "MarketingManagement");
            createMasterDataEnhanced.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMarketingPromotionTargetTypeViewAllPromotionTargetType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("PromotionTargetType", "MarketingManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMarketingPromotionTypeCreatePromotionType_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("PromotionType", "MarketingManagement");
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMarketingPromotionTypeViewAllPromotionType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("PromotionType", "MarketingManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMiscellaneousCountryCreateCountry_Click(object sender, EventArgs e)
        {
            CreateCountry createCountry = new CreateCountry();
            createCountry.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMiscellaneousCountryViewAllCountry_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("Country", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMiscellaneousCountryTranslationCreateCountryTranslation_Click(object sender, EventArgs e)
        {
            CreateCountryTranslation createCountryTranslation = new CreateCountryTranslation();
            createCountryTranslation.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMiscellaneousCountryTranslationViewAllCountryTranslation_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("CountryTranslation", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMiscellaneousHTMLTemplateTypeCreateHTMLTemplateType_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("HTMLTemplateType", "CompanyManagement");
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMiscellaneousHTMLTemplateTypeViewAllHTMLTemplateType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("HTMLTemplateType", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMiscellaneousOrderLineItemStatusCreateOrderLineItemStatus_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("OrderLineItemStatus", "OrderManagement");
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMiscellaneousOrderLineItemStatusViewAllOrderLineItemStatus_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("OrderLineItemStatus", "OrderManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementOrderOrderPaymentStatusCreateOrderPaymentStatus_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("OrderPaymentStatus", "OrderManagement");
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementOrderOrderPaymentStatusViewAllOrderPaymentStatus_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("OrderPaymentStatus", "OrderManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMiscellaneousOrderStatusCreateOrderStatus_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("OrderStatus", "OrderManagement");
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMiscellaneousOrderStatusViewAllOrderStaus_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("OrderStatus", "OrderManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementOrderOrderTypeCreateOrderType_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("OrderType", "OrderManagement");
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementOrderOrderTypeViewAllOrderType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("OrderType", "OrderManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementProductProductCategoryCreateProductCategory_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("ProductCategory", "ProductManagement");
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementProductProductCategoryViewAllProductCategory_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("ProductCategory", "ProductManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementProductProductFamilyCreateProductFamily_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("ProductFamily", "ProductManagement");
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementProductProductFamilyViewAllProductFamily_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("ProductFamily", "ProductManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementProductProductSubCategoryCreateProductSubCategory_Click(object sender, EventArgs e)
        {
            CreateMasterDataAdvanced createMasterDataAdvanced = new CreateMasterDataAdvanced("ProductSubCategory", "ProductManagement");
            createMasterDataAdvanced.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementProductProductSubCategoryViewAllProductSubCategory_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("ProductSubCategory", "ProductManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementProductProductNoteTypeCreateProductNoteType_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("ProductNoteType", "ProductManagement");
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementProductProductNoteTypeViewAllProductNoteType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("ProductNoteType", "ProductManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSalesGeographySalesRegionCreateSalesRegion_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("SalesRegion", "CompanyManagement");
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSalesGeographySalesRegionViewAllSalesRegion_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("SalesRegion", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSalesGeographySalesSubRegionCreateSalesSubRegion_Click(object sender, EventArgs e)
        {
            CreateMasterDataAdvanced createMasterDataAdvanced = new CreateMasterDataAdvanced("SalesSubRegion", "CompanyManagement");
            createMasterDataAdvanced.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSalesGeographySalesSubRegionViewAllSalesSubRegion_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("SalesSubRegion", "CompanyManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSupplierSupplierNoteTypeCreateSupplierNoteType_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("SupplierNoteType", "SupplierManagement");
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSupplierSupplierNoteTypeViewAllSupplierNoteType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("SupplierNoteType", "SupplierManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSupplierSupplierOrderLineItemStatusCreateSupplierOrderLineItemStatus_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("SupplierOrderLineItemStatus", "SupplierManagement");
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSupplierSupplierOrderLineItemStatusViewAllSupplierOrderLineItemStatus_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("SupplierOrderLineItemStatus", "SupplierManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSupplierSupplierOrderPaymentStatusCreateSupplierOrderPaymentStatus_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("SupplierOrderPaymentStatus", "SupplierManagement");
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSupplierSupplierOrderPaymentStatusViewAllSupplierOrderPaymentStatus_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("SupplierOrderPaymentStatus", "SupplierManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSupplierSupplierOrderStatusCreateSupplierOrderStatus_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple("SupplierOrderStatus", "SupplierManagement");
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSupplierSupplierOrderStatusViewAllSupplierOrderStatus_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("SupplierOrderStatus", "SupplierManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCustomerManagement_Click(object sender, EventArgs e)
        {
            ModuleHomeSimple moduleHomeSimple = new ModuleHomeSimple("CustomerManagement");
            moduleHomeSimple.Show();
        }

        private void homeMenuStripModuleCustomerManagementCreateCustomer_Click(object sender, EventArgs e)
        {
            CreateCustomer createCustomer = new CreateCustomer();
            createCustomer.Show();
        }

        private void homeMenuStripModuleCustomerManagementViewAllCustomer_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("ViewAllCustomer", "CustomerManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleMarketingManagement_Click(object sender, EventArgs e)
        {
            ModuleHomeSimple moduleHomeSimple = new ModuleHomeSimple("MarketingManagement");
            moduleHomeSimple.Show();
        }

        private void homeMenuStripModuleMarketingManagementCreateMarketingCampaign_Click(object sender, EventArgs e)
        {
            CreateMarketingCampaign createMarketingCampaign = new CreateMarketingCampaign();
            createMarketingCampaign.Show();
        }

        private void homeMenuStripModuleMarketingManagementViewAllMarketingCampaign_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("ViewAllMarketingCampaign", "MarketingManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleOrderManagement_Click(object sender, EventArgs e)
        {
            ModuleHomeSimple moduleHomeSimple = new ModuleHomeSimple("OrderManagement");
            moduleHomeSimple.Show();
        }

        private void homeMenuStripModuleProductManagement_Click(object sender, EventArgs e)
        {
            ModuleHomeSimple moduleHomeSimple = new ModuleHomeSimple("ProductManagement");
            moduleHomeSimple.Show();
        }

        private void homeMenuStripModuleProductManagementCreateProduct_Click(object sender, EventArgs e)
        {
            CreateProduct createProduct = new CreateProduct();
            createProduct.Show();
        }

        private void homeMenuStripModuleProductManagementViewAllProduct_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("ViewAllProduct", "ProductManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleSupplierManagement_Click(object sender, EventArgs e)
        {
            ModuleHomeSimple moduleHomeSimple = new ModuleHomeSimple("SupplierManagement");
            moduleHomeSimple.Show();
        }

        private void homeMenuStripModuleSupplierManagementCreateSupplier_Click(object sender, EventArgs e)
        {
            CreateSupplier createSupplier = new CreateSupplier();
            createSupplier.Show();
        }

        private void homeMenuStripModuleSupplierManagementViewAllSupplier_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData("ViewAllSupplier", "SupplierManagement", null);
            viewAllData.Show();
        }

        private void homeMenuStripOptionsAppConfiguration_Click(object sender, EventArgs e)
        {
            AppConfiguration appConfiguration = new AppConfiguration();
            appConfiguration.Show();
        }

        private async void changeActiveCompanyConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(homeStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.ShowChangeDialogAndReloadAsync(this);
        }
    }
}