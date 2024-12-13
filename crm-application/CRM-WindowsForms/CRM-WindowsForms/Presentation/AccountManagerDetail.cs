using CRM_WindowsForms.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRM_WindowsForms.Presentation
{
    public partial class AccountManagerDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _accountManagerId;
        private string accountManagerDetailFirstNameOriginalValue;
        private string accountManagerDetailLastNameOriginalValue;
        private string accountManagerDetailEmailAddressOriginalValue;
        private string accountManagerDetailTelephoneNumberOriginalValue;
        private bool accountManagerDetailActiveStatusOriginalValue;

        public AccountManagerDetail(Guid accountManagerId)
        {
            InitializeComponent();
            _accountManagerId = accountManagerId;
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

                DataTable accountManagerDataTable = await executor.ExecuteAsync("[dbo].[GetAccountManager]", parameters);

                if (accountManagerDataTable != null)
                {
                    DataRow accountManagerDataRow = accountManagerDataTable.Rows[0];
                    accountManagerDetailFirstNameTextbox.Text = accountManagerDataRow["FirstName"].ToString();
                    accountManagerDetailLastNameTextbox.Text = accountManagerDataRow["LastName"].ToString();
                    accountManagerDetailEmailAddressTextbox.Text = accountManagerDataRow["EmailAddress"].ToString();
                    accountManagerDetailTelephoneNumberTextbox.Text = accountManagerDataRow["TelephoneNumber"].ToString();
                    accountManagerDetailAccountManagerIdTextbox.Text = accountManagerDataRow["AccountManagerId"].ToString();
                    accountManagerDetailActiveStatusCheckbox.Checked = (bool)accountManagerDataRow["ActiveStatus"];

                    accountManagerDetailFirstNameOriginalValue = accountManagerDataRow["FirstName"].ToString();
                    accountManagerDetailLastNameOriginalValue = accountManagerDataRow["LastName"].ToString();
                    accountManagerDetailEmailAddressOriginalValue = accountManagerDataRow["EmailAddress"].ToString();
                    accountManagerDetailTelephoneNumberOriginalValue = accountManagerDataRow["TelephoneNumber"].ToString();
                    accountManagerDetailActiveStatusOriginalValue = (bool)accountManagerDataRow["ActiveStatus"];
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
                DataTable dataTable = await executor.ExecuteAsync("[dbo].[GetAssociatedCustomerToAccountManager]", parameters);

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

                    accountManagerDetailAssociatedCustomerDataGridView.CellContentClick += accountManagerDetailAssociatedCustomerDataGridView_CellContentClick;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load account managers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void accountManagerDetailAssociatedCustomerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private async void accountManagerDetailUpdateAccountManagerButton_Click(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show("Are you sure that you want to update the following values?\n\n" +
                $"First Name Original Value: {accountManagerDetailFirstNameOriginalValue}" + $"\nFirst Name New Value: {accountManagerDetailFirstNameTextbox.Text}\n" +
                $"Last Name Original Value: {accountManagerDetailLastNameOriginalValue}" + $"\nLast Name New Value: {accountManagerDetailLastNameTextbox.Text}\n" +
                $"Email Address Original Value: {accountManagerDetailEmailAddressOriginalValue}" + $"\nEmail Address New Value: {accountManagerDetailEmailAddressTextbox.Text}\n" +
                $"Telephone Number Original Value: {accountManagerDetailTelephoneNumberOriginalValue}" + $"\nTelephone Number New Value: {accountManagerDetailTelephoneNumberTextbox.Text}\n" +
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
                        new SqlParameter("@firstName", accountManagerDetailFirstNameTextbox.Text),
                        new SqlParameter("@lastName", accountManagerDetailLastNameTextbox.Text),
                        new SqlParameter("@emailAddress", accountManagerDetailEmailAddressTextbox.Text),
                        new SqlParameter("@telephoneNumber", accountManagerDetailTelephoneNumberTextbox.Text),
                        new SqlParameter("@activeStatus", accountManagerDetailActiveStatusCheckbox.Checked)
                    };

                    await executor.ExecuteAsync("[dbo].[UpdateAccountManager]", parameters);
                    MessageBox.Show("Account manager details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update account manager details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Update details were cancelled, no changes have been made to the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            ViewAccountManagerDetailAccountManagerInformation_Load(this, EventArgs.Empty);
            ViewAccountManagerDetailAssociatedCustomer_Load(this, EventArgs.Empty);
        }


    }
}