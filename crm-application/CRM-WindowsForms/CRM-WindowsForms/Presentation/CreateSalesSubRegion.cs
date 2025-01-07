using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreateSalesSubRegion : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreateSalesSubRegion()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadDatabaseConnectionSettingsAsync();
            CreateSalesSubRegionLoadSalesRegionAsync();
        }

        private void InitializeCustomComponents()
        {
            createSalesSubRegionSalesRegionComboBox.DropDown += new EventHandler(CreateSalesSubRegionSalesRegionComboBox_DropDown);
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void CreateSalesSubRegionLoadSalesRegionAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                DataTable salesRegionData = await executor.ExecuteAsync("[dbo].[spGetAllSalesRegion]");
                var salesRegionList = salesRegionData.AsEnumerable()
                    .Select(row => new
                    {
                        SalesRegionId = row.Field<Guid>("Sales Region Id"),
                        SalesRegion = row.Field<string>("Sales Region")
                    })
                    .OrderBy(item => item.SalesRegion)
                    .ToList();
                createSalesSubRegionSalesRegionComboBox.DataSource = salesRegionList;
                createSalesSubRegionSalesRegionComboBox.DisplayMember = "SalesRegion";
                createSalesSubRegionSalesRegionComboBox.ValueMember = "SalesRegionId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Sales Region data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateSalesSubRegionSalesRegionComboBox_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private bool ValidateInput()
        {
            StringBuilder validationErrors = new StringBuilder();

            string salesSubRegion = createSalesSubRegionSalesSubRegionTextbox.Text.TrimEnd();

            if (salesSubRegion.Length > 50)
            {
                validationErrors.AppendLine($"Sales Sub Region cannot be longer than 50 characters. Submitted length is {salesSubRegion.Length} characters.");
            }

            if (SQLInjectionRiskCheck.ContainsSqlInjectionRisk(salesSubRegion))
            {
                validationErrors.AppendLine("Input contains potentially dangerous characters that could lead to SQL injection.");
            }

            if (validationErrors.Length > 0)
            {
                MessageBox.Show(validationErrors.ToString(), "Validation Error: ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async void createSalesSubRegionSubmitButton_Click(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateInput())
            {
                return;
            }

            try
            {
                bool activeStatus = createSalesSubRegionActiveStatusCheckbox.Checked;
                Guid salesRegionId = Guid.Parse(createSalesSubRegionSalesRegionComboBox.SelectedValue.ToString());
                string salesSubRegion = createSalesSubRegionSalesSubRegionTextbox.Text.TrimEnd();

                var parameters = new[]
                {
                        new SqlParameter("@activeStatus", activeStatus),
                        new SqlParameter("@salesRegionId", salesRegionId),
                        new SqlParameter("@salesSubRegion", salesSubRegion)
                    };

                ExecuteStoredProcedure executeor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                await executeor.ExecuteNonQueryAsync("[dbo].[spCreateSalesSubRegion]", parameters);

                MessageBox.Show("New Sales Sub Region added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add new Sales Sub Region: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}