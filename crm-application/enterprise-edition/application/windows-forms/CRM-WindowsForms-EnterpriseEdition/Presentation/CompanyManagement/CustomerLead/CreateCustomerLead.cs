using CRM.Helpers;
using CRM.Interface;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.CompanyManagement.CustomerLead
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
            createCustomerLeadCustomerContactPanelNoRadioButton.CheckedChanged += createCustomerLeadCustomerContactPanelRadioButton_CheckedChanged;
            createCustomerLeadCustomerContactPanelYesRadioButton.CheckedChanged += createCustomerLeadCustomerContactPanelRadioButton_CheckedChanged;
            createCustomerLeadCustomerContactPanelCustomerContactComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            createCustomerLeadCustomerLeadTypeComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            createCustomerLeadMarketingChannelPanelNoRadioButton.CheckedChanged += createCustomerLeadMarketingChannelPanelRadioButton_CheckedChanged;
            createCustomerLeadMarketingChannelPanelYesRadioButton.CheckedChanged += createCustomerLeadMarketingChannelPanelRadioButton_CheckedChanged;
            createCustomerLeadMarketingChannelPanelMarketingChannelComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            createCustomerLeadCustomerLeadTargetDatePanelNoRadioButton.CheckedChanged += createCustomerLeadTargetDatePanelRadioButton_CheckedChanged;
            createCustomerLeadCustomerLeadTargetDatePanelYesRadioButton.CheckedChanged += createCustomerLeadTargetDatePanelRadioButton_CheckedChanged;
        }

        private async void LoadCustomerContactAsync(Guid customerId)
        {
            var parameters = new[]
                {
                    new StoredProcedureParameter
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

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void LoadMarketingChannelAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCustomerLeadMarketingChannelPanelMarketingChannelComboBox, "spGetAllMarketingChannel");
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private void PopulateStatusStrip()
        {
            createCustomerLeadCustomerPlaceholder.Text = $"Customer: {_customerName} ({_customerId})";
        }

        private void createCustomerLeadCustomerContactPanelRadioButton_CheckedChanged(object? sender, EventArgs e)
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

        private void createCustomerLeadMarketingChannelPanelRadioButton_CheckedChanged(object? sender, EventArgs e)
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

        private async void createCustomerLeadSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createCustomerLeadActiveStatusCheckBox.Checked;
            Guid? customerContactId = null;
            if (createCustomerLeadCustomerContactPanelYesRadioButton.Checked)
            {
                customerContactId = (Guid)createCustomerLeadCustomerContactPanelCustomerContactComboBox.SelectedValue;
            }
            string customerLead = TextBoxCleanerHelper.GetTrimmedText(createCustomerLeadCustomerLeadTextBox);
            string customerLeadTitle = TextBoxCleanerHelper.GetTrimmedText(createCustomerLeadCustomerLeadTitleTextBox);
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
                    AllowNullValue = false,
                    Name = "Customer Lead Title",
                    Value = customerLeadTitle,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Lead Type",
                    Value = customerLeadType,
                    ValueType = typeof(Guid)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Marketing Channel Id",
                    Value = marketingChannelId,
                    ValueType = typeof(Guid)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Target Date",
                    Value = targetDate,
                    ValueType = typeof(DateTime)
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
                        ParameterName = "customerLeadTitle",
                        ParameterValue = customerLeadTitle
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "customerLeadType",
                        ParameterValue = customerLeadType
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

                if (marketingChannelId != null)
                {
                    parameters.Add(new StoredProcedureParameter
                    {
                        ParameterName = "marketingChannelId",
                        ParameterValue = marketingChannelId
                    });
                }

                if (targetDate != null)
                {
                    parameters.Add(new StoredProcedureParameter
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

        private void createCustomerLeadTargetDatePanelRadioButton_CheckedChanged(object? sender, EventArgs e)
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
    }
}