using CRM_WindowsForms.Interface;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class CurrencyDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _currencyId;
        private string ?currencyDetailCurrencyCodeOriginalValue;
        private string ?currencyDetailCurrencyNameOriginalValue;
        private bool ?currencyDetailActiveStatusOriginalValue;
        private readonly string dataSubject = "Currency";

        public CurrencyDetail(Guid currencyId)
        {
            InitializeComponent();
            _currencyId = currencyId;
            currencyDetailToggleEditModeButton.Click += currencyDetailToggleEditModeButton_Click;
            LoadDatabaseConnectionSettingsAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void ViewCurrencyDetailCurrencyInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string storedProcedureName = "[dbo].[spGetCurrency]";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@currencyId",
                    ParameterValue = _currencyId
                }
            };

            try
            {
                DataTable? currencyDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (currencyDataTable != null)
                {
                    DataRow currencyDataRow = currencyDataTable.Rows[0];
                    currencyDetailCurrencyIdTextbox.Text = currencyDataRow["Currency Id"].ToString();
                    currencyDetailCurrencyCodeTextbox.Text = currencyDataRow["Currency Code"].ToString();
                    currencyDetailCurrencyNameTextbox.Text = currencyDataRow["Currency Name"].ToString();
                    currencyDetailCreatedByTextbox.Text = currencyDataRow["Created By"].ToString();
                    currencyDetailCreatedTimestampTextbox.Text = currencyDataRow["Created Timestamp UTC"].ToString();
                    currencyDetailLastUpdatedByTextbox.Text = currencyDataRow["Modified By"].ToString();
                    currencyDetailLastUpdatedTimestampTextbox.Text = currencyDataRow["Modified Timestamp UTC"].ToString();
                    currencyDetailActiveStatusCheckbox.Checked = (bool)currencyDataRow["Active Status"];

                    currencyDetailCurrencyCodeOriginalValue = currencyDataRow["Currency Code"].ToString();
                    currencyDetailCurrencyNameOriginalValue = currencyDataRow["Currency Name"].ToString();
                    currencyDetailActiveStatusOriginalValue = (bool)currencyDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show("No data found for the specified Currency.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Currency details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void currencyDetailUpdateCurrencyButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = currencyDetailActiveStatusCheckbox.Checked;
            string currencyCode = currencyDetailCurrencyCodeTextbox.Text.TrimEnd();
            string currencyName = currencyDetailCurrencyNameTextbox.Text.TrimEnd();

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
                    Name = "CurrencyCode",
                    Value = currencyCode,
                    MaxLength = 3,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CurrencyName",
                    Value = currencyName,
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
                        VariableType = "bool",
                        OriginalValue = currencyDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail 
                    { 
                        VariableName = "Currency Code",
                        VariableType = "string",
                        OriginalValue = currencyDetailCurrencyCodeOriginalValue,
                        NewValue = currencyCode 
                    },
                    new ChangeDetail
                    { 
                        VariableName = "Currency Name",
                        VariableType = "string",
                        OriginalValue = currencyDetailCurrencyNameOriginalValue,
                        NewValue = currencyName
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
                            ParameterName = "@currencyCode",
                            ParameterValue = currencyCode
                        },
                        new Parameter
                        {
                            ParameterName = "@currencyName",
                            ParameterValue = currencyName
                        },
                        new Parameter
                        {
                            ParameterName = "@currencyId",
                            ParameterValue = _currencyId
                        }
                    };
                    string storedProcedureName = "[dbo].[spUpdateCurrency]";
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
            ViewCurrencyDetailCurrencyInformation_Load(this, EventArgs.Empty);
        }

        private void currencyDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            currencyDetailCurrencyCodeTextbox.ReadOnly = !currencyDetailCurrencyCodeTextbox.ReadOnly;
            currencyDetailCurrencyNameTextbox.ReadOnly = !currencyDetailCurrencyNameTextbox.ReadOnly;
            currencyDetailActiveStatusCheckbox.Enabled = !currencyDetailActiveStatusCheckbox.Enabled;
            currencyDetailUpdateCurrencyButton.Enabled = !currencyDetailUpdateCurrencyButton.Enabled;
        }
    }
}