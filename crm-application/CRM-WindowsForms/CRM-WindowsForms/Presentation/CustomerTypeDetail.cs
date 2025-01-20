using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class CustomerTypeDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Customer Type";
        private readonly Guid _customerTypeId;
        private bool? customerTypeDetailActiveStatusOriginalValue;
        private string? customerTypeDetailCustomerTypeOriginalValue;

        public CustomerTypeDetail(Guid customerTypeId)
        {
            InitializeComponent();
            _customerTypeId = customerTypeId;
            customerTypeDetailToggleEditModeButton.Click += customerTypeDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void ViewSupplierTypeDetailSupplierTypeInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string storedProcedureName = "[dbo].[spGetCustomerType]";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@customerTypeId",
                    ParameterValue = _customerTypeId
                }
            };

            try
            {
                DataTable? customerTypeDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (customerTypeDataTable != null)
                {
                    DataRow customerTypeDataRow = customerTypeDataTable.Rows[0];
                    customerTypeDetailCustomerTypeIdTextbox.Text = customerTypeDataRow["Customer Type ID"].ToString();
                    customerTypeDetailCustomerTypeTextbox.Text = customerTypeDataRow["Customer Type"].ToString();
                    customerTypeDetailCreatedByTextbox.Text = customerTypeDataRow["Created By"].ToString();
                    customerTypeDetailCreatedTimestampTextbox.Text = customerTypeDataRow["Created Timestamp"].ToString();
                    customerTypeDetailLastUpdatedByTextbox.Text = customerTypeDataRow["Modified By"].ToString();
                    customerTypeDetailLastUpdatedTimestampTextbox.Text = customerTypeDataRow["Modified Timestamp"].ToString();
                    customerTypeDetailActiveStatusCheckbox.Checked = (bool)customerTypeDataRow["Active Status"];

                    customerTypeDetailCustomerTypeOriginalValue = customerTypeDataRow["Customer Type"].ToString();
                    customerTypeDetailActiveStatusOriginalValue = (bool)customerTypeDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Customer Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Customer Type details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void customerTypeDetailUpdateCustomerTypeButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = customerTypeDetailActiveStatusCheckbox.Checked;
            string customerType = customerTypeDetailCustomerTypeTextbox.Text.TrimEnd();

            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var stringsToValidate = new List<ValidateStringInput.StringProperty>
            {
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerType",
                    Value = customerType,
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
                var changesList = new List<ChangeDetail>
                {
                    new ChangeDetail
                    {
                        VariableName = "Customer Type",
                        VariableType = "string",
                        OriginalValue = customerTypeDetailCustomerTypeOriginalValue,
                        NewValue = customerType
                    },
                    new ChangeDetail
                    {
                        VariableName = "Active Status",
                        VariableType = "string",
                        OriginalValue = customerTypeDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
                    }
                };

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
                            ParameterName = "@customerType",
                            ParameterValue = customerType
                        },
                        new Parameter
                        {
                            ParameterName = "@customerTypeId",
                            ParameterValue = _customerTypeId
                        }
                    };
                    string storedProcedureName = "[dbo].[spUpdateCustomerType]";
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
            ViewSupplierTypeDetailSupplierTypeInformation_Load(this, EventArgs.Empty);
        }

        private void customerTypeDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            customerTypeDetailCustomerTypeTextbox.Enabled = !customerTypeDetailCustomerTypeTextbox.Enabled;
            customerTypeDetailActiveStatusCheckbox.Enabled = !customerTypeDetailActiveStatusCheckbox.Enabled;
            customerTypeDetailUpdateCustomerTypeButton.Enabled = !customerTypeDetailUpdateCustomerTypeButton.Enabled;
        }
    }
}