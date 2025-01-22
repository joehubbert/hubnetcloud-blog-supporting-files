using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class ViewAllCustomer : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Customers";

        public ViewAllCustomer()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
            viewAllCustomerDataGridView.CellContentClick += ViewAllCustomerDataGridView_CellContentClick;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task ViewAllCustomer_Load()
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string storedProcedureName = "[dbo].[spGetAllCustomer]";
                DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataTable.DefaultView.Sort = "Customer ASC";
                    viewAllCustomerDataGridView.AutoGenerateColumns = true;
                    viewAllCustomerDataGridView.DataSource = dataTable;
                    viewAllCustomerDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (viewAllCustomerDataGridView.Columns.Contains("Details"))
                    {
                        viewAllCustomerDataGridView.Columns.Remove("Details");
                    }
                    DataGridViewLinkColumn customerDetailLink = new DataGridViewLinkColumn
                    {
                        HeaderText = "Details",
                        Text = "View Customer Details",
                        UseColumnTextForLinkValue = true,
                        Name = "Details"
                    };
                    viewAllCustomerDataGridView.Columns.Add(customerDetailLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewAllCustomerDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == viewAllCustomerDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (viewAllCustomerDataGridView.Columns.Contains("Customer Id"))
                    {
                        Guid customerId = (Guid)viewAllCustomerDataGridView.Rows[e.RowIndex].Cells["Customer Id"].Value;
                        CustomerDetail customerDetailForm = new CustomerDetail(customerId);
                        customerDetailForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Customer Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open Customer details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void ViewAllCustomerRefreshDataButton_Click(object sender, EventArgs e)
        {
            await ViewAllCustomer_Load();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            await ViewAllCustomer_Load();
        }
    }
}