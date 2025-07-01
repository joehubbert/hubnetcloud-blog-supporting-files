using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateContact : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _dataSubjectId;
        private readonly string _functionTitle;
        private readonly string applicationTitlePrefix = "CRM - Create ";
        private string createContactModuleContactEntityFriendlyName;
        private string createContactModuleContactCreateStoredProcedureName;
        private string createContactModuleContactCreateStoredProcedureDataSubjectParentParameterPrefix;
        private string createContactModuleContactTypeFriendlyName;

        public CreateContact(Guid dataSubjectId, string functionTitle)
        {
            InitializeComponent();
            _dataSubjectId = dataSubjectId;
            _functionTitle = functionTitle;
            SetModuleTheme(_functionTitle);
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void SetModuleTheme(string functionTitle)
        {
            switch (functionTitle)
            {
                case "CustomerContact":
                    this.BackColor = Color.LightGreen;
                    createContactModuleContactEntityFriendlyName = "Customer";
                    createContactModuleContactCreateStoredProcedureName = "[dbo].[spCreateCustomerContact]";
                    createContactModuleContactCreateStoredProcedureDataSubjectParentParameterPrefix = "customer";
                    createContactModuleContactTypeFriendlyName = "Customer Contact";
                    break;
                case "SupplierContact":
                    this.BackColor = Color.MediumAquamarine;
                    createContactModuleContactEntityFriendlyName = "Supplier";
                    createContactModuleContactCreateStoredProcedureName = "[dbo].[spCreateSupplierContact]";
                    createContactModuleContactCreateStoredProcedureDataSubjectParentParameterPrefix = "supplier";
                    createContactModuleContactTypeFriendlyName = "Supplier Contact";
                    break;
            }

            this.Text = $"{applicationTitlePrefix}{createContactModuleContactTypeFriendlyName}";
            createContactTitleLabel.Text = createContactModuleContactTypeFriendlyName;
        }

        private async void createContactSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createContactActiveStatusCheckbox.Checked;
            string emailAddress = createContactEmailAddressTextbox.Text.TrimEnd();
            string firstName = createContactFirstNameTextbox.Text.TrimEnd();
            string lastName = createContactLastNameTextbox.Text.TrimEnd();
            string role = createContactRoleTextbox.Text.TrimEnd();
            string telephoneNumber = createContactTelephoneNumberTextbox.Text.TrimEnd();

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
                    Name = $"{createContactModuleContactEntityFriendlyName}Id",
                    Value = _dataSubjectId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "EmailAddress",
                    Value = emailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "FirstName",
                    Value = firstName,
                    MaxLength = 30,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "LastName",
                    Value = lastName,
                    MaxLength = 30,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Role",
                    Value = role,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "TelephoneNumber",
                    Value = telephoneNumber,
                    ValueType = typeof(string)
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
                var parameters = new[]
                {
                    new Parameter
                    {
                        ParameterName = "@activeStatus",
                        ParameterValue = activeStatus
                    },
                    new Parameter
                    {
                        ParameterName = $"@{createContactModuleContactCreateStoredProcedureDataSubjectParentParameterPrefix}Id",
                        ParameterValue = _dataSubjectId
                    },
                    new Parameter
                    {
                        ParameterName = "@emailAddress",
                        ParameterValue = emailAddress
                    },
                    new Parameter
                    {
                        ParameterName = "@firstName",
                        ParameterValue = firstName
                    },
                    new Parameter
                    {
                        ParameterName = "@lastName",
                        ParameterValue = lastName
                    },
                    new Parameter
                    {
                        ParameterName = "@role",
                        ParameterValue = role
                    },
                    new Parameter
                    {
                        ParameterName = "@telephoneNumber",
                        ParameterValue = telephoneNumber
                    }
                };

                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(
                    createContactModuleContactCreateStoredProcedureName,
                    parameters.ToArray(),
                    createContactModuleContactTypeFriendlyName,
                    _databaseConnectionSettings.DatabaseConnectionString,
                    operationType
                    );
                this.Close();
            }
        }
    }
}