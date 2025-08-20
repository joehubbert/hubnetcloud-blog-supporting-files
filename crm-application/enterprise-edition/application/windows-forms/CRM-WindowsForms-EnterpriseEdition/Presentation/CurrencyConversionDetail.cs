using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CurrencyConversionDetail : Form
    {
        private readonly Guid _currencyConversionId;
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private bool? currencyConversionDetailActiveStatusOriginalValue;
        private string? currencyConversionDetailBaseCurrencyCodeOriginalValue;
        private Guid? currencyConversionDetailBaseCurrencyIdOriginalValue;
        private decimal? currencyConversionDetailBaseCurrencyValueOriginalValue;
        private Guid currencyConversionDetailCompanyConfigurationIdOriginalValue;
        private DateTime? currencyConversionDetailEffectiveDateOriginalValue;
        private DateTime? currencyConversionDetailExpiryDateOriginalValue;
        private string? currencyConversionDetailTargetCurrencyCodeOriginalValue;
        private Guid? currencyConversionDetailTargetCurrencyIdOriginalValue;
        private decimal? currencyConversionDetailTargetCurrencyValueOriginalValue;

        public CurrencyConversionDetail(Guid currencyConversionId)
        {
            InitializeComponent();
            InitializeEventHandlers();
            _currencyConversionId = currencyConversionId;
            LoadDatabaseConnectionSettingsAsync();
        }

        private void InitializeEventHandlers()
        {
            currencyConversionDetailBaseCurrencyComboBox.DropDown += AdjustComboBoxWidth_DropDown;
            currencyConversionDetailCompanyConfigurationComboBox.DropDown += AdjustComboBoxWidth_DropDown;
            currencyConversionDetailTargetCurrencyComboBox.DropDown += AdjustComboBoxWidth_DropDown;
            currencyConversionDetailAddExpiryDateRadioButtonChoiceYesRadioButton.CheckedChanged += CurrencyConversionDetailAddExpiryDateRadioButtonChoice_CheckedChanged;
            currencyConversionDetailAddExpiryDateRadioButtonChoiceNoRadioButton.CheckedChanged += CurrencyConversionDetailAddExpiryDateRadioButtonChoice_CheckedChanged;
            currencyConversionDetailToggleEditModeButton.Click += currencyConversionDetailToggleEditModeButton_Click;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task LoadCompanyConfigurationAsync(Guid companyConfigurationId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(currencyConversionDetailCompanyConfigurationComboBox, "spGetAllCompanyConfiguration", null, true, "Company Configuration Id", companyConfigurationId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadCurrencyDataAsync(string currencyDirection, Guid currencyId)
        {
            switch (currencyDirection)
            {
                case "base":
                    _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(currencyConversionDetailBaseCurrencyComboBox, "spGetAllCurrency", null, true, "Currency Id", currencyId);
                    await _dataAccessComboBoxHelper.LoadDataAsync();
                    break;
                case "target":
                    _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(currencyConversionDetailTargetCurrencyComboBox, "spGetAllCurrency", null, true, "Currency Id", currencyId);
                    await _dataAccessComboBoxHelper.LoadDataAsync();
                    break;
                default:
                    throw new ArgumentException("Invalid currency direction specified.");
            }   
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDownHelper.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private void CurrencyConversionDetailAddExpiryDateRadioButtonChoice_CheckedChanged(object? sender, EventArgs e)
        {
            if (currencyConversionDetailAddExpiryDateRadioButtonChoiceYesRadioButton.Checked)
            {
                currencyConversionDetailExpiryDatePicker.Enabled = true;
            }
            else if (currencyConversionDetailAddExpiryDateRadioButtonChoiceNoRadioButton.Checked)
            {
                currencyConversionDetailExpiryDatePicker.Enabled = false;
            }
        }

        private async void CurrencyConversionDetailCurrencyConversionInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            string storedProcedureName = "spGetCurrencyConversion";
            string dataSubject = "Currency Conversion";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "currencyConversionId",
                    ParameterValue = _currencyConversionId
                }
            };

            try
            {
                DataTable? currencyConversionDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject);

                if (currencyConversionDataTable != null)
                {
                    DataRow currencyConversionDataRow = currencyConversionDataTable.Rows[0];
                    currencyConversionDetailCurrencyConversionIdTextbox.Text = currencyConversionDataRow["Currency Conversion Id"].ToString();
                    Guid baseCurrencyId = (Guid)currencyConversionDataRow["Base Currency Id"];
                    await LoadCurrencyDataAsync("base", baseCurrencyId);
                    currencyConversionDetailBaseCurrencyValueTextbox.Text = currencyConversionDataRow["Base Currency Conversion Rate]"].ToString();
                    currencyConversionDetailEffectiveDatePicker.Value = (DateTime)currencyConversionDataRow["Effective Date"];
                    if (currencyConversionDataRow["Expiry Date"] != DBNull.Value)
                    {
                        currencyConversionDetailAddExpiryDateRadioButtonChoiceYesRadioButton.Checked = true;
                        currencyConversionDetailExpiryDatePicker.Value = (DateTime)currencyConversionDataRow["Expiry Date"];
                    }
                    else
                    {
                        currencyConversionDetailAddExpiryDateRadioButtonChoiceNoRadioButton.Checked = true;
                        currencyConversionDetailExpiryDatePicker.Enabled = false;
                    }
                    Guid targetCurrencyId = (Guid)currencyConversionDataRow["Target Currency Id"];
                    await LoadCurrencyDataAsync("target", targetCurrencyId);
                    string targetCurrencyValuePartA;
                    string targetCurrencyValuePartB;
                    SplitDecimalHelper.SplitDecimalUsingDelimiter((decimal)currencyConversionDataRow["Target Currency Conversion Rate"], out targetCurrencyValuePartA, out targetCurrencyValuePartB);
                    currencyConversionDetailTargetCurrencyValueTextboxA.Text = targetCurrencyValuePartA;
                    currencyConversionDetailTargetCurrencyValueTextboxB.Text = targetCurrencyValuePartB;
                    currencyConversionDetailCreatedByTextbox.Text = currencyConversionDataRow["Created By"].ToString();
                    currencyConversionDetailCreatedTimestampTextbox.Text = currencyConversionDataRow["Created Timestamp UTC"].ToString();
                    currencyConversionDetailLastUpdatedByTextbox.Text = currencyConversionDataRow["Modified By"].ToString();
                    currencyConversionDetailLastUpdatedTimestampTextbox.Text = currencyConversionDataRow["Modified Timestamp UTC"].ToString();
                    currencyConversionDetailActiveStatusCheckbox.Checked = (bool)currencyConversionDataRow["Active Status"];
                    Guid companyConfigurationId = (Guid)currencyConversionDataRow["Company Configuration Id"];
                    await LoadCompanyConfigurationAsync(companyConfigurationId);

                    currencyConversionDetailActiveStatusOriginalValue = (bool)currencyConversionDataRow["Active Status"];
                    currencyConversionDetailBaseCurrencyIdOriginalValue = (Guid)currencyConversionDataRow["Base Currency Id"];
                    currencyConversionDetailBaseCurrencyValueOriginalValue = (decimal)currencyConversionDataRow["Base Currency Conversion Rate"];
                    currencyConversionDetailCompanyConfigurationIdOriginalValue = (Guid)currencyConversionDataRow["Company Configuration Id"];
                    currencyConversionDetailEffectiveDateOriginalValue = (DateTime)currencyConversionDataRow["Effective Date"];
                    currencyConversionDetailExpiryDateOriginalValue = currencyConversionDataRow["Expiry Date"] != DBNull.Value ? (DateTime?)currencyConversionDataRow["Expiry Date"] : null;
                    currencyConversionDetailTargetCurrencyIdOriginalValue = (Guid)currencyConversionDataRow["Target Currency Id"];
                    currencyConversionDetailTargetCurrencyValueOriginalValue = (decimal)currencyConversionDataRow["Target Currency Conversion Rate"];

                    this.Text += $" - {currencyConversionDetailBaseCurrencyCodeOriginalValue} to {currencyConversionDetailTargetCurrencyCodeOriginalValue}";
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

        private bool ValidateBaseAndTargetCurrencyDifferent()
        {
            if (currencyConversionDetailBaseCurrencyComboBox.SelectedValue != null &&
                currencyConversionDetailTargetCurrencyComboBox.SelectedValue != null &&
                currencyConversionDetailBaseCurrencyComboBox.SelectedValue.Equals(currencyConversionDetailTargetCurrencyComboBox.SelectedValue))
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.CurrencyConversion.BaseCurrencyTargetCurrencyDifference");
                return false;
            }
            return true;
        }

        private async void currencyConversionDetailUpdateCurrencyConversionButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = currencyConversionDetailActiveStatusCheckbox.Checked;

            if (string.IsNullOrWhiteSpace(currencyConversionDetailBaseCurrencyValueTextbox.Text) ||
                string.IsNullOrWhiteSpace(currencyConversionDetailTargetCurrencyValueTextboxA.Text) ||
                string.IsNullOrWhiteSpace(currencyConversionDetailTargetCurrencyValueTextboxB.Text))
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.CurrencyConversion.MissingValues");
                return;
            }

            if (currencyConversionDetailBaseCurrencyComboBox.SelectedValue is not Guid baseCurrencyId)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.DataValidation.Selection", "Base Currency");
                return;
            }

            if (currencyConversionDetailTargetCurrencyComboBox.SelectedValue is not Guid targetCurrencyId)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.DataValidation.Selection", "Target Currency");
                return;
            }

            Guid companyConfigurationId = Guid.Parse(currencyConversionDetailCompanyConfigurationComboBox.SelectedValue.ToString());
            DateTime effectiveDate = currencyConversionDetailEffectiveDatePicker.Value.Date;
            DateTime? expiryDate = null;
            if (currencyConversionDetailAddExpiryDateRadioButtonChoiceYesRadioButton.Checked)
            {
                expiryDate = currencyConversionDetailExpiryDatePicker.Value.Date;
                if (expiryDate <= effectiveDate)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.CurrencyConversion.EffectiveDateValidation");
                    return;
                }
            }

            if (!decimal.TryParse(currencyConversionDetailBaseCurrencyValueTextbox.Text, out decimal baseCurrencyConversionRate))
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.DataValidation.InvalidValue", "Base Currency Conversion Rate");
                return;
            }

            if (!decimal.TryParse(currencyConversionDetailTargetCurrencyValueTextboxA.Text.TrimEnd(), out decimal targetA) ||
                !decimal.TryParse(currencyConversionDetailTargetCurrencyValueTextboxB.Text.TrimEnd(), out decimal targetB))
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
                    Value = companyConfigurationId,
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
            else
            {
                var changesList = new List<ChangeDetail>
                {
                    new ChangeDetail
                    {
                        VariableName = "Active Status",
                        VariableType = "bool",
                        OriginalValue = currencyConversionDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Base Currency Conversion Rate",
                        VariableType = "decimal",
                        OriginalValue = currencyConversionDetailBaseCurrencyValueOriginalValue,
                        NewValue = baseCurrencyConversionRate
                    },
                    new ChangeDetail
                    {
                        VariableName = "Base Currency Id",
                        VariableType = "Guid",
                        OriginalValue = currencyConversionDetailBaseCurrencyIdOriginalValue,
                        NewValue = baseCurrencyId
                    },
                    new ChangeDetail
                    {
                        VariableName = "Company Configuration Id",
                        VariableType = "Guid",
                        OriginalValue = currencyConversionDetailCompanyConfigurationIdOriginalValue,
                        NewValue = companyConfigurationId
                    },
                    new ChangeDetail
                    {
                        VariableName = "Effective Date",
                        VariableType = "DateTime",
                        OriginalValue = currencyConversionDetailEffectiveDateOriginalValue,
                        NewValue = effectiveDate
                    },
                    new ChangeDetail
                    {
                        VariableName = "Expiry Date",
                        VariableType = "DateTime",
                        OriginalValue = currencyConversionDetailExpiryDateOriginalValue,
                        NewValue = expiryDate
                    },
                    new ChangeDetail
                    {
                        VariableName = "Target Currency Conversion Rate",
                        VariableType = "decimal",
                        OriginalValue = currencyConversionDetailTargetCurrencyValueOriginalValue,
                        NewValue = targetCurrencyConversionRate
                    },
                    new ChangeDetail
                    {
                        VariableName = "Target Currency Id",
                        VariableType = "Guid",
                        OriginalValue = currencyConversionDetailTargetCurrencyIdOriginalValue,
                        NewValue = targetCurrencyId
                    },
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = UpdateConfirmationService.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
                {
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
                            ParameterValue = companyConfigurationId
                        },
                        new Parameter
                        {
                            ParameterName = "currencyConversionId",
                            ParameterValue = _currencyConversionId
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
                    string storedProcedureName = "spUpdateCurrencyConversion";
                    string operationType = "update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters.ToArray(), dataSubject, operationType);
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
            CurrencyConversionDetailCurrencyConversionInformation_Load(this, EventArgs.Empty);
        }

        private void currencyConversionDetailToggleEditModeButton_Click(object sender, EventArgs e)
        {
            currencyConversionDetailActiveStatusCheckbox.Enabled = !currencyConversionDetailActiveStatusCheckbox.Enabled;
            currencyConversionDetailBaseCurrencyComboBox.Enabled = !currencyConversionDetailBaseCurrencyComboBox.Enabled;
            currencyConversionDetailEffectiveDatePicker.Enabled = !currencyConversionDetailEffectiveDatePicker.Enabled;
            currencyConversionDetailTargetCurrencyComboBox.Enabled = !currencyConversionDetailTargetCurrencyComboBox.Enabled;
            currencyConversionDetailTargetCurrencyValueTextboxA.ReadOnly = !currencyConversionDetailTargetCurrencyValueTextboxA.ReadOnly;
            currencyConversionDetailTargetCurrencyValueTextboxB.ReadOnly = !currencyConversionDetailTargetCurrencyValueTextboxB.ReadOnly;
        }
    }
}