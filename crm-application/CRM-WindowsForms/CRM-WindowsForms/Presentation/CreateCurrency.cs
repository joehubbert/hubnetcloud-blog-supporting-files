using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;

namespace CRM_WindowsForms.Presentation
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
            bool activeStatus = createCurrencyActiveStatusCheckbox.Checked;
            string currencyCode = createCurrencyCurrencyCodeTextbox.Text.TrimEnd();
            string currencyName = createCurrencyCurrencyNameTextbox.Text.TrimEnd();

            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dataToValidate = new List<ValidateDataInput.DataProperty>
            {
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false;
                    Name = "ActiveStatus",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false;
                    Name = "CurrencyCode",
                    Value = currencyCode,
                    MaxLength = 1,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false;
                    Name = "CurrencyName",
                    Value = currencyName,
                    MaxLength = 50,
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
                        ParameterName = "@currencyCode",
                        ParameterValue = currencyCode
                    },
                    new Parameter
                    {
                        ParameterName = "@currencyName",
                        ParameterValue = currencyName
                    }
                };
                string storedProcedureName = "[dbo].[spCreateCurrency]";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                this.Close();
            }
        }
    }
}