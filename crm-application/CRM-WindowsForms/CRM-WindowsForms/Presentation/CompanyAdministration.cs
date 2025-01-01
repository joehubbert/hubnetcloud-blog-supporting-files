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
    public partial class CompanyAdministration : Form
    {
        public CompanyAdministration()
        {
            InitializeComponent();
        }

        private void companyAdministrationAddNewAccountManagerButton_Click(object sender, EventArgs e)
        {
            CreateAccountManager addNewAccountManager = new CreateAccountManager();
            addNewAccountManager.Show();
        }

        private void companyAdministrationViewAllAccountManagersButton_Click(object sender, EventArgs e)
        {
            ViewAllAccountManager viewAllAccountManager = new ViewAllAccountManager();
            viewAllAccountManager.Show();
        }

        private void companyAdministrationCreateCustomerTierButton_Click(object sender, EventArgs e)
        {
            CreateCustomerTier createCustomerTier = new CreateCustomerTier();
            createCustomerTier.Show();
        }

        private void companyAdministrationViewAllCustomerTierButton_Click(object sender, EventArgs e)
        {
            ViewAllCustomerTier viewAllCustomerTier = new ViewAllCustomerTier();
            viewAllCustomerTier.Show();
        }

        private void companyAdministrationCreateCustomerTypeButton_Click(object sender, EventArgs e)
        {
            CreateCustomerType createCustomerType = new CreateCustomerType();
            createCustomerType.Show();
        }

        private void companyAdministrationViewAllCustomerTypeButton_Click(object sender, EventArgs e)
        {
            ViewAllCustomerType viewAllCustomerType = new ViewAllCustomerType();
            viewAllCustomerType.Show();
        }
    }
}
