using CRM_WindowsForms.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRM_WindowsForms.Presentation
{
    public partial class ViewAllAccountManager : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public ViewAllAccountManager()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void ViewAllAccountManager_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                DataTable dataTable = await executor.ExecuteAsync("[dbo].[GetAllAccountManager]");

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    viewAllAccountManagersDataGridView.AutoGenerateColumns = true;
                    viewAllAccountManagersDataGridView.DataSource = dataTable;
                    viewAllAccountManagersDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    DataGridViewLinkColumn accountManagerDetailLink = new DataGridViewLinkColumn
                    {
                        HeaderText = "Details",
                        Text = "View Account Manager Details",
                        UseColumnTextForLinkValue = true
                    };
                    viewAllAccountManagersDataGridView.Columns.Add(accountManagerDetailLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load account managers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void viewAllAccountManagersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == viewAllAccountManagersDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                int accountManagerId = Convert.ToInt32(viewAllAccountManagersDataGridView.Rows[e.RowIndex].Cells["AccountManagerId"].Value);
                AccountManagerDetail accountManagerDetailForm = new AccountManagerDetail(accountManagerId);
                accountManagerDetailForm.Show();
            }
        }

        private async void viewAllAccountManagersRefreshButton_Click(object sender, EventArgs e)
        {
            await LoadDatabaseConnectionSettingsAsync();
            ViewAllAccountManager_Load(this, EventArgs.Empty);
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            ViewAllAccountManager_Load(this, EventArgs.Empty);
        }
    }
}