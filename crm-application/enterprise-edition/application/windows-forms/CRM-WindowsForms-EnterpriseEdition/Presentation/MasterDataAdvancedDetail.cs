using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
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
        private string dataParentSubjectIdName;
        private Guid dataParentSubjectOriginalValue;
        private string dataParentSubjectName;
        private string dataParentSubjectGetStoredProcedureName;
        private bool? dataSubjectActiveStatusOriginalValue;
        private Guid dataSubjectCompanyConfigurationIdOriginalValue;
        private string dataSubjectFriendlyName;
        private string dataSubjectGetStoredProcedureName;
        private string dataSubjectIdFriendlyName;
        private string dataSubjectIdName;
        private string dataSubjectName;
        private string? dataSubjectOriginalValue;
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

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task LoadCompanyConfigurationAsync(Guid companyConfigurationId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(masterDataAdvancedDetailCompanyConfigurationComboBox, "spGetAllCompanyConfiguration", null, true, "Company Configuration Id", companyConfigurationId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private void InitializeEventHandlers()
        {
            masterDataAdvancedDetailDataParentSubjectComboBox.DropDown += AdjustComboBoxWidth_DropDown;
            masterDataAdvancedDetailToggleEditModeButton.Click += masterDataAdvancedDetailToggleEditModeButton_Click;
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
                    dataParentSubjectIdName = "ProductCategoryId";
                    dataParentSubjectName = "ProductCategory";
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
                    dataParentSubjectIdName = "SalesRegionId";
                    dataParentSubjectName = "SalesRegion";
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
            masterDataAdvancedDetailActiveStatusCheckbox.Text = $"Active {dataSubjectFriendlyName}";
            masterDataAdvancedDetailUpdateDataSubjectButton.Text = $"Update {dataSubjectFriendlyName}";
            this.Text = $"{applicationTitlePrefix}{dataSubjectFriendlyName}{titleLabelSuffix}";
        }

        private async Task LoadDataParentSubjectAsync(Guid companyConfigurationId, Guid dataParentSubjectId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(masterDataAdvancedDetailDataParentSubjectComboBox, dataParentSubjectGetStoredProcedureName, companyConfigurationId, true, dataParentSubjectIdFriendlyName, dataParentSubjectId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDownHelper.AdjustComboBoxDropDownWidth(sender as ComboBox);
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
                new Parameter
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
                    await LoadCompanyConfigurationAsync(companyConfigurationId);
                    Guid dataSubjectParentId = (Guid)masterDataAdvancedDetailDataRow[dataParentSubjectIdFriendlyName];
                    await LoadDataParentSubjectAsync(companyConfigurationId, dataSubjectParentId);
                    masterDataAdvancedDetailDataSubjectTextBox.Text = masterDataAdvancedDetailDataRow[dataSubjectFriendlyName].ToString();
                    
                    masterDataAdvancedDetailCreatedByTextBox.Text = masterDataAdvancedDetailDataRow["Created By"].ToString();
                    masterDataAdvancedDetailCreatedTimestampTextBox.Text = masterDataAdvancedDetailDataRow["Created Timestamp UTC"].ToString();
                    masterDataAdvancedDetailLastUpdatedByTextBox.Text = masterDataAdvancedDetailDataRow["Modified By"].ToString();
                    masterDataAdvancedDetailLastUpdatedTimestampTextBox.Text = masterDataAdvancedDetailDataRow["Modified Timestamp UTC"].ToString();
                    masterDataAdvancedDetailActiveStatusCheckbox.Checked = (bool)masterDataAdvancedDetailDataRow["Active Status"];

                    dataParentSubjectOriginalValue = (Guid)masterDataAdvancedDetailDataRow[dataParentSubjectIdFriendlyName];
                    dataSubjectCompanyConfigurationIdOriginalValue = (Guid)masterDataAdvancedDetailDataRow["Company Configuration Id"];
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

        private async void masterDataAdvancedDetailUpdateDataSubjectButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = masterDataAdvancedDetailActiveStatusCheckbox.Checked;
            Guid companyConfigurationId = (Guid)masterDataAdvancedDetailCompanyConfigurationComboBox.SelectedValue;
            Guid dataParentSubjectIdValue = (Guid)masterDataAdvancedDetailDataParentSubjectComboBox.SelectedValue;
            string dataSubjectValue = masterDataAdvancedDetailDataSubjectTextBox.Text.TrimEnd();

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
                    Name = "ActiveStatus",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Company Configuration id",
                    Value = companyConfigurationId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = dataParentSubjectFriendlyName,
                    Value = dataParentSubjectIdValue,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = dataSubjectFriendlyName,
                    Value = dataSubjectValue,
                    MaxLength = 50,
                    ValueType = typeof(string)
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
                        VariableType = "bool",
                        OriginalValue = dataSubjectActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Company Configuration Id",
                        VariableType = "Guid",
                        OriginalValue = dataSubjectCompanyConfigurationIdOriginalValue,
                        NewValue = companyConfigurationId
                    },
                    new ChangeDetail
                    {
                        VariableName = dataParentSubjectFriendlyName,
                        VariableType = "Guid",
                        OriginalValue = dataParentSubjectOriginalValue,
                        NewValue = dataParentSubjectIdValue
                    },
                    new ChangeDetail
                    {
                        VariableName = dataSubjectFriendlyName,
                        VariableType = "string",
                        OriginalValue = dataSubjectOriginalValue,
                        NewValue = dataSubjectValue
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = UpdateConfirmationService.ConfirmChanges(changesList, dataSubjectName);

                if (confirmed)
                {
                    var parameters = new[]
                    {
                        new Parameter
                        {
                            ParameterName = "activeStatus",
                            ParameterValue = activeStatus
                        },
                        new Parameter
                        {
                            ParameterName = "companyConfigurationId",
                            ParameterValue = companyConfigurationId
                        },
                        new Parameter
                        {
                            ParameterName = $"{dataSubjectUpdateStoredProcedureParentDataSubjectParameterPrefix}Id",
                            ParameterValue = dataParentSubjectIdValue
                        },
                        new Parameter
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

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            SetParameters(_functionTitle);
            MasterDataAdvancedDetailMasterDataInformation_Load(this, EventArgs.Empty);
        }

        private void masterDataAdvancedDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            masterDataAdvancedDetailDataParentSubjectComboBox.Enabled = !masterDataAdvancedDetailDataParentSubjectComboBox.Enabled;
            masterDataAdvancedDetailDataSubjectTextBox.ReadOnly = !masterDataAdvancedDetailDataSubjectTextBox.ReadOnly;
            masterDataAdvancedDetailCompanyConfigurationComboBox.Enabled = !masterDataAdvancedDetailCompanyConfigurationComboBox.Enabled;
            masterDataAdvancedDetailActiveStatusCheckbox.Enabled = !masterDataAdvancedDetailActiveStatusCheckbox.Enabled;
            masterDataAdvancedDetailUpdateDataSubjectButton.Enabled = !masterDataAdvancedDetailUpdateDataSubjectButton.Enabled;
        }
    }
}