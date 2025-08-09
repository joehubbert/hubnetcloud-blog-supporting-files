using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class AccountManagerDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _accountManagerId;
        private bool? accountManagerInformationActiveStatusOriginalValue;
        private string? accountManagerInformationEmailAddressOriginalValue;
        private string? accountManagerInformationFirstNameOriginalValue;
        private string? accountManagerInformationLastNameOriginalValue;      
        private string? accountManagerInformationTelephoneNumberOriginalValue;
        private readonly string dataSubject = "Account Manager";

        public AccountManagerDetail(Guid accountManagerId)
        {
            InitializeComponent();
            _accountManagerId = accountManagerId;
            InitializeCustomComponents();
            LoadDatabaseConnectionSettingsAsync();
        }

        private void InitializeCustomComponents()
        {
            accountManagerDetailTabControlAssociatedCustomersTabPageDataGridView.CellContentClick += AccountManagerDetailAssociatedCustomerDataGridView_CellContentClick;
            accountManagerDetailTabControl.SelectedIndexChanged += new EventHandler(AccountManagerDetailTabControl_SelectedIndexChanged);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void AccountManagerDetailAccountManagerInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
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
                    accountManagerDetailTabControlAccountManagerInformationTabPageFirstNameTextbox.Text = accountManagerDataRow["First Name"].ToString();
                    accountManagerDetailTabControlAccountManagerInformationTabPageLastNameTextbox.Text = accountManagerDataRow["Last Name"].ToString();
                    accountManagerDetailTabControlAccountManagerInformationTabPageEmailAddressTextbox.Text = accountManagerDataRow["Email Address"].ToString();
                    accountManagerDetailTabControlAccountManagerInformationTabPageTelephoneNumberTextbox.Text = accountManagerDataRow["Telephone Number"].ToString();
                    accountManagerDetailTabControlAccountManagerInformationTabPageAccountManagerIdTextbox.Text = accountManagerDataRow["Account Manager Id"].ToString();
                    accountManagerDetailTabControlAccountManagerInformationTabPageCreatedByTextbox.Text = accountManagerDataRow["Created By"].ToString();
                    accountManagerDetailTabControlAccountManagerInformationTabPageCreatedTimestampTextbox.Text = accountManagerDataRow["Created Timestamp UTC"].ToString();
                    accountManagerDetailTabControlAccountManagerInformationTabPageLastUpdatedByTextbox.Text = accountManagerDataRow["Modified By"].ToString();
                    accountManagerDetailTabControlAccountManagerInformationTabPageLastUpdatedTimestampTextbox.Text = accountManagerDataRow["Modified Timestamp UTC"].ToString();
                    accountManagerDetailTabControlAccountManagerInformationTabPageActiveStatusCheckbox.Checked = (bool)accountManagerDataRow["Active Status"];

                    accountManagerInformationFirstNameOriginalValue = accountManagerDataRow["First Name"].ToString();
                    accountManagerInformationLastNameOriginalValue = accountManagerDataRow["Last Name"].ToString();
                    accountManagerInformationEmailAddressOriginalValue = accountManagerDataRow["Email Address"].ToString();
                    accountManagerInformationTelephoneNumberOriginalValue = accountManagerDataRow["Telephone Number"].ToString();
                    accountManagerInformationActiveStatusOriginalValue = (bool)accountManagerDataRow["Active Status"];

                    this.Text += $" - ({accountManagerInformationLastNameOriginalValue}, {accountManagerInformationFirstNameOriginalValue})";
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.NoDataFound", dataSubject);
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async void AccountManagerDetailTabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (accountManagerDetailTabControl.SelectedTab == accountManagerDetailTabControl.TabPages["associatedCustomers"])
            {
                await AccountManagerDetailAssociatedCustomer_Load();
            }
        }

        private async Task AccountManagerDetailAssociatedCustomer_Load()
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            string storedProcedureName = "[dbo].[spGetAssociatedCustomerToAccountManager]";
            string dataSubject = "Associated Customers";

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
                ErrorMessageService errorMessageService = new ErrorMessageService("Information.NoDataFound", dataSubject);
            }
            else
            {
                dataTable.DefaultView.Sort = "Company Tier ASC";
                accountManagerDetailTabControlAssociatedCustomersTabPageDataGridView.AutoGenerateColumns = true;
                accountManagerDetailTabControlAssociatedCustomersTabPageDataGridView.DataSource = dataTable;
                accountManagerDetailTabControlAssociatedCustomersTabPageDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if (accountManagerDetailTabControlAssociatedCustomersTabPageDataGridView.Columns.Contains("Details"))
                {
                    accountManagerDetailTabControlAssociatedCustomersTabPageDataGridView.Columns.Remove("Details");
                }
                DataGridViewLinkColumn customerDetailLink = new DataGridViewLinkColumn
                {
                    HeaderText = "Details",
                    Text = "View Customer Details",
                    UseColumnTextForLinkValue = true,
                    Name = "Details"
                };
                accountManagerDetailTabControlAssociatedCustomersTabPageDataGridView.Columns.Add(customerDetailLink);
            }
        }

        private void AccountManagerDetailAssociatedCustomerDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == accountManagerDetailTabControlAssociatedCustomersTabPageDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (accountManagerDetailTabControlAssociatedCustomersTabPageDataGridView.Columns.Contains("Customer Id"))
                    {
                        Guid customerId = (Guid)accountManagerDetailTabControlAssociatedCustomersTabPageDataGridView.Rows[e.RowIndex].Cells["Customer Id"].Value;
                        CustomerDetail customerDetailForm = new CustomerDetail(customerId);
                        customerDetailForm.Show();
                    }
                    else
                    {
                        ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.IdColumnNotFound", dataSubject);
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
                }
            }
        }

        private async void accountManagerDetailUpdateAccountManagerButton_Click(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            bool activeStatus = accountManagerDetailTabControlAccountManagerInformationTabPageActiveStatusCheckbox.Checked;
            string firstName = accountManagerDetailTabControlAccountManagerInformationTabPageFirstNameTextbox.Text.TrimEnd();
            string lastName = accountManagerDetailTabControlAccountManagerInformationTabPageLastNameTextbox.Text.TrimEnd();
            string emailAddress = accountManagerDetailTabControlAccountManagerInformationTabPageEmailAddressTextbox.Text.TrimEnd();
            string telephoneNumber = accountManagerDetailTabControlAccountManagerInformationTabPageTelephoneNumberTextbox.Text.TrimEnd();

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
                        OriginalValue = accountManagerInformationActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "First Name",
                        VariableType = "string",
                        OriginalValue = accountManagerInformationFirstNameOriginalValue,
                        NewValue = firstName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Last Name",
                        VariableType = "string",
                        OriginalValue = accountManagerInformationLastNameOriginalValue,
                        NewValue = lastName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Email Address",
                        VariableType = "string",
                        OriginalValue = accountManagerInformationEmailAddressOriginalValue,
                        NewValue = emailAddress
                    },
                    new ChangeDetail
                    {
                        VariableName = "Telephone Number",
                        VariableType = "string",
                        OriginalValue = accountManagerInformationTelephoneNumberOriginalValue,
                        NewValue = telephoneNumber
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = UpdateConfirmation.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
                {
                    var parameters = new[]
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
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.UpdateCancelled");
                    this.Close();
                }
            }
        }

        private async void accountManagerDetailTabControlAssociatedCustomersTabPageRefreshDataButton_Click(object sender, EventArgs e)
        {
            await AccountManagerDetailAssociatedCustomer_Load();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            AccountManagerDetailAccountManagerInformation_Load(this, EventArgs.Empty);
        }

        private void accountManagerDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            accountManagerDetailTabControlAccountManagerInformationTabPageFirstNameTextbox.ReadOnly = !accountManagerDetailTabControlAccountManagerInformationTabPageFirstNameTextbox.ReadOnly;
            accountManagerDetailTabControlAccountManagerInformationTabPageLastNameTextbox.ReadOnly = !accountManagerDetailTabControlAccountManagerInformationTabPageLastNameTextbox.ReadOnly;
            accountManagerDetailTabControlAccountManagerInformationTabPageEmailAddressTextbox.ReadOnly = !accountManagerDetailTabControlAccountManagerInformationTabPageEmailAddressTextbox.ReadOnly;
            accountManagerDetailTabControlAccountManagerInformationTabPageTelephoneNumberTextbox.ReadOnly = !accountManagerDetailTabControlAccountManagerInformationTabPageTelephoneNumberTextbox.ReadOnly;
            accountManagerDetailTabControlAccountManagerInformationTabPageActiveStatusCheckbox.Enabled = !accountManagerDetailTabControlAccountManagerInformationTabPageActiveStatusCheckbox.Enabled;
            accountManagerDetailUpdateAccountManagerButton.Enabled = !accountManagerDetailUpdateAccountManagerButton.Enabled;
        }
    }
}