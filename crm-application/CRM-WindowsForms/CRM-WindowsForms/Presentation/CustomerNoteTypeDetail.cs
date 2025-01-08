using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Text;

namespace CRM_WindowsForms.Presentation
{
    public partial class CustomerNoteTypeDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _customerNoteTypeId;
        private bool ?customerNoteTypeDetailActiveStatusOriginalValue;
        private string ?customerNoteTypeDetailCustomerNoteTypeOriginalValue;

        public CustomerNoteTypeDetail(Guid customerNoteTypeId)
        {
            InitializeComponent();
            _customerNoteTypeId = customerNoteTypeId;
            customerNoteTypeDetailToggleEditModeButton.Click += customerNoteTypeDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void ViewCustomerNoteTypeDetailCustomerNoteTypeInformation_Load(object sender, EventArgs e)
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
                    new SqlParameter("@customerNoteTypeId", _customerNoteTypeId)
                };

                DataTable customerNoteTypeDataTable = await executor.ExecuteAsync("[dbo].[spGetCustomerNoteType]", parameters);

                if (customerNoteTypeDataTable != null)
                {
                    DataRow customerNoteTypeDataRow = customerNoteTypeDataTable.Rows[0];
                    customerNoteTypeDetailCustomerNoteTypeIdTextbox.Text = customerNoteTypeDataRow["Customer Note Type ID"].ToString();
                    customerNoteTypeDetailCustomerNoteTypeTextbox.Text = customerNoteTypeDataRow["Customer Note Type"].ToString();
                    customerNoteTypeDetailCreatedByTextbox.Text = customerNoteTypeDataRow["Created By"].ToString();
                    customerNoteTypeDetailCreatedTimestampTextbox.Text = customerNoteTypeDataRow["Created Timestamp"].ToString();
                    customerNoteTypeDetailLastUpdatedByTextbox.Text = customerNoteTypeDataRow["Modified By"].ToString();
                    customerNoteTypeDetailLastUpdatedTimestampTextbox.Text = customerNoteTypeDataRow["Modified Timestamp"].ToString();
                    customerNoteTypeDetailActiveStatusCheckbox.Checked = (bool)customerNoteTypeDataRow["Active Status"];

                    customerNoteTypeDetailCustomerNoteTypeOriginalValue = customerNoteTypeDataRow["Customer Note Type"].ToString();
                    customerNoteTypeDetailActiveStatusOriginalValue = (bool)customerNoteTypeDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Customer Note Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Customer Note Type details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            StringBuilder validationErrors = new StringBuilder();

            string customerNoteType = customerNoteTypeDetailCustomerNoteTypeTextbox.Text.TrimEnd();

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

        private async void customerNoteTypeDetailUpdateCustomerNoteTypeButton_Click(object sender, EventArgs e)
        {
            string customerNoteType = customerNoteTypeDetailCustomerNoteTypeTextbox.Text.TrimEnd();

            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateInput())
            {
                return;
            }

            var changes = new StringBuilder("Are you sure that you want to update the following values?\n\n");

            if (customerNoteTypeDetailCustomerNoteTypeOriginalValue != customerNoteType)
            {
                changes.AppendLine($"Customer Note Type Original Value: {customerNoteTypeDetailCustomerNoteTypeOriginalValue}" + $"\nCustomer Note Type New Value: {customerNoteType}\n");
            }

            if (customerNoteTypeDetailActiveStatusOriginalValue != customerNoteTypeDetailActiveStatusCheckbox.Checked)
            {
                changes.AppendLine($"Active Status Original Value: {customerNoteTypeDetailActiveStatusOriginalValue}" + $"\nActive Status New Value: {customerNoteTypeDetailActiveStatusCheckbox.Checked}\n\n");
            }

            changes.AppendLine("This action cannot be undone.");

            var result = MessageBox.Show(changes.ToString(), "Update Customer Note Type Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Code to update the customer type details
                try
                {
                    ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@activeStatus", customerNoteTypeDetailActiveStatusCheckbox.Checked),
                        new SqlParameter("@customerNoteType", customerNoteType),
                        new SqlParameter("@customerNoteTypeId", _customerNoteTypeId)
                    };

                    await executor.ExecuteAsync("[dbo].[spUpdateCustomerNoteType]", parameters);
                    MessageBox.Show("Customer Note Type details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update Customer Note Type details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ViewCustomerNoteTypeDetailCustomerNoteTypeInformation_Load(this, EventArgs.Empty);
        }

        private void customerNoteTypeDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            customerNoteTypeDetailCustomerNoteTypeTextbox.Enabled = !customerNoteTypeDetailCustomerNoteTypeTextbox.Enabled;
            customerNoteTypeDetailActiveStatusCheckbox.Enabled = !customerNoteTypeDetailActiveStatusCheckbox.Enabled;
            customerNoteTypeDetailUpdateCustomerNoteTypeButton.Enabled = !customerNoteTypeDetailUpdateCustomerNoteTypeButton.Enabled;
        }
    }
}