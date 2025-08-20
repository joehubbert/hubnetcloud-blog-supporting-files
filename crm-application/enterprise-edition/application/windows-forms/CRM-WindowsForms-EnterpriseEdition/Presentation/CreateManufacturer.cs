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
            LoadInitialDataAsync();
            LoadCountryDataAsync();
        }

        private void InitializeEventHandlers()
        {
            createManufacturerTabControlFinanceTabPageVATRegisteredCheckbox.CheckedChanged += new EventHandler(CreateManufacturerFinanceVATRegisteredCheckBox_CheckedChanged);
            createManufacturerTabControlOverviewTabPageAddressLine5ComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task LoadInitialDataAsync()
        {
            await LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadCountryDataAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createManufacturerTabControlOverviewTabPageAddressLine5ComboBox, "spGetAllCountry");
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDownHelper.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private void CreateManufacturerFinanceVATRegisteredCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (createManufacturerTabControlFinanceTabPageVATRegisteredCheckbox.Checked)
            {
                createManufacturerTabControlFinanceTabPageVATNumberTextbox.Enabled = true;
            }
            else
            {
                createManufacturerTabControlFinanceTabPageVATNumberTextbox.Enabled = false;
                createManufacturerTabControlFinanceTabPageVATNumberTextbox.Text = string.Empty;
            }
        }

        private async void createManufacturerSubmitButton_Click(object sender, EventArgs e)
        {
            string? manufacturerFinanceVATNumber = createManufacturerTabControlFinanceTabPageVATNumberTextbox.Text.TrimEnd();

            bool manufacturerOverviewActiveStatus = createManufacturerTabControlOverviewTabPageActiveStatusCheckbox.Checked;
            string manufacturerOverviewAddressLine1 = createManufacturerTabControlOverviewTabPageAddressLine1Textbox.Text.TrimEnd();
            string? manufacturerOverviewAddressLine2 = createManufacturerTabControlOverviewTabPageAddressLine2Textbox.Text.TrimEnd();
            string manufacturerOverviewAddressLine3 = createManufacturerTabControlOverviewTabPageAddressLine3Textbox.Text.TrimEnd();
            string manufacturerOverviewAddressLine4 = createManufacturerTabControlOverviewTabPageAddressLine4Textbox.Text.TrimEnd();
            Guid manufacturerOverviewAddressLine5 = Guid.Parse(createManufacturerTabControlOverviewTabPageAddressLine5ComboBox.SelectedValue.ToString());
            string manufacturerOverviewManufacturerName = createManufacturerTabControlOverviewTabPageManufacturerNameTextbox.Text.TrimEnd();
            string manufacturerOverviewEmailAddress = createManufacturerTabControlOverviewTabPageEmailAddressTextbox.Text.TrimEnd();
            string manufacturerOverviewTelephoneNumber = createManufacturerTabControlOverviewTabPageTelephoneNumberTextbox.Text.TrimEnd();

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
                var parameters = new List<Parameter>
                {
                    new Parameter
                    {
                        ParameterName = "activeStatus",
                        ParameterValue = manufacturerOverviewActiveStatus
                    },
                    new Parameter
                    {
                        ParameterName = "addressLine1",
                        ParameterValue = manufacturerOverviewAddressLine1
                    },
                    new Parameter
                    {
                        ParameterName = "addressLine3",
                        ParameterValue = manufacturerOverviewAddressLine3
                    },
                    new Parameter
                    {
                        ParameterName = "addressLine4",
                        ParameterValue = manufacturerOverviewAddressLine4
                    },
                    new Parameter
                    {
                        ParameterName = "addressLine5",
                        ParameterValue = manufacturerOverviewAddressLine5
                    },
                    new Parameter
                    {
                        ParameterName = "emailAddress",
                        ParameterValue = manufacturerOverviewEmailAddress
                    },
                    new Parameter
                    {
                        ParameterName = "manufacturerName",
                        ParameterValue = manufacturerOverviewManufacturerName
                    },
                    new Parameter
                    {
                        ParameterName = "telephoneNumber",
                        ParameterValue = manufacturerOverviewTelephoneNumber
                    }
                };

                if (!string.IsNullOrEmpty(manufacturerOverviewAddressLine2))
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "addressLine2",
                        ParameterValue = manufacturerOverviewAddressLine2
                    });
                }

                if (!string.IsNullOrEmpty(manufacturerFinanceVATNumber))
                {
                    parameters.Add(new Parameter
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