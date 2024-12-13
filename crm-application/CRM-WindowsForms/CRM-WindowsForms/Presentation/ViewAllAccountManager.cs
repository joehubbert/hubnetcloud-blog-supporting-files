using CRM_WindowsForms.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Diagnostics;
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
            viewAllAccountManagersDataGridView.CellContentClick += viewAllAccountManagersDataGridView_CellContentClick;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task ViewAllAccountManager_Load()
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
                    if (viewAllAccountManagersDataGridView.Columns.Contains("Details"))
                    {
                        viewAllAccountManagersDataGridView.Columns.Remove("Details");
                    }
                    DataGridViewLinkColumn accountManagerDetailLink = new DataGridViewLinkColumn
                    {
                        HeaderText = "Details",
                        Text = "View Account Manager Details",
                        UseColumnTextForLinkValue = true,
                        Name = "Details"
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
                try
                {
                    if (viewAllAccountManagersDataGridView.Columns.Contains("Account Manager Id"))
                    {
                        Guid accountManagerId = (Guid)viewAllAccountManagersDataGridView.Rows[e.RowIndex].Cells["Account Manager Id"].Value;
                        AccountManagerDetail accountManagerDetailForm = new AccountManagerDetail(accountManagerId);
                        accountManagerDetailForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Account Manager Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open account manager details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void viewAllAccountManagerRefreshDataButton_Click(object sender, EventArgs e)
        {
            await ViewAllAccountManager_Load();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            await ViewAllAccountManager_Load();
        }
    }
}