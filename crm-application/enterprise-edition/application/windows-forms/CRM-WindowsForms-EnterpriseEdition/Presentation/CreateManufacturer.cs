using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateManufacturer : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Manufacturer";

        public CreateManufacturer()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadDatabaseConnectionSettingsAsync();
            LoadInitialDataAsync();
        }

        private void InitializeCustomComponents()
        {
            createManufacturerTabControlFinanceTabPageVATRegisteredCheckbox.CheckedChanged += new EventHandler(CreateManufacturerFinanceVATRegisteredCheckBox_CheckedChanged);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task LoadInitialDataAsync()
        {
            await LoadDatabaseConnectionSettingsAsync();
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
            string manufacturerOverviewAddressLine5 = createManufacturerTabControlOverviewTabPageAddressLine5Textbox.Text.TrimEnd();
            string manufacturerOverviewManufacturerName = createManufacturerTabControlOverviewTabPageManufacturerNameTextbox.Text.TrimEnd();
            string manufacturerOverviewEmailAddress = createManufacturerTabControlOverviewTabPageEmailAddressTextbox.Text.TrimEnd();
            string manufacturerOverviewTelephoneNumber = createManufacturerTabControlOverviewTabPageTelephoneNumberTextbox.Text.TrimEnd();

            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Database.ConnectionSettingsNotLoaded");
                return;
            }

            var dataToValidate = new List<ValidateDataInput.DataProperty>
            {
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerOverviewActiveStatus",
                    Value = manufacturerOverviewActiveStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerOverviewActiveStatus",
                    Value = manufacturerOverviewActiveStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerOverviewAddressLine1",
                    Value = manufacturerOverviewAddressLine1,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerOverviewAddressLine3",
                    Value = manufacturerOverviewAddressLine3,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerOverviewAddressLine4",
                    Value = manufacturerOverviewAddressLine4,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerOverviewAddressLine5",
                    Value = manufacturerOverviewAddressLine5,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerOverviewEmailAddress",
                    Value = manufacturerOverviewEmailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerOverviewManufacturerName",
                    Value = manufacturerOverviewManufacturerName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerOverviewTelephoneNumber",
                    Value = manufacturerOverviewTelephoneNumber,
                    MaxLength = 13,
                    ValueType = typeof(string)
                }
            };

            if (!string.IsNullOrEmpty(manufacturerOverviewAddressLine2))
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "ManufacturerOverviewAddressLine2",
                    Value = manufacturerOverviewAddressLine2,
                    MaxLength = 50,
                    ValueType = typeof(string)
                });
            }

            if (!string.IsNullOrEmpty(manufacturerFinanceVATNumber))
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "ManufacturerFinanceVATNumber",
                    Value = manufacturerFinanceVATNumber,
                    MaxLength = 50,
                    ValueType = typeof(string)
                });
            }

            dataToValidate = dataToValidate.OrderBy(change => change.Name).ToList();

            var validationResult = ValidateDataInput.ValidateInput(dataToValidate);

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
                        ParameterName = "@activeStatus",
                        ParameterValue = manufacturerOverviewActiveStatus
                    },
                    new Parameter
                    {
                        ParameterName = "@addressLine1",
                        ParameterValue = manufacturerOverviewAddressLine1
                    },
                    new Parameter
                    {
                        ParameterName = "@addressLine3",
                        ParameterValue = manufacturerOverviewAddressLine3
                    },
                    new Parameter
                    {
                        ParameterName = "@addressLine4",
                        ParameterValue = manufacturerOverviewAddressLine4
                    },
                    new Parameter
                    {
                        ParameterName = "@addressLine5",
                        ParameterValue = manufacturerOverviewAddressLine5
                    },
                    new Parameter
                    {
                        ParameterName = "@emailAddress",
                        ParameterValue = manufacturerOverviewEmailAddress
                    },
                    new Parameter
                    {
                        ParameterName = "@manufacturerName",
                        ParameterValue = manufacturerOverviewManufacturerName
                    },
                    new Parameter
                    {
                        ParameterName = "@telephoneNumber",
                        ParameterValue = manufacturerOverviewTelephoneNumber
                    },
                    new Parameter
                    {
                        ParameterName = "@vatNumber",
                        ParameterValue = manufacturerFinanceVATNumber
                    }
                };

                if (!string.IsNullOrEmpty(manufacturerOverviewAddressLine2))
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@addressLine2",
                        ParameterValue = manufacturerOverviewAddressLine2
                    });
                }

                string storedProcedureName = "[dbo].[spCreateManufacturer]";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters.ToArray(), dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                this.Close();
            }
        }
    }
}