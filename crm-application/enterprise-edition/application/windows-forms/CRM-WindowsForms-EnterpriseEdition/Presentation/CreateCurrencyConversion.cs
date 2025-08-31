using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateCurrencyConversion : Form
    {
        private Guid _companyConfigurationId;
        private ActiveCompanyConfigurationHelper? _companyConfigHelper;
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreateCurrencyConversion()
        {
            InitializeComponent();
            InitializeEventHandlers();
            LoadDatabaseConnectionSettingsAsync();
            LoadActiveCompanyConfigurationAsync();
            LoadCurrencyDataAsync();
        }

        private void InitializeEventHandlers()
        {
            createCurrencyConversionBaseCurrencyComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            createCurrencyConversionTargetCurrencyComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            createCurrencyConversionAddExpiryDateRadioButtonChoiceYesRadioButton.CheckedChanged += CreateCurrencyConversionAddExpiryDateRadioButtonChoice_CheckedChanged;
            createCurrencyConversionAddExpiryDateRadioButtonChoiceNoRadioButton.CheckedChanged += CreateCurrencyConversionAddExpiryDateRadioButtonChoice_CheckedChanged;
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void LoadActiveCompanyConfigurationAsync()
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(createCurrencyConversionStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.LoadAsync();
            _companyConfigurationId = _companyConfigHelper.CompanyConfigurationId;
        }

        private async void LoadCurrencyDataAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCurrencyConversionBaseCurrencyComboBox, "spGetAllCurrency");
            await _dataAccessComboBoxHelper.LoadDataAsync();

            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCurrencyConversionTargetCurrencyComboBox, "spGetAllCurrency");
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private void CreateCurrencyConversionAddExpiryDateRadioButtonChoice_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCurrencyConversionAddExpiryDateRadioButtonChoiceYesRadioButton.Checked)
            {
                createCurrencyConversionExpiryDatePicker.Enabled = true;
            }
            else if (createCurrencyConversionAddExpiryDateRadioButtonChoiceNoRadioButton.Checked)
            {
                createCurrencyConversionExpiryDatePicker.Enabled = false;
            }
        }

        private bool ValidateBaseAndTargetCurrencyDifferent()
        {
            if (createCurrencyConversionBaseCurrencyComboBox.SelectedValue != null &&
                createCurrencyConversionTargetCurrencyComboBox.SelectedValue != null &&
                createCurrencyConversionBaseCurrencyComboBox.SelectedValue.Equals(createCurrencyConversionTargetCurrencyComboBox.SelectedValue))
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.CurrencyConversion.BaseCurrencyTargetCurrencyDifference");
                return false;
            }
            return true;
        }

        private async void createCurrencyConversionSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createCurrencyConversionActiveStatusCheckBox.Checked;

            if (string.IsNullOrWhiteSpace(createCurrencyConversionBaseCurrencyValueTextBox.Text) ||
                string.IsNullOrWhiteSpace(createCurrencyConversionTargetCurrencyValueTextBoxA.Text) ||
                string.IsNullOrWhiteSpace(createCurrencyConversionTargetCurrencyValueTextBoxB.Text))
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.CurrencyConversion.MissingValues");
                return;
            }

            if (createCurrencyConversionBaseCurrencyComboBox.SelectedValue is not Guid baseCurrencyId)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.DataValidation.Selection", "Base Currency");
                return;
            }

            if (createCurrencyConversionTargetCurrencyComboBox.SelectedValue is not Guid targetCurrencyId)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.DataValidation.Selection", "Target Currency");
                return;
            }

            DateTime effectiveDate = createCurrencyConversionEffectiveDatePicker.Value.Date;
            DateTime? expiryDate = null;
            if (createCurrencyConversionAddExpiryDateRadioButtonChoiceYesRadioButton.Checked)
            {
                expiryDate = createCurrencyConversionExpiryDatePicker.Value.Date;
                if (expiryDate <= effectiveDate)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.CurrencyConversion.EffectiveDateValidation");
                    return;
                }
            }

            if (!decimal.TryParse(createCurrencyConversionBaseCurrencyValueTextBox.Text, out decimal baseCurrencyConversionRate))
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.DataValidation.InvalidValue", "Base Currency Conversion Rate");
                return;
            }

            if (!decimal.TryParse(createCurrencyConversionTargetCurrencyValueTextBoxA.Text.TrimEnd(), out decimal targetA) ||
                !decimal.TryParse(createCurrencyConversionTargetCurrencyValueTextBoxB.Text.TrimEnd(), out decimal targetB))
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.DataValidation.InvalidValue", "Target Currency Conversion Rate");
                return;
            }

            decimal targetCurrencyConversionRate = targetA + (targetB / 100);

            string dataSubject = "Currency Conversion";

            if (!ValidateBaseAndTargetCurrencyDifferent())
            {
                return;
            }

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
                        Name = "Base Currency Conversion Rate",
                        Value = baseCurrencyConversionRate,
                        ValueType = typeof(decimal)
                    },
                    new ValidateDataInputService.DataProperty
                    {
                        AllowNullValue = false,
                        Name = "Base Currency Id",
                        Value = baseCurrencyId,
                        ValueType = typeof(Guid)
                    },
                    new ValidateDataInputService.DataProperty
                    {
                        AllowNullValue = false,
                        Name = "Company Configuration Id",
                        Value = _companyConfigurationId,
                        ValueType = typeof(Guid)
                    },
                    new ValidateDataInputService.DataProperty
                    {
                        AllowNullValue = false,
                        Name = "Effective Date",
                        Value = effectiveDate,
                        ValueType = typeof(DateTime)
                    },
                    new ValidateDataInputService.DataProperty
                    {
                        AllowNullValue = true,
                        Name = "Expiry Date",
                        Value = expiryDate,
                        ValueType = typeof(DateTime)
                    },
                    new ValidateDataInputService.DataProperty
                    {
                        AllowNullValue = false,
                        Name = "Target Currency Conversion Rate",
                        Value = targetCurrencyConversionRate,
                        ValueType = typeof(decimal)
                    },
                    new ValidateDataInputService.DataProperty
                    {
                        AllowNullValue = false,
                        Name = "Target Currency Id",
                        Value = targetCurrencyId,
                        ValueType = typeof(Guid)
                    }
                };

            dataToValidate = dataToValidate.OrderBy(change => change.Name).ToList();

            var validationResult = ValidateDataInputService.ValidateInput(dataToValidate);

            if (!validationResult.IsValid)
            {
                return;
            }

            var parameters = new List<StoredProcedureParameter>
                {
                    new StoredProcedureParameter
                    {
                        ParameterName = "activeStatus",
                        ParameterValue = activeStatus
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "baseCurrencyConversionRate",
                        ParameterValue = baseCurrencyConversionRate
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "baseCurrencyId",
                        ParameterValue = baseCurrencyId
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "companyConfigurationId",
                        ParameterValue = _companyConfigurationId
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "effectiveDate",
                        ParameterValue = effectiveDate
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "targetCurrencyConversionRate",
                        ParameterValue = targetCurrencyConversionRate
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "targetCurrencyId",
                        ParameterValue = targetCurrencyId
                    }
                };

            if (expiryDate != null)
            {
                parameters.Add(new StoredProcedureParameter
                {
                    ParameterName = "expiryDate",
                    ParameterValue = expiryDate
                });
            }

            string storedProcedureName = "spCreateCustomerTier";
            string operationType = "create";

            await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters.ToArray(), dataSubject, operationType);
            this.Close();
        }

        private async void changeActiveCompanyConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(createCurrencyConversionStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.ShowChangeDialogAndReloadAsync(this);
            _companyConfigurationId = _companyConfigHelper.CompanyConfigurationId;
        }
    }
}