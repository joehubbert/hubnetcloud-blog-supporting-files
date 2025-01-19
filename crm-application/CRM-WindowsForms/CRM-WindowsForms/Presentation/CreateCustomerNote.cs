using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreateCustomerNote : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _customerId;
        private readonly string dataSubject = "Customer Note";

        public CreateCustomerNote(Guid customerId)
        {
            InitializeComponent();
            InitializeCustomComponents();
            _customerId = customerId;
            CreateCustomerNoteLoadNoteTypeAsync();
        }

        private void InitializeCustomComponents()
        {
            createCustomerNoteCustomerNoteTypeComboBox.DropDown += new EventHandler(CreateCustomerNoteCustomerNoteTypeComboBox_DropDown);
        }

        private async void CreateCustomerNoteLoadNoteTypeAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                string storedProcedureName = "[dbo].[spGetAllCustomerNoteType]";
                string dataSubject = "Customer Note Type";
                DataTable? customerNoteTypeData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var customerNoteTypeList = customerNoteTypeData.AsEnumerable()
                    .Select(row => new
                    {
                        CustomerNoteTypeId = row.Field<Guid>("Customer Note Type Id"),
                        CustomerNoteType = row.Field<string>("Customer Note Type")
                    })
                    .OrderBy(item => item.CustomerNoteType)
                    .ToList();
                createCustomerNoteCustomerNoteTypeComboBox.DataSource = customerNoteTypeList;
                createCustomerNoteCustomerNoteTypeComboBox.DisplayMember = "CustomerNoteType";
                createCustomerNoteCustomerNoteTypeComboBox.ValueMember = "CustomerNoteTypeId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Customer Note Type data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateCustomerNoteCustomerNoteTypeComboBox_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void createCustomerSubmitButton_Click(object sender, EventArgs e)
        {
            Guid customerId = _customerId;
            string customerNote = createCustomerNoteCustomerNoteTextbox.Text.TrimEnd();
            string customerNoteTitle = createCustomerNoteCustomerNoteTitleTextbox.Text.TrimEnd();
            Guid customerNoteTypeId = Guid.Parse(createCustomerNoteCustomerNoteTypeComboBox.SelectedValue.ToString());

            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var stringsToValidate = new List<ValidateStringInput.StringProperty>
            {
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerNoteTitle",
                    Value = customerNoteTitle,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerNote",
                    Value = customerNote,
                    MaxLength = 1073741823
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
                            ParameterName = "@customerId",
                            ParameterValue = customerId
                        },
                        new Parameter
                        {
                            ParameterName = "@customerNote",
                            ParameterValue = customerNote
                        },
                        new Parameter
                        {
                            ParameterName = "@customerNoteTitle",
                            ParameterValue = customerNoteTitle
                        },
                        new Parameter
                        {
                            ParameterName = "@customerNoteTypeId",
                            ParameterValue = customerNoteTypeId
                        }
                };
                string storedProcedureName = "[dbo].[spCreateCustomerNote]";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                this.Close();
            }
        }
    }
}