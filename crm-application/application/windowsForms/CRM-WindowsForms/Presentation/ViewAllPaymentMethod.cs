using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class ViewAllPaymentMethod : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Payment Methods";

        public ViewAllPaymentMethod()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
            viewAllPaymentMethodDataGridView.CellContentClick += ViewAllPaymentMethodDataGridView_CellContentClick;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task ViewAllPaymentMethod_Load()
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string storedProcedureName = "[dbo].[spGetAllPaymentMethod]";
                DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataTable.DefaultView.Sort = "Payment Method ASC";
                    viewAllPaymentMethodDataGridView.AutoGenerateColumns = true;
                    viewAllPaymentMethodDataGridView.DataSource = dataTable;
                    viewAllPaymentMethodDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (viewAllPaymentMethodDataGridView.Columns.Contains("Details"))
                    {
                        viewAllPaymentMethodDataGridView.Columns.Remove("Details");
                    }
                    DataGridViewLinkColumn paymentMethodDetailLink = new DataGridViewLinkColumn
                    {
                        HeaderText = "Details",
                        Text = "View Payment Method Details",
                        UseColumnTextForLinkValue = true,
                        Name = "Details"
                    };
                    viewAllPaymentMethodDataGridView.Columns.Add(paymentMethodDetailLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Payment Methods: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewAllPaymentMethodDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == viewAllPaymentMethodDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (viewAllPaymentMethodDataGridView.Columns.Contains("Payment Method Id"))
                    {
                        Guid paymentMethodId = (Guid)viewAllPaymentMethodDataGridView.Rows[e.RowIndex].Cells["Payment Method Id"].Value;
                        PaymentMethodDetail paymentMethodDetailForm = new PaymentMethodDetail(paymentMethodId);
                        paymentMethodDetailForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Payment Method Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open Payment Method details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void ViewAllPaymentMethodRefreshDataButton_Click(object sender, EventArgs e)
        {
            await ViewAllPaymentMethod_Load();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            await ViewAllPaymentMethod_Load();
        }
    }
}