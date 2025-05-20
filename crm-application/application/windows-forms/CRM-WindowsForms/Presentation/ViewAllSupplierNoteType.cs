using CRM_WindowsForms.Interface;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class ViewAllSupplierNoteType : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Supplier Note Types";

        public ViewAllSupplierNoteType()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
            viewAllSupplierNoteTypeDataGridView.CellContentClick += ViewAllSupplierNoteTypeDataGridView_CellContentClick;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task ViewAllSupplierNoteType_Load()
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string storedProcedureName = "[dbo].[spGetAllSupplierNoteType]";
                DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataTable.DefaultView.Sort = "Supplier Note Type ASC";
                    viewAllSupplierNoteTypeDataGridView.AutoGenerateColumns = true;
                    viewAllSupplierNoteTypeDataGridView.DataSource = dataTable;
                    viewAllSupplierNoteTypeDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (viewAllSupplierNoteTypeDataGridView.Columns.Contains("Details"))
                    {
                        viewAllSupplierNoteTypeDataGridView.Columns.Remove("Details");
                    }
                    DataGridViewLinkColumn supplierNoteTypeDetailLink = new DataGridViewLinkColumn
                    {
                        HeaderText = "Details",
                        Text = "View Supplier Note Type Details",
                        UseColumnTextForLinkValue = true,
                        Name = "Details"
                    };
                    viewAllSupplierNoteTypeDataGridView.Columns.Add(supplierNoteTypeDetailLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Supplier Note Types: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewAllSupplierNoteTypeDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == viewAllSupplierNoteTypeDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (viewAllSupplierNoteTypeDataGridView.Columns.Contains("Supplier Note Type Id"))
                    {
                        Guid supplierNoteTypeId = (Guid)viewAllSupplierNoteTypeDataGridView.Rows[e.RowIndex].Cells["Supplier Note Type Id"].Value;
                        SupplierNoteTypeDetail supplierNoteTypeDetailForm = new SupplierNoteTypeDetail(supplierNoteTypeId);
                        supplierNoteTypeDetailForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Supplier Note Type Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open Supplier Note Type details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void ViewAllSupplierNoteTypeRefreshDataButton_Click(object sender, EventArgs e)
        {
            await ViewAllSupplierNoteType_Load();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            await ViewAllSupplierNoteType_Load();
        }
    }
}