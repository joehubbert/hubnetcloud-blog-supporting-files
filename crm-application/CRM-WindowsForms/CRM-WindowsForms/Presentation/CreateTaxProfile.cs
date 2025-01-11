using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;

namespace CRM_WindowsForms.Presentation
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
            bool activeStatus = createTaxProfileActiveStatusCheckbox.Checked;
            string taxProfile = createTaxProfileTaxProfileTextbox.Text.TrimEnd();
            decimal taxRate = decimal.Parse(createTaxProfileTaxRateTextboxA.Text.TrimEnd()) + (decimal.Parse(createTaxProfileTaxRateTextboxB.Text.TrimEnd()) / 100);

            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var stringsToValidate = new List<ValidateStringInput.StringProperty>
            {
                new ValidateStringInput.StringProperty
                {
                    Name = "TaxProfile",
                    Value = taxProfile,
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
                            ParameterName = "@taxProfile",
                            ParameterValue = taxProfile
                        },
                        new Parameter
                        {
                            ParameterName = "@taxRate",
                            ParameterValue = taxRate
                        }
                    };
                string storedProcedureName = "[dbo].[spCreateTaxProfile]";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                this.Close();
            }
        }
    }
}