using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;

namespace CRM_WindowsForms.Presentation
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
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var stringsToValidate = new List<ValidateStringInput.StringProperty>
            {
                new ValidateStringInput.StringProperty
                {
                    Name = "EmailAddress",
                    Value = emailAddress,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "FirstName",
                    Value = firstName,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "LastName",
                    Value = lastName,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "TelephoneNumber",
                    Value = telephoneNumber,
                    MaxLength = 13
                }
            };

            var validationResult = ValidateStringInput.ValidateInput(stringsToValidate);

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