using CRM.Helpers;
using CRM.Interface;
using CRM.Services;

namespace CRM.Presentation.MasterDataManagement
{
    public partial class CreateCurrency : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Currency";

        public CreateCurrency()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void createCurrencySubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createCurrencyActiveStatusCheckBox.Checked;
            string currencyCode = TextBoxCleanerHelper.GetTrimmedText(createCurrencyCurrencyCodeMaskedTextBox);
            string currencyName = TextBoxCleanerHelper.GetTrimmedText(createCurrencyCurrencyNameTextBox);

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
                    Name = "Currency Code",
                    Value = currencyCode,
                    MaxLength = 3,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Currency Name",
                    Value = currencyName,
                    MaxLength = 50,
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
                        ParameterName = "currencyCode",
                        ParameterValue = currencyCode
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "currencyName",
                        ParameterValue = currencyName
                    }
                };
                string storedProcedureName = "spCreateCurrency";
                string operationType = "Create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, operationType);
                this.Close();
            }
        }
    }
}