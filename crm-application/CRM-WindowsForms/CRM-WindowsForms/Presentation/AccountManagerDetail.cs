using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace CRM_WindowsForms.Presentation
{
    public partial class AccountManagerDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _accountManagerId;
        private string ?accountManagerDetailFirstNameOriginalValue;
        private string ?accountManagerDetailLastNameOriginalValue;
        private string ?accountManagerDetailEmailAddressOriginalValue;
        private string ?accountManagerDetailTelephoneNumberOriginalValue;
        private bool ?accountManagerDetailActiveStatusOriginalValue;

        public AccountManagerDetail(Guid accountManagerId)
        {
            InitializeComponent();
            _accountManagerId = accountManagerId;
            accountManagerDetailAssociatedCustomerDataGridView.CellContentClick += accountManagerDetailAssociatedCustomerDataGridView_CellContentClick;
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void ViewAccountManagerDetailAccountManagerInformation_Load(object sender, EventArgs e)
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
                    new SqlParameter("@accountManagerId", _accountManagerId)
                };

                DataTable accountManagerDataTable = await executor.ExecuteAsync("[dbo].[spGetAccountManager]", parameters);

                if (accountManagerDataTable != null)
                {
                    DataRow accountManagerDataRow = accountManagerDataTable.Rows[0];
                    accountManagerDetailFirstNameTextbox.Text = accountManagerDataRow["First Name"].ToString();
                    accountManagerDetailLastNameTextbox.Text = accountManagerDataRow["Last Name"].ToString();
                    accountManagerDetailEmailAddressTextbox.Text = accountManagerDataRow["Email Address"].ToString();
                    accountManagerDetailTelephoneNumberTextbox.Text = accountManagerDataRow["Telephone Number"].ToString();
                    accountManagerDetailAccountManagerIdTextbox.Text = accountManagerDataRow["Account Manager Id"].ToString();
                    accountManagerDetailCreatedByTextbox.Text = accountManagerDataRow["Created By"].ToString();
                    accountManagerDetailCreatedTimestampTextbox.Text = accountManagerDataRow["Created Timestamp"].ToString();
                    accountManagerDetailLastUpdatedByTextbox.Text = accountManagerDataRow["Modified By"].ToString();
                    accountManagerDetailLastUpdatedTimestampTextbox.Text = accountManagerDataRow["Modified Timestamp"].ToString();
                    accountManagerDetailActiveStatusCheckbox.Checked = (bool)accountManagerDataRow["Active Status"];

                    accountManagerDetailFirstNameOriginalValue = accountManagerDataRow["First Name"].ToString();
                    accountManagerDetailLastNameOriginalValue = accountManagerDataRow["Last Name"].ToString();
                    accountManagerDetailEmailAddressOriginalValue = accountManagerDataRow["Email Address"].ToString();
                    accountManagerDetailTelephoneNumberOriginalValue = accountManagerDataRow["Telephone Number"].ToString();
                    accountManagerDetailActiveStatusOriginalValue = (bool)accountManagerDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Account Manager.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load account manager details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void ViewAccountManagerDetailAssociatedCustomer_Load(object sender, EventArgs e)
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
                    new SqlParameter("@accountManagerId", _accountManagerId)
                };
                DataTable dataTable = await executor.ExecuteAsync("[dbo].[spGetAssociatedCustomerToAccountManager]", parameters);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No associated customers found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    accountManagerDetailAssociatedCustomerDataGridView.AutoGenerateColumns = true;
                    accountManagerDetailAssociatedCustomerDataGridView.DataSource = dataTable;
                    accountManagerDetailAssociatedCustomerDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    DataGridViewLinkColumn customerDetailLink = new DataGridViewLinkColumn
                    {
                        HeaderText = "Details",
                        Text = "View Customer Details",
                        UseColumnTextForLinkValue = true,
                        Name = "Details"
                    };
                    accountManagerDetailAssociatedCustomerDataGridView.Columns.Add(customerDetailLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load account managers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void accountManagerDetailAssociatedCustomerDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == accountManagerDetailAssociatedCustomerDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (accountManagerDetailAssociatedCustomerDataGridView.Columns.Contains("Customer Id"))
                    {
                        Guid customerId = (Guid)accountManagerDetailAssociatedCustomerDataGridView.Rows[e.RowIndex].Cells["Customer Id"].Value;
                        CustomerDetail customerDetailForm = new CustomerDetail(customerId);
                        customerDetailForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Account Manager Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open account manager details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateInput()
        {
            StringBuilder validationErrors = new StringBuilder();

            string firstName = accountManagerDetailFirstNameTextbox.Text.TrimEnd();
            string lastName = accountManagerDetailLastNameTextbox.Text.TrimEnd();
            string emailAddress = accountManagerDetailEmailAddressTextbox.Text.TrimEnd();
            string telephoneNumber = accountManagerDetailTelephoneNumberTextbox.Text.TrimEnd();

            if (firstName.Length > 50)
            {
                validationErrors.AppendLine($"First Name cannot be longer than 50 characters. Submitted length is {firstName.Length} characters.");
            }

            if (lastName.Length > 50)
            {
                validationErrors.AppendLine($"Last Name cannot be longer than 50 characters. Submitted length is {lastName.Length} characters.");
            }

            if (emailAddress.Length > 50)
            {
                validationErrors.AppendLine($"Email Address cannot be longer than 50 characters. Submitted length is {emailAddress.Length} characters.");
            }
            else if (!emailAddress.Contains("@"))
            {
                validationErrors.AppendLine("Email Address must contain an '@' symbol.");
            }

            if (telephoneNumber.Length > 13)
            {
                validationErrors.AppendLine($"Telephone Number cannot be longer than 13 characters. Submitted length is {telephoneNumber.Length} characters.");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(telephoneNumber, @"^\+\d{12}$"))
            {
                validationErrors.AppendLine("Telephone Number must start with a '+' prefix followed by exactly 12 digits.");
            }

            if (SQLInjectionRiskCheck.ContainsSqlInjectionRisk(firstName) ||
                SQLInjectionRiskCheck.ContainsSqlInjectionRisk(lastName) ||
                SQLInjectionRiskCheck.ContainsSqlInjectionRisk(emailAddress) ||
                SQLInjectionRiskCheck.ContainsSqlInjectionRisk(telephoneNumber))
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

        private async void accountManagerDetailUpdateAccountManagerButton_Click(object sender, EventArgs e)
        {
            string firstName = accountManagerDetailFirstNameTextbox.Text.TrimEnd();
            string lastName = accountManagerDetailLastNameTextbox.Text.TrimEnd();
            string emailAddress = accountManagerDetailEmailAddressTextbox.Text.TrimEnd();
            string telephoneNumber = accountManagerDetailTelephoneNumberTextbox.Text.TrimEnd();

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
                $"First Name Original Value: {accountManagerDetailFirstNameOriginalValue}" + $"\nFirst Name New Value: {firstName}\n" +
                $"Last Name Original Value: {accountManagerDetailLastNameOriginalValue}" + $"\nLast Name New Value: {lastName}\n" +
                $"Email Address Original Value: {accountManagerDetailEmailAddressOriginalValue}" + $"\nEmail Address New Value: {emailAddress}\n" +
                $"Telephone Number Original Value: {accountManagerDetailTelephoneNumberOriginalValue}" + $"\nTelephone Number New Value: {telephoneNumber}\n" +
                $"Active Status Original Value: {accountManagerDetailActiveStatusOriginalValue}" + $"\nActive Status New Value: {accountManagerDetailActiveStatusCheckbox.Checked}\n\n" +
                "This action cannot be undone.", "Update Account Manager Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Code to update the account manager details
                try
                {
                    ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@accountManagerId", _accountManagerId),
                        new SqlParameter("@activeStatus", accountManagerDetailActiveStatusCheckbox.Checked),
                        new SqlParameter("@firstName", firstName),
                        new SqlParameter("@emailAddress", emailAddress),
                        new SqlParameter("@telephoneNumber", telephoneNumber),
                        new SqlParameter("@lastName", lastName)
                    };

                    await executor.ExecuteAsync("[dbo].[spUpdateAccountManager]", parameters);
                    MessageBox.Show("Account Manager details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update Account Manager details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ViewAccountManagerDetailAccountManagerInformation_Load(this, EventArgs.Empty);
            ViewAccountManagerDetailAssociatedCustomer_Load(this, EventArgs.Empty);
        }

        private void accountManagerDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            accountManagerDetailFirstNameTextbox.Enabled = !accountManagerDetailFirstNameTextbox.Enabled;
            accountManagerDetailLastNameTextbox.Enabled = !accountManagerDetailLastNameTextbox.Enabled;
            accountManagerDetailEmailAddressTextbox.Enabled = !accountManagerDetailEmailAddressTextbox.Enabled;
            accountManagerDetailTelephoneNumberTextbox.Enabled = !accountManagerDetailTelephoneNumberTextbox.Enabled;
            accountManagerDetailActiveStatusCheckbox.Enabled = !accountManagerDetailActiveStatusCheckbox.Enabled;
            accountManagerDetailUpdateAccountManagerButton.Enabled = !accountManagerDetailUpdateAccountManagerButton.Enabled;
        }
    }
}