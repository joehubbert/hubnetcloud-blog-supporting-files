using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreateCustomerTier : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Customer Tier";

        public CreateCustomerTier()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void createCustomerTierSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createCustomerTierActiveStatusCheckbox.Checked;
            string customerTierCode = createCustomerTierCustomerTierCodeTextbox.Text.TrimEnd();
            string customerTierDescription = createCustomerTierCustomerTierDescriptionTextbox.Text.TrimEnd();

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
                    Name = "CustomerTierCode",
                    Value = customerTierCode,
                    MaxLength = 1,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false;
                    Name = "CustomerTierDescription",
                    Value = customerTierDescription,
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
                        ParameterName = "@customerTier",
                        ParameterValue = customerTierDescription
                    },
                    new Parameter
                    {
                        ParameterName = "@customerTierCode",
                        ParameterValue = customerTierCode
                    }
                };
                string storedProcedureName = "[dbo].[spCreateCustomerTier]";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                this.Close();
            }
        }
    }
}