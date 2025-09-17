using CRM.Helpers;
using CRM.Interface;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.CompanyManagement.HTMLTemplate
{
    public partial class HTMLTemplateDetail : Form
    {
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _htmlTemplateId;
        private Guid htmlTemplateDetailCompanyConfigurationIdOriginalValue;
        private string htmlTemplateDetailHTMLTemplateOriginalValue;
        private string htmlTemplateDetailHTMLTemplateTitleOriginalValue;
        private Guid htmlTemplateDetailHTMLTemplateTypeIdOriginalValue;

        public HTMLTemplateDetail(Guid htmlTemplateId)
        {
            InitializeComponent();
            InitializeEventHandlers();
            _htmlTemplateId = htmlTemplateId;        
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            HTMLTemplateDetailHTMLTemplateInformation_Load(this, EventArgs.Empty);
        }

        private void InitializeEventHandlers()
        {
            htmlTemplateDetailHTMLTemplateTypeComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
        }

        private async void HTMLTemplateDetailHTMLTemplateInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            string dataSubject = "HTML Template";

            var parameters = new[]
            {
                new StoredProcedureParameter
                {
                    ParameterName = "htmlTemplateId",
                    ParameterValue = _htmlTemplateId
                }
            };

            try
            {
                string storedProcedureName = "spGetHTMLTemplate";

                DataTable? htmlTemplateDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(
                    storedProcedureName,
                    parameters.ToArray(),
                    dataSubject
                    );

                if (htmlTemplateDataTable != null)
                {
                    DataRow htmlTemplateDataRow = htmlTemplateDataTable.Rows[0];
                    Guid companyConfigurationId = (Guid)htmlTemplateDataRow["Company Configuration Id"];
                    await LoadCompanyConfigurationAsync(companyConfigurationId);
                    htmlTemplateDetailHTMLTemplateIdTextBox.Text = htmlTemplateDataRow["HTML Template Id"].ToString();
                    htmlTemplateDetailHTMLTemplateTitleTextBox.Text = htmlTemplateDataRow["HTML Template Title"].ToString();
                    Guid htmlTemplateTypeId = (Guid)htmlTemplateDataRow["HTML Template Type Id"];
                    await LoadHTMLTemplateTypeAsync(htmlTemplateTypeId);
                    htmlTemplateDetailHTMLTemplateTextBox.Text = htmlTemplateDataRow["HTML Template"].ToString();
                    htmlTemplateDetailCreatedByTextBox.Text = htmlTemplateDataRow["Created By"].ToString();
                    htmlTemplateDetailCreatedTimestampTextBox.Text = htmlTemplateDataRow["Created Timestamp UTC"].ToString();
                    htmlTemplateDetailLastUpdatedByTextBox.Text = htmlTemplateDataRow["Modified By"].ToString();
                    htmlTemplateDetailLastUpdatedTimestampTextBox.Text = htmlTemplateDataRow["Modified Timestamp UTC"].ToString();

                    htmlTemplateDetailCompanyConfigurationIdOriginalValue = (Guid)htmlTemplateDataRow["Company Configuration Id"];
                    htmlTemplateDetailHTMLTemplateOriginalValue = htmlTemplateDataRow["HTML Template"].ToString();
                    htmlTemplateDetailHTMLTemplateTitleOriginalValue = htmlTemplateDataRow["HTML Template Title"].ToString();
                    htmlTemplateDetailHTMLTemplateTypeIdOriginalValue = (Guid)htmlTemplateDataRow["HTML Template Type Id"];

                    this.Text += $" ({htmlTemplateDetailHTMLTemplateTitleOriginalValue})";
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.NoDataFound", dataSubject);
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async Task LoadCompanyConfigurationAsync(Guid companyConfigurationId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(htmlTemplateDetailCompanyConfigurationComboBox, "spGetAllCompanyConfiguration", null, true, "Company Configuration Id", companyConfigurationId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task LoadHTMLTemplateTypeAsync(Guid htmlTemplateTypeId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(htmlTemplateDetailHTMLTemplateTypeComboBox,
                "spGetAllHTMLTemplateType",
                null,
                true,
                "HTML Template Type Id",
                htmlTemplateTypeId,
                false,
                null,
                null,
                null,
                true);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private void htmlTemplateDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            htmlTemplateDetailCompanyConfigurationComboBox.Enabled = !htmlTemplateDetailCompanyConfigurationComboBox.Enabled;
            htmlTemplateDetailHTMLTemplateTextBox.ReadOnly = !htmlTemplateDetailHTMLTemplateTextBox.ReadOnly;
            htmlTemplateDetailHTMLTemplateTitleTextBox.ReadOnly = !htmlTemplateDetailHTMLTemplateTitleTextBox.ReadOnly;
            htmlTemplateDetailHTMLTemplateTypeComboBox.Enabled = !htmlTemplateDetailHTMLTemplateTypeComboBox.Enabled;
            htmlTemplateDetailUpdateHTMLTemplateButton.Enabled = !htmlTemplateDetailUpdateHTMLTemplateButton.Enabled;
        }

        private async void htmlTemplateDetailUpdateHTMLTemplateButton_Click(object sender, EventArgs e)
        {
            Guid companyConfigurationId = (Guid)htmlTemplateDetailCompanyConfigurationComboBox.SelectedValue;
            string htmlTemplate = TextBoxCleanerHelper.GetTrimmedText(htmlTemplateDetailHTMLTemplateTextBox);
            string htmlTemplateTitle = TextBoxCleanerHelper.GetTrimmedText(htmlTemplateDetailHTMLTemplateTitleTextBox);
            Guid htmlTemplateTypeId = (Guid)htmlTemplateDetailHTMLTemplateTypeComboBox.SelectedValue;

            string dataSubject = "HTML Template";

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
                    Name = "Company Configuration Id",
                    Value = companyConfigurationId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "HTML Template",
                    Value = htmlTemplate,
                    MaxLength = 1070000000,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "HTML Template Title",
                    Value = htmlTemplateTitle,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "HTML Template Type Id",
                    Value = htmlTemplateTypeId,
                    ValueType = typeof(Guid)
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
                        VariableName = "Company Configuration Id",
                        VariableType = "Guid",
                        OriginalValue = htmlTemplateDetailCompanyConfigurationIdOriginalValue,
                        NewValue = companyConfigurationId
                    },
                    new ChangeDetail
                    {
                        VariableName = "HTML Template",
                        VariableType = "string",
                        OriginalValue = htmlTemplateDetailHTMLTemplateOriginalValue,
                        NewValue = htmlTemplate
                    },
                    new ChangeDetail
                    {
                        VariableName = "HTML Template Title",
                        VariableType = "string",
                        OriginalValue = htmlTemplateDetailHTMLTemplateTitleOriginalValue,
                        NewValue = htmlTemplateTitle
                    },
                    new ChangeDetail
                    {
                        VariableName = "HTML Template Type Id",
                        VariableType = "Guid",
                        OriginalValue = htmlTemplateDetailHTMLTemplateTypeIdOriginalValue,
                        NewValue = htmlTemplateTypeId
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = UpdateConfirmationService.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
                {
                    var parameters = new[]
                    {
                        new StoredProcedureParameter
                        {
                            ParameterName = "companyConfigurationId",
                            ParameterValue = companyConfigurationId
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "htmlTemplateId",
                            ParameterValue = _htmlTemplateId
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "htmlTemplateTitle",
                            ParameterValue = htmlTemplateTitle
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "htmlTemplateTypeId",
                            ParameterValue = htmlTemplateTypeId
                        }
                    };

                    string operationType = "update";
                    string storedProcedureName = "spUpdateHTMLTemplate";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(
                        storedProcedureName,
                        parameters.ToArray(),
                        dataSubject,
                        operationType
                        );
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