using CRM.Helpers;
using CRM.Interface;
using CRM.Services;

namespace CRM.Presentation.MasterDataManagement
{
    public partial class CreateTaxProfile : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private TextBoxNumericCharacterDataValidationHelper _textBoxNumericHelper;
        private readonly string dataSubject = "Tax Profile";

        public CreateTaxProfile()
        {
            InitializeComponent();
            _textBoxNumericHelper = new TextBoxNumericCharacterDataValidationHelper();
            InitializeEventHandlers();
            LoadDatabaseConnectionSettingsAsync();
        }

        private void InitializeEventHandlers()
        {
            createTaxProfileTaxRateTextBoxA.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            createTaxProfileTaxRateTextBoxB.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void createTaxProfileSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createTaxProfileActiveStatusCheckBox.Checked;
            string taxProfile = TextBoxCleanerHelper.GetTrimmedText(createTaxProfileTaxProfileTextBox);
            decimal taxRate = decimal.Parse($"{TextBoxCleanerHelper.GetTrimmedText(createTaxProfileTaxRateTextBoxA)}.{TextBoxCleanerHelper.GetTrimmedText(createTaxProfileTaxRateTextBoxB)}");

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
                    Name = "Tax Profile",
                    Value = taxProfile,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Tax Rate",
                    Value = taxRate,
                    ValueType = typeof(decimal)
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
                            ParameterName = "taxProfile",
                            ParameterValue = taxProfile
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "taxRate",
                            ParameterValue = taxRate
                        }
                    };
                string storedProcedureName = "spCreateTaxProfile";
                string operationType = "Create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, operationType);
                this.Close();
            }
        }
    }
}