using CRM.Helpers;
using CRM.Interface;
using CRM.Model;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.MasterDataManagement
{
    public partial class CreateMasterDataSimple : Form
    {
        private Guid? _companyConfigurationId;
        private ActiveCompanyConfigurationHelper? _companyConfigHelper;
        private readonly FunctionTitle _functionTitle;
        private readonly ModuleGroup _moduleGroup;
        private UIModelHelper _uiModelHelper = new UIModelHelper();
        private readonly string applicationTitlePrefix = "CRM - Create ";
        private List<FunctionTitle> companyConfigurationEnabledDataSubjects;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private string dataSubjectCreateStoredProcedureName;
        private string dataSubjectFriendlyName;
        private string dataSubjectName;
        private string dataSubjectStoredProcedureParameterName;
        private readonly string titleLabelPrefix = "Create ";

        public CreateMasterDataSimple(FunctionTitle functionTitle, ModuleGroup moduleGroup)
        {
            InitializeComponent();
            _functionTitle = functionTitle;
            LoadDatabaseConnectionSettingsAsync();
            _moduleGroup = moduleGroup;
            SetModuleTheme();
            SetParameters();
        }

        private async void LoadActiveCompanyConfigurationAsync()
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(createMasterDataSimpleStatusStripCompanyConfigurationPlaceholder);
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

        private void SetParameters()
        {
            companyConfigurationEnabledDataSubjects = new List<FunctionTitle>
            {
                FunctionTitle.ProductCategory,
                FunctionTitle.ProductFamily,
                FunctionTitle.SalesRegion
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
            dataSubjectStoredProcedureParameterName = dataSubjectProperties.DataSubject.DataSubjectCamelCaseName;

            if (companyConfigurationEnabledDataSubjects.Contains(_functionTitle))
            {
                LoadActiveCompanyConfigurationAsync();
            }
            else
            {
                this.Size = new Size(544, 293);
                createMasterDataSimpleStatusStrip.Visible = false;
                createMasterDataSimpleStatusStripCompanyConfigurationPlaceholder.Visible = false;
            }

            dataSubjectName = _functionTitle.ToString();

            createMasterDataSimpleTitleLabel.Text = $"{titleLabelPrefix}{dataSubjectFriendlyName}";
            createMasterDataSimpleMasterDataTypeTextBoxLabel.Text = $"{dataSubjectFriendlyName}*";
            createMasterDataSimpleActiveStatusCheckBox.Text = $"Active {dataSubjectFriendlyName}*";
            this.Text = $"{applicationTitlePrefix}{dataSubjectFriendlyName}";
        }

        private async void changeActiveCompanyConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(createMasterDataSimpleStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.ShowChangeDialogAndReloadAsync(this);
            _companyConfigurationId = _companyConfigHelper.CompanyConfigurationId;
        }

        private async void createMasterDataSimpleSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createMasterDataSimpleActiveStatusCheckBox.Checked;
            string dataSubjectValue = TextBoxCleanerHelper.GetTrimmedText(createMasterDataSimpleMasterDataTypeTextBox);

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
                        ParameterName = dataSubjectStoredProcedureParameterName,
                        ParameterValue = dataSubjectValue
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

                string operationType = "Create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(_databaseConnectionSettings, dataSubjectCreateStoredProcedureName, parameters.ToArray(), dataSubjectName, operationType);
                this.Close();
            }
        }
    }
}