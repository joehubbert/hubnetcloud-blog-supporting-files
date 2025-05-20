using CRM_WindowsForms.Interface;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class ViewAllSupplier : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Suppliers";

        public ViewAllSupplier()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
            viewAllSupplierDataGridView.CellContentClick += ViewAllSupplierDataGridView_CellContentClick;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task ViewAllSupplier_Load()
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string storedProcedureName = "[dbo].[spGetAllSupplier]";
                DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataTable.DefaultView.Sort = "Supplier Name ASC";
                    viewAllSupplierDataGridView.AutoGenerateColumns = true;
                    viewAllSupplierDataGridView.DataSource = dataTable;
                    viewAllSupplierDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (viewAllSupplierDataGridView.Columns.Contains("Details"))
                    {
                        viewAllSupplierDataGridView.Columns.Remove("Details");
                    }
                    DataGridViewLinkColumn supplierDetailLink = new DataGridViewLinkColumn
                    {
                        HeaderText = "Details",
                        Text = "View Supplier Details",
                        UseColumnTextForLinkValue = true,
                        Name = "Details"
                    };
                    viewAllSupplierDataGridView.Columns.Add(supplierDetailLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Suppliers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewAllSupplierDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == viewAllSupplierDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (viewAllSupplierDataGridView.Columns.Contains("Supplier Id"))
                    {
                        Guid supplierId = (Guid)viewAllSupplierDataGridView.Rows[e.RowIndex].Cells["Supplier Id"].Value;
                        SupplierDetail supplierDetailForm = new SupplierDetail(supplierId);
                        supplierDetailForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Supplier Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open Supplier details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void ViewAllSupplierRefreshDataButton_Click(object sender, EventArgs e)
        {
            await ViewAllSupplier_Load();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            await ViewAllSupplier_Load();
        }
    }
}