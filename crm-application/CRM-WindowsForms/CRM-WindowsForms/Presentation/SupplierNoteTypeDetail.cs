using CRM_WindowsForms.Model;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace CRM_WindowsForms.Presentation
{
    public partial class SupplierNoteTypeDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _supplierNoteTypeId;
        private string supplierNoteTypeDetailSupplierTypeOriginalValue;
        private bool supplierNoteTypeDetailActiveStatusOriginalValue;

        public SupplierNoteTypeDetail(Guid supplierNoteTypeId)
        {
            InitializeComponent();
            _supplierNoteTypeId = supplierNoteTypeId;
            supplierNoteTypeDetailToggleEditModeButton.Click += supplierNoteTypeDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void ViewSupplierTypeDetailSupplierTypeInformation_Load(object sender, EventArgs e)
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
                    new SqlParameter("@supplierNoteTypeId", _supplierNoteTypeId)
                };

                DataTable supplierNoteTypeDataTable = await executor.ExecuteAsync("[dbo].[spGetSupplierType]", parameters);

                if (supplierNoteTypeDataTable != null)
                {
                    DataRow supplierNoteTypeDataRow = supplierNoteTypeDataTable.Rows[0];
                    supplierNoteTypeDetailSupplierTypeIdTextbox.Text = supplierNoteTypeDataRow["Supplier Note Type ID"].ToString();
                    supplierNoteTypeDetailSupplierTypeTextbox.Text = supplierNoteTypeDataRow["Supplier Note Type"].ToString();
                    supplierNoteTypeDetailCreatedByTextbox.Text = supplierNoteTypeDataRow["Created By"].ToString();
                    supplierNoteTypeDetailCreatedTimestampTextbox.Text = supplierNoteTypeDataRow["Created Timestamp"].ToString();
                    supplierNoteTypeDetailLastUpdatedByTextbox.Text = supplierNoteTypeDataRow["Modified By"].ToString();
                    supplierNoteTypeDetailLastUpdatedTimestampTextbox.Text = supplierNoteTypeDataRow["Modified Timestamp"].ToString();
                    supplierNoteTypeDetailActiveStatusCheckbox.Checked = (bool)supplierNoteTypeDataRow["Active Status"];

                    supplierNoteTypeDetailSupplierTypeOriginalValue = supplierNoteTypeDataRow["Supplier Note Type"].ToString();
                    supplierNoteTypeDetailActiveStatusOriginalValue = (bool)supplierNoteTypeDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Supplier Note Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Supplier Note Type details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            StringBuilder validationErrors = new StringBuilder();

            string supplierNoteType = supplierNoteTypeDetailSupplierTypeTextbox.Text.Trim();

            if (supplierNoteType.Length > 50)
            {
                validationErrors.AppendLine($"Supplier Note Type cannot be longer than 50 characters. Submitted length is {supplierNoteType.Length} characters.");
            }

            if (ContainsSqlInjectionRisk(supplierNoteType))
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

        private async void supplierNoteTypeDetailUpdateSupplierTypeButton_Click(object sender, EventArgs e)
        {
            string supplierNoteType = supplierNoteTypeDetailSupplierTypeTextbox.Text.Trim();

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
                $"Supplier Note Type Original Value: {supplierNoteTypeDetailSupplierTypeOriginalValue}" + $"\nSupplier Note Type New Value: {supplierNoteType}\n" +
                $"Active Status Original Value: {supplierNoteTypeDetailActiveStatusOriginalValue}" + $"\nActive Status New Value: {supplierNoteTypeDetailActiveStatusCheckbox.Checked}\n\n" +
                "This action cannot be undone.", "Update Supplier Note Type Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Code to update the supplier type details
                try
                {
                    ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@activeStatus", supplierNoteTypeDetailActiveStatusCheckbox.Checked),
                        new SqlParameter("@supplierNoteType", supplierNoteType),
                        new SqlParameter("@supplierNoteTypeId", _supplierNoteTypeId)
                    };

                    await executor.ExecuteAsync("[dbo].[spUpdateSupplierType]", parameters);
                    MessageBox.Show("Supplier Note Type details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update Supplier Note Type details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ViewSupplierTypeDetailSupplierTypeInformation_Load(this, EventArgs.Empty);
        }

        private void supplierNoteTypeDetailToggleEditModeButton_Click(object sender, EventArgs e)
        {
            supplierNoteTypeDetailSupplierTypeTextbox.Enabled = !supplierNoteTypeDetailSupplierTypeTextbox.Enabled;
            supplierNoteTypeDetailActiveStatusCheckbox.Enabled = !supplierNoteTypeDetailActiveStatusCheckbox.Enabled;
            supplierNoteTypeDetailUpdateSupplierTypeButton.Enabled = !supplierNoteTypeDetailUpdateSupplierTypeButton.Enabled;
        }
    }
}