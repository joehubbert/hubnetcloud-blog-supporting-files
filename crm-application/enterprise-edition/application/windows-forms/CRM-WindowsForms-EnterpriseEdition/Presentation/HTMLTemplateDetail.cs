using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;
using System.Runtime.CompilerServices;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class HTMLTemplateDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _htmlTemplateId;
        private string? htmlTemplateDetailHTMLTemplateOriginalValue;
        private string? htmlTemplateDetailHTMLTemplateTitleOriginalValue;
        private Guid? htmlTemplateDetailHTMLTemplateTypeIdOriginalValue;

        public HTMLTemplateDetail(Guid htmlTemplateId)
        {
            InitializeComponent();
            _htmlTemplateId = htmlTemplateId;
            htmlTemplateDetailToggleEditModeButton.Click += new EventHandler(htmlTemplateDetailToggleEditModeButton_Click);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task HTMLTemplateDetailLoadHTMLTemplateTypeAsync(Guid htmlTemplateTypeId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "HTML Template Type";

            try
            {               
                string storedProcedureName = "[dbo].[spGetAllHTMLTemplateType]";

                DataTable? htmlTemplateTypeData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var htmlTemplateTypeList = htmlTemplateTypeData.AsEnumerable()
                    .Select(row => new
                    {
                        HTMLTemplateTypeId = row.Field<Guid>("HTML Template Type Id"),
                        HTMLTemplateType = row.Field<string>("HTML Template Type"),
                    })
                    .OrderBy(item => item.HTMLTemplateType)
                    .ToList();
                htmlTemplateDetailHTMLTemplateTypeComboBox.DataSource = htmlTemplateTypeList;
                htmlTemplateDetailHTMLTemplateTypeComboBox.DisplayMember = "HTMLTemplateType";
                htmlTemplateDetailHTMLTemplateTypeComboBox.ValueMember = "HTMLTemplateTypeId";
                htmlTemplateDetailHTMLTemplateTypeComboBox.SelectedValue = htmlTemplateTypeId;
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async void HTMLTemplateDetailHTMLTemplateInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            string dataSubject = "HTML Template";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@htmlTemplateId",
                    ParameterValue = _htmlTemplateId
                }
            };

            try
            {
                string storedProcedureName = "[dbo].[spGetHTMLTemplate]";

                DataTable? htmlTemplateDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(
                    storedProcedureName,
                    parameters.ToArray(),
                    dataSubject,
                    _databaseConnectionSettings.DatabaseConnectionString
                    );

                if (htmlTemplateDataTable != null)
                {
                    DataRow htmlTemplateDataRow = htmlTemplateDataTable.Rows[0];
                    htmlTemplateDetailCompanyConfigurationIdTextbox.Text = htmlTemplateDataRow["Company Configuration Id"].ToString();
                    htmlTemplateDetailHTMLTemplateIdTextbox.Text = htmlTemplateDataRow["HTML Template Id"].ToString();
                    htmlTemplateDetailHTMLTemplateTitleTextbox.Text = htmlTemplateDataRow["HTML Template Title"].ToString();
                    await HTMLTemplateDetailLoadHTMLTemplateTypeAsync((Guid)htmlTemplateDataRow["HTML Template Type Id"]);
                    htmlTemplateDetailHTMLTemplateTextbox.Text = htmlTemplateDataRow["HTML Template"].ToString();
                    htmlTemplateDetailCreatedByTextbox.Text = htmlTemplateDataRow["Created By"].ToString();
                    htmlTemplateDetailCreatedTimestampTextbox.Text = htmlTemplateDataRow["Created Timestamp UTC"].ToString();
                    htmlTemplateDetailLastUpdatedByTextbox.Text = htmlTemplateDataRow["Modified By"].ToString();
                    htmlTemplateDetailLastUpdatedTimestampTextbox.Text = htmlTemplateDataRow["Modified Timestamp UTC"].ToString();

                    htmlTemplateDetailHTMLTemplateOriginalValue = htmlTemplateDataRow["HTML Template"].ToString();
                    htmlTemplateDetailHTMLTemplateTitleOriginalValue = htmlTemplateDataRow["HTML Template Title"].ToString();
                    htmlTemplateDetailHTMLTemplateTypeIdOriginalValue = (Guid)htmlTemplateDataRow["HTML Template Type Id"];

                    this.Text += $" ({htmlTemplateDetailHTMLTemplateTitleOriginalValue})";
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Information.NoDataFound", dataSubject);
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async void htmlTemplateDetailUpdateHTMLTemplateButton_Click(object sender, EventArgs e)
        {
            string htmlTemplate = htmlTemplateDetailHTMLTemplateTextbox.Text.TrimEnd();
            string htmlTemplateTitle = htmlTemplateDetailHTMLTemplateTitleTextbox.Text.TrimEnd();
            Guid htmlTemplateTypeId = (Guid)htmlTemplateDetailHTMLTemplateTypeComboBox.SelectedValue;

            string dataSubject = "HTML Template";

            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Database.Connection.SettingsNotLoaded");
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
                var changesList = new List<ChangeDetail>
                {
                    new ChangeDetail
                    {
                        VariableName = "HTMLTemplate",
                        VariableType = "string",
                        OriginalValue = htmlTemplateDetailHTMLTemplateOriginalValue,
                        NewValue = htmlTemplate
                    },
                    new ChangeDetail
                    {
                        VariableName = "HTMLTemplateTitle",
                        VariableType = "string",
                        OriginalValue = htmlTemplateDetailHTMLTemplateTitleOriginalValue,
                        NewValue = htmlTemplateTitle
                    },
                    new ChangeDetail
                    {
                        VariableName = "HTMLTemplateTypeId",
                        VariableType = "Guid",
                        OriginalValue = htmlTemplateDetailHTMLTemplateTypeIdOriginalValue,
                        NewValue = htmlTemplateTypeId
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = UpdateConfirmation.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
                {
                    var parameters = new[]
                    {
                        new Parameter
                        {
                            ParameterName = "@htmlTemplateId",
                            ParameterValue = _htmlTemplateId
                        },
                        new Parameter
                        {
                            ParameterName = "@htmlTemplateTitle",
                            ParameterValue = htmlTemplateTitle
                        },
                        new Parameter
                        {
                            ParameterName = "@htmlTemplateTypeId",
                            ParameterValue = htmlTemplateTypeId
                        }
                    };

                    string operationType = "update";
                    string storedProcedureName = "[dbo].[spUpdateHTMLTemplate]";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(
                        storedProcedureName,
                        parameters.ToArray(),
                        dataSubject,
                        _databaseConnectionSettings.DatabaseConnectionString,
                        operationType
                        );
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
            HTMLTemplateDetailHTMLTemplateInformation_Load(this, EventArgs.Empty);
        }

        private void htmlTemplateDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            htmlTemplateDetailHTMLTemplateTextbox.ReadOnly = !htmlTemplateDetailHTMLTemplateTextbox.ReadOnly;
            htmlTemplateDetailHTMLTemplateTitleTextbox.ReadOnly = !htmlTemplateDetailHTMLTemplateTitleTextbox.ReadOnly;
            htmlTemplateDetailHTMLTemplateTypeComboBox.Enabled = !htmlTemplateDetailHTMLTemplateTypeComboBox.Enabled;
            htmlTemplateDetailUpdateHTMLTemplateButton.Enabled = !htmlTemplateDetailUpdateHTMLTemplateButton.Enabled;
        }
    }
}