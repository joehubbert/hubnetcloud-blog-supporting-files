using CRM.Helpers;
using CRM.Interface;
using CRM.Model;
using CRM.Presentation.Note;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.CompanyManagement.CustomerLead
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

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            CustomerLeadDetailCustomerLeadInformation_Load(this, EventArgs.Empty);
        }

        private void InitializeEventHandlers()
        {
            customerLeadDetailTabControl.SelectedIndexChanged += customerLeadDetailTabControl_SelectedIndexChanged;
            customerLeadDetailTabControlCustomerLeadNoteTabPageDataGridView.CellContentClick += customerLeadDetailTabControlCustomerLeadNoteTabPageDataGridView_CellContentClick;
            customerLeadDetailTabControlOverviewTabPageCustomerContactPanelNoRadioButton.CheckedChanged += customerLeadDetailTabControlOverviewTabPageCustomerContactPanelRadioButton_CheckedChanged;
            customerLeadDetailTabControlOverviewTabPageCustomerContactPanelYesRadioButton.CheckedChanged += customerLeadDetailTabControlOverviewTabPageCustomerContactPanelRadioButton_CheckedChanged;
            customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerLeadDetailTabControlOverviewTabPageCustomerLeadTypeComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelNoRadioButton.CheckedChanged += customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelRadioButton_CheckedChanged;
            customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelYesRadioButton.CheckedChanged += customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelRadioButton_CheckedChanged;
            customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelMarketingChannelComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelNoRadioButton.CheckedChanged += customerLeadDetailTabControlOverviewTabPageTargetDatePanelRadioButton_CheckedChanged;
            customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelYesRadioButton.CheckedChanged += customerLeadDetailTabControlOverviewTabPageTargetDatePanelRadioButton_CheckedChanged;
            _dataGridViewQuickSearchHelper = new DataGridViewQuickSearchHelper(customerLeadDetailTabControlCustomerLeadNoteTabPageQuickFilterTextBox, customerLeadDetailTabControlCustomerLeadNoteTabPageDataGridView);
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
                DataTable? customerLeadTable = await DBInterface.ExecuteSelectStoredProcedureAsync(dataSubject, _databaseConnectionSettings, storedProcedureName, parameters);

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
                dataGridView: customerLeadDetailTabControlCustomerLeadNoteTabPageDataGridView,
                detailsColumnText: "View Customer Lead Note",
                functionTitle: FunctionTitle.CustomerLeadNote,
                idValue: _customerLeadId
            );
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
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
                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox,
                    FunctionTitle.CustomerContact,
                    null,
                    true,
                    "Customer Contact Id",
                    customerContactId,
                    false,
                    null,
                    null,
                    parameters,
                    true);
            }
            else
            {
                _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox,
                    FunctionTitle.CustomerContact,
                    null,
                    false,
                    null,
                    null,
                    false,
                    null,
                    null,
                    parameters,
                    false);
            }

            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadCustomerLeadTypeAsync(Guid customerLeadTypeId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerLeadDetailTabControlOverviewTabPageCustomerLeadTypeComboBox,
                FunctionTitle.CustomerLeadType,
                null,
                true,
                "Customer Lead Type Id",
                customerLeadTypeId,
                false,
                null,
                null,
                null,
                true);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadMarketingChannelAsync(Guid marketingChannelId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelMarketingChannelComboBox,
                FunctionTitle.MarketingChannel,
                null,
                true,
                "Marketing Channel Id",
                marketingChannelId,
                false,
                null,
                null,
                null,
                true);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private void PopulateStatusStrip()
        {
            customerLeadDetailStatusStripCustomerPlaceholder.Text = $"Customer: {_customerName} ({_customerId})";
        }

        private async void customerLeadDetailTabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (customerLeadDetailTabControl.SelectedTab == customerLeadDetailTabControl.TabPages["customerLeadDetailTabControlCustomerLeadNoteTabPage"])
            {
                await CustomerLeadDetailExistingCustomerLeadNote_Load(sender, e);
            }
        }

        private async void customerLeadDetailTabControlOverviewTabPageCustomerContactPanelRadioButton_CheckedChanged(object? sender, EventArgs e)
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

        private async void customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelRadioButton_CheckedChanged(object? sender, EventArgs e)
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

        private void customerLeadDetailTabControlOverviewTabPageTargetDatePanelRadioButton_CheckedChanged(object? sender, EventArgs e)
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

        private void customerLeadDetailTabControlCustomerLeadNoteTabPageDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            DataAccessDataGridViewHelper.HandleDetailsCellClick(
            customerLeadDetailTabControlCustomerLeadNoteTabPageDataGridView,
            e,
            FunctionTitle.CustomerLeadNote,
            id => {
                var noteDetail = new NoteDetail(_customerLeadId, FunctionTitle.CustomerLeadNote, ModuleGroup.CustomerManagement, id, customerLeadDetailTabControlOverviewTabPageCustomerLeadTitleOriginalValue);
                noteDetail.Show();
            });
        }

        private void customerLeadDetailTabControlCustomerLeadNoteTabPageCreateNewCustomerLeadNoteButton_Click(object sender, EventArgs e)
        {
            CreateNote createNote = new CreateNote(_customerLeadId, FunctionTitle.CustomerLeadNote, ModuleGroup.CustomerManagement, customerLeadDetailTabControlOverviewTabPageCustomerLeadTitleOriginalValue);
            createNote.Show();
        }

        private async void customerLeadDetailTabControlCustomerLeadNoteTabPageRefreshDataButton_Click(object sender, EventArgs e)
        {
            await CustomerLeadDetailExistingCustomerLeadNote_Load(sender, e);
        }

        private void customerLeadDetailToggleEditModeButton_Click(object? sender, EventArgs e)
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

        private async void customerLeadDetailUpdateCustomerLeadButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = customerLeadDetailTabControlOverviewTabPageActiveStatusCheckBox.Checked;
            Guid? customerContactId = null;
            if (customerLeadDetailTabControlOverviewTabPageCustomerContactPanelYesRadioButton.Checked)
            {
                customerContactId = (Guid)customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox.SelectedValue;
            }
            string customerLead = TextBoxCleanerHelper.GetTrimmedText(customerLeadDetailTabControlOverviewTabPageCustomerLeadTextBox);
            DateTime? customerLeadTargetDate = null;
            if (customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelYesRadioButton.Checked)
            {
                customerLeadTargetDate = customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelTargetDatePicker.Value;
            }
            string customerLeadTitle = TextBoxCleanerHelper.GetTrimmedText(customerLeadDetailTabControlOverviewTabPageCustomerLeadTitleTextBox);
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

            var dataToValidate = new List<DataValidationService.DataProperty>
            {
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Active Status",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Customer Contact Id",
                    Value = customerContactId,
                    ValueType = typeof(Guid)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Lead",
                    Value = customerLead,
                    MaxLength = 4000,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Customer Lead Target Date",
                    Value = customerLeadTargetDate,
                    ValueType = typeof(DateTime)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Lead Title",
                    Value = customerLeadTitle,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Lead Type Id",
                    Value = customerLeadTypeId,
                    ValueType = typeof(Guid)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Marketing Channel Id",
                    Value = marketingChannelId,
                    ValueType = typeof(Guid)
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
                var changesList = new List<ChangeDetail>
                {
                    new ChangeDetail
                    {
                        VariableName = "Active Status",
                        OriginalValue = customerLeadDetailTabControlOverviewTabPageActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Contact Id",
                        OriginalValue = customerLeadDetailTabControlOverviewTabPageCustomerContactIdOriginalValue ?? null,
                        NewValue = customerContactId
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Lead",
                        OriginalValue = customerLeadDetailTabControlOverviewTabPageCustomerLeadOriginalValue,
                        NewValue = customerLead
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Lead Target Date",
                        OriginalValue = customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDateOriginalValue ?? null,
                        NewValue = customerLeadTargetDate
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Lead Title",
                        OriginalValue = customerLeadDetailTabControlOverviewTabPageCustomerLeadTitleOriginalValue,
                        NewValue = customerLeadTitle
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Lead Type Id",
                        OriginalValue = customerLeadDetailTabControlOverviewTabPageCustomerLeadTypeIdOriginalValue,
                        NewValue = customerLeadTypeId
                    },
                    new ChangeDetail
                    {
                        VariableName = "Marketing Channel Id",
                        OriginalValue = customerLeadDetailTabControlOverviewTabPageMarketingChannelIdOriginalValue ?? null,
                        NewValue = marketingChannelId
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = ChangeValidationService.ConfirmChanges(changesList, dataSubject);

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
                    DataOperationType operationType = DataOperationType.Update;

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(dataSubject, _databaseConnectionSettings, operationType, storedProcedureName, parameters.ToArray()  );
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