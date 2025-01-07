using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using Microsoft.Data.SqlClient;
using System.Text;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreateCustomerNoteType : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreateCustomerNoteType()
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

            string customerNoteType = createCustomerNoteTypeCustomerNoteTypeTextbox.Text.TrimEnd();

            if (customerNoteType.Length > 50)
            {
                validationErrors.AppendLine($"Customer Note Type cannot be longer than 50 characters. Submitted length is {customerNoteType.Length} characters.");
            }

            if (SQLInjectionRiskCheck.ContainsSqlInjectionRisk(customerNoteType))
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

        private async void createCustomerNoteTypeSubmitButton_Click(object sender, EventArgs e)
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
                bool activeStatus = createCustomerNoteTypeActiveStatusCheckbox.Checked;
                string customerNoteType = createCustomerNoteTypeCustomerNoteTypeTextbox.Text.TrimEnd();

                var parameters = new[]
                {
                        new SqlParameter("@activeStatus", activeStatus),
                        new SqlParameter("@customerNoteType", customerNoteType)
                    };

                ExecuteStoredProcedure executeor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                await executeor.ExecuteNonQueryAsync("[dbo].[spCreateCustomerNoteType]", parameters);

                MessageBox.Show("New Customer Note Type added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add new Customer Note Type: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}