using CRM.Helpers;
using CRM.Interface;
using CRM.Model;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.MasterDataManagement
{
    public partial class CreateMasterDataEnhanced : Form
    {
        private Guid? _companyConfigurationId;
        private ActiveCompanyConfigurationHelper? _companyConfigHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly FunctionTitle _functionTitle;
        private readonly ModuleGroup _moduleGroup;
        private UIModelHelper _uiModelHelper = new UIModelHelper();
        private readonly string applicationTitlePrefix = "CRM - Create ";
        private List<FunctionTitle> companyConfigurationEnabledDataSubjects;
        private string dataSubjectCreateStoredProcedureName;
        private string dataSubjectFriendlyName;
        private string dataSubjectName;
        private string dataSubjectStoredProcedureParameter;
        private string dataSubjectStoredProcedureDescriptionParameter;
        private readonly string titleLabelPrefix = "Create ";

        public CreateMasterDataEnhanced(FunctionTitle functionTitle, ModuleGroup moduleGroup)
        {
            InitializeComponent();
			_functionTitle = functionTitle;
            LoadDatabaseConnectionSettingsAsync();
            _moduleGroup = moduleGroup;
            SetModuleTheme();
            SetParameters();
        }

		private async Task LoadActiveCompanyConfigurationAsync()
		{
			_companyConfigHelper = new ActiveCompanyConfigurationHelper(createMasterDataEnhancedStatusStripCompanyConfigurationPlaceholder);
			await _companyConfigHelper.LoadAsync();
			_companyConfigurationId = _companyConfigHelper.CompanyConfigurationId;
		}

		private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void SetModuleTheme()
        {
            ModuleThemeHelper.ApplyTheme(this, _moduleGroup);
        }

        private async void SetParameters()
        {
            companyConfigurationEnabledDataSubjects = new List<FunctionTitle>
            {
                FunctionTitle.CustomerLeadType,
                FunctionTitle.CustomerType
            };

            var dataSubjectProperties = _uiModelHelper.GetDataSubjectProperties(_functionTitle);
            if (dataSubjectProperties == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", _functionTitle.ToString());
                return;
            }

            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataSubject.DataSubjectCreateStoredProcedureName))
            {
                dataSubjectCreateStoredProcedureName = dataSubjectProperties.DataSubject.DataSubjectCreateStoredProcedureName;
            }
            
            dataSubjectFriendlyName = dataSubjectProperties.DataSubject.DataSubjectFriendlyName;
            dataSubjectStoredProcedureParameter = dataSubjectProperties.DataSubject.DataSubjectCamelCaseName;
            dataSubjectStoredProcedureDescriptionParameter = $"{dataSubjectStoredProcedureParameter}Description";

			if (companyConfigurationEnabledDataSubjects.Contains(_functionTitle))
			{
				await LoadActiveCompanyConfigurationAsync();
			}
			else
			{
				this.Size = new Size(614, 330);
				createMasterDataEnhancedStatusStrip.Visible = false;
				createMasterDataEnhancedStatusStripCompanyConfigurationPlaceholder.Visible = false;
			}

			dataSubjectName = _functionTitle.ToString();
            createMasterDataEnhancedTitleLabel.Text = $"{titleLabelPrefix}{dataSubjectFriendlyName}";
            createMasterDataEnhancedMasterDataTypeTextBoxLabel.Text = $"{dataSubjectFriendlyName}*";
            createMasterDataEnhancedMasterDataDescriptionTextBoxLabel.Text = $"{dataSubjectFriendlyName} Description*";
            createMasterDataEnhancedActiveStatusCheckBox.Text = $"Active {dataSubjectFriendlyName}*";
            this.Text = $"{applicationTitlePrefix}{dataSubjectFriendlyName}";
        }

		private async void changeActiveCompanyConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_companyConfigHelper = new ActiveCompanyConfigurationHelper(createMasterDataEnhancedStatusStripCompanyConfigurationPlaceholder);
			await _companyConfigHelper.ShowChangeDialogAndReloadAsync(this);
			_companyConfigurationId = _companyConfigHelper.CompanyConfigurationId;
		}

		private async void createMasterDataEnhancedSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createMasterDataEnhancedActiveStatusCheckBox.Checked;
            string dataSubjectDescriptionValue = TextBoxCleanerHelper.GetTrimmedText(createMasterDataEnhancedMasterDataDescriptionTextBox);
            string dataSubjectValue = TextBoxCleanerHelper.GetTrimmedText(createMasterDataEnhancedMasterDataTypeTextBox);

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
                    AllowNullValue = true,
                    Name = "Company Configuration Id",
                    Value = _companyConfigurationId,
                    ValueType = typeof(Guid)
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
                    }
                };

                if (companyConfigurationEnabledDataSubjects.Contains(_functionTitle))
                {
                    parameters.Add(new StoredProcedureParameter
                    {
                        ParameterName = "companyConfigurationId",
                        ParameterValue = _companyConfigurationId
                    });
                }

                DataOperationType operationType = DataOperationType.Create;

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(dataSubjectName, _databaseConnectionSettings, operationType, dataSubjectCreateStoredProcedureName, parameters.ToArray());
                this.Close();
            }
        }
    }
}