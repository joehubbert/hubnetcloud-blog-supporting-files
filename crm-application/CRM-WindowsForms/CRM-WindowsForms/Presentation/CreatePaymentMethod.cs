using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using Microsoft.Data.SqlClient;
using System.Text;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreatePaymentMethod : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreatePaymentMethod()
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

            string paymentMethod = createPaymentMethodPaymentMethodTextbox.Text.TrimEnd();

            if (paymentMethod.Length > 50)
            {
                validationErrors.AppendLine($"Payment Method cannot be longer than 50 characters. Submitted length is {paymentMethod.Length} characters.");
            }

            if (SQLInjectionRiskCheck.ContainsSqlInjectionRisk(paymentMethod))
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

        private async void createPaymentMethodSubmitButton_Click(object sender, EventArgs e)
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
                bool activeStatus = createPaymentMethodActiveStatusCheckbox.Checked;
                string paymentMethod = createPaymentMethodPaymentMethodTextbox.Text.TrimEnd();

                var parameters = new[]
                {
                        new SqlParameter("@activeStatus", activeStatus),
                        new SqlParameter("@paymentMethod", paymentMethod)
                    };

                ExecuteStoredProcedure executeor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                await executeor.ExecuteNonQueryAsync("[dbo].[spCreatePaymentMethod]", parameters);

                MessageBox.Show("New Payment Method added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add new Payment Method: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}