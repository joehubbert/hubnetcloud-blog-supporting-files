using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class CustomerNoteDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _customerNoteId;
        private string? customerNoteDetailCustomerNoteOriginalValue;
        private Guid? customerNoteDetailCustomerNoteTypeIdOriginalValue;
        private string? customerNoteDetailCustomerNoteTitleOriginalValue;

        public CustomerNoteDetail(Guid customerNoteId)
        {
            InitializeComponent();
            _customerNoteId = customerNoteId;
            customerNoteDetailToggleEditModeButton.Click += customerNoteDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task CustomerNoteDetailLoadCustomerNoteTypeAsync(Guid customerNoteTypeId)
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
                        CustomerNoteType = row.Field<string>("Customer Note Type"),
                    })
                    .OrderBy(item => item.CustomerNoteType)
                    .ToList();
                customerNoteDetailCustomerNoteTypeComboBox.DataSource = customerNoteTypeList;
                customerNoteDetailCustomerNoteTypeComboBox.DisplayMember = "CustomerNoteType";
                customerNoteDetailCustomerNoteTypeComboBox.ValueMember = "CustomerNoteTypeId";
                customerNoteDetailCustomerNoteTypeComboBox.SelectedValue = customerNoteTypeId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Customer Note Type data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ViewCustomerNoteDetailCustomerNoteInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string storedProcedureName = "[dbo].[spGetCustomerNote]";
            string dataSubject = "Customer Note";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@customerNoteId",
                    ParameterValue = _customerNoteId
                }
            };

            try
            {
                DataTable? customerNoteDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (customerNoteDataTable != null)
                {
                    DataRow customerNoteDataRow = customerNoteDataTable.Rows[0];
                    customerNoteDetailCustomerNoteIdTextbox.Text = customerNoteDataRow["Customer Note ID"].ToString();
                    customerNoteDetailCustomerNoteTitleTextbox.Text = customerNoteDataRow["Customer Note Title"].ToString();
                    Guid customerNoteTypeId = (Guid)customerNoteDataRow["Customer Note Type"];
                    await CustomerNoteDetailLoadCustomerNoteTypeAsync(customerNoteTypeId);
                    customerNoteDetailCustomerNoteTextbox.Text = customerNoteDataRow["Customer Note"].ToString();
                    customerNoteDetailCreatedByTextbox.Text = customerNoteDataRow["Created By"].ToString();
                    customerNoteDetailCreatedTimestampTextbox.Text = customerNoteDataRow["Created Timestamp"].ToString();
                    customerNoteDetailLastUpdatedByTextbox.Text = customerNoteDataRow["Modified By"].ToString();
                    customerNoteDetailLastUpdatedTimestampTextbox.Text = customerNoteDataRow["Modified Timestamp"].ToString();

                    customerNoteDetailCustomerNoteOriginalValue = customerNoteDataRow["Customer Note"].ToString();
                    customerNoteDetailCustomerNoteTitleOriginalValue = customerNoteDataRow["Customer Note Title"].ToString();
                    customerNoteDetailCustomerNoteTypeIdOriginalValue = customerNoteTypeId;
                }
                else
                {
                    MessageBox.Show("No data found for the specified Customer Note.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Customer Note details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void customerNoteDetailUpdateCustomerNoteButton_Click(object sender, EventArgs e)
        {
            string customerNote = customerNoteDetailCustomerNoteTextbox.Text.TrimEnd();
            string customerNoteTitle = customerNoteDetailCustomerNoteTitleTextbox.Text.TrimEnd();
            Guid customerNoteTypeId = (Guid)customerNoteDetailCustomerNoteTypeComboBox.SelectedValue;
            string dataSubject = "Customer Note";

            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var stringsToValidate = new List<ValidateStringInput.StringProperty>
            {
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerNote",
                    Value = customerNote,
                    MaxLength = 1073741823
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerNoteTitle",
                    Value = customerNoteTitle,
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
                        VariableName = "Customer Note",
                        VariableType = "string",
                        OriginalValue = customerNoteDetailCustomerNoteOriginalValue,
                        NewValue = customerNote
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Note Title",
                        VariableType = "string",
                        OriginalValue = customerNoteDetailCustomerNoteTitleOriginalValue,
                        NewValue = customerNoteTitle
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Note Type Id",
                        VariableType = "Guid",
                        OriginalValue = customerNoteDetailCustomerNoteTypeIdOriginalValue,
                        NewValue = customerNoteTypeId
                    }
                };

                bool confirmed = UpdateConfirmation.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
                {
                    var parameters = new[]
                    {
                        new Parameter
                        {
                            ParameterName = "@customerNote",
                            ParameterValue = customerNote
                        },
                        new Parameter
                        {
                            ParameterName = "@customerNoteId",
                            ParameterValue = _customerNoteId
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
                    string storedProcedureName = "[dbo].[spUpdateCustomerNote]";
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
            ViewCustomerNoteDetailCustomerNoteInformation_Load(this, EventArgs.Empty);
        }

        private void customerNoteDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            customerNoteDetailCustomerNoteTextbox.Enabled = !customerNoteDetailCustomerNoteTextbox.Enabled;
            customerNoteDetailCustomerNoteTitleTextbox.Enabled = !customerNoteDetailCustomerNoteTitleTextbox.Enabled;
            customerNoteDetailCustomerNoteTypeComboBox.Enabled = !customerNoteDetailCustomerNoteTypeComboBox.Enabled;
            customerNoteDetailUpdateCustomerNoteButton.Enabled = !customerNoteDetailUpdateCustomerNoteButton.Enabled;
        }
    }
}