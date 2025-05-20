using CRM_WindowsForms.Interface;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class ViewAllProductCategory : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Product Categories";

        public ViewAllProductCategory()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
            viewAllProductCategoryDataGridView.CellContentClick += ViewAllProductCategoryDataGridView_CellContentClick;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task ViewAllProductCategory_Load()
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string storedProcedureName = "[dbo].[spGetAllProductCategory]";
                DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataTable.DefaultView.Sort = "Product Category ASC";
                    viewAllProductCategoryDataGridView.AutoGenerateColumns = true;
                    viewAllProductCategoryDataGridView.DataSource = dataTable;
                    viewAllProductCategoryDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (viewAllProductCategoryDataGridView.Columns.Contains("Details"))
                    {
                        viewAllProductCategoryDataGridView.Columns.Remove("Details");
                    }
                    DataGridViewLinkColumn productCategoryDetailLink = new DataGridViewLinkColumn
                    {
                        HeaderText = "Details",
                        Text = "View Product Category Details",
                        UseColumnTextForLinkValue = true,
                        Name = "Details"
                    };
                    viewAllProductCategoryDataGridView.Columns.Add(productCategoryDetailLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Product Categorys: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewAllProductCategoryDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == viewAllProductCategoryDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (viewAllProductCategoryDataGridView.Columns.Contains("Product Category Id"))
                    {
                        Guid productCategoryId = (Guid)viewAllProductCategoryDataGridView.Rows[e.RowIndex].Cells["Product Category Id"].Value;
                        ProductCategoryDetail productCategoryDetailForm = new ProductCategoryDetail(productCategoryId);
                        productCategoryDetailForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Product Category Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open Product Category details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void ViewAllProductCategoryRefreshDataButton_Click(object sender, EventArgs e)
        {
            await ViewAllProductCategory_Load();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            await ViewAllProductCategory_Load();
        }
    }
}