using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class ViewAllOrderStatus : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Order Statuses";

        public ViewAllOrderStatus()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
            viewAllOrderStatusDataGridView.CellContentClick += ViewAllOrderStatusDataGridView_CellContentClick;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task ViewAllOrderStatus_Load()
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string storedProcedureName = "[dbo].[spGetAllOrderStatus]";
                DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataTable.DefaultView.Sort = "Order Status ASC";
                    viewAllOrderStatusDataGridView.AutoGenerateColumns = true;
                    viewAllOrderStatusDataGridView.DataSource = dataTable;
                    viewAllOrderStatusDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (viewAllOrderStatusDataGridView.Columns.Contains("Details"))
                    {
                        viewAllOrderStatusDataGridView.Columns.Remove("Details");
                    }
                    DataGridViewLinkColumn orderStatusDetailLink = new DataGridViewLinkColumn
                    {
                        HeaderText = "Details",
                        Text = "View Order Status Details",
                        UseColumnTextForLinkValue = true,
                        Name = "Details"
                    };
                    viewAllOrderStatusDataGridView.Columns.Add(orderStatusDetailLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Order Statuss: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewAllOrderStatusDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == viewAllOrderStatusDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (viewAllOrderStatusDataGridView.Columns.Contains("Order Status Id"))
                    {
                        Guid orderStatusId = (Guid)viewAllOrderStatusDataGridView.Rows[e.RowIndex].Cells["Order Status Id"].Value;
                        OrderStatusDetail orderStatusDetailForm = new OrderStatusDetail(orderStatusId);
                        orderStatusDetailForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Order Status Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open Order Status details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void ViewAllOrderStatusRefreshDataButton_Click(object sender, EventArgs e)
        {
            await ViewAllOrderStatus_Load();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            await ViewAllOrderStatus_Load();
        }
    }
}