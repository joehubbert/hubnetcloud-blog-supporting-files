using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CustomerTierDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _customerTierId;
        private bool? customerTierDetailActiveStatusOriginalValue;
        private string? customerTierDetailCustomerTierCodeOriginalValue;
        private string? customerTierDetailCustomerTierDescriptionOriginalValue;
        private readonly string dataSubject = "Customer Tier";

        public CustomerTierDetail(Guid customerTierId)
        {
            InitializeComponent();
            _customerTierId = customerTierId;
            customerTierDetailToggleEditModeButton.Click += new EventHandler(customerTierDetailToggleEditModeButton_Click);
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
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
                new Parameter
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
                    customerTierDetailCustomerTierIdTextbox.Text = customerTierDataRow["Customer Tier Id"].ToString();
                    customerTierDetailCustomerTierCodeTextbox.Text = customerTierDataRow["Customer Tier Code"].ToString();
                    customerTierDetailCustomerTierDescriptionTextbox.Text = customerTierDataRow["Customer Tier Description"].ToString();
                    customerTierDetailCreatedByTextbox.Text = customerTierDataRow["Created By"].ToString();
                    customerTierDetailCreatedTimestampTextbox.Text = customerTierDataRow["Created Timestamp UTC"].ToString();
                    customerTierDetailLastUpdatedByTextbox.Text = customerTierDataRow["Modified By"].ToString();
                    customerTierDetailLastUpdatedTimestampTextbox.Text = customerTierDataRow["Modified Timestamp UTC"].ToString();
                    customerTierDetailActiveStatusCheckbox.Checked = (bool)customerTierDataRow["Active Status"];

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
            bool activeStatus = customerTierDetailActiveStatusCheckbox.Checked;
            string customerTierCode = customerTierDetailCustomerTierCodeTextbox.Text.TrimEnd();
            string customerTierDescription = customerTierDetailCustomerTierDescriptionTextbox.Text.TrimEnd();

            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            var dataToValidate = new List<ValidateDataInput.DataProperty>
            {
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Active Status",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerTierCode",
                    Value = customerTierCode,
                    MaxLength = 1,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerTierDescription",
                    Value = customerTierDescription,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
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
                        OriginalValue = customerTierDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
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

                bool confirmed = UpdateConfirmation.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
                {
                    var parameters = new[]
                    {
                        new Parameter
                        {
                            ParameterName = "activeStatus",
                            ParameterValue = activeStatus
                        },
                        new Parameter
                        {
                            ParameterName = "customerTier",
                            ParameterValue = customerTierDescription
                        },
                        new Parameter
                        {
                            ParameterName = "customerTierCode",
                            ParameterValue = customerTierCode
                        },
                        new Parameter
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
            customerTierDetailCustomerTierCodeTextbox.ReadOnly = !customerTierDetailCustomerTierCodeTextbox.ReadOnly;
            customerTierDetailCustomerTierDescriptionTextbox.ReadOnly = !customerTierDetailCustomerTierDescriptionTextbox.ReadOnly;
            customerTierDetailActiveStatusCheckbox.Enabled = !customerTierDetailActiveStatusCheckbox.Enabled;
            customerTierDetailUpdateCustomerTierButton.Enabled = !customerTierDetailUpdateCustomerTierButton.Enabled;
        }
    }
}