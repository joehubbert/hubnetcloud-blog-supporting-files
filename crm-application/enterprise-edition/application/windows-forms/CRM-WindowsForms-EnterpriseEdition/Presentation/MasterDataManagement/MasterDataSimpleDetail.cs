using CRM.Helpers;
using CRM.Interface;
using CRM.Model;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.MasterDataManagement
{
    public partial class MasterDataSimpleDetail : Form
    {
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private readonly Guid _dataSubjectId;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly FunctionTitle _functionTitle;
        private readonly ModuleGroup _moduleGroup;
        private UIModelHelper _uiModelHelper = new UIModelHelper();
        private readonly string applicationTitlePrefix = "CRM - ";
        private bool dataSubjectActiveStatusOriginalValue;
        private List<FunctionTitle> companyConfigurationEnabledDataSubjects;
        private Guid? dataSubjectCompanyConfigurationIdOriginalValue;
        private string dataSubjectFriendlyName;
        private string dataSubjectSelectStoredProcedureName;
        private string dataSubjectIdFriendlyName;
        private string dataSubjectName;
        private string dataSubjectOriginalValue;
        private string dataSubjectStoredProcedureIdParameterName;
        private string dataSubjectStoredProcedureParameterName;
        private string dataSubjectUpdateStoredProcedureName;      
        private readonly string titleLabelSuffix= " Detail";

        public MasterDataSimpleDetail(Guid dataSubjectId, FunctionTitle functionTitle, ModuleGroup moduleGroup)
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
            MasterDataSimpleDetailMasterDataInformation_Load(this, EventArgs.Empty);
        }

        private void InitializeEventHandlers()
        {
            
        }

        private async Task LoadCompanyConfigurationAsync(Guid companyConfigurationId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(masterDataSimpleDetailCompanyConfigurationComboBox, FunctionTitle.CompanyConfiguration, null, true, "Company Configuration Id", companyConfigurationId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void MasterDataSimpleDetailMasterDataInformation_Load(object sender, EventArgs e)
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
                DataTable? masterDataSimpleDetailDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(
                    dataSubjectName,
                    _databaseConnectionSettings,
                    dataSubjectSelectStoredProcedureName,
                    parameters.ToArray()
                    );

                if (masterDataSimpleDetailDataTable != null)
                {
                    DataRow masterDataSimpleDetailDataRow = masterDataSimpleDetailDataTable.Rows[0];
                    masterDataSimpleDetailDataSubjectIdTextBox.Text = masterDataSimpleDetailDataRow[dataSubjectIdFriendlyName].ToString();
                    masterDataSimpleDetailDataSubjectTextBox.Text = masterDataSimpleDetailDataRow[dataSubjectFriendlyName].ToString();
                    masterDataSimpleDetailCreatedByTextBox.Text = masterDataSimpleDetailDataRow["Created By"].ToString();
                    masterDataSimpleDetailCreatedTimestampTextBox.Text = masterDataSimpleDetailDataRow["Created Timestamp UTC"].ToString();
                    masterDataSimpleDetailLastUpdatedByTextBox.Text = masterDataSimpleDetailDataRow["Modified By"].ToString();
                    masterDataSimpleDetailLastUpdatedTimestampTextBox.Text = masterDataSimpleDetailDataRow["Modified Timestamp UTC"].ToString();
                    masterDataSimpleDetailActiveStatusCheckBox.Checked = (bool)masterDataSimpleDetailDataRow["Active Status"];
                    if (companyConfigurationEnabledDataSubjects.Contains(_functionTitle))
                    {
                        Guid companyConfigurationId = (Guid)masterDataSimpleDetailDataRow["Company Configuration Id"];
                        await LoadCompanyConfigurationAsync(companyConfigurationId);
                    }

                    dataSubjectOriginalValue = masterDataSimpleDetailDataRow[dataSubjectFriendlyName].ToString();
                    if (companyConfigurationEnabledDataSubjects.Contains(_functionTitle))
                    {
                        dataSubjectCompanyConfigurationIdOriginalValue = (Guid)masterDataSimpleDetailDataRow["Company Configuration Id"];
                    }

                    dataSubjectActiveStatusOriginalValue = (bool)masterDataSimpleDetailDataRow["Active Status"];

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
            companyConfigurationEnabledDataSubjects = new List<FunctionTitle>
            {
                FunctionTitle.ProductCategory,
                FunctionTitle.ProductFamily,
                FunctionTitle.SalesRegion,
            };

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
            
            if (!string.IsNullOrEmpty(dataSubjectProperties.DataSubject.DataSubjectSelectStoredProcedureName))
            {
                dataSubjectSelectStoredProcedureName = dataSubjectProperties.DataSubject.DataSubjectSelectStoredProcedureName;
            }

            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataSubject.DataSubjectStoredProcedureIdParameterName))
            {
                dataSubjectStoredProcedureIdParameterName = dataSubjectProperties.DataSubject.DataSubjectStoredProcedureIdParameterName;
            }

            dataSubjectStoredProcedureParameterName = dataSubjectProperties.DataSubject.DataSubjectCamelCaseName;

            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataSubject.DataSubjectUpdateStoredProcedureName))
            {
                dataSubjectUpdateStoredProcedureName = dataSubjectProperties.DataSubject.DataSubjectUpdateStoredProcedureName;
            }

            if (!companyConfigurationEnabledDataSubjects.Contains(_functionTitle))
            {
                masterDataSimpleDetailCompanyConfigurationComboBox.Visible = false;
                masterDataSimpleDetailCompanyConfigurationComboBoxLabel.Visible = false;
            }

            dataSubjectName = _functionTitle.ToString();

            masterDataSimpleDetailTitleLabel.Text = $"{dataSubjectFriendlyName}{titleLabelSuffix}";
            masterDataSimpleDetailDataSubjectIdTextBoxLabel.Text = dataSubjectIdFriendlyName;
            masterDataSimpleDetailDataSubjectTextBoxLabel.Text = dataSubjectFriendlyName;
            masterDataSimpleDetailActiveStatusCheckBox.Text = $"Active {dataSubjectFriendlyName}";
            masterDataSimpleDetailUpdateDataSubjectButton.Text = $"Update {dataSubjectFriendlyName}";
            this.Text = $"{applicationTitlePrefix}{dataSubjectFriendlyName}{titleLabelSuffix}";
        }

        private void masterDataSimpleDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            masterDataSimpleDetailDataSubjectTextBox.ReadOnly = !masterDataSimpleDetailDataSubjectTextBox.ReadOnly;
            masterDataSimpleDetailActiveStatusCheckBox.Enabled = !masterDataSimpleDetailActiveStatusCheckBox.Enabled;
            masterDataSimpleDetailUpdateDataSubjectButton.Enabled = !masterDataSimpleDetailUpdateDataSubjectButton.Enabled;
            if (companyConfigurationEnabledDataSubjects.Contains(_functionTitle))
            {
                masterDataSimpleDetailCompanyConfigurationComboBox.Enabled = !masterDataSimpleDetailCompanyConfigurationComboBox.Enabled;
            }
        }

        private async void masterDataSimpleDetailUpdateDataSubjectButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = masterDataSimpleDetailActiveStatusCheckBox.Checked;
            Guid? companyConfigurationId = (Guid?)masterDataSimpleDetailCompanyConfigurationComboBox.SelectedValue;
            string dataSubjectValue = TextBoxCleanerHelper.GetTrimmedText(masterDataSimpleDetailDataSubjectTextBox);

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
                    AllowNullValue = companyConfigurationEnabledDataSubjects.Contains(_functionTitle) ? false : true,
                    Name = "Company Configuration Id",
                    Value = companyConfigurationId,
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
                        VariableName = "Company Configuration Id",
                        OriginalValue = dataSubjectCompanyConfigurationIdOriginalValue,
                        NewValue = companyConfigurationId
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
                    var parameters = new List<StoredProcedureParameter>
                    {
                        new StoredProcedureParameter
                        {
                            ParameterName = "activeStatus",
                            ParameterValue = activeStatus
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = dataSubjectStoredProcedureIdParameterName,
                            ParameterValue = _dataSubjectId
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
                            ParameterValue = companyConfigurationId
                        });
                    }

                    DataOperationType operationType = DataOperationType.Update;

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(dataSubjectName, _databaseConnectionSettings, operationType, dataSubjectUpdateStoredProcedureName, parameters.ToArray());
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