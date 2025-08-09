using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class ManufacturerDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _manufacturerId;
        private string? manufacturerDetailFinanceVATNumberOriginalValue;
        private bool? manufacturerDetailTabControlOverviewTabPageActiveStatusOrginalValue;
        private string? manufacturerDetailTabControlOverviewTabPageAddressLine1OriginalValue;
        private string? manufacturerDetailTabControlOverviewTabPageAddressLine2OriginalValue;
        private string? manufacturerDetailTabControlOverviewTabPageAddressLine3OriginalValue;
        private string? manufacturerDetailTabControlOverviewTabPageAddressLine4OriginalValue;
        private string? manufacturerDetailTabControlOverviewTabPageAddressLine5OriginalValue;
        private string? manufacturerDetailTabControlOverviewTabPageEmailAddressOriginalValue;
        private string? manufacturerDetailTabControlOverviewTabPageManufacturerNameOriginalValue;
        private string? manufacturerDetailTabControlOverviewTabPageTelephoneNumberOriginalValue;

        public ManufacturerDetail(Guid manufacturerId)
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadDatabaseConnectionSettingsAsync();
            _manufacturerId = manufacturerId;
        }

        private void InitializeCustomComponents()
        {
            manufacturerDetailTabControlFinanceTabPageVATRegisteredCheckbox.CheckedChanged += new EventHandler(ManufacturerDetailFinanceVATRegisteredCheckbox_CheckedChanged);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void ManufacturerDetailManufacturerInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            string storedProcedureName = "[dbo].[spGetManufacturer]";
            string dataSubject = "Manufacturer";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@manufacturerId",
                    ParameterValue = _manufacturerId
                }
            };
            try
            {
                DataTable? manufacturerDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (manufacturerDataTable != null)
                {
                    DataRow manufacturerDataRow = manufacturerDataTable.Rows[0];

                    Guid paymentCurrencyId = (Guid)manufacturerDataRow["Payment Currency Id"];
                    manufacturerDetailTabControlFinanceTabPageVATNumberTextbox.Text = manufacturerDataRow["VAT Number"].ToString();
                    if (manufacturerDetailTabControlFinanceTabPageVATNumberTextbox.Text.Length > 0)
                    {
                        manufacturerDetailTabControlFinanceTabPageVATRegisteredCheckbox.Checked = true;
                    }
                    else
                    {
                        manufacturerDetailTabControlFinanceTabPageVATRegisteredCheckbox.Checked = false;
                    }
                    manufacturerDetailTabControlOverviewTabPageActiveStatusCheckbox.Checked = (bool)manufacturerDataRow["Active Status"];
                    manufacturerDetailTabControlOverviewTabPageAddressLine1Textbox.Text = manufacturerDataRow["Address Line 1"].ToString();
                    manufacturerDetailTabControlOverviewTabPageAddressLine2Textbox.Text = manufacturerDataRow["Address Line 2"].ToString();
                    manufacturerDetailTabControlOverviewTabPageAddressLine3Textbox.Text = manufacturerDataRow["Address Line 3"].ToString();
                    manufacturerDetailTabControlOverviewTabPageAddressLine4Textbox.Text = manufacturerDataRow["Address Line 4"].ToString();
                    manufacturerDetailTabControlOverviewTabPageAddressLine5Textbox.Text = manufacturerDataRow["Address Line 5"].ToString();
                    manufacturerDetailTabControlOverviewTabPageCreatedByTextbox.Text = manufacturerDataRow["Created By"].ToString();
                    manufacturerDetailTabControlOverviewTabPageCreatedTimestampTextbox.Text = manufacturerDataRow["Created Timestamp UTC"].ToString();
                    manufacturerDetailTabControlOverviewTabPageEmailAddressTextbox.Text = manufacturerDataRow["Email Address"].ToString();
                    manufacturerDetailTabControlOverviewTabPageLastUpdatedByTextbox.Text = manufacturerDataRow["Modified By"].ToString();
                    manufacturerDetailTabControlOverviewTabPageLastUpdatedTimestampTextbox.Text = manufacturerDataRow["Modified Timestamp UTC"].ToString();
                    manufacturerDetailTabControlOverviewTabPageManufacturerIdTextbox.Text = manufacturerDataRow["Manufacturer Id"].ToString();
                    manufacturerDetailTabControlOverviewTabPageManufacturerNameTextbox.Text = manufacturerDataRow["Manufacturer Name"].ToString();
                    manufacturerDetailTabControlOverviewTabPageTelephoneNumberTextbox.Text = manufacturerDataRow["Telephone Number"].ToString();

                    manufacturerDetailFinanceVATNumberOriginalValue = manufacturerDataRow["VAT Number"].ToString();
                    manufacturerDetailTabControlOverviewTabPageActiveStatusOrginalValue = (bool)manufacturerDataRow["Active Status"];
                    manufacturerDetailTabControlOverviewTabPageAddressLine1OriginalValue = manufacturerDataRow["Address Line 1"].ToString();
                    manufacturerDetailTabControlOverviewTabPageAddressLine2OriginalValue = manufacturerDataRow["Address Line 2"].ToString();
                    manufacturerDetailTabControlOverviewTabPageAddressLine3OriginalValue = manufacturerDataRow["Address Line 3"].ToString();
                    manufacturerDetailTabControlOverviewTabPageAddressLine4OriginalValue = manufacturerDataRow["Address Line 4"].ToString();
                    manufacturerDetailTabControlOverviewTabPageAddressLine5OriginalValue = manufacturerDataRow["Address Line 5"].ToString();
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

        private void ManufacturerDetailFinanceVATRegisteredCheckbox_CheckedChanged(object? sender, EventArgs e)
        {
            if (!manufacturerDetailTabControlFinanceTabPageVATRegisteredCheckbox.Checked)
            {
                var result = MessageBox.Show(
                    "A VAT Number cannot be assigned if VAT Registered is false. Clicking OK will clear the VAT Number field. Clicking Cancel will reverse the changes.",
                    "Warning",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    manufacturerDetailTabControlFinanceTabPageVATNumberTextbox.Text = string.Empty;
                }
                else
                {
                    manufacturerDetailTabControlFinanceTabPageVATRegisteredCheckbox.Checked = true;
                }
            }
        }

        private async void ManufacturerDetailUpdateManufacturerButton_Click(object sender, EventArgs e)
        {
            string? manufacturerDetailFinanceVATNumber = manufacturerDetailTabControlFinanceTabPageVATNumberTextbox.Text.TrimEnd();

            bool manufacturerDetailTabControlOverviewTabPageActiveStatus = manufacturerDetailTabControlOverviewTabPageActiveStatusCheckbox.Checked;
            string manufacturerDetailTabControlOverviewTabPageAddressLine1 = manufacturerDetailTabControlOverviewTabPageAddressLine1Textbox.Text.TrimEnd();
            string? manufacturerDetailTabControlOverviewTabPageAddressLine2 = manufacturerDetailTabControlOverviewTabPageAddressLine2Textbox.Text.TrimEnd();
            string manufacturerDetailTabControlOverviewTabPageAddressLine3 = manufacturerDetailTabControlOverviewTabPageAddressLine3Textbox.Text.TrimEnd();
            string? manufacturerDetailTabControlOverviewTabPageAddressLine4 = manufacturerDetailTabControlOverviewTabPageAddressLine4Textbox.Text.TrimEnd();
            string manufacturerDetailTabControlOverviewTabPageAddressLine5 = manufacturerDetailTabControlOverviewTabPageAddressLine5Textbox.Text.TrimEnd();
            string manufacturerDetailTabControlOverviewTabPageEmailAddress = manufacturerDetailTabControlOverviewTabPageEmailAddressTextbox.Text.TrimEnd();
            string manufacturerDetailTabControlOverviewTabPageManufacturerName = manufacturerDetailTabControlOverviewTabPageManufacturerNameTextbox.Text.TrimEnd();
            string manufacturerDetailTabControlOverviewTabPageTelephoneNumber = manufacturerDetailTabControlOverviewTabPageTelephoneNumberTextbox.Text.TrimEnd();

            string dataSubject = "Manufacturer";

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
                    Name = "ManufacturerDetailFinanceVATNumber",
                    Value = manufacturerDetailFinanceVATNumber,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerDetailOverviewActiveStatus",
                    Value = manufacturerDetailTabControlOverviewTabPageActiveStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerDetailOverviewAddressLine1",
                    Value = manufacturerDetailTabControlOverviewTabPageAddressLine1,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerDetailOverviewAddressLine3",
                    Value = manufacturerDetailTabControlOverviewTabPageAddressLine3,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerDetailOverviewAddressLine4",
                    Value = manufacturerDetailTabControlOverviewTabPageAddressLine4,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerDetailOverviewAddressLine5",
                    Value = manufacturerDetailTabControlOverviewTabPageAddressLine5,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerDetailOverviewEmailAddress",
                    Value = manufacturerDetailTabControlOverviewTabPageEmailAddress,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerDetailOverviewManufacturerName",
                    Value = manufacturerDetailTabControlOverviewTabPageManufacturerName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerDetailOverviewTelephoneNumber",
                    Value = manufacturerDetailTabControlOverviewTabPageTelephoneNumber,
                    ValueType = typeof(string)
                }
            };

            if (!string.IsNullOrEmpty(manufacturerDetailTabControlOverviewTabPageAddressLine2))
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    Name = "ManufacturerDetailOverviewAddressLine2",
                    Value = manufacturerDetailTabControlOverviewTabPageAddressLine2,
                    MaxLength = 50
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
                var changesList = new List<ChangeDetail>
                {
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Finance: VAT Number",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailFinanceVATNumberOriginalValue,
                        NewValue = manufacturerDetailFinanceVATNumber
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Active Status",
                        VariableType = "bool",
                        OriginalValue = manufacturerDetailTabControlOverviewTabPageActiveStatusOrginalValue,
                        NewValue = manufacturerDetailTabControlOverviewTabPageActiveStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Address Line 1",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailTabControlOverviewTabPageAddressLine1OriginalValue,
                        NewValue = manufacturerDetailTabControlOverviewTabPageAddressLine1
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Address Line 3",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailTabControlOverviewTabPageAddressLine3OriginalValue,
                        NewValue = manufacturerDetailTabControlOverviewTabPageAddressLine3
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Address Line 4",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailTabControlOverviewTabPageAddressLine4OriginalValue,
                        NewValue = manufacturerDetailTabControlOverviewTabPageAddressLine4
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Address Line 5",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailTabControlOverviewTabPageAddressLine5OriginalValue,
                        NewValue = manufacturerDetailTabControlOverviewTabPageAddressLine5
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Email Address",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailTabControlOverviewTabPageEmailAddressOriginalValue,
                        NewValue = manufacturerDetailTabControlOverviewTabPageEmailAddress
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Manufacturer Name",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailTabControlOverviewTabPageManufacturerNameOriginalValue,
                        NewValue = manufacturerDetailTabControlOverviewTabPageManufacturerName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Telephone Number",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailTabControlOverviewTabPageTelephoneNumberOriginalValue,
                        NewValue = manufacturerDetailTabControlOverviewTabPageTelephoneNumber
                    }
                };

                if (!string.IsNullOrEmpty(manufacturerDetailTabControlOverviewTabPageAddressLine2))
                {
                    changesList.Add(new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Address Line 2",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailTabControlOverviewTabPageAddressLine2OriginalValue,
                        NewValue = manufacturerDetailTabControlOverviewTabPageAddressLine2
                    });
                }

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = UpdateConfirmation.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
                {
                    var parameters = new List<Parameter>
                    {
                        new Parameter
                        {
                            ParameterName = "@activeStatus",
                            ParameterValue = manufacturerDetailTabControlOverviewTabPageActiveStatus
                        },
                        new Parameter
                        {
                            ParameterName = "@addressLine1",
                            ParameterValue = manufacturerDetailTabControlOverviewTabPageAddressLine1
                        },
                        new Parameter
                        {
                            ParameterName = "@addressLine3",
                            ParameterValue = manufacturerDetailTabControlOverviewTabPageAddressLine3
                        },
                        new Parameter
                        {
                            ParameterName = "@addressLine4",
                            ParameterValue = manufacturerDetailTabControlOverviewTabPageAddressLine4
                        },
                        new Parameter
                        {
                            ParameterName = "@addressLine5",
                            ParameterValue = manufacturerDetailTabControlOverviewTabPageAddressLine5
                        },
                        new Parameter
                        {
                            ParameterName = "@emailAddress",
                            ParameterValue = manufacturerDetailTabControlOverviewTabPageEmailAddress
                        },
                        new Parameter
                        {
                            ParameterName = "@manufacturerId",
                            ParameterValue = _manufacturerId
                        },
                        new Parameter
                        {
                            ParameterName = "@manufacturerName",
                            ParameterValue = manufacturerDetailTabControlOverviewTabPageManufacturerName
                        },
                        new Parameter
                        {
                            ParameterName = "@telephoneNumber",
                            ParameterValue = manufacturerDetailTabControlOverviewTabPageTelephoneNumber
                        },
                        new Parameter
                        {
                            ParameterName = "@vatNumber",
                            ParameterValue = manufacturerDetailFinanceVATNumber
                        }
                    };

                    if (!string.IsNullOrEmpty(manufacturerDetailTabControlOverviewTabPageAddressLine2))
                    {
                        parameters.Add(new Parameter
                        {
                            ParameterName = "@addressLine2",
                            ParameterValue = manufacturerDetailTabControlOverviewTabPageAddressLine2
                        });
                    }

                    string storedProcedureName = "[dbo].[spUpdateManufacturer]";
                    string operationType = "update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters.ToArray(), dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
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
            manufacturerDetailTabControlOverviewTabPageCreatedByTextbox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageCreatedByTextbox.ReadOnly;
            manufacturerDetailTabControlOverviewTabPageCreatedTimestampTextbox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageCreatedTimestampTextbox.ReadOnly;
            manufacturerDetailTabControlFinanceTabPageVATNumberTextbox.ReadOnly = !manufacturerDetailTabControlFinanceTabPageVATNumberTextbox.ReadOnly;
            manufacturerDetailTabControlFinanceTabPageVATRegisteredCheckbox.Enabled = !manufacturerDetailTabControlFinanceTabPageVATRegisteredCheckbox.Enabled;
            manufacturerDetailTabControlOverviewTabPageLastUpdatedByTextbox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageLastUpdatedByTextbox.ReadOnly;
            manufacturerDetailTabControlOverviewTabPageLastUpdatedByTextbox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageLastUpdatedByTextbox.ReadOnly;
            manufacturerDetailTabControlOverviewTabPageActiveStatusCheckbox.Enabled = !manufacturerDetailTabControlOverviewTabPageActiveStatusCheckbox.Enabled;
            manufacturerDetailTabControlOverviewTabPageAddressLine1Textbox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageAddressLine1Textbox.ReadOnly;
            manufacturerDetailTabControlOverviewTabPageAddressLine2Textbox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageAddressLine2Textbox.ReadOnly;
            manufacturerDetailTabControlOverviewTabPageAddressLine3Textbox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageAddressLine3Textbox.ReadOnly;
            manufacturerDetailTabControlOverviewTabPageAddressLine4Textbox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageAddressLine4Textbox.ReadOnly;
            manufacturerDetailTabControlOverviewTabPageAddressLine5Textbox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageAddressLine5Textbox.ReadOnly;
            manufacturerDetailTabControlOverviewTabPageEmailAddressTextbox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageEmailAddressTextbox.ReadOnly;
            manufacturerDetailTabControlOverviewTabPageManufacturerIdTextbox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageManufacturerIdTextbox.ReadOnly;
            manufacturerDetailTabControlOverviewTabPageManufacturerNameTextbox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageManufacturerNameTextbox.ReadOnly;
            manufacturerDetailTabControlOverviewTabPageTelephoneNumberTextbox.ReadOnly = !manufacturerDetailTabControlOverviewTabPageTelephoneNumberTextbox.ReadOnly;
            manufacturerDetailUpdateManufacturerButton.Enabled = !manufacturerDetailUpdateManufacturerButton.Enabled;
        }

        private void manufacturerDetailManufacturerNotesCreateNewManufacturerNoteButton_Click(object sender, EventArgs e)
        {
            CreateNote createNote = new CreateNote(_manufacturerId, "ManufacturerNote");
            createNote.Show();
        }
    }
}