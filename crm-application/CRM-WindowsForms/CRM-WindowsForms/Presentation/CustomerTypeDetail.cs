using CRM_WindowsForms.Model;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace CRM_WindowsForms.Presentation
{
    public partial class CustomerTypeDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _customerTypeId;
        private bool customerTypeDetailActiveStatusOriginalValue;
        private string customerTypeDetailCustomerTypeOriginalValue;

        public CustomerTypeDetail(Guid customerTypeId)
        {
            InitializeComponent();
            _customerTypeId = customerTypeId;
            customerTypeDetailToggleEditModeButton.Click += customerTypeDetailToggleEditModeButton_Click;
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
                    new SqlParameter("@customerTypeId", _customerTypeId)
                };

                DataTable customerTypeDataTable = await executor.ExecuteAsync("[dbo].[spGetCustomerType]", parameters);

                if (customerTypeDataTable != null)
                {
                    DataRow customerTypeDataRow = customerTypeDataTable.Rows[0];
                    customerTypeDetailCustomerTypeIdTextbox.Text = customerTypeDataRow["Customer Type ID"].ToString();
                    customerTypeDetailCustomerTypeTextbox.Text = customerTypeDataRow["Customer Type"].ToString();
                    customerTypeDetailCreatedByTextbox.Text = customerTypeDataRow["Created By"].ToString();
                    customerTypeDetailCreatedTimestampTextbox.Text = customerTypeDataRow["Created Timestamp"].ToString();
                    customerTypeDetailLastUpdatedByTextbox.Text = customerTypeDataRow["Modified By"].ToString();
                    customerTypeDetailLastUpdatedTimestampTextbox.Text = customerTypeDataRow["Modified Timestamp"].ToString();
                    customerTypeDetailActiveStatusCheckbox.Checked = (bool)customerTypeDataRow["Active Status"];

                    customerTypeDetailCustomerTypeOriginalValue = customerTypeDataRow["Customer Type"].ToString();
                    customerTypeDetailActiveStatusOriginalValue = (bool)customerTypeDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Customer Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Customer Type details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            StringBuilder validationErrors = new StringBuilder();

            string customerType = customerTypeDetailCustomerTypeTextbox.Text.Trim();

            if (customerType.Length > 50)
            {
                validationErrors.AppendLine($"Customer Type cannot be longer than 50 characters. Submitted length is {customerType.Length} characters.");
            }

            if (ContainsSqlInjectionRisk(customerType))
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

        private async void customerTypeDetailUpdateCustomerTypeButton_Click(object sender, EventArgs e)
        {
            string customerType = customerTypeDetailCustomerTypeTextbox.Text.Trim();

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
                $"Customer Type Original Value: {customerTypeDetailCustomerTypeOriginalValue}" + $"\nCustomer Type New Value: {customerType}\n" +
                $"Active Status Original Value: {customerTypeDetailActiveStatusOriginalValue}" + $"\nActive Status New Value: {customerTypeDetailActiveStatusCheckbox.Checked}\n\n" +
                "This action cannot be undone.", "Update Customer Type Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Code to update the customer type details
                try
                {
                    ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@activeStatus", customerTypeDetailActiveStatusCheckbox.Checked),
                        new SqlParameter("@customerType", customerType),
                        new SqlParameter("@customerTypeId", _customerTypeId)
                    };

                    await executor.ExecuteAsync("[dbo].[spUpdateCustomerType]", parameters);
                    MessageBox.Show("Customer Type details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update Customer Type details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void customerTypeDetailToggleEditModeButton_Click(object sender, EventArgs e)
        {
            customerTypeDetailCustomerTypeTextbox.Enabled = !customerTypeDetailCustomerTypeTextbox.Enabled;
            customerTypeDetailActiveStatusCheckbox.Enabled = !customerTypeDetailActiveStatusCheckbox.Enabled;
            customerTypeDetailUpdateCustomerTypeButton.Enabled = !customerTypeDetailUpdateCustomerTypeButton.Enabled;
        }
    }
}