using CRM_WindowsForms.Interface;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class SupplierNoteDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _supplierNoteId;
        private string? supplierNoteDetailSupplierNoteOriginalValue;
        private Guid? supplierNoteDetailSupplierNoteTypeIdOriginalValue;
        private string? supplierNoteDetailSupplierNoteTitleOriginalValue;

        public SupplierNoteDetail(Guid supplierNoteId)
        {
            InitializeComponent();
            _supplierNoteId = supplierNoteId;
            supplierNoteDetailToggleEditModeButton.Click += supplierNoteDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task SupplierNoteDetailLoadSupplierNoteTypeAsync(Guid supplierNoteTypeId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                string storedProcedureName = "[dbo].[spGetAllSupplierNoteType]";
                string dataSubject = "Supplier Note Type";
                DataTable? supplierNoteTypeData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var supplierNoteTypeList = supplierNoteTypeData.AsEnumerable()
                    .Select(row => new
                    {
                        SupplierNoteTypeId = row.Field<Guid>("Supplier Note Type Id"),
                        SupplierNoteType = row.Field<string>("Supplier Note Type"),
                    })
                    .OrderBy(item => item.SupplierNoteType)
                    .ToList();
                supplierNoteDetailSupplierNoteTypeComboBox.DataSource = supplierNoteTypeList;
                supplierNoteDetailSupplierNoteTypeComboBox.DisplayMember = "SupplierNoteType";
                supplierNoteDetailSupplierNoteTypeComboBox.ValueMember = "SupplierNoteTypeId";
                supplierNoteDetailSupplierNoteTypeComboBox.SelectedValue = supplierNoteTypeId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Supplier Note Type data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ViewSupplierNoteDetailSupplierNoteInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string storedProcedureName = "[dbo].[spGetSupplierNote]";
            string dataSubject = "Supplier Note";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@supplierNoteId",
                    ParameterValue = _supplierNoteId
                }
            };

            try
            {
                DataTable? supplierNoteDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (supplierNoteDataTable != null)
                {
                    DataRow supplierNoteDataRow = supplierNoteDataTable.Rows[0];
                    supplierNoteDetailSupplierNoteIdTextbox.Text = supplierNoteDataRow["Supplier Note Id"].ToString();
                    supplierNoteDetailSupplierNoteTitleTextbox.Text = supplierNoteDataRow["Supplier Note Title"].ToString();
                    Guid supplierNoteTypeId = (Guid)supplierNoteDataRow["Supplier Note Type"];
                    await SupplierNoteDetailLoadSupplierNoteTypeAsync(supplierNoteTypeId);
                    supplierNoteDetailSupplierNoteTextbox.Text = supplierNoteDataRow["Supplier Note"].ToString();
                    supplierNoteDetailCreatedByTextbox.Text = supplierNoteDataRow["Created By"].ToString();
                    supplierNoteDetailCreatedTimestampTextbox.Text = supplierNoteDataRow["Created Timestamp"].ToString();
                    supplierNoteDetailLastUpdatedByTextbox.Text = supplierNoteDataRow["Modified By"].ToString();
                    supplierNoteDetailLastUpdatedTimestampTextbox.Text = supplierNoteDataRow["Modified Timestamp"].ToString();

                    supplierNoteDetailSupplierNoteOriginalValue = supplierNoteDataRow["Supplier Note"].ToString();
                    supplierNoteDetailSupplierNoteTitleOriginalValue = supplierNoteDataRow["Supplier Note Title"].ToString();
                    supplierNoteDetailSupplierNoteTypeIdOriginalValue = supplierNoteTypeId;
                }
                else
                {
                    MessageBox.Show("No data found for the specified Supplier Note.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Supplier Note details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void supplierNoteDetailUpdateSupplierNoteButton_Click(object sender, EventArgs e)
        {
            string supplierNote = supplierNoteDetailSupplierNoteTextbox.Text.TrimEnd();
            string supplierNoteTitle = supplierNoteDetailSupplierNoteTitleTextbox.Text.TrimEnd();
            Guid supplierNoteTypeId = (Guid)supplierNoteDetailSupplierNoteTypeComboBox.SelectedValue;

            string dataSubject = "Supplier Note";

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
                    Name = "SupplierNote",
                    Value = supplierNote,
                    MaxLength = 1073741823,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierNoteTitle",
                    Value = supplierNoteTitle,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierNoteTypeId",
                    Value = supplierNoteTypeId,
                    ValueType = typeof(Guid)
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
                        VariableName = "Supplier Note",
                        VariableType = "string",
                        OriginalValue = supplierNoteDetailSupplierNoteOriginalValue,
                        NewValue = supplierNote
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Note Title",
                        VariableType = "string",
                        OriginalValue = supplierNoteDetailSupplierNoteTitleOriginalValue,
                        NewValue = supplierNoteTitle
                    },
                    new ChangeDetail
                    {
                        VariableName = "Supplier Note Type Id",
                        VariableType = "Guid",
                        OriginalValue = supplierNoteDetailSupplierNoteTypeIdOriginalValue,
                        NewValue = supplierNoteTypeId
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
                            ParameterName = "@supplierNote",
                            ParameterValue = supplierNote
                        },
                        new Parameter
                        {
                            ParameterName = "@supplierNoteId",
                            ParameterValue = _supplierNoteId
                        },
                        new Parameter
                        {
                            ParameterName = "@supplierNoteTitle",
                            ParameterValue = supplierNoteTitle
                        },
                        new Parameter
                        {
                            ParameterName = "@supplierNoteTypeId",
                            ParameterValue = supplierNoteTypeId
                        }
                    };
                    string storedProcedureName = "[dbo].[spUpdateSupplierNote]";
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
            ViewSupplierNoteDetailSupplierNoteInformation_Load(this, EventArgs.Empty);
        }

        private void supplierNoteDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            supplierNoteDetailSupplierNoteTextbox.ReadOnly = !supplierNoteDetailSupplierNoteTextbox.ReadOnly;
            supplierNoteDetailSupplierNoteTitleTextbox.ReadOnly = !supplierNoteDetailSupplierNoteTitleTextbox.ReadOnly;
            supplierNoteDetailSupplierNoteTypeComboBox.Enabled = !supplierNoteDetailSupplierNoteTypeComboBox.Enabled;
            supplierNoteDetailUpdateSupplierNoteButton.Enabled = !supplierNoteDetailUpdateSupplierNoteButton.Enabled;
        }
    }
}