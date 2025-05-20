namespace CRM_WindowsForms.Presentation
{
    public partial class ProductManagement : Form
    {
        public ProductManagement()
        {
            InitializeComponent();
        }

        private void productManagementCreateProductButton_Click(object sender, EventArgs e)
        {
            CreateProduct createProduct = new CreateProduct();
            createProduct.Show();
        }

        private void productManagementViewAllProductsButton_Click(object sender, EventArgs e)
        {
            ViewAllProduct viewAllProduct = new ViewAllProduct();
            viewAllProduct.Show();
        }
    }
}