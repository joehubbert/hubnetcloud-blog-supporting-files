using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Text;

namespace CRM_WindowsForms.Presentation
{
    public partial class CustomerTierDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _customerTierId;
        private bool ?customerTierDetailActiveStatusOriginalValue;
        private string ?customerTierDetailCustomerTierCodeOriginalValue;
        private string ?customerTierDetailCustomerTierDescriptionOriginalValue;

        public CustomerTierDetail(Guid customerTierId)
        {
            InitializeComponent();
            _customerTierId = customerTierId;
            customerTierDetailToggleEditModeButton.Click += customerTierDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void ViewCustomerTierDetailCustomerTierInformation_Load(object sender, EventArgs e)
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
                    new SqlParameter("@customerTierId", _customerTierId)
                };

                DataTable customerTierDataTable = await executor.ExecuteAsync("[dbo].[spGetCustomerTier]", parameters);

                if (customerTierDataTable != null)
                {
                    DataRow customerTierDataRow = customerTierDataTable.Rows[0];
                    customerTierDetailCustomerTierIdTextbox.Text = customerTierDataRow["Customer Tier ID"].ToString();
                    customerTierDetailCustomerTierCodeTextbox.Text = customerTierDataRow["Customer Tier Code"].ToString();
                    customerTierDetailCustomerTierDescriptionTextbox.Text = customerTierDataRow["Customer Tier Description"].ToString();
                    customerTierDetailCreatedByTextbox.Text = customerTierDataRow["Created By"].ToString();
                    customerTierDetailCreatedTimestampTextbox.Text = customerTierDataRow["Created Timestamp"].ToString();
                    customerTierDetailLastUpdatedByTextbox.Text = customerTierDataRow["Modified By"].ToString();
                    customerTierDetailLastUpdatedTimestampTextbox.Text = customerTierDataRow["Modified Timestamp"].ToString();
                    customerTierDetailActiveStatusCheckbox.Checked = (bool)customerTierDataRow["Active Status"];

                    customerTierDetailCustomerTierCodeOriginalValue = customerTierDataRow["Customer Tier Code"].ToString();
                    customerTierDetailCustomerTierDescriptionOriginalValue = customerTierDataRow["Customer Tier Description"].ToString();
                    customerTierDetailActiveStatusOriginalValue = (bool)customerTierDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Customer Tier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Customer Tier details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            StringBuilder validationErrors = new StringBuilder();

            string customerTierCode = customerTierDetailCustomerTierCodeTextbox.Text.TrimEnd();
            string customerTierDescription = customerTierDetailCustomerTierDescriptionTextbox.Text.TrimEnd();

            if (customerTierCode.Length > 1)
            {
                validationErrors.AppendLine($"Customer Tier Code cannot be longer than 1 character. Submitted length is {customerTierCode.Length} characters.");
            }

            if (customerTierDescription.Length > 50)
            {
                validationErrors.AppendLine($"Customer Tier Description cannot be longer than 50 characters. Submitted length is {customerTierDescription.Length} characters.");
            }

            if (SQLInjectionRiskCheck.ContainsSqlInjectionRisk(customerTierCode) ||
                SQLInjectionRiskCheck.ContainsSqlInjectionRisk(customerTierDescription))
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

        private async void customerTierDetailUpdateCustomerTierButton_Click(object sender, EventArgs e)
        {
            string customerTierCode = customerTierDetailCustomerTierCodeTextbox.Text.TrimEnd();
            string customerTierDescription = customerTierDetailCustomerTierDescriptionTextbox.Text.TrimEnd();

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

            if (customerTierDetailCustomerTierCodeOriginalValue != customerTierCode)
            {
                changes.AppendLine($"Customer Tier Code Original Value: {customerTierDetailCustomerTierCodeOriginalValue}" + $"\nCustomer Tier Code New Value: {customerTierCode}\n");
            }

            if (customerTierDetailCustomerTierDescriptionOriginalValue != customerTierDescription)
            {
                changes.AppendLine($"Customer Tier Description Original Value: {customerTierDetailCustomerTierDescriptionOriginalValue}" + $"\nCustomer Tier Description New Value: {customerTierDescription}\n");
            }

            if (customerTierDetailActiveStatusOriginalValue != customerTierDetailActiveStatusCheckbox.Checked)
            {
                changes.AppendLine($"Active Status Original Value: {customerTierDetailActiveStatusOriginalValue}" + $"\nActive Status New Value: {customerTierDetailActiveStatusCheckbox.Checked}\n\n");
            }

            changes.AppendLine("This action cannot be undone.");

            var result = MessageBox.Show(changes.ToString(), "Update Customer Tier Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Code to update the customer tier details
                try
                {
                    ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@activeStatus", customerTierDetailActiveStatusCheckbox.Checked),
                        new SqlParameter("@customerTierCode", customerTierCode),
                        new SqlParameter("@customerTierDescription", customerTierDescription),
                        new SqlParameter("@customerTierId", _customerTierId),
                    };

                    await executor.ExecuteAsync("[dbo].[spUpdateCustomerTier]", parameters);
                    MessageBox.Show("Customer Tier details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update Customer Tier details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ViewCustomerTierDetailCustomerTierInformation_Load(this, EventArgs.Empty);
        }

        private void customerTierDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            customerTierDetailCustomerTierCodeTextbox.Enabled = !customerTierDetailCustomerTierCodeTextbox.Enabled;
            customerTierDetailCustomerTierDescriptionTextbox.Enabled = !customerTierDetailCustomerTierDescriptionTextbox.Enabled;
            customerTierDetailActiveStatusCheckbox.Enabled = !customerTierDetailActiveStatusCheckbox.Enabled;
            customerTierDetailUpdateCustomerTierButton.Enabled = !customerTierDetailUpdateCustomerTierButton.Enabled;
        }
    }
}