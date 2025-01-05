using CRM_WindowsForms.Model;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace CRM_WindowsForms.Presentation
{
    public partial class CustomerNoteTypeDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _customerNoteTypeId;
        private bool ?customerNoteTypeDetailActiveStatusOriginalValue;
        private string ?customerNoteTypeDetailCustomerTypeOriginalValue;

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

        private async void ViewCustomerTypeDetailCustomerTypeInformation_Load(object sender, EventArgs e)
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
                    customerNoteTypeDetailCustomerTypeIdTextbox.Text = customerNoteTypeDataRow["Customer Note Type ID"].ToString();
                    customerNoteTypeDetailCustomerTypeTextbox.Text = customerNoteTypeDataRow["Customer Note Type"].ToString();
                    customerNoteTypeDetailCreatedByTextbox.Text = customerNoteTypeDataRow["Created By"].ToString();
                    customerNoteTypeDetailCreatedTimestampTextbox.Text = customerNoteTypeDataRow["Created Timestamp"].ToString();
                    customerNoteTypeDetailLastUpdatedByTextbox.Text = customerNoteTypeDataRow["Modified By"].ToString();
                    customerNoteTypeDetailLastUpdatedTimestampTextbox.Text = customerNoteTypeDataRow["Modified Timestamp"].ToString();
                    customerNoteTypeDetailActiveStatusCheckbox.Checked = (bool)customerNoteTypeDataRow["Active Status"];

                    customerNoteTypeDetailCustomerTypeOriginalValue = customerNoteTypeDataRow["Customer Note Type"].ToString();
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

            string customerNoteType = customerNoteTypeDetailCustomerTypeTextbox.Text.Trim();

            if (customerNoteType.Length > 50)
            {
                validationErrors.AppendLine($"Customer Note Type cannot be longer than 50 characters. Submitted length is {customerNoteType.Length} characters.");
            }

            if (ContainsSqlInjectionRisk(customerNoteType))
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

        private async void customerNoteTypeDetailUpdateCustomerTypeButton_Click(object sender, EventArgs e)
        {
            string customerNoteType = customerNoteTypeDetailCustomerTypeTextbox.Text.Trim();

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
                $"Customer Note Type Original Value: {customerNoteTypeDetailCustomerTypeOriginalValue}" + $"\nCustomer Note Type New Value: {customerNoteType}\n" +
                $"Active Status Original Value: {customerNoteTypeDetailActiveStatusOriginalValue}" + $"\nActive Status New Value: {customerNoteTypeDetailActiveStatusCheckbox.Checked}\n\n" +
                "This action cannot be undone.", "Update Customer Note Type Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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

                    await executor.ExecuteAsync("[dbo].[spUpdateCustomerType]", parameters);
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
            ViewCustomerTypeDetailCustomerTypeInformation_Load(this, EventArgs.Empty);
        }

        private void customerNoteTypeDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            customerNoteTypeDetailCustomerTypeTextbox.Enabled = !customerNoteTypeDetailCustomerTypeTextbox.Enabled;
            customerNoteTypeDetailActiveStatusCheckbox.Enabled = !customerNoteTypeDetailActiveStatusCheckbox.Enabled;
            customerNoteTypeDetailUpdateCustomerTypeButton.Enabled = !customerNoteTypeDetailUpdateCustomerTypeButton.Enabled;
        }
    }
}