using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateCustomerLead : Form
    {
        private readonly Guid _customerId;
        private readonly string _customerName;
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreateCustomerLead(Guid customerId, string customerName)
        {
            InitializeComponent();
            InitializeEventHandlers();
            LoadDatabaseConnectionSettingsAsync();
            _customerId = customerId;
            _customerName = customerName;
            PopulateStatusStrip();
            LoadCustomerLeadTypeAsync();
        }

        private void InitializeEventHandlers()
        {
            createCustomerLeadCustomerContactPanelNoRadioButton.CheckedChanged += CreateCustomerLeadCustomerContactChoiceRadioButton_CheckedChanged;
            createCustomerLeadCustomerContactPanelYesRadioButton.CheckedChanged += CreateCustomerLeadCustomerContactChoiceRadioButton_CheckedChanged;
            createCustomerLeadCustomerContactPanelCustomerContactComboBox.DropDown += AdjustComboBoxWidth_DropDown;
            createCustomerLeadCustomerLeadTypeComboBox.DropDown += AdjustComboBoxWidth_DropDown;
            createCustomerLeadMarketingChannelPanelNoRadioButton.CheckedChanged += CreateCustomerLeadMarketingChannelChoiceRadioButton_CheckedChanged;
            createCustomerLeadMarketingChannelPanelYesRadioButton.CheckedChanged += CreateCustomerLeadMarketingChannelChoiceRadioButton_CheckedChanged;
            createCustomerLeadMarketingChannelPanelMarketingChannelComboBox.DropDown += AdjustComboBoxWidth_DropDown;
            createCustomerLeadCustomerLeadTargetDatePanelNoRadioButton.CheckedChanged += CreateCustomerLeadTargetDateChoiceRadioButton_CheckedChanged;
            createCustomerLeadCustomerLeadTargetDatePanelYesRadioButton.CheckedChanged += CreateCustomerLeadTargetDateChoiceRadioButton_CheckedChanged;
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void PopulateStatusStrip()
        {
            createCustomerLeadCustomerPlaceholder.Text = $"Customer: {_customerName} ({_customerId})";
        }

        private async void LoadCustomerContactAsync(Guid customerId)
        {
            var parameters = new[]
                {
                    new Parameter
                    {
                        ParameterName = "customerId",
                        ParameterValue = customerId
                    }
                };

            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCustomerLeadCustomerContactPanelCustomerContactComboBox, "spGetAllCustomerContactForCustomer", null, false, null, null, false, null, null, parameters);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async void LoadCustomerLeadTypeAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCustomerLeadCustomerLeadTypeComboBox, "spGetAllCustomerLeadType");
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async void LoadMarketingChannelAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCustomerLeadMarketingChannelPanelMarketingChannelComboBox, "spGetAllMarketingChannel");
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDownHelper.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private void CreateCustomerLeadCustomerContactChoiceRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCustomerLeadCustomerContactPanelYesRadioButton.Checked)
            {
                createCustomerLeadCustomerContactPanelCustomerContactComboBox.Enabled = true;
                LoadCustomerContactAsync(_customerId);
            }
            else if (createCustomerLeadCustomerContactPanelNoRadioButton.Checked)
            {
                createCustomerLeadCustomerContactPanelCustomerContactComboBox.Enabled = false;
                createCustomerLeadCustomerContactPanelCustomerContactComboBox.DataSource = null;
            }
        }

        private void CreateCustomerLeadMarketingChannelChoiceRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCustomerLeadMarketingChannelPanelYesRadioButton.Checked)
            {
                LoadMarketingChannelAsync();
                createCustomerLeadMarketingChannelPanelMarketingChannelComboBox.Enabled = true;
            }
            else if (createCustomerLeadMarketingChannelPanelNoRadioButton.Checked)
            {
                createCustomerLeadMarketingChannelPanelMarketingChannelComboBox.Enabled = false;
                createCustomerLeadMarketingChannelPanelMarketingChannelComboBox.DataSource = null;
            }
        }

        private void CreateCustomerLeadTargetDateChoiceRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCustomerLeadCustomerLeadTargetDatePanelYesRadioButton.Checked)
            {
                createCustomerLeadCustomerLeadTargetDatePanelTargetDatePicker.Enabled = true;
            }
            else if (createCustomerLeadCustomerLeadTargetDatePanelNoRadioButton.Checked)
            {
                createCustomerLeadCustomerLeadTargetDatePanelTargetDatePicker.Enabled = false;
                createCustomerLeadCustomerLeadTargetDatePanelTargetDatePicker.Value = DateTime.Now;
            }
        }

        private async void createCustomerLeadSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createCustomerLeadActiveStatusCheckbox.Checked;
            Guid? customerContactId = null;
            if (createCustomerLeadCustomerContactPanelYesRadioButton.Checked)
            {
                customerContactId = (Guid)createCustomerLeadCustomerContactPanelCustomerContactComboBox.SelectedValue;
            }
            string customerLead = createCustomerLeadCustomerLeadTextBox.Text.TrimEnd();
            string customerLeadTitle = createCustomerLeadCustomerLeadTitleTextBox.Text.TrimEnd();
            Guid customerLeadType = (Guid)createCustomerLeadCustomerLeadTypeComboBox.SelectedValue;
            Guid? marketingChannelId = null;
            if (createCustomerLeadMarketingChannelPanelYesRadioButton.Checked)
            {
                marketingChannelId = (Guid)createCustomerLeadMarketingChannelPanelMarketingChannelComboBox.SelectedValue;
            }
            DateTime? targetDate = null;
            if (createCustomerLeadCustomerLeadTargetDatePanelYesRadioButton.Checked)
            {
                targetDate = createCustomerLeadCustomerLeadTargetDatePanelTargetDatePicker.Value;
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
                    AllowNullValue = false,
                    Name = "Customer Lead Title",
                    Value = customerLeadTitle,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Lead Type",
                    Value = customerLeadType,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Marketing Channel Id",
                    Value = marketingChannelId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Target Date",
                    Value = targetDate,
                    ValueType = typeof(DateTime)
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
                        ParameterName = "customerLeadTitle",
                        ParameterValue = customerLeadTitle
                    },
                    new Parameter
                    {
                        ParameterName = "customerLeadType",
                        ParameterValue = customerLeadType
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

                if (marketingChannelId != null)
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "marketingChannelId",
                        ParameterValue = marketingChannelId
                    });
                }

                if (targetDate != null)
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "targetDate",
                        ParameterValue = targetDate
                    });
                }

                string storedProcedureName = "spCreateCustomerLead";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters.ToArray(), dataSubject, operationType);
                this.Close();
            }
        }
    }
}