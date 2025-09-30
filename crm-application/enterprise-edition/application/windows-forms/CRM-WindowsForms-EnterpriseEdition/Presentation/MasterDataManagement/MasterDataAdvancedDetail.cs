using CRM.Helpers;
using CRM.Interface;
using CRM.Model;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.MasterDataManagement
{
    public partial class MasterDataAdvancedDetail : Form
    {
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private readonly Guid _dataSubjectId;
        private DatabaseConnectionSettings? _databaseConnectionSettings;     
        private readonly FunctionTitle _functionTitle;
        private readonly ModuleGroup _moduleGroup;
        private UIModelHelper _uiModelHelper = new UIModelHelper();
        private readonly string applicationTitlePrefix = "CRM - ";
        private string dataParentSubjectFriendlyName;
        private FunctionTitle dataParentSubjectFunctionTitle;
        private string dataParentSubjectIdFriendlyName; 
        private Guid dataParentSubjectIdOriginalValue;
        private string dataParentSubjectSelectAllStoredProcedureName;
        private string dataParentSubjectStoredProcedureIdParameterName;
        private bool dataSubjectActiveStatusOriginalValue;        
        private string dataSubjectFriendlyName;
        private string dataSubjectIdFriendlyName;
        private string dataSubjectName;
        private string dataSubjectOriginalValue;
        private string dataSubjectSelectStoredProcedureName;
        private string dataSubjectStoredProcedureIdParameterName;
        private string dataSubjectStoredProcedureParameterName;
        private string dataSubjectUpdateStoredProcedureName;
        private readonly string titleLabelSuffix = " Detail";

        public MasterDataAdvancedDetail(Guid dataSubjectId, FunctionTitle functionTitle, ModuleGroup moduleGroup)
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
            MasterDataAdvancedDetailMasterDataInformation_Load(this, EventArgs.Empty);
        }

        private void InitializeEventHandlers()
        {
            masterDataAdvancedDetailDataParentSubjectComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
        }

        private async Task LoadDataParentSubjectAsync(Guid companyConfigurationId, Guid dataParentSubjectId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(
                comboBox: masterDataAdvancedDetailDataParentSubjectComboBox,
                companyConfigurationId: companyConfigurationId,
                dataSubjectFilter1: true,
                dataSubjectFilterColumn1: dataParentSubjectIdFriendlyName,
                dataSubjectId1: dataParentSubjectId,
                functionTitle: dataParentSubjectFunctionTitle,
                treatFiltersAsPreselection: true
            );
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void MasterDataAdvancedDetailMasterDataInformation_Load(object sender, EventArgs e)
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
                    ParameterName = dataSubjectStoredProcedureIdParameterName,
                    ParameterValue = _dataSubjectId
                }
            };

            try
            {
                DataTable? masterDataAdvancedDetailDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(
                    dataSubjectName,
                    _databaseConnectionSettings,
                    dataSubjectSelectStoredProcedureName,
                    parameters.ToArray()
                    );

                if (masterDataAdvancedDetailDataTable != null)
                {
                    DataRow masterDataAdvancedDetailDataRow = masterDataAdvancedDetailDataTable.Rows[0];
                    masterDataAdvancedDetailDataSubjectIdTextBox.Text = masterDataAdvancedDetailDataRow[dataSubjectIdFriendlyName].ToString();
                    Guid companyConfigurationId = (Guid)masterDataAdvancedDetailDataRow["Company Configuration Id"];
                    Guid dataSubjectParentId = (Guid)masterDataAdvancedDetailDataRow[dataParentSubjectIdFriendlyName];
                    await LoadDataParentSubjectAsync(companyConfigurationId, dataSubjectParentId);
                    masterDataAdvancedDetailDataSubjectTextBox.Text = masterDataAdvancedDetailDataRow[dataSubjectFriendlyName].ToString();

                    masterDataAdvancedDetailCreatedByTextBox.Text = masterDataAdvancedDetailDataRow["Created By"].ToString();
                    masterDataAdvancedDetailCreatedTimestampTextBox.Text = masterDataAdvancedDetailDataRow["Created Timestamp UTC"].ToString();
                    masterDataAdvancedDetailLastUpdatedByTextBox.Text = masterDataAdvancedDetailDataRow["Modified By"].ToString();
                    masterDataAdvancedDetailLastUpdatedTimestampTextBox.Text = masterDataAdvancedDetailDataRow["Modified Timestamp UTC"].ToString();
                    masterDataAdvancedDetailActiveStatusCheckBox.Checked = (bool)masterDataAdvancedDetailDataRow["Active Status"];

                    dataParentSubjectIdOriginalValue = (Guid)masterDataAdvancedDetailDataRow[dataParentSubjectIdFriendlyName];
                    dataSubjectOriginalValue = masterDataAdvancedDetailDataRow[dataSubjectFriendlyName].ToString();
                    dataSubjectActiveStatusOriginalValue = (bool)masterDataAdvancedDetailDataRow["Active Status"];

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
            if (dataSubjectProperties == null || dataSubjectProperties.DataParentSubject == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", _functionTitle.ToString());
                return;
            }

            dataParentSubjectFriendlyName = dataSubjectProperties.DataParentSubject.DataSubjectFriendlyName;
            dataParentSubjectFunctionTitle = dataSubjectProperties.DataParentSubject.DataSubject;

            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataParentSubject.DataSubjectIdFriendlyName))
            {
                dataParentSubjectIdFriendlyName = dataSubjectProperties.DataParentSubject.DataSubjectIdFriendlyName;
            }
            
            dataParentSubjectSelectAllStoredProcedureName = dataSubjectProperties.DataParentSubject.DataSubjectSelectAllStoredProcedureName;

            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataParentSubject.DataSubjectStoredProcedureIdParameterName))
            {
                dataParentSubjectStoredProcedureIdParameterName = dataSubjectProperties.DataParentSubject.DataSubjectStoredProcedureIdParameterName;
            }
            
            dataSubjectStoredProcedureParameterName = dataSubjectProperties.DataSubject.DataSubjectCamelCaseName;
            dataSubjectFriendlyName = dataSubjectProperties.DataSubject.DataSubjectFriendlyName;

            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName))
            {
                dataSubjectIdFriendlyName = dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName;
            }
            
            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataSubject.DataSubjectSelectStoredProcedureName))
            {
                dataSubjectSelectStoredProcedureName = dataSubjectProperties.DataSubject.DataSubjectSelectStoredProcedureName;
            }
            
            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataSubject.DataSubjectStoredProcedureIdParameterName))
            {
                dataSubjectStoredProcedureIdParameterName = dataSubjectProperties.DataSubject.DataSubjectStoredProcedureIdParameterName;
            }
             
            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataSubject.DataSubjectUpdateStoredProcedureName))
            {
                dataSubjectUpdateStoredProcedureName = dataSubjectProperties.DataSubject.DataSubjectUpdateStoredProcedureName;
            }

            dataSubjectName = _functionTitle.ToString();

            masterDataAdvancedDetailTitleLabel.Text = $"{dataSubjectFriendlyName}{titleLabelSuffix}";
            masterDataAdvancedDetailDataSubjectIdTextBoxLabel.Text = dataSubjectIdFriendlyName;
            masterDataAdvancedDetailDataParentSubjectComboBoxLabel.Text = dataParentSubjectFriendlyName;
            masterDataAdvancedDetailDataSubjectTextBoxLabel.Text = dataSubjectFriendlyName;
            masterDataAdvancedDetailActiveStatusCheckBox.Text = $"Active {dataSubjectFriendlyName}";
            masterDataAdvancedDetailUpdateDataSubjectButton.Text = $"Update {dataSubjectFriendlyName}";
            this.Text = $"{applicationTitlePrefix}{dataSubjectFriendlyName}{titleLabelSuffix}";
        }

        private void masterDataAdvancedDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            masterDataAdvancedDetailDataParentSubjectComboBox.Enabled = !masterDataAdvancedDetailDataParentSubjectComboBox.Enabled;
            masterDataAdvancedDetailDataSubjectTextBox.ReadOnly = !masterDataAdvancedDetailDataSubjectTextBox.ReadOnly;
            masterDataAdvancedDetailActiveStatusCheckBox.Enabled = !masterDataAdvancedDetailActiveStatusCheckBox.Enabled;
            masterDataAdvancedDetailUpdateDataSubjectButton.Enabled = !masterDataAdvancedDetailUpdateDataSubjectButton.Enabled;
        }

        private async void masterDataAdvancedDetailUpdateDataSubjectButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = masterDataAdvancedDetailActiveStatusCheckBox.Checked;
            Guid dataParentSubjectIdValue = (Guid)masterDataAdvancedDetailDataParentSubjectComboBox.SelectedValue;
            string dataSubjectValue = TextBoxCleanerHelper.GetTrimmedText(masterDataAdvancedDetailDataSubjectTextBox);

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
                    Name = "ActiveStatus",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = dataParentSubjectFriendlyName,
                    Value = dataParentSubjectIdValue,
                    ValueType = typeof(Guid)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = dataSubjectFriendlyName,
                    Value = dataSubjectValue,
                    MaxLength = 50,
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
                        VariableName = dataParentSubjectFriendlyName,
                        OriginalValue = dataParentSubjectIdOriginalValue,
                        NewValue = dataParentSubjectIdValue
                    },
                    new ChangeDetail
                    {
                        VariableName = dataSubjectFriendlyName,
                        OriginalValue = dataSubjectOriginalValue,
                        NewValue = dataSubjectValue
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = ChangeValidationService.ConfirmChanges(changesList, dataSubjectName);

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
                            ParameterName = dataParentSubjectStoredProcedureIdParameterName,
                            ParameterValue = dataParentSubjectIdValue
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = dataSubjectStoredProcedureParameterName,
                            ParameterValue = dataSubjectValue
                        }
                    };

                    DataOperationType operationType = DataOperationType.Update;

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(dataSubjectName, _databaseConnectionSettings, operationType, dataSubjectUpdateStoredProcedureName, parameters);
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