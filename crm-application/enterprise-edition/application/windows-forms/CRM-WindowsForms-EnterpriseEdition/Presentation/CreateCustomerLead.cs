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
            createCustomerLeadCustomerContactChoiceNoRadioButton.CheckedChanged += new EventHandler(CreateCustomerLeadCustomerContactChoiceRadioButton_CheckedChanged);
            createCustomerLeadCustomerContactChoiceYesRadioButton.CheckedChanged += new EventHandler(CreateCustomerLeadCustomerContactChoiceRadioButton_CheckedChanged);
            createCustomerLeadCustomerContactComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            createCustomerLeadCustomerLeadTypeComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            createCustomerLeadMarketingChannelChoiceNoRadioButton.CheckedChanged += new EventHandler(CreateCustomerLeadMarketingChannelChoiceRadioButton_CheckedChanged);
            createCustomerLeadMarketingChannelChoiceYesRadioButton.CheckedChanged += new EventHandler(CreateCustomerLeadMarketingChannelChoiceRadioButton_CheckedChanged);
            createCustomerLeadMarketingChannelComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            createCustomerLeadCustomerLeadTargetDateChoiceNoRadioButton.CheckedChanged += new EventHandler(CreateCustomerLeadTargetDateChoiceRadioButton_CheckedChanged);
            createCustomerLeadCustomerLeadTargetDateChoiceYesRadioButton.CheckedChanged += new EventHandler(CreateCustomerLeadTargetDateChoiceRadioButton_CheckedChanged);
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
            try
            {
                string storedProcedureName = "[dbo].[spGetAllCustomerContactForCustomer]";
                string dataSubject = "Customer Contact";

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
                createCustomerLeadCustomerContactComboBox.DataSource = customerContactList;
                createCustomerLeadCustomerContactComboBox.DisplayMember = "DisplayText";
                createCustomerLeadCustomerContactComboBox.ValueMember = "CustomerContactId";

                if( customerContactList.Count > 0)
                {
                    MessageBox.Show("There are no Contacts defined for this Customer. Please create first and then try again.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    createCustomerLeadCustomerContactComboBox.Enabled = false;
                    createCustomerLeadCustomerContactComboBox.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Customer Contact data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CreateCustomerLeadLoadCustomerLeadTypeAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                string storedProcedureName = "[dbo].[spGetAllCustomerLeadType]";
                string dataSubject = "Customer Lead Type";
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
                MessageBox.Show($"Failed to load Customer Lead Type data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CreateCustomerLeadLoadMarketingChannelAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                string storedProcedureName = "[dbo].[spGetAllMarketingChannel]";
                string dataSubject = "Marketing Channel";
                DataTable? marketingChannelData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var marketingChannelList = marketingChannelData.AsEnumerable()
                    .Select(row => new
                    {
                        MarketingChannelId = row.Field<Guid>("Marketing Channel Id"),
                        MarketingChannel = row.Field<string>("Marketing Channel")
                    })
                    .OrderBy(item => item.MarketingChannel)
                    .ToList();
                createCustomerLeadMarketingChannelComboBox.DataSource = marketingChannelList;
                createCustomerLeadMarketingChannelComboBox.DisplayMember = "MarketingChannel";
                createCustomerLeadMarketingChannelComboBox.ValueMember = "MarketingChannelId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Country data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private void CreateCustomerLeadCustomerContactChoiceRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCustomerLeadCustomerContactChoiceYesRadioButton.Checked)
            {
                createCustomerLeadCustomerContactComboBox.Enabled = true;
                CreateCustomerLeadLoadCustomerContactAsync(_customerId);
            }
            else if (createCustomerLeadCustomerContactChoiceNoRadioButton.Checked)
            {
                createCustomerLeadCustomerContactComboBox.Enabled = false;
                createCustomerLeadCustomerContactComboBox.DataSource = null;
            }
        }

        private void CreateCustomerLeadMarketingChannelChoiceRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCustomerLeadMarketingChannelChoiceYesRadioButton.Checked)
            {
                CreateCustomerLeadLoadMarketingChannelAsync();
                createCustomerLeadMarketingChannelComboBox.Enabled = true;
            }
            else if (createCustomerLeadMarketingChannelChoiceNoRadioButton.Checked)
            {
                createCustomerLeadMarketingChannelComboBox.Enabled = false;
                createCustomerLeadMarketingChannelComboBox.DataSource = null;
            }
        }

        private void CreateCustomerLeadTargetDateChoiceRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCustomerLeadCustomerLeadTargetDateChoiceYesRadioButton.Checked)
            {
                createCustomerLeadCustomerLeadTargetDatePicker.Enabled = true;
            }
            else if (createCustomerLeadCustomerLeadTargetDateChoiceNoRadioButton.Checked)
            {
                createCustomerLeadCustomerLeadTargetDatePicker.Enabled = false;
                createCustomerLeadCustomerLeadTargetDatePicker.Value = DateTime.Now;
            }
        }

        private async void createCustomerLeadSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createCustomerLeadActiveStatusCheckbox.Checked;
            Guid? customerContactId = null;
            if (createCustomerLeadCustomerContactChoiceYesRadioButton.Checked)
            {
                customerContactId = (Guid)createCustomerLeadCustomerContactComboBox.SelectedValue;
            }
            string customerLead = createCustomerLeadCustomerLeadTextbox.Text.TrimEnd();
            string customerLeadTitle = createCustomerLeadCustomerLeadTitleTextbox.Text.TrimEnd();
            Guid customerLeadType = (Guid)createCustomerLeadCustomerLeadTypeComboBox.SelectedValue;
            Guid? marketingChannelId = null;
            if (createCustomerLeadMarketingChannelChoiceYesRadioButton.Checked)
            {
                marketingChannelId = (Guid)createCustomerLeadMarketingChannelComboBox.SelectedValue;
            }
            DateTime? targetDate = null;
            if (createCustomerLeadCustomerLeadTargetDateChoiceYesRadioButton.Checked)
            {
                targetDate = createCustomerLeadCustomerLeadTargetDatePicker.Value;
            }

            string dataSubject = "Customer Lead";

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