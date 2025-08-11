using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateCurrencyConversion : Form
    {
        private Guid _companyConfigurationId;
        private ActiveCompanyConfigurationHelper? _companyConfigHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreateCurrencyConversion()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadDatabaseConnectionSettingsAsync();
            LoadActiveCompanyConfigurationAsync();
            CreateCurrencyConversionLoadCurrencyDataAsync();
        }

        private void InitializeCustomComponents()
        {
            createCurrencyConversionBaseCurrencyComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            createCurrencyConversionTargetCurrencyComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            createCurrencyConversionAddExpiryDateRadioButtonChoiceYesRadioButton.CheckedChanged += new EventHandler(CreateCurrencyConversionAddExpiryDateRadioButtonChoice_CheckedChanged);
            createCurrencyConversionAddExpiryDateRadioButtonChoiceNoRadioButton.CheckedChanged += new EventHandler(CreateCurrencyConversionAddExpiryDateRadioButtonChoice_CheckedChanged);
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void LoadActiveCompanyConfigurationAsync()
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(createCurrencyConversionStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.LoadAsync();
        }

        private async void CreateCurrencyConversionLoadCurrencyDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Currency";

            try
            {
                string storedProcedureName = "spGetAllCurrency";
                DataTable? currencyData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject);

                var currencyList = currencyData.AsEnumerable()
                    .Select(row => new
                    {
                        CurrencyId = row.Field<Guid>("Currency Id"),
                        CurrencyCode = row.Field<string>("Currency Code"),
                        CurrencyName = row.Field<string>("Currency Name"),
                        DisplayText = $"{row.Field<string>("Currency Code")} - {row.Field<string>("Currency Name")}"
                    })
                    .OrderBy(item => item.DisplayText)
                    .ToList();

                createCurrencyConversionBaseCurrencyComboBox.DataSource = currencyList;
                createCurrencyConversionBaseCurrencyComboBox.DisplayMember = "DisplayText";
                createCurrencyConversionBaseCurrencyComboBox.ValueMember = "CurrencyId";

                createCurrencyConversionTargetCurrencyComboBox.DataSource = currencyList;
                createCurrencyConversionTargetCurrencyComboBox.DisplayMember = "DisplayText";
                createCurrencyConversionTargetCurrencyComboBox.ValueMember = "CurrencyId";
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
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
            bool activeStatus = createCurrencyConversionActiveStatusCheckbox.Checked;

            if (string.IsNullOrWhiteSpace(createCurrencyConversionBaseCurrencyValueTextbox.Text) ||
                string.IsNullOrWhiteSpace(createCurrencyConversionTargetCurrencyValueTextboxA.Text) ||
                string.IsNullOrWhiteSpace(createCurrencyConversionTargetCurrencyValueTextboxB.Text))
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

            if (!decimal.TryParse(createCurrencyConversionBaseCurrencyValueTextbox.Text, out decimal baseCurrencyConversionRate))
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.DataValidation.InvalidValue", "Base Currency Conversion Rate");
                return;
            }

            if (!decimal.TryParse(createCurrencyConversionTargetCurrencyValueTextboxA.Text.TrimEnd(), out decimal targetA) ||
                !decimal.TryParse(createCurrencyConversionTargetCurrencyValueTextboxB.Text.TrimEnd(), out decimal targetB))
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

            var dataToValidate = new List<ValidateDataInput.DataProperty>
                {
                    new ValidateDataInput.DataProperty
                    {
                        AllowNullValue = false,
                        Name = "ActiveStatus",
                        Value = activeStatus,
                        ValueType = typeof(bool)
                    },
                    new ValidateDataInput.DataProperty
                    {
                        AllowNullValue = false,
                        Name = "BaseCurrencyConversionRate",
                        Value = baseCurrencyConversionRate,
                        ValueType = typeof(decimal)
                    },
                    new ValidateDataInput.DataProperty
                    {
                        AllowNullValue = false,
                        Name = "BaseCurrencyId",
                        Value = baseCurrencyId,
                        ValueType = typeof(Guid)
                    },
                    new ValidateDataInput.DataProperty
                    {
                        AllowNullValue = false,
                        Name = "CompanyConfigurationId",
                        Value = _companyConfigurationId,
                        ValueType = typeof(Guid)
                    },
                    new ValidateDataInput.DataProperty
                    {
                        AllowNullValue = false,
                        Name = "EffectiveDate",
                        Value = effectiveDate,
                        ValueType = typeof(DateTime)
                    },
                    new ValidateDataInput.DataProperty
                    {
                        AllowNullValue = false,
                        Name = "TargetCurrencyConversionRate",
                        Value = targetCurrencyConversionRate,
                        ValueType = typeof(decimal)
                    },
                    new ValidateDataInput.DataProperty
                    {
                        AllowNullValue = false,
                        Name = "TargetCurrencyId",
                        Value = targetCurrencyId,
                        ValueType = typeof(Guid)
                    }
                };

            if (expiryDate != null)
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ExpiryDate",
                    Value = expiryDate,
                    ValueType = typeof(DateTime)
                });
            }

            dataToValidate = dataToValidate.OrderBy(change => change.Name).ToList();

            var validationResult = ValidateDataInput.ValidateInput(dataToValidate);

            if (!validationResult.IsValid)
            {
                return;
            }

            var parameters = new List<Parameter>
                {
                    new Parameter
                    {
                        ParameterName = "activeStatus",
                        ParameterValue = activeStatus
                    },
                    new Parameter
                    {
                        ParameterName = "baseCurrencyConversionRate",
                        ParameterValue = baseCurrencyConversionRate
                    },
                    new Parameter
                    {
                        ParameterName = "baseCurrencyId",
                        ParameterValue = baseCurrencyId
                    },
                    new Parameter
                    {
                        ParameterName = "companyConfigurationId",
                        ParameterValue = _companyConfigurationId
                    },
                    new Parameter
                    {
                        ParameterName = "effectiveDate",
                        ParameterValue = effectiveDate
                    },
                    new Parameter
                    {
                        ParameterName = "targetCurrencyConversionRate",
                        ParameterValue = targetCurrencyConversionRate
                    },
                    new Parameter
                    {
                        ParameterName = "targetCurrencyId",
                        ParameterValue = targetCurrencyId
                    }
                };

            if (expiryDate != null)
            {
                parameters.Add(new Parameter
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
        }
    }
}