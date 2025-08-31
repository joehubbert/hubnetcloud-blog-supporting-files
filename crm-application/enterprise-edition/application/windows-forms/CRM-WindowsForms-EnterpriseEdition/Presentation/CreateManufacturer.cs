using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateManufacturer : Form
    {
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Manufacturer";

        public CreateManufacturer()
        {
            InitializeComponent();
            InitializeEventHandlers();
            LoadDatabaseConnectionSettingsAsync();
            LoadCountryDataAsync();
        }

        private void InitializeEventHandlers()
        {
            createManufacturerTabControlFinanceTabPageVATRegisteredCheckBox.CheckedChanged += CreateManufacturerFinanceVATRegisteredCheckBox_CheckedChanged;
            createManufacturerTabControlOverviewTabPageAddressLine5ComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task LoadCountryDataAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createManufacturerTabControlOverviewTabPageAddressLine5ComboBox, "spGetAllCountry");
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private void CreateManufacturerFinanceVATRegisteredCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (createManufacturerTabControlFinanceTabPageVATRegisteredCheckBox.Checked)
            {
                createManufacturerTabControlFinanceTabPageVATNumberTextBox.Enabled = true;
            }
            else
            {
                createManufacturerTabControlFinanceTabPageVATNumberTextBox.Enabled = false;
                createManufacturerTabControlFinanceTabPageVATNumberTextBox.Text = string.Empty;
            }
        }

        private async void createManufacturerSubmitButton_Click(object sender, EventArgs e)
        {
            string? manufacturerFinanceVATNumber = createManufacturerTabControlFinanceTabPageVATNumberTextBox.Text.TrimEnd();
            bool manufacturerFinanceVATRegistered = createManufacturerTabControlFinanceTabPageVATRegisteredCheckBox.Checked;

            bool manufacturerOverviewActiveStatus = createManufacturerTabControlOverviewTabPageActiveStatusCheckBox.Checked;
            string manufacturerOverviewAddressLine1 = createManufacturerTabControlOverviewTabPageAddressLine1TextBox.Text.TrimEnd();
            string? manufacturerOverviewAddressLine2 = createManufacturerTabControlOverviewTabPageAddressLine2TextBox.Text.TrimEnd();
            string manufacturerOverviewAddressLine3 = createManufacturerTabControlOverviewTabPageAddressLine3TextBox.Text.TrimEnd();
            string manufacturerOverviewAddressLine4 = createManufacturerTabControlOverviewTabPageAddressLine4TextBox.Text.TrimEnd();
            Guid manufacturerOverviewAddressLine5 = Guid.Parse(createManufacturerTabControlOverviewTabPageAddressLine5ComboBox.SelectedValue.ToString());
            string manufacturerOverviewManufacturerName = createManufacturerTabControlOverviewTabPageManufacturerNameTextBox.Text.TrimEnd();
            string manufacturerOverviewEmailAddress = createManufacturerTabControlOverviewTabPageEmailAddressTextBox.Text.TrimEnd();
            string manufacturerOverviewTelephoneNumber = createManufacturerTabControlOverviewTabPageTelephoneNumberTextBox.Text.TrimEnd();

            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            var dataToValidate = new List<ValidateDataInputService.DataProperty>
            {
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Manufacturer Finance: VAT Number",
                    Value = manufacturerFinanceVATNumber,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Finance: VAT Registered",
                    Value = manufacturerFinanceVATRegistered,
                    ValueType = typeof(bool)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Overview: Active Status",
                    Value = manufacturerOverviewActiveStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Overview: Address Line 1",
                    Value = manufacturerOverviewAddressLine1,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Manufacturer Overview: Address Line 2",
                    Value = manufacturerOverviewAddressLine2,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Overview: Address Line 3",
                    Value = manufacturerOverviewAddressLine3,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Overview: Address Line 4",
                    Value = manufacturerOverviewAddressLine4,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Overview: Address Line 5",
                    Value = manufacturerOverviewAddressLine5,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Overview: Email Address",
                    Value = manufacturerOverviewEmailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Overview: Manufacturer Name",
                    Value = manufacturerOverviewManufacturerName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Overview: Telephone Number",
                    Value = manufacturerOverviewTelephoneNumber,
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
                var parameters = new List<StoredProcedureParameter>
                {
                    new StoredProcedureParameter
                    {
                        ParameterName = "activeStatus",
                        ParameterValue = manufacturerOverviewActiveStatus
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "addressLine1",
                        ParameterValue = manufacturerOverviewAddressLine1
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "addressLine3",
                        ParameterValue = manufacturerOverviewAddressLine3
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "addressLine4",
                        ParameterValue = manufacturerOverviewAddressLine4
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "addressLine5",
                        ParameterValue = manufacturerOverviewAddressLine5
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "emailAddress",
                        ParameterValue = manufacturerOverviewEmailAddress
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "manufacturerName",
                        ParameterValue = manufacturerOverviewManufacturerName
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "telephoneNumber",
                        ParameterValue = manufacturerOverviewTelephoneNumber
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "vatRegistered",
                        ParameterValue = manufacturerFinanceVATRegistered
                    }
                };

                if (!string.IsNullOrEmpty(manufacturerOverviewAddressLine2))
                {
                    parameters.Add(new StoredProcedureParameter
                    {
                        ParameterName = "addressLine2",
                        ParameterValue = manufacturerOverviewAddressLine2
                    });
                }

                if (!string.IsNullOrEmpty(manufacturerFinanceVATNumber))
                {
                    parameters.Add(new StoredProcedureParameter
                    {
                        ParameterName = "vatNumber",
                        ParameterValue = manufacturerOverviewAddressLine2
                    });
                }

                string storedProcedureName = "spCreateManufacturer";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters.ToArray(), dataSubject, operationType);
                this.Close();
            }
        }
    }
}