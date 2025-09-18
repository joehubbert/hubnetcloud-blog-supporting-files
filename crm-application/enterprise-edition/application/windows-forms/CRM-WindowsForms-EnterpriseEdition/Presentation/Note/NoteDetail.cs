using CRM.Helpers;
using CRM.Interface;
using CRM.Services;
using System.Data;
using System.Diagnostics;

namespace CRM.Presentation.Note
{
    public partial class NoteDetail : Form
    {
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private readonly Guid _dataSubjectId;
        private readonly string _dataSubjectName;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string _functionTitle;
        private readonly Guid _noteId;
        private readonly string applicationTitlePrefix = "CRM - ";
        private string noteDetailModuleNoteTypeFriendlyName;
        private string noteDetailNoteGetStoredProcedureName;
        private string noteDetailNoteIdFriendlyName;
        private string noteDetailNoteOriginalValue;
        private string noteDetailNoteStoredProcedureParameterPrefix;
        private string noteDetailNoteTitleFriendlyName;
        private string noteDetailNoteTitleOriginalValue;
        private string noteDetailNoteTypeFriendlyName;
        private string noteDetailNoteTypeGetStoredProcedureName;
        private string noteDetailNoteTypeIdFriendlyName;
        private Guid noteDetailNoteTypeIdOriginalValue;       
        private string noteDetailNoteUpdateStoredProcedureName;
        private readonly string titleLabelSuffix = " Detail";

        public NoteDetail(Guid dataSubjectId, string functionTitle, Guid noteId, string? dataSubjectName = null)
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
            _noteId = noteId;
            SetModuleTheme(_functionTitle);
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
                noteDetailNoteTypeGetStoredProcedureName,
                null,
                true,
                noteDetailNoteTypeIdFriendlyName,
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
                    ParameterName = $"{noteDetailNoteStoredProcedureParameterPrefix}Id",
                    ParameterValue = _noteId
                }
            };

            try
            {
                DataTable? noteDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(
                    noteDetailNoteGetStoredProcedureName,
                    parameters.ToArray(),
                    noteDetailModuleNoteTypeFriendlyName
                    );

                if (noteDataTable != null)
                {
                    DataRow noteDataRow = noteDataTable.Rows[0];
                    noteDetailNoteIdTextBox.Text = noteDataRow[noteDetailNoteIdFriendlyName].ToString();
                    noteDetailNoteTitleTextBox.Text = noteDataRow[noteDetailNoteTitleFriendlyName].ToString();
                    Guid noteTypeId = (Guid)noteDataRow[noteDetailNoteTypeIdFriendlyName];
                    await LoadNoteTypeAsync(noteTypeId);
                    noteDetailNoteTextBox.Text = noteDataRow[noteDetailModuleNoteTypeFriendlyName].ToString();
                    noteDetailCreatedByTextBox.Text = noteDataRow["Created By"].ToString();
                    noteDetailCreatedTimestampTextBox.Text = noteDataRow["Created Timestamp UTC"].ToString();
                    noteDetailLastUpdatedByTextBox.Text = noteDataRow["Modified By"].ToString();
                    noteDetailLastUpdatedTimestampTextBox.Text = noteDataRow["Modified Timestamp UTC"].ToString();

                    noteDetailNoteOriginalValue = noteDataRow[noteDetailModuleNoteTypeFriendlyName].ToString();
                    noteDetailNoteTitleOriginalValue = noteDataRow[noteDetailNoteTitleFriendlyName].ToString();
                    noteDetailNoteTypeIdOriginalValue = (Guid)noteDataRow[noteDetailNoteTypeIdFriendlyName];
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.NoDataFound", noteDetailModuleNoteTypeFriendlyName);
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", noteDetailModuleNoteTypeFriendlyName, ex.Message);
            }
        }

        private void SetModuleTheme(string functionTitle)
        {
            switch (functionTitle)
            {
                case "Customer":
                    this.BackColor = Color.LightGreen;
                    noteDetailModuleNoteTypeFriendlyName = "Customer Note";
                    noteDetailNoteGetStoredProcedureName = "spGetCustomerNote";
                    noteDetailNoteIdFriendlyName = "Customer Note Id";
                    noteDetailNoteStoredProcedureParameterPrefix = "customerNote";
                    noteDetailNoteTitleFriendlyName = "Customer Note Title";
                    noteDetailNoteTypeFriendlyName = "Customer Note Type";
                    noteDetailNoteTypeGetStoredProcedureName = "spGetAllCustomerNoteType";
                    noteDetailNoteTypeIdFriendlyName = "Customer Note Type Id";
                    noteDetailStatusStripDataSubjectPlaceholder.Text = $"Customer: {_dataSubjectName} ({_dataSubjectId})";
                    break;
                case "CustomerLead":
                    this.BackColor = Color.LightGreen;
                    noteDetailModuleNoteTypeFriendlyName = "Customer Lead Note";
                    noteDetailNoteGetStoredProcedureName = "spGetCustomerLeadNote";
                    noteDetailNoteIdFriendlyName = "Customer Lead Note Id";
                    noteDetailNoteStoredProcedureParameterPrefix = "customerLeadNote";
                    noteDetailNoteTitleFriendlyName = "Customer Lead Note Title";
                    noteDetailNoteTypeFriendlyName = "Customer Lead Note Type";
                    noteDetailNoteTypeGetStoredProcedureName = "spGetAllCustomerLeadNoteType";
                    noteDetailNoteTypeIdFriendlyName = "Customer Lead Note Type Id";
                    noteDetailStatusStripDataSubjectPlaceholder.Text = $"Customer Lead: {_dataSubjectName} ({_dataSubjectId})";
                    break;
                case "Product":
                    this.BackColor = Color.SkyBlue;
                    noteDetailModuleNoteTypeFriendlyName = "Product Note";
                    noteDetailNoteGetStoredProcedureName = "spGetProductNote";
                    noteDetailNoteIdFriendlyName = "Product Note Id";
                    noteDetailNoteStoredProcedureParameterPrefix = "productNote";
                    noteDetailNoteTitleFriendlyName = "Product Note Title";
                    noteDetailNoteTypeFriendlyName = "Product Note Type";
                    noteDetailNoteTypeGetStoredProcedureName = "spGetAllProductNoteType";
                    noteDetailNoteTypeIdFriendlyName = "Product Note Type Id";
                    noteDetailStatusStripDataSubjectPlaceholder.Text = $"Product: {_dataSubjectName} ({_dataSubjectId})";
                    break;
                case "Supplier":
                    this.BackColor = Color.MediumAquamarine;
                    noteDetailModuleNoteTypeFriendlyName = "Supplier Note";
                    noteDetailNoteGetStoredProcedureName = "spGetSupplierNote";
                    noteDetailNoteIdFriendlyName = "Supplier Note Id";
                    noteDetailNoteStoredProcedureParameterPrefix = "supplierNote";
                    noteDetailNoteTitleFriendlyName = "Supplier Note Title";
                    noteDetailNoteTypeFriendlyName = "Supplier Note Type";
                    noteDetailNoteTypeGetStoredProcedureName = "spGetAllSupplierNoteType";
                    noteDetailNoteTypeIdFriendlyName = "Supplier Note Type Id";
                    noteDetailStatusStripDataSubjectPlaceholder.Text = $"Supplier: {_dataSubjectName} ({_dataSubjectId})";
                    break;
            }

            this.Text = $"{applicationTitlePrefix}{noteDetailModuleNoteTypeFriendlyName}{titleLabelSuffix}";
            noteDetailTitleLabel.Text = $"{noteDetailModuleNoteTypeFriendlyName}{titleLabelSuffix}";
            noteDetailNoteIdTextBoxLabel.Text = noteDetailNoteIdFriendlyName;
            noteDetailNoteTitleTextBoxLabel.Text = $"{noteDetailNoteTitleFriendlyName}*";
            noteDetailNoteTypeComboBoxLabel.Text = $"{noteDetailNoteTypeFriendlyName}*";
            noteDetailUpdateNoteButton.Text = $"Update {noteDetailModuleNoteTypeFriendlyName}";
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
                    Name = noteDetailModuleNoteTypeFriendlyName,
                    Value = note,
                    MaxLength = 4000,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = noteDetailNoteTitleFriendlyName,
                    Value = noteTitle,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = noteDetailNoteTypeIdFriendlyName,
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
                        VariableName = noteDetailModuleNoteTypeFriendlyName,
                        OriginalValue = noteDetailNoteOriginalValue,
                        NewValue = note
                    },
                    new ChangeDetail
                    {
                        VariableName = noteDetailNoteTitleFriendlyName,
                        OriginalValue = noteDetailNoteTitleOriginalValue,
                        NewValue = noteTitle
                    },
                    new ChangeDetail
                    {
                        VariableName = noteDetailNoteTypeIdFriendlyName,
                        OriginalValue = noteDetailNoteTypeIdOriginalValue,
                        NewValue = noteTypeId
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = ChangeValidationService.ConfirmChanges(changesList, noteDetailModuleNoteTypeFriendlyName);

                if (confirmed)
                {
                    var parameters = new[]
                    {
                        new StoredProcedureParameter
                        {
                            ParameterName = $"{noteDetailNoteStoredProcedureParameterPrefix}Id",
                            ParameterValue = _noteId
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = $"{noteDetailNoteStoredProcedureParameterPrefix}Title",
                            ParameterValue = noteTitle
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = $"{noteDetailNoteStoredProcedureParameterPrefix}TypeId",
                            ParameterValue = noteTypeId
                        }
                    };

                    string operationType = "update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(
                        noteDetailNoteUpdateStoredProcedureName,
                        parameters.ToArray(),
                        noteDetailModuleNoteTypeFriendlyName,
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