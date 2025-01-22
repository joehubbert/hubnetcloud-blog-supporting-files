using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class ViewAllDeliveryMethod : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Delivery Methods";

        public ViewAllDeliveryMethod()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
            viewAllDeliveryMethodDataGridView.CellContentClick += ViewAllDeliveryMethodDataGridView_CellContentClick;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task ViewAllDeliveryMethod_Load()
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string storedProcedureName = "[dbo].[spGetAllDeliveryMethod]";
                DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataTable.DefaultView.Sort = "Delivery Method ASC";
                    viewAllDeliveryMethodDataGridView.AutoGenerateColumns = true;
                    viewAllDeliveryMethodDataGridView.DataSource = dataTable;
                    viewAllDeliveryMethodDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (viewAllDeliveryMethodDataGridView.Columns.Contains("Details"))
                    {
                        viewAllDeliveryMethodDataGridView.Columns.Remove("Details");
                    }
                    DataGridViewLinkColumn deliveryMethodDetailLink = new DataGridViewLinkColumn
                    {
                        HeaderText = "Details",
                        Text = "View Delivery Method Details",
                        UseColumnTextForLinkValue = true,
                        Name = "Details"
                    };
                    viewAllDeliveryMethodDataGridView.Columns.Add(deliveryMethodDetailLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Delivery Methods: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewAllDeliveryMethodDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == viewAllDeliveryMethodDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (viewAllDeliveryMethodDataGridView.Columns.Contains("Delivery Method Id"))
                    {
                        Guid deliveryMethodId = (Guid)viewAllDeliveryMethodDataGridView.Rows[e.RowIndex].Cells["Deliv Id"].Value;
                        DeliveryMethodDetail deliveryMethodDetailForm = new DeliveryMethodDetail(deliveryMethodId);
                        deliveryMethodDetailForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Delivery Method Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open Delivery Method details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void ViewAllDeliveryMethodRefreshDataButton_Click(object sender, EventArgs e)
        {
            await ViewAllDeliveryMethod_Load();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            await ViewAllDeliveryMethod_Load();
        }
    }
}