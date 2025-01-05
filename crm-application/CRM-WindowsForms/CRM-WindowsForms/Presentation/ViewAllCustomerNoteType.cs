using CRM_WindowsForms.Model;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class ViewAllCustomerNoteType : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public ViewAllCustomerNoteType()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
            viewAllCustomerNoteTypeDataGridView.CellContentClick += viewAllCustomerNoteTypeDataGridView_CellContentClick;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task ViewAllCustomerNoteType_Load()
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                DataTable dataTable = await executor.ExecuteAsync("[dbo].[spGetAllCustomerNoteType]");

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataTable.DefaultView.Sort = "Customer Note Type ASC";
                    viewAllCustomerNoteTypeDataGridView.AutoGenerateColumns = true;
                    viewAllCustomerNoteTypeDataGridView.DataSource = dataTable;
                    viewAllCustomerNoteTypeDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (viewAllCustomerNoteTypeDataGridView.Columns.Contains("Details"))
                    {
                        viewAllCustomerNoteTypeDataGridView.Columns.Remove("Details");
                    }
                    DataGridViewLinkColumn customerNoteTypeDetailLink = new DataGridViewLinkColumn
                    {
                        HeaderText = "Details",
                        Text = "View Customer Note Type Details",
                        UseColumnTextForLinkValue = true,
                        Name = "Details"
                    };
                    viewAllCustomerNoteTypeDataGridView.Columns.Add(customerNoteTypeDetailLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Customer Note Types: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void viewAllCustomerNoteTypeDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == viewAllCustomerNoteTypeDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (viewAllCustomerNoteTypeDataGridView.Columns.Contains("Customer Note Type Id"))
                    {
                        Guid customerNoteTypeId = (Guid)viewAllCustomerNoteTypeDataGridView.Rows[e.RowIndex].Cells["Customer Note Type Id"].Value;
                        CustomerNoteTypeDetail customerNoteTypeDetailForm = new CustomerNoteTypeDetail(customerNoteTypeId);
                        customerNoteTypeDetailForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Customer Note Type Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open Customer Note Type details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void viewAllCustomerNoteTypeRefreshDataButton_Click(object sender, EventArgs e)
        {
            await ViewAllCustomerNoteType_Load();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            await ViewAllCustomerNoteType_Load();
        }
    }
}