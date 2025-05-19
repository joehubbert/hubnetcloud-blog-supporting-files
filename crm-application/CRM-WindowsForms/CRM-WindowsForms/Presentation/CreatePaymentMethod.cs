using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreatePaymentMethod : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Payment Method";

        public CreatePaymentMethod()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void createPaymentMethodSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createPaymentMethodActiveStatusCheckbox.Checked;
            string paymentMethod = createPaymentMethodPaymentMethodTextbox.Text.TrimEnd();

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
                    Name = "PaymentMethod",
                    Value = paymentMethod,
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
                        ParameterName = "@paymentMethod",
                        ParameterValue = paymentMethod
                    }
                };
                string storedProcedureName = "[dbo].[spCreatePaymentMethod]";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                this.Close();
            }
        }
    }
}