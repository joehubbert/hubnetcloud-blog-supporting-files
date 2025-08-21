using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateContact : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _dataSubjectId;
        private readonly string _dataSubjectName;
        private readonly string _functionTitle;
        private readonly string applicationTitlePrefix = "CRM - Create ";
        private string createContactModuleContactEntityFriendlyName;
        private string createContactModuleContactCreateStoredProcedureName;
        private string createContactModuleContactCreateStoredProcedureDataSubjectParentParameterPrefix;
        private string createContactModuleContactTypeFriendlyName;

        public CreateContact(Guid dataSubjectId, string dataSubjectName, string functionTitle)
        {
            InitializeComponent();
            _dataSubjectId = dataSubjectId;
            _dataSubjectName = dataSubjectName;
            _functionTitle = functionTitle;
            SetModuleTheme();
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void SetModuleTheme()
        {
            switch (_functionTitle)
            {
                case "CustomerContact":
                    this.BackColor = Color.LightGreen;
                    createContactModuleContactEntityFriendlyName = "Customer";
                    createContactModuleContactCreateStoredProcedureName = "spCreateCustomerContact";
                    createContactModuleContactCreateStoredProcedureDataSubjectParentParameterPrefix = "customer";
                    createContactModuleContactTypeFriendlyName = "Customer Contact";
                    createContactStatusStripDataSubjectPlaceholder.Text = $"Customer: {_dataSubjectName} ({_dataSubjectId})";
                    break;
                case "SupplierContact":
                    this.BackColor = Color.MediumAquamarine;
                    createContactModuleContactEntityFriendlyName = "Supplier";
                    createContactModuleContactCreateStoredProcedureName = "spCreateSupplierContact";
                    createContactModuleContactCreateStoredProcedureDataSubjectParentParameterPrefix = "supplier";
                    createContactModuleContactTypeFriendlyName = "Supplier Contact";
                    createContactStatusStripDataSubjectPlaceholder.Text = $"Supplier: {_dataSubjectName} ({_dataSubjectId})";
                    break;
            }

            this.Text = $"{applicationTitlePrefix}{createContactModuleContactTypeFriendlyName}";
            createContactTitleLabel.Text = createContactModuleContactTypeFriendlyName;
            createContactActiveStatusCheckbox.Text = $"Active {createContactModuleContactEntityFriendlyName} Contact*";
        }

        private async void createContactSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createContactActiveStatusCheckbox.Checked;
            string emailAddress = createContactEmailAddressTextBox.Text.TrimEnd();
            string firstName = createContactFirstNameTextBox.Text.TrimEnd();
            string lastName = createContactLastNameTextBox.Text.TrimEnd();
            string role = createContactRoleTextBox.Text.TrimEnd();
            string telephoneNumber = createContactTelephoneNumberTextBox.Text.TrimEnd();

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
                    AllowNullValue = false,
                    Name = $"{createContactModuleContactEntityFriendlyName}Id",
                    Value = _dataSubjectId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Email Address",
                    Value = emailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "First Name",
                    Value = firstName,
                    MaxLength = 30,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Last Name",
                    Value = lastName,
                    MaxLength = 30,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Role",
                    Value = role,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Telephone Number",
                    Value = telephoneNumber,
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
                var parameters = new[]
                {
                    new Parameter
                    {
                        ParameterName = "activeStatus",
                        ParameterValue = activeStatus
                    },
                    new Parameter
                    {
                        ParameterName = $"{createContactModuleContactCreateStoredProcedureDataSubjectParentParameterPrefix}Id",
                        ParameterValue = _dataSubjectId
                    },
                    new Parameter
                    {
                        ParameterName = "emailAddress",
                        ParameterValue = emailAddress
                    },
                    new Parameter
                    {
                        ParameterName = "firstName",
                        ParameterValue = firstName
                    },
                    new Parameter
                    {
                        ParameterName = "lastName",
                        ParameterValue = lastName
                    },
                    new Parameter
                    {
                        ParameterName = "role",
                        ParameterValue = role
                    },
                    new Parameter
                    {
                        ParameterName = "telephoneNumber",
                        ParameterValue = telephoneNumber
                    }
                };

                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(
                    createContactModuleContactCreateStoredProcedureName,
                    parameters.ToArray(),
                    createContactModuleContactTypeFriendlyName,
                    operationType
                    );
                this.Close();
            }
        }
    }
}