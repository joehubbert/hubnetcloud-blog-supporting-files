using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class CustomerTierDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _customerTierId;
        private bool? customerTierDetailActiveStatusOriginalValue;
        private string? customerTierDetailCustomerTierCodeOriginalValue;
        private string? customerTierDetailCustomerTierDescriptionOriginalValue;
        private readonly string dataSubject = "Customer Tier";

        public CustomerTierDetail(Guid customerTierId)
        {
            InitializeComponent();
            _customerTierId = customerTierId;
            customerTierDetailToggleEditModeButton.Click += customerTierDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void ViewCustomerTierDetailCustomerTierInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string storedProcedureName = "[dbo].[spGetCustomerTier]";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@customerTierId",
                    ParameterValue = _customerTierId
                }
            };

            try
            {
                DataTable? customerTierDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (customerTierDataTable != null)
                {
                    DataRow customerTierDataRow = customerTierDataTable.Rows[0];
                    customerTierDetailCustomerTierIdTextbox.Text = customerTierDataRow["Customer Tier ID"].ToString();
                    customerTierDetailCustomerTierCodeTextbox.Text = customerTierDataRow["Customer Tier Code"].ToString();
                    customerTierDetailCustomerTierDescriptionTextbox.Text = customerTierDataRow["Customer Tier"].ToString();
                    customerTierDetailCreatedByTextbox.Text = customerTierDataRow["Created By"].ToString();
                    customerTierDetailCreatedTimestampTextbox.Text = customerTierDataRow["Created Timestamp"].ToString();
                    customerTierDetailLastUpdatedByTextbox.Text = customerTierDataRow["Modified By"].ToString();
                    customerTierDetailLastUpdatedTimestampTextbox.Text = customerTierDataRow["Modified Timestamp"].ToString();
                    customerTierDetailActiveStatusCheckbox.Checked = (bool)customerTierDataRow["Active Status"];

                    customerTierDetailCustomerTierCodeOriginalValue = customerTierDataRow["Customer Tier Code"].ToString();
                    customerTierDetailCustomerTierDescriptionOriginalValue = customerTierDataRow["Customer Tier"].ToString();
                    customerTierDetailActiveStatusOriginalValue = (bool)customerTierDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Customer Tier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Customer Tier details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void customerTierDetailUpdateCustomerTierButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = customerTierDetailActiveStatusCheckbox.Checked;
            string customerTierCode = customerTierDetailCustomerTierCodeTextbox.Text.TrimEnd();
            string customerTierDescription = customerTierDetailCustomerTierDescriptionTextbox.Text.TrimEnd();

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
                },
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
                        VariableName = "Customer Tier Code",
                        VariableType = "string",
                        OriginalValue = customerTierDetailCustomerTierCodeOriginalValue,
                        NewValue = customerTierCode
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Tier Description",
                        VariableType = "string",
                        OriginalValue = customerTierDetailCustomerTierDescriptionOriginalValue,
                        NewValue = customerTierDescription
                    },
                    new ChangeDetail
                    {
                        VariableName = "Active Status",
                        VariableType = "string",
                        OriginalValue = customerTierDetailActiveStatusOriginalValue,
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
                            ParameterName = "@customerTier",
                            ParameterValue = customerTierDescription
                        },
                        new Parameter
                        {
                            ParameterName = "@customerTierCode",
                            ParameterValue = customerTierCode
                        },
                        new Parameter
                        {
                            ParameterName = "@customerTierId",
                            ParameterValue = _customerTierId
                        }
                    };
                    string storedProcedureName = "[dbo].[spUpdateCustomerTier]";
                    string operationType = "update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Update details were cancelled, no changes have been made to the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            ViewCustomerTierDetailCustomerTierInformation_Load(this, EventArgs.Empty);
        }

        private void customerTierDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            customerTierDetailCustomerTierDescriptionTextbox.Enabled = !customerTierDetailCustomerTierDescriptionTextbox.Enabled;
            customerTierDetailActiveStatusCheckbox.Enabled = !customerTierDetailActiveStatusCheckbox.Enabled;
            customerTierDetailUpdateCustomerTierButton.Enabled = !customerTierDetailUpdateCustomerTierButton.Enabled;
        }
    }
}