using CRM_WindowsForms_EnterpriseEdition.Presentation;

namespace CRM_WindowsForms.Presentation
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
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
            ViewAllData viewAllData = new ViewAllData("ViewAllCustomer", "CustomerManagement");
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
            ViewAllData viewAllData = new ViewAllData("ViewAllMarketingCampaign", "MarketingManagement");
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
            ViewAllData viewAllData = new ViewAllData("ViewAllProduct", "ProductManagement");
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
            ViewAllData viewAllData = new ViewAllData("ViewAllSupplier", "SupplierManagement");
            viewAllData.Show();
        }

        private void homeMenuStripOptionsAppConfiguration_Click(object sender, EventArgs e)
        {
            AppConfiguration appConfiguration = new AppConfiguration();
            appConfiguration.Show();
        }
    }
}