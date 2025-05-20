using CRM_WindowsForms.Interface;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class ViewAllSalesRegion : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Sales Regions";

        public ViewAllSalesRegion()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
            viewAllSalesRegionDataGridView.CellContentClick += ViewAllSalesRegionDataGridView_CellContentClick;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task ViewAllSalesRegion_Load()
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string storedProcedureName = "[dbo].[spGetAllSalesRegion]";
                DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataTable.DefaultView.Sort = "Sales Region ASC";
                    viewAllSalesRegionDataGridView.AutoGenerateColumns = true;
                    viewAllSalesRegionDataGridView.DataSource = dataTable;
                    viewAllSalesRegionDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (viewAllSalesRegionDataGridView.Columns.Contains("Details"))
                    {
                        viewAllSalesRegionDataGridView.Columns.Remove("Details");
                    }
                    DataGridViewLinkColumn salesRegionDetailLink = new DataGridViewLinkColumn
                    {
                        HeaderText = "Details",
                        Text = "View Sales Region Details",
                        UseColumnTextForLinkValue = true,
                        Name = "Details"
                    };
                    viewAllSalesRegionDataGridView.Columns.Add(salesRegionDetailLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Sales Regions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewAllSalesRegionDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == viewAllSalesRegionDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (viewAllSalesRegionDataGridView.Columns.Contains("Sales Region Id"))
                    {
                        Guid salesRegionId = (Guid)viewAllSalesRegionDataGridView.Rows[e.RowIndex].Cells["Sales Region Id"].Value;
                        SalesRegionDetail salesRegionDetailForm = new SalesRegionDetail(salesRegionId);
                        salesRegionDetailForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sales Region Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open Sales Region details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void ViewAllSalesRegionRefreshDataButton_Click(object sender, EventArgs e)
        {
            await ViewAllSalesRegion_Load();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            await ViewAllSalesRegion_Load();
        }
    }
}