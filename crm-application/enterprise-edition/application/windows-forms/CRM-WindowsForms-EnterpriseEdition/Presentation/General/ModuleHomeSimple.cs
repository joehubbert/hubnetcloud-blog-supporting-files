using CRM.Helpers;
using CRM.Model;
using CRM.Presentation.CompanyManagement.Customer;
using CRM.Presentation.CompanyManagement.MarketingCampaign;
using CRM.Presentation.CompanyManagement.Order;
using CRM.Presentation.CompanyManagement.Supplier;
using CRM.Presentation.Manufacturer;
using CRM.Presentation.Product;
using CRM.Services;

namespace CRM.Presentation.General
{
    public partial class ModuleHomeSimple : Form
    {
        private ActiveCompanyConfigurationHelper? _companyConfigHelper;
        private GeneralSharedComponents _generalSharedComponents = new GeneralSharedComponents();
        private readonly ModuleGroup _moduleGroup;
        private readonly string applicationTitlePrefix = "CRM - ";
        private string dataSubjectPluralName;
        private string dataSubjectSingularName;
        private string moduleFriendlyName;
        private readonly string viewAllPrefix = "View All ";

        public ModuleHomeSimple(ModuleGroup moduleGroup)
        {
            InitializeComponent();
            _moduleGroup = moduleGroup;
            LoadActiveCompanyConfigurationAsync();
            ModuleConfiguration();
        }

        private async void LoadActiveCompanyConfigurationAsync()
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(moduleHomeStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.LoadAsync();
        }

        private void ModuleConfiguration()
        {
            ModuleThemeHelper.ApplyTheme(this, _moduleGroup);

            dataSubjectPluralName = _generalSharedComponents.GetModuleGroupValue(_moduleGroup, "moduleGroupDataSubjectName");
            dataSubjectSingularName = _generalSharedComponents.GetModuleGroupValue(_moduleGroup, "moduleGroupDataSubjectName");
            moduleFriendlyName = _generalSharedComponents.GetModuleGroupValue(_moduleGroup, "moduleGroupFriendlyName");

            // Handle the case where no matching entry is found
            if (string.IsNullOrEmpty(moduleFriendlyName))
            {
                this.Text = _moduleGroup.ToString();
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.NotImplemented", _moduleGroup.ToString());
                return;
            }
            moduleHomeTitleLabel.Text = moduleFriendlyName;
            this.Text = $"{applicationTitlePrefix}{moduleFriendlyName}";
            moduleHomeCreateButton.Text = $"Create {dataSubjectSingularName}";
            moduleHomeViewAllButton.Text = $"{viewAllPrefix}{dataSubjectPluralName}";

            if (_moduleGroup == ModuleGroup.ProductManagement)
            {
                moduleHomeCreateButton2.Text = "Create Manufacturer";
                moduleHomeViewAllButton2.Text = $"{viewAllPrefix}Manufacturers";
            }
            else
            {
                moduleHomeCreateButton2.Visible = false;
                moduleHomeViewAllButton2.Visible = false;
                this.Size = new Size(633, 304);
            }
        }

        private async void changeActiveCompanyConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(moduleHomeStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.ShowChangeDialogAndReloadAsync(this);
        }

        private void moduleHomeCreateButton_Click(object sender, EventArgs e)
        {
            switch (_moduleGroup)
            {
                case ModuleGroup.CustomerManagement:
                    CreateCustomer createCustomer = new CreateCustomer();
                    createCustomer.Show();
                    break;
                case ModuleGroup.MarketingManagement:
                    CreateMarketingCampaign createMarketingCampaign = new CreateMarketingCampaign();
                    createMarketingCampaign.Show();
                    break;
                case ModuleGroup.OrderManagement:
                    CreateOrder createOrder = new CreateOrder();
                    createOrder.Show();
                    break;
                case ModuleGroup.ProductManagement:
                    CreateProduct createProduct = new CreateProduct();
                    createProduct.Show();
                    break;
                case ModuleGroup.SupplierManagement:
                    CreateSupplier createSupplier = new CreateSupplier();
                    createSupplier.Show();
                    break;
            }
        }

        private void moduleHomeViewAllButton_Click(object sender, EventArgs e)
        {
            switch (_moduleGroup)
            {
                case ModuleGroup.CustomerManagement:
                    {
                        ViewAllData viewAllData = new ViewAllData(FunctionTitle.Customer, ModuleGroup.CustomerManagement, null);
                        viewAllData.Show();
                        break;
                    }
                case ModuleGroup.MarketingManagement:
                    {
                        ViewAllData viewAllData = new ViewAllData(FunctionTitle.MarketingCampaign, ModuleGroup.MarketingManagement, null);
                        viewAllData.Show();
                        break;
                    }
                case ModuleGroup.OrderManagement:
                    {
                        ViewAllData viewAllData = new ViewAllData(FunctionTitle.Order, ModuleGroup.OrderManagement, null);
                        viewAllData.Show();
                        break;
                    }
                case ModuleGroup.ProductManagement:
                    {
                        ViewAllData viewAllData = new ViewAllData(FunctionTitle.Product, ModuleGroup.ProductManagement, null);
                        viewAllData.Show();
                        break;
                    }
                case ModuleGroup.SupplierManagement:
                    {
                        ViewAllData viewAllData = new ViewAllData(FunctionTitle.Supplier, ModuleGroup.SupplierManagement, null);
                        viewAllData.Show();
                        break;
                    }
            }
        }

        private void moduleHomeCreateButton2_Click(object sender, EventArgs e)
        {
            switch (_moduleGroup)
            {
                case ModuleGroup.ProductManagement:
                    CreateManufacturer createManufacturer = new CreateManufacturer();
                    createManufacturer.Show();
                    break;
                default:
                    this.Text = _moduleGroup.ToString();
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.NotImplemented", _moduleGroup.ToString());
                    break;
            }
        }

        private void moduleHomeViewAllButton2_Click(object sender, EventArgs e)
        {
            switch (_moduleGroup)
            {
                case ModuleGroup.ProductManagement:
                    ViewAllData viewAllData = new ViewAllData(FunctionTitle.Manufacturer, ModuleGroup.ProductManagement, null);
                    viewAllData.Show();
                    break;
                default:
                    this.Text = _moduleGroup.ToString();
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.NotImplemented", _moduleGroup.ToString());
                    break;
            }
        }
    }
}