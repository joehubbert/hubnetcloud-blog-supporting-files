using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class ViewAllTaxProfile : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Tax Profiles";

        public ViewAllTaxProfile()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
            viewAllTaxProfileDataGridView.CellContentClick += ViewAllTaxProfileDataGridView_CellContentClick;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task ViewAllTaxProfile_Load()
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string storedProcedureName = "[dbo].[spGetAllTaxProfile]";
                DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataTable.DefaultView.Sort = "Tax Profile ASC";
                    viewAllTaxProfileDataGridView.AutoGenerateColumns = true;
                    viewAllTaxProfileDataGridView.DataSource = dataTable;
                    viewAllTaxProfileDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (viewAllTaxProfileDataGridView.Columns.Contains("Details"))
                    {
                        viewAllTaxProfileDataGridView.Columns.Remove("Details");
                    }
                    DataGridViewLinkColumn taxProfileDetailLink = new DataGridViewLinkColumn
                    {
                        HeaderText = "Details",
                        Text = "View Tax Profile Details",
                        UseColumnTextForLinkValue = true,
                        Name = "Details"
                    };
                    viewAllTaxProfileDataGridView.Columns.Add(taxProfileDetailLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Tax Profiles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewAllTaxProfileDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == viewAllTaxProfileDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (viewAllTaxProfileDataGridView.Columns.Contains("Tax Profile Id"))
                    {
                        Guid taxProfileId = (Guid)viewAllTaxProfileDataGridView.Rows[e.RowIndex].Cells["Tax Profile Id"].Value;
                        TaxProfileDetail taxProfileDetailForm = new TaxProfileDetail(taxProfileId);
                        taxProfileDetailForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Tax Profile Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open Tax Profile details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void ViewAllTaxProfileRefreshDataButton_Click(object sender, EventArgs e)
        {
            await ViewAllTaxProfile_Load();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            await ViewAllTaxProfile_Load();
        }
    }
}