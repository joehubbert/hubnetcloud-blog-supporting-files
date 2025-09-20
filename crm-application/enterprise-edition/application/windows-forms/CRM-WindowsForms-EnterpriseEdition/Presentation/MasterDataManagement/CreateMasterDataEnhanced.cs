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
        private readonly string _functionTitle;
        private readonly string _moduleGroup;
        private readonly string applicationTitlePrefix = "CRM - Create ";
        private List<string> companyConfigurationEnabledDataSubjects;
        private string dataSubjectFriendlyName;
        private string dataSubjectName;
        private string dataSubjectStoredProcedureName;
        private string dataSubjectStoredProcedureParameterPrefix;
        private readonly string titleLabelPrefix = "Create ";

        public CreateMasterDataEnhanced(string functionTitle, string moduleGroup)
        {
            InitializeComponent();
			_functionTitle = functionTitle;
            LoadDatabaseConnectionSettingsAsync();
            _moduleGroup = moduleGroup;
            SetModuleTheme();
            SetParameters(_functionTitle);
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

        private async void SetParameters(string functionTitle)
        {
            companyConfigurationEnabledDataSubjects = new List<string>
            {
                "CustomerLeadType",
                "CustomerType"
            };

            switch (functionTitle)
            {
                case "CustomerLeadType":
                    dataSubjectFriendlyName = "Customer Lead Type";
                    dataSubjectStoredProcedureName = "spCreateCustomerLeadType";
                    dataSubjectStoredProcedureParameterPrefix = "customerLeadType";
                    break;
                case "CustomerType":
                    dataSubjectFriendlyName = "Customer Type";
                    dataSubjectStoredProcedureName = "spCreateCustomerType";
                    dataSubjectStoredProcedureParameterPrefix = "customerType";
                    break;
                case "PromotionTargetType":
                    dataSubjectFriendlyName = "Promotion Target Type";
                    dataSubjectStoredProcedureName = "spCreatePromotionTargetType";
                    dataSubjectStoredProcedureParameterPrefix = "promotionTargetType";
                    break;
                default:
                    this.Text = functionTitle;
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", functionTitle);
                    break;
            }

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

			dataSubjectName = functionTitle;
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
                        ParameterName = $"{dataSubjectStoredProcedureParameterPrefix}",
                        ParameterValue = dataSubjectValue
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = $"{dataSubjectStoredProcedureParameterPrefix}Description",
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

                string operationType = "Create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(_databaseConnectionSettings, dataSubjectStoredProcedureName, parameters.ToArray(), dataSubjectName, operationType);
                this.Close();
            }
        }
    }
}