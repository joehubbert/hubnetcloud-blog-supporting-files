namespace CRM_WindowsForms.Presentation
{
    public partial class SupplierManagement : Form
    {
        public SupplierManagement()
        {
            InitializeComponent();
        }

        private void supplierManagementCreateSupplierButton_Click(object sender, EventArgs e)
        {
            CreateSupplier createSupplier = new CreateSupplier();
            createSupplier.Show();
        }

        private void supplierManagementViewAllSuppliersButton_Click(object sender, EventArgs e)
        {
            ViewAllSupplier viewAllSupplier = new ViewAllSupplier();
            viewAllSupplier.Show();
        }
    }
}