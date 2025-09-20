using CRM.Helpers;
using CRM.Interface;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.MasterDataManagement
{
    public partial class MasterDataEnhancedDetail : Form
    {
        private readonly Guid _dataSubjectId;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string _functionTitle;
        private readonly string _moduleGroup;
        private readonly string applicationTitlePrefix = "CRM - ";
        private bool dataSubjectActiveStatusOriginalValue;
        private string dataSubjectDescriptionOriginalValue;
        private string dataSubjectFriendlyName;
        private string dataSubjectGetStoredProcedureName;
        private string dataSubjectIdFriendlyName;
        private string dataSubjectName;
        private string dataSubjectOriginalValue;
        private string dataSubjectUpdateStoredProcedureName;
        private string dataSubjectUpdateStoredProcedureParameterPrefix;
        private readonly string titleLabelSuffix = " Detail";

        public MasterDataEnhancedDetail(Guid dataSubjectId, string functionTitle, string moduleGroup)
        {
            InitializeComponent();
            InitializeEventHandlers();
            _dataSubjectId = dataSubjectId;
            _functionTitle = functionTitle;
            _moduleGroup = moduleGroup;
            SetModuleTheme();  
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            SetParameters(_functionTitle);
            MasterDataEnhancedDetailMasterDataInformation_Load(this, EventArgs.Empty);
        }

        private void InitializeEventHandlers()
        {
            
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void MasterDataEnhancedDetailMasterDataInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            var parameters = new[]
            {
                new StoredProcedureParameter
                {
                    ParameterName = $"{dataSubjectUpdateStoredProcedureParameterPrefix}Id",
                    ParameterValue = _dataSubjectId
                }
            };

            try
            {
                DataTable? masterDataEnhancedDetailDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(
                    _databaseConnectionSettings,
                    dataSubjectGetStoredProcedureName,
                    parameters.ToArray(),
                    dataSubjectName);

                if (masterDataEnhancedDetailDataTable != null)
                {
                    DataRow masterDataEnhancedDetailDataRow = masterDataEnhancedDetailDataTable.Rows[0];
                    masterDataEnhancedDetailDataSubjectIdTextBox.Text = masterDataEnhancedDetailDataRow[dataSubjectIdFriendlyName].ToString();
                    masterDataEnhancedDetailDataSubjectTextBox.Text = masterDataEnhancedDetailDataRow[dataSubjectFriendlyName].ToString();
                    masterDataEnhancedDetailDataSubjectDescriptionTextBox.Text = masterDataEnhancedDetailDataRow[$"{dataSubjectFriendlyName} Description"].ToString();
                    masterDataEnhancedDetailCreatedByTextBox.Text = masterDataEnhancedDetailDataRow["Created By"].ToString();
                    masterDataEnhancedDetailCreatedTimestampTextBox.Text = masterDataEnhancedDetailDataRow["Created Timestamp UTC"].ToString();
                    masterDataEnhancedDetailLastUpdatedByTextBox.Text = masterDataEnhancedDetailDataRow["Modified By"].ToString();
                    masterDataEnhancedDetailLastUpdatedTimestampTextBox.Text = masterDataEnhancedDetailDataRow["Modified Timestamp UTC"].ToString();
                    masterDataEnhancedDetailActiveStatusCheckBox.Checked = (bool)masterDataEnhancedDetailDataRow["Active Status"];

                    dataSubjectOriginalValue = masterDataEnhancedDetailDataRow[dataSubjectFriendlyName].ToString();
                    dataSubjectDescriptionOriginalValue = masterDataEnhancedDetailDataRow[$"{dataSubjectFriendlyName} Description"].ToString();
                    dataSubjectActiveStatusOriginalValue = (bool)masterDataEnhancedDetailDataRow["Active Status"];

                    this.Text += $" ({dataSubjectOriginalValue})";
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.NoDataFound", dataSubjectFriendlyName);
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubjectFriendlyName, ex.Message);
            }
        }

        private void SetModuleTheme()
        {
            ModuleThemeHelper.ApplyTheme(this, _moduleGroup);
        }

        private void SetParameters(string functionTitle)
        {
            switch (functionTitle)
            {
                case "CustomerLeadType":
                    dataSubjectFriendlyName = "Customer Lead Type";
                    dataSubjectGetStoredProcedureName = "spGetCustomerLeadType";
                    dataSubjectIdFriendlyName = "Customer Lead Type Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdateCustomerLeadType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "customerLeadType";
                    break;
                case "CustomerType":
                    dataSubjectFriendlyName = "Customer Type";
                    dataSubjectGetStoredProcedureName = "spGetCustomerType";
                    dataSubjectIdFriendlyName = "Customer Type Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdateCustomerType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "customerType";
                    break;
                case "PromotionTargetType":
                    dataSubjectFriendlyName = "Promotion Target Type";
                    dataSubjectGetStoredProcedureName = "spGetPromotionTargetType";
                    dataSubjectIdFriendlyName = "Promotion Target Type Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdatePromotionTargetType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "promotionTargetType";
                    break;
                default:
                    this.Text = functionTitle;
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", functionTitle);
                    break;
            }

            dataSubjectName = functionTitle;

            masterDataEnhancedDetailTitleLabel.Text = $"{dataSubjectFriendlyName}{titleLabelSuffix}";
            masterDataEnhancedDetailDataSubjectIdTextBoxLabel.Text = dataSubjectIdFriendlyName;
            masterDataEnhancedDetailDataSubjectTextBoxLabel.Text = dataSubjectFriendlyName;
            masterDataEnhancedDetailDataSubjectDescriptionTextBoxLabel.Text = $"{dataSubjectFriendlyName} Description";
            masterDataEnhancedDetailActiveStatusCheckBox.Text = $"Active {dataSubjectFriendlyName}";
            masterDataEnhancedDetailUpdateDataSubjectButton.Text = $"Update {dataSubjectFriendlyName}";
            this.Text = $"{applicationTitlePrefix}{dataSubjectFriendlyName}{titleLabelSuffix}";
        }

        private void masterDataEnhancedDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            masterDataEnhancedDetailDataSubjectTextBox.ReadOnly = !masterDataEnhancedDetailDataSubjectTextBox.ReadOnly;
            masterDataEnhancedDetailDataSubjectDescriptionTextBox.ReadOnly = !masterDataEnhancedDetailDataSubjectDescriptionTextBox.ReadOnly;
            masterDataEnhancedDetailActiveStatusCheckBox.Enabled = !masterDataEnhancedDetailActiveStatusCheckBox.Enabled;
            masterDataEnhancedDetailUpdateDataSubjectButton.Enabled = !masterDataEnhancedDetailUpdateDataSubjectButton.Enabled;
        }

        private async void masterDataEnhancedDetailUpdateDataSubjectButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = masterDataEnhancedDetailActiveStatusCheckBox.Checked;
            string dataSubjectDescriptionValue = TextBoxCleanerHelper.GetTrimmedText(masterDataEnhancedDetailDataSubjectDescriptionTextBox);
            string dataSubjectValue = TextBoxCleanerHelper.GetTrimmedText(masterDataEnhancedDetailDataSubjectTextBox);

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
                    Name = dataSubjectFriendlyName,
                    Value = dataSubjectValue,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = $"{dataSubjectFriendlyName} Description",
                    Value = dataSubjectDescriptionValue,
                    MaxLength = 255,
                    ValueType = typeof(string)
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
                        OriginalValue = dataSubjectActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = dataSubjectFriendlyName,
                        OriginalValue = dataSubjectOriginalValue,
                        NewValue = dataSubjectValue
                    },
                    new ChangeDetail
                    {
                        VariableName = $"{dataSubjectFriendlyName} Description",
                        OriginalValue = dataSubjectDescriptionOriginalValue,
                        NewValue = dataSubjectDescriptionValue
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = ChangeValidationService.ConfirmChanges(changesList, dataSubjectName);

                if (confirmed)
                {
                    var parameters = new List<StoredProcedureParameter>
                    {
                        new StoredProcedureParameter
                        {
                            ParameterName = "activeStatus",
                            ParameterValue = activeStatus
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = $"{dataSubjectUpdateStoredProcedureParameterPrefix}",
                            ParameterValue = dataSubjectValue
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = $"{dataSubjectUpdateStoredProcedureParameterPrefix}Description",
                            ParameterValue = dataSubjectDescriptionValue
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = $"{dataSubjectUpdateStoredProcedureParameterPrefix}Id",
                            ParameterValue = _dataSubjectId
                        }
                    };

                    string operationType = "Update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(_databaseConnectionSettings, dataSubjectUpdateStoredProcedureName, parameters.ToArray(), dataSubjectName, operationType);
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