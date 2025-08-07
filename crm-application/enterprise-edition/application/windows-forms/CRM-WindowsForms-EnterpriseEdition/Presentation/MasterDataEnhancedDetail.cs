using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class MasterDataEnhancedDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _dataSubjectId;
        private readonly string _functionTitle;
        private readonly string _moduleGroup;
        private readonly string applicationTitlePrefix = "CRM - ";
        private bool? dataSubjectActiveStatusOriginalValue;
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
            _dataSubjectId = dataSubjectId;
            _functionTitle = functionTitle;
            _moduleGroup = moduleGroup;
            SetModuleTheme(_moduleGroup);
            masterDataEnhancedDetailToggleEditModeButton.Click += new EventHandler(masterDataEnhancedDetailToggleEditModeButton_Click);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void SetModuleTheme(string moduleGroup)
        {
            switch (moduleGroup)
            {
                case "CompanyManagement":
                    this.BackColor = Color.LemonChiffon;
                    break;
                case "CustomerManagement":
                    this.BackColor = Color.LightGreen;
                    break;
                case "MarketingManagement":
                    this.BackColor = Color.NavajoWhite;
                    break;
                case "OrderManagement":
                    this.BackColor = Color.LightSalmon;
                    break;
                case "ProductManagement":
                    this.BackColor = Color.SkyBlue;
                    break;
                case "SupplierManagement":
                    this.BackColor = Color.MediumAquamarine;
                    break;
                default:
                    ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Module.NotImplemented", moduleGroup);
                    break;
            }
        }

        private void SetParameters(string functionTitle)
        {
            switch (functionTitle)
            {
                case "CustomerLeadType":
                    dataSubjectFriendlyName = "Customer Lead Type";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetCustomerLeadType]";
                    dataSubjectIdFriendlyName = "Customer Lead Type Id";
                    dataSubjectIdName = "CustomerLeadTypeId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateCustomerLeadType]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "customerLeadType";
                    break;
                case "CustomerType":
                    dataSubjectFriendlyName = "Customer Type";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetCustomerType]";
                    dataSubjectIdFriendlyName = "Customer Type Id";
                    dataSubjectIdName = "CustomerTypeId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateCustomerType]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "customerType";
                    break;
                default:
                    this.Text = functionTitle;
                    ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Module.Function.NotImplemented", functionTitle);
                    break;
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
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Database.ConnectionSettingsNotLoaded");
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
                DataTable? masterDataEnhancedDetailDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(
                    dataSubjectGetStoredProcedureName,
                    parameters.ToArray(),
                    dataSubjectName,
                    _databaseConnectionSettings.DatabaseConnectionString);

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

                    dataSubjectOriginalValue = masterDataEnhancedDetailDataRow[dataSubjectFriendlyName].ToString();
                    dataSubjectDescriptionOriginalValue = masterDataEnhancedDetailDataRow[$"{dataSubjectFriendlyName} Description"].ToString();
                    dataSubjectActiveStatusOriginalValue = (bool)masterDataEnhancedDetailDataRow["Active Status"];

                    this.Text += $" ({dataSubjectOriginalValue})";
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Information.NoDataFound", dataSubjectFriendlyName);
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.Retrieval", dataSubjectFriendlyName, ex.Message);
            }
        }

        private async void masterDataEnhancedDetailUpdateDataSubjectButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = masterDataEnhancedDetailActiveStatusCheckbox.Checked;
            string dataSubjectDescriptionValue = masterDataEnhancedDetailDataSubjectDescriptionTextbox.Text.TrimEnd();
            string dataSubjectValue = masterDataEnhancedDetailDataSubjectTextbox.Text.TrimEnd();

            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Database.ConnectionSettingsNotLoaded");
                return;
            }

            var dataToValidate = new List<ValidateDataInput.DataProperty>
            {
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ActiveStatus",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = dataSubjectName,
                    Value = dataSubjectValue,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = $"{dataSubjectName}Description",
                    Value = dataSubjectDescriptionValue,
                    MaxLength = 255,
                    ValueType = typeof(string)
                }
            };

            dataToValidate = dataToValidate.OrderBy(change => change.Name).ToList();

            var validationResult = ValidateDataInput.ValidateInput(dataToValidate);

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

                bool confirmed = UpdateConfirmation.ConfirmChanges(changesList, dataSubjectName);

                if (confirmed)
                {
                    var parameters = new[]
                    {
                        new Parameter
                        {
                            ParameterName = "@activeStatus",
                            ParameterValue = activeStatus
                        },
                        new Parameter
                        {
                            ParameterName = $"@{dataSubjectUpdateStoredProcedureParameterPrefix}",
                            ParameterValue = dataSubjectValue
                        },
                        new Parameter
                        {
                            ParameterName = $"@{dataSubjectUpdateStoredProcedureParameterPrefix}Description",
                            ParameterValue = dataSubjectDescriptionValue
                        },
                        new Parameter
                        {
                            ParameterName = $"@{dataSubjectUpdateStoredProcedureParameterPrefix}Id",
                            ParameterValue = _dataSubjectId
                        }
                    };

                    string operationType = "update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(dataSubjectUpdateStoredProcedureName, parameters, dataSubjectName, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                    this.Close();
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Information.UpdateCancelled");
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
        }
    }
}