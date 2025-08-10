using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateCountry : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Country";

        public CreateCountry()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void createCountrySubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createCountryActiveStatusCheckbox.Checked;
            string countryEnglishName = createCountryCountryEnglishNameTextbox.Text.TrimEnd();
            string iso31661A2CountryCode = createCountryISO31661A2CountryCodeTextbox.Text.TrimEnd().ToUpper();

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
                    AllowNullValue = false,
                    Name = "CountryEnglishName",
                    Value = countryEnglishName,
                    MaxLength = 100,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ISO31661A2CountryCode",
                    Value = iso31661A2CountryCode,
                    MaxLength = 2,
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
                        ParameterName = "activeStatus",
                        ParameterValue = activeStatus
                    },
                    new Parameter
                    {
                        ParameterName = "countryEnglishName",
                        ParameterValue = countryEnglishName
                    },
                    new Parameter
                    {
                        ParameterName = "iso31661A2CountryCode",
                        ParameterValue = iso31661A2CountryCode
                    }
                };
                string storedProcedureName = "spCreateCountry";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, operationType);
                this.Close();
            }
        }
    }
}