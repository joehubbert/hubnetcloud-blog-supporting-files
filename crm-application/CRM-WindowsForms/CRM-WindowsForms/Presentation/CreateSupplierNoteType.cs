using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreateSupplierNoteType : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Supplier Note Type";

        public CreateSupplierNoteType()
        {
            InitializeComponent();
            LoadDatabaseConnectionSettingsAsync();
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void createSupplierNoteTypeSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createSupplierNoteTypeActiveStatusCheckbox.Checked;
            string supplierNoteType = createSupplierNoteTypeSupplierNoteTypeTextbox.Text.TrimEnd();

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
                    Name = "SupplierNoteType",
                    Value = supplierNoteType,
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
                            ParameterName = "@supplierNoteType",
                            ParameterValue = supplierNoteType
                        }
                    };
                string storedProcedureName = "[dbo].[spCreateSupplierNoteType]";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                this.Close();
            }
        }
    }
}