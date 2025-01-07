using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using Microsoft.Data.SqlClient;
using System.Text;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreateSupplierNoteType : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreateSupplierNoteType()
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

            string supplierNoteType = createSupplierNoteTypeSupplierNoteTypeTextbox.Text.TrimEnd();

            if (supplierNoteType.Length > 50)
            {
                validationErrors.AppendLine($"Supplier Note Type cannot be longer than 50 characters. Submitted length is {supplierNoteType.Length} characters.");
            }

            if (SQLInjectionRiskCheck.ContainsSqlInjectionRisk(supplierNoteType))
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

        private async void createSupplierNoteTypeSubmitButton_Click(object sender, EventArgs e)
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
                bool activeStatus = createSupplierNoteTypeActiveStatusCheckbox.Checked;
                string supplierNoteType = createSupplierNoteTypeSupplierNoteTypeTextbox.Text.TrimEnd();

                var parameters = new[]
                {
                        new SqlParameter("@activeStatus", activeStatus),
                        new SqlParameter("@supplierNoteType", supplierNoteType)
                    };

                ExecuteStoredProcedure executeor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                await executeor.ExecuteNonQueryAsync("[dbo].[spCreateSupplierNoteType]", parameters);

                MessageBox.Show("New Supplier Note Type added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add new Supplier Note Type: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}