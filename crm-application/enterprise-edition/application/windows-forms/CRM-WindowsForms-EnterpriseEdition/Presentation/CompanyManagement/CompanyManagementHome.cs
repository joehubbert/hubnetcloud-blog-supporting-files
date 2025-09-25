using CRM.Helpers;
using CRM.Model;
using CRM.Presentation.CompanyManagement.AccountManagement;
using CRM.Presentation.CompanyManagement.CompanyConfiguration;
using CRM.Presentation.CompanyManagement.CurrencyConversion;
using CRM.Presentation.CompanyManagement.CustomerTier;
using CRM.Presentation.General;
using CRM.Presentation.MasterDataManagement;

namespace CRM.Presentation.CompanyManagement
{
    public partial class CompanyManagementHome : Form
    {
        private ActiveCompanyConfigurationHelper? _companyConfigHelper;

        public CompanyManagementHome()
        {
            InitializeComponent();
            LoadActiveCompanyConfigurationAsync();
        }

        private async void LoadActiveCompanyConfigurationAsync()
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(companyManagementStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.LoadAsync();
        }

        private async void changeActiveCompanyConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(companyManagementStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.ShowChangeDialogAndReloadAsync(this);
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
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.CompanyConfiguration, ModuleGroup.CompanyManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlAccountManagementTabPageTabControlAccountManagerTabPageCreateAccountManagerButton_Click(object sender, EventArgs e)
        {
            CreateAccountManager createAccountManager = new CreateAccountManager();
            createAccountManager.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlAccountManagementTabPageTabControlAccountManagerTabPageViewAllAccountManagerButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.AccountManager, ModuleGroup.CompanyManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerLeadNoteTypeTabPageCreateCustomerLeadNoteType_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.CustomerLeadNoteType, ModuleGroup.CustomerManagement);
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerLeadNoteTypeTabPageViewAllCustomerLeadNoteType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.CustomerLeadNoteType, ModuleGroup.CustomerManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerLeadStatusTabPageCreateCustomerLeadStatusButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.CustomerLeadStatus, ModuleGroup.CustomerManagement);
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerLeadStatusTabPageViewAllCustomerLeadStatusButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.CustomerLeadStatus, ModuleGroup.CustomerManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerLeadTypeTabPageCreateCustomerLeadTypeButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataEnhanced createMasterDataEnhanced = new CreateMasterDataEnhanced(FunctionTitle.CustomerLeadType, ModuleGroup.CustomerManagement);
            createMasterDataEnhanced.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerLeadTypeTabPageViewAllCustomerLeadTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.CustomerLeadType, ModuleGroup.CustomerManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerNoteTypeTabPageCreateCustomerNoteTypeButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.CustomerNoteType, ModuleGroup.CustomerManagement);
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerNoteTypeTabPageViewAllCustomerNoteTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.CustomerNoteType, ModuleGroup.CustomerManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerTierTabPageCreateCustomerTierButton_Click(object sender, EventArgs e)
        {
            CreateCustomerTier createCustomerTier = new CreateCustomerTier();
            createCustomerTier.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerTierTabPageViewAllCustomerTierButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.CustomerTier, ModuleGroup.CustomerManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerTypeTabPageCreateCustomerTypeButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataEnhanced createMasterDataEnhanced = new CreateMasterDataEnhanced(FunctionTitle.CustomerType, ModuleGroup.CustomerManagement);
            createMasterDataEnhanced.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlCustomerTabPageTabControlCustomerTypeTabPageViewAllCustomerTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.CustomerType, ModuleGroup.CustomerManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlCurrencyTabPageCreateCurrencyButton_Click(object sender, EventArgs e)
        {
            CreateCurrency createCurrency = new CreateCurrency();
            createCurrency.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlCurrencyTabPageViewAllCurrencyButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.Currency, ModuleGroup.CompanyManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlCurrencyConversionTabPageCreateCurrencyConversionButton_Click(object sender, EventArgs e)
        {
            CreateCurrencyConversion createCurrencyConversion = new CreateCurrencyConversion();
            createCurrencyConversion.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlCurrencyConversionTabPageViewAllCurrencyConversionButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.CurrencyConversion, ModuleGroup.CompanyManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlPaymentMethodTabPageCreatePaymentMethodButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.PaymentMethod, ModuleGroup.CompanyManagement);
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlPaymentMethodTabPageViewAllPaymentMethodButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.PaymentMethod, ModuleGroup.CompanyManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlTaxProfileTabPageCreateTaxProfileButton_Click(object sender, EventArgs e)
        {
            CreateTaxProfile createTaxProfile = new CreateTaxProfile();
            createTaxProfile.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlFinanceTabPageTabControlTaxProfileTabPageViewAllTaxProfileButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.TaxProfile, ModuleGroup.CompanyManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlLogisticsTabPageTabControlDeliveryMethodTabPageCreateDeliveryMethodButton_Click(object sender, EventArgs e)
        {
            CreateDeliveryMethod createDeliveryMethod = new CreateDeliveryMethod();
            createDeliveryMethod.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlLogisticsTabPageTabControlDeliveryMethodTabPageViewAllDeliveryMethodButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.DeliveryMethod, ModuleGroup.CompanyManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMarketingTabPageTabControlMarketingCampaignStatusTabPageCreateMarketingCampaignStatusButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.MarketingCampaignStatus, ModuleGroup.MarketingManagement);
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMarketingTabPageTabControlMarketingCampaignStatusTabPageViewAllMarketingCampaignStatusButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.MarketingCampaignStatus, ModuleGroup.MarketingManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMarketingTabPageTabControlMarketingCampaignTypeTabPageCreateMarketingCampaignTypeButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.MarketingCampaignType, ModuleGroup.MarketingManagement);
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMarketingTabPageTabControlMarketingCampaignTypeTabPageViewAllMarketingCampaignTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.MarketingCampaignType, ModuleGroup.MarketingManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMarketingTabPageTabControlMarketingChannelTabPageCreateMarketingChannelButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.MarketingChannel, ModuleGroup.MarketingManagement);
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMarketingTabPageTabControlMarketingChannelTabPageViewAllMarketingChannelButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.MarketingChannel, ModuleGroup.MarketingManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlPromotionTargetTypeTabPageCreatePromotionTargetTypeButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataEnhanced createMasterDataEnhanced = new CreateMasterDataEnhanced(FunctionTitle.PromotionTargetType, ModuleGroup.MarketingManagement);
            createMasterDataEnhanced.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlPromotionTargetTypeTabPageViewAllPromotionTargetType_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.PromotionTargetType, ModuleGroup.MarketingManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMarketingTabPageTabControlPromotionTypeTabPageCreatePromotionTypeButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.PromotionType, ModuleGroup.MarketingManagement);
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMarketingTabPageTabControlPromotionTypeTabPageViewAllPromotionTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.PromotionType, ModuleGroup.MarketingManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMiscellaneousTabPageTabControlCountryTabPageCreateCountryButton_Click(object sender, EventArgs e)
        {
            CreateCountry createCountry = new CreateCountry();
            createCountry.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMiscellaneousTabPageTabControlCountryTabPageViewAllCountryButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.Country, ModuleGroup.CompanyManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMiscellaneousTabPageTabControlHTMLTemplateTypeTabPageCreateHTMLTemplateTypeButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.HTMLTemplateType, ModuleGroup.CompanyManagement);
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlMiscellaneousTabPageTabControlHTMLTemplateTypeTabPageViewAllHTMLTemplateTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.HTMLTemplateType, ModuleGroup.CompanyManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlOrderTabPageTabControlOrderLineItemStatusTabPageCreateOrderLineItemStatusButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.OrderLineItemStatus, ModuleGroup.OrderManagement);
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlOrderTabPageTabControlOrderLineItemStatusTabPageViewAllOrderLineItemStatusButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.OrderLineItemStatus, ModuleGroup.OrderManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlOrderTabPageTabControlOrderPaymentStatusTabPageCreateOrderPaymentStatusButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.OrderPaymentStatus, ModuleGroup.OrderManagement);
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlOrderTabPageTabControlOrderPaymentStatusTabPageViewAllOrderPaymentStatusButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.OrderPaymentStatus, ModuleGroup.OrderManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlOrderTabPageTabControlOrderStatusTabPageCreateOrderStatusButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.OrderStatus, ModuleGroup.OrderManagement);
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlOrderTabPageTabControlOrderStatusTabPageViewAllOrderStatusButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.OrderStatus, ModuleGroup.OrderManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlOrderTabPageTabControlOrderTypeTabPageCreateOrderTypeButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.OrderType, ModuleGroup.OrderManagement);
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlOrderTabPageTabControlOrderTypeTabPageViewAllOrderTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.OrderType, ModuleGroup.OrderManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlProductTabPageTabControlProductCategoryTabPageCreateProductCategoryButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.ProductCategory, ModuleGroup.ProductManagement);
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlProductTabPageTabControlProductCategoryTabPageViewAllProductCategoryButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.ProductCategory, ModuleGroup.ProductManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlProductTabPageTabControlProductFamilyTabPageCreateProductFamilyButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.ProductFamily, ModuleGroup.ProductManagement);
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlProductTabPageTabControlProductFamilyTabPageViewAllProductFamilyButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.ProductFamily, ModuleGroup.ProductManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlProductTabPageTabControlProductSubCategoryTabPageCreateProductSubCategoryButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataAdvanced createMasterDataAdvanced = new CreateMasterDataAdvanced(FunctionTitle.ProductSubCategory, ModuleGroup.ProductManagement);
            createMasterDataAdvanced.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlProductTabPageTabControlProductSubCategoryTabPageViewAllProductSubCategoryButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.ProductSubCategory, ModuleGroup.ProductManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlProductTabPageTabControlProductNoteTypeTabPageCreateProductNoteTypeButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.ProductNoteType, ModuleGroup.ProductManagement);
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlProductTabPageTabControlProductNoteTypeTabPageViewAllProductNoteTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.ProductNoteType, ModuleGroup.ProductManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControMasterDataManagementTabPagelTabControlSalesGeographyTabPageTabControlSalesRegionTabPageCreateSalesRegionButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.SalesRegion, ModuleGroup.CompanyManagement);
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControMasterDataManagementTabPagelTabControlSalesGeographyTabPageTabControlSalesRegionTabPageViewAllSalesRegionButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.SalesRegion, ModuleGroup.CompanyManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControMasterDataManagementTabPagelTabControlSalesGeographyTabPageTabControlSalesSubRegionTabPageCreateSalesSubRegionButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataAdvanced createMasterDataAdvanced = new CreateMasterDataAdvanced(FunctionTitle.SalesSubRegion, ModuleGroup.CompanyManagement);
            createMasterDataAdvanced.Show();
        }

        private void companyManagementTabControMasterDataManagementTabPagelTabControlSalesGeographyTabPageTabControlSalesSubRegionTabPageViewAllSalesSubRegionButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.SalesSubRegion, ModuleGroup.CompanyManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlSupplierTabPageTabControlSupplierNoteTypeTabPageCreateSupplierNoteTypeButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.SupplierNoteType, ModuleGroup.SupplierManagement);
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlSupplierTabPageTabControlSupplierNoteTypeTabPageViewAllSupplierNoteTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.SupplierNoteType, ModuleGroup.SupplierManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlSupplierTabPageTabControlSupplierOrderLineItemStatusTabPageCreateSupplierOrderLineItemStatusButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.SupplierOrderLineItemStatus, ModuleGroup.SupplierManagement);
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlSupplierTabPageTabControlSupplierOrderLineItemStatusTabPageViewAllSupplierOrderLineItemStatus_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.SupplierOrderLineItemStatus, ModuleGroup.SupplierManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlSupplierTabPageTabControlSupplierOrderPaymentStatusTabPageCreateSupplierOrderPaymentStatusButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.SupplierOrderPaymentStatus, ModuleGroup.SupplierManagement);
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlSupplierTabPageTabControlSupplierOrderPaymentStatusTabPageViewAllSupplierOrderPaymentStatusButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.SupplierOrderPaymentStatus, ModuleGroup.SupplierManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlSupplierTabPageTabControlSupplierOrderStatusTabPageCreateSupplierOrderStatusButtom_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.SupplierOrderStatus, ModuleGroup.SupplierManagement);
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlSupplierTabPageTabControlSupplierOrderStatusTabPageViewAllSupplierOrderStatusButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.SupplierOrderStatus, ModuleGroup.SupplierManagement, null);
            viewAllData.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlSupplierTabPageTabControlWholesaleDeliveryTypeTabPageCreateWholesaleDeliveryTypeButton_Click(object sender, EventArgs e)
        {
            CreateMasterDataSimple createMasterDataSimple = new CreateMasterDataSimple(FunctionTitle.WholesaleDeliveryType, ModuleGroup.SupplierManagement);
            createMasterDataSimple.Show();
        }

        private void companyManagementTabControlMasterDataManagementTabPageTabControlSupplierTabPageTabControlWholesaleDeliveryTypeTabPageViewAllWholesaleDeliveryTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllData viewAllData = new ViewAllData(FunctionTitle.WholesaleDeliveryType, ModuleGroup.SupplierManagement, null);
            viewAllData.Show();
        }
    }
}