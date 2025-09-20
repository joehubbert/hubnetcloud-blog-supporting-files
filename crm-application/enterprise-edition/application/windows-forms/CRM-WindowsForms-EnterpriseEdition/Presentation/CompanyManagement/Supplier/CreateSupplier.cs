using CRM.Helpers;
using CRM.Interface;
using CRM.Model;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.CompanyManagement.Supplier
{
    public partial class CreateSupplier : Form
    {
        private Guid _companyConfigurationId;
        private ActiveCompanyConfigurationHelper? _companyConfigHelper;
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private TextBoxNumericCharacterDataValidationHelper _textBoxNumericHelper;
        private readonly string dataSubject = "Supplier";

        public CreateSupplier()
        {
            InitializeComponent();
            _textBoxNumericHelper = new TextBoxNumericCharacterDataValidationHelper();
            InitializeEventHandlers();
            LoadDatabaseConnectionSettingsAsync();
            LoadActiveCompanyConfigurationAsync();
            LoadCountryDataAsync();
            LoadCurrencyDataAsync();
        }

        private void InitializeEventHandlers()
        {
            createSupplierTabControlFinanceTabPagePaymentCurrencyComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            createSupplierTabControlFinanceTabPagePaymentDaysTextBox.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            createSupplierTabControlFinanceTabPageVATRegisteredCheckBox.CheckedChanged += createSupplierFinanceVATRegisteredCheckBox_CheckedChanged;
        }

        private async void LoadActiveCompanyConfigurationAsync()
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(createSupplierStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.LoadAsync();
            _companyConfigurationId = _companyConfigHelper.CompanyConfigurationId;
        }

        private async Task LoadCountryDataAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createSupplierTabControlOverviewTabPageAddressLine5ComboBox, "spGetAllCountry");
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadCurrencyDataAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createSupplierTabControlFinanceTabPagePaymentCurrencyComboBox, "spGetAllCurrency");
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void createSupplierFinanceVATRegisteredCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (createSupplierTabControlFinanceTabPageVATRegisteredCheckBox.Checked)
            {
                createSupplierTabControlFinanceTabPageVATNumberTextBox.Enabled = true;
            }
            else
            {
                createSupplierTabControlFinanceTabPageVATNumberTextBox.Enabled = false;
                var result = MessageBox.Show(
                    "A VAT Number cannot be assigned if VAT Registered is false. Clicking OK will clear the VAT Number field. Clicking Cancel will reverse the changes.",
                    "Warning",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    createSupplierTabControlFinanceTabPageVATNumberTextBox.Text = string.Empty;
                }
                else
                {
                    createSupplierTabControlFinanceTabPageVATRegisteredCheckBox.Checked = true;
                    createSupplierTabControlFinanceTabPageVATNumberTextBox.Enabled = true;
                }
            }
        }

        private async void createSupplierSubmitButton_Click(object sender, EventArgs e)
        {
            Guid supplierFinancePaymentCurrencyId = (Guid)createSupplierTabControlFinanceTabPagePaymentCurrencyComboBox.SelectedValue;
            byte supplierFinancePaymentDays = byte.Parse(TextBoxCleanerHelper.GetTrimmedText(createSupplierTabControlFinanceTabPagePaymentDaysTextBox));
            string? supplierFinanceVATNumber = TextBoxCleanerHelper.GetTrimmedText(createSupplierTabControlFinanceTabPageVATNumberTextBox);
            bool supplierFinanceVATRegistered = createSupplierTabControlFinanceTabPageVATRegisteredCheckBox.Checked;

            bool supplierOverviewActiveStatus = createSupplierTabControlOverviewTabPageActiveStatusCheckBox.Checked;
            string supplierOverviewAddressLine1 = TextBoxCleanerHelper.GetTrimmedText(createSupplierTabControlOverviewTabPageAddressLine1TextBox);
            string? supplierOverviewAddressLine2 = TextBoxCleanerHelper.GetTrimmedText(createSupplierTabControlOverviewTabPageAddressLine2TextBox);
            string supplierOverviewAddressLine3 = TextBoxCleanerHelper.GetTrimmedText(createSupplierTabControlOverviewTabPageAddressLine3TextBox);
            string supplierOverviewAddressLine4 = TextBoxCleanerHelper.GetTrimmedText(createSupplierTabControlOverviewTabPageAddressLine4TextBox);
            Guid supplierOverviewAddressLine5 = (Guid)createSupplierTabControlOverviewTabPageAddressLine5ComboBox.SelectedValue;
            string supplierOverviewSupplierName = TextBoxCleanerHelper.GetTrimmedText(createSupplierTabControlOverviewTabPageSupplierNameTextBox);
            string supplierOverviewEmailAddress = TextBoxCleanerHelper.GetTrimmedText(createSupplierTabControlOverviewTabPageEmailAddressTextBox);
            string supplierOverviewTelephoneNumber = TextBoxCleanerHelper.GetTrimmedText(createSupplierTabControlOverviewTabPageTelephoneNumberTextBox);

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
                    Name = "Company Configuration Id",
                    Value = _companyConfigurationId,
                    ValueType = typeof(Guid)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Finance: Payment Currency Id",
                    Value = supplierFinancePaymentCurrencyId,
                    ValueType = typeof(Guid)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Finance: Payment Days",
                    Value = supplierFinancePaymentDays,
                    ValueType = typeof(byte)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Supplier Finance: VAT Number",
                    Value = supplierFinanceVATNumber,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Finance: VAT Registered",
                    Value = supplierFinanceVATRegistered,
                    ValueType = typeof(bool)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Overview: Active Status",
                    Value = supplierOverviewActiveStatus,
                    ValueType = typeof(bool)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Overview: Address Line 1",
                    Value = supplierOverviewAddressLine1,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Supplier Overview: Address Line 2",
                    Value = supplierOverviewAddressLine2,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Overview: Address Line 3",
                    Value = supplierOverviewAddressLine3,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Overview: Address Line 4",
                    Value = supplierOverviewAddressLine4,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Overview: Address Line 5",
                    Value = supplierOverviewAddressLine5,
                    ValueType = typeof(Guid)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Overview: Email Address",
                    Value = supplierOverviewEmailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Overview: Supplier Name",
                    Value = supplierOverviewSupplierName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Overview: Telephone Number",
                    Value = supplierOverviewTelephoneNumber,
                    MaxLength = 13,
                    ValueType = typeof(string)
                }
            };

            dataToValidate = dataToValidate.OrderBy(change => change.Name).ToList();

            var validationResult = DataValidationService.ValidateInput(dataToValidate);

            if (!validationResult.IsValid)
            {
                return;
            }
            else
            {
                var parameters = new List<StoredProcedureParameter>
                {
                    new StoredProcedureParameter
                    {
                        ParameterName = "activeStatus",
                        ParameterValue = supplierOverviewActiveStatus
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "addressLine1",
                        ParameterValue = supplierOverviewAddressLine1
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "addressLine3",
                        ParameterValue = supplierOverviewAddressLine3
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "addressLine4",
                        ParameterValue = supplierOverviewAddressLine4
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "addressLine5",
                        ParameterValue = supplierOverviewAddressLine5
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "companyConfigurationId",
                        ParameterValue = _companyConfigurationId
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "emailAddress",
                        ParameterValue = supplierOverviewEmailAddress
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "paymentCurrencyId",
                        ParameterValue = supplierFinancePaymentCurrencyId
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "paymentDays",
                        ParameterValue = supplierFinancePaymentDays
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "supplierName",
                        ParameterValue = supplierOverviewSupplierName
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "telephoneNumber",
                        ParameterValue = supplierOverviewTelephoneNumber
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "vatRegistered",
                        ParameterValue = supplierFinanceVATRegistered
                    }
                };

                if (!string.IsNullOrEmpty(supplierOverviewAddressLine2))
                {
                    parameters.Add(new StoredProcedureParameter
                    {
                        ParameterName = "addressLine2",
                        ParameterValue = supplierOverviewAddressLine2
                    });
                }

                if (!string.IsNullOrEmpty(supplierFinanceVATNumber))
                {
                    parameters.Add(new StoredProcedureParameter
                    {
                        ParameterName = "vatNumber",
                        ParameterValue = supplierFinanceVATNumber
                    });
                }

                string storedProcedureName = "spCreateSupplier";
                string operationType = "Create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(_databaseConnectionSettings, storedProcedureName, parameters.ToArray(), dataSubject, operationType);
                this.Close();
            }
        }

        private async void changeActiveCompanyConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(createSupplierStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.ShowChangeDialogAndReloadAsync(this);
            _companyConfigurationId = _companyConfigHelper.CompanyConfigurationId;
        }
    }
}