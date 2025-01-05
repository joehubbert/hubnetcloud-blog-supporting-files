using CRM_WindowsForms.Model;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class ViewAllProductNoteType : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public ViewAllProductNoteType()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
            viewAllProductNoteTypeDataGridView.CellContentClick += viewAllProductNoteTypeDataGridView_CellContentClick;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task ViewAllProductNoteType_Load()
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                DataTable dataTable = await executor.ExecuteAsync("[dbo].[spGetAllProductNoteType]");

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataTable.DefaultView.Sort = "Product Note Type ASC";
                    viewAllProductNoteTypeDataGridView.AutoGenerateColumns = true;
                    viewAllProductNoteTypeDataGridView.DataSource = dataTable;
                    viewAllProductNoteTypeDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (viewAllProductNoteTypeDataGridView.Columns.Contains("Details"))
                    {
                        viewAllProductNoteTypeDataGridView.Columns.Remove("Details");
                    }
                    DataGridViewLinkColumn productNoteTypeDetailLink = new DataGridViewLinkColumn
                    {
                        HeaderText = "Details",
                        Text = "View Product Note Type Details",
                        UseColumnTextForLinkValue = true,
                        Name = "Details"
                    };
                    viewAllProductNoteTypeDataGridView.Columns.Add(productNoteTypeDetailLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Product Note Types: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void viewAllProductNoteTypeDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == viewAllProductNoteTypeDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (viewAllProductNoteTypeDataGridView.Columns.Contains("Product Note Type Id"))
                    {
                        Guid productNoteTypeId = (Guid)viewAllProductNoteTypeDataGridView.Rows[e.RowIndex].Cells["Product Note Type Id"].Value;
                        ProductNoteTypeDetail productNoteTypeDetailForm = new ProductNoteTypeDetail(productNoteTypeId);
                        productNoteTypeDetailForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Product Note Type Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open Product Note Type details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void viewAllProductNoteTypeRefreshDataButton_Click(object sender, EventArgs e)
        {
            await ViewAllProductNoteType_Load();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            await ViewAllProductNoteType_Load();
        }
    }
}