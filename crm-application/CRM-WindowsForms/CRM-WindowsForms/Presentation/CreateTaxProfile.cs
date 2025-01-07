using CRM_WindowsForms.Model;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreateTaxProfile : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreateTaxProfile()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private bool ValidateInput()
        {
            StringBuilder validationErrors = new StringBuilder();

            string taxProfile = createTaxProfileTaxProfileTextbox.Text.TrimEnd();
            string taxRateA = createTaxProfileTaxRateTextboxA.Text.TrimEnd();
            string taxRateB = createTaxProfileTaxRateTextboxB.Text.TrimEnd();

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

        private async void createTaxProfileSubmitButton_Click(object sender, EventArgs e)
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
                bool activeStatus = createTaxProfileActiveStatusCheckbox.Checked;
                string taxProfile = createTaxProfileTaxProfileTextbox.Text.TrimEnd();
                decimal taxRate = decimal.Parse(createTaxProfileTaxRateTextboxA.Text.TrimEnd()) + (decimal.Parse(createTaxProfileTaxRateTextboxB.Text.TrimEnd()) / 100);

                var parameters = new[]
                {
                        new SqlParameter("@activeStatus", activeStatus),
                        new SqlParameter("@taxProfile", taxProfile),
                        new SqlParameter("@taxRate", taxRate)
                    };

                ExecuteStoredProcedure executeor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                await executeor.ExecuteNonQueryAsync("[dbo].[spCreateTaxProfile]", parameters);

                MessageBox.Show("New Tax Profile added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add new Tax Profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}