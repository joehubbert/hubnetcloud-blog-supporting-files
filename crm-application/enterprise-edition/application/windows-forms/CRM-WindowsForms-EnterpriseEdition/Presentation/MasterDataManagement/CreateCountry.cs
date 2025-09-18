using CRM.Helpers;
using CRM.Interface;
using CRM.Services;

namespace CRM.Presentation.MasterDataManagement
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
            bool activeStatus = createCountryActiveStatusCheckBox.Checked;
            string countryEnglishName = TextBoxCleanerHelper.GetTrimmedText(createCountryCountryEnglishNameTextBox);
            string iso31661A2CountryCode = TextBoxCleanerHelper.GetTrimmedText(createCountryISO31661A2CountryCodeMaskedTextBox).ToUpper();

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
                    AllowNullValue = false,
                    Name = "Country English Name",
                    Value = countryEnglishName,
                    MaxLength = 100,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ISO 3166-1 Alpha 2 Country Code",
                    Value = iso31661A2CountryCode,
                    MaxLength = 2,
                    ValueType = typeof(string)
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
                var parameters = new[]
                {
                    new StoredProcedureParameter
                    {
                        ParameterName = "activeStatus",
                        ParameterValue = activeStatus
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "countryEnglishName",
                        ParameterValue = countryEnglishName
                    },
                    new StoredProcedureParameter
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