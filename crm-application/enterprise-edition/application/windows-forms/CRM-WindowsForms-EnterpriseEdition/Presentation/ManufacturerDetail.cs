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
        private bool? manufacturerDetailOverviewActiveStatusOrginalValue;
        private string? manufacturerDetailOverviewAddressLine1OriginalValue;
        private string? manufacturerDetailOverviewAddressLine2OriginalValue;
        private string? manufacturerDetailOverviewAddressLine3OriginalValue;
        private string? manufacturerDetailOverviewAddressLine4OriginalValue;
        private string? manufacturerDetailOverviewAddressLine5OriginalValue;
        private string? manufacturerDetailOverviewEmailAddressOriginalValue;
        private string? manufacturerDetailOverviewManufacturerNameOriginalValue;
        private string? manufacturerDetailOverviewTelephoneNumberOriginalValue;

        public ManufacturerDetail(Guid manufacturerId)
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadDatabaseConnectionSettingsAsync();
            _manufacturerId = manufacturerId;
        }

        private void InitializeCustomComponents()
        {
            manufacturerDetailFinanceVATRegisteredCheckbox.CheckedChanged += new EventHandler(ManufacturerDetailFinanceVATRegisteredCheckbox_CheckedChanged);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void ManufacturerDetailManufacturerInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    manufacturerDetailFinanceVATNumberTextbox.Text = manufacturerDataRow["VAT Number"].ToString();
                    if (manufacturerDetailFinanceVATNumberTextbox.Text.Length > 0)
                    {
                        manufacturerDetailFinanceVATRegisteredCheckbox.Checked = true;
                    }
                    else
                    {
                        manufacturerDetailFinanceVATRegisteredCheckbox.Checked = false;
                    }
                    manufacturerDetailOverviewActiveStatusCheckbox.Checked = (bool)manufacturerDataRow["Active Status"];
                    manufacturerDetailOverviewAddressLine1Textbox.Text = manufacturerDataRow["Address Line 1"].ToString();
                    manufacturerDetailOverviewAddressLine2Textbox.Text = manufacturerDataRow["Address Line 2"].ToString();
                    manufacturerDetailOverviewAddressLine3Textbox.Text = manufacturerDataRow["Address Line 3"].ToString();
                    manufacturerDetailOverviewAddressLine4Textbox.Text = manufacturerDataRow["Address Line 4"].ToString();
                    manufacturerDetailOverviewAddressLine5Textbox.Text = manufacturerDataRow["Address Line 5"].ToString();
                    manufacturerDetailOverviewCreatedByTextbox.Text = manufacturerDataRow["Created By"].ToString();
                    manufacturerDetailOverviewCreatedTimestampTextbox.Text = manufacturerDataRow["Created Timestamp UTC"].ToString();
                    manufacturerDetailOverviewEmailAddressTextbox.Text = manufacturerDataRow["Email Address"].ToString();
                    manufacturerDetailOverviewLastUpdatedByTextbox.Text = manufacturerDataRow["Modified By"].ToString();
                    manufacturerDetailOverviewLastUpdatedTimestampTextbox.Text = manufacturerDataRow["Modified Timestamp UTC"].ToString();
                    manufacturerDetailOverviewManufacturerIdTextbox.Text = manufacturerDataRow["Manufacturer Id"].ToString();
                    manufacturerDetailOverviewManufacturerNameTextbox.Text = manufacturerDataRow["Manufacturer Name"].ToString();
                    manufacturerDetailOverviewTelephoneNumberTextbox.Text = manufacturerDataRow["Telephone Number"].ToString();

                    manufacturerDetailFinanceVATNumberOriginalValue = manufacturerDataRow["VAT Number"].ToString();
                    manufacturerDetailOverviewActiveStatusOrginalValue = (bool)manufacturerDataRow["Active Status"];
                    manufacturerDetailOverviewAddressLine1OriginalValue = manufacturerDataRow["Address Line 1"].ToString();
                    manufacturerDetailOverviewAddressLine2OriginalValue = manufacturerDataRow["Address Line 2"].ToString();
                    manufacturerDetailOverviewAddressLine3OriginalValue = manufacturerDataRow["Address Line 3"].ToString();
                    manufacturerDetailOverviewAddressLine4OriginalValue = manufacturerDataRow["Address Line 4"].ToString();
                    manufacturerDetailOverviewAddressLine5OriginalValue = manufacturerDataRow["Address Line 5"].ToString();
                    manufacturerDetailOverviewEmailAddressOriginalValue = manufacturerDataRow["Email Address"].ToString();
                    manufacturerDetailOverviewManufacturerNameOriginalValue = manufacturerDataRow["Manufacturer Name"].ToString();
                    manufacturerDetailOverviewTelephoneNumberOriginalValue = manufacturerDataRow["Telephone Number"].ToString();
                }
                else
                {
                    MessageBox.Show("No data found for the specified Manufacturer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Manufacturer details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManufacturerDetailFinanceVATRegisteredCheckbox_CheckedChanged(object? sender, EventArgs e)
        {
            if (!manufacturerDetailFinanceVATRegisteredCheckbox.Checked)
            {
                var result = MessageBox.Show(
                    "A VAT Number cannot be assigned if VAT Registered is false. Clicking OK will clear the VAT Number field. Clicking Cancel will reverse the changes.",
                    "Warning",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    manufacturerDetailFinanceVATNumberTextbox.Text = string.Empty;
                }
                else
                {
                    manufacturerDetailFinanceVATRegisteredCheckbox.Checked = true;
                }
            }
        }

        private async void ManufacturerDetailUpdateManufacturerButton_Click(object sender, EventArgs e)
        {
            string? manufacturerDetailFinanceVATNumber = manufacturerDetailFinanceVATNumberTextbox.Text.TrimEnd();

            bool manufacturerDetailOverviewActiveStatus = manufacturerDetailOverviewActiveStatusCheckbox.Checked;
            string manufacturerDetailOverviewAddressLine1 = manufacturerDetailOverviewAddressLine1Textbox.Text.TrimEnd();
            string? manufacturerDetailOverviewAddressLine2 = manufacturerDetailOverviewAddressLine2Textbox.Text.TrimEnd();
            string manufacturerDetailOverviewAddressLine3 = manufacturerDetailOverviewAddressLine3Textbox.Text.TrimEnd();
            string? manufacturerDetailOverviewAddressLine4 = manufacturerDetailOverviewAddressLine4Textbox.Text.TrimEnd();
            string manufacturerDetailOverviewAddressLine5 = manufacturerDetailOverviewAddressLine5Textbox.Text.TrimEnd();
            string manufacturerDetailOverviewEmailAddress = manufacturerDetailOverviewEmailAddressTextbox.Text.TrimEnd();
            string manufacturerDetailOverviewManufacturerName = manufacturerDetailOverviewManufacturerNameTextbox.Text.TrimEnd();
            string manufacturerDetailOverviewTelephoneNumber = manufacturerDetailOverviewTelephoneNumberTextbox.Text.TrimEnd();

            string dataSubject = "Manufacturer";

            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Value = manufacturerDetailOverviewActiveStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerDetailOverviewAddressLine1",
                    Value = manufacturerDetailOverviewAddressLine1,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerDetailOverviewAddressLine3",
                    Value = manufacturerDetailOverviewAddressLine3,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerDetailOverviewAddressLine4",
                    Value = manufacturerDetailOverviewAddressLine4,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerDetailOverviewAddressLine5",
                    Value = manufacturerDetailOverviewAddressLine5,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerDetailOverviewEmailAddress",
                    Value = manufacturerDetailOverviewEmailAddress,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerDetailOverviewManufacturerName",
                    Value = manufacturerDetailOverviewManufacturerName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ManufacturerDetailOverviewTelephoneNumber",
                    Value = manufacturerDetailOverviewTelephoneNumber,
                    ValueType = typeof(string)
                }
            };

            if (!string.IsNullOrEmpty(manufacturerDetailOverviewAddressLine2))
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    Name = "ManufacturerDetailOverviewAddressLine2",
                    Value = manufacturerDetailOverviewAddressLine2,
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
                        OriginalValue = manufacturerDetailOverviewActiveStatusOrginalValue,
                        NewValue = manufacturerDetailOverviewActiveStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Address Line 1",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailOverviewAddressLine1OriginalValue,
                        NewValue = manufacturerDetailOverviewAddressLine1
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Address Line 3",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailOverviewAddressLine3OriginalValue,
                        NewValue = manufacturerDetailOverviewAddressLine3
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Address Line 4",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailOverviewAddressLine4OriginalValue,
                        NewValue = manufacturerDetailOverviewAddressLine4
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Address Line 5",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailOverviewAddressLine5OriginalValue,
                        NewValue = manufacturerDetailOverviewAddressLine5
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Email Address",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailOverviewEmailAddressOriginalValue,
                        NewValue = manufacturerDetailOverviewEmailAddress
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Manufacturer Name",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailOverviewManufacturerNameOriginalValue,
                        NewValue = manufacturerDetailOverviewManufacturerName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Telephone Number",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailOverviewTelephoneNumberOriginalValue,
                        NewValue = manufacturerDetailOverviewTelephoneNumber
                    }
                };

                if (!string.IsNullOrEmpty(manufacturerDetailOverviewAddressLine2))
                {
                    changesList.Add(new ChangeDetail
                    {
                        VariableName = "Manufacturer Detail Overview: Address Line 2",
                        VariableType = "string",
                        OriginalValue = manufacturerDetailOverviewAddressLine2OriginalValue,
                        NewValue = manufacturerDetailOverviewAddressLine2
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
                            ParameterValue = manufacturerDetailOverviewActiveStatus
                        },
                        new Parameter
                        {
                            ParameterName = "@addressLine1",
                            ParameterValue = manufacturerDetailOverviewAddressLine1
                        },
                        new Parameter
                        {
                            ParameterName = "@addressLine3",
                            ParameterValue = manufacturerDetailOverviewAddressLine3
                        },
                        new Parameter
                        {
                            ParameterName = "@addressLine4",
                            ParameterValue = manufacturerDetailOverviewAddressLine4
                        },
                        new Parameter
                        {
                            ParameterName = "@addressLine5",
                            ParameterValue = manufacturerDetailOverviewAddressLine5
                        },
                        new Parameter
                        {
                            ParameterName = "@emailAddress",
                            ParameterValue = manufacturerDetailOverviewEmailAddress
                        },
                        new Parameter
                        {
                            ParameterName = "@manufacturerId",
                            ParameterValue = _manufacturerId
                        },
                        new Parameter
                        {
                            ParameterName = "@manufacturerName",
                            ParameterValue = manufacturerDetailOverviewManufacturerName
                        },
                        new Parameter
                        {
                            ParameterName = "@telephoneNumber",
                            ParameterValue = manufacturerDetailOverviewTelephoneNumber
                        },
                        new Parameter
                        {
                            ParameterName = "@vatNumber",
                            ParameterValue = manufacturerDetailFinanceVATNumber
                        }
                    };

                    if (!string.IsNullOrEmpty(manufacturerDetailOverviewAddressLine2))
                    {
                        parameters.Add(new Parameter
                        {
                            ParameterName = "@addressLine2",
                            ParameterValue = manufacturerDetailOverviewAddressLine2
                        });
                    }

                    string storedProcedureName = "[dbo].[spUpdateManufacturer]";
                    string operationType = "update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters.ToArray(), dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Updates were cancelled, no changes have been made to the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            manufacturerDetailOverviewCreatedByTextbox.ReadOnly = !manufacturerDetailOverviewCreatedByTextbox.ReadOnly;
            manufacturerDetailOverviewCreatedTimestampTextbox.ReadOnly = !manufacturerDetailOverviewCreatedTimestampTextbox.ReadOnly;
            manufacturerDetailFinanceVATNumberTextbox.ReadOnly = !manufacturerDetailFinanceVATNumberTextbox.ReadOnly;
            manufacturerDetailFinanceVATRegisteredCheckbox.Enabled = !manufacturerDetailFinanceVATRegisteredCheckbox.Enabled;
            manufacturerDetailOverviewLastUpdatedByTextbox.ReadOnly = !manufacturerDetailOverviewLastUpdatedByTextbox.ReadOnly;
            manufacturerDetailOverviewLastUpdatedByTextbox.ReadOnly = !manufacturerDetailOverviewLastUpdatedByTextbox.ReadOnly;
            manufacturerDetailOverviewActiveStatusCheckbox.Enabled = !manufacturerDetailOverviewActiveStatusCheckbox.Enabled;
            manufacturerDetailOverviewAddressLine1Textbox.ReadOnly = !manufacturerDetailOverviewAddressLine1Textbox.ReadOnly;
            manufacturerDetailOverviewAddressLine2Textbox.ReadOnly = !manufacturerDetailOverviewAddressLine2Textbox.ReadOnly;
            manufacturerDetailOverviewAddressLine3Textbox.ReadOnly = !manufacturerDetailOverviewAddressLine3Textbox.ReadOnly;
            manufacturerDetailOverviewAddressLine4Textbox.ReadOnly = !manufacturerDetailOverviewAddressLine4Textbox.ReadOnly;
            manufacturerDetailOverviewAddressLine5Textbox.ReadOnly = !manufacturerDetailOverviewAddressLine5Textbox.ReadOnly;
            manufacturerDetailOverviewEmailAddressTextbox.ReadOnly = !manufacturerDetailOverviewEmailAddressTextbox.ReadOnly;
            manufacturerDetailOverviewManufacturerIdTextbox.ReadOnly = !manufacturerDetailOverviewManufacturerIdTextbox.ReadOnly;
            manufacturerDetailOverviewManufacturerNameTextbox.ReadOnly = !manufacturerDetailOverviewManufacturerNameTextbox.ReadOnly;
            manufacturerDetailOverviewTelephoneNumberTextbox.ReadOnly = !manufacturerDetailOverviewTelephoneNumberTextbox.ReadOnly;
            manufacturerDetailUpdateManufacturerButton.Enabled = !manufacturerDetailUpdateManufacturerButton.Enabled;
        }

        private void manufacturerDetailManufacturerNotesCreateNewManufacturerNoteButton_Click(object sender, EventArgs e)
        {
            CreateNote createNote = new CreateNote(_manufacturerId, "ManufacturerNote");
            createNote.Show();
        }
    }
}