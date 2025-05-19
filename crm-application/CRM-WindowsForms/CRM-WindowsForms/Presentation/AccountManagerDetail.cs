using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

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
        private readonly string dataSubject = "Account Manager";

        public AccountManagerDetail(Guid accountManagerId)
        {
            InitializeComponent();
            _accountManagerId = accountManagerId;
            accountManagerDetailAssociatedCustomerDataGridView.CellContentClick += accountManagerDetailAssociatedCustomerDataGridView_CellContentClick;
            accountManagerDetailTabControl.SelectedIndexChanged += AccountManagerDetailTabControl_SelectedIndexChanged;
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

            string storedProcedureName = "[dbo].[spGetAccountManager]";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@accountManagerId",
                    ParameterValue = _accountManagerId
                }
            };

            try
            {
                DataTable? accountManagerDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

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
                MessageBox.Show($"Failed to load Account Manager details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void AccountManagerDetailTabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (accountManagerDetailTabControl.SelectedTab == accountManagerDetailTabControl.TabPages["associatedCustomers"])
            {
                await ViewAccountManagerDetailAssociatedCustomer_Load(sender, e);
            }
        }

        private async Task ViewAccountManagerDetailAssociatedCustomer_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string storedProcedureName = "[dbo].[spGetAssociatedCustomerToAccountManager]";
            string dataSubject = "Associated Customers to Account Manager";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@accountManagerId",
                    ParameterValue = _accountManagerId
                }
            };

            DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No Associated Customers found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataTable.DefaultView.Sort = "Company Tier ASC";
                accountManagerDetailAssociatedCustomerDataGridView.AutoGenerateColumns = true;
                accountManagerDetailAssociatedCustomerDataGridView.DataSource = dataTable;
                accountManagerDetailAssociatedCustomerDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if (accountManagerDetailAssociatedCustomerDataGridView.Columns.Contains("Details"))
                {
                    accountManagerDetailAssociatedCustomerDataGridView.Columns.Remove("Details");
                }
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

        private async void accountManagerDetailUpdateAccountManagerButton_Click(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool activeStatus = accountManagerDetailActiveStatusCheckbox.Checked;
            string firstName = accountManagerDetailFirstNameTextbox.Text.TrimEnd();
            string lastName = accountManagerDetailLastNameTextbox.Text.TrimEnd();
            string emailAddress = accountManagerDetailEmailAddressTextbox.Text.TrimEnd();
            string telephoneNumber = accountManagerDetailTelephoneNumberTextbox.Text.TrimEnd();

            var dataToValidate = new List<ValidateDataInput.DataProperty>
            {
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ActiveStatus",
                    Value = activeStatus,
                    MaxLength = 50,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "FirstName",
                    Value = firstName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "LastName",
                    Value = lastName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "EmailAddress",
                    Value = emailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "TelephoneNumber",
                    Value = telephoneNumber,
                    MaxLength = 13,
                    ValueType = typeof(string)
                }
            };

            dataToValidate = dataToValidate.OrderBy(change => change.Name).ToList();

            var validationResult = ValidateDataInput.ValidateInput(dataToValidate);

            if (!validationResult.IsValid)
            {
                return;
            }
            else
            {
                var changesList = new List<ChangeDetail>
                {
                    new ChangeDetail
                    {
                        VariableName = "Active Status",
                        VariableType = "bool",
                        OriginalValue = accountManagerDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail 
                    { 
                        VariableName = "First Name",
                        VariableType = "string",
                        OriginalValue = accountManagerDetailFirstNameOriginalValue,
                        NewValue = firstName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Last Name",
                        VariableType = "string",
                        OriginalValue = accountManagerDetailLastNameOriginalValue,
                        NewValue = lastName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Email Address",
                        VariableType = "string",
                        OriginalValue = accountManagerDetailEmailAddressOriginalValue,
                        NewValue = emailAddress
                    },
                    new ChangeDetail
                    {
                        VariableName = "Telephone Number",
                        VariableType = "string",
                        OriginalValue = accountManagerDetailTelephoneNumberOriginalValue,
                        NewValue = telephoneNumber
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = UpdateConfirmation.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
                {
                    var parameters = new []
                    {
                        new Parameter 
                        { 
                            ParameterName = "@accountManagerId",
                            ParameterValue = _accountManagerId
                        },
                        new Parameter
                        {
                            ParameterName = "@activeStatus",
                            ParameterValue = activeStatus
                        },
                        new Parameter
                        {
                            ParameterName = "@firstName",
                            ParameterValue = firstName
                        },
                        new Parameter
                        {
                            ParameterName = "@emailAddress",
                            ParameterValue = emailAddress
                        },
                        new Parameter
                        {
                            ParameterName = "@lastName",
                            ParameterValue = lastName
                        },
                        new Parameter
                        {
                            ParameterName = "@telephoneNumber",
                            ParameterValue = telephoneNumber
                        }
                    };

                    string storedProcedureName = "[dbo].[spUpdateAccountManager]";
                    string operationType = "update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Updates were cancelled, no changes have been made to the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
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