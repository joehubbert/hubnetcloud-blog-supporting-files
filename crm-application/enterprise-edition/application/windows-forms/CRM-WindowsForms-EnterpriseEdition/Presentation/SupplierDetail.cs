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
        private bool? supplierDetailTabControlOverviewTabPageActiveStatusOrginalValue;
        private string? supplierDetailTabControlOverviewTabPageAddressLine1OriginalValue;
        private string? supplierDetailTabControlOverviewTabPageAddressLine2OriginalValue;
        private string? supplierDetailTabControlOverviewTabPageAddressLine3OriginalValue;
        private string? supplierDetailTabControlOverviewTabPageAddressLine4OriginalValue;
        private string? supplierDetailTabControlOverviewTabPageAddressLine5OriginalValue;
        private string? supplierDetailTabControlOverviewTabPageEmailAddressOriginalValue;
        private string? supplierDetailTabControlOverviewTabPageSupplierNameOriginalValue;
        private string? supplierDetailTabControlOverviewTabPageTelephoneNumberOriginalValue;

        public SupplierDetail(Guid supplierId)
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadDatabaseConnectionSettingsAsync();
            _supplierId = supplierId;
        }

        private void InitializeCustomComponents()
        {
            supplierDetailTabControlFinanceTabPageVATRegisteredCheckbox.CheckedChanged += new EventHandler(SupplierDetailFinanceVATRegisteredCheckbox_CheckedChanged);
            supplierDetailTabControl.SelectedIndexChanged += new EventHandler(SupplierDetailTabControl_SelectedIndexChanged);
            supplierDetailTabControlSupplierNoteTabPageDataGridView.CellContentClick += supplierDetailSupplierNoteExistingSupplierNoteDataGridView_CellContentClick;
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

            string dataSubject = "Currency";

            try
            {
                string storedProcedureName = "[dbo].[spGetAllCurrency]";               
                DataTable? currencyData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject);

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

                supplierDetailTabControlFinanceTabPagePaymentCurrencyComboBox.DataSource = currencyList;
                supplierDetailTabControlFinanceTabPagePaymentCurrencyComboBox.DisplayMember = "DisplayText";
                supplierDetailTabControlFinanceTabPagePaymentCurrencyComboBox.ValueMember = "CurrencyId";
                supplierDetailTabControlFinanceTabPagePaymentCurrencyComboBox.SelectedValue = paymentCurrencyId;
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async void SupplierDetailSupplierInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            string storedProcedureName = "[dbo].[spGetSupplier]";
            string dataSubject = "Supplier";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "supplierId",
                    ParameterValue = _supplierId
                }
            };
            try
            {
                DataTable? supplierDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject);

                if (supplierDataTable != null)
                {
                    DataRow supplierDataRow = supplierDataTable.Rows[0];

                    Guid paymentCurrencyId = (Guid)supplierDataRow["Payment Currency Id"];
                    await SupplierDetailFinanceLoadCurrencyDataAsync(paymentCurrencyId);
                    supplierDetailTabControlFinanceTabPagePaymentDaysTextbox.Text = supplierDataRow["Payment Days"].ToString();
                    supplierDetailTabControlFinanceTabPageVATNumberTextbox.Text = supplierDataRow["VAT Number"].ToString();
                    if (supplierDetailTabControlFinanceTabPageVATNumberTextbox.Text.Length > 0)
                    {
                        supplierDetailTabControlFinanceTabPageVATRegisteredCheckbox.Checked = true;
                    }
                    else
                    {
                        supplierDetailTabControlFinanceTabPageVATRegisteredCheckbox.Checked = false;
                    }
                    supplierDetailTabControlOverviewTabPageActiveStatusCheckbox.Checked = (bool)supplierDataRow["Active Status"];
                    supplierDetailTabControlOverviewTabPageAddressLine1Textbox.Text = supplierDataRow["Address Line 1"].ToString();
                    supplierDetailTabControlOverviewTabPageAddressLine2Textbox.Text = supplierDataRow["Address Line 2"].ToString();
                    supplierDetailTabControlOverviewTabPageAddressLine3Textbox.Text = supplierDataRow["Address Line 3"].ToString();
                    supplierDetailTabControlOverviewTabPageAddressLine4Textbox.Text = supplierDataRow["Address Line 4"].ToString();
                    supplierDetailTabControlOverviewTabPageAddressLine5Textbox.Text = supplierDataRow["Address Line 5"].ToString();
                    supplierDetailTabControlOverviewTabPageCreatedByTextbox.Text = supplierDataRow["Created By"].ToString();
                    supplierDetailTabControlOverviewTabPageCreatedTimestampTextbox.Text = supplierDataRow["Created Timestamp UTC"].ToString();
                    supplierDetailTabControlOverviewTabPageEmailAddressTextbox.Text = supplierDataRow["Email Address"].ToString();
                    supplierDetailTabControlOverviewTabPageLastUpdatedByTextbox.Text = supplierDataRow["Modified By"].ToString();
                    supplierDetailTabControlOverviewTabPageLastUpdatedTimestampTextbox.Text = supplierDataRow["Modified Timestamp UTC"].ToString();
                    supplierDetailTabControlOverviewTabPageSupplierIdTextbox.Text = supplierDataRow["Supplier Id"].ToString();
                    supplierDetailTabControlOverviewTabPageSupplierNameTextbox.Text = supplierDataRow["Supplier Name"].ToString();
                    supplierDetailTabControlOverviewTabPageTelephoneNumberTextbox.Text = supplierDataRow["Telephone Number"].ToString();

                    supplierDetailFinancePaymentCurrencyIdOriginalValue = paymentCurrencyId;
                    supplierDetailFinancePaymentDaysOriginalValue = supplierDataRow["Payment Days"].ToString();
                    supplierDetailFinanceVATNumberOriginalValue = supplierDataRow["VAT Number"].ToString();
                    supplierDetailTabControlOverviewTabPageActiveStatusOrginalValue = (bool)supplierDataRow["Active Status"];
                    supplierDetailTabControlOverviewTabPageAddressLine1OriginalValue = supplierDataRow["Address Line 1"].ToString();
                    supplierDetailTabControlOverviewTabPageAddressLine2OriginalValue = supplierDataRow["Address Line 2"].ToString();
                    supplierDetailTabControlOverviewTabPageAddressLine3OriginalValue = supplierDataRow["Address Line 3"].ToString();
                    supplierDetailTabControlOverviewTabPageAddressLine4OriginalValue = supplierDataRow["Address Line 4"].ToString();
                    supplierDetailTabControlOverviewTabPageAddressLine5OriginalValue = supplierDataRow["Address Line 5"].ToString();
                    supplierDetailTabControlOverviewTabPageEmailAddressOriginalValue = supplierDataRow["Email Address"].ToString();
                    supplierDetailTabControlOverviewTabPageSupplierNameOriginalValue = supplierDataRow["Supplier Name"].ToString();
                    supplierDetailTabControlOverviewTabPageTelephoneNumberOriginalValue = supplierDataRow["Telephone Number"].ToString();

                    this.Text += $" ({supplierDetailTabControlOverviewTabPageSupplierNameOriginalValue})";
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

        private async void SupplierDetailTabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (supplierDetailTabControl.SelectedTab == supplierDetailTabControl.TabPages["supplierDetailTabControlSupplierContactTabPage"])
            {
                await SupplierDetailExistingSupplierContact_Load(sender, e);
            }
            if (supplierDetailTabControl.SelectedTab == supplierDetailTabControl.TabPages["supplierDetailTabControlSupplierNotesPage"])
            {
                await SupplierDetailExistingSupplierNote_Load(sender, e);
            }
        }

        private async Task SupplierDetailExistingSupplierContact_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            string dataSubject = "Existing Supplier Contacts";
            string storedProcedureName = "[dbo].[spGetAllSupplierContactForSupplier]";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "supplierId",
                    ParameterValue = _supplierId
                }
            };

            DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject);

            if (dataTable.Rows.Count == 0)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Information.NoDataFound", dataSubject);
            }
            else
            {
                dataTable.DefaultView.Sort = "Created Timestamp DESC";
                supplierDetailTabControlSupplierContactTabPageDataGridView.AutoGenerateColumns = true;
                supplierDetailTabControlSupplierContactTabPageDataGridView.DataSource = dataTable;
                supplierDetailTabControlSupplierContactTabPageDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if (supplierDetailTabControlSupplierContactTabPageDataGridView.Columns.Contains("Details"))
                {
                    supplierDetailTabControlSupplierContactTabPageDataGridView.Columns.Remove("Details");
                }
                DataGridViewLinkColumn supplierContactDetailLink = new DataGridViewLinkColumn
                {
                    HeaderText = "Details",
                    Text = "View Supplier Contact",
                    UseColumnTextForLinkValue = true,
                    Name = "Details"
                };
                supplierDetailTabControlSupplierContactTabPageDataGridView.Columns.Add(supplierContactDetailLink);
            }
        }

        private async Task SupplierDetailExistingSupplierNote_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            string dataSubject = "Existing Supplier Notes";
            string storedProcedureName = "[dbo].[spGetAllNoteForSupplier]";           

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "supplierId",
                    ParameterValue = _supplierId
                }
            };

            DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject);

            if (dataTable.Rows.Count == 0)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Information.NoDataFound", dataSubject);
            }
            else
            {
                dataTable.DefaultView.Sort = "Created Timestamp DESC";
                supplierDetailTabControlSupplierNoteTabPageDataGridView.AutoGenerateColumns = true;
                supplierDetailTabControlSupplierNoteTabPageDataGridView.DataSource = dataTable;
                supplierDetailTabControlSupplierNoteTabPageDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if (supplierDetailTabControlSupplierNoteTabPageDataGridView.Columns.Contains("Details"))
                {
                    supplierDetailTabControlSupplierNoteTabPageDataGridView.Columns.Remove("Details");
                }
                DataGridViewLinkColumn supplierNoteDetailLink = new DataGridViewLinkColumn
                {
                    HeaderText = "Details",
                    Text = "View Supplier Note",
                    UseColumnTextForLinkValue = true,
                    Name = "Details"
                };
                supplierDetailTabControlSupplierNoteTabPageDataGridView.Columns.Add(supplierNoteDetailLink);
            }
        }

        private void SupplierDetailFinanceVATRegisteredCheckbox_CheckedChanged(object? sender, EventArgs e)
        {
            if (!supplierDetailTabControlFinanceTabPageVATRegisteredCheckbox.Checked)
            {
                var result = MessageBox.Show(
                    "A VAT Number cannot be assigned if VAT Registered is false. Clicking OK will clear the VAT Number field. Clicking Cancel will reverse the changes.",
                    "Warning",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    supplierDetailTabControlFinanceTabPageVATNumberTextbox.Text = string.Empty;
                }
                else
                {
                    supplierDetailTabControlFinanceTabPageVATRegisteredCheckbox.Checked = true;
                }
            }
        }

        private void supplierDetailSupplierContactExistingSupplierContactDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == supplierDetailTabControlSupplierContactTabPageDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                string dataSubject = "Supplier Contact";

                try
                {
                    if (supplierDetailTabControlSupplierContactTabPageDataGridView.Columns.Contains("Supplier Contact Id"))
                    {
                        Guid supplierContactId = (Guid)supplierDetailTabControlSupplierContactTabPageDataGridView.Rows[e.RowIndex].Cells["Supplier Contact Id"].Value;
                        ContactDetail contactDetail = new ContactDetail("Supplier", supplierContactId);
                        contactDetail.Show();
                    }
                    else
                    {
                        ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.IdColumnNotFound", dataSubject);
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
                }
            }
        }

        private void supplierDetailSupplierNoteExistingSupplierNoteDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == supplierDetailTabControlSupplierNoteTabPageDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                string dataSubject = "Supplier Note";

                try
                {
                    if (supplierDetailTabControlSupplierNoteTabPageDataGridView.Columns.Contains("Supplier Note Id"))
                    {
                        Guid supplierNoteId = (Guid)supplierDetailTabControlSupplierNoteTabPageDataGridView.Rows[e.RowIndex].Cells["Supplier Note Id"].Value;
                        NoteDetail noteDetail = new NoteDetail("Supplier", supplierNoteId);
                        noteDetail.Show();
                    }
                    else
                    {
                        ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.IdColumnNotFound", dataSubject);
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
                }
            }
        }

        private async void supplierDetailUpdateSupplierButton_Click(object sender, EventArgs e)
        {
            Guid supplierDetailFinancePaymentCurrencyId = (Guid)supplierDetailTabControlFinanceTabPagePaymentCurrencyComboBox.SelectedValue;
            byte supplierDetailFinancePaymentDays = byte.Parse(supplierDetailTabControlFinanceTabPagePaymentDaysTextbox.Text.TrimEnd());
            string? supplierDetailFinanceVATNumber = supplierDetailTabControlFinanceTabPageVATNumberTextbox.Text.TrimEnd();

            bool supplierDetailTabControlOverviewTabPageActiveStatus = supplierDetailTabControlOverviewTabPageActiveStatusCheckbox.Checked;
            string supplierDetailTabControlOverviewTabPageAddressLine1 = supplierDetailTabControlOverviewTabPageAddressLine1Textbox.Text.TrimEnd();
            string? supplierDetailTabControlOverviewTabPageAddressLine2 = supplierDetailTabControlOverviewTabPageAddressLine2Textbox.Text.TrimEnd();
            string supplierDetailTabControlOverviewTabPageAddressLine3 = supplierDetailTabControlOverviewTabPageAddressLine3Textbox.Text.TrimEnd();
            string? supplierDetailTabControlOverviewTabPageAddressLine4 = supplierDetailTabControlOverviewTabPageAddressLine4Textbox.Text.TrimEnd();
            string supplierDetailTabControlOverviewTabPageAddressLine5 = supplierDetailTabControlOverviewTabPageAddressLine5Textbox.Text.TrimEnd();
            string supplierDetailTabControlOverviewTabPageEmailAddress = supplierDetailTabControlOverviewTabPageEmailAddressTextbox.Text.TrimEnd();
            string supplierDetailTabControlOverviewTabPageSupplierName = supplierDetailTabControlOverviewTabPageSupplierNameTextbox.Text.TrimEnd();
            string supplierDetailTabControlOverviewTabPageTelephoneNumber = supplierDetailTabControlOverviewTabPageTelephoneNumberTextbox.Text.TrimEnd();

            string dataSubject = "Supplier";

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
                    Value = supplierDetailTabControlOverviewTabPageActiveStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierDetailOverviewAddressLine1",
                    Value = supplierDetailTabControlOverviewTabPageAddressLine1,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierDetailOverviewAddressLine3",
                    Value = supplierDetailTabControlOverviewTabPageAddressLine3,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierDetailOverviewAddressLine4",
                    Value = supplierDetailTabControlOverviewTabPageAddressLine4,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierDetailOverviewAddressLine5",
                    Value = supplierDetailTabControlOverviewTabPageAddressLine5,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierDetailOverviewEmailAddress",
                    Value = supplierDetailTabControlOverviewTabPageEmailAddress,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierDetailOverviewSupplierName",
                    Value = supplierDetailTabControlOverviewTabPageSupplierName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierDetailOverviewTelephoneNumber",
                    Value = supplierDetailTabControlOverviewTabPageTelephoneNumber,
                    ValueType = typeof(string)
                }
            };

            if (!string.IsNullOrEmpty(supplierDetailTabControlOverviewTabPageAddressLine2))
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    Name = "SupplierDetailOverviewAddressLine2",
                    Value = supplierDetailTabControlOverviewTabPageAddressLine2,
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
                        OriginalValue = supplierDetailTabControlOverviewTabPageActiveStatusOrginalValue,
                        NewValue = supplierDetailTabControlOverviewTabPageActiveStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Address Line 1",
                        VariableType = "string",
                        OriginalValue = supplierDetailTabControlOverviewTabPageAddressLine1OriginalValue,
                        NewValue = supplierDetailTabControlOverviewTabPageAddressLine1
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Address Line 3",
                        VariableType = "string",
                        OriginalValue = supplierDetailTabControlOverviewTabPageAddressLine3OriginalValue,
                        NewValue = supplierDetailTabControlOverviewTabPageAddressLine3
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Address Line 4",
                        VariableType = "string",
                        OriginalValue = supplierDetailTabControlOverviewTabPageAddressLine4OriginalValue,
                        NewValue = supplierDetailTabControlOverviewTabPageAddressLine4
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Address Line 5",
                        VariableType = "string",
                        OriginalValue = supplierDetailTabControlOverviewTabPageAddressLine5OriginalValue,
                        NewValue = supplierDetailTabControlOverviewTabPageAddressLine5
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Email Address",
                        VariableType = "string",
                        OriginalValue = supplierDetailTabControlOverviewTabPageEmailAddressOriginalValue,
                        NewValue = supplierDetailTabControlOverviewTabPageEmailAddress
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Supplier Name",
                        VariableType = "string",
                        OriginalValue = supplierDetailTabControlOverviewTabPageSupplierNameOriginalValue,
                        NewValue = supplierDetailTabControlOverviewTabPageSupplierName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Telephone Number",
                        VariableType = "string",
                        OriginalValue = supplierDetailTabControlOverviewTabPageTelephoneNumberOriginalValue,
                        NewValue = supplierDetailTabControlOverviewTabPageTelephoneNumber
                    }
                };

                if (!string.IsNullOrEmpty(supplierDetailTabControlOverviewTabPageAddressLine2))
                {
                    changesList.Add(new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Address Line 2",
                        VariableType = "string",
                        OriginalValue = supplierDetailTabControlOverviewTabPageAddressLine2OriginalValue,
                        NewValue = supplierDetailTabControlOverviewTabPageAddressLine2
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
                            ParameterName = "activeStatus",
                            ParameterValue = supplierDetailTabControlOverviewTabPageActiveStatus
                        },
                        new Parameter
                        {
                            ParameterName = "addressLine1",
                            ParameterValue = supplierDetailTabControlOverviewTabPageAddressLine1
                        },
                        new Parameter
                        {
                            ParameterName = "addressLine3",
                            ParameterValue = supplierDetailTabControlOverviewTabPageAddressLine3
                        },
                        new Parameter
                        {
                            ParameterName = "addressLine4",
                            ParameterValue = supplierDetailTabControlOverviewTabPageAddressLine4
                        },
                        new Parameter
                        {
                            ParameterName = "addressLine5",
                            ParameterValue = supplierDetailTabControlOverviewTabPageAddressLine5
                        },
                        new Parameter
                        {
                            ParameterName = "emailAddress",
                            ParameterValue = supplierDetailTabControlOverviewTabPageEmailAddress
                        },
                        new Parameter
                        {
                            ParameterName = "paymentCurrencyId",
                            ParameterValue = supplierDetailFinancePaymentCurrencyId
                        },
                        new Parameter
                        {
                            ParameterName = "paymentDays",
                            ParameterValue = supplierDetailFinancePaymentDays
                        },
                        new Parameter
                        {
                            ParameterName = "supplierId",
                            ParameterValue = _supplierId
                        },
                        new Parameter
                        {
                            ParameterName = "supplierName",
                            ParameterValue = supplierDetailTabControlOverviewTabPageSupplierName
                        },
                        new Parameter
                        {
                            ParameterName = "telephoneNumber",
                            ParameterValue = supplierDetailTabControlOverviewTabPageTelephoneNumber
                        },
                        new Parameter
                        {
                            ParameterName = "vatNumber",
                            ParameterValue = supplierDetailFinanceVATNumber
                        }
                    };

                    if (!string.IsNullOrEmpty(supplierDetailTabControlOverviewTabPageAddressLine2))
                    {
                        parameters.Add(new Parameter
                        {
                            ParameterName = "addressLine2",
                            ParameterValue = supplierDetailTabControlOverviewTabPageAddressLine2
                        });
                    }

                    string storedProcedureName = "[dbo].[spUpdateSupplier]";
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
            SupplierDetailSupplierInformation_Load(this, EventArgs.Empty);
        }

        private void supplierDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            supplierDetailTabControlOverviewTabPageCreatedByTextbox.ReadOnly = !supplierDetailTabControlOverviewTabPageCreatedByTextbox.ReadOnly;
            supplierDetailTabControlOverviewTabPageCreatedTimestampTextbox.ReadOnly = !supplierDetailTabControlOverviewTabPageCreatedTimestampTextbox.ReadOnly;
            supplierDetailTabControlFinanceTabPagePaymentCurrencyComboBox.Enabled = !supplierDetailTabControlFinanceTabPagePaymentCurrencyComboBox.Enabled;
            supplierDetailTabControlFinanceTabPagePaymentDaysTextbox.ReadOnly = !supplierDetailTabControlFinanceTabPagePaymentDaysTextbox.ReadOnly;
            supplierDetailTabControlFinanceTabPageVATNumberTextbox.ReadOnly = !supplierDetailTabControlFinanceTabPageVATNumberTextbox.ReadOnly;
            supplierDetailTabControlFinanceTabPageVATRegisteredCheckbox.Enabled = !supplierDetailTabControlFinanceTabPageVATRegisteredCheckbox.Enabled;
            supplierDetailTabControlOverviewTabPageLastUpdatedByTextbox.ReadOnly = !supplierDetailTabControlOverviewTabPageLastUpdatedByTextbox.ReadOnly;
            supplierDetailTabControlOverviewTabPageLastUpdatedByTextbox.ReadOnly = !supplierDetailTabControlOverviewTabPageLastUpdatedByTextbox.ReadOnly;
            supplierDetailTabControlOverviewTabPageActiveStatusCheckbox.Enabled = !supplierDetailTabControlOverviewTabPageActiveStatusCheckbox.Enabled;
            supplierDetailTabControlOverviewTabPageAddressLine1Textbox.ReadOnly = !supplierDetailTabControlOverviewTabPageAddressLine1Textbox.ReadOnly;
            supplierDetailTabControlOverviewTabPageAddressLine2Textbox.ReadOnly = !supplierDetailTabControlOverviewTabPageAddressLine2Textbox.ReadOnly;
            supplierDetailTabControlOverviewTabPageAddressLine3Textbox.ReadOnly = !supplierDetailTabControlOverviewTabPageAddressLine3Textbox.ReadOnly;
            supplierDetailTabControlOverviewTabPageAddressLine4Textbox.ReadOnly = !supplierDetailTabControlOverviewTabPageAddressLine4Textbox.ReadOnly;
            supplierDetailTabControlOverviewTabPageAddressLine5Textbox.ReadOnly = !supplierDetailTabControlOverviewTabPageAddressLine5Textbox.ReadOnly;
            supplierDetailTabControlOverviewTabPageEmailAddressTextbox.ReadOnly = !supplierDetailTabControlOverviewTabPageEmailAddressTextbox.ReadOnly;
            supplierDetailTabControlOverviewTabPageSupplierIdTextbox.ReadOnly = !supplierDetailTabControlOverviewTabPageSupplierIdTextbox.ReadOnly;
            supplierDetailTabControlOverviewTabPageSupplierNameTextbox.ReadOnly = !supplierDetailTabControlOverviewTabPageSupplierNameTextbox.ReadOnly;
            supplierDetailTabControlOverviewTabPageTelephoneNumberTextbox.ReadOnly = !supplierDetailTabControlOverviewTabPageTelephoneNumberTextbox.ReadOnly;
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