using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class ProductNoteDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _productNoteId;
        private string? productNoteDetailProductNoteOriginalValue;
        private Guid? productNoteDetailProductNoteTypeIdOriginalValue;
        private string? productNoteDetailProductNoteTitleOriginalValue;

        public ProductNoteDetail(Guid productNoteId)
        {
            InitializeComponent();
            _productNoteId = productNoteId;
            productNoteDetailToggleEditModeButton.Click += productNoteDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task ProductNoteDetailLoadProductNoteTypeAsync(Guid productNoteTypeId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                string storedProcedureName = "[dbo].[spGetAllProductNoteType]";
                string dataSubject = "Product Note Type";
                DataTable? productNoteTypeData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var productNoteTypeList = productNoteTypeData.AsEnumerable()
                    .Select(row => new
                    {
                        ProductNoteTypeId = row.Field<Guid>("Product Note Type Id"),
                        ProductNoteType = row.Field<string>("Product Note Type"),
                    })
                    .OrderBy(item => item.ProductNoteType)
                    .ToList();
                productNoteDetailProductNoteTypeComboBox.DataSource = productNoteTypeList;
                productNoteDetailProductNoteTypeComboBox.DisplayMember = "ProductNoteType";
                productNoteDetailProductNoteTypeComboBox.ValueMember = "ProductNoteTypeId";
                productNoteDetailProductNoteTypeComboBox.SelectedValue = productNoteTypeId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Product Note Type data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ViewProductNoteDetailProductNoteInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string storedProcedureName = "[dbo].[spGetProductNote]";
            string dataSubject = "Product Note";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@productNoteId",
                    ParameterValue = _productNoteId
                }
            };

            try
            {
                DataTable? productNoteDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (productNoteDataTable != null)
                {
                    DataRow productNoteDataRow = productNoteDataTable.Rows[0];
                    productNoteDetailProductNoteIdTextbox.Text = productNoteDataRow["Product Note ID"].ToString();
                    productNoteDetailProductNoteTitleTextbox.Text = productNoteDataRow["Product Note Title"].ToString();
                    Guid productNoteTypeId = (Guid)productNoteDataRow["Product Note Type"];
                    await ProductNoteDetailLoadProductNoteTypeAsync(productNoteTypeId);
                    productNoteDetailProductNoteTextbox.Text = productNoteDataRow["Product Note"].ToString();
                    productNoteDetailCreatedByTextbox.Text = productNoteDataRow["Created By"].ToString();
                    productNoteDetailCreatedTimestampTextbox.Text = productNoteDataRow["Created Timestamp"].ToString();
                    productNoteDetailLastUpdatedByTextbox.Text = productNoteDataRow["Modified By"].ToString();
                    productNoteDetailLastUpdatedTimestampTextbox.Text = productNoteDataRow["Modified Timestamp"].ToString();

                    productNoteDetailProductNoteOriginalValue = productNoteDataRow["Product Note"].ToString();
                    productNoteDetailProductNoteTitleOriginalValue = productNoteDataRow["Product Note Title"].ToString();
                    productNoteDetailProductNoteTypeIdOriginalValue = productNoteTypeId;
                }
                else
                {
                    MessageBox.Show("No data found for the specified Product Note.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Product Note details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void productNoteDetailUpdateProductNoteButton_Click(object sender, EventArgs e)
        {
            string productNote = productNoteDetailProductNoteTextbox.Text.TrimEnd();
            string productNoteTitle = productNoteDetailProductNoteTitleTextbox.Text.TrimEnd();
            Guid productNoteTypeId = (Guid)productNoteDetailProductNoteTypeComboBox.SelectedValue;
            string dataSubject = "Product Note";

            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var stringsToValidate = new List<ValidateStringInput.StringProperty>
            {
                new ValidateStringInput.StringProperty
                {
                    Name = "ProductNote",
                    Value = productNote,
                    MaxLength = 1073741823
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "ProductNoteTitle",
                    Value = productNoteTitle,
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
                        VariableName = "Product Note",
                        VariableType = "string",
                        OriginalValue = productNoteDetailProductNoteOriginalValue,
                        NewValue = productNote
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Note Title",
                        VariableType = "string",
                        OriginalValue = productNoteDetailProductNoteTitleOriginalValue,
                        NewValue = productNoteTitle
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Note Type Id",
                        VariableType = "Guid",
                        OriginalValue = productNoteDetailProductNoteTypeIdOriginalValue,
                        NewValue = productNoteTypeId
                    }
                };

                bool confirmed = UpdateConfirmation.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
                {
                    var parameters = new[]
                    {
                        new Parameter
                        {
                            ParameterName = "@productNote",
                            ParameterValue = productNote
                        },
                        new Parameter
                        {
                            ParameterName = "@productNoteId",
                            ParameterValue = _productNoteId
                        },
                        new Parameter
                        {
                            ParameterName = "@productNoteTitle",
                            ParameterValue = productNoteTitle
                        },
                        new Parameter
                        {
                            ParameterName = "@productNoteTypeId",
                            ParameterValue = productNoteTypeId
                        }
                    };
                    string storedProcedureName = "[dbo].[spUpdateProductNote]";
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
            ViewProductNoteDetailProductNoteInformation_Load(this, EventArgs.Empty);
        }

        private void productNoteDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            productNoteDetailProductNoteTextbox.Enabled = !productNoteDetailProductNoteTextbox.Enabled;
            productNoteDetailProductNoteTitleTextbox.Enabled = !productNoteDetailProductNoteTitleTextbox.Enabled;
            productNoteDetailProductNoteTypeComboBox.Enabled = !productNoteDetailProductNoteTypeComboBox.Enabled;
            productNoteDetailUpdateProductNoteButton.Enabled = !productNoteDetailUpdateProductNoteButton.Enabled;
        }
    }
}