using CRM.Helpers;
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
        private readonly string _moduleGroup;
        private readonly string applicationTitlePrefix = "CRM - ";
        private string dataSubjectPluralName;
        private string dataSubjectSingularName;
        private string moduleFriendlyName;
        private readonly string viewAllPrefix = "View All ";

        public ModuleHomeSimple(string moduleGroup)
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

            switch (_moduleGroup)
            {
                case "CompanyManagement":
                    dataSubjectPluralName = "Companies";
                    dataSubjectSingularName = "Company";
                    moduleFriendlyName = "Company Management";
                    break;
                case "CustomerManagement":
                    dataSubjectPluralName = "Customers";
                    dataSubjectSingularName = "Customer";
                    moduleFriendlyName = "Customer Management";
                    break;
                case "MarketingManagement":
                    dataSubjectPluralName = "Marketing Campaigns";
                    dataSubjectSingularName = "Marketing Campaign";
                    moduleFriendlyName = "Marketing Management";
                    break;
                case "OrderManagement":
                    dataSubjectPluralName = "Orders";
                    dataSubjectSingularName = "Order";
                    moduleFriendlyName = "Order Management";
                    break;
                case "ProductManagement":
                    dataSubjectPluralName = "Products";
                    dataSubjectSingularName = "Product";
                    moduleFriendlyName = "Product Management";
                    break;
                case "SupplierManagement":
                    dataSubjectPluralName = "Suppliers";
                    dataSubjectSingularName = "Supplier";
                    moduleFriendlyName = "Supplier Management";
                    break;
                default:
                    this.Text = _moduleGroup;
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.NotImplemented", _moduleGroup);
                    break;
            }
            moduleHomeTitleLabel.Text = moduleFriendlyName;
            this.Text = $"{applicationTitlePrefix}{moduleFriendlyName}";
            moduleHomeCreateButton.Text = $"Create {dataSubjectSingularName}";
            moduleHomeViewAllButton.Text = $"{viewAllPrefix}{dataSubjectPluralName}";

            if (_moduleGroup == "ProductManagement")
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
                case "CustomerManagement":
                    CreateCustomer createCustomer = new CreateCustomer();
                    createCustomer.Show();
                    break;
                case "MarketingManagement":
                    CreateMarketingCampaign createMarketingCampaign = new CreateMarketingCampaign();
                    createMarketingCampaign.Show();
                    break;
                case "OrderManagement":
                    CreateOrder createOrder = new CreateOrder();
                    createOrder.Show();
                    break;
                case "ProductManagement":
                    CreateProduct createProduct = new CreateProduct();
                    createProduct.Show();
                    break;
                case "SupplierManagement":
                    CreateSupplier createSupplier = new CreateSupplier();
                    createSupplier.Show();
                    break;
            }
        }

        private void moduleHomeViewAllButton_Click(object sender, EventArgs e)
        {
            switch (_moduleGroup)
            {
                case "CustomerManagement":
                    {
                        ViewAllData viewAllData = new ViewAllData("Customer", "CustomerManagement", null);
                        viewAllData.Show();
                        break;
                    }
                case "MarketingManagement":
                    {
                        ViewAllData viewAllData = new ViewAllData("MarketingCampaign", "MarketingManagement", null);
                        viewAllData.Show();
                        break;
                    }
                case "OrderManagement":
                    {
                        ViewAllData viewAllData = new ViewAllData("Order", "OrderManagement", null);
                        viewAllData.Show();
                        break;
                    }
                case "ProductManagement":
                    {
                        ViewAllData viewAllData = new ViewAllData("Product", "ProductManagement", null);
                        viewAllData.Show();
                        break;
                    }
                case "SupplierManagement":
                    {
                        ViewAllData viewAllData = new ViewAllData("Supplier", "SupplierManagement", null);
                        viewAllData.Show();
                        break;
                    }
            }
        }

        private void moduleHomeCreateButton2_Click(object sender, EventArgs e)
        {
            switch (_moduleGroup)
            {
                case "ProductManagement":
                    CreateManufacturer createManufacturer = new CreateManufacturer();
                    createManufacturer.Show();
                    break;
                default:
                    this.Text = _moduleGroup;
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.NotImplemented", _moduleGroup);
                    break;
            }
        }

        private void moduleHomeViewAllButton2_Click(object sender, EventArgs e)
        {
            switch (_moduleGroup)
            {
                case "ProductManagement":
                    ViewAllData viewAllData = new ViewAllData("Manufacturer", "ProductManagement", null);
                    viewAllData.Show();
                    break;
                default:
                    this.Text = _moduleGroup;
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.NotImplemented", _moduleGroup);
                    break;
            }
        }
    }
}