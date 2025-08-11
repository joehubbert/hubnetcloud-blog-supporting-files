using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CustomerLeadDetail : Form
    {
        private readonly Guid _customerId;
        private readonly Guid _customerLeadId;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private bool customerLeadDetailTabControlOverviewTabPageActiveStatusOriginalValue;
        private Guid? customerLeadDetailTabControlOverviewTabPageCustomerContactIdOriginalValue;
        private string customerLeadDetailTabControlOverviewTabPageCustomerLeadOriginalValue;
        private DateTime? customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDateOriginalValue;
        private string customerLeadDetailTabControlOverviewTabPageCustomerLeadTitleOriginalValue;
        private Guid customerLeadDetailTabControlOverviewTabPageCustomerLeadTypeIdOriginalValue;
        private Guid? customerLeadDetailTabControlOverviewTabPageMarketingChannelIdOriginalValue;

        public CustomerLeadDetail(Guid customerId, Guid customerLeadId)
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadDatabaseConnectionSettingsAsync();
            _customerId = customerId;
            _customerLeadId = customerLeadId;
        }

        private void InitializeCustomComponents()
        {
            customerLeadDetailTabControl.SelectedIndexChanged += new EventHandler(CustomerLeadDetailTabControl_SelectedIndexChanged);
            customerLeadDetailTabControlOverviewTabPageCustomerContactPanelNoRadioButton.CheckedChanged += new EventHandler(CustomerLeadDetailCustomerContactChoiceRadioButton_CheckedChanged);
            customerLeadDetailTabControlOverviewTabPageCustomerContactPanelYesRadioButton.CheckedChanged += new EventHandler(CustomerLeadDetailCustomerContactChoiceRadioButton_CheckedChanged);
            customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            customerLeadDetailTabControlOverviewTabPageCustomerLeadTypeComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelNoRadioButton.CheckedChanged += new EventHandler(CustomerLeadDetailMarketingChannelChoiceRadioButton_CheckedChanged);
            customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelYesRadioButton.CheckedChanged += new EventHandler(CustomerLeadDetailMarketingChannelChoiceRadioButton_CheckedChanged);
            customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelMarketingChannelComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelNoRadioButton.CheckedChanged += new EventHandler(CustomerLeadDetailTargetDateChoiceRadioButton_CheckedChanged);
            customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelYesRadioButton.CheckedChanged += new EventHandler(CustomerLeadDetailTargetDateChoiceRadioButton_CheckedChanged);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task CustomerLeadDetailLoadCustomerContactAsync(Guid customerContactId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Customer Contact";

            try
            {
                string storedProcedureName = "spGetAllCustomerContactForCustomer";

                var parameters = new[]
                {
                    new Parameter
                    {
                        ParameterName = "customerId",
                        ParameterValue = _customerId
                    }
                };

                DataTable? customerContactData = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject);

                var customerContactList = customerContactData.AsEnumerable()
                    .Select(row => new
                    {
                        CustomerContactId = row.Field<Guid>("Customer Contact Id"),
                        DisplayText = $"{row.Field<string>("Customer Contact Last Name")}, {row.Field<string>("Customer Contact First Name")} - {row.Field<string>("Customer Contact Email Address")}"
                    })
                    .OrderBy(item => item.DisplayText)
                    .ToList();
                customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox.DataSource = customerContactList;
                customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox.DisplayMember = "DisplayText";
                customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox.ValueMember = "CustomerContactId";
                customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox.SelectedValue = customerContactId;

                if (customerContactList.Count > 0)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.NoDataFound", dataSubject);
                    customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox.Enabled = false;
                    customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async Task CustomerLeadDetailLoadCustomerLeadTypeAsync(Guid customerLeadTypeId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Customer Lead Type";

            try
            {
                string storedProcedureName = "spGetAllCustomerLeadType";

                DataTable? customerLeadTypeData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject);

                var customerLeadTypeList = customerLeadTypeData.AsEnumerable()
                    .Select(row => new
                    {
                        CustomerLeadTypeId = row.Field<Guid>("Customer Lead Type Id"),
                        CustomerLeadType = row.Field<string>("Customer Lead Type")
                    })
                    .OrderBy(item => item.CustomerLeadType)
                    .ToList();
                customerLeadDetailTabControlOverviewTabPageCustomerLeadTypeComboBox.DataSource = customerLeadTypeList;
                customerLeadDetailTabControlOverviewTabPageCustomerLeadTypeComboBox.DisplayMember = "CustomerLeadType";
                customerLeadDetailTabControlOverviewTabPageCustomerLeadTypeComboBox.ValueMember = "CustomerLeadTypeId";
                customerLeadDetailTabControlOverviewTabPageCustomerLeadTypeComboBox.SelectedValue = customerLeadTypeId;
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async Task CustomerLeadDetailLoadMarketingChannelAsync(Guid marketingChannelId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Marketing Channel";

            try
            {
                string storedProcedureName = "spGetAllMarketingChannel";
                DataTable? marketingChannelData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject);

                var marketingChannelList = marketingChannelData.AsEnumerable()
                    .Select(row => new
                    {
                        MarketingChannelId = row.Field<Guid>("Marketing Channel Id"),
                        MarketingChannel = row.Field<string>("Marketing Channel")
                    })
                    .OrderBy(item => item.MarketingChannel)
                    .ToList();
                customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelMarketingChannelComboBox.DataSource = marketingChannelList;
                customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelMarketingChannelComboBox.DisplayMember = "MarketingChannel";
                customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelMarketingChannelComboBox.ValueMember = "MarketingChannelId";
                customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelMarketingChannelComboBox.SelectedValue = marketingChannelId;
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void CustomerLeadDetailCustomerContactChoiceRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (customerLeadDetailTabControlOverviewTabPageCustomerContactPanelYesRadioButton.Checked)
            {
                customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox.Enabled = true;
                await CustomerLeadDetailLoadCustomerContactAsync(_customerLeadId);
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
                await CustomerLeadDetailLoadMarketingChannelAsync(customerLeadDetailTabControlOverviewTabPageMarketingChannelIdOriginalValue ?? Guid.Empty);
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
                new Parameter
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
                    customerLeadDetailTabControlOverviewTabPageCustomerLeadIdTextbox.Text = customerLeadDataRow["Customer Lead Id"].ToString();
                    Guid customerLeadTypeId = (Guid)customerLeadDataRow["Customer Lead Type Id"];
                    await CustomerLeadDetailLoadCustomerLeadTypeAsync(customerLeadTypeId);
                    customerLeadDetailTabControlOverviewTabPageCustomerLeadTitleTextbox.Text = customerLeadDataRow["Customer Lead Title"].ToString();
                    customerLeadDetailTabControlOverviewTabPageCustomerLeadTextbox.Text = customerLeadDataRow["Customer Lead"].ToString();
                    if (customerLeadDataRow["Marketing Channel Id"] != DBNull.Value)
                    {
                        customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelYesRadioButton.Checked = true;
                        Guid marketingChannelId = (Guid)customerLeadDataRow["Marketing Channel Id"];
                        await CustomerLeadDetailLoadMarketingChannelAsync(marketingChannelId);
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
                        await CustomerLeadDetailLoadCustomerContactAsync(customerContactId);
                    }
                    else
                    {
                        customerLeadDetailTabControlOverviewTabPageCustomerContactPanelNoRadioButton.Checked = true;
                    }
                    customerLeadDetailTabControlOverviewTabPageCreatedByTextbox.Text = customerLeadDataRow["Created By"].ToString();
                    customerLeadDetailTabControlOverviewTabPageCreatedTimestampTextbox.Text = customerLeadDataRow["Created Timestamp UTC"].ToString();
                    customerLeadDetailTabControlOverviewTabPageLastUpdatedByTextbox.Text = customerLeadDataRow["Modified By"].ToString();
                    customerLeadDetailTabControlOverviewTabPageLastUpdatedTimestampTextbox.Text = customerLeadDataRow["Modified Timestamp UTC"].ToString();
                    customerLeadDetailTabControlOverviewTabPageActiveStatusCheckbox.Checked = (bool)customerLeadDataRow["Active Status"];

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
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            string storedProcedureName = "spGetAllNoteForCustomerLead";
            string dataSubject = "Existing Customer Notes";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "customerLeadId",
                    ParameterValue = _customerLeadId
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
                customerLeadDetailTabControlCustomerLeadNoteTabPageDataGridView.AutoGenerateColumns = true;
                customerLeadDetailTabControlCustomerLeadNoteTabPageDataGridView.DataSource = dataTable;
                customerLeadDetailTabControlCustomerLeadNoteTabPageDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if (customerLeadDetailTabControlCustomerLeadNoteTabPageDataGridView.Columns.Contains("Details"))
                {
                    customerLeadDetailTabControlCustomerLeadNoteTabPageDataGridView.Columns.Remove("Details");
                }
                DataGridViewLinkColumn customerLeadNoteDetailLink = new DataGridViewLinkColumn
                {
                    HeaderText = "Details",
                    Text = "View Customer Lead Note",
                    UseColumnTextForLinkValue = true,
                    Name = "Details"
                };
                customerLeadDetailTabControlCustomerLeadNoteTabPageDataGridView.Columns.Add(customerLeadNoteDetailLink);
            }
        }

        private void customerLeadDetailTabControlCustomerLeadNoteTabPageDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == customerLeadDetailTabControlCustomerLeadNoteTabPageDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                string dataSubject = "Customer Lead Note";

                try
                {
                    if (customerLeadDetailTabControlCustomerLeadNoteTabPageDataGridView.Columns.Contains("Customer Lead Note Id"))
                    {
                        Guid customerLeadNoteId = (Guid)customerLeadDetailTabControlCustomerLeadNoteTabPageDataGridView.Rows[e.RowIndex].Cells["Customer Lead Note Id"].Value;
                        NoteDetail noteDetail = new NoteDetail("CustomerLead", customerLeadNoteId);
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

        private async void CustomerLeadDetailTabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (customerLeadDetailTabControl.SelectedTab == customerLeadDetailTabControl.TabPages["customerLeadDetailTabControlCustomerLeadNoteTabPage"])
            {
                await CustomerLeadDetailExistingCustomerLeadNote_Load(sender, e);
            }
        }

        private async void customerLeadDetailUpdateCustomerLeadButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = customerLeadDetailTabControlOverviewTabPageActiveStatusCheckbox.Checked;
            Guid? customerContactId = null;
            if (customerLeadDetailTabControlOverviewTabPageCustomerContactPanelYesRadioButton.Checked)
            {
                customerContactId = (Guid)customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox.SelectedValue;
            }
            string customerLead = customerLeadDetailTabControlOverviewTabPageCustomerLeadTextbox.Text;
            DateTime? customerLeadTargetDate = null;
            if (customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelYesRadioButton.Checked)
            {
                customerLeadTargetDate = customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelTargetDatePicker.Value;
            }
            string customerLeadTitle = customerLeadDetailTabControlOverviewTabPageCustomerLeadTitleTextbox.Text;
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

            var dataToValidate = new List<ValidateDataInput.DataProperty>
            {
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ActiveStatus",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "CustomerContactId",
                    Value = customerContactId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerLead",
                    Value = customerLead,
                    MaxLength = 4000,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "CustomerLeadTargetDate",
                    Value = customerLeadTargetDate,
                    ValueType = typeof(DateTime)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerLeadTitle",
                    Value = customerLeadTitle,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerLeadTypeId",
                    Value = customerLeadTypeId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "MarketingChannelId",
                    Value = marketingChannelId,
                    ValueType = typeof(Guid)
                }
            };

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

                bool confirmed = UpdateConfirmation.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
                {
                    var parameters = new List<Parameter>
                    {
                        new Parameter
                        {
                            ParameterName = "activeStatus",
                            ParameterValue = activeStatus
                        },
                        new Parameter
                        {
                            ParameterName = "customerLead",
                            ParameterValue = customerLead
                        },
                        new Parameter
                        {
                            ParameterName = "customerLeadId",
                            ParameterValue = _customerLeadId
                        },
                        new Parameter
                        {
                            ParameterName = "customerLeadTitle",
                            ParameterValue = customerLeadTitle
                        },
                        new Parameter
                        {
                            ParameterName = "customerLeadTypeId",
                            ParameterValue = customerLeadTypeId
                        }
                    };

                    if (customerContactId != null)
                    {
                        parameters.Add(new Parameter
                        {
                            ParameterName = "customerContactId",
                            ParameterValue = customerContactId
                        });
                    }

                    if (customerLeadTargetDate != null)
                    {
                        parameters.Add(new Parameter
                        {
                            ParameterName = "customerLeadTargetDate",
                            ParameterValue = customerLeadTargetDate
                        });
                    }

                    if (marketingChannelId != null)
                    {
                        parameters.Add(new Parameter
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
            customerLeadDetailTabControlOverviewTabPageActiveStatusCheckbox.Enabled = !customerLeadDetailTabControlOverviewTabPageActiveStatusCheckbox.Enabled;
            customerLeadDetailTabControlOverviewTabPageCustomerContactPanelYesRadioButton.Enabled = !customerLeadDetailTabControlOverviewTabPageCustomerContactPanelYesRadioButton.Enabled;
            customerLeadDetailTabControlOverviewTabPageCustomerContactPanelNoRadioButton.Enabled = !customerLeadDetailTabControlOverviewTabPageCustomerContactPanelNoRadioButton.Enabled;
            customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox.Enabled = !customerLeadDetailTabControlOverviewTabPageCustomerContactPanelCustomerContactComboBox.Enabled;
            customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelYesRadioButton.Enabled = !customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelYesRadioButton.Enabled;
            customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelNoRadioButton.Enabled = !customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelNoRadioButton.Enabled;
            customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelTargetDatePicker.Enabled = !customerLeadDetailTabControlOverviewTabPageCustomerLeadTargetDatePanelTargetDatePicker.Enabled;
            customerLeadDetailTabControlOverviewTabPageCustomerLeadTitleTextbox.ReadOnly = !customerLeadDetailTabControlOverviewTabPageCustomerLeadTitleTextbox.ReadOnly;
            customerLeadDetailTabControlOverviewTabPageCustomerLeadTextbox.ReadOnly = !customerLeadDetailTabControlOverviewTabPageCustomerLeadTextbox.ReadOnly;
            customerLeadDetailTabControlOverviewTabPageCustomerLeadTypeComboBox.Enabled = !customerLeadDetailTabControlOverviewTabPageCustomerLeadTypeComboBox.Enabled;
            customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelYesRadioButton.Enabled = !customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelYesRadioButton.Enabled;
            customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelNoRadioButton.Enabled = !customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelNoRadioButton.Enabled;
            customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelMarketingChannelComboBox.Enabled = !customerLeadDetailTabControlOverviewTabPageMarketingChannelPanelMarketingChannelComboBox.Enabled;
        }
    }
}
