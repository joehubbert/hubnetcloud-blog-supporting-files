using CRM.Helpers;
using CRM.Interface;
using CRM.Model;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.Note
{
    public partial class NoteDetail : Form
    {
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private readonly Guid _dataSubjectId;
        private readonly string? _dataSubjectName;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly FunctionTitle _functionTitle;
        private readonly ModuleGroup _moduleGroup;
        private readonly Guid _noteId;
        private UIModelHelper _uiModelHelper = new UIModelHelper();
        private readonly string applicationTitlePrefix = "CRM - ";       
        private string noteDetailNoteOriginalValue;
        private string noteDetailNoteTitleOriginalValue;
        private Guid noteDetailNoteTypeIdOriginalValue;
        private string noteDetailDataSubjectCamelCaseName;
        private string noteDetailDataSubjectFriendlyName;
        private string noteDetailDataSubjectIdFriendlyName;
        private string noteDetailDataSubjectSelectStoredProcedureName;
        private string noteDetailDataSubjectStoredProcedureIdParameterName;
        private string noteDetailDataSubjectTitleFriendlyName;
        private string noteDetailDataSubjectTitleName;
        private string noteDetailDataSubjectTypeFriendlyName;
        private string noteDetailDataSubjectTypeIdFriendlyName;
        private string noteDetailDataSubjectTypeIdName; 
        private string noteDetailDataSubjectUpdateStoredProcedureName;
        private readonly string titleLabelSuffix = " Detail";

        public NoteDetail(Guid dataSubjectId, FunctionTitle functionTitle, ModuleGroup moduleGroup, Guid noteId, string? dataSubjectName = null)
        {
            InitializeComponent();
            InitializeEventHandlers();
            _dataSubjectId = dataSubjectId;
            if (string.IsNullOrEmpty(dataSubjectName))
            {
                _dataSubjectName = null;
            }
            else
            {
                _dataSubjectName = dataSubjectName;
            }
            _functionTitle = functionTitle;
            _moduleGroup = moduleGroup;
            _noteId = noteId;
            SetParameters();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            NoteDetailNoteInformation_Load(this, EventArgs.Empty);
        }

        private void InitializeEventHandlers()
        {
            
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task LoadNoteTypeAsync(Guid noteTypeId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(noteDetailNoteTypeComboBox, 
                _functionTitle,
                null,
                true,
                noteDetailDataSubjectTypeIdFriendlyName,
                noteTypeId,
                false,
                null,
                null,
                null,
                true);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async void NoteDetailNoteInformation_Load(object sender, EventArgs e)
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
                    ParameterName = noteDetailDataSubjectStoredProcedureIdParameterName,
                    ParameterValue = _noteId
                }
            };

            try
            {
                DataTable? noteDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(
                    noteDetailDataSubjectFriendlyName,
                    _databaseConnectionSettings,
                    noteDetailDataSubjectSelectStoredProcedureName,
                    parameters.ToArray()
                    );

                if (noteDataTable != null)
                {
                    DataRow noteDataRow = noteDataTable.Rows[0];
                    noteDetailNoteIdTextBox.Text = noteDataRow[noteDetailDataSubjectIdFriendlyName].ToString();
                    noteDetailNoteTitleTextBox.Text = noteDataRow[noteDetailDataSubjectTitleFriendlyName].ToString();
                    Guid noteTypeId = (Guid)noteDataRow[noteDetailDataSubjectTypeIdFriendlyName];
                    await LoadNoteTypeAsync(noteTypeId);
                    noteDetailNoteTextBox.Text = noteDataRow[noteDetailDataSubjectFriendlyName].ToString();
                    noteDetailCreatedByTextBox.Text = noteDataRow["Created By"].ToString();
                    noteDetailCreatedTimestampTextBox.Text = noteDataRow["Created Timestamp UTC"].ToString();
                    noteDetailLastUpdatedByTextBox.Text = noteDataRow["Modified By"].ToString();
                    noteDetailLastUpdatedTimestampTextBox.Text = noteDataRow["Modified Timestamp UTC"].ToString();

                    noteDetailNoteOriginalValue = noteDataRow[noteDetailDataSubjectFriendlyName].ToString();
                    noteDetailNoteTitleOriginalValue = noteDataRow[noteDetailDataSubjectTitleFriendlyName].ToString();
                    noteDetailNoteTypeIdOriginalValue = (Guid)noteDataRow[noteDetailDataSubjectTypeIdFriendlyName];
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.NoDataFound", noteDetailDataSubjectFriendlyName);
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", noteDetailDataSubjectFriendlyName, ex.Message);
            }
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

            noteDetailDataSubjectCamelCaseName = dataSubjectProperties.DataSubject.DataSubjectCamelCaseName;
            noteDetailDataSubjectFriendlyName = dataSubjectProperties.DataSubject.DataSubjectFriendlyName;

            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName))
            {
                noteDetailDataSubjectIdFriendlyName = dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName;
            }

            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataSubject.DataSubjectSelectStoredProcedureName))
            {
                noteDetailDataSubjectSelectStoredProcedureName = dataSubjectProperties.DataSubject.DataSubjectSelectStoredProcedureName;
            }

            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataSubject.DataSubjectStoredProcedureIdParameterName))
            {
                noteDetailDataSubjectStoredProcedureIdParameterName = dataSubjectProperties.DataSubject.DataSubjectStoredProcedureIdParameterName;
            }

            noteDetailDataSubjectTitleFriendlyName = $"{noteDetailDataSubjectFriendlyName} Title";
            noteDetailDataSubjectTitleName = $"{noteDetailDataSubjectCamelCaseName}Title";
            noteDetailDataSubjectTypeFriendlyName = $"{noteDetailDataSubjectFriendlyName} Type";
            noteDetailDataSubjectTypeIdFriendlyName = $"{noteDetailDataSubjectTypeFriendlyName} Id";
            noteDetailDataSubjectTypeIdName = $"{noteDetailDataSubjectCamelCaseName}TypeId";

            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataSubject.DataSubjectUpdateStoredProcedureName))
            {
                noteDetailDataSubjectUpdateStoredProcedureName = dataSubjectProperties.DataSubject.DataSubjectUpdateStoredProcedureName;
            }

            this.Text = $"{applicationTitlePrefix}{noteDetailDataSubjectFriendlyName}{titleLabelSuffix}";
            noteDetailTitleLabel.Text = $"{noteDetailDataSubjectFriendlyName}{titleLabelSuffix}";
            noteDetailNoteIdTextBoxLabel.Text = noteDetailDataSubjectIdFriendlyName;
            noteDetailNoteTitleTextBoxLabel.Text = $"{noteDetailDataSubjectTitleFriendlyName}*";
            noteDetailNoteTypeComboBoxLabel.Text = $"{noteDetailDataSubjectFriendlyName}*";
            noteDetailUpdateNoteButton.Text = $"Update {noteDetailDataSubjectFriendlyName}";
            noteDetailStatusStrip.BackColor = SystemColors.Control;
        }

        private void noteDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            noteDetailNoteTextBox.ReadOnly = !noteDetailNoteTextBox.ReadOnly;
            noteDetailNoteTitleTextBox.ReadOnly = !noteDetailNoteTitleTextBox.ReadOnly;
            noteDetailNoteTypeComboBox.Enabled = !noteDetailNoteTypeComboBox.Enabled;
            noteDetailUpdateNoteButton.Enabled = !noteDetailUpdateNoteButton.Enabled;
        }

        private async void noteDetailUpdateNoteButton_Click(object sender, EventArgs e)
        {
            string note = TextBoxCleanerHelper.GetTrimmedText(noteDetailNoteTextBox);
            string noteTitle = TextBoxCleanerHelper.GetTrimmedText(noteDetailNoteTitleTextBox);
            Guid noteTypeId = (Guid)noteDetailNoteTypeComboBox.SelectedValue;

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
                    Name = noteDetailDataSubjectFriendlyName,
                    Value = note,
                    MaxLength = 4000,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = noteDetailDataSubjectTitleFriendlyName,
                    Value = noteTitle,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = noteDetailDataSubjectTypeIdFriendlyName,
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
                var changesList = new List<ChangeDetail>
                {
                    new ChangeDetail
                    {
                        VariableName = noteDetailDataSubjectFriendlyName,
                        OriginalValue = noteDetailNoteOriginalValue,
                        NewValue = note
                    },
                    new ChangeDetail
                    {
                        VariableName = noteDetailDataSubjectTitleFriendlyName,
                        OriginalValue = noteDetailNoteTitleOriginalValue,
                        NewValue = noteTitle
                    },
                    new ChangeDetail
                    {
                        VariableName = noteDetailDataSubjectTypeIdFriendlyName,
                        OriginalValue = noteDetailNoteTypeIdOriginalValue,
                        NewValue = noteTypeId
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = ChangeValidationService.ConfirmChanges(changesList, noteDetailDataSubjectFriendlyName);

                if (confirmed)
                {
                    var parameters = new[]
                    {
                        new StoredProcedureParameter
                        {
                            ParameterName = noteDetailDataSubjectStoredProcedureIdParameterName,
                            ParameterValue = _noteId
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName =noteDetailDataSubjectTitleName,
                            ParameterValue = noteTitle
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = noteDetailDataSubjectTypeIdName,
                            ParameterValue = noteTypeId
                        }
                    };

                    DataOperationType operationType = DataOperationType.Update;

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(
                        noteDetailDataSubjectFriendlyName,
                        _databaseConnectionSettings,
                        operationType,
                        noteDetailDataSubjectUpdateStoredProcedureName,
                        parameters.ToArray()
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