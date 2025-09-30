using CRM.Helpers;
using CRM.Interface;
using CRM.Model;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.Manufacturer
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
            createManufacturerTabControlFinanceTabPageVATRegisteredCheckBox.CheckedChanged += createManufacturerFinanceVATRegisteredCheckBox_CheckedChanged;
            createManufacturerTabControlOverviewTabPageAddressLine5ComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
        }

        private async Task LoadCountryDataAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createManufacturerTabControlOverviewTabPageAddressLine5ComboBox, FunctionTitle.Country);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void createManufacturerFinanceVATRegisteredCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (createManufacturerTabControlFinanceTabPageVATRegisteredCheckBox.Checked)
            {
                createManufacturerTabControlFinanceTabPageVATNumberTextBox.Enabled = true;
            }
            else
            {
                createManufacturerTabControlFinanceTabPageVATNumberTextBox.Enabled = false;
                var result = MessageBox.Show(
                    "A VAT Number cannot be assigned if VAT Registered is false. Clicking OK will clear the VAT Number field. Clicking Cancel will reverse the changes.",
                    "Warning",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    createManufacturerTabControlFinanceTabPageVATNumberTextBox.Text = string.Empty;
                }
                else
                {
                    createManufacturerTabControlFinanceTabPageVATRegisteredCheckBox.Checked = true;
                    createManufacturerTabControlFinanceTabPageVATNumberTextBox.Enabled = true;
                }
            }
        }

        private async void createManufacturerSubmitButton_Click(object sender, EventArgs e)
        {
            string? manufacturerFinanceVATNumber = TextBoxCleanerHelper.GetTrimmedText(createManufacturerTabControlFinanceTabPageVATNumberTextBox);
            bool manufacturerFinanceVATRegistered = createManufacturerTabControlFinanceTabPageVATRegisteredCheckBox.Checked;

            bool manufacturerOverviewActiveStatus = createManufacturerTabControlOverviewTabPageActiveStatusCheckBox.Checked;
            string manufacturerOverviewAddressLine1 = TextBoxCleanerHelper.GetTrimmedText(createManufacturerTabControlOverviewTabPageAddressLine1TextBox);
            string? manufacturerOverviewAddressLine2 = TextBoxCleanerHelper.GetTrimmedText(createManufacturerTabControlOverviewTabPageAddressLine2TextBox);
            string manufacturerOverviewAddressLine3 = TextBoxCleanerHelper.GetTrimmedText(createManufacturerTabControlOverviewTabPageAddressLine3TextBox);
            string manufacturerOverviewAddressLine4 = TextBoxCleanerHelper.GetTrimmedText(createManufacturerTabControlOverviewTabPageAddressLine4TextBox);
            Guid manufacturerOverviewAddressLine5 = (Guid)createManufacturerTabControlOverviewTabPageAddressLine5ComboBox.SelectedValue;
            string manufacturerOverviewManufacturerName = TextBoxCleanerHelper.GetTrimmedText(createManufacturerTabControlOverviewTabPageManufacturerNameTextBox);
            string manufacturerOverviewEmailAddress = TextBoxCleanerHelper.GetTrimmedText(createManufacturerTabControlOverviewTabPageEmailAddressTextBox);
            string manufacturerOverviewTelephoneNumber = TextBoxCleanerHelper.GetTrimmedText(createManufacturerTabControlOverviewTabPageTelephoneNumberTextBox);

            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            var dataToValidate = new List<DataValidationService.DataProperty>
            {
                new DataValidationService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Manufacturer Finance: VAT Number",
                    Value = manufacturerFinanceVATNumber,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Finance: VAT Registered",
                    Value = manufacturerFinanceVATRegistered,
                    ValueType = typeof(bool)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Overview: Active Status",
                    Value = manufacturerOverviewActiveStatus,
                    ValueType = typeof(bool)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Overview: Address Line 1",
                    Value = manufacturerOverviewAddressLine1,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Manufacturer Overview: Address Line 2",
                    Value = manufacturerOverviewAddressLine2,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Overview: Address Line 3",
                    Value = manufacturerOverviewAddressLine3,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Overview: Address Line 4",
                    Value = manufacturerOverviewAddressLine4,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Overview: Address Line 5",
                    Value = manufacturerOverviewAddressLine5,
                    ValueType = typeof(Guid)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Overview: Email Address",
                    Value = manufacturerOverviewEmailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Overview: Manufacturer Name",
                    Value = manufacturerOverviewManufacturerName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Overview: Telephone Number",
                    Value = manufacturerOverviewTelephoneNumber,
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
                        ParameterValue = manufacturerFinanceVATNumber
                    });
                }

                string storedProcedureName = "spCreateManufacturer";
                DataOperationType operationType = DataOperationType.Create;

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(dataSubject, _databaseConnectionSettings, operationType, storedProcedureName, parameters.ToArray()  );
                this.Close();
            }
        }
    }
}