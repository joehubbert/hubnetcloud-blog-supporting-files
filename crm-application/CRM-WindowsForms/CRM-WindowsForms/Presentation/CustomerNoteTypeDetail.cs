using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class CustomerNoteTypeDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _customerNoteTypeId;
        private bool ?customerNoteTypeDetailActiveStatusOriginalValue;
        private string ?customerNoteTypeDetailCustomerNoteTypeOriginalValue;
        private readonly string dataSubject = "Customer Note Type";

        public CustomerNoteTypeDetail(Guid customerNoteTypeId)
        {
            InitializeComponent();
            _customerNoteTypeId = customerNoteTypeId;
            customerNoteTypeDetailToggleEditModeButton.Click += customerNoteTypeDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void ViewCustomerNoteTypeDetailCustomerNoteTypeInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string storedProcedureName = "[dbo].[spGetCustomerNoteType]";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@customerNoteTypeId",
                    ParameterValue = _customerNoteTypeId
                }
            };

            try
            {
                DataTable? customerNoteTypeDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (customerNoteTypeDataTable != null)
                {
                    DataRow customerNoteTypeDataRow = customerNoteTypeDataTable.Rows[0];
                    customerNoteTypeDetailCustomerNoteTypeIdTextbox.Text = customerNoteTypeDataRow["Customer Note Type Id"].ToString();
                    customerNoteTypeDetailCustomerNoteTypeTextbox.Text = customerNoteTypeDataRow["Customer Note Type"].ToString();
                    customerNoteTypeDetailCreatedByTextbox.Text = customerNoteTypeDataRow["Created By"].ToString();
                    customerNoteTypeDetailCreatedTimestampTextbox.Text = customerNoteTypeDataRow["Created Timestamp"].ToString();
                    customerNoteTypeDetailLastUpdatedByTextbox.Text = customerNoteTypeDataRow["Modified By"].ToString();
                    customerNoteTypeDetailLastUpdatedTimestampTextbox.Text = customerNoteTypeDataRow["Modified Timestamp"].ToString();
                    customerNoteTypeDetailActiveStatusCheckbox.Checked = (bool)customerNoteTypeDataRow["Active Status"];

                    customerNoteTypeDetailCustomerNoteTypeOriginalValue = customerNoteTypeDataRow["Customer Note Type"].ToString();
                    customerNoteTypeDetailActiveStatusOriginalValue = (bool)customerNoteTypeDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Customer Note Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Customer Note Type details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void customerNoteTypeDetailUpdateCustomerNoteTypeButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = customerNoteTypeDetailActiveStatusCheckbox.Checked;
            string customerNoteType = customerNoteTypeDetailCustomerNoteTypeTextbox.Text.TrimEnd();

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
                    Name = "CustomerNoteType",
                    Value = customerNoteType,
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
                var changesList = new List<ChangeDetail>
                {
                    new ChangeDetail
                    {
                        VariableName = "Active Status",
                        VariableType = "string",
                        OriginalValue = customerNoteTypeDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Note Type",
                        VariableType = "string",
                        OriginalValue = customerNoteTypeDetailCustomerNoteTypeOriginalValue,
                        NewValue = customerNoteType
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = UpdateConfirmation.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
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
                            ParameterName = "@customerNoteType",
                            ParameterValue = customerNoteType
                        },
                        new Parameter
                        {
                            ParameterName = "@customerNoteTypeId",
                            ParameterValue = _customerNoteTypeId
                        }
                    };
                    string storedProcedureName = "[dbo].[spUpdateCustomerNoteType]";
                    string operationType = "update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Updates were cancelled, no changes have been made to the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            ViewCustomerNoteTypeDetailCustomerNoteTypeInformation_Load(this, EventArgs.Empty);
        }

        private void customerNoteTypeDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            customerNoteTypeDetailCustomerNoteTypeTextbox.Enabled = !customerNoteTypeDetailCustomerNoteTypeTextbox.Enabled;
            customerNoteTypeDetailActiveStatusCheckbox.Enabled = !customerNoteTypeDetailActiveStatusCheckbox.Enabled;
            customerNoteTypeDetailUpdateCustomerNoteTypeButton.Enabled = !customerNoteTypeDetailUpdateCustomerNoteTypeButton.Enabled;
        }
    }
}