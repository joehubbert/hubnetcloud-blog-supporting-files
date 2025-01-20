using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class ProductNoteTypeDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Product Note Type";
        private readonly Guid _productNoteTypeId;
        private bool ?productNoteTypeDetailActiveStatusOriginalValue;
        private string ?productNoteTypeDetailProductNoteTypeOriginalValue;
        
        public ProductNoteTypeDetail(Guid productNoteTypeId)
        {
            InitializeComponent();
            _productNoteTypeId = productNoteTypeId;
            productNoteTypeDetailToggleEditModeButton.Click += productNoteTypeDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void ViewProductNoteTypeDetailProductNoteTypeInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string storedProcedureName = "[dbo].[spGetProductNoteType]";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@oroductNoteTypeId",
                    ParameterValue = _productNoteTypeId
                }
            };

            try
            {
                DataTable? productNoteTypeDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (productNoteTypeDataTable != null)
                {
                    DataRow productNoteTypeDataRow = productNoteTypeDataTable.Rows[0];
                    productNoteTypeDetailProductNoteTypeIdTextbox.Text = productNoteTypeDataRow["Product Note Type ID"].ToString();
                    productNoteTypeDetailProductNoteTypeTextbox.Text = productNoteTypeDataRow["Product Note Type"].ToString();
                    productNoteTypeDetailCreatedByTextbox.Text = productNoteTypeDataRow["Created By"].ToString();
                    productNoteTypeDetailCreatedTimestampTextbox.Text = productNoteTypeDataRow["Created Timestamp"].ToString();
                    productNoteTypeDetailLastUpdatedByTextbox.Text = productNoteTypeDataRow["Modified By"].ToString();
                    productNoteTypeDetailLastUpdatedTimestampTextbox.Text = productNoteTypeDataRow["Modified Timestamp"].ToString();
                    productNoteTypeDetailActiveStatusCheckbox.Checked = (bool)productNoteTypeDataRow["Active Status"];

                    productNoteTypeDetailProductNoteTypeOriginalValue = productNoteTypeDataRow["Product Note Type"].ToString();
                    productNoteTypeDetailActiveStatusOriginalValue = (bool)productNoteTypeDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Product Note Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Product Note Type details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void productNoteTypeDetailUpdateProductNoteTypeButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = productNoteTypeDetailActiveStatusCheckbox.Checked;
            string productNoteType = productNoteTypeDetailProductNoteTypeTextbox.Text.TrimEnd();

            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var stringsToValidate = new List<ValidateStringInput.StringProperty>
            {
                new ValidateStringInput.StringProperty
                {
                    Name = "ProductNoteType",
                    Value = productNoteType,
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
                        VariableName = "Product Note Type",
                        VariableType = "string",
                        OriginalValue = productNoteTypeDetailProductNoteTypeOriginalValue,
                        NewValue = productNoteType
                    },
                    new ChangeDetail
                    {
                        VariableName = "Active Status",
                        VariableType = "string",
                        OriginalValue = productNoteTypeDetailActiveStatusOriginalValue,
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
                            ParameterName = "@productNoteType",
                            ParameterValue = productNoteType
                        },
                        new Parameter
                        {
                            ParameterName = "@productNoteTypeId",
                            ParameterValue = _productNoteTypeId
                        }
                    };
                    string storedProcedureName = "[dbo].[spUpdateProductNoteType]";
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
            ViewProductNoteTypeDetailProductNoteTypeInformation_Load(this, EventArgs.Empty);
        }

        private void productNoteTypeDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            productNoteTypeDetailProductNoteTypeTextbox.Enabled = !productNoteTypeDetailProductNoteTypeTextbox.Enabled;
            productNoteTypeDetailActiveStatusCheckbox.Enabled = !productNoteTypeDetailActiveStatusCheckbox.Enabled;
            productNoteTypeDetailUpdateProductNoteTypeButton.Enabled = !productNoteTypeDetailUpdateProductNoteTypeButton.Enabled;
        }
    }
}