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

            var stringsToValidate = new List<ValidateStringInput.StringProperty>
            {
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerTierCode",
                    Value = customerTierCode,
                    MaxLength = 1
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerTierDescription",
                    Value = customerTierDescription,
                    MaxLength = 50
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