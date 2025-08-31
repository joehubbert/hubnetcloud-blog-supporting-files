using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CustomerTierDetail : Form
    {
        private readonly Guid _customerTierId;
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private bool customerTierDetailActiveStatusOriginalValue;
        private Guid customerTierDetailCompanyConfigurationIdOriginalValue;
        private string customerTierDetailCustomerTierCodeOriginalValue;
        private string customerTierDetailCustomerTierDescriptionOriginalValue;
        private readonly string dataSubject = "Customer Tier";

        public CustomerTierDetail(Guid customerTierId)
        {
            InitializeComponent();
            InitializeEventHandlers();
            _customerTierId = customerTierId;
            LoadDatabaseConnectionSettingsAsync();
        }

        private void InitializeEventHandlers()
        {
            customerTierDetailToggleEditModeButton.Click += customerTierDetailToggleEditModeButton_Click;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task LoadCompanyConfigurationAsync(Guid companyConfigurationId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerTierDetailCompanyConfigurationComboBox, "spGetAllCompanyConfiguration", null, true, "Company Configuration Id", companyConfigurationId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async void CustomerTierDetailCustomerTierInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            string storedProcedureName = "spGetCustomerTier";

            var parameters = new[]
            {
                new StoredProcedureParameter
                {
                    ParameterName = "customerTierId",
                    ParameterValue = _customerTierId
                }
            };

            try
            {
                DataTable? customerTierDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject);

                if (customerTierDataTable != null)
                {
                    DataRow customerTierDataRow = customerTierDataTable.Rows[0];
                    customerTierDetailCustomerTierIdTextBox.Text = customerTierDataRow["Customer Tier Id"].ToString();
                    customerTierDetailCustomerTierCodeTextBox.Text = customerTierDataRow["Customer Tier Code"].ToString();
                    customerTierDetailCustomerTierDescriptionTextBox.Text = customerTierDataRow["Customer Tier Description"].ToString();
                    customerTierDetailCreatedByTextBox.Text = customerTierDataRow["Created By"].ToString();
                    customerTierDetailCreatedTimestampTextBox.Text = customerTierDataRow["Created Timestamp UTC"].ToString();
                    customerTierDetailLastUpdatedByTextBox.Text = customerTierDataRow["Modified By"].ToString();
                    customerTierDetailLastUpdatedTimestampTextBox.Text = customerTierDataRow["Modified Timestamp UTC"].ToString();
                    customerTierDetailActiveStatusCheckBox.Checked = (bool)customerTierDataRow["Active Status"];
                    Guid companyConfigurationId = (Guid)customerTierDataRow["Company Configuration Id"];
                    await LoadCompanyConfigurationAsync(companyConfigurationId);

                    customerTierDetailCompanyConfigurationIdOriginalValue = (Guid)customerTierDataRow["Company Configuration Id"];
                    customerTierDetailCustomerTierCodeOriginalValue = customerTierDataRow["Customer Tier Code"].ToString();
                    customerTierDetailCustomerTierDescriptionOriginalValue = customerTierDataRow["Customer Tier Description"].ToString();
                    customerTierDetailActiveStatusOriginalValue = (bool)customerTierDataRow["Active Status"];

                    this.Text += $" ({customerTierDetailCustomerTierDescriptionOriginalValue})";
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

        private async void customerTierDetailUpdateCustomerTierButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = customerTierDetailActiveStatusCheckBox.Checked;
            Guid companyConfigurationId = Guid.Parse(customerTierDetailCompanyConfigurationComboBox.SelectedValue.ToString());
            string customerTierCode = customerTierDetailCustomerTierCodeTextBox.Text.TrimEnd();
            string customerTierDescription = customerTierDetailCustomerTierDescriptionTextBox.Text.TrimEnd();

            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            var dataToValidate = new List<ValidateDataInputService.DataProperty>
            {
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Active Status",
                    Value = activeStatus,
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
                    Name = "Customer Tier Code",
                    Value = customerTierCode,
                    MaxLength = 1,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Tier Description",
                    Value = customerTierDescription,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
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
                        OriginalValue = customerTierDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Company Configuration Id",
                        VariableType = "Guid",
                        OriginalValue = customerTierDetailCompanyConfigurationIdOriginalValue,
                        NewValue = companyConfigurationId
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Tier Code",
                        VariableType = "string",
                        OriginalValue = customerTierDetailCustomerTierCodeOriginalValue,
                        NewValue = customerTierCode
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Tier Description",
                        VariableType = "string",
                        OriginalValue = customerTierDetailCustomerTierDescriptionOriginalValue,
                        NewValue = customerTierDescription
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
                            ParameterName = "customerTier",
                            ParameterValue = customerTierDescription
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "customerTierCode",
                            ParameterValue = customerTierCode
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "customerTierId",
                            ParameterValue = _customerTierId
                        }
                    };
                    string storedProcedureName = "spUpdateCustomerTier";
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

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            CustomerTierDetailCustomerTierInformation_Load(this, EventArgs.Empty);
        }

        private void customerTierDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            customerTierDetailCompanyConfigurationComboBox.Enabled = !customerTierDetailCompanyConfigurationComboBox.Enabled;
            customerTierDetailCustomerTierCodeTextBox.ReadOnly = !customerTierDetailCustomerTierCodeTextBox.ReadOnly;
            customerTierDetailCustomerTierDescriptionTextBox.ReadOnly = !customerTierDetailCustomerTierDescriptionTextBox.ReadOnly;
            customerTierDetailActiveStatusCheckBox.Enabled = !customerTierDetailActiveStatusCheckBox.Enabled;
            customerTierDetailUpdateCustomerTierButton.Enabled = !customerTierDetailUpdateCustomerTierButton.Enabled;
        }
    }
}