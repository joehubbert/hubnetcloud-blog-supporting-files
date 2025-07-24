using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class SupplierDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _supplierId;
        private string? supplierDetailFinancePaymentDaysOriginalValue;
        private Guid? supplierDetailFinancePaymentCurrencyIdOriginalValue;
        private string? supplierDetailFinanceVATNumberOriginalValue;
        private bool? supplierDetailOverviewActiveStatusOrginalValue;
        private string? supplierDetailOverviewAddressLine1OriginalValue;
        private string? supplierDetailOverviewAddressLine2OriginalValue;
        private string? supplierDetailOverviewAddressLine3OriginalValue;
        private string? supplierDetailOverviewAddressLine4OriginalValue;
        private string? supplierDetailOverviewAddressLine5OriginalValue;
        private string? supplierDetailOverviewEmailAddressOriginalValue;
        private string? supplierDetailOverviewSupplierNameOriginalValue;
        private string? supplierDetailOverviewTelephoneNumberOriginalValue;

        public SupplierDetail(Guid supplierId)
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadDatabaseConnectionSettingsAsync();
            _supplierId = supplierId;
        }

        private void InitializeCustomComponents()
        {
            supplierDetailFinanceVATRegisteredCheckbox.CheckedChanged += new EventHandler(SupplierDetailFinanceVATRegisteredCheckbox_CheckedChanged);
            supplierDetailTabControl.SelectedIndexChanged += new EventHandler(SupplierDetailTabControl_SelectedIndexChanged);
            supplierDetailSupplierNoteExistingSupplierNoteDataGridView.CellContentClick += supplierDetailSupplierNoteExistingSupplierNoteDataGridView_CellContentClick;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task SupplierDetailFinanceLoadCurrencyDataAsync(Guid paymentCurrencyId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            try
            {
                string storedProcedureName = "[dbo].[spGetAllCurrency]";
                string dataSubject = "Currency";
                DataTable? currencyData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var currencyList = currencyData.AsEnumerable()
                    .Select(row => new
                    {
                        CurrencyId = row.Field<Guid>("Currency Id"),
                        CurrencyCode = row.Field<string>("Currency Code"),
                        CurrencyName = row.Field<string>("Currency Name"),
                        DisplayText = $"{row.Field<string>("Currency Code")} - {row.Field<string>("Currency Name")}"
                    })
                    .OrderBy(item => item.DisplayText)
                    .ToList();

                supplierDetailFinancePaymentCurrencyComboBox.DataSource = currencyList;
                supplierDetailFinancePaymentCurrencyComboBox.DisplayMember = "DisplayText";
                supplierDetailFinancePaymentCurrencyComboBox.ValueMember = "CurrencyId";
                supplierDetailFinancePaymentCurrencyComboBox.SelectedValue = paymentCurrencyId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Currency data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void SupplierDetailSupplierInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string storedProcedureName = "[dbo].[spGetSupplier]";
            string dataSubject = "Supplier";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@supplierId",
                    ParameterValue = _supplierId
                }
            };
            try
            {
                DataTable? supplierDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (supplierDataTable != null)
                {
                    DataRow supplierDataRow = supplierDataTable.Rows[0];

                    Guid paymentCurrencyId = (Guid)supplierDataRow["Payment Currency Id"];
                    await SupplierDetailFinanceLoadCurrencyDataAsync(paymentCurrencyId);
                    supplierDetailFinancePaymentDaysTextbox.Text = supplierDataRow["Payment Days"].ToString();
                    supplierDetailFinanceVATNumberTextbox.Text = supplierDataRow["VAT Number"].ToString();
                    if (supplierDetailFinanceVATNumberTextbox.Text.Length > 0)
                    {
                        supplierDetailFinanceVATRegisteredCheckbox.Checked = true;
                    }
                    else
                    {
                        supplierDetailFinanceVATRegisteredCheckbox.Checked = false;
                    }
                    supplierDetailOverviewActiveStatusCheckbox.Checked = (bool)supplierDataRow["Active Status"];
                    supplierDetailOverviewAddressLine1Textbox.Text = supplierDataRow["Address Line 1"].ToString();
                    supplierDetailOverviewAddressLine2Textbox.Text = supplierDataRow["Address Line 2"].ToString();
                    supplierDetailOverviewAddressLine3Textbox.Text = supplierDataRow["Address Line 3"].ToString();
                    supplierDetailOverviewAddressLine4Textbox.Text = supplierDataRow["Address Line 4"].ToString();
                    supplierDetailOverviewAddressLine5Textbox.Text = supplierDataRow["Address Line 5"].ToString();
                    supplierDetailOverviewCreatedByTextbox.Text = supplierDataRow["Created By"].ToString();
                    supplierDetailOverviewCreatedTimestampTextbox.Text = supplierDataRow["Created Timestamp UTC"].ToString();
                    supplierDetailOverviewEmailAddressTextbox.Text = supplierDataRow["Email Address"].ToString();
                    supplierDetailOverviewLastUpdatedByTextbox.Text = supplierDataRow["Modified By"].ToString();
                    supplierDetailOverviewLastUpdatedTimestampTextbox.Text = supplierDataRow["Modified Timestamp UTC"].ToString();
                    supplierDetailOverviewSupplierIdTextbox.Text = supplierDataRow["Supplier Id"].ToString();
                    supplierDetailOverviewSupplierNameTextbox.Text = supplierDataRow["Supplier Name"].ToString();
                    supplierDetailOverviewTelephoneNumberTextbox.Text = supplierDataRow["Telephone Number"].ToString();

                    supplierDetailFinancePaymentCurrencyIdOriginalValue = paymentCurrencyId;
                    supplierDetailFinancePaymentDaysOriginalValue = supplierDataRow["Payment Days"].ToString();
                    supplierDetailFinanceVATNumberOriginalValue = supplierDataRow["VAT Number"].ToString();
                    supplierDetailOverviewActiveStatusOrginalValue = (bool)supplierDataRow["Active Status"];
                    supplierDetailOverviewAddressLine1OriginalValue = supplierDataRow["Address Line 1"].ToString();
                    supplierDetailOverviewAddressLine2OriginalValue = supplierDataRow["Address Line 2"].ToString();
                    supplierDetailOverviewAddressLine3OriginalValue = supplierDataRow["Address Line 3"].ToString();
                    supplierDetailOverviewAddressLine4OriginalValue = supplierDataRow["Address Line 4"].ToString();
                    supplierDetailOverviewAddressLine5OriginalValue = supplierDataRow["Address Line 5"].ToString();
                    supplierDetailOverviewEmailAddressOriginalValue = supplierDataRow["Email Address"].ToString();
                    supplierDetailOverviewSupplierNameOriginalValue = supplierDataRow["Supplier Name"].ToString();
                    supplierDetailOverviewTelephoneNumberOriginalValue = supplierDataRow["Telephone Number"].ToString();
                }
                else
                {
                    MessageBox.Show("No data found for the specified Supplier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Supplier details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void SupplierDetailTabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (supplierDetailTabControl.SelectedTab == supplierDetailTabControl.TabPages["supplierDetailTabControlSupplierNotesPage"])
            {
                await SupplierDetailExistingSupplierNote_Load(sender, e);
            }
        }

        private async Task SupplierDetailExistingSupplierContact_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string storedProcedureName = "[dbo].[spGetAllSupplierContactForSupplier]";
            string dataSubject = "Existing Supplier Contacts";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@supplierId",
                    ParameterValue = _supplierId
                }
            };

            DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No Existing Supplier Contacts found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataTable.DefaultView.Sort = "Created Timestamp DESC";
                supplierDetailSupplierContactExistingSupplierContactDataGridView.AutoGenerateColumns = true;
                supplierDetailSupplierContactExistingSupplierContactDataGridView.DataSource = dataTable;
                supplierDetailSupplierContactExistingSupplierContactDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if (supplierDetailSupplierContactExistingSupplierContactDataGridView.Columns.Contains("Details"))
                {
                    supplierDetailSupplierContactExistingSupplierContactDataGridView.Columns.Remove("Details");
                }
                DataGridViewLinkColumn supplierContactDetailLink = new DataGridViewLinkColumn
                {
                    HeaderText = "Details",
                    Text = "View Supplier Contact",
                    UseColumnTextForLinkValue = true,
                    Name = "Details"
                };
                supplierDetailSupplierContactExistingSupplierContactDataGridView.Columns.Add(supplierContactDetailLink);
            }
        }

        private async Task SupplierDetailExistingSupplierNote_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string storedProcedureName = "[dbo].[spGetAllNoteForSupplier]";
            string dataSubject = "Existing Supplier Notes";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@supplierId",
                    ParameterValue = _supplierId
                }
            };

            DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No Existing Supplier Notes found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataTable.DefaultView.Sort = "Created Timestamp DESC";
                supplierDetailSupplierNoteExistingSupplierNoteDataGridView.AutoGenerateColumns = true;
                supplierDetailSupplierNoteExistingSupplierNoteDataGridView.DataSource = dataTable;
                supplierDetailSupplierNoteExistingSupplierNoteDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if (supplierDetailSupplierNoteExistingSupplierNoteDataGridView.Columns.Contains("Details"))
                {
                    supplierDetailSupplierNoteExistingSupplierNoteDataGridView.Columns.Remove("Details");
                }
                DataGridViewLinkColumn supplierNoteDetailLink = new DataGridViewLinkColumn
                {
                    HeaderText = "Details",
                    Text = "View Supplier Note",
                    UseColumnTextForLinkValue = true,
                    Name = "Details"
                };
                supplierDetailSupplierNoteExistingSupplierNoteDataGridView.Columns.Add(supplierNoteDetailLink);
            }
        }

        private void SupplierDetailFinanceVATRegisteredCheckbox_CheckedChanged(object? sender, EventArgs e)
        {
            if (!supplierDetailFinanceVATRegisteredCheckbox.Checked)
            {
                var result = MessageBox.Show(
                    "A VAT Number cannot be assigned if VAT Registered is false. Clicking OK will clear the VAT Number field. Clicking Cancel will reverse the changes.",
                    "Warning",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    supplierDetailFinanceVATNumberTextbox.Text = string.Empty;
                }
                else
                {
                    supplierDetailFinanceVATRegisteredCheckbox.Checked = true;
                }
            }
        }

        private void supplierDetailSupplierContactExistingSupplierContactDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == supplierDetailSupplierContactExistingSupplierContactDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (supplierDetailSupplierContactExistingSupplierContactDataGridView.Columns.Contains("Supplier Contact Id"))
                    {
                        Guid supplierContactId = (Guid)supplierDetailSupplierContactExistingSupplierContactDataGridView.Rows[e.RowIndex].Cells["Supplier Contact Id"].Value;
                        ContactDetail contactDetail = new ContactDetail("Supplier", supplierContactId);
                        contactDetail.Show();
                    }
                    else
                    {
                        MessageBox.Show("Supplier Contact Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open Supplier Contact details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void supplierDetailSupplierNoteExistingSupplierNoteDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == supplierDetailSupplierNoteExistingSupplierNoteDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (supplierDetailSupplierNoteExistingSupplierNoteDataGridView.Columns.Contains("Supplier Note Id"))
                    {
                        Guid supplierNoteId = (Guid)supplierDetailSupplierNoteExistingSupplierNoteDataGridView.Rows[e.RowIndex].Cells["Supplier Note Id"].Value;
                        NoteDetail noteDetail = new NoteDetail("Supplier", supplierNoteId);
                        noteDetail.Show();
                    }
                    else
                    {
                        MessageBox.Show("Supplier Note Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open Supplier Note details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void supplierDetailUpdateSupplierButton_Click(object sender, EventArgs e)
        {
            Guid supplierDetailFinancePaymentCurrencyId = (Guid)supplierDetailFinancePaymentCurrencyComboBox.SelectedValue;
            byte supplierDetailFinancePaymentDays = byte.Parse(supplierDetailFinancePaymentDaysTextbox.Text.TrimEnd());
            string? supplierDetailFinanceVATNumber = supplierDetailFinanceVATNumberTextbox.Text.TrimEnd();

            bool supplierDetailOverviewActiveStatus = supplierDetailOverviewActiveStatusCheckbox.Checked;
            string supplierDetailOverviewAddressLine1 = supplierDetailOverviewAddressLine1Textbox.Text.TrimEnd();
            string? supplierDetailOverviewAddressLine2 = supplierDetailOverviewAddressLine2Textbox.Text.TrimEnd();
            string supplierDetailOverviewAddressLine3 = supplierDetailOverviewAddressLine3Textbox.Text.TrimEnd();
            string? supplierDetailOverviewAddressLine4 = supplierDetailOverviewAddressLine4Textbox.Text.TrimEnd();
            string supplierDetailOverviewAddressLine5 = supplierDetailOverviewAddressLine5Textbox.Text.TrimEnd();
            string supplierDetailOverviewEmailAddress = supplierDetailOverviewEmailAddressTextbox.Text.TrimEnd();
            string supplierDetailOverviewSupplierName = supplierDetailOverviewSupplierNameTextbox.Text.TrimEnd();
            string supplierDetailOverviewTelephoneNumber = supplierDetailOverviewTelephoneNumberTextbox.Text.TrimEnd();

            string dataSubject = "Supplier";

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
                    Name = "SupplierDetailFinancePaymentCurrencyId",
                    Value = supplierDetailFinancePaymentCurrencyId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierDetailFinancePaymentDays",
                    Value = supplierDetailFinancePaymentDays,
                    ValueType = typeof(byte)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierDetailFinanceVATNumber",
                    Value = supplierDetailFinanceVATNumber,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierDetailOverviewActiveStatus",
                    Value = supplierDetailOverviewActiveStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierDetailOverviewAddressLine1",
                    Value = supplierDetailOverviewAddressLine1,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierDetailOverviewAddressLine3",
                    Value = supplierDetailOverviewAddressLine3,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierDetailOverviewAddressLine4",
                    Value = supplierDetailOverviewAddressLine4,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierDetailOverviewAddressLine5",
                    Value = supplierDetailOverviewAddressLine5,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierDetailOverviewEmailAddress",
                    Value = supplierDetailOverviewEmailAddress,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierDetailOverviewSupplierName",
                    Value = supplierDetailOverviewSupplierName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierDetailOverviewTelephoneNumber",
                    Value = supplierDetailOverviewTelephoneNumber,
                    ValueType = typeof(string)
                }
            };

            if (!string.IsNullOrEmpty(supplierDetailOverviewAddressLine2))
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    Name = "SupplierDetailOverviewAddressLine2",
                    Value = supplierDetailOverviewAddressLine2,
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
                        VariableName = "Supplier Detail Finance: Payment Currency Id",
                        VariableType = "Guid",
                        OriginalValue = supplierDetailFinancePaymentCurrencyIdOriginalValue,
                        NewValue = supplierDetailFinancePaymentCurrencyId
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Finance: Payment Days",
                        VariableType = "int",
                        OriginalValue = supplierDetailFinancePaymentDaysOriginalValue,
                        NewValue = supplierDetailFinancePaymentDays
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Finance: VAT Number",
                        VariableType = "string",
                        OriginalValue = supplierDetailFinanceVATNumberOriginalValue,
                        NewValue = supplierDetailFinanceVATNumber
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Active Status",
                        VariableType = "bool",
                        OriginalValue = supplierDetailOverviewActiveStatusOrginalValue,
                        NewValue = supplierDetailOverviewActiveStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Address Line 1",
                        VariableType = "string",
                        OriginalValue = supplierDetailOverviewAddressLine1OriginalValue,
                        NewValue = supplierDetailOverviewAddressLine1
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Address Line 3",
                        VariableType = "string",
                        OriginalValue = supplierDetailOverviewAddressLine3OriginalValue,
                        NewValue = supplierDetailOverviewAddressLine3
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Address Line 4",
                        VariableType = "string",
                        OriginalValue = supplierDetailOverviewAddressLine4OriginalValue,
                        NewValue = supplierDetailOverviewAddressLine4
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Address Line 5",
                        VariableType = "string",
                        OriginalValue = supplierDetailOverviewAddressLine5OriginalValue,
                        NewValue = supplierDetailOverviewAddressLine5
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Email Address",
                        VariableType = "string",
                        OriginalValue = supplierDetailOverviewEmailAddressOriginalValue,
                        NewValue = supplierDetailOverviewEmailAddress
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Supplier Name",
                        VariableType = "string",
                        OriginalValue = supplierDetailOverviewSupplierNameOriginalValue,
                        NewValue = supplierDetailOverviewSupplierName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Telephone Number",
                        VariableType = "string",
                        OriginalValue = supplierDetailOverviewTelephoneNumberOriginalValue,
                        NewValue = supplierDetailOverviewTelephoneNumber
                    }
                };

                if (!string.IsNullOrEmpty(supplierDetailOverviewAddressLine2))
                {
                    changesList.Add(new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Address Line 2",
                        VariableType = "string",
                        OriginalValue = supplierDetailOverviewAddressLine2OriginalValue,
                        NewValue = supplierDetailOverviewAddressLine2
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
                            ParameterValue = supplierDetailOverviewActiveStatus
                        },
                        new Parameter
                        {
                            ParameterName = "@addressLine1",
                            ParameterValue = supplierDetailOverviewAddressLine1
                        },
                        new Parameter
                        {
                            ParameterName = "@addressLine3",
                            ParameterValue = supplierDetailOverviewAddressLine3
                        },
                        new Parameter
                        {
                            ParameterName = "@addressLine4",
                            ParameterValue = supplierDetailOverviewAddressLine4
                        },
                        new Parameter
                        {
                            ParameterName = "@addressLine5",
                            ParameterValue = supplierDetailOverviewAddressLine5
                        },
                        new Parameter
                        {
                            ParameterName = "@emailAddress",
                            ParameterValue = supplierDetailOverviewEmailAddress
                        },
                        new Parameter
                        {
                            ParameterName = "@paymentCurrencyId",
                            ParameterValue = supplierDetailFinancePaymentCurrencyId
                        },
                        new Parameter
                        {
                            ParameterName = "@paymentDays",
                            ParameterValue = supplierDetailFinancePaymentDays
                        },
                        new Parameter
                        {
                            ParameterName = "@supplierId",
                            ParameterValue = _supplierId
                        },
                        new Parameter
                        {
                            ParameterName = "@supplierName",
                            ParameterValue = supplierDetailOverviewSupplierName
                        },
                        new Parameter
                        {
                            ParameterName = "@telephoneNumber",
                            ParameterValue = supplierDetailOverviewTelephoneNumber
                        },
                        new Parameter
                        {
                            ParameterName = "@vatNumber",
                            ParameterValue = supplierDetailFinanceVATNumber
                        }
                    };

                    if (!string.IsNullOrEmpty(supplierDetailOverviewAddressLine2))
                    {
                        parameters.Add(new Parameter
                        {
                            ParameterName = "@addressLine2",
                            ParameterValue = supplierDetailOverviewAddressLine2
                        });
                    }

                    string storedProcedureName = "[dbo].[spUpdateSupplier]";
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
            SupplierDetailSupplierInformation_Load(this, EventArgs.Empty);
        }

        private void supplierDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            supplierDetailOverviewCreatedByTextbox.ReadOnly = !supplierDetailOverviewCreatedByTextbox.ReadOnly;
            supplierDetailOverviewCreatedTimestampTextbox.ReadOnly = !supplierDetailOverviewCreatedTimestampTextbox.ReadOnly;
            supplierDetailFinancePaymentCurrencyComboBox.Enabled = !supplierDetailFinancePaymentCurrencyComboBox.Enabled;
            supplierDetailFinancePaymentDaysTextbox.ReadOnly = !supplierDetailFinancePaymentDaysTextbox.ReadOnly;
            supplierDetailFinanceVATNumberTextbox.ReadOnly = !supplierDetailFinanceVATNumberTextbox.ReadOnly;
            supplierDetailFinanceVATRegisteredCheckbox.Enabled = !supplierDetailFinanceVATRegisteredCheckbox.Enabled;
            supplierDetailOverviewLastUpdatedByTextbox.ReadOnly = !supplierDetailOverviewLastUpdatedByTextbox.ReadOnly;
            supplierDetailOverviewLastUpdatedByTextbox.ReadOnly = !supplierDetailOverviewLastUpdatedByTextbox.ReadOnly;
            supplierDetailOverviewActiveStatusCheckbox.Enabled = !supplierDetailOverviewActiveStatusCheckbox.Enabled;
            supplierDetailOverviewAddressLine1Textbox.ReadOnly = !supplierDetailOverviewAddressLine1Textbox.ReadOnly;
            supplierDetailOverviewAddressLine2Textbox.ReadOnly = !supplierDetailOverviewAddressLine2Textbox.ReadOnly;
            supplierDetailOverviewAddressLine3Textbox.ReadOnly = !supplierDetailOverviewAddressLine3Textbox.ReadOnly;
            supplierDetailOverviewAddressLine4Textbox.ReadOnly = !supplierDetailOverviewAddressLine4Textbox.ReadOnly;
            supplierDetailOverviewAddressLine5Textbox.ReadOnly = !supplierDetailOverviewAddressLine5Textbox.ReadOnly;
            supplierDetailOverviewEmailAddressTextbox.ReadOnly = !supplierDetailOverviewEmailAddressTextbox.ReadOnly;
            supplierDetailOverviewSupplierIdTextbox.ReadOnly = !supplierDetailOverviewSupplierIdTextbox.ReadOnly;
            supplierDetailOverviewSupplierNameTextbox.ReadOnly = !supplierDetailOverviewSupplierNameTextbox.ReadOnly;
            supplierDetailOverviewTelephoneNumberTextbox.ReadOnly = !supplierDetailOverviewTelephoneNumberTextbox.ReadOnly;
            supplierDetailUpdateSupplierButton.Enabled = !supplierDetailUpdateSupplierButton.Enabled;
        }

        private void supplierDetailSupplierContactCreateNewSupplierContactButton_Click(object sender, EventArgs e)
        {
            CreateContact createContact = new CreateContact(_supplierId, "Supplier");
            createContact.Show();
        }

        private async void supplierDetailSupplierContactRefreshDataButton_Click(object sender, EventArgs e)
        {
            await SupplierDetailExistingSupplierContact_Load(sender, e);
        }

        private void supplierDetailSupplierNotesCreateNewSupplierNoteButton_Click(object sender, EventArgs e)
        {
            CreateNote createNote = new CreateNote(_supplierId, "SupplierNote");
            createNote.Show();
        }

        private async void supplierDetailSupplierNotesRefreshDataButton_Click(object sender, EventArgs e)
        {
            await SupplierDetailExistingSupplierNote_Load(sender, e);
        }
    }
}