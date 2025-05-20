using CRM_WindowsForms.Interface;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class ViewAllAccountManager : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Account Managers";

        public ViewAllAccountManager()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
            viewAllAccountManagerDataGridView.CellContentClick += ViewAllAccountManagerDataGridView_CellContentClick;
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
                string storedProcedureName = "[dbo].[spGetAllAccountManager]";
                DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataTable.DefaultView.Sort = "Last Name ASC";
                    viewAllAccountManagerDataGridView.AutoGenerateColumns = true;
                    viewAllAccountManagerDataGridView.DataSource = dataTable;
                    viewAllAccountManagerDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (viewAllAccountManagerDataGridView.Columns.Contains("Details"))
                    {
                        viewAllAccountManagerDataGridView.Columns.Remove("Details");
                    }
                    DataGridViewLinkColumn accountManagerDetailLink = new DataGridViewLinkColumn
                    {
                        HeaderText = "Details",
                        Text = "View Account Manager Details",
                        UseColumnTextForLinkValue = true,
                        Name = "Details"
                    };
                    viewAllAccountManagerDataGridView.Columns.Add(accountManagerDetailLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load account managers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewAllAccountManagerDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == viewAllAccountManagerDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (viewAllAccountManagerDataGridView.Columns.Contains("Account Manager Id"))
                    {
                        Guid accountManagerId = (Guid)viewAllAccountManagerDataGridView.Rows[e.RowIndex].Cells["Account Manager Id"].Value;
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

        private async void ViewAllAccountManagerRefreshDataButton_Click(object sender, EventArgs e)
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