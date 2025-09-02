using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class SupplierDetail : Form
    {
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DataGridViewQuickSearchHelper? _dataGridViewQuickSearchHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _supplierId;
        private TextBoxNumericCharacterDataValidationHelper _textBoxNumericHelper;
        private string supplierDetailTabControlFinanceTabPagePaymentDaysOriginalValue;
        private Guid supplierDetailTabControlFinanceTabPagePaymentCurrencyIdOriginalValue;
        private string? supplierDetailTabControlFinanceTabPageVATNumberOriginalValue;
        private bool supplierDetailTabControlFinanceTabPageVATRegisteredOriginalValue;
        private bool supplierDetailTabControlOverviewTabPageActiveStatusOrginalValue;
        private string supplierDetailTabControlOverviewTabPageAddressLine1OriginalValue;
        private string? supplierDetailTabControlOverviewTabPageAddressLine2OriginalValue;
        private string supplierDetailTabControlOverviewTabPageAddressLine3OriginalValue;
        private string supplierDetailTabControlOverviewTabPageAddressLine4OriginalValue;
        private Guid supplierDetailTabControlOverviewTabPageAddressLine5OriginalValue;
        private string supplierDetailTabControlOverviewTabPageEmailAddressOriginalValue;
        private string supplierDetailTabControlOverviewTabPageSupplierNameOriginalValue;
        private string supplierDetailTabControlOverviewTabPageTelephoneNumberOriginalValue;

        public SupplierDetail(Guid supplierId)
        {
            InitializeComponent();
            _textBoxNumericHelper = new TextBoxNumericCharacterDataValidationHelper();
            InitializeEventHandlers();
            LoadDatabaseConnectionSettingsAsync();
            _supplierId = supplierId;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            SupplierDetailSupplierInformation_Load(this, EventArgs.Empty);
        }

        private void InitializeEventHandlers()
        {
            supplierDetailTabControl.SelectedIndexChanged += supplierDetailTabControl_SelectedIndexChanged;
            supplierDetailTabControlFinanceTabPagePaymentCurrencyComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            supplierDetailTabControlFinanceTabPagePaymentDaysTextBox.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            supplierDetailTabControlFinanceTabPageVATRegisteredCheckBox.CheckedChanged += supplierDetailTabControlFinanceTabPageVATRegisteredCheckBox_CheckedChanged;
            supplierDetailTabControlOverviewTabPageAddressLine5ComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            supplierDetailTabControlSupplierContactTabPageDataGridView.CellContentClick += supplierDetailTabControlSupplierContactTabPageDataGridView_CellContentClick;
            supplierDetailTabControlSupplierNoteTabPageDataGridView.CellContentClick += supplierDetailTabControlSupplierNoteTabPageDataGridView_CellContentClick;
            supplierDetailToggleEditModeButton.Click += supplierDetailToggleEditModeButton_Click;
            _dataGridViewQuickSearchHelper = new DataGridViewQuickSearchHelper(supplierDetailTabControlSupplierContactTabPageQuickFilterTextBox, supplierDetailTabControlSupplierContactTabPageDataGridView);
            _dataGridViewQuickSearchHelper = new DataGridViewQuickSearchHelper(supplierDetailTabControlSupplierNoteTabPageQuickFilterTextBox, supplierDetailTabControlSupplierNoteTabPageDataGridView);
        }

        private async Task LoadCountryDataAsync(Guid countryId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(supplierDetailTabControlOverviewTabPageAddressLine5ComboBox, "spGetAllCountry", null, true, "Country Id", countryId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadCurrencyDataAsync(Guid currencyId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(supplierDetailTabControlFinanceTabPagePaymentCurrencyComboBox, "spGetAllCurrency", null, true, "Currency Id", currencyId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task SupplierDetailExistingSupplierContact_Load(object sender, EventArgs e)
        {
            await DataAccessDataGridViewHelper.LoadDataGridViewAsync(
                _databaseConnectionSettings,
                _supplierId,
                "supplierId",
                "spGetAllSupplierContactForSupplier",
                "Existing Supplier Contacts",
                supplierDetailTabControlSupplierContactTabPageDataGridView,
                "Supplier Contact Id",
                "View Supplier Contact",
                "DESC",
                "Created Timestamp UTC"
            );
        }

        private async Task SupplierDetailExistingSupplierNote_Load(object sender, EventArgs e)
        {
            await DataAccessDataGridViewHelper.LoadDataGridViewAsync(
                _databaseConnectionSettings,
                _supplierId,
                "supplierId",
                "spGetAllNoteForSupplier",
                "Existing Supplier Notes",
                supplierDetailTabControlSupplierNoteTabPageDataGridView,
                "Supplier Note Id",
                "View Supplier Note",
                "DESC",
                "Created Timestamp UTC"
            );
        }

        private async void SupplierDetailSupplierInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            string storedProcedureName = "spGetSupplier";
            string dataSubject = "Supplier";

            var parameters = new[]
            {
                new StoredProcedureParameter
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
                    await LoadCurrencyDataAsync(paymentCurrencyId);
                    supplierDetailTabControlFinanceTabPagePaymentDaysTextBox.Text = supplierDataRow["Payment Days"].ToString();
                    supplierDetailTabControlFinanceTabPageVATNumberTextBox.Text = supplierDataRow["VAT Number"].ToString();
                    supplierDetailTabControlFinanceTabPageVATRegisteredCheckBox.Checked = (bool)supplierDataRow["VAT Registered"];
                    supplierDetailTabControlOverviewTabPageActiveStatusCheckBox.Checked = (bool)supplierDataRow["Active Status"];
                    supplierDetailTabControlOverviewTabPageAddressLine1TextBox.Text = supplierDataRow["Address Line 1"].ToString();
                    supplierDetailTabControlOverviewTabPageAddressLine2TextBox.Text = supplierDataRow["Address Line 2"].ToString();
                    supplierDetailTabControlOverviewTabPageAddressLine3TextBox.Text = supplierDataRow["Address Line 3"].ToString();
                    supplierDetailTabControlOverviewTabPageAddressLine4TextBox.Text = supplierDataRow["Address Line 4"].ToString();
                    Guid supplierAddressLine5 = (Guid)supplierDataRow["Address Line 5"];
                    await LoadCountryDataAsync(supplierAddressLine5);
                    supplierDetailTabControlOverviewTabPageCreatedByTextBox.Text = supplierDataRow["Created By"].ToString();
                    supplierDetailTabControlOverviewTabPageCreatedTimestampTextBox.Text = supplierDataRow["Created Timestamp UTC"].ToString();
                    supplierDetailTabControlOverviewTabPageEmailAddressTextBox.Text = supplierDataRow["Email Address"].ToString();
                    supplierDetailTabControlOverviewTabPageLastUpdatedByTextBox.Text = supplierDataRow["Modified By"].ToString();
                    supplierDetailTabControlOverviewTabPageLastUpdatedTimestampTextBox.Text = supplierDataRow["Modified Timestamp UTC"].ToString();
                    supplierDetailTabControlOverviewTabPageSupplierIdTextBox.Text = supplierDataRow["Supplier Id"].ToString();
                    supplierDetailTabControlOverviewTabPageSupplierNameTextBox.Text = supplierDataRow["Supplier Name"].ToString();
                    supplierDetailTabControlOverviewTabPageTelephoneNumberTextBox.Text = supplierDataRow["Telephone Number"].ToString();

                    supplierDetailTabControlFinanceTabPagePaymentCurrencyIdOriginalValue = paymentCurrencyId;
                    supplierDetailTabControlFinanceTabPagePaymentDaysOriginalValue = supplierDataRow["Payment Days"].ToString();
                    supplierDetailTabControlFinanceTabPageVATNumberOriginalValue = supplierDataRow["VAT Number"].ToString();
                    supplierDetailTabControlFinanceTabPageVATRegisteredOriginalValue = (bool)supplierDataRow["VAT Registered"];
                    supplierDetailTabControlOverviewTabPageActiveStatusOrginalValue = (bool)supplierDataRow["Active Status"];
                    supplierDetailTabControlOverviewTabPageAddressLine1OriginalValue = supplierDataRow["Address Line 1"].ToString();
                    supplierDetailTabControlOverviewTabPageAddressLine2OriginalValue = supplierDataRow["Address Line 2"].ToString();
                    supplierDetailTabControlOverviewTabPageAddressLine3OriginalValue = supplierDataRow["Address Line 3"].ToString();
                    supplierDetailTabControlOverviewTabPageAddressLine4OriginalValue = supplierDataRow["Address Line 4"].ToString();
                    supplierDetailTabControlOverviewTabPageAddressLine5OriginalValue = (Guid)supplierDataRow["Address Line 5"];
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

        private async void supplierDetailTabControl_SelectedIndexChanged(object? sender, EventArgs e)
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

        private void supplierDetailTabControlFinanceTabPageVATRegisteredCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (!supplierDetailTabControlFinanceTabPageVATRegisteredCheckBox.Checked)
            {
                var result = MessageBox.Show(
                    "A VAT Number cannot be assigned if VAT Registered is false. Clicking OK will clear the VAT Number field. Clicking Cancel will reverse the changes.",
                    "Warning",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    supplierDetailTabControlFinanceTabPageVATNumberTextBox.Text = string.Empty;
                }
                else
                {
                    supplierDetailTabControlFinanceTabPageVATRegisteredCheckBox.Checked = true;
                }
            }
        }

        private void supplierDetailTabControlSupplierContactTabPageCreateNewSupplierContactButton_Click(object sender, EventArgs e)
        {
            CreateContact createContact = new CreateContact(_supplierId, "Supplier", supplierDetailTabControlOverviewTabPageSupplierNameOriginalValue);
            createContact.Show();
        }

        private void supplierDetailTabControlSupplierContactTabPageDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            DataAccessDataGridViewHelper.HandleDetailsCellClick(
            supplierDetailTabControlSupplierContactTabPageDataGridView,
            e,
            "Supplier Contact Id",
            "Supplier Contact",
            id => {
                var contactDetail = new ContactDetail("Supplier", id, supplierDetailTabControlOverviewTabPageSupplierNameOriginalValue, _supplierId);
                contactDetail.Show();
            });
        }

        private async void supplierDetailTabControlSupplierContactTabPageRefreshDataButton_Click(object sender, EventArgs e)
        {
            await SupplierDetailExistingSupplierContact_Load(sender, e);
        }

        private void supplierDetailTabControlSupplierNoteTabPageCreateNewSupplierNoteButton_Click(object sender, EventArgs e)
        {
            CreateNote createNote = new CreateNote(_supplierId, "SupplierNote", supplierDetailTabControlOverviewTabPageSupplierNameOriginalValue);
            createNote.Show();
        }

        private void supplierDetailTabControlSupplierNoteTabPageDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            DataAccessDataGridViewHelper.HandleDetailsCellClick(
            supplierDetailTabControlSupplierNoteTabPageDataGridView,
            e,
            "Supplier Note Id",
            "Supplier Note",
            id => {
                var noteDetail = new NoteDetail(_supplierId, "Supplier", id, supplierDetailTabControlOverviewTabPageSupplierNameOriginalValue);
                noteDetail.Show();
            });
        }

        private async void supplierDetailTabControlSupplierNoteTabPageRefreshDataButton_Click(object sender, EventArgs e)
        {
            await SupplierDetailExistingSupplierNote_Load(sender, e);
        }

        private void supplierDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            supplierDetailTabControlOverviewTabPageCreatedByTextBox.ReadOnly = !supplierDetailTabControlOverviewTabPageCreatedByTextBox.ReadOnly;
            supplierDetailTabControlOverviewTabPageCreatedTimestampTextBox.ReadOnly = !supplierDetailTabControlOverviewTabPageCreatedTimestampTextBox.ReadOnly;
            supplierDetailTabControlFinanceTabPagePaymentCurrencyComboBox.Enabled = !supplierDetailTabControlFinanceTabPagePaymentCurrencyComboBox.Enabled;
            supplierDetailTabControlFinanceTabPagePaymentDaysTextBox.ReadOnly = !supplierDetailTabControlFinanceTabPagePaymentDaysTextBox.ReadOnly;
            supplierDetailTabControlFinanceTabPageVATNumberTextBox.ReadOnly = !supplierDetailTabControlFinanceTabPageVATNumberTextBox.ReadOnly;
            supplierDetailTabControlFinanceTabPageVATRegisteredCheckBox.Enabled = !supplierDetailTabControlFinanceTabPageVATRegisteredCheckBox.Enabled;
            supplierDetailTabControlOverviewTabPageLastUpdatedByTextBox.ReadOnly = !supplierDetailTabControlOverviewTabPageLastUpdatedByTextBox.ReadOnly;
            supplierDetailTabControlOverviewTabPageLastUpdatedByTextBox.ReadOnly = !supplierDetailTabControlOverviewTabPageLastUpdatedByTextBox.ReadOnly;
            supplierDetailTabControlOverviewTabPageActiveStatusCheckBox.Enabled = !supplierDetailTabControlOverviewTabPageActiveStatusCheckBox.Enabled;
            supplierDetailTabControlOverviewTabPageAddressLine1TextBox.ReadOnly = !supplierDetailTabControlOverviewTabPageAddressLine1TextBox.ReadOnly;
            supplierDetailTabControlOverviewTabPageAddressLine2TextBox.ReadOnly = !supplierDetailTabControlOverviewTabPageAddressLine2TextBox.ReadOnly;
            supplierDetailTabControlOverviewTabPageAddressLine3TextBox.ReadOnly = !supplierDetailTabControlOverviewTabPageAddressLine3TextBox.ReadOnly;
            supplierDetailTabControlOverviewTabPageAddressLine4TextBox.ReadOnly = !supplierDetailTabControlOverviewTabPageAddressLine4TextBox.ReadOnly;
            supplierDetailTabControlOverviewTabPageAddressLine5ComboBox.Enabled = !supplierDetailTabControlOverviewTabPageAddressLine5ComboBox.Enabled;
            supplierDetailTabControlOverviewTabPageEmailAddressTextBox.ReadOnly = !supplierDetailTabControlOverviewTabPageEmailAddressTextBox.ReadOnly;
            supplierDetailTabControlOverviewTabPageSupplierIdTextBox.ReadOnly = !supplierDetailTabControlOverviewTabPageSupplierIdTextBox.ReadOnly;
            supplierDetailTabControlOverviewTabPageSupplierNameTextBox.ReadOnly = !supplierDetailTabControlOverviewTabPageSupplierNameTextBox.ReadOnly;
            supplierDetailTabControlOverviewTabPageTelephoneNumberTextBox.ReadOnly = !supplierDetailTabControlOverviewTabPageTelephoneNumberTextBox.ReadOnly;
            supplierDetailUpdateSupplierButton.Enabled = !supplierDetailUpdateSupplierButton.Enabled;
        }

        private async void supplierDetailUpdateSupplierButton_Click(object sender, EventArgs e)
        {
            Guid supplierDetailFinancePaymentCurrencyId = (Guid)supplierDetailTabControlFinanceTabPagePaymentCurrencyComboBox.SelectedValue;
            byte supplierDetailFinancePaymentDays = byte.Parse(TextBoxCleanerHelper.GetTrimmedText(supplierDetailTabControlFinanceTabPagePaymentDaysTextBox));
            string? supplierDetailFinanceVATNumber = TextBoxCleanerHelper.GetTrimmedText(supplierDetailTabControlFinanceTabPageVATNumberTextBox);
            bool supplierDetailFinanceVATRegistered = supplierDetailTabControlFinanceTabPageVATRegisteredCheckBox.Checked;

            bool supplierDetailOverviewActiveStatus = supplierDetailTabControlOverviewTabPageActiveStatusCheckBox.Checked;
            string supplierDetailOverviewAddressLine1 = TextBoxCleanerHelper.GetTrimmedText(supplierDetailTabControlOverviewTabPageAddressLine1TextBox);
            string? supplierDetailOverviewAddressLine2 = TextBoxCleanerHelper.GetTrimmedText(supplierDetailTabControlOverviewTabPageAddressLine2TextBox);
            string supplierDetailOverviewAddressLine3 = TextBoxCleanerHelper.GetTrimmedText(supplierDetailTabControlOverviewTabPageAddressLine3TextBox);
            string? supplierDetailOverviewAddressLine4 = TextBoxCleanerHelper.GetTrimmedText(supplierDetailTabControlOverviewTabPageAddressLine4TextBox);
            Guid supplierDetailOverviewAddressLine5 = (Guid)supplierDetailTabControlOverviewTabPageAddressLine5ComboBox.SelectedValue;
            string supplierDetailOverviewEmailAddress = TextBoxCleanerHelper.GetTrimmedText(supplierDetailTabControlOverviewTabPageEmailAddressTextBox);
            string supplierDetailOverviewSupplierName = TextBoxCleanerHelper.GetTrimmedText(supplierDetailTabControlOverviewTabPageSupplierNameTextBox);
            string supplierDetailOverviewTelephoneNumber = TextBoxCleanerHelper.GetTrimmedText(supplierDetailTabControlOverviewTabPageTelephoneNumberTextBox);

            string dataSubject = "Supplier";

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
                    Name = "Supplier Detail Finance:Payment Currency Id",
                    Value = supplierDetailFinancePaymentCurrencyId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Detail Finance: Payment Days",
                    Value = supplierDetailFinancePaymentDays,
                    ValueType = typeof(byte)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Supplier Detail Finance: VAT Number",
                    Value = supplierDetailFinanceVATNumber,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Detail Finance: VAT Registered",
                    Value = supplierDetailFinanceVATRegistered,
                    ValueType = typeof(bool)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Detail Overview: Active Status",
                    Value = supplierDetailOverviewActiveStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Detail Overview: Address Line 1",
                    Value = supplierDetailOverviewAddressLine1,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Supplier Detail Overview: Address Line 2",
                    Value = supplierDetailOverviewAddressLine2,
                    MaxLength = 50
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Detail Overview: Address Line 3",
                    Value = supplierDetailOverviewAddressLine3,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Detail Overview: Address Line 4",
                    Value = supplierDetailOverviewAddressLine4,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Detail Overview: Address Line 5",
                    Value = supplierDetailOverviewAddressLine5,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Detail Overview: Email Address",
                    Value = supplierDetailOverviewEmailAddress,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Detail Overview: Supplier Name",
                    Value = supplierDetailOverviewSupplierName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Supplier Detail Overview: Telephone Number",
                    Value = supplierDetailOverviewTelephoneNumber,
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
                        VariableName = "Supplier Detail Finance: Payment Currency Id",
                        VariableType = "Guid",
                        OriginalValue = supplierDetailTabControlFinanceTabPagePaymentCurrencyIdOriginalValue,
                        NewValue = supplierDetailFinancePaymentCurrencyId
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Finance: Payment Days",
                        VariableType = "int",
                        OriginalValue = supplierDetailTabControlFinanceTabPagePaymentDaysOriginalValue,
                        NewValue = supplierDetailFinancePaymentDays
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Finance: VAT Number",
                        VariableType = "string",
                        OriginalValue = supplierDetailTabControlFinanceTabPageVATNumberOriginalValue,
                        NewValue = supplierDetailFinanceVATNumber
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Finance: VAT Registered",
                        VariableType = "bool",
                        OriginalValue = supplierDetailTabControlFinanceTabPageVATRegisteredOriginalValue,
                        NewValue = supplierDetailFinanceVATRegistered
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Active Status",
                        VariableType = "bool",
                        OriginalValue = supplierDetailTabControlOverviewTabPageActiveStatusOrginalValue,
                        NewValue = supplierDetailOverviewActiveStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Address Line 1",
                        VariableType = "string",
                        OriginalValue = supplierDetailTabControlOverviewTabPageAddressLine1OriginalValue,
                        NewValue = supplierDetailOverviewAddressLine1
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Address Line 3",
                        VariableType = "string",
                        OriginalValue = supplierDetailTabControlOverviewTabPageAddressLine3OriginalValue,
                        NewValue = supplierDetailOverviewAddressLine3
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Address Line 4",
                        VariableType = "string",
                        OriginalValue = supplierDetailTabControlOverviewTabPageAddressLine4OriginalValue,
                        NewValue = supplierDetailOverviewAddressLine4
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Address Line 5",
                        VariableType = "string",
                        OriginalValue = supplierDetailTabControlOverviewTabPageAddressLine5OriginalValue,
                        NewValue = supplierDetailOverviewAddressLine5
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Email Address",
                        VariableType = "string",
                        OriginalValue = supplierDetailTabControlOverviewTabPageEmailAddressOriginalValue,
                        NewValue = supplierDetailOverviewEmailAddress
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Supplier Name",
                        VariableType = "string",
                        OriginalValue = supplierDetailTabControlOverviewTabPageSupplierNameOriginalValue,
                        NewValue = supplierDetailOverviewSupplierName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Telephone Number",
                        VariableType = "string",
                        OriginalValue = supplierDetailTabControlOverviewTabPageTelephoneNumberOriginalValue,
                        NewValue = supplierDetailOverviewTelephoneNumber
                    }
                };

                if (!string.IsNullOrEmpty(supplierDetailOverviewAddressLine2))
                {
                    changesList.Add(new ChangeDetail
                    {
                        VariableName = "Supplier Detail Overview: Address Line 2",
                        VariableType = "string",
                        OriginalValue = supplierDetailTabControlOverviewTabPageAddressLine2OriginalValue,
                        NewValue = supplierDetailOverviewAddressLine2
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
                            ParameterValue = supplierDetailOverviewActiveStatus
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "addressLine1",
                            ParameterValue = supplierDetailOverviewAddressLine1
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "addressLine3",
                            ParameterValue = supplierDetailOverviewAddressLine3
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "addressLine4",
                            ParameterValue = supplierDetailOverviewAddressLine4
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "addressLine5",
                            ParameterValue = supplierDetailOverviewAddressLine5
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "emailAddress",
                            ParameterValue = supplierDetailOverviewEmailAddress
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "paymentCurrencyId",
                            ParameterValue = supplierDetailFinancePaymentCurrencyId
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "paymentDays",
                            ParameterValue = supplierDetailFinancePaymentDays
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "supplierId",
                            ParameterValue = _supplierId
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "supplierName",
                            ParameterValue = supplierDetailOverviewSupplierName
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "telephoneNumber",
                            ParameterValue = supplierDetailOverviewTelephoneNumber
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "vatRegistered",
                            ParameterValue = supplierDetailFinanceVATRegistered
                        }
                    };

                    if (!string.IsNullOrEmpty(supplierDetailOverviewAddressLine2))
                    {
                        parameters.Add(new StoredProcedureParameter
                        {
                            ParameterName = "addressLine2",
                            ParameterValue = supplierDetailOverviewAddressLine2
                        });
                    }

                    if (!string.IsNullOrEmpty(supplierDetailFinanceVATNumber))
                    {
                        parameters.Add(new StoredProcedureParameter
                        {
                            ParameterName = "vatNumber",
                            ParameterValue = supplierDetailFinanceVATNumber
                        });
                    }

                    string storedProcedureName = "spUpdateSupplier";
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
    }
}