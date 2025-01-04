using CRM_WindowsForms.Model;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace CRM_WindowsForms.Presentation
{
    public partial class TaxProfileDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _taxProfileId;
        private bool taxProfileDetailActiveStatusOriginalValue;
        private string taxProfileDetailTaxProfileOriginalValue;
        private decimal taxProfileDetailTaxRateOriginalValue;

        public TaxProfileDetail(Guid taxProfileId)
        {
            InitializeComponent();
            _taxProfileId = taxProfileId;
            taxProfileDetailToggleEditModeButton.Click += taxProfileDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void SplitDecimal(decimal decimalValue, out string partA, out string partB)
        {
            string[] parts = decimalValue.ToString().Split('.');
            partA = parts[0];
            partB = parts.Length > 1 ? parts[1] : "0";
        }

        private async void ViewTaxProfileDetailTaxProfileInformation_Load(object sender, EventArgs e)
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
                    new SqlParameter("@taxProfileId", _taxProfileId)
                };

                DataTable taxProfileDataTable = await executor.ExecuteAsync("[dbo].[spGetTaxProfile]", parameters);

                if (taxProfileDataTable != null)
                {
                    DataRow taxProfileDataRow = taxProfileDataTable.Rows[0];
                    string taxRatePartA;
                    string taxRatePartB;

                    SplitDecimal((decimal)taxProfileDataRow["Tax Rate"], out taxRatePartA, out taxRatePartB);

                    taxProfileDetailTaxProfileIdTextbox.Text = taxProfileDataRow["Tax Profile ID"].ToString();
                    taxProfileDetailTaxProfileTextbox.Text = taxProfileDataRow["Tax Profile"].ToString();
                    taxProfileDetailTaxRateTextboxA.Text = taxRatePartA;
                    taxProfileDetailTaxRateTextboxB.Text = taxRatePartB;
                    taxProfileDetailCreatedByTextbox.Text = taxProfileDataRow["Created By"].ToString();
                    taxProfileDetailCreatedTimestampTextbox.Text = taxProfileDataRow["Created Timestamp"].ToString();
                    taxProfileDetailLastUpdatedByTextbox.Text = taxProfileDataRow["Modified By"].ToString();
                    taxProfileDetailLastUpdatedTimestampTextbox.Text = taxProfileDataRow["Modified Timestamp"].ToString();
                    taxProfileDetailActiveStatusCheckbox.Checked = (bool)taxProfileDataRow["Active Status"];

                    taxProfileDetailTaxProfileOriginalValue = taxProfileDataRow["Tax Profile"].ToString();
                    taxProfileDetailTaxRateOriginalValue = (decimal)taxProfileDataRow["Tax Rate"];
                    taxProfileDetailActiveStatusOriginalValue = (bool)taxProfileDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Tax Profile.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Tax Profile details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            StringBuilder validationErrors = new StringBuilder();

            string taxProfile = taxProfileDetailTaxProfileTextbox.Text.Trim();
            string taxRateA = taxProfileDetailTaxRateTextboxA.Text.Trim();
            string taxRateB = taxProfileDetailTaxRateTextboxB.Text.Trim();

            if (taxProfile.Length > 50)
            {
                validationErrors.AppendLine($"Tax Profile cannot be longer than 50 characters. Submitted length is {taxProfile.Length} characters.");
            }

            if (taxRateA.Length > 5)
            {
                validationErrors.AppendLine($"Tax Rate Part A cannot be longer than 5 characters. Submitted length is {taxRateA.Length} characters.");
            }

            if (taxRateB.Length > 2)
            {
                validationErrors.AppendLine($"Tax Rate Part B cannot be longer than 2 characters. Submitted length is {taxRateB.Length} characters.");
            }

            if (!Regex.IsMatch(taxRateA, @"^\d+$"))
            {
                validationErrors.AppendLine("Tax Rate Part A must contain only numbers.");
            }

            if (!Regex.IsMatch(taxRateB, @"^\d+$"))
            {
                validationErrors.AppendLine("Tax Rate Part B must contain only numbers.");
            }

            if (ContainsSqlInjectionRisk(taxProfile) ||
                ContainsSqlInjectionRisk(taxRateA) ||
                ContainsSqlInjectionRisk(taxRateB))
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


        private async void taxProfileDetailUpdateTaxProfileButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = taxProfileDetailActiveStatusCheckbox.Checked;
            string taxProfile = taxProfileDetailTaxProfileTextbox.Text.Trim();
            decimal taxRate = decimal.Parse(taxProfileDetailTaxRateTextboxA.Text.Trim()) + (decimal.Parse(taxProfileDetailTaxRateTextboxB.Text.Trim()) / 100);

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
                $"Tax Profile Original Value: {taxProfileDetailTaxProfileOriginalValue}" + $"\nTax Profile New Value: {taxProfile}\n" +
                $"Tax Rate Original Value: {taxProfileDetailTaxRateOriginalValue.ToString()}" + $"\nTax Rate New Value: {taxRate.ToString()}\n" +
                $"Active Status Original Value: {taxProfileDetailActiveStatusOriginalValue}" + $"\nActive Status New Value: {taxProfileDetailActiveStatusCheckbox.Checked}\n\n" +
                "This action cannot be undone.", "Update Tax Profile Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Code to update the customer tier details
                try
                {
                    ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@activeStatus", taxProfileDetailActiveStatusCheckbox.Checked),
                        new SqlParameter("@taxProfile", taxProfile),
                        new SqlParameter("@taxProfileId", _taxProfileId),
                        new SqlParameter("@taxRate", taxRate) 
                    };

                    await executor.ExecuteAsync("[dbo].[spUpdateTaxProfile]", parameters);
                    MessageBox.Show("Tax Profile details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update Tax Profile details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ViewTaxProfileDetailTaxProfileInformation_Load(this, EventArgs.Empty);
        }

        private void taxProfileDetailToggleEditModeButton_Click(object sender, EventArgs e)
        {
            taxProfileDetailTaxProfileTextbox.Enabled = !taxProfileDetailTaxProfileTextbox.Enabled;
            taxProfileDetailTaxRateTextboxA.Enabled = !taxProfileDetailTaxRateTextboxA.Enabled;
            taxProfileDetailTaxRateTextboxB.Enabled = !taxProfileDetailTaxRateTextboxB.Enabled;
            taxProfileDetailActiveStatusCheckbox.Enabled = !taxProfileDetailActiveStatusCheckbox.Enabled;
            taxProfileDetailUpdateTaxProfileButton.Enabled = !taxProfileDetailUpdateTaxProfileButton.Enabled;
        }
    }
}