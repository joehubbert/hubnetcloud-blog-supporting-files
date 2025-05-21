using CRM_WindowsForms.Interface;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class ProductCategoryDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Product Category";
        private readonly Guid _productCategoryId;
        private bool? productCategoryDetailActiveStatusOriginalValue;
        private string? productCategoryDetailProductCategoryOriginalValue;

        public ProductCategoryDetail(Guid productCategoryId)
        {
            InitializeComponent();
            _productCategoryId = productCategoryId;
            productCategoryDetailToggleEditModeButton.Click += productCategoryDetailToggleEditModeButton_Click;
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

            string storedProcedureName = "[dbo].[spGetProductCategory]";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@productCategoryId",
                    ParameterValue = _productCategoryId
                }
            };

            try
            {
                DataTable? productCategoryDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (productCategoryDataTable != null)
                {
                    DataRow productCategoryDataRow = productCategoryDataTable.Rows[0];
                    productCategoryDetailProductCategoryIdTextbox.Text = productCategoryDataRow["Product Category Id"].ToString();
                    productCategoryDetailProductCategoryTextbox.Text = productCategoryDataRow["Product Category"].ToString();
                    productCategoryDetailCreatedByTextbox.Text = productCategoryDataRow["Created By"].ToString();
                    productCategoryDetailCreatedTimestampTextbox.Text = productCategoryDataRow["Created Timestamp"].ToString();
                    productCategoryDetailLastUpdatedByTextbox.Text = productCategoryDataRow["Modified By"].ToString();
                    productCategoryDetailLastUpdatedTimestampTextbox.Text = productCategoryDataRow["Modified Timestamp"].ToString();
                    productCategoryDetailActiveStatusCheckbox.Checked = (bool)productCategoryDataRow["Active Status"];

                    productCategoryDetailProductCategoryOriginalValue = productCategoryDataRow["Product Category"].ToString();
                    productCategoryDetailActiveStatusOriginalValue = (bool)productCategoryDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Product Category.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Product Category details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void productCategoryDetailUpdateProductCategoryButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = productCategoryDetailActiveStatusCheckbox.Checked;
            string productCategory = productCategoryDetailProductCategoryTextbox.Text.TrimEnd();

            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dataToValidate = new List<ValidateDataInput.DataProperty>
            {
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ActiveStatus",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductCategory",
                    Value = productCategory,
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
                        OriginalValue = productCategoryDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Category",
                        VariableType = "string",
                        OriginalValue = productCategoryDetailProductCategoryOriginalValue,
                        NewValue = productCategory
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
                            ParameterName = "@productCategory",
                            ParameterValue = productCategory
                        },
                        new Parameter
                        {
                            ParameterName = "@productCategoryId",
                            ParameterValue = _productCategoryId
                        }
                    };
                    string storedProcedureName = "[dbo].[spUpdateProductCategory]";
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

        private void productCategoryDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            productCategoryDetailProductCategoryTextbox.ReadOnly = !productCategoryDetailProductCategoryTextbox.ReadOnly;
            productCategoryDetailActiveStatusCheckbox.Enabled = !productCategoryDetailActiveStatusCheckbox.Enabled;
            productCategoryDetailUpdateProductCategoryButton.Enabled = !productCategoryDetailUpdateProductCategoryButton.Enabled;
        }
    }
}