namespace CRM_WindowsForms.Presentation
{
    public partial class CustomerManagement : Form
    {
        public CustomerManagement()
        {
            InitializeComponent();
        }

        private void customerManagementCreateCustomerButton_Click(object sender, EventArgs e)
        {
            CreateCustomer createCustomer = new CreateCustomer();
            createCustomer.Show();
        }

        private void customerManagementViewAllCustomersButton_Click(object sender, EventArgs e)
        {
            ViewAllCustomer viewAllCustomer = new ViewAllCustomer();
            viewAllCustomer.Show();
        }
    }
}