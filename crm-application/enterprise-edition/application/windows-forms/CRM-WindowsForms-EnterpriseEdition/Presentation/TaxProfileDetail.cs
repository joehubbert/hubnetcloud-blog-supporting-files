using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class TaxProfileDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Tax Profile";
        private readonly Guid _taxProfileId;
        private bool? taxProfileDetailActiveStatusOriginalValue;
        private string? taxProfileDetailTaxProfileOriginalValue;
        private decimal? taxProfileDetailTaxRateOriginalValue;

        public TaxProfileDetail(Guid taxProfileId)
        {
            InitializeComponent();
            InitializeEventHandlers();
            _taxProfileId = taxProfileId;
            LoadDatabaseConnectionSettingsAsync();
        }

        private void InitializeEventHandlers()
        {
            taxProfileDetailToggleEditModeButton.Click += taxProfileDetailToggleEditModeButton_Click;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void TaxProfileDetailTaxProfileInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            string storedProcedureName = "spGetTaxProfile";

            var parameters = new[]
            {
                new StoredProcedureParameter
                {
                    ParameterName = "taxProfileId",
                    ParameterValue = _taxProfileId
                }
            };

            try
            {
                DataTable? taxProfileDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject);

                if (taxProfileDataTable != null)
                {
                    DataRow taxProfileDataRow = taxProfileDataTable.Rows[0];
                    string taxRatePartA;
                    string taxRatePartB;

                    SplitDecimalHelper.SplitDecimalUsingDelimiter((decimal)taxProfileDataRow["Tax Rate"], out taxRatePartA, out taxRatePartB);

                    taxProfileDetailTaxProfileIdTextBox.Text = taxProfileDataRow["Tax Profile Id"].ToString();
                    taxProfileDetailTaxProfileTextBox.Text = taxProfileDataRow["Tax Profile"].ToString();
                    taxProfileDetailTaxRateTextBoxA.Text = taxRatePartA;
                    taxProfileDetailTaxRateTextBoxB.Text = taxRatePartB;
                    taxProfileDetailCreatedByTextBox.Text = taxProfileDataRow["Created By"].ToString();
                    taxProfileDetailCreatedTimestampTextBox.Text = taxProfileDataRow["Created Timestamp UTC"].ToString();
                    taxProfileDetailLastUpdatedByTextBox.Text = taxProfileDataRow["Modified By"].ToString();
                    taxProfileDetailLastUpdatedTimestampTextBox.Text = taxProfileDataRow["Modified Timestamp UTC"].ToString();
                    taxProfileDetailActiveStatusCheckbox.Checked = (bool)taxProfileDataRow["Active Status"];

                    taxProfileDetailTaxProfileOriginalValue = taxProfileDataRow["Tax Profile"].ToString();
                    taxProfileDetailTaxRateOriginalValue = (decimal)taxProfileDataRow["Tax Rate"];
                    taxProfileDetailActiveStatusOriginalValue = (bool)taxProfileDataRow["Active Status"];

                    this.Text += $" ({taxProfileDetailTaxProfileOriginalValue})";
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

        private async void taxProfileDetailUpdateTaxProfileButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = taxProfileDetailActiveStatusCheckbox.Checked;
            string taxProfile = taxProfileDetailTaxProfileTextBox.Text.TrimEnd();
            decimal taxRate = decimal.Parse(taxProfileDetailTaxRateTextBoxA.Text.TrimEnd()) + (decimal.Parse(taxProfileDetailTaxRateTextBoxB.Text.TrimEnd()) / 100);

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
                    Name = "Tax Profile",
                    Value = taxProfile,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Tax Rate",
                    Value = taxRate,
                    ValueType = typeof(decimal)
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
                        VariableType = "string",
                        OriginalValue = taxProfileDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Tax Profile",
                        VariableType = "string",
                        OriginalValue = taxProfileDetailTaxProfileOriginalValue,
                        NewValue = taxProfile
                    },
                    new ChangeDetail
                    {
                        VariableName = "Tax Rate",
                        VariableType = "string",
                        OriginalValue = taxProfileDetailTaxRateOriginalValue,
                        NewValue = taxRate
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
                            ParameterName = "taxProfile",
                            ParameterValue = taxProfile
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "taxProfileId",
                            ParameterValue = _taxProfileId
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "taxRate",
                            ParameterValue = taxRate
                        }
                    };
                    string storedProcedureName = "spUpdateTaxProfile";
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
            TaxProfileDetailTaxProfileInformation_Load(this, EventArgs.Empty);
        }

        private void taxProfileDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            taxProfileDetailTaxProfileTextBox.ReadOnly = !taxProfileDetailTaxProfileTextBox.ReadOnly;
            taxProfileDetailTaxRateTextBoxA.ReadOnly = !taxProfileDetailTaxRateTextBoxA.ReadOnly;
            taxProfileDetailTaxRateTextBoxB.ReadOnly = !taxProfileDetailTaxRateTextBoxB.ReadOnly;
            taxProfileDetailActiveStatusCheckbox.Enabled = !taxProfileDetailActiveStatusCheckbox.Enabled;
            taxProfileDetailUpdateTaxProfileButton.Enabled = !taxProfileDetailUpdateTaxProfileButton.Enabled;
        }
    }
}