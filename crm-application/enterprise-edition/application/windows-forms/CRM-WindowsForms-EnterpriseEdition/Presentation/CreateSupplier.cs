using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateSupplier : Form
    {
        private Guid _companyConfigurationId;
        private ActiveCompanyConfigurationHelper? _companyConfigHelper;
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Supplier";

        public CreateSupplier()
        {
            InitializeComponent();
            InitializeEventHandlers();
            LoadDatabaseConnectionSettingsAsync();
            LoadActiveCompanyConfigurationAsync();
            LoadCountryDataAsync();
            LoadCurrencyDataAsync();
        }

        private void InitializeEventHandlers()
        {
            createSupplierTabControlFinanceTabPagePaymentCurrencyComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            createSupplierTabControlFinanceTabPageVATRegisteredCheckbox.CheckedChanged += CreateSupplierFinanceVATRegisteredCheckBox_CheckedChanged;
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
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

        private void CreateSupplierFinanceVATRegisteredCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (createSupplierTabControlFinanceTabPageVATRegisteredCheckbox.Checked)
            {
                createSupplierTabControlFinanceTabPageVATNumberTextBox.Enabled = true;
            }
            else
            {
                createSupplierTabControlFinanceTabPageVATNumberTextBox.Enabled = false;
                createSupplierTabControlFinanceTabPageVATNumberTextBox.Text = string.Empty;
            }
        }

        private async void createSupplierSubmitButton_Click(object sender, EventArgs e)
        {
            Guid supplierFinancePaymentCurrencyId = Guid.Parse(createSupplierTabControlFinanceTabPagePaymentCurrencyComboBox.SelectedValue.ToString());
            byte supplierFinancePaymentDays = byte.Parse(createSupplierTabControlFinanceTabPagePaymentDaysTextBox.Text.TrimEnd());
            string? supplierFinanceVATNumber = createSupplierTabControlFinanceTabPageVATNumberTextBox.Text.TrimEnd();
            bool supplierFinanceVATRegistered = createSupplierTabControlFinanceTabPageVATRegisteredCheckbox.Checked;

            bool supplierOverviewActiveStatus = createSupplierTabControlOverviewTabPageActiveStatusCheckbox.Checked;
            string supplierOverviewAddressLine1 = createSupplierTabControlOverviewTabPageAddressLine1TextBox.Text.TrimEnd();
            string? supplierOverviewAddressLine2 = createSupplierTabControlOverviewTabPageAddressLine2TextBox.Text.TrimEnd();
            string supplierOverviewAddressLine3 = createSupplierTabControlOverviewTabPageAddressLine3TextBox.Text.TrimEnd();
            string supplierOverviewAddressLine4 = createSupplierTabControlOverviewTabPageAddressLine4TextBox.Text.TrimEnd();
            Guid supplierOverviewAddressLine5 = Guid.Parse(createSupplierTabControlOverviewTabPageAddressLine5ComboBox.SelectedValue.ToString());
            string supplierOverviewSupplierName = createSupplierTabControlOverviewTabPageSupplierNameTextBox.Text.TrimEnd();
            string supplierOverviewEmailAddress = createSupplierTabControlOverviewTabPageEmailAddressTextBox.Text.TrimEnd();
            string supplierOverviewTelephoneNumber = createSupplierTabControlOverviewTabPageTelephoneNumberTextBox.Text.TrimEnd();

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
                    Name = "Company Configuration Id",
                    Value = _companyConfigurationId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Finance: Payment Currency Id",
                    Value = supplierFinancePaymentCurrencyId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Finance: Payment Days",
                    Value = supplierFinancePaymentDays,
                    ValueType = typeof(byte)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Supplier Finance: VAT Number",
                    Value = supplierFinanceVATNumber,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Finance: VAT Registered",
                    Value = supplierFinanceVATRegistered,
                    ValueType = typeof(bool)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Overview: Active Status",
                    Value = supplierOverviewActiveStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Overview: Address Line 1",
                    Value = supplierOverviewAddressLine1,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Supplier Overview: Address Line 2",
                    Value = supplierOverviewAddressLine2,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Overview: Address Line 3",
                    Value = supplierOverviewAddressLine3,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Overview: Address Line 4",
                    Value = supplierOverviewAddressLine4,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Overview: Address Line 5",
                    Value = supplierOverviewAddressLine5,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Overview: Email Address",
                    Value = supplierOverviewEmailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Overview: Supplier Name",
                    Value = supplierOverviewSupplierName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Overview: Telephone Number",
                    Value = supplierOverviewTelephoneNumber,
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
                var parameters = new List<Parameter>
                {
                    new Parameter
                    {
                        ParameterName = "activeStatus",
                        ParameterValue = supplierOverviewActiveStatus
                    },
                    new Parameter
                    {
                        ParameterName = "addressLine1",
                        ParameterValue = supplierOverviewAddressLine1
                    },
                    new Parameter
                    {
                        ParameterName = "addressLine3",
                        ParameterValue = supplierOverviewAddressLine3
                    },
                    new Parameter
                    {
                        ParameterName = "addressLine4",
                        ParameterValue = supplierOverviewAddressLine4
                    },
                    new Parameter
                    {
                        ParameterName = "addressLine5",
                        ParameterValue = supplierOverviewAddressLine5
                    },
                    new Parameter
                    {
                        ParameterName = "companyConfigurationId",
                        ParameterValue = _companyConfigurationId
                    },
                    new Parameter
                    {
                        ParameterName = "emailAddress",
                        ParameterValue = supplierOverviewEmailAddress
                    },
                    new Parameter
                    {
                        ParameterName = "paymentCurrencyId",
                        ParameterValue = supplierFinancePaymentCurrencyId
                    },
                    new Parameter
                    {
                        ParameterName = "paymentDays",
                        ParameterValue = supplierFinancePaymentDays
                    },
                    new Parameter
                    {
                        ParameterName = "supplierName",
                        ParameterValue = supplierOverviewSupplierName
                    },
                    new Parameter
                    {
                        ParameterName = "telephoneNumber",
                        ParameterValue = supplierOverviewTelephoneNumber
                    },
                    new Parameter
                    {
                        ParameterName = "vatRegistered",
                        ParameterValue = supplierFinanceVATRegistered
                    }
                };

                if (!string.IsNullOrEmpty(supplierOverviewAddressLine2))
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "addressLine2",
                        ParameterValue = supplierOverviewAddressLine2
                    });
                }

                if (!string.IsNullOrEmpty(supplierFinanceVATNumber))
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "vatNumber",
                        ParameterValue = supplierFinanceVATNumber
                    });
                }

                string storedProcedureName = "spCreateSupplier";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters.ToArray(), dataSubject, operationType);
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