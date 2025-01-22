using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class SalesRegionDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Sales Region";
        private readonly Guid _salesRegionId;
        private bool? salesRegionDetailActiveStatusOriginalValue;
        private string? salesRegionDetailSalesRegionOriginalValue;

        public SalesRegionDetail(Guid salesRegionId)
        {
            InitializeComponent();
            _salesRegionId = salesRegionId;
            salesRegionDetailToggleEditModeButton.Click += salesRegionDetailToggleEditModeButton_Click;
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

            string storedProcedureName = "[dbo].[spGetSalesRegion]";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@salesRegionId",
                    ParameterValue = _salesRegionId
                }
            };

            try
            {
                DataTable? salesRegionDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (salesRegionDataTable != null)
                {
                    DataRow salesRegionDataRow = salesRegionDataTable.Rows[0];
                    salesRegionDetailSalesRegionIdTextbox.Text = salesRegionDataRow["Sales Region Id"].ToString();
                    salesRegionDetailSalesRegionTextbox.Text = salesRegionDataRow["Sales Region"].ToString();
                    salesRegionDetailCreatedByTextbox.Text = salesRegionDataRow["Created By"].ToString();
                    salesRegionDetailCreatedTimestampTextbox.Text = salesRegionDataRow["Created Timestamp"].ToString();
                    salesRegionDetailLastUpdatedByTextbox.Text = salesRegionDataRow["Modified By"].ToString();
                    salesRegionDetailLastUpdatedTimestampTextbox.Text = salesRegionDataRow["Modified Timestamp"].ToString();
                    salesRegionDetailActiveStatusCheckbox.Checked = (bool)salesRegionDataRow["Active Status"];

                    salesRegionDetailSalesRegionOriginalValue = salesRegionDataRow["Sales Region"].ToString();
                    salesRegionDetailActiveStatusOriginalValue = (bool)salesRegionDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Sales Region.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Sales Region details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void salesRegionDetailUpdateSalesRegionButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = salesRegionDetailActiveStatusCheckbox.Checked;
            string salesRegion = salesRegionDetailSalesRegionTextbox.Text.TrimEnd();

            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dataToValidate = new List<ValidateDataInput.DataProperty>
            {
                new ValidateDataInput.DataProperty
                {
                    Name = "ActiveStatus",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    Name = "SalesRegion",
                    Value = salesRegion,
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
                        OriginalValue = salesRegionDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Sales Region",
                        VariableType = "string",
                        OriginalValue = salesRegionDetailSalesRegionOriginalValue,
                        NewValue = salesRegion
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
                            ParameterName = "@salesRegion",
                            ParameterValue = salesRegion
                        },
                        new Parameter
                        {
                            ParameterName = "@salesRegionId",
                            ParameterValue = _salesRegionId
                        }
                    };
                    string storedProcedureName = "[dbo].[spUpdateSalesRegion]";
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

        private void salesRegionDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            salesRegionDetailSalesRegionTextbox.Enabled = !salesRegionDetailSalesRegionTextbox.Enabled;
            salesRegionDetailActiveStatusCheckbox.Enabled = !salesRegionDetailActiveStatusCheckbox.Enabled;
            salesRegionDetailUpdateSalesRegionButton.Enabled = !salesRegionDetailUpdateSalesRegionButton.Enabled;
        }
    }
}