using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM_WindowsForms.Presentation
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void homeNavOrderManagement_Click(object sender, EventArgs e)
        {
            OrderManagement orderManagement = new OrderManagement();
            orderManagement.Show();
        }

        private void homeNavCustomerManagement_Click(object sender, EventArgs e)
        {
            CustomerManagement customerManagement = new CustomerManagement();
            customerManagement.Show();
        }

        private void homeNavProductManagement_Click(object sender, EventArgs e)
        {
            ProductManagement productManagement = new ProductManagement();
            productManagement.Show();
        }

        private void homeNavCompanyManagement_Click(object sender, EventArgs e)
        {
            CompanyManagement companyManagement = new CompanyManagement();
            companyManagement.Show();
        }

        private void homeNavSupplierManagementButton_Click(object sender, EventArgs e)
        {
            SupplierManagement supplierManagement = new SupplierManagement();
            supplierManagement.Show();
        }

        private void homeNavAppConfiguration_Click(object sender, EventArgs e)
        {
            AppConfiguration appConfiguration = new AppConfiguration();
            appConfiguration.Show();
        }

        private void homeMenuStripHelpAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void homeMenuStripHelpEasterEggSolitaire_Click(object sender, EventArgs e)
        {
            Solitaire solitaire = new Solitaire();
            solitaire.Show();
        }

        private void homeMenuStripCustomerManagementCreateCustomer_Click(object sender, EventArgs e)
        {
            CreateCustomer createCustomer = new CreateCustomer();
            createCustomer.Show();
        }

        private void homeMenuStripCustomerManagementViewAllCustomer_Click(object sender, EventArgs e)
        {
            ViewAllCustomer viewAllCustomer = new ViewAllCustomer();
            viewAllCustomer.Show();
        }

        private void homeMenuStripProductManagementCreateProduct_Click(object sender, EventArgs e)
        {
            CreateProduct createProduct = new CreateProduct();
            createProduct.Show();
        }

        private void homeMenuStripProductManagementViewAllProduct_Click(object sender, EventArgs e)
        {
            ViewAllProduct viewAllProduct = new ViewAllProduct();
            viewAllProduct.Show();
        }

        private void homeMenuStripSupplierManagementCreateSupplier_Click(object sender, EventArgs e)
        {
            CreateSupplier createSupplier = new CreateSupplier();
            createSupplier.Show();
        }

        private void homeMenuStripSupplierManagementViewAllSupplier_Click(object sender, EventArgs e)
        {
            ViewAllSupplier viewAllSupplier = new ViewAllSupplier();
            viewAllSupplier.Show();
        }

        private void homeMenuStripOptionsAppConfiguration_Click(object sender, EventArgs e)
        {
            AppConfiguration appConfiguration = new AppConfiguration();
            appConfiguration.Show();
        }
    }
}