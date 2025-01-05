using CRM_WindowsForms.Model;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class ViewAllCurrency : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public ViewAllCurrency()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
            viewAllCurrencyDataGridView.CellContentClick += viewAllCurrencyDataGridView_CellContentClick;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task ViewAllCurrency_Load()
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                DataTable dataTable = await executor.ExecuteAsync("[dbo].[spGetAllCurrency]");

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataTable.DefaultView.Sort = "Currency Code ASC";
                    viewAllCurrencyDataGridView.AutoGenerateColumns = true;
                    viewAllCurrencyDataGridView.DataSource = dataTable;
                    viewAllCurrencyDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (viewAllCurrencyDataGridView.Columns.Contains("Details"))
                    {
                        viewAllCurrencyDataGridView.Columns.Remove("Details");
                    }
                    DataGridViewLinkColumn currencyDetailLink = new DataGridViewLinkColumn
                    {
                        HeaderText = "Details",
                        Text = "View Currency Details",
                        UseColumnTextForLinkValue = true,
                        Name = "Details"
                    };
                    viewAllCurrencyDataGridView.Columns.Add(currencyDetailLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Currencys: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void viewAllCurrencyDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == viewAllCurrencyDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (viewAllCurrencyDataGridView.Columns.Contains("Currency Id"))
                    {
                        Guid currencyId = (Guid)viewAllCurrencyDataGridView.Rows[e.RowIndex].Cells["Currency Id"].Value;
                        CurrencyDetail currencyDetailForm = new CurrencyDetail(currencyId);
                        currencyDetailForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Currency Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open Currency details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void viewAllCurrencyRefreshDataButton_Click(object sender, EventArgs e)
        {
            await ViewAllCurrency_Load();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            await ViewAllCurrency_Load();
        }
    }
}