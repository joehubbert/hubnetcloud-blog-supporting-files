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

        private void homeNavCompanyAdministration_Click(object sender, EventArgs e)
        {
            CompanyAdministration companyAdministration = new CompanyAdministration();
            companyAdministration.Show();
        }

        private void homeNavAppConfiguration_Click(object sender, EventArgs e)
        {
            AppConfiguration appConfiguration = new AppConfiguration();
            appConfiguration.Show();
        }
    }
}