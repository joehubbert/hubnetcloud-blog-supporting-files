using CRM.Helpers;
using CRM.Interface;
using CRM.Model;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.Note
{
    public partial class CreateNote : Form
    {
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private readonly Guid _dataSubjectId;
        private readonly string? _dataSubjectName;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
		private readonly FunctionTitle _functionTitle;
        private readonly ModuleGroup _moduleGroup;
        private UIModelHelper _uiModelHelper = new UIModelHelper();
        private readonly string applicationTitlePrefix = "CRM - Create ";    
        private string createNoteDataSubjectCamelCaseName;
        private string createNoteDataSubjectCreateStoredProcedureName;
        private string? createNoteDataSubjectTitleFriendlyName;
        private string createNoteDataSubjectTitleName;
        private string createNoteDataSubjectTypeFriendlyName;
        private string createNoteDataSubjectTypeIdFriendlyName;
        private string createNoteDataSubjectTypeIdName;
        private string createNoteParentDataSubjectFriendlyName;
        private string createNoteParentDataSubjectStoredProcedureIdName;

        public CreateNote(Guid dataSubjectId, FunctionTitle functionTitle, ModuleGroup moduleGroup, string? dataSubjectName = null)
        {
            InitializeComponent();
            InitializeEventHandlers();
            _dataSubjectId = dataSubjectId;
            _dataSubjectName = dataSubjectName;
			_functionTitle = functionTitle;
            SetParameters();
            LoadDatabaseConnectionSettingsAsync();
            LoadNoteTypeAsync();
        }

        private void InitializeEventHandlers()
        {
            createNoteNoteTypeComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void LoadNoteTypeAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createNoteNoteTypeComboBox, _functionTitle);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private void SetParameters()
        {
            ModuleThemeHelper.ApplyTheme(this, _moduleGroup);

            var dataSubjectProperties = _uiModelHelper.GetDataSubjectProperties(_functionTitle);
            if (dataSubjectProperties == null || dataSubjectProperties.DataParentSubject == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", _functionTitle.ToString());
                return;
            }

            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataSubject.DataSubjectCreateStoredProcedureName))
            {
                createNoteDataSubjectCreateStoredProcedureName = dataSubjectProperties.DataSubject.DataSubjectCreateStoredProcedureName;
            }

            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataParentSubject.DataSubjectStoredProcedureIdParameterName))
            {
                createNoteParentDataSubjectStoredProcedureIdName = dataSubjectProperties.DataParentSubject.DataSubjectStoredProcedureIdParameterName;
            }

            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataParentSubject.DataSubjectFriendlyName))
            {
                createNoteParentDataSubjectFriendlyName = dataSubjectProperties.DataParentSubject.DataSubjectFriendlyName;
            }

            createNoteDataSubjectCamelCaseName = dataSubjectProperties.DataSubject.DataSubjectCamelCaseName;
            createNoteDataSubjectTitleName = $"{createNoteDataSubjectCamelCaseName}Title";
            createNoteDataSubjectTypeIdName = $"{createNoteDataSubjectCamelCaseName}TypeId";
            createNoteDataSubjectTypeFriendlyName = dataSubjectProperties.DataSubject.DataSubjectFriendlyName;
            createNoteDataSubjectTitleFriendlyName = $"{createNoteDataSubjectTypeFriendlyName} Title";
            createNoteDataSubjectTypeFriendlyName = $"{createNoteDataSubjectTypeFriendlyName} Type";
            createNoteDataSubjectTypeIdFriendlyName = $"{createNoteDataSubjectTypeFriendlyName} Id";
            createNoteStatusStripDataSubjectPlaceholder.Text = $"{createNoteParentDataSubjectFriendlyName}: {_dataSubjectName} ({_dataSubjectId})";

            this.Text = $"{applicationTitlePrefix}{createNoteDataSubjectTypeFriendlyName}";
            createNoteTitleLabel.Text = createNoteDataSubjectTypeFriendlyName;
            createNoteNoteTitleTextBoxLabel.Text = $"{createNoteDataSubjectTitleFriendlyName}*";
            createNoteNoteTypeComboBoxLabel.Text = $"{createNoteDataSubjectTypeFriendlyName}*";
            createNoteStatusStrip.BackColor = SystemColors.Control;
        }

        private async void createNoteSubmitButton_Click(object sender, EventArgs e)
        {
            string note = TextBoxCleanerHelper.GetTrimmedText(createNoteNoteTextBox);
            string noteTitle = TextBoxCleanerHelper.GetTrimmedText(createNoteNoteTitleTextBox);
            Guid noteTypeId = (Guid)createNoteNoteTypeComboBox.SelectedValue;

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
                    Name = createNoteDataSubjectTypeFriendlyName,
                    Value = note,
                    MaxLength = 4000,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = createNoteDataSubjectTitleFriendlyName,
                    Value = noteTitle,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = createNoteDataSubjectTypeIdFriendlyName,
                    Value = noteTypeId,
                    ValueType = typeof(Guid)
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
                        ParameterName = createNoteParentDataSubjectStoredProcedureIdName,
                        ParameterValue = _dataSubjectId
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = createNoteDataSubjectCamelCaseName,
                        ParameterValue = note
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = createNoteDataSubjectTitleName,
                        ParameterValue = noteTitle
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = createNoteDataSubjectTypeIdName,
                        ParameterValue = noteTypeId
                    }
                };

                string operationType = "Create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(
                    _databaseConnectionSettings,
                    createNoteDataSubjectCreateStoredProcedureName,
                    parameters.ToArray(),
                    createNoteDataSubjectTypeFriendlyName,
                    operationType
                    );
                this.Close();
            }
        }
    }
}