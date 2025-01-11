using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class ViewAllCustomerType : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Customer Types";

        public ViewAllCustomerType()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
            viewAllCustomerTypeDataGridView.CellContentClick += viewAllCustomerTypeDataGridView_CellContentClick;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task ViewAllCustomerType_Load()
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string storedProcedureName = "[dbo].[spGetAllCustomerType]";
                DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataTable.DefaultView.Sort = "Customer Type ASC";
                    viewAllCustomerTypeDataGridView.AutoGenerateColumns = true;
                    viewAllCustomerTypeDataGridView.DataSource = dataTable;
                    viewAllCustomerTypeDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (viewAllCustomerTypeDataGridView.Columns.Contains("Details"))
                    {
                        viewAllCustomerTypeDataGridView.Columns.Remove("Details");
                    }
                    DataGridViewLinkColumn customerTypeDetailLink = new DataGridViewLinkColumn
                    {
                        HeaderText = "Details",
                        Text = "View Customer Type Details",
                        UseColumnTextForLinkValue = true,
                        Name = "Details"
                    };
                    viewAllCustomerTypeDataGridView.Columns.Add(customerTypeDetailLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Customer Types: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void viewAllCustomerTypeDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == viewAllCustomerTypeDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (viewAllCustomerTypeDataGridView.Columns.Contains("Customer Type Id"))
                    {
                        Guid customerTypeId = (Guid)viewAllCustomerTypeDataGridView.Rows[e.RowIndex].Cells["Customer Type Id"].Value;
                        CustomerTypeDetail customerTypeDetailForm = new CustomerTypeDetail(customerTypeId);
                        customerTypeDetailForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Customer Type Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open Customer Type details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void viewAllCustomerTypeRefreshDataButton_Click(object sender, EventArgs e)
        {
            await ViewAllCustomerType_Load();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            await ViewAllCustomerType_Load();
        }
    }
}