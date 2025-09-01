using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CustomerLeadDetail : Form
    {    
        private readonly Guid _customerId;
        private readonly Guid _customerLeadId;
        private readonly string _customerName;
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DataGridViewQuickSearchHelper? _dataGridViewQuickSearchHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private bool customerLeadDetailTabControlOverviewTabPageActiveStatusOriginalValue;
        private Guid? customerLeadDetailTabControlOverviewTabPageCustomerContactIdOriginalValue;
        private string customerLeadDetailTabControlOverviewTabPageCustomerLeadOriginalValue;
        private DateTime? customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDateOriginalValue;
        private string customerLeadDetailTabControlOverviewTabPageCustomerLeadTitleOriginalValue;
        private Guid customerLeadDetailTabControlOverviewTabPageCustomerLeadTypeIdOriginalValue;
        private Guid? customerLeadDetailTabControlOverviewTabPageMarketingChannelIdOriginalValue;

        public CustomerLeadDetail(Guid customerId, Guid customerLeadId, string customerName)
        {
            InitializeComponent();
            InitializeEventHandlers();
            LoadDatabaseConnectionSettingsAsync();
            _customerId = customerId;
            _customerLeadId = customerLeadId;
            _customerName = customerName;
            PopulateStatusStrip();
        }

        private void InitializeEventHandlers()
        {
            customerLeadDetailTabControl.SelectedIndexChanged += CustomerLeadDetailTabControl_SelectedIndexChanged;
            customerLeadDetailTabControlCustomerLeadNoteTabPageDataGridView.CellContentClick += customerLeadDetailTabControlCustomerLeadNoteTabPageDataGridView_CellContentClick;
            customerLeadDetailTabControlOverviewTabPageCustomerContactPanelNoRadioButton.CheckedChanged += CustomerLeadDetailCustomerContactChoiceRadioButton_CheckedChanged;
            customerLeadDetailTabControlOverviewTabPageCustomerContactPanelYesRadioButton.CheckedChanged += CustomerLeadDetailCustomerContactChoiceRadioButton_CheckedChanged;
            customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerLeadDetailTabControlOverviewTabPageCustomerLeadTypeComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelNoRadioButton.CheckedChanged += CustomerLeadDetailMarketingChannelChoiceRadioButton_CheckedChanged;
            customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelYesRadioButton.CheckedChanged += CustomerLeadDetailMarketingChannelChoiceRadioButton_CheckedChanged;
            customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelMarketingChannelComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelNoRadioButton.CheckedChanged += CustomerLeadDetailTargetDateChoiceRadioButton_CheckedChanged;
            customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelYesRadioButton.CheckedChanged += CustomerLeadDetailTargetDateChoiceRadioButton_CheckedChanged;
            customerLeadDetailToggleEditModeButton.Click += customerLeadDetailToggleEditModeButton_Click;
            _dataGridViewQuickSearchHelper = new DataGridViewQuickSearchHelper(customerLeadDetailTabControlCustomerLeadNoteTabPageQuickFilterTextBox, customerLeadDetailTabControlCustomerLeadNoteTabPageDataGridView);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void PopulateStatusStrip()
        {
            customerLeadDetailStatusStripCustomerPlaceholder.Text = $"Customer: {_customerName} ({_customerId})";
        }

        private async Task LoadCustomerContactAsync(Guid customerId, Guid? customerContactId = null)
        {
            var parameters = new[]
                {
                    new StoredProcedureParameter
                    {
                        ParameterName = "customerId",
                        ParameterValue = customerId
                    }
                };

            if (customerContactId != null)
            {
                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox, "spGetAllCustomerContactForCustomer", null, true, "Customer Contact Id", customerContactId, false, null, null, parameters);
            }
            else
            {
                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox, "spGetAllCustomerContactForCustomer", null, false, null, null, false, null, null, parameters);
            }

            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadCustomerLeadTypeAsync(Guid customerLeadTypeId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerLeadDetailTabControlOverviewTabPageCustomerLeadTypeComboBox, "spGetAllCustomerLeadType", null, true, "Customer Lead Type Id", customerLeadTypeId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadMarketingChannelAsync(Guid marketingChannelId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelMarketingChannelComboBox, "spGetAllMarketingChannel", null, true, "Marketing Channel Id", marketingChannelId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async void CustomerLeadDetailCustomerContactChoiceRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (customerLeadDetailTabControlOverviewTabPageCustomerContactPanelYesRadioButton.Checked)
            {
                customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox.Enabled = true;
                await LoadCustomerContactAsync(_customerLeadId, customerLeadDetailTabControlOverviewTabPageCustomerContactIdOriginalValue);
            }
            else if (customerLeadDetailTabControlOverviewTabPageCustomerContactPanelNoRadioButton.Checked)
            {
                customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox.Enabled = false;
                customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox.DataSource = null;
            }
        }

        private async void CustomerLeadDetailMarketingChannelChoiceRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelYesRadioButton.Checked)
            {
                await LoadMarketingChannelAsync(customerLeadDetailTabControlOverviewTabPageMarketingChannelIdOriginalValue ?? Guid.Empty);
                customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelMarketingChannelComboBox.Enabled = true;
            }
            else if (customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelNoRadioButton.Checked)
            {
                customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelMarketingChannelComboBox.Enabled = false;
                customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelMarketingChannelComboBox.DataSource = null;
            }
        }

        private void CustomerLeadDetailTargetDateChoiceRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelYesRadioButton.Checked)
            {
                customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelTargetDatePicker.Enabled = true;
            }
            else if (customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelNoRadioButton.Checked)
            {
                customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelTargetDatePicker.Enabled = false;
                customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelTargetDatePicker.Value = DateTime.Now;
            }
        }

        private async void CustomerLeadDetailCustomerLeadInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            string dataSubject = "Customer Lead";
            string storedProcedureName = "spGetCustomerLead";

            var parameters = new[]
{
                new StoredProcedureParameter
                {
                    ParameterName = "customerLeadId",
                    ParameterValue = _customerLeadId
                }
            };

            try
            {
                DataTable? customerLeadTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject);

                if (customerLeadTable != null)
                {
                    DataRow customerLeadDataRow = customerLeadTable.Rows[0];
                    customerLeadDetailTabControlOverviewTabPageCustomerLeadIdTextBox.Text = customerLeadDataRow["Customer Lead Id"].ToString();
                    Guid customerLeadTypeId = (Guid)customerLeadDataRow["Customer Lead Type Id"];
                    await LoadCustomerLeadTypeAsync(customerLeadTypeId);
                    customerLeadDetailTabControlOverviewTabPageCustomerLeadTitleTextBox.Text = customerLeadDataRow["Customer Lead Title"].ToString();
                    customerLeadDetailTabControlOverviewTabPageCustomerLeadTextBox.Text = customerLeadDataRow["Customer Lead"].ToString();
                    if (customerLeadDataRow["Marketing Channel Id"] != DBNull.Value)
                    {
                        customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelYesRadioButton.Checked = true;
                        Guid marketingChannelId = (Guid)customerLeadDataRow["Marketing Channel Id"];
                        await LoadMarketingChannelAsync(marketingChannelId);
                    }
                    else
                    {
                        customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelNoRadioButton.Checked = true;
                    }
                    if (customerLeadDataRow["Customer Lead Target Date"] != DBNull.Value)
                    {
                        customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelYesRadioButton.Checked = true;
                        customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelTargetDatePicker.Value = (DateTime)customerLeadDataRow["Customer Lead Target Date"];
                    }
                    else
                    {
                        customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelNoRadioButton.Checked = true;
                    }
                    if (customerLeadDataRow["Customer Contact Id"] != DBNull.Value)
                    {
                        customerLeadDetailTabControlOverviewTabPageCustomerContactPanelYesRadioButton.Checked = true;
                        Guid customerContactId = (Guid)customerLeadDataRow["Customer Contact Id"];
                        await LoadCustomerContactAsync(customerContactId);
                    }
                    else
                    {
                        customerLeadDetailTabControlOverviewTabPageCustomerContactPanelNoRadioButton.Checked = true;
                    }
                    customerLeadDetailTabControlOverviewTabPageCreatedByTextBox.Text = customerLeadDataRow["Created By"].ToString();
                    customerLeadDetailTabControlOverviewTabPageCreatedTimestampTextBox.Text = customerLeadDataRow["Created Timestamp UTC"].ToString();
                    customerLeadDetailTabControlOverviewTabPageLastUpdatedByTextBox.Text = customerLeadDataRow["Modified By"].ToString();
                    customerLeadDetailTabControlOverviewTabPageLastUpdatedTimestampTextBox.Text = customerLeadDataRow["Modified Timestamp UTC"].ToString();
                    customerLeadDetailTabControlOverviewTabPageActiveStatusCheckBox.Checked = (bool)customerLeadDataRow["Active Status"];

                    customerLeadDetailTabControlOverviewTabPageActiveStatusOriginalValue = (bool)customerLeadDataRow["Active Status"];
                    if (customerLeadDataRow["Customer Contact Id"] != DBNull.Value)
                    {
                        customerLeadDetailTabControlOverviewTabPageCustomerContactIdOriginalValue = (Guid)customerLeadDataRow["Customer Contact Id"];
                    }
                    else
                    {
                        customerLeadDetailTabControlOverviewTabPageCustomerContactIdOriginalValue = null;
                    }
                    customerLeadDetailTabControlOverviewTabPageCustomerLeadOriginalValue = customerLeadDataRow["Customer Lead"].ToString();
                    if (customerLeadDataRow["Customer Lead Target Date"] != DBNull.Value)
                    {
                        customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDateOriginalValue = (DateTime)customerLeadDataRow["Customer Lead Target Date"];
                    }
                    else
                    {
                        customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDateOriginalValue = null;
                    }
                    customerLeadDetailTabControlOverviewTabPageCustomerLeadTitleOriginalValue = customerLeadDataRow["Customer Lead Title"].ToString();
                    customerLeadDetailTabControlOverviewTabPageCustomerLeadTypeIdOriginalValue = (Guid)customerLeadDataRow["Customer Lead Type Id"];
                    if (customerLeadDataRow["Marketing Channel Id"] != DBNull.Value)
                    {
                        customerLeadDetailTabControlOverviewTabPageMarketingChannelIdOriginalValue = (Guid)customerLeadDataRow["Marketing Channel Id"];
                    }
                    else
                    {
                        customerLeadDetailTabControlOverviewTabPageMarketingChannelIdOriginalValue = null;
                    }

                    this.Text += $" ({customerLeadDetailTabControlOverviewTabPageCustomerLeadTitleOriginalValue})";
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

        private async Task CustomerLeadDetailExistingCustomerLeadNote_Load(object sender, EventArgs e)
        {
            await DataAccessDataGridViewHelper.LoadDataGridViewAsync(
                _databaseConnectionSettings,
                _customerLeadId,
                "customerLeadId",
                "spGetAllNoteForCustomerLead",
                "Existing Customer Lead Notes",
                customerLeadDetailTabControlCustomerLeadNoteTabPageDataGridView,
                "Customer Lead Note Id",
                "View Customer Lead Note",
                "DESC",
                "Created Timestamp UTC"
            );
        }

        private void customerLeadDetailTabControlCustomerLeadNoteTabPageDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            DataAccessDataGridViewHelper.HandleDetailsCellClick(
            customerLeadDetailTabControlCustomerLeadNoteTabPageDataGridView,
            e,
            "Customer Lead Note Id",
            "Customer Lead Note",
            id => {
                var noteDetail = new NoteDetail(_customerLeadId, "CustomerLead", id, customerLeadDetailTabControlOverviewTabPageCustomerLeadTitleOriginalValue);
                noteDetail.Show();
            });
        }

        private async void CustomerLeadDetailTabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (customerLeadDetailTabControl.SelectedTab == customerLeadDetailTabControl.TabPages["customerLeadDetailTabControlCustomerLeadNoteTabPage"])
            {
                await CustomerLeadDetailExistingCustomerLeadNote_Load(sender, e);
            }
        }

        private async void customerLeadDetailUpdateCustomerLeadButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = customerLeadDetailTabControlOverviewTabPageActiveStatusCheckBox.Checked;
            Guid? customerContactId = null;
            if (customerLeadDetailTabControlOverviewTabPageCustomerContactPanelYesRadioButton.Checked)
            {
                customerContactId = (Guid)customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox.SelectedValue;
            }
            string customerLead = customerLeadDetailTabControlOverviewTabPageCustomerLeadTextBox.Text;
            DateTime? customerLeadTargetDate = null;
            if (customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelYesRadioButton.Checked)
            {
                customerLeadTargetDate = customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelTargetDatePicker.Value;
            }
            string customerLeadTitle = customerLeadDetailTabControlOverviewTabPageCustomerLeadTitleTextBox.Text;
            Guid customerLeadTypeId = (Guid)customerLeadDetailTabControlOverviewTabPageCustomerLeadTypeComboBox.SelectedValue;
            Guid? marketingChannelId = null;
            if (customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelYesRadioButton.Checked)
            {
                marketingChannelId = (Guid)customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelMarketingChannelComboBox.SelectedValue;
            }

            string dataSubject = "Customer Lead";

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
                    Name = "Active Status",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Customer Contact Id",
                    Value = customerContactId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Lead",
                    Value = customerLead,
                    MaxLength = 4000,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Customer Lead Target Date",
                    Value = customerLeadTargetDate,
                    ValueType = typeof(DateTime)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Lead Title",
                    Value = customerLeadTitle,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Lead Type Id",
                    Value = customerLeadTypeId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Marketing Channel Id",
                    Value = marketingChannelId,
                    ValueType = typeof(Guid)
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
                        VariableName = "Active Status",
                        VariableType = "bool",
                        OriginalValue = customerLeadDetailTabControlOverviewTabPageActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Contact Id",
                        VariableType = "Guid",
                        OriginalValue = customerLeadDetailTabControlOverviewTabPageCustomerContactIdOriginalValue ?? null,
                        NewValue = customerContactId
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Lead",
                        VariableType = "string",
                        OriginalValue = customerLeadDetailTabControlOverviewTabPageCustomerLeadOriginalValue,
                        NewValue = customerLead
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Lead Target Date",
                        VariableType = "DateTime",
                        OriginalValue = customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDateOriginalValue ?? null,
                        NewValue = customerLeadTargetDate
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Lead Title",
                        VariableType = "string",
                        OriginalValue = customerLeadDetailTabControlOverviewTabPageCustomerLeadTitleOriginalValue,
                        NewValue = customerLeadTitle
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Lead Type Id",
                        VariableType = "Guid",
                        OriginalValue = customerLeadDetailTabControlOverviewTabPageCustomerLeadTypeIdOriginalValue,
                        NewValue = customerLeadTypeId
                    },
                    new ChangeDetail
                    {
                        VariableName = "Marketing Channel Id",
                        VariableType = "Guid",
                        OriginalValue = customerLeadDetailTabControlOverviewTabPageMarketingChannelIdOriginalValue ?? null,
                        NewValue = marketingChannelId
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = UpdateConfirmationService.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
                {
                    var parameters = new List<StoredProcedureParameter>
                    {
                        new StoredProcedureParameter
                        {
                            ParameterName = "activeStatus",
                            ParameterValue = activeStatus
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "customerLead",
                            ParameterValue = customerLead
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "customerLeadId",
                            ParameterValue = _customerLeadId
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "customerLeadTitle",
                            ParameterValue = customerLeadTitle
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "customerLeadTypeId",
                            ParameterValue = customerLeadTypeId
                        }
                    };

                    if (customerContactId != null)
                    {
                        parameters.Add(new StoredProcedureParameter
                        {
                            ParameterName = "customerContactId",
                            ParameterValue = customerContactId
                        });
                    }

                    if (customerLeadTargetDate != null)
                    {
                        parameters.Add(new StoredProcedureParameter
                        {
                            ParameterName = "customerLeadTargetDate",
                            ParameterValue = customerLeadTargetDate
                        });
                    }

                    if (marketingChannelId != null)
                    {
                        parameters.Add(new StoredProcedureParameter
                        {
                            ParameterName = "marketingChannelId",
                            ParameterValue = marketingChannelId
                        });
                    }

                    string storedProcedureName = "spUpdateCustomerLead";
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

        private void customerLeadDetailTabControlCustomerLeadNoteTabPageCreateNewCustomerLeadNoteButton_Click(object sender, EventArgs e)
        {
            CreateNote createNote = new CreateNote(_customerLeadId, "CustomerLead", customerLeadDetailTabControlOverviewTabPageCustomerLeadTitleOriginalValue);
            createNote.Show();
        }

        private async void customerLeadDetailTabControlCustomerLeadNoteTabPageRefreshDataButton_Click(object sender, EventArgs e)
        {
            await CustomerLeadDetailExistingCustomerLeadNote_Load(sender, e);
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            CustomerLeadDetailCustomerLeadInformation_Load(this, EventArgs.Empty);
        }

        private void customerLeadDetailToggleEditModeButton_Click(object sender, EventArgs e)
        {
            customerLeadDetailTabControlOverviewTabPageActiveStatusCheckBox.Enabled = !customerLeadDetailTabControlOverviewTabPageActiveStatusCheckBox.Enabled;
            customerLeadDetailTabControlOverviewTabPageCustomerContactPanelYesRadioButton.Enabled = !customerLeadDetailTabControlOverviewTabPageCustomerContactPanelYesRadioButton.Enabled;
            customerLeadDetailTabControlOverviewTabPageCustomerContactPanelNoRadioButton.Enabled = !customerLeadDetailTabControlOverviewTabPageCustomerContactPanelNoRadioButton.Enabled;
            customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox.Enabled = !customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox.Enabled;
            customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelYesRadioButton.Enabled = !customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelYesRadioButton.Enabled;
            customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelNoRadioButton.Enabled = !customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelNoRadioButton.Enabled;
            customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelTargetDatePicker.Enabled = !customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelTargetDatePicker.Enabled;
            customerLeadDetailTabControlOverviewTabPageCustomerLeadTitleTextBox.ReadOnly = !customerLeadDetailTabControlOverviewTabPageCustomerLeadTitleTextBox.ReadOnly;
            customerLeadDetailTabControlOverviewTabPageCustomerLeadTextBox.ReadOnly = !customerLeadDetailTabControlOverviewTabPageCustomerLeadTextBox.ReadOnly;
            customerLeadDetailTabControlOverviewTabPageCustomerLeadTypeComboBox.Enabled = !customerLeadDetailTabControlOverviewTabPageCustomerLeadTypeComboBox.Enabled;
            customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelYesRadioButton.Enabled = !customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelYesRadioButton.Enabled;
            customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelNoRadioButton.Enabled = !customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelNoRadioButton.Enabled;
            customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelMarketingChannelComboBox.Enabled = !customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelMarketingChannelComboBox.Enabled;
        }
    }
}