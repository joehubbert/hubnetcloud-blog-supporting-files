using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateHTMLTemplate : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _companyConfigurationId;

        public CreateHTMLTemplate(Guid companyConfigurationId)
        {
            InitializeComponent();
            InitializeCustomComponents();
            _companyConfigurationId = companyConfigurationId;
            LoadDatabaseConnectionSettingsAsync();
            CreateHTMLTemplateLoadHTMLTemplateTypeAsync();
        }

        private void InitializeCustomComponents()
        {
            createHTMLTemplateHTMLTemplateTypeComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void CreateHTMLTemplateLoadHTMLTemplateTypeAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "HTML Template Type";

            try
            {
                
                string storedProcedureName = "[dbo].[spGetAllHTMLTemplateType]";

                DataTable? htmlTemplateTypeData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject);

                var htmlTemplateTypeList = htmlTemplateTypeData.AsEnumerable()
                    .Select(row => new
                    {
                        HTMLTemplateTypeId = row.Field<Guid>("HTML Template Type Id"),
                        HTMLTemplateType = row.Field<string>("HTML Template Type")
                    })
                    .OrderBy(item => item.HTMLTemplateType)
                    .ToList();
                createHTMLTemplateHTMLTemplateTypeComboBox.DataSource = htmlTemplateTypeList;
                createHTMLTemplateHTMLTemplateTypeComboBox.DisplayMember = "HTMLTemplateType";
                createHTMLTemplateHTMLTemplateTypeComboBox.ValueMember = "HTMLTemplateTypeId";
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void createHTMLTemplateSubmitButton_Click(object sender, EventArgs e)
        {
            string htmlTemplate = createHTMLTemplateHTMLTemplateTextbox.Text.TrimEnd();
            string htmlTemplateTitle = createHTMLTemplateHTMLTemplateTitleTextbox.Text.TrimEnd();
            Guid htmlTemplateTypeId = Guid.Parse(createHTMLTemplateHTMLTemplateTypeComboBox.SelectedValue.ToString());

            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            var dataToValidate = new List<ValidateDataInput.DataProperty>
            {
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "HTMLTemplate",
                    Value = htmlTemplate,
                    MaxLength = 1070000000,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "HTMLTemplateTitle",
                    Value = htmlTemplateTitle,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "HTMLTemplateTypeId",
                    Value = htmlTemplateTypeId,
                    ValueType = typeof(Guid)
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
                var parameters = new[]
                {
                    new Parameter
                    {
                        ParameterName = "companyConfigurationId",
                        ParameterValue = _companyConfigurationId
                    },
                    new Parameter
                    {
                        ParameterName = "htmlTemplate",
                        ParameterValue = htmlTemplate
                    },
                    new Parameter
                    {
                        ParameterName = "htmlTemplateTitle",
                        ParameterValue = htmlTemplateTitle
                    },
                    new Parameter
                    {
                        ParameterName = "htmlTemplateTypeId",
                        ParameterValue = htmlTemplateTypeId
                    }
                };

                string dataSubject = "HTML Template";
                string operationType = "create";
                string storedProcedureName = "[dbo].[spCreateHTMLTemplate]";

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