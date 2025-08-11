using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class ModuleHomeSimple : Form
    {
        private Guid _companyConfigurationId;
        private ActiveCompanyConfigurationHelper? _companyConfigHelper;
        private readonly string _moduleName;
        private readonly string applicationTitlePrefix = "CRM - ";
        private string dataSubjectPluralName;
        private string dataSubjectSingularName;
        private string moduleFriendlyName;
        private readonly string viewAllPrefix = "View All ";

        public ModuleHomeSimple(string moduleName)
        {
            InitializeComponent();
            _moduleName = moduleName;
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
            switch (_moduleName)
            {
                case "CompanyManagement":
                    this.BackColor = Color.LemonChiffon;
                    dataSubjectPluralName = "Companies";
                    dataSubjectSingularName = "Company";
                    moduleFriendlyName = "Company Management";
                    break;
                case "CustomerManagement":
                    this.BackColor = Color.LightGreen;
                    dataSubjectPluralName = "Customers";
                    dataSubjectSingularName = "Customer";
                    moduleFriendlyName = "Customer Management";
                    break;
                case "MarketingManagement":
                    this.BackColor = Color.NavajoWhite;
                    dataSubjectPluralName = "Marketing Campaigns";
                    dataSubjectSingularName = "Marketing Campaign";
                    moduleFriendlyName = "Marketing Management";
                    break;
                case "OrderManagement":
                    this.BackColor = Color.LightSalmon;
                    dataSubjectPluralName = "Orders";
                    dataSubjectSingularName = "Order";
                    moduleFriendlyName = "Order Management";
                    break;
                case "ProductManagement":
                    this.BackColor = Color.SkyBlue;
                    dataSubjectPluralName = "Products";
                    dataSubjectSingularName = "Product";
                    moduleFriendlyName = "Product Management";
                    break;
                case "SupplierManagement":
                    this.BackColor = Color.MediumAquamarine;
                    dataSubjectPluralName = "Suppliers";
                    dataSubjectSingularName = "Supplier";
                    moduleFriendlyName = "Supplier Management";
                    break;
                default:
                    this.Text = _moduleName;
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.NotImplemented", _moduleName);
                    break;
            }
            moduleHomeTitleLabel.Text = moduleFriendlyName;
            this.Text = $"{applicationTitlePrefix}{moduleFriendlyName}";
            moduleHomeCreateButton.Text = $"Create {dataSubjectSingularName}";
            moduleHomeViewAllButton.Text = $"{viewAllPrefix}{dataSubjectPluralName}";
        }

        private void moduleHomeCreateButton_Click(object sender, EventArgs e)
        {
            switch (_moduleName)
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
            switch (_moduleName)
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

        private async void changeActiveCompanyConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(moduleHomeStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.ShowChangeDialogAndReloadAsync(this);
        }
    }
}