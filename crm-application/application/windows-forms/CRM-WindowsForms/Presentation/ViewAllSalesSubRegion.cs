using CRM_WindowsForms.Interface;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class ViewAllSalesSubRegion : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Sales Sub Regions";

        public ViewAllSalesSubRegion()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
            viewAllSalesSubRegionDataGridView.CellContentClick += ViewAllSalesSubRegionDataGridView_CellContentClick;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task ViewAllSalesSubRegion_Load()
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string storedProcedureName = "[dbo].[spGetAllSalesSubRegion]";
                DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataTable.DefaultView.Sort = "Sales Region ASC, Sales Sub Region ASC";
                    viewAllSalesSubRegionDataGridView.AutoGenerateColumns = true;
                    viewAllSalesSubRegionDataGridView.DataSource = dataTable;
                    viewAllSalesSubRegionDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (viewAllSalesSubRegionDataGridView.Columns.Contains("Details"))
                    {
                        viewAllSalesSubRegionDataGridView.Columns.Remove("Details");
                    }
                    viewAllSalesSubRegionDataGridView.Columns.Remove("Sales Region Id");
                    DataGridViewLinkColumn salesRegionDetailLink = new DataGridViewLinkColumn
                    {
                        HeaderText = "Details",
                        Text = "View Sales Sub Region Details",
                        UseColumnTextForLinkValue = true,
                        Name = "Details"
                    };
                    viewAllSalesSubRegionDataGridView.Columns.Add(salesRegionDetailLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Sales Sub Regions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewAllSalesSubRegionDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == viewAllSalesSubRegionDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (viewAllSalesSubRegionDataGridView.Columns.Contains("Sales Sub Region Id"))
                    {
                        Guid salesRegionId = (Guid)viewAllSalesSubRegionDataGridView.Rows[e.RowIndex].Cells["Sales Sub Region Id"].Value;
                        SalesSubRegionDetail salesRegionDetailForm = new SalesSubRegionDetail(salesRegionId);
                        salesRegionDetailForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sales Sub Region Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open Sales Sub Region details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void ViewAllSalesSubRegionRefreshDataButton_Click(object sender, EventArgs e)
        {
            await ViewAllSalesSubRegion_Load();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            await ViewAllSalesSubRegion_Load();
        }
    }
}