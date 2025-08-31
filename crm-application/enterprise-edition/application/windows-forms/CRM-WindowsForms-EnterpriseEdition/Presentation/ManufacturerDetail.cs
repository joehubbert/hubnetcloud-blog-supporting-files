using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class ManufacturerDetail : Form
    {
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _manufacturerId;
        private string? manufacturerDetailTabControlFinanceTabPageFinanceVATNumberOriginalValue;
        private bool manufacturerDetailTabControlFinanceTabPageFinanceVATRegisteredOriginalValue;
        private bool? manufacturerDetailTabControlOverviewTabPageActiveStatusOrginalValue;
        private string manufacturerDetailTabControlOverviewTabPageAddressLine1OriginalValue;
        private string? manufacturerDetailTabControlOverviewTabPageAddressLine2OriginalValue;
        private string manufacturerDetailTabControlOverviewTabPageAddressLine3OriginalValue;
        private string manufacturerDetailTabControlOverviewTabPageAddressLine4OriginalValue;
        private Guid manufacturerDetailTabControlOverviewTabPageAddressLine5OriginalValue;
        private string manufacturerDetailTabControlOverviewTabPageEmailAddressOriginalValue;
        private string manufacturerDetailTabControlOverviewTabPageManufacturerNameOriginalValue;
        private string manufacturerDetailTabControlOverviewTabPageTelephoneNumberOriginalValue;

        public ManufacturerDetail(Guid manufacturerId)
        {
            InitializeComponent();
            InitializeEventHandlers();
            LoadDatabaseConnectionSettingsAsync();
            _manufacturerId = manufacturerId;
        }

        private void InitializeEventHandlers()
        {
            manufacturerDetailTabControlFinanceTabPageVATRegisteredCheckBox.CheckedChanged += ManufacturerDetailFinanceVATRegisteredCheckBox_CheckedChanged;
            manufacturerDetailTabControlOverviewTabPageAddressLine5ComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            manufacturerDetailToggleEditModeButton.Click += ManufacturerDetailToggleEditModeButton_Click;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task LoadCountryDataAsync(Guid countryId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(manufacturerDetailTabControlOverviewTabPageAddressLine5ComboBox, "spGetAllCountry", null, true, "Country Id", countryId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async void ManufacturerDetailManufacturerInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            string storedProcedureName = "spGetManufacturer";
            string dataSubject = "Manufacturer";

            var parameters = new[]
            {
                new StoredProcedureParameter
                {
                    ParameterName = "manufacturerId",
                    ParameterValue = _manufacturerId
                }
            };
            try
            {
                DataTable? manufacturerDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject);

                if (manufacturerDataTable != null)
                {
                    DataRow manufacturerDataRow = manufacturerDataTable.Rows[0];

                    Guid paymentCurrencyId = (Guid)manufacturerDataRow["Payment Currency Id"];
                    manufacturerDetailTabControlFinanceTabPageVATNumberTextBox.Text = manufacturerDataRow["VAT Number"].ToString();
                    manufacturerDetailTabControlFinanceTabPageVATRegisteredCheckBox.Checked = (bool)manufacturerDataRow["VAT Registered"];

                    manufacturerDetailTabControlOverviewTabPageActiveStatusCheckBox.Checked = (bool)manufacturerDataRow["Active Status"];
                    manufacturerDetailTabControlOverviewTabPageAddressLine1TextBox.Text = manufacturerDataRow["Address Line 1"].ToString();
                    manufacturerDetailTabControlOverviewTabPageAddressLine2TextBox.Text = manufacturerDataRow["Address Line 2"].ToString();
                    manufacturerDetailTabControlOverviewTabPageAddressLine3TextBox.Text = manufacturerDataRow["Address Line 3"].ToString();
                    manufacturerDetailTabControlOverviewTabPageAddressLine4TextBox.Text = manufacturerDataRow["Address Line 4"].ToString();
                    Guid manufacturerAddressLine5 = (Guid)manufacturerDataRow["Address Line 5"];
                    await LoadCountryDataAsync(manufacturerAddressLine5);
                    manufacturerDetailTabControlOverviewTabPageCreatedByTextBox.Text = manufacturerDataRow["Created By"].ToString();
                    manufacturerDetailTabControlOverviewTabPageCreatedTimestampTextBox.Text = manufacturerDataRow["Created Timestamp UTC"].ToString();
                    manufacturerDetailTabControlOverviewTabPageEmailAddressTextBox.Text = manufacturerDataRow["Email Address"].ToString();
                    manufacturerDetailTabControlOverviewTabPageLastUpdatedByTextBox.Text = manufacturerDataRow["Modified By"].ToString();
                    manufacturerDetailTabControlOverviewTabPageLastUpdatedTimestampTextBox.Text = manufacturerDataRow["Modified Timestamp UTC"].ToString();
                    manufacturerDetailTabControlOverviewTabPageManufacturerIdTextBox.Text = manufacturerDataRow["Manufacturer Id"].ToString();
                    manufacturerDetailTabControlOverviewTabPageManufacturerNameTextBox.Text = manufacturerDataRow["Manufacturer Name"].ToString();
                    manufacturerDetailTabControlOverviewTabPageTelephoneNumberTextBox.Text = manufacturerDataRow["Telephone Number"].ToString();

                    manufacturerDetailTabControlFinanceTabPageFinanceVATNumberOriginalValue = manufacturerDataRow["VAT Number"].ToString();
                    manufacturerDetailTabControlFinanceTabPageFinanceVATRegisteredOriginalValue = (bool)manufacturerDataRow["VAT Registered"];
                    manufacturerDetailTabControlOverviewTabPageActiveStatusOrginalValue = (bool)manufacturerDataRow["Active Status"];
                    manufacturerDetailTabControlOverviewTabPageAddressLine1OriginalValue = manufacturerDataRow["Address Line 1"].ToString();
                    manufacturerDetailTabControlOverviewTabPageAddressLine2OriginalValue = manufacturerDataRow["Address Line 2"].ToString();
                    manufacturerDetailTabControlOverviewTabPageAddressLine3OriginalValue = manufacturerDataRow["Address Line 3"].ToString();
                    manufacturerDetailTabControlOverviewTabPageAddressLine4OriginalValue = manufacturerDataRow["Address Line 4"].ToString();
                    manufacturerDetailTabControlOverviewTabPageAddressLine5OriginalValue = (Guid)manufacturerDataRow["Address Line 5"];
                    manufacturerDetailTabControlOverviewTabPageEmailAddressOriginalValue = manufacturerDataRow["Email Address"].ToString();
                    manufacturerDetailTabControlOverviewTabPageManufacturerNameOriginalValue = manufacturerDataRow["Manufacturer Name"].ToString();
                    manufacturerDetailTabControlOverviewTabPageTelephoneNumberOriginalValue = manufacturerDataRow["Telephone Number"].ToString();

                    this.Text += $" ({manufacturerDetailTabControlOverviewTabPageManufacturerNameOriginalValue})";
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

        private void ManufacturerDetailFinanceVATRegisteredCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (!manufacturerDetailTabControlFinanceTabPageVATRegisteredCheckBox.Checked)
            {
                var result = MessageBox.Show(
                    "A VAT Number cannot be assigned if VAT Registered is false. Clicking OK will clear the VAT Number field. Clicking Cancel will reverse the changes.",
                    "Warning",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    manufacturerDetailTabControlFinanceTabPageVATNumberTextBox.Text = string.Empty;
                }
                else
                {
                    manufacturerDetailTabControlFinanceTabPageVATRegisteredCheckBox.Checked = true;
                }
            }
        }

        private async void manufacturerDetailUpdateManufacturerButton_Click(object sender, EventArgs e)
        {
            string? manufacturerDetailFinanceVATNumber = manufacturerDetailTabControlFinanceTabPageVATNumberTextBox.Text.TrimEnd();
            bool manufacturerDetailFinanceVATRegistered = manufacturerDetailTabControlFinanceTabPageVATRegisteredCheckBox.Checked;

            bool manufacturerDetailOverviewActiveStatus = manufacturerDetailTabControlOverviewTabPageActiveStatusCheckBox.Checked;
            string manufacturerDetailOverviewAddressLine1 = manufacturerDetailTabControlOverviewTabPageAddressLine1TextBox.Text.TrimEnd();
            string? manufacturerDetailOverviewAddressLine2 = manufacturerDetailTabControlOverviewTabPageAddressLine2TextBox.Text.TrimEnd();
            string manufacturerDetailOverviewAddressLine3 = manufacturerDetailTabControlOverviewTabPageAddressLine3TextBox.Text.TrimEnd();
            string? manufacturerDetailOverviewAddressLine4 = manufacturerDetailTabControlOverviewTabPageAddressLine4TextBox.Text.TrimEnd();
            Guid manufacturerDetailOverviewAddressLine5 = Guid.Parse(manufacturerDetailTabControlOverviewTabPageAddressLine5ComboBox.SelectedValue.ToString());
            string manufacturerDetailOverviewEmailAddress = manufacturerDetailTabControlOverviewTabPageEmailAddressTextBox.Text.TrimEnd();
            string manufacturerDetailOverviewManufacturerName = manufacturerDetailTabControlOverviewTabPageManufacturerNameTextBox.Text.TrimEnd();
            string manufacturerDetailOverviewTelephoneNumber = manufacturerDetailTabControlOverviewTabPageTelephoneNumberTextBox.Text.TrimEnd();

            string dataSubject = "Manufacturer";

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
                    Name = "Manufacturer Detail Finance: VAT Number",
                    Value = manufacturerDetailFinanceVATNumber,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Detail Finance: VAT Registered",
                    Value = manufacturerDetailFinanceVATRegistered,
                    ValueType = typeof(bool)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Detail Overview: Active Status",
                    Value = manufacturerDetailOverviewActiveStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Detail Overview: Address Line 1",
                    Value = manufacturerDetailOverviewAddressLine1,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Manufacturer Detail Overview: Address Line 2",
                    Value = manufacturerDetailOverviewAddressLine2,
                    MaxLength = 50
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Detail Overview: Address Line 3",
                    Value = manufacturerDetailOverviewAddressLine3,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Detail Overview: Address Line 4",
                    Value = manufacturerDetailOverviewAddressLine4,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Detail Overview: Address Line 5",
                    Value = manufacturerDetailOverviewAddressLine5,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Detail Overview: Email Address",
                    Value = manufacturerDetailOverviewEmailAddress,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Detail Overview: Manufacturer Name",
                    Value = manufacturerDetailOverviewManufacturerName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Manufacturer Detail Overview: Telephone Number",
                    Value = manufacturerDetailOverviewTelephoneNumber,
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
                var changesList = new List<ChangeDetail>
                {
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Finance: VAT Number",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailTabControlFinanceTabPageFinanceVATNumberOriginalValue,
                        NewValue = manufacturerDetailFinanceVATNumber
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Finance: VAT Registered",
                        VariableType = "bool",
                        OriginalValue = manufacturerDetailTabControlFinanceTabPageFinanceVATNumberOriginalValue,
                        NewValue = manufacturerDetailFinanceVATRegistered
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Active Status",
                        VariableType = "bool",
                        OriginalValue = manufacturerDetailTabControlOverviewTabPageActiveStatusOrginalValue,
                        NewValue = manufacturerDetailOverviewActiveStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Address Line 1",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailTabControlOverviewTabPageAddressLine1OriginalValue,
                        NewValue = manufacturerDetailOverviewAddressLine1
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Address Line 3",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailTabControlOverviewTabPageAddressLine3OriginalValue,
                        NewValue = manufacturerDetailOverviewAddressLine3
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Address Line 4",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailTabControlOverviewTabPageAddressLine4OriginalValue,
                        NewValue = manufacturerDetailOverviewAddressLine4
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Address Line 5",
                        VariableType = "Guid",
                        OriginalValue = manufacturerDetailTabControlOverviewTabPageAddressLine5OriginalValue,
                        NewValue = manufacturerDetailOverviewAddressLine5
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Email Address",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailTabControlOverviewTabPageEmailAddressOriginalValue,
                        NewValue = manufacturerDetailOverviewEmailAddress
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Manufacturer Name",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailTabControlOverviewTabPageManufacturerNameOriginalValue,
                        NewValue = manufacturerDetailOverviewManufacturerName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Telephone Number",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailTabControlOverviewTabPageTelephoneNumberOriginalValue,
                        NewValue = manufacturerDetailOverviewTelephoneNumber
                    }
                };

                if (!string.IsNullOrEmpty(manufacturerDetailOverviewAddressLine2))
                {
                    changesList.Add(new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Address Line 2",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailTabControlOverviewTabPageAddressLine2OriginalValue,
                        NewValue = manufacturerDetailOverviewAddressLine2
                    });
                }

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = UpdateConfirmationService.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
                {
                    var parameters = new List<StoredProcedureParameter>
                    {
                        new StoredProcedureParameter
                        {
                            ParameterName = "activeStatus",
                            ParameterValue = manufacturerDetailOverviewActiveStatus
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "addressLine1",
                            ParameterValue = manufacturerDetailOverviewAddressLine1
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "addressLine3",
                            ParameterValue = manufacturerDetailOverviewAddressLine3
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "addressLine4",
                            ParameterValue = manufacturerDetailOverviewAddressLine4
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "addressLine5",
                            ParameterValue = manufacturerDetailOverviewAddressLine5
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "emailAddress",
                            ParameterValue = manufacturerDetailOverviewEmailAddress
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "manufacturerId",
                            ParameterValue = _manufacturerId
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "manufacturerName",
                            ParameterValue = manufacturerDetailOverviewManufacturerName
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "telephoneNumber",
                            ParameterValue = manufacturerDetailOverviewTelephoneNumber
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "vatNumber",
                            ParameterValue = manufacturerDetailFinanceVATNumber
                        }
                    };

                    if (!string.IsNullOrEmpty(manufacturerDetailOverviewAddressLine2))
                    {
                        parameters.Add(new StoredProcedureParameter
                        {
                            ParameterName = "addressLine2",
                            ParameterValue = manufacturerDetailOverviewAddressLine2
                        });
                    }

                    if (!string.IsNullOrEmpty(manufacturerDetailFinanceVATNumber))
                    {
                        parameters.Add(new StoredProcedureParameter
                        {
                            ParameterName = "vatNumber",
                            ParameterValue = manufacturerDetailFinanceVATNumber
                        });
                    }

                    string storedProcedureName = "spUpdateManufacturer";
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
            ManufacturerDetailManufacturerInformation_Load(this, EventArgs.Empty);
        }

        private void ManufacturerDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            manufacturerDetailTabControlOverviewTabPageCreatedByTextBox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageCreatedByTextBox.ReadOnly;
            manufacturerDetailTabControlOverviewTabPageCreatedTimestampTextBox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageCreatedTimestampTextBox.ReadOnly;
            manufacturerDetailTabControlFinanceTabPageVATNumberTextBox.ReadOnly = !manufacturerDetailTabControlFinanceTabPageVATNumberTextBox.ReadOnly;
            manufacturerDetailTabControlFinanceTabPageVATRegisteredCheckBox.Enabled = !manufacturerDetailTabControlFinanceTabPageVATRegisteredCheckBox.Enabled;
            manufacturerDetailTabControlOverviewTabPageLastUpdatedByTextBox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageLastUpdatedByTextBox.ReadOnly;
            manufacturerDetailTabControlOverviewTabPageLastUpdatedByTextBox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageLastUpdatedByTextBox.ReadOnly;
            manufacturerDetailTabControlOverviewTabPageActiveStatusCheckBox.Enabled = !manufacturerDetailTabControlOverviewTabPageActiveStatusCheckBox.Enabled;
            manufacturerDetailTabControlOverviewTabPageAddressLine1TextBox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageAddressLine1TextBox.ReadOnly;
            manufacturerDetailTabControlOverviewTabPageAddressLine2TextBox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageAddressLine2TextBox.ReadOnly;
            manufacturerDetailTabControlOverviewTabPageAddressLine3TextBox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageAddressLine3TextBox.ReadOnly;
            manufacturerDetailTabControlOverviewTabPageAddressLine4TextBox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageAddressLine4TextBox.ReadOnly;
            manufacturerDetailTabControlOverviewTabPageAddressLine5ComboBox.Enabled = !manufacturerDetailTabControlOverviewTabPageAddressLine5ComboBox.Enabled;
            manufacturerDetailTabControlOverviewTabPageEmailAddressTextBox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageEmailAddressTextBox.ReadOnly;
            manufacturerDetailTabControlOverviewTabPageManufacturerIdTextBox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageManufacturerIdTextBox.ReadOnly;
            manufacturerDetailTabControlOverviewTabPageManufacturerNameTextBox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageManufacturerNameTextBox.ReadOnly;
            manufacturerDetailTabControlOverviewTabPageTelephoneNumberTextBox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageTelephoneNumberTextBox.ReadOnly;
            manufacturerDetailUpdateManufacturerButton.Enabled = !manufacturerDetailUpdateManufacturerButton.Enabled;
        }

        private void manufacturerDetailManufacturerNotesCreateNewManufacturerNoteButton_Click(object sender, EventArgs e)
        {
            CreateNote createNote = new CreateNote(_manufacturerId, "ManufacturerNote");
            createNote.Show();
        }
    }
}