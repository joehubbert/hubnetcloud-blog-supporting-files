using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class MasterDataEnhancedDetail : Form
    {
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private readonly Guid _dataSubjectId;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string _functionTitle;
        private readonly string _moduleGroup;
        private readonly string applicationTitlePrefix = "CRM - ";
        private List<string> companyConfigurationEnabledDataSubjects;
        private bool? dataSubjectActiveStatusOriginalValue;
        private Guid? dataSubjectCompanyConfigurationIdOriginalValue;
        private string? dataSubjectDescriptionOriginalValue;
        private string dataSubjectFriendlyName;
        private string dataSubjectGetStoredProcedureName;
        private string dataSubjectIdFriendlyName;
        private string dataSubjectIdName;
        private string dataSubjectName;
        private string? dataSubjectOriginalValue;
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

        private void InitializeEventHandlers()
        {
            masterDataEnhancedDetailToggleEditModeButton.Click += masterDataEnhancedDetailToggleEditModeButton_Click;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task LoadCompanyConfigurationAsync(Guid companyConfigurationId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(masterDataEnhancedDetailCompanyConfigurationComboBox, "spGetAllCompanyConfiguration", null, true, "Company Configuration Id", companyConfigurationId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private void SetModuleTheme()
        {
            ModuleThemeHelper.ApplyTheme(this, _moduleGroup);
        }

        private void SetParameters(string functionTitle)
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
                    dataSubjectGetStoredProcedureName = "spGetCustomerLeadType";
                    dataSubjectIdFriendlyName = "Customer Lead Type Id";
                    dataSubjectIdName = "CustomerLeadTypeId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateCustomerLeadType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "customerLeadType";
                    break;
                case "CustomerType":
                    dataSubjectFriendlyName = "Customer Type";
                    dataSubjectGetStoredProcedureName = "spGetCustomerType";
                    dataSubjectIdFriendlyName = "Customer Type Id";
                    dataSubjectIdName = "CustomerTypeId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateCustomerType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "customerType";
                    break;
                case "PromotionTargetType":
                    dataSubjectFriendlyName = "Promotion Target Type";
                    dataSubjectGetStoredProcedureName = "spGetPromotionTargetType";
                    dataSubjectIdFriendlyName = "Promotion Target Type Id";
                    dataSubjectIdName = "PromotionTargetTypeId";
                    dataSubjectUpdateStoredProcedureName = "spUpdatePromotionTargetType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "promotionTargetType";
                    break;
                default:
                    this.Text = functionTitle;
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", functionTitle);
                    break;
            }

            if (!companyConfigurationEnabledDataSubjects.Contains(_functionTitle))
            {
                masterDataEnhancedDetailCompanyConfigurationComboBox.Visible = false;
                masterDataEnhancedDetailCompanyConfigurationComboBoxLabel.Visible = false;
            }

            dataSubjectName = functionTitle;

            masterDataEnhancedDetailTitleLabel.Text = $"{dataSubjectFriendlyName}{titleLabelSuffix}";
            masterDataEnhancedDetailDataSubjectIdTextboxLabel.Text = dataSubjectIdFriendlyName;
            masterDataEnhancedDetailDataSubjectTextboxLabel.Text = dataSubjectFriendlyName;
            masterDataEnhancedDetailDataSubjectDescriptionTextboxLabel.Text = $"{dataSubjectFriendlyName} Description";
            masterDataEnhancedDetailActiveStatusCheckbox.Text = $"Active {dataSubjectFriendlyName}";
            masterDataEnhancedDetailUpdateDataSubjectButton.Text = $"Update {dataSubjectFriendlyName}";
            this.Text = $"{applicationTitlePrefix}{dataSubjectFriendlyName}{titleLabelSuffix}";
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
                new Parameter
                {
                    ParameterName = $"{dataSubjectUpdateStoredProcedureParameterPrefix}Id",
                    ParameterValue = _dataSubjectId
                }
            };

            try
            {
                DataTable? masterDataEnhancedDetailDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(
                    dataSubjectGetStoredProcedureName,
                    parameters.ToArray(),
                    dataSubjectName);

                if (masterDataEnhancedDetailDataTable != null)
                {
                    DataRow masterDataEnhancedDetailDataRow = masterDataEnhancedDetailDataTable.Rows[0];
                    masterDataEnhancedDetailDataSubjectIdTextbox.Text = masterDataEnhancedDetailDataRow[dataSubjectIdFriendlyName].ToString();
                    masterDataEnhancedDetailDataSubjectTextbox.Text = masterDataEnhancedDetailDataRow[dataSubjectFriendlyName].ToString();
                    masterDataEnhancedDetailDataSubjectDescriptionTextbox.Text = masterDataEnhancedDetailDataRow[$"{dataSubjectFriendlyName} Description"].ToString();
                    masterDataEnhancedDetailCreatedByTextbox.Text = masterDataEnhancedDetailDataRow["Created By"].ToString();
                    masterDataEnhancedDetailCreatedTimestampTextbox.Text = masterDataEnhancedDetailDataRow["Created Timestamp UTC"].ToString();
                    masterDataEnhancedDetailLastUpdatedByTextbox.Text = masterDataEnhancedDetailDataRow["Modified By"].ToString();
                    masterDataEnhancedDetailLastUpdatedTimestampTextbox.Text = masterDataEnhancedDetailDataRow["Modified Timestamp UTC"].ToString();
                    masterDataEnhancedDetailActiveStatusCheckbox.Checked = (bool)masterDataEnhancedDetailDataRow["Active Status"];
                    if(_functionTitle == "CustomerLeadType" || _functionTitle == "CustomerType")
                    {
                        Guid companyConfigurationId = (Guid)masterDataEnhancedDetailDataRow["Company Configuration Id"];
                        await LoadCompanyConfigurationAsync(companyConfigurationId);
                    }

                    dataSubjectOriginalValue = masterDataEnhancedDetailDataRow[dataSubjectFriendlyName].ToString();
                    dataSubjectDescriptionOriginalValue = masterDataEnhancedDetailDataRow[$"{dataSubjectFriendlyName} Description"].ToString();
                    dataSubjectActiveStatusOriginalValue = (bool)masterDataEnhancedDetailDataRow["Active Status"];

                    if (_functionTitle == "CustomerLeadType" || _functionTitle == "CustomerType")
                    {
                        dataSubjectCompanyConfigurationIdOriginalValue = (Guid)masterDataEnhancedDetailDataRow["Company Configuration Id"];
                    }

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

        private async void masterDataEnhancedDetailUpdateDataSubjectButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = masterDataEnhancedDetailActiveStatusCheckbox.Checked;
            Guid? companyConfigurationId = (Guid?)masterDataEnhancedDetailCompanyConfigurationComboBox.SelectedValue;
            string dataSubjectDescriptionValue = masterDataEnhancedDetailDataSubjectDescriptionTextbox.Text.TrimEnd();
            string dataSubjectValue = masterDataEnhancedDetailDataSubjectTextbox.Text.TrimEnd();

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
                    Name = "Active Status",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = companyConfigurationEnabledDataSubjects.Contains(_functionTitle) ? false : true,
                    Name = "Company Configuration Id",
                    Value = companyConfigurationId,
                    ValueType = typeof(Guid?)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = dataSubjectFriendlyName,
                    Value = dataSubjectValue,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = $"{dataSubjectFriendlyName} Description",
                    Value = dataSubjectDescriptionValue,
                    MaxLength = 255,
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
                        VariableType = "Guid?",
                        OriginalValue = dataSubjectCompanyConfigurationIdOriginalValue,
                        NewValue = companyConfigurationId
                    },
                    new ChangeDetail
                    {
                        VariableName = dataSubjectFriendlyName,
                        VariableType = "string",
                        OriginalValue = dataSubjectOriginalValue,
                        NewValue = dataSubjectValue
                    },
                    new ChangeDetail
                    {
                        VariableName = $"{dataSubjectFriendlyName} Description",
                        VariableType = "string",
                        OriginalValue = dataSubjectDescriptionOriginalValue,
                        NewValue = dataSubjectDescriptionValue
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = UpdateConfirmationService.ConfirmChanges(changesList, dataSubjectName);

                if (confirmed)
                {
                    var parameters = new List<Parameter>
                    {
                        new Parameter
                        {
                            ParameterName = "activeStatus",
                            ParameterValue = activeStatus
                        },
                        new Parameter
                        {
                            ParameterName = $"{dataSubjectUpdateStoredProcedureParameterPrefix}",
                            ParameterValue = dataSubjectValue
                        },
                        new Parameter
                        {
                            ParameterName = $"{dataSubjectUpdateStoredProcedureParameterPrefix}Description",
                            ParameterValue = dataSubjectDescriptionValue
                        },
                        new Parameter
                        {
                            ParameterName = $"{dataSubjectUpdateStoredProcedureParameterPrefix}Id",
                            ParameterValue = _dataSubjectId
                        }
                    };

                    if (companyConfigurationEnabledDataSubjects.Contains(_functionTitle))
                    {
                        parameters.Add(new Parameter
                        {
                            ParameterName = "companyConfigurationId",
                            ParameterValue = companyConfigurationId
                        });
                    }

                    string operationType = "update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(dataSubjectUpdateStoredProcedureName, parameters.ToArray(), dataSubjectName, operationType);
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
            MasterDataEnhancedDetailMasterDataInformation_Load(this, EventArgs.Empty);
        }

        private void masterDataEnhancedDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            masterDataEnhancedDetailDataSubjectTextbox.ReadOnly = !masterDataEnhancedDetailDataSubjectTextbox.ReadOnly;
            masterDataEnhancedDetailDataSubjectDescriptionTextbox.ReadOnly = !masterDataEnhancedDetailDataSubjectDescriptionTextbox.ReadOnly;
            masterDataEnhancedDetailActiveStatusCheckbox.Enabled = !masterDataEnhancedDetailActiveStatusCheckbox.Enabled;
            masterDataEnhancedDetailUpdateDataSubjectButton.Enabled = !masterDataEnhancedDetailUpdateDataSubjectButton.Enabled;
            if(companyConfigurationEnabledDataSubjects.Contains(_functionTitle))
            {
                masterDataEnhancedDetailCompanyConfigurationComboBox.Enabled = !masterDataEnhancedDetailCompanyConfigurationComboBox.Enabled;
            }
        }
    }
}