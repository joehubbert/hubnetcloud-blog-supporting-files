using CRM.Helpers;
using CRM.Interface;
using CRM.Model;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.MasterDataManagement
{
    public partial class CreateMasterDataAdvanced : Form
    {
        private Guid _companyConfigurationId;
        private ActiveCompanyConfigurationHelper? _companyConfigHelper;
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string _functionTitle;
        private readonly string _moduleGroup;
        private readonly string applicationTitlePrefix = "CRM - Create ";
        private string dataParentSubjectFriendlyName;
        private string dataParentSubjectIdFriendlyName;
        private string dataParentSubjectGetStoredProcedureName;
        private string dataSubjectFriendlyName;
        private string dataSubjectName;
        private string dataSubjectCreateStoredProcedureName;
        private string dataSubjectCreateStoredProcedureParameterPrefix;
        private string dataSubjectCreateStoredProcedureParentDataSubjectParameterPrefix;
        private readonly string titleLabelPrefix = "Create ";

        public CreateMasterDataAdvanced(string functionTitle, string moduleGroup)
        {
            InitializeComponent();
            _functionTitle = functionTitle;
            LoadDatabaseConnectionSettingsAsync();
            LoadActiveCompanyConfigurationAsync();
            _moduleGroup = moduleGroup;
            SetModuleTheme();
            SetParameters(_functionTitle);
        }

        private void InitializeEventHandlers()
        {
            createMasterDataAdvancedDataParentSubjectComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
        }

        private async void LoadActiveCompanyConfigurationAsync()
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(createMasterDataAdvancedStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.LoadAsync();
            _companyConfigurationId = _companyConfigHelper.CompanyConfigurationId;
        }

        private async void LoadDataParentSubjectAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createMasterDataAdvancedDataParentSubjectComboBox, dataParentSubjectGetStoredProcedureName, _companyConfigurationId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void SetModuleTheme()
        {
            ModuleThemeHelper.ApplyTheme(this, _moduleGroup);
        }

        private void SetParameters(string functionTitle)
        {
            switch (functionTitle)
            {
                case "ProductSubCategory":
                    dataParentSubjectFriendlyName = "Product Category";
                    dataParentSubjectIdFriendlyName = "Product Category Id";
                    dataParentSubjectGetStoredProcedureName = "spGetAllProductCategory";
                    dataSubjectFriendlyName = "Product Sub Category";
                    dataSubjectCreateStoredProcedureName = "spCreateProductSubCategory";
                    dataSubjectCreateStoredProcedureParameterPrefix = "productSubCategory";
                    dataSubjectCreateStoredProcedureParentDataSubjectParameterPrefix = "productCategory";
                    break;
                case "SalesSubRegion":
                    dataParentSubjectFriendlyName = "Sales Region";
                    dataParentSubjectIdFriendlyName = "Sales Region Id";
                    dataParentSubjectGetStoredProcedureName = "spGetAllSalesRegion";
                    dataSubjectFriendlyName = "Sales Sub Region";
                    dataSubjectCreateStoredProcedureName = "spCreateSalesSubRegion";
                    dataSubjectCreateStoredProcedureParameterPrefix = "salesSubRegion";
                    dataSubjectCreateStoredProcedureParentDataSubjectParameterPrefix = "salesRegion";
                    break;
                default:
                    this.Text = functionTitle;
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", functionTitle);
                    break;
            }

            dataSubjectName = functionTitle;

            createMasterDataAdvancedTitleLabel.Text = $"{titleLabelPrefix}{dataSubjectFriendlyName}";
            createMasterDataAdvancedDataParentSubjectComboBoxLabel.Text = $"{dataParentSubjectFriendlyName}*";
            createMasterDataAdvancedMasterDataTypeTextBoxLabel.Text = $"{dataSubjectFriendlyName}*";
            createMasterDataAdvancedActiveStatusCheckBox.Text = $"Active {dataSubjectFriendlyName}*";
            this.Text = $"{applicationTitlePrefix}{dataSubjectFriendlyName}";
            InitializeEventHandlers();
            LoadDataParentSubjectAsync();
        }

        private async void changeActiveCompanyConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(createMasterDataAdvancedStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.ShowChangeDialogAndReloadAsync(this);
            _companyConfigurationId = _companyConfigHelper.CompanyConfigurationId;
        }

        private async void createMasterDataAdvancedSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createMasterDataAdvancedActiveStatusCheckBox.Checked;
            Guid dataParentSubjectValue = (Guid)createMasterDataAdvancedDataParentSubjectComboBox.SelectedValue;
            string dataSubjectValue = TextBoxCleanerHelper.GetTrimmedText(createMasterDataAdvancedMasterDataTypeTextBox);

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
                    Name = "Company Configuration Id",
                    Value = _companyConfigurationId,
                    ValueType = typeof(Guid)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = dataParentSubjectIdFriendlyName,
                    Value = dataParentSubjectValue,
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
                var parameters = new[]
                {
                    new StoredProcedureParameter
                    {
                        ParameterName = "activeStatus",
                        ParameterValue = activeStatus
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = $"{dataSubjectCreateStoredProcedureParentDataSubjectParameterPrefix}Id",
                        ParameterValue = dataParentSubjectValue
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = $"{dataSubjectCreateStoredProcedureParameterPrefix}",
                        ParameterValue = dataSubjectValue
                    }
                };

                string operationType = "Create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(_databaseConnectionSettings, dataSubjectCreateStoredProcedureName, parameters, dataSubjectName, operationType);
                this.Close();
            }
        }
    }
}