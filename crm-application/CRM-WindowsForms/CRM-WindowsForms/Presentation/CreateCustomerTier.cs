using CRM_WindowsForms.Model;
using Microsoft.Data.SqlClient;
using System.Text;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreateCustomerTier : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreateCustomerTier()
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

            string customerTierCode = createCustomerTierCustomerTierCodeTextbox.Text.TrimEnd();
            string customerTierDescription = createCustomerTierCustomerTierDescriptionTextbox.Text.TrimEnd();

            if (customerTierCode.Length > 1)
            {
                validationErrors.AppendLine($"Customer Tier Code cannot be longer than 1 character. Submitted length is {customerTierCode.Length} characters.");
            }

            if (customerTierDescription.Length > 50)
            {
                validationErrors.AppendLine($"Customer Tier Description cannot be longer than 50 characters. Submitted length is {customerTierDescription.Length} characters.");
            }

            if (ContainsSqlInjectionRisk(customerTierCode) ||
                ContainsSqlInjectionRisk(customerTierDescription))
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

        private async void createCustomerTierSubmitButton_Click(object sender, EventArgs e)
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
                bool activeStatus = createCustomerTierActiveStatusCheckbox.Checked;
                string customerTierCode = createCustomerTierCustomerTierCodeTextbox.Text.TrimEnd();
                string customerTierDescription = createCustomerTierCustomerTierDescriptionTextbox.Text.TrimEnd();

                var parameters = new[]
                {
                        new SqlParameter("@activeStatus", activeStatus),
                        new SqlParameter("@customerTierCode", customerTierCode),
                        new SqlParameter("@customerTierDescription", customerTierDescription)
                    };

                ExecuteStoredProcedure executeor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                await executeor.ExecuteNonQueryAsync("[dbo].[spCreateCustomerTier]", parameters);

                MessageBox.Show("New Customer Tier added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add new Customer Tier: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}