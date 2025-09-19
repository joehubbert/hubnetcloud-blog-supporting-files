using CRM.Helpers;
using CRM.Interface;
using CRM.Services;
using System.Data;
using System.Diagnostics;

namespace CRM.Presentation.CompanyManagement.CurrencyConversion
{
    public partial class CreateCurrencyConversion : Form
    {
        private Guid _companyConfigurationCurrencyId;
        private Guid _companyConfigurationId;
        private ActiveCompanyConfigurationHelper? _companyConfigHelper;
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private TextBoxNumericCharacterDataValidationHelper _textBoxNumericHelper;

        public CreateCurrencyConversion()
        {
            InitializeComponent();
            _textBoxNumericHelper = new TextBoxNumericCharacterDataValidationHelper();
            InitializeEventHandlers();
            LoadDatabaseConnectionSettingsAsync();
            LoadActiveCompanyConfigurationAsync();
        }

        private void InitializeEventHandlers()
        {
            createCurrencyConversionBaseCurrencyComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            createCurrencyConversionTargetCurrencyComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            createCurrencyConversionTargetCurrencyValueTextBoxA.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            createCurrencyConversionTargetCurrencyValueTextBoxB.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            createCurrencyConversionAddExpiryDateRadioButtonChoiceYesRadioButton.CheckedChanged += createCurrencyConversionAddExpiryDateRadioButtonChoiceContainerPanelRadioButtonChoice_CheckedChanged;
            createCurrencyConversionAddExpiryDateRadioButtonChoiceNoRadioButton.CheckedChanged += createCurrencyConversionAddExpiryDateRadioButtonChoiceContainerPanelRadioButtonChoice_CheckedChanged;
        }

        private async void LoadActiveCompanyConfigurationAsync()
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(createCurrencyConversionStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.LoadAsync();
            _companyConfigurationId = _companyConfigHelper.CompanyConfigurationId;

            var companyConfigurationDataTableHelper = new DataAccessLookupHelper(
                "spGetAllCompanyConfiguration",
                _companyConfigurationId);

            var companyConfigurationDataTable = await companyConfigurationDataTableHelper.GetFilteredDataTableAsync();
            if (companyConfigurationDataTable != null && companyConfigurationDataTable.Rows.Count > 0)
            {
                _companyConfigurationCurrencyId = companyConfigurationDataTable.Rows[0].Field<Guid>("Bank Account Currency Id");
                Debug.WriteLine($"Loaded Company Configuration Currency Id: {_companyConfigurationCurrencyId}");
            }

            await LoadCurrencyDataAsync();
        }

        private async Task LoadCurrencyDataAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCurrencyConversionBaseCurrencyComboBox, "spGetAllCurrency", 
                null,
                true,
                "Currency Id",
                _companyConfigurationCurrencyId,
                false,
                null,
                null,
                null,
                true);
            await _dataAccessComboBoxHelper.LoadDataAsync();

            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCurrencyConversionTargetCurrencyComboBox, "spGetAllCurrency");
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
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

        private async void changeActiveCompanyConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(createCurrencyConversionStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.ShowChangeDialogAndReloadAsync(this);
            _companyConfigurationId = _companyConfigHelper.CompanyConfigurationId;
        }

        private void createCurrencyConversionAddExpiryDateRadioButtonChoiceContainerPanelRadioButtonChoice_CheckedChanged(object? sender, EventArgs e)
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

            Guid baseCurrencyId = (Guid)createCurrencyConversionBaseCurrencyComboBox.SelectedValue;
            DateTime effectiveDate = createCurrencyConversionEffectiveDatePicker.Value.Date;
            DateTime? expiryDate = null;
            if (createCurrencyConversionAddExpiryDateRadioButtonChoiceYesRadioButton.Checked)
            {
                expiryDate = createCurrencyConversionExpiryDatePicker.Value.Date;
                DateComparisonHelper.ValidateEffectiveAndExpiryDates(createCurrencyConversionEffectiveDatePicker, createCurrencyConversionExpiryDatePicker);
                if (expiryDate <= effectiveDate)
                {
                    // Prevent further processing if invalid
                    return;
                }
            }

            if (!decimal.TryParse(TextBoxCleanerHelper.GetTrimmedText(createCurrencyConversionBaseCurrencyValueTextBox), out decimal baseCurrencyConversionRate))
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Validation.InvalidValue", "Base Currency Conversion Rate");
                return;
            }

            if (!decimal.TryParse(TextBoxCleanerHelper.GetTrimmedText(createCurrencyConversionTargetCurrencyValueTextBoxA), out decimal targetA) ||
                !decimal.TryParse(TextBoxCleanerHelper.GetTrimmedText(createCurrencyConversionTargetCurrencyValueTextBoxB), out decimal targetB))
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Validation.InvalidValue", "Target Currency Conversion Rate");
                return;
            }

            string targetBText = TextBoxCleanerHelper.GetTrimmedText(createCurrencyConversionTargetCurrencyValueTextBoxB);
            decimal targetCurrencyConversionRate;
            if (!string.IsNullOrEmpty(targetBText))
            {
                int digits = targetBText.Length;
                decimal divisor = (decimal)Math.Pow(10, digits);
                targetCurrencyConversionRate = targetA + (targetB / divisor);
            }
            else
            {
                targetCurrencyConversionRate = targetA;
            }
            Guid targetCurrencyId = (Guid)createCurrencyConversionTargetCurrencyComboBox.SelectedValue;

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

            var dataToValidate = new List<DataValidationService.DataProperty>
                {
                    new DataValidationService.DataProperty
                    {
                        AllowNullValue = false,
                        Name = "Active Status",
                        Value = activeStatus,
                        ValueType = typeof(bool)
                    },
                    new DataValidationService.DataProperty
                    {
                        AllowNullValue = false,
                        Name = "Base Currency Conversion Rate",
                        Value = baseCurrencyConversionRate,
                        ValueType = typeof(decimal)
                    },
                    new DataValidationService.DataProperty
                    {
                        AllowNullValue = false,
                        Name = "Base Currency Id",
                        Value = baseCurrencyId,
                        ValueType = typeof(Guid)
                    },
                    new DataValidationService.DataProperty
                    {
                        AllowNullValue = false,
                        Name = "Company Configuration Id",
                        Value = _companyConfigurationId,
                        ValueType = typeof(Guid)
                    },
                    new DataValidationService.DataProperty
                    {
                        AllowNullValue = false,
                        Name = "Effective Date",
                        Value = effectiveDate,
                        ValueType = typeof(DateTime)
                    },
                    new DataValidationService.DataProperty
                    {
                        AllowNullValue = true,
                        Name = "Expiry Date",
                        Value = expiryDate,
                        ValueType = typeof(DateTime)
                    },
                    new DataValidationService.DataProperty
                    {
                        AllowNullValue = false,
                        Name = "Target Currency Conversion Rate",
                        Value = targetCurrencyConversionRate,
                        ValueType = typeof(decimal)
                    },
                    new DataValidationService.DataProperty
                    {
                        AllowNullValue = false,
                        Name = "Target Currency Id",
                        Value = targetCurrencyId,
                        ValueType = typeof(Guid)
                    }
                };

            dataToValidate = dataToValidate.OrderBy(change => change.Name).ToList();

            var validationResult = DataValidationService.ValidateInput(dataToValidate);

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

            string storedProcedureName = "spCreateCurrencyConversion";
            string operationType = "Create";

            await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters.ToArray(), dataSubject, operationType);
            this.Close();
        }
    }
}