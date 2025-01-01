using CRM_WindowsForms.Model;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace CRM_WindowsForms.Presentation
{
    public partial class SalesRegionDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _salesRegionId;
        private string salesRegionDetailSalesRegionOriginalValue;
        private bool salesRegionDetailActiveStatusOriginalValue;

        public SalesRegionDetail(Guid salesRegionId)
        {
            InitializeComponent();
            _salesRegionId = salesRegionId;
            salesRegionDetailToggleEditModeButton.Click += salesRegionDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void ViewSalesRegionDetailSalesRegionInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@salesRegionId", _salesRegionId)
                };

                DataTable salesRegionDataTable = await executor.ExecuteAsync("[dbo].[spGetSalesRegion]", parameters);

                if (salesRegionDataTable != null)
                {
                    DataRow salesRegionDataRow = salesRegionDataTable.Rows[0];
                    salesRegionDetailSalesRegionIdTextbox.Text = salesRegionDataRow["Sales Region ID"].ToString();
                    salesRegionDetailSalesRegionTextbox.Text = salesRegionDataRow["Sales Region"].ToString();
                    salesRegionDetailCreatedByTextbox.Text = salesRegionDataRow["Created By"].ToString();
                    salesRegionDetailCreatedTimestampTextbox.Text = salesRegionDataRow["Created Timestamp"].ToString();
                    salesRegionDetailLastUpdatedByTextbox.Text = salesRegionDataRow["Modified By"].ToString();
                    salesRegionDetailLastUpdatedTimestampTextbox.Text = salesRegionDataRow["Modified Timestamp"].ToString();
                    salesRegionDetailActiveStatusCheckbox.Checked = (bool)salesRegionDataRow["Active Status"];

                    salesRegionDetailSalesRegionOriginalValue = salesRegionDataRow["Sales Region"].ToString();
                    salesRegionDetailActiveStatusOriginalValue = (bool)salesRegionDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Sales Region.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Sales Region details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            StringBuilder validationErrors = new StringBuilder();

            string salesRegion = salesRegionDetailSalesRegionTextbox.Text.Trim();

            if (salesRegion.Length > 50)
            {
                validationErrors.AppendLine($"Sales Region cannot be longer than 50 characters. Submitted length is {salesRegion.Length} characters.");
            }

            if (ContainsSqlInjectionRisk(salesRegion))
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

        private bool ContainsSqlInjectionRisk(string input)
        {
            string[] sqlInjectionRiskCharacters = { "--", ";--", ";", "/*", "*/", "@@" };
            foreach (var riskChar in sqlInjectionRiskCharacters)
            {
                if (input.Contains(riskChar))
                {
                    return true;
                }
            }
            return false;
        }

        private async void salesRegionDetailUpdateSalesRegionButton_Click(object sender, EventArgs e)
        {
            string salesRegion = salesRegionDetailSalesRegionTextbox.Text.Trim();

            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateInput())
            {
                return;
            }

            var result = MessageBox.Show("Are you sure that you want to update the following values?\n\n" +
                $"Sales Region Original Value: {salesRegionDetailSalesRegionOriginalValue}" + $"\nSales Region New Value: {salesRegion}\n" +
                $"Active Status Original Value: {salesRegionDetailActiveStatusOriginalValue}" + $"\nActive Status New Value: {salesRegionDetailActiveStatusCheckbox.Checked}\n\n" +
                "This action cannot be undone.", "Update Sales Region Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Code to update the customer type details
                try
                {
                    ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@salesRegion", salesRegion),
                        new SqlParameter("@salesRegionId", _salesRegionId),
                        new SqlParameter("@activeStatus", salesRegionDetailActiveStatusCheckbox.Checked)
                    };

                    await executor.ExecuteAsync("[dbo].[spUpdateSalesRegion]", parameters);
                    MessageBox.Show("Sales Region details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update Sales Region details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Update details were cancelled, no changes have been made to the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            ViewSalesRegionDetailSalesRegionInformation_Load(this, EventArgs.Empty);
        }

        private void salesRegionDetailToggleEditModeButton_Click(object sender, EventArgs e)
        {
            salesRegionDetailSalesRegionTextbox.Enabled = !salesRegionDetailSalesRegionTextbox.Enabled;
            salesRegionDetailActiveStatusCheckbox.Enabled = !salesRegionDetailActiveStatusCheckbox.Enabled;
            salesRegionDetailUpdateSalesRegionButton.Enabled = !salesRegionDetailUpdateSalesRegionButton.Enabled;
        }
    }
}