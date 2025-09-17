using CRM_WindowsForms_EnterpriseEdition.Helpers;
using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Services;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class AccountManagerDetail : Form
    {
        private readonly Guid _accountManagerId;
        private bool _associatedCustomersLoaded = false;
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private List<DataGridViewQuickSearchHelper> _dataGridViewQuickSearchHelpers;
        private DatabaseConnectionSettings? _databaseConnectionSettings; 
        private bool? accountManagerInformationActiveStatusOriginalValue;
        private Guid? accountManagerInformationCompanyConfigurationIdOriginalValue;
        private string? accountManagerInformationEmailAddressOriginalValue;
        private string? accountManagerInformationFirstNameOriginalValue;
        private string? accountManagerInformationLastNameOriginalValue;      
        private string? accountManagerInformationTelephoneNumberOriginalValue;
        private readonly string dataSubject = "Account Manager";

        public AccountManagerDetail(Guid accountManagerId)
        {
            InitializeComponent();
            _dataGridViewQuickSearchHelpers = new List<DataGridViewQuickSearchHelper>();
            InitializeEventHandlers();
            _accountManagerId = accountManagerId;
            LoadDatabaseConnectionSettingsAsync();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            AccountManagerDetailAccountManagerInformation_Load(this, EventArgs.Empty);
        }

        private void InitializeEventHandlers()
        {
            accountManagerDetailTabControlAccountManagerInformationTabPageCompanyConfigurationComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            accountManagerDetailTabControlAssociatedCustomersTabPageDataGridView.CellContentClick += accountManagerDetailTabControlAssociatedCustomersTabPageDataGridView_CellContentClick;
            _dataGridViewQuickSearchHelpers.Add(new DataGridViewQuickSearchHelper(accountManagerDetailTabControlAssociatedCustomersTabPageQuickFilterTextBox, accountManagerDetailTabControlAssociatedCustomersTabPageDataGridView));
        }

        private async Task AccountManagerDetailAssociatedCustomer_Load(object sender, EventArgs e)
        {
            await DataAccessDataGridViewHelper.LoadDataGridViewAsync(
                _databaseConnectionSettings,
                _accountManagerId,
                "accountManagerId",
                "spGetAssociatedCustomerToAccountManager",
                "Associated Customers to Account Manager",
                accountManagerDetailTabControlAssociatedCustomersTabPageDataGridView,
                "Customer Id",
                "View Customer",
                "ASC",
                "Company Tier"
            );
        }

        private async void AccountManagerDetailAccountManagerInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            string storedProcedureName = "spGetAccountManager";

            var parameters = new[]
            {
                new StoredProcedureParameter
                {
                    ParameterName = "accountManagerId",
                    ParameterValue = _accountManagerId
                }
            };

            try
            {
                DataTable? accountManagerDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject);

                if (accountManagerDataTable != null)
                {
                    DataRow accountManagerDataRow = accountManagerDataTable.Rows[0];
                    accountManagerDetailTabControlAccountManagerInformationTabPageFirstNameTextBox.Text = accountManagerDataRow["First Name"].ToString();
                    accountManagerDetailTabControlAccountManagerInformationTabPageLastNameTextBox.Text = accountManagerDataRow["Last Name"].ToString();
                    accountManagerDetailTabControlAccountManagerInformationTabPageEmailAddressTextBox.Text = accountManagerDataRow["Email Address"].ToString();
                    accountManagerDetailTabControlAccountManagerInformationTabPageTelephoneNumberTextBox.Text = accountManagerDataRow["Telephone Number"].ToString();
                    accountManagerDetailTabControlAccountManagerInformationTabPageAccountManagerIdTextBox.Text = accountManagerDataRow["Account Manager Id"].ToString();
                    Guid companyConfigurationId = (Guid)accountManagerDataRow["Company Configuration Id"];
                    await LoadCompanyConfigurationAsync(companyConfigurationId);
                    accountManagerDetailTabControlAccountManagerInformationTabPageCreatedByTextBox.Text = accountManagerDataRow["Created By"].ToString();
                    accountManagerDetailTabControlAccountManagerInformationTabPageCreatedTimestampTextBox.Text = accountManagerDataRow["Created Timestamp UTC"].ToString();
                    accountManagerDetailTabControlAccountManagerInformationTabPageLastUpdatedByTextBox.Text = accountManagerDataRow["Modified By"].ToString();
                    accountManagerDetailTabControlAccountManagerInformationTabPageLastUpdatedTimestampTextBox.Text = accountManagerDataRow["Modified Timestamp UTC"].ToString();
                    accountManagerDetailTabControlAccountManagerInformationTabPageActiveStatusCheckBox.Checked = (bool)accountManagerDataRow["Active Status"];

                    accountManagerInformationFirstNameOriginalValue = accountManagerDataRow["First Name"].ToString();
                    accountManagerInformationLastNameOriginalValue = accountManagerDataRow["Last Name"].ToString();
                    accountManagerInformationEmailAddressOriginalValue = accountManagerDataRow["Email Address"].ToString();
                    accountManagerInformationTelephoneNumberOriginalValue = accountManagerDataRow["Telephone Number"].ToString();
                    accountManagerInformationActiveStatusOriginalValue = (bool)accountManagerDataRow["Active Status"];
                    accountManagerInformationCompanyConfigurationIdOriginalValue = (Guid)accountManagerDataRow["Company Configuration Id"];

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

        private async Task LoadCompanyConfigurationAsync(Guid companyConfigurationId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(accountManagerDetailTabControlAccountManagerInformationTabPageCompanyConfigurationComboBox, "spGetAllCompanyConfiguration", null, true, "Company Configuration Id", companyConfigurationId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void accountManagerDetailTabControlAssociatedCustomersTabPage_Enter(object? sender, EventArgs e)
        {
            if (!_associatedCustomersLoaded)
            {
                await AccountManagerDetailAssociatedCustomer_Load(this, EventArgs.Empty);
                _associatedCustomersLoaded = true;
            }
        }

        private void accountManagerDetailTabControlAssociatedCustomersTabPageDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            DataAccessDataGridViewHelper.HandleDetailsCellClick(
            accountManagerDetailTabControlAssociatedCustomersTabPageDataGridView,
            e,
            "Customer Id",
            "Customer",
            id => {
                var customerDetail = new CustomerDetail(id);
                customerDetail.Show();
            });
        }

        private async void accountManagerDetailTabControlAssociatedCustomersTabPageRefreshDataButton_Click(object sender, EventArgs e)
        {
            await AccountManagerDetailAssociatedCustomer_Load(this, EventArgs.Empty);
        }

        private void accountManagerDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            accountManagerDetailTabControlAccountManagerInformationTabPageFirstNameTextBox.ReadOnly = !accountManagerDetailTabControlAccountManagerInformationTabPageFirstNameTextBox.ReadOnly;
            accountManagerDetailTabControlAccountManagerInformationTabPageLastNameTextBox.ReadOnly = !accountManagerDetailTabControlAccountManagerInformationTabPageLastNameTextBox.ReadOnly;
            accountManagerDetailTabControlAccountManagerInformationTabPageEmailAddressTextBox.ReadOnly = !accountManagerDetailTabControlAccountManagerInformationTabPageEmailAddressTextBox.ReadOnly;
            accountManagerDetailTabControlAccountManagerInformationTabPageTelephoneNumberTextBox.ReadOnly = !accountManagerDetailTabControlAccountManagerInformationTabPageTelephoneNumberTextBox.ReadOnly;
            accountManagerDetailTabControlAccountManagerInformationTabPageActiveStatusCheckBox.Enabled = !accountManagerDetailTabControlAccountManagerInformationTabPageActiveStatusCheckBox.Enabled;
            accountManagerDetailTabControlAccountManagerInformationTabPageCompanyConfigurationComboBox.Enabled = !accountManagerDetailTabControlAccountManagerInformationTabPageCompanyConfigurationComboBox.Enabled;
            accountManagerDetailUpdateAccountManagerButton.Enabled = !accountManagerDetailUpdateAccountManagerButton.Enabled;
        }

        private async void accountManagerDetailUpdateAccountManagerButton_Click(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            bool activeStatus = accountManagerDetailTabControlAccountManagerInformationTabPageActiveStatusCheckBox.Checked;
            Guid companyConfigurationId = Guid.Parse(accountManagerDetailTabControlAccountManagerInformationTabPageCompanyConfigurationComboBox.SelectedValue.ToString());
            string firstName = accountManagerDetailTabControlAccountManagerInformationTabPageFirstNameTextBox.Text.TrimEnd();
            string lastName = accountManagerDetailTabControlAccountManagerInformationTabPageLastNameTextBox.Text.TrimEnd();
            string emailAddress = accountManagerDetailTabControlAccountManagerInformationTabPageEmailAddressTextBox.Text.TrimEnd();
            string telephoneNumber = accountManagerDetailTabControlAccountManagerInformationTabPageTelephoneNumberTextBox.Text.TrimEnd();

            var dataToValidate = new List<ValidateDataInputService.DataProperty>
            {
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Active Status",
                    Value = activeStatus,
                    MaxLength = 50,
                    ValueType = typeof(bool)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Company Configuration Id",
                    Value = companyConfigurationId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "First Name",
                    Value = firstName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Last Name",
                    Value = lastName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Email Address",
                    Value = emailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Telephone Number",
                    Value = telephoneNumber,
                    MaxLength = 13,
                    ValueType = typeof(string)
                }
            };

            dataToValidate = dataToValidate.OrderBy(change => change.Name).ToList();

            var validationResult = ValidateDataInputService.ValidateInput(dataToValidate);

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
                        VariableName = "Company Configuration Id",
                        VariableType = "Guid",
                        OriginalValue = accountManagerInformationCompanyConfigurationIdOriginalValue,
                        NewValue = companyConfigurationId
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

                bool confirmed = UpdateConfirmationService.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
                {
                    var parameters = new[]
                    {
                        new StoredProcedureParameter
                        {
                            ParameterName = "accountManagerId",
                            ParameterValue = _accountManagerId
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "activeStatus",
                            ParameterValue = activeStatus
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "companyConfigurationId",
                            ParameterValue = companyConfigurationId
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "firstName",
                            ParameterValue = firstName
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "emailAddress",
                            ParameterValue = emailAddress
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "lastName",
                            ParameterValue = lastName
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "telephoneNumber",
                            ParameterValue = telephoneNumber
                        }
                    };

                    string storedProcedureName = "spUpdateAccountManager";
                    string operationType = "update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, operationType);
                    this.Close();
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.UpdateCancelled");
                    this.Close();
                }
            }
        }






    }
}