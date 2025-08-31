using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateTaxProfile : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Tax Profile";

        public CreateTaxProfile()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void createTaxProfileSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createTaxProfileActiveStatusCheckBox.Checked;
            string taxProfile = createTaxProfileTaxProfileTextBox.Text.TrimEnd();
            decimal taxRate = decimal.Parse(createTaxProfileTaxRateTextBoxA.Text.TrimEnd()) + (decimal.Parse(createTaxProfileTaxRateTextBoxB.Text.TrimEnd()) / 100);

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
                    Name = "Tax Profile",
                    Value = taxProfile,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Tax Rate",
                    Value = taxRate,
                    ValueType = typeof(decimal)
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
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, operationType);
                this.Close();
            }
        }
    }
}