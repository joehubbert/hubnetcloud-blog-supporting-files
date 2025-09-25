using CRM.Helpers;
using CRM.Interface;
using CRM.Model;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.MasterDataManagement
{
    public partial class MasterDataEnhancedDetail : Form
    {
        private readonly Guid _dataSubjectId;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly FunctionTitle _functionTitle;
        private readonly ModuleGroup _moduleGroup;
        private UIModelHelper _uiModelHelper = new UIModelHelper();
        private readonly string applicationTitlePrefix = "CRM - ";
        private bool dataSubjectActiveStatusOriginalValue;  
        private string dataSubjectDescriptionOriginalValue;
        private string dataSubjectFriendlyName;    
        private string dataSubjectIdFriendlyName;
        private string dataSubjectName;
        private string dataSubjectOriginalValue;
        private string dataSubjectSelectStoredProcedure;
        private string dataSubjectStoredProcedureDescriptionParameter;
        private string dataSubjectStoredProcedureIdParameter;
        private string dataSubjectStoredProcedureParameter;
        private string dataSubjectUpdateStoredProcedureName;
        private readonly string titleLabelSuffix = " Detail";

        public MasterDataEnhancedDetail(Guid dataSubjectId, FunctionTitle functionTitle, ModuleGroup moduleGroup)
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
            SetParameters();
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
                    ParameterName = dataSubjectStoredProcedureIdParameter,
                    ParameterValue = _dataSubjectId
                }
            };

            try
            {
                DataTable? masterDataEnhancedDetailDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(
                    _databaseConnectionSettings,
                    dataSubjectSelectStoredProcedure,
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

        private void SetParameters()
        {
            var dataSubjectProperties = _uiModelHelper.GetDataSubjectProperties(_functionTitle);
            if (dataSubjectProperties == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", _functionTitle.ToString());
                return;
            }

            dataSubjectFriendlyName = dataSubjectProperties.DataSubject.DataSubjectFriendlyName;

            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName))
            {
                dataSubjectIdFriendlyName = dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName;
            }               

            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataSubject.DataSubjectSelectStoredProcedureName))
            {
                dataSubjectSelectStoredProcedure = dataSubjectProperties.DataSubject.DataSubjectSelectStoredProcedureName;
            }

            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataSubject.DataSubjectUpdateStoredProcedureName))
            {
                dataSubjectUpdateStoredProcedureName = dataSubjectProperties.DataSubject.DataSubjectUpdateStoredProcedureName;
            }

            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataSubject.DataSubjectStoredProcedureIdParameterName))
            {
                dataSubjectStoredProcedureIdParameter = dataSubjectProperties.DataSubject.DataSubjectStoredProcedureIdParameterName;
            }

            dataSubjectStoredProcedureParameter = dataSubjectProperties.DataSubject.DataSubjectCamelCaseName;
            dataSubjectStoredProcedureDescriptionParameter = $"{dataSubjectStoredProcedureParameter}Description";

            dataSubjectName = _functionTitle.ToString();

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
                            ParameterName = dataSubjectStoredProcedureParameter,
                            ParameterValue = dataSubjectValue
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = dataSubjectStoredProcedureDescriptionParameter,
                            ParameterValue = dataSubjectDescriptionValue
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = dataSubjectStoredProcedureIdParameter,
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