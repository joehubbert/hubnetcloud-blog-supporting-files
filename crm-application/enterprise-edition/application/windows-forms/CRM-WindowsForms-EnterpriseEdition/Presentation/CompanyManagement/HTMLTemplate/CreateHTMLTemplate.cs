using CRM.Helpers;
using CRM.Interface;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.CompanyManagement.HTMLTemplate
{
    public partial class CreateHTMLTemplate : Form
    {
        private readonly Guid _companyConfigurationId;
        private readonly string _companyName;
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreateHTMLTemplate(Guid companyConfigurationId, string companyName)
        {
            InitializeComponent();
            InitializeEventHandlers();
            _companyConfigurationId = companyConfigurationId;
            _companyName = companyName;
            LoadDatabaseConnectionSettingsAsync();
            PopulateStatusStrip();
            LoadHTMLTemplateTypeAsync();
        }

        private void InitializeEventHandlers()
        {
            createHTMLTemplateHTMLTemplateTypeComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void PopulateStatusStrip()
        {
            createHTMLTemplateStatusStripCompanyConfigurationPlaceholder.Text = $"Company Configuration: {_companyName} ({_companyConfigurationId})";
        }

        private async void LoadHTMLTemplateTypeAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createHTMLTemplateHTMLTemplateTypeComboBox, "spGetAllHTMLTemplateType");
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async void createHTMLTemplateSubmitButton_Click(object sender, EventArgs e)
        {
            string htmlTemplate = TextBoxCleanerHelper.GetTrimmedText(createHTMLTemplateHTMLTemplateTextBox);
            string htmlTemplateTitle = TextBoxCleanerHelper.GetTrimmedText(createHTMLTemplateHTMLTemplateTitleTextBox);
            Guid htmlTemplateTypeId = (Guid)createHTMLTemplateHTMLTemplateTypeComboBox.SelectedValue;

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
                    Value = _companyConfigurationId,
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
                var parameters = new[]
                {
                    new StoredProcedureParameter
                    {
                        ParameterName = "companyConfigurationId",
                        ParameterValue = _companyConfigurationId
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "htmlTemplate",
                        ParameterValue = htmlTemplate
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

                string dataSubject = "HTML Template";
                string operationType = "create";
                string storedProcedureName = "spCreateHTMLTemplate";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(
                    storedProcedureName,
                    parameters.ToArray(),
                    dataSubject,
                    operationType
                    );
                this.Close();
            }
        }
    }
}