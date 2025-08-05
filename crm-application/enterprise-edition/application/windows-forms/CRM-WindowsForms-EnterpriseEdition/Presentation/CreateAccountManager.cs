using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateAccountManager : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Account Manager";

        public CreateAccountManager()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void createAccountManagerSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createAccountManagerActiveStatusCheckbox.Checked;
            string emailAddress = createAccountManagerEmailAddressTextbox.Text.TrimEnd();
            string firstName = createAccountManagerFirstNameTextbox.Text.TrimEnd();
            string lastName = createAccountManagerLastNameTextbox.Text.TrimEnd();
            string telephoneNumber = createAccountManagerTelephoneNumberTextbox.Text.TrimEnd();

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
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "LastName",
                    Value = lastName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "TelephoneNumber",
                    Value = telephoneNumber,
                    MaxLength = 13,
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
                        ParameterName = "@telephoneNumber",
                        ParameterValue = telephoneNumber
                    }
                };
                string storedProcedureName = "[dbo].[spCreateAccountManager]";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                this.Close();
            }
        }
    }
}