using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using Microsoft.Data.SqlClient;
using System.Text;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreateCurrency : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreateCurrency()
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

            string currencyCode = createCurrencyCurrencyCodeTextbox.Text.TrimEnd();
            string currencyName = createCurrencyCurrencyNameTextbox.Text.TrimEnd();

            if (currencyCode.Length > 3)
            {
                validationErrors.AppendLine($"Currency Code cannot be longer than 3 characters. Submitted length is {currencyCode.Length} characters.");
            }

            if (currencyName.Length > 50)
            {
                validationErrors.AppendLine($"Currency Name cannot be longer than 50 characters. Submitted length is {currencyName.Length} characters.");
            }

            if (SQLInjectionRiskCheck.ContainsSqlInjectionRisk(currencyCode) ||
                SQLInjectionRiskCheck.ContainsSqlInjectionRisk(currencyName))
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

        private async void createCurrencySubmitButton_Click(object sender, EventArgs e)
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
                bool activeStatus = createCurrencyActiveStatusCheckbox.Checked;
                string currencyCode = createCurrencyCurrencyCodeTextbox.Text.TrimEnd();
                string currencyName = createCurrencyCurrencyNameTextbox.Text.TrimEnd();

                var parameters = new[]
                {
                        new SqlParameter("@activeStatus", activeStatus),
                        new SqlParameter("@currencyCode", currencyCode),
                        new SqlParameter("@currencyName", currencyName)
                    };

                ExecuteStoredProcedure executeor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                await executeor.ExecuteNonQueryAsync("[dbo].[spCreateCurrency]", parameters);

                MessageBox.Show("New Currency added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add new Currency: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}