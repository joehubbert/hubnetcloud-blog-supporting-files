using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using Microsoft.Data.SqlClient;
using System.Text;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreateProductNoteType : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreateProductNoteType()
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

            string productNoteType = createProductNoteTypeProductNoteTypeTextbox.Text.TrimEnd();

            if (productNoteType.Length > 50)
            {
                validationErrors.AppendLine($"Product Note Type cannot be longer than 50 characters. Submitted length is {productNoteType.Length} characters.");
            }

            if (SQLInjectionRiskCheck.ContainsSqlInjectionRisk(productNoteType))
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

        private async void createProductNoteTypeSubmitButton_Click(object sender, EventArgs e)
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
                bool activeStatus = createProductNoteTypeActiveStatusCheckbox.Checked;
                string productNoteType = createProductNoteTypeProductNoteTypeTextbox.Text.TrimEnd();

                var parameters = new[]
                {
                        new SqlParameter("@activeStatus", activeStatus),
                        new SqlParameter("@productNoteType", productNoteType)
                    };

                ExecuteStoredProcedure executeor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                await executeor.ExecuteNonQueryAsync("[dbo].[spCreateProductNoteType]", parameters);

                MessageBox.Show("New Product Note Type added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add new Product Note Type: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}