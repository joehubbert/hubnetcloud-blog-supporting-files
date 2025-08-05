using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;
using System.Net.Mail;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateCustomerLead : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _customerId;

        public CreateCustomerLead(Guid customerId)
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadDatabaseConnectionSettingsAsync();
            _customerId = customerId;
            CreateCustomerLeadLoadCustomerLeadTypeAsync();
        }

        private void InitializeCustomComponents()
        {
            createCustomerLeadCustomerContactPanelNoRadioButton.CheckedChanged += new EventHandler(CreateCustomerLeadCustomerContactChoiceRadioButton_CheckedChanged);
            createCustomerLeadCustomerContactPanelYesRadioButton.CheckedChanged += new EventHandler(CreateCustomerLeadCustomerContactChoiceRadioButton_CheckedChanged);
            createCustomerLeadCustomerContactPanelCustomerContactComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            createCustomerLeadCustomerLeadTypeComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            createCustomerLeadMarketingChannelPanelNoRadioButton.CheckedChanged += new EventHandler(CreateCustomerLeadMarketingChannelChoiceRadioButton_CheckedChanged);
            createCustomerLeadMarketingChannelPanelYesRadioButton.CheckedChanged += new EventHandler(CreateCustomerLeadMarketingChannelChoiceRadioButton_CheckedChanged);
            createCustomerLeadMarketingChannelPanelMarketingChannelComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            createCustomerLeadCustomerLeadTargetDatePanelNoRadioButton.CheckedChanged += new EventHandler(CreateCustomerLeadTargetDateChoiceRadioButton_CheckedChanged);
            createCustomerLeadCustomerLeadTargetDatePanelYesRadioButton.CheckedChanged += new EventHandler(CreateCustomerLeadTargetDateChoiceRadioButton_CheckedChanged);
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void CreateCustomerLeadLoadCustomerContactAsync(Guid customerId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Customer Contact";

            try
            {
                string storedProcedureName = "[dbo].[spGetAllCustomerContactForCustomer]";


                var parameters = new[]
{
                    new Parameter
                    {
                        ParameterName = "@customerId",
                        ParameterValue = customerId
                    }
                };

                DataTable? customerContactData = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var customerContactList = customerContactData.AsEnumerable()
                    .Select(row => new
                    {
                        CustomerContactId = row.Field<Guid>("Customer Contact Id"),
                        DisplayText = $"{row.Field<string>("Customer Contact Last Name")}, {row.Field<string>("Customer Contact First Name")} - {row.Field<string>("Customer Contact Email Address")}"
                    })
                    .OrderBy(item => item.DisplayText)
                    .ToList();
                createCustomerLeadCustomerContactPanelCustomerContactComboBox.DataSource = customerContactList;
                createCustomerLeadCustomerContactPanelCustomerContactComboBox.DisplayMember = "DisplayText";
                createCustomerLeadCustomerContactPanelCustomerContactComboBox.ValueMember = "CustomerContactId";

                if( customerContactList.Count > 0)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.NoDataFound", dataSubject);
                    createCustomerLeadCustomerContactPanelCustomerContactComboBox.Enabled = false;
                    createCustomerLeadCustomerContactPanelCustomerContactComboBox.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async void CreateCustomerLeadLoadCustomerLeadTypeAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Customer Lead Type";

            try
            {
                string storedProcedureName = "[dbo].[spGetAllCustomerLeadType]";

                DataTable? customerLeadTypeData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var customerLeadTypeList = customerLeadTypeData.AsEnumerable()
                    .Select(row => new
                    {
                        CustomerLeadTypeId = row.Field<Guid>("Customer Lead Type Id"),
                        CustomerLeadType = row.Field<string>("Customer Lead Type")
                    })
                    .OrderBy(item => item.CustomerLeadType)
                    .ToList();
                createCustomerLeadCustomerLeadTypeComboBox.DataSource = customerLeadTypeList;
                createCustomerLeadCustomerLeadTypeComboBox.DisplayMember = "CustomerLeadType";
                createCustomerLeadCustomerLeadTypeComboBox.ValueMember = "CustomerLeadTypeId";
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async void CreateCustomerLeadLoadMarketingChannelAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Marketing Channel";

            try
            {
                string storedProcedureName = "[dbo].[spGetAllMarketingChannel]";                
                DataTable? marketingChannelData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var marketingChannelList = marketingChannelData.AsEnumerable()
                    .Select(row => new
                    {
                        MarketingChannelId = row.Field<Guid>("Marketing Channel Id"),
                        MarketingChannel = row.Field<string>("Marketing Channel")
                    })
                    .OrderBy(item => item.MarketingChannel)
                    .ToList();
                createCustomerLeadMarketingChannelPanelMarketingChannelComboBox.DataSource = marketingChannelList;
                createCustomerLeadMarketingChannelPanelMarketingChannelComboBox.DisplayMember = "MarketingChannel";
                createCustomerLeadMarketingChannelPanelMarketingChannelComboBox.ValueMember = "MarketingChannelId";
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

        private void CreateCustomerLeadCustomerContactChoiceRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCustomerLeadCustomerContactPanelYesRadioButton.Checked)
            {
                createCustomerLeadCustomerContactPanelCustomerContactComboBox.Enabled = true;
                CreateCustomerLeadLoadCustomerContactAsync(_customerId);
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
                CreateCustomerLeadLoadMarketingChannelAsync();
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
            string customerLead = createCustomerLeadCustomerLeadTextbox.Text.TrimEnd();
            string customerLeadTitle = createCustomerLeadCustomerLeadTitleTextbox.Text.TrimEnd();
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
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.ConnectionSettingsNotLoaded");
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
                    AllowNullValue = false,
                    Name = "CustomerLead",
                    Value = customerLead,
                    MaxLength = 4000,
                    ValueType = typeof(string)
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
                    Name = "CustomerLeadType",
                    Value = customerLeadType,
                    ValueType = typeof(Guid)
                }
            };

            if (customerContactId != null)
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "CustomerContactId",
                    Value = customerContactId,
                    ValueType = typeof(Guid)
                });
            }

            if (marketingChannelId != null)
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "MarketingChannelId",
                    Value = marketingChannelId,
                    ValueType = typeof(Guid)
                });
            }

            if (targetDate != null)
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "TargetDate",
                    Value = targetDate,
                    ValueType = typeof(DateTime)
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
                var parameters = new List<Parameter>
                {
                    new Parameter
                    {
                        ParameterName = "@activeStatus",
                        ParameterValue = activeStatus
                    },
                    new Parameter
                    {
                        ParameterName = "@customerLead",
                        ParameterValue = customerLead
                    },
                    new Parameter
                    {
                        ParameterName = "@customerLeadTitle",
                        ParameterValue = customerLeadTitle
                    },
                    new Parameter
                    {
                        ParameterName = "@customerLeadType",
                        ParameterValue = customerLeadType
                    }
                };

                if (customerContactId != null)
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@customerContactId",
                        ParameterValue = customerContactId
                    });
                }

                if (marketingChannelId != null)
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@marketingChannelId",
                        ParameterValue = marketingChannelId
                    });
                }

                if (targetDate != null)
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@targetDate",
                        ParameterValue = targetDate
                    });
                }

                string storedProcedureName = "[dbo].[spCreateCustomerLead]";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters.ToArray(), dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                this.Close();
            }
        }
    }
}