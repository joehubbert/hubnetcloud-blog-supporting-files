using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class ViewAllProduct : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Products";

        public ViewAllProduct()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
            viewAllProductDataGridView.CellContentClick += ViewAllProductDataGridView_CellContentClick;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task ViewAllProduct_Load()
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string storedProcedureName = "[dbo].[spGetAllProduct]";
                DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataTable.DefaultView.Sort = "Product Name ASC";
                    viewAllProductDataGridView.AutoGenerateColumns = true;
                    viewAllProductDataGridView.DataSource = dataTable;
                    viewAllProductDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (viewAllProductDataGridView.Columns.Contains("Details"))
                    {
                        viewAllProductDataGridView.Columns.Remove("Details");
                    }
                    DataGridViewLinkColumn productDetailLink = new DataGridViewLinkColumn
                    {
                        HeaderText = "Details",
                        Text = "View Product Details",
                        UseColumnTextForLinkValue = true,
                        Name = "Details"
                    };
                    viewAllProductDataGridView.Columns.Add(productDetailLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewAllProductDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == viewAllProductDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (viewAllProductDataGridView.Columns.Contains("Product Id"))
                    {
                        Guid productId = (Guid)viewAllProductDataGridView.Rows[e.RowIndex].Cells["Product Id"].Value;
                        ProductDetail productDetailForm = new ProductDetail(productId);
                        productDetailForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Product Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open Product details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void ViewAllProductRefreshDataButton_Click(object sender, EventArgs e)
        {
            await ViewAllProduct_Load();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            await ViewAllProduct_Load();
        }
    }
}