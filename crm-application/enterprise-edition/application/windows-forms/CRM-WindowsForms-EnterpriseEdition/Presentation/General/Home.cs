using CRM.Helpers;
using CRM.Model;
using CRM.Presentation.CompanyManagement;
using CRM.Presentation.CompanyManagement.AccountManagement;
using CRM.Presentation.CompanyManagement.CompanyConfiguration;
using CRM.Presentation.CompanyManagement.CurrencyConversion;
using CRM.Presentation.CompanyManagement.Customer;
using CRM.Presentation.CompanyManagement.CustomerTier;
using CRM.Presentation.CompanyManagement.MarketingCampaign;
using CRM.Presentation.CompanyManagement.Supplier;
using CRM.Presentation.Games;
using CRM.Presentation.Manufacturer;
using CRM.Presentation.MasterDataManagement;
using CRM.Presentation.Product;

namespace CRM.Presentation.General
{
    public partial class Home : Form
    {
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

        private async void changeActiveCompanyConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(homeStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.ShowChangeDialogAndReloadAsync(this);
        }

        private void homeNavAppConfiguration_Click(object sender, EventArgs e)
        {
            AppConfiguration appConfiguration = new AppConfiguration();
            appConfiguration.Show();
        }

        private void homeNavCompanyManagement_Click(object sender, EventArgs e)
        {
            CompanyManagementHome companyManagementHome = new CompanyManagementHome();
            companyManagementHome.Show();
        }

        private void homeNavCustomerManagement_Click(object sender, EventArgs e)
        {
            ModuleHomeSimple moduleHomeSimple = new ModuleHomeSimple(ModuleGroup.CustomerManagement);
            moduleHomeSimple.Show();
        }

        private void homeNavMarketingManagement_Click(object sender, EventArgs e)
        {
            ModuleHomeSimple moduleHomeSimple = new ModuleHomeSimple(ModuleGroup.MarketingManagement);
            moduleHomeSimple.Show();
        }

        private void homeNavOrderManagement_Click(object sender, EventArgs e)
        {
            ModuleHomeSimple moduleHomeSimple = new ModuleHomeSimple(ModuleGroup.OrderManagement);
            moduleHomeSimple.Show();
        }

        private void homeNavProductManagement_Click(object sender, EventArgs e)
        {
            ModuleHomeSimple moduleHomeSimple = new ModuleHomeSimple(ModuleGroup.ProductManagement);
            moduleHomeSimple.Show();
        }

        private void homeNavSupplierManagementButton_Click(object sender, EventArgs e)
        {
            ModuleHomeSimple moduleHomeSimple = new ModuleHomeSimple(ModuleGroup.SupplierManagement);
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
            CompanyManagementHome companyManagementHome = new CompanyManagementHome();
            companyManagementHome.Show();
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
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.CompanyConfiguration, ModuleGroup.CompanyManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementAccountManagementAccountManagerCreateAccountManager_Click(object sender, EventArgs e)
        {
            CreateAccountManager createAccountManager = new CreateAccountManager();
            createAccountManager.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementAccountManagementAccountManagerViewAllAccountManager_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.AccountManager, ModuleGroup.CompanyManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerLeadNoteTypeCreateCustomerLeadNoteType_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.CustomerLeadNoteType, ModuleGroup.CustomerManagement);
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerLeadNoteTypeViewAllCustomerLeadNoteType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.CustomerLeadNoteType, ModuleGroup.CustomerManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerLeadStatusCreateCustomerLeadStatus_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.CustomerLeadStatus, ModuleGroup.CustomerManagement);
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerLeadStatusViewAllCustomerLeadStatus_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.CustomerLeadStatus, ModuleGroup.CustomerManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerLeadTypeCreateCustomerLeadType_Click(object sender, EventArgs e)
        {
            CreateMasterDataEnhanced createMasterDataEnhanced = new CreateMasterDataEnhanced(FunctionTitle.CustomerLeadType, ModuleGroup.CustomerManagement);
            createMasterDataEnhanced.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerLeadTypeViewAllCustomerLeadType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.CustomerLeadType, ModuleGroup.CustomerManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerNoteTypeCreateCustomerNoteType_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.CustomerNoteType, ModuleGroup.CustomerManagement);
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerNoteTypeViewAllCustomerNoteType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.CustomerNoteType, ModuleGroup.CustomerManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerTierCreateCustomerTier_Click(object sender, EventArgs e)
        {
            CreateCustomerTier createCustomerTier = new CreateCustomerTier();
            createCustomerTier.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerTierViewAllCustomerTier_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.CustomerTier, ModuleGroup.CustomerManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerTypeCreateCustomerType_Click(object sender, EventArgs e)
        {
            CreateMasterDataEnhanced createMasterDataEnhanced = new CreateMasterDataEnhanced(FunctionTitle.CustomerType, ModuleGroup.CustomerManagement);
            createMasterDataEnhanced.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementCustomerCustomerTypeViewAllCustomerType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.CustomerType, ModuleGroup.CustomerManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementFinanceCurrencyCreateCurrency_Click(object sender, EventArgs e)
        {
            CreateCurrency createCurrency = new CreateCurrency();
            createCurrency.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementFinanceCurrencyViewAllCurrency_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.Currency, ModuleGroup.CompanyManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementFinanceCurrencyConversionCreateCurrencyConversion_Click(object sender, EventArgs e)
        {
            CreateCurrencyConversion createCurrencyConversion = new CreateCurrencyConversion();
            createCurrencyConversion.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementFinanceCurrencyConversionViewAllCurrencyConversion_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.CurrencyConversion, ModuleGroup.CompanyManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementFinancePaymentMethodCreatePaymentMethod_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.PaymentMethod, ModuleGroup.CompanyManagement);
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementFinancePaymentMethodViewAllPaymentMethod_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.PaymentMethod, ModuleGroup.CompanyManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementFinanceTaxProfileCreateTaxProfile_Click(object sender, EventArgs e)
        {
            CreateTaxProfile createTaxProfile = new CreateTaxProfile();
            createTaxProfile.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementFinanceTaxProfileViewAllTaxProfile_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.TaxProfile, ModuleGroup.CompanyManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementLogisticsDeliveryMethodCreateDeliveryMethod_Click(object sender, EventArgs e)
        {
            CreateDeliveryMethod createDeliveryMethod = new CreateDeliveryMethod();
            createDeliveryMethod.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementLogisticsDeliveryMethodViewAllDeliveryMethod_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.DeliveryMethod, ModuleGroup.CompanyManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMarketingMarketingCampaignStatusCreateMarketingCampaignStatus_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.MarketingCampaignStatus, ModuleGroup.MarketingManagement);
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMarketingMarketingCampaignStatusViewAllMarketingCampaignStatus_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.MarketingCampaignStatus, ModuleGroup.MarketingManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMarketingMarketingCampaignTypeCreateMarketingCampaignType_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.MarketingCampaignType, ModuleGroup.MarketingManagement);
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMarketingMarketingCampaignTypeViewAllMarketingCampaignType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.MarketingCampaignType, ModuleGroup.MarketingManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMarketingMarketingChannelCreateMarketingChannel_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.MarketingChannel, ModuleGroup.MarketingManagement);
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMarketingMarketingChannelViewAllMarketingChannel_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.MarketingChannel, ModuleGroup.MarketingManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMarketingPromotionTargetTypeCreatePromotionTargetType_Click(object sender, EventArgs e)
        {
            CreateMasterDataEnhanced createMasterDataEnhanced = new CreateMasterDataEnhanced(FunctionTitle.PromotionTargetType, ModuleGroup.MarketingManagement);
            createMasterDataEnhanced.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMarketingPromotionTargetTypeViewAllPromotionTargetType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.PromotionTargetType, ModuleGroup.MarketingManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMarketingPromotionTypeCreatePromotionType_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.PromotionType, ModuleGroup.MarketingManagement);
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMarketingPromotionTypeViewAllPromotionType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.PromotionType, ModuleGroup.MarketingManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMiscellaneousCountryCreateCountry_Click(object sender, EventArgs e)
        {
            CreateCountry createCountry = new CreateCountry();
            createCountry.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMiscellaneousCountryViewAllCountry_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.Country, ModuleGroup.CompanyManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMiscellaneousHTMLTemplateTypeCreateHTMLTemplateType_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.HTMLTemplateType, ModuleGroup.CompanyManagement);
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMiscellaneousHTMLTemplateTypeViewAllHTMLTemplateType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.HTMLTemplateType, ModuleGroup.CompanyManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMiscellaneousOrderLineItemStatusCreateOrderLineItemStatus_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.OrderLineItemStatus, ModuleGroup.OrderManagement);
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMiscellaneousOrderLineItemStatusViewAllOrderLineItemStatus_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.OrderLineItemStatus, ModuleGroup.OrderManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementOrderOrderPaymentStatusCreateOrderPaymentStatus_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.OrderPaymentStatus, ModuleGroup.OrderManagement);
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementOrderOrderPaymentStatusViewAllOrderPaymentStatus_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.OrderPaymentStatus, ModuleGroup.OrderManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMiscellaneousOrderStatusCreateOrderStatus_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.OrderStatus, ModuleGroup.OrderManagement);
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementMiscellaneousOrderStatusViewAllOrderStaus_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.OrderStatus, ModuleGroup.OrderManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementOrderOrderTypeCreateOrderType_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.OrderType, ModuleGroup.OrderManagement);
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementOrderOrderTypeViewAllOrderType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.OrderType, ModuleGroup.OrderManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementProductProductCategoryCreateProductCategory_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.ProductCategory, ModuleGroup.ProductManagement);
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementProductProductCategoryViewAllProductCategory_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.ProductCategory, ModuleGroup.ProductManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementProductProductFamilyCreateProductFamily_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.ProductFamily, ModuleGroup.ProductManagement);
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementProductProductFamilyViewAllProductFamily_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.ProductFamily, ModuleGroup.ProductManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementProductProductSubCategoryCreateProductSubCategory_Click(object sender, EventArgs e)
        {
            CreateMasterDataAdvanced createMasterDataAdvanced = new CreateMasterDataAdvanced(FunctionTitle.ProductSubCategory, ModuleGroup.ProductManagement);
            createMasterDataAdvanced.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementProductProductSubCategoryViewAllProductSubCategory_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.ProductSubCategory, ModuleGroup.ProductManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementProductProductNoteTypeCreateProductNoteType_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.ProductNoteType, ModuleGroup.ProductManagement);
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementProductProductNoteTypeViewAllProductNoteType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.ProductNoteType, ModuleGroup.ProductManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSalesGeographySalesRegionCreateSalesRegion_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.SalesRegion, ModuleGroup.CompanyManagement);
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSalesGeographySalesRegionViewAllSalesRegion_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.SalesRegion, ModuleGroup.CompanyManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSalesGeographySalesSubRegionCreateSalesSubRegion_Click(object sender, EventArgs e)
        {
            CreateMasterDataAdvanced createMasterDataAdvanced = new CreateMasterDataAdvanced(FunctionTitle.SalesSubRegion, ModuleGroup.CompanyManagement);
            createMasterDataAdvanced.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSalesGeographySalesSubRegionViewAllSalesSubRegion_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.SalesSubRegion, ModuleGroup.CompanyManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSupplierSupplierNoteTypeCreateSupplierNoteType_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.SupplierNoteType, ModuleGroup.SupplierManagement);
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSupplierSupplierNoteTypeViewAllSupplierNoteType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.SupplierNoteType, ModuleGroup.SupplierManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSupplierSupplierOrderLineItemStatusCreateSupplierOrderLineItemStatus_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.SupplierOrderLineItemStatus, ModuleGroup.SupplierManagement);
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSupplierSupplierOrderLineItemStatusViewAllSupplierOrderLineItemStatus_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.SupplierOrderLineItemStatus, ModuleGroup.SupplierManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSupplierSupplierOrderPaymentStatusCreateSupplierOrderPaymentStatus_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.SupplierOrderPaymentStatus, ModuleGroup.SupplierManagement);
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSupplierSupplierOrderPaymentStatusViewAllSupplierOrderPaymentStatus_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.SupplierOrderPaymentStatus, ModuleGroup.SupplierManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSupplierSupplierOrderStatusCreateSupplierOrderStatus_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.SupplierOrderStatus, ModuleGroup.SupplierManagement);
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSupplierSupplierOrderStatusViewAllSupplierOrderStatus_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.SupplierOrderStatus, ModuleGroup.SupplierManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSupplierWholesaleDeliveryTypeCreateWholesaleDeliveryType_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.WholesaleDeliveryType, ModuleGroup.SupplierManagement);
            createMasterDataSimple.Show();
        }

        private void homeMenuStripModuleCompanyManagementMasterDataManagementSupplierWholesaleDeliveryTypeViewAllWholesaleDeliveryType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.WholesaleDeliveryType, ModuleGroup.SupplierManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleCustomerManagement_Click(object sender, EventArgs e)
        {
            ModuleHomeSimple moduleHomeSimple = new ModuleHomeSimple(ModuleGroup.CustomerManagement);
            moduleHomeSimple.Show();
        }

        private void homeMenuStripModuleCustomerManagementCreateCustomer_Click(object sender, EventArgs e)
        {
            CreateCustomer createCustomer = new CreateCustomer();
            createCustomer.Show();
        }

        private void homeMenuStripModuleCustomerManagementViewAllCustomer_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.Customer, ModuleGroup.CustomerManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleMarketingManagement_Click(object sender, EventArgs e)
        {
            ModuleHomeSimple moduleHomeSimple = new ModuleHomeSimple(ModuleGroup.MarketingManagement);
            moduleHomeSimple.Show();
        }

        private void homeMenuStripModuleMarketingManagementCreateMarketingCampaign_Click(object sender, EventArgs e)
        {
            CreateMarketingCampaign createMarketingCampaign = new CreateMarketingCampaign();
            createMarketingCampaign.Show();
        }

        private void homeMenuStripModuleMarketingManagementViewAllMarketingCampaign_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.MarketingCampaign, ModuleGroup.MarketingManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleOrderManagement_Click(object sender, EventArgs e)
        {
            ModuleHomeSimple moduleHomeSimple = new ModuleHomeSimple(ModuleGroup.OrderManagement);
            moduleHomeSimple.Show();
        }

        private void homeMenuStripModuleProductManagement_Click(object sender, EventArgs e)
        {
            ModuleHomeSimple moduleHomeSimple = new ModuleHomeSimple(ModuleGroup.ProductManagement);
            moduleHomeSimple.Show();
        }

        private void homeMenuStripModuleProductManagementManufacturerCreateManufacturer_Click(object sender, EventArgs e)
        {
            CreateManufacturer createManufacturer = new CreateManufacturer();
            createManufacturer.Show();
        }

        private void homeMenuStripModuleProductManagementManufacturerViewAllManufacturer_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.Manufacturer, ModuleGroup.ProductManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleProductManagementProductCreateProduct_Click(object sender, EventArgs e)
        {
            CreateProduct createProduct = new CreateProduct();
            createProduct.Show();
        }

        private void homeMenuStripModuleProductManagementProductViewAllProduct_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.Product, ModuleGroup.ProductManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripModuleSupplierManagement_Click(object sender, EventArgs e)
        {
            ModuleHomeSimple moduleHomeSimple = new ModuleHomeSimple(ModuleGroup.SupplierManagement);
            moduleHomeSimple.Show();
        }

        private void homeMenuStripModuleSupplierManagementCreateSupplier_Click(object sender, EventArgs e)
        {
            CreateSupplier createSupplier = new CreateSupplier();
            createSupplier.Show();
        }

        private void homeMenuStripModuleSupplierManagementViewAllSupplier_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.Supplier, ModuleGroup.SupplierManagement, null);
            viewAllData.Show();
        }

        private void homeMenuStripOptionsAppConfiguration_Click(object sender, EventArgs e)
        {
            AppConfiguration appConfiguration = new AppConfiguration();
            appConfiguration.Show();
        }
    }
}