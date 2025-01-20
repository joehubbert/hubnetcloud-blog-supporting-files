using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class SupplierNoteTypeDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Supplier Note Type";
        private readonly Guid _supplierNoteTypeId;
        private bool ?supplierNoteTypeDetailActiveStatusOriginalValue;
        private string ?supplierNoteTypeDetailSupplierNoteTypeOriginalValue;
        
        public SupplierNoteTypeDetail(Guid supplierNoteTypeId)
        {
            InitializeComponent();
            _supplierNoteTypeId = supplierNoteTypeId;
            supplierNoteTypeDetailToggleEditModeButton.Click += supplierNoteTypeDetailToggleEditModeButton_Click;
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

            string storedProcedureName = "[dbo].[spGetSupplierNoteType]";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@supplierNoteTypeId",
                    ParameterValue = _supplierNoteTypeId
                }
            };

            try
            {
                DataTable? supplierNoteTypeDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (supplierNoteTypeDataTable != null)
                {
                    DataRow supplierNoteTypeDataRow = supplierNoteTypeDataTable.Rows[0];
                    supplierNoteTypeDetailSupplierNoteTypeIdTextbox.Text = supplierNoteTypeDataRow["Supplier Note Type ID"].ToString();
                    supplierNoteTypeDetailSupplierNoteTypeTextbox.Text = supplierNoteTypeDataRow["Supplier Note Type"].ToString();
                    supplierNoteTypeDetailCreatedByTextbox.Text = supplierNoteTypeDataRow["Created By"].ToString();
                    supplierNoteTypeDetailCreatedTimestampTextbox.Text = supplierNoteTypeDataRow["Created Timestamp"].ToString();
                    supplierNoteTypeDetailLastUpdatedByTextbox.Text = supplierNoteTypeDataRow["Modified By"].ToString();
                    supplierNoteTypeDetailLastUpdatedTimestampTextbox.Text = supplierNoteTypeDataRow["Modified Timestamp"].ToString();
                    supplierNoteTypeDetailActiveStatusCheckbox.Checked = (bool)supplierNoteTypeDataRow["Active Status"];

                    supplierNoteTypeDetailSupplierNoteTypeOriginalValue = supplierNoteTypeDataRow["Supplier Note Type"].ToString();
                    supplierNoteTypeDetailActiveStatusOriginalValue = (bool)supplierNoteTypeDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Supplier Note Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Supplier Note Type details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void supplierNoteTypeDetailUpdateSupplierNoteTypeButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = supplierNoteTypeDetailActiveStatusCheckbox.Checked;
            string supplierNoteType = supplierNoteTypeDetailSupplierNoteTypeTextbox.Text.TrimEnd();

            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var stringsToValidate = new List<ValidateStringInput.StringProperty>
            {
                new ValidateStringInput.StringProperty
                {
                    Name = "SupplierNoteType",
                    Value = supplierNoteType,
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
                        VariableName = "Supplier Note Type",
                        VariableType = "string",
                        OriginalValue = supplierNoteTypeDetailSupplierNoteTypeOriginalValue,
                        NewValue = supplierNoteType
                    },
                    new ChangeDetail
                    {
                        VariableName = "Active Status",
                        VariableType = "string",
                        OriginalValue = supplierNoteTypeDetailActiveStatusOriginalValue,
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
                            ParameterName = "@supplierNoteType",
                            ParameterValue = supplierNoteType
                        },
                        new Parameter
                        {
                            ParameterName = "@supplierNoteTypeId",
                            ParameterValue = _supplierNoteTypeId
                        }
                    };
                    string storedProcedureName = "[dbo].[spUpdateSupplierNoteType]";
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

        private void supplierNoteTypeDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            supplierNoteTypeDetailSupplierNoteTypeTextbox.Enabled = !supplierNoteTypeDetailSupplierNoteTypeTextbox.Enabled;
            supplierNoteTypeDetailActiveStatusCheckbox.Enabled = !supplierNoteTypeDetailActiveStatusCheckbox.Enabled;
            supplierNoteTypeDetailUpdateSupplierNoteTypeButton.Enabled = !supplierNoteTypeDetailUpdateSupplierNoteTypeButton.Enabled;
        }
    }
}