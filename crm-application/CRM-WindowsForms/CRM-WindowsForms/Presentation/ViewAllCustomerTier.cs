using CRM_WindowsForms.Model;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class ViewAllCustomerTier : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public ViewAllCustomerTier()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
            viewAllCustomerTierDataGridView.CellContentClick += viewAllCustomerTierDataGridView_CellContentClick;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task ViewAllCustomerTier_Load()
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                DataTable dataTable = await executor.ExecuteAsync("[dbo].[spGetAllCustomerTier]");

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataTable.DefaultView.Sort = "Customer Tier Code ASC";
                    viewAllCustomerTierDataGridView.AutoGenerateColumns = true;
                    viewAllCustomerTierDataGridView.DataSource = dataTable;
                    viewAllCustomerTierDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (viewAllCustomerTierDataGridView.Columns.Contains("Details"))
                    {
                        viewAllCustomerTierDataGridView.Columns.Remove("Details");
                    }
                    DataGridViewLinkColumn customerTierDetailLink = new DataGridViewLinkColumn
                    {
                        HeaderText = "Details",
                        Text = "View Customer Tier Details",
                        UseColumnTextForLinkValue = true,
                        Name = "Details"
                    };
                    viewAllCustomerTierDataGridView.Columns.Add(customerTierDetailLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Customer Tiers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void viewAllCustomerTierDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == viewAllCustomerTierDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (viewAllCustomerTierDataGridView.Columns.Contains("Customer Tier Id"))
                    {
                        Guid customerTierId = (Guid)viewAllCustomerTierDataGridView.Rows[e.RowIndex].Cells["Customer Tier Id"].Value;
                        CustomerTierDetail customerTierDetailForm = new CustomerTierDetail(customerTierId);
                        customerTierDetailForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Customer Tier Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open Customer Tier details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void viewAllCustomerTierRefreshDataButton_Click(object sender, EventArgs e)
        {
            await ViewAllCustomerTier_Load();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            await ViewAllCustomerTier_Load();
        }
    }
}