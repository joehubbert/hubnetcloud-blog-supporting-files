using CRM.Helpers;
using CRM.Interface;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.MasterDataManagement
{
    public partial class TaxProfileDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Tax Profile";
        private readonly Guid _taxProfileId;
        private TextBoxNumericCharacterDataValidationHelper _textBoxNumericHelper;
        private bool taxProfileDetailActiveStatusOriginalValue;
        private string taxProfileDetailTaxProfileOriginalValue;
        private decimal taxProfileDetailTaxRateOriginalValue;

        public TaxProfileDetail(Guid taxProfileId)
        {
            InitializeComponent();
            _textBoxNumericHelper = new TextBoxNumericCharacterDataValidationHelper();
            InitializeEventHandlers();
            _taxProfileId = taxProfileId;
            LoadDatabaseConnectionSettingsAsync();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            TaxProfileDetailTaxProfileInformation_Load(this, EventArgs.Empty);
        }

        private void InitializeEventHandlers()
        {
            taxProfileDetailTaxRateTextBoxA.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            taxProfileDetailTaxRateTextBoxB.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
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
                    taxProfileDetailActiveStatusCheckBox.Checked = (bool)taxProfileDataRow["Active Status"];

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

        private void taxProfileDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            taxProfileDetailTaxProfileTextBox.ReadOnly = !taxProfileDetailTaxProfileTextBox.ReadOnly;
            taxProfileDetailTaxRateTextBoxA.ReadOnly = !taxProfileDetailTaxRateTextBoxA.ReadOnly;
            taxProfileDetailTaxRateTextBoxB.ReadOnly = !taxProfileDetailTaxRateTextBoxB.ReadOnly;
            taxProfileDetailActiveStatusCheckBox.Enabled = !taxProfileDetailActiveStatusCheckBox.Enabled;
            taxProfileDetailUpdateTaxProfileButton.Enabled = !taxProfileDetailUpdateTaxProfileButton.Enabled;
        }

        private async void taxProfileDetailUpdateTaxProfileButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = taxProfileDetailActiveStatusCheckBox.Checked;
            string taxProfile = TextBoxCleanerHelper.GetTrimmedText(taxProfileDetailTaxProfileTextBox);
            decimal taxRate = decimal.Parse(TextBoxCleanerHelper.GetTrimmedText(taxProfileDetailTaxRateTextBoxA)) + (decimal.Parse(TextBoxCleanerHelper.GetTrimmedText(taxProfileDetailTaxRateTextBoxB)) / 100);

            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            var dataToValidate = new List<DataValidationService.DataProperty>
            {
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Active Status",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Tax Profile",
                    Value = taxProfile,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Tax Rate",
                    Value = taxRate,
                    ValueType = typeof(decimal)
                }
            };

            dataToValidate = dataToValidate.OrderBy(change => change.Name).ToList();

            var validationResult = DataValidationService.ValidateInput(dataToValidate);

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
                        OriginalValue = taxProfileDetailActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Tax Profile",
                        OriginalValue = taxProfileDetailTaxProfileOriginalValue,
                        NewValue = taxProfile
                    },
                    new ChangeDetail
                    {
                        VariableName = "Tax Rate",
                        OriginalValue = taxProfileDetailTaxRateOriginalValue,
                        NewValue = taxRate
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = ChangeValidationService.ConfirmChanges(changesList, dataSubject);

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
                    string operationType = "Update";

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
    }
}