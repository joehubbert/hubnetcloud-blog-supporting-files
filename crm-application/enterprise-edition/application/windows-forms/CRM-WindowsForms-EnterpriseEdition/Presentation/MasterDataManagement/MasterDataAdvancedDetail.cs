using CRM.Helpers;
using CRM.Interface;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.MasterDataManagement
{
    public partial class MasterDataAdvancedDetail : Form
    {
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private readonly Guid _dataSubjectId;
        private DatabaseConnectionSettings? _databaseConnectionSettings;     
        private readonly string _functionTitle;
        private readonly string _moduleGroup;
        private readonly string applicationTitlePrefix = "CRM - ";
        private string dataParentSubjectFriendlyName;
        private string dataParentSubjectIdFriendlyName;
        private Guid dataParentSubjectOriginalValue;
        private string dataParentSubjectGetStoredProcedureName;
        private bool dataSubjectActiveStatusOriginalValue;
        private string dataSubjectFriendlyName;
        private string dataSubjectGetStoredProcedureName;
        private string dataSubjectIdFriendlyName;
        private string dataSubjectIdName;
        private string dataSubjectName;
        private string dataSubjectOriginalValue;
        private string dataSubjectUpdateStoredProcedureName;
        private string dataSubjectUpdateStoredProcedureParameterPrefix;
        private string dataSubjectUpdateStoredProcedureParentDataSubjectParameterPrefix;
        private readonly string titleLabelSuffix = " Detail";

        public MasterDataAdvancedDetail(Guid dataSubjectId, string functionTitle, string moduleGroup)
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
            MasterDataAdvancedDetailMasterDataInformation_Load(this, EventArgs.Empty);
        }

        private void InitializeEventHandlers()
        {
            masterDataAdvancedDetailDataParentSubjectComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
        }

        private async Task LoadDataParentSubjectAsync(Guid companyConfigurationId, Guid dataParentSubjectId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(masterDataAdvancedDetailDataParentSubjectComboBox,
                dataParentSubjectGetStoredProcedureName,
                companyConfigurationId,
                true,
                dataParentSubjectIdFriendlyName,
                dataParentSubjectId,
                false,
                null,
                null,
                null,
                true);
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
                    ParameterName = $"@{dataSubjectUpdateStoredProcedureParameterPrefix}Id",
                    ParameterValue = _dataSubjectId
                }
            };

            try
            {
                DataTable? masterDataAdvancedDetailDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(
                    dataSubjectGetStoredProcedureName,
                    parameters.ToArray(),
                    dataSubjectName);

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

                    dataParentSubjectOriginalValue = (Guid)masterDataAdvancedDetailDataRow[dataParentSubjectIdFriendlyName];
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

        private void SetParameters(string functionTitle)
        {
            switch (functionTitle)
            {
                case "ProductSubCategory":
                    dataParentSubjectFriendlyName = "Product Category";
                    dataParentSubjectIdFriendlyName = "Product Category Id";
                    dataParentSubjectGetStoredProcedureName = "spGetAllProductCategory";
                    dataSubjectFriendlyName = "Product Sub Category";
                    dataSubjectGetStoredProcedureName = "spGetProductSubCategory";
                    dataSubjectIdFriendlyName = "Product Sub Category Id";
                    dataSubjectIdName = "ProductSubCategoryId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateProductSubCategory";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "productSubCategory";
                    dataSubjectUpdateStoredProcedureParentDataSubjectParameterPrefix = "productCategory";
                    break;
                case "SalesSubRegion":
                    dataParentSubjectFriendlyName = "Sales Region";
                    dataParentSubjectIdFriendlyName = "Sales Region Id";
                    dataParentSubjectGetStoredProcedureName = "spGetAllSalesRegion";
                    dataSubjectFriendlyName = "Sales Sub Region";
                    dataSubjectGetStoredProcedureName = "spGetSalesSubRegion";
                    dataSubjectIdFriendlyName = "Sales Sub Region Id";
                    dataSubjectIdName = "SalesSubRegionId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateSalesSubRegion";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "salesSubRegion";
                    dataSubjectUpdateStoredProcedureParentDataSubjectParameterPrefix = "salesRegion";
                    break;
                default:
                    this.Text = functionTitle;
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", functionTitle);
                    break;
            }

            dataSubjectName = functionTitle;

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
                        OriginalValue = dataParentSubjectOriginalValue,
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
                            ParameterName = $"{dataSubjectUpdateStoredProcedureParentDataSubjectParameterPrefix}Id",
                            ParameterValue = dataParentSubjectIdValue
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = $"{dataSubjectUpdateStoredProcedureParameterPrefix}",
                            ParameterValue = dataSubjectValue
                        }
                    };

                    string operationType = "update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(dataSubjectUpdateStoredProcedureName, parameters, dataSubjectName, operationType);
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