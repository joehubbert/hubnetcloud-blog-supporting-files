using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CurrencyDetail : Form
    {
        private readonly Guid _currencyId;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private bool? currencyDetailActiveStatusOriginalValue;
        private string? currencyDetailCurrencyCodeOriginalValue;
        private string? currencyDetailCurrencyNameOriginalValue;
        private readonly string dataSubject = "Currency";

        public CurrencyDetail(Guid currencyId)
        {
            InitializeComponent();
            InitializeEventHandlers();
            _currencyId = currencyId;
            LoadDatabaseConnectionSettingsAsync();
        }

        private void InitializeEventHandlers()
        {
            currencyDetailToggleEditModeButton.Click += currencyDetailToggleEditModeButton_Click;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void CurrencyDetailCurrencyInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            string dataSubject = "Currency";
            string storedProcedureName = "spGetCurrency";

            var parameters = new[]
            {
                new StoredProcedureParameter
                {
                    ParameterName = "currencyId",
                    ParameterValue = _currencyId
                }
            };

            try
            {
                DataTable? currencyDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject);

                if (currencyDataTable != null)
                {
                    DataRow currencyDataRow = currencyDataTable.Rows[0];
                    currencyDetailCurrencyIdTextBox.Text = currencyDataRow["Currency Id"].ToString();
                    currencyDetailCurrencyCodeMaskedTextBox.Text = currencyDataRow["Currency Code"].ToString();
                    currencyDetailCurrencyNameTextBox.Text = currencyDataRow["Currency Name"].ToString();
                    currencyDetailCreatedByTextBox.Text = currencyDataRow["Created By"].ToString();
                    currencyDetailCreatedTimestampTextBox.Text = currencyDataRow["Created Timestamp UTC"].ToString();
                    currencyDetailLastUpdatedByTextBox.Text = currencyDataRow["Modified By"].ToString();
                    currencyDetailLastUpdatedTimestampTextBox.Text = currencyDataRow["Modified Timestamp UTC"].ToString();
                    currencyDetailActiveStatusCheckBox.Checked = (bool)currencyDataRow["Active Status"];

                    currencyDetailCurrencyCodeOriginalValue = currencyDataRow["Currency Code"].ToString();
                    currencyDetailCurrencyNameOriginalValue = currencyDataRow["Currency Name"].ToString();
                    currencyDetailActiveStatusOriginalValue = (bool)currencyDataRow["Active Status"];

                    this.Text += $" ({currencyDetailCurrencyNameOriginalValue})";
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.NoDataFound", dataSubject);
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async void currencyDetailUpdateCurrencyButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = currencyDetailActiveStatusCheckBox.Checked;
            string currencyCode = currencyDetailCurrencyCodeMaskedTextBox.Text.TrimEnd();
            string currencyName = currencyDetailCurrencyNameTextBox.Text.TrimEnd();

            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            var dataToValidate = new List<ValidateDataInputService.DataProperty>
            {
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Active Status",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Currency Code",
                    Value = currencyCode,
                    MaxLength = 3,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Currency Name",
                    Value = currencyName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                }
            };

            dataToValidate = dataToValidate.OrderBy(change => change.Name).ToList();

            var validationResult = ValidateDataInputService.ValidateInput(dataToValidate);

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

                bool confirmed = UpdateConfirmationService.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
                {
                    var parameters = new[]
                    {
                        new StoredProcedureParameter
                        {
                            ParameterName = "activeStatus",
                            ParameterValue = activeStatus
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "currencyCode",
                            ParameterValue = currencyCode
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "currencyName",
                            ParameterValue = currencyName
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "currencyId",
                            ParameterValue = _currencyId
                        }
                    };
                    string storedProcedureName = "spUpdateCurrency";
                    string operationType = "update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, operationType);
                    this.Close();
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.UpdateCancelled");
                    this.Close();
                }
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            CurrencyDetailCurrencyInformation_Load(this, EventArgs.Empty);
        }

        private void currencyDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            currencyDetailCurrencyCodeMaskedTextBox.ReadOnly = !currencyDetailCurrencyCodeMaskedTextBox.ReadOnly;
            currencyDetailCurrencyNameTextBox.ReadOnly = !currencyDetailCurrencyNameTextBox.ReadOnly;
            currencyDetailActiveStatusCheckBox.Enabled = !currencyDetailActiveStatusCheckBox.Enabled;
            currencyDetailUpdateCurrencyButton.Enabled = !currencyDetailUpdateCurrencyButton.Enabled;
        }
    }
}