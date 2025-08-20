using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
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
        private string noteDetailModuleNoteTypeName;
        private string noteDetailNoteGetStoredProcedureName;
        private string noteDetailNoteIdFriendlyName;
        private string noteDetailNoteIdName;
        private string? noteDetailNoteOriginalValue;
        private string noteDetailNoteStoredProcedureParameterPrefix;
        private string? noteDetailNoteTitleFriendlyName;
        private string noteDetailNoteTitleName;
        private string? noteDetailNoteTitleOriginalValue;
        private string noteDetailNoteTypeFriendlyName;
        private string noteDetailNoteTypeGetStoredProcedureName;
        private string noteDetailNoteTypeIdFriendlyName;
        private string noteDetailNoteTypeIdName;
        private string noteDetailNoteTypeName;
        private Guid? noteDetailNoteTypeIdOriginalValue;       
        private string noteDetailNoteUpdateStoredProcedureName;
        private readonly string titleLabelSuffix = " Detail";

        public NoteDetail(Guid dataSubjectId, string functionTitle, Guid noteId, string? dataSubjectName = null)
        {
            InitializeComponent();
            InitializeEventHandlers();
            _dataSubjectId = dataSubjectId;
            if(string.IsNullOrEmpty(dataSubjectName))
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

        private void InitializeEventHandlers()
        {
            noteDetailToggleEditModeButton.Click += new EventHandler(noteDetailToggleEditModeButton_Click);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void SetModuleTheme(string functionTitle)
        {
            switch (functionTitle)
            {
                case "Customer":
                    this.BackColor = Color.LightGreen;
                    noteDetailModuleNoteTypeFriendlyName = "Customer Note";
                    noteDetailModuleNoteTypeName = "CustomerNote";
                    noteDetailNoteGetStoredProcedureName = "spGetCustomerNote";
                    noteDetailNoteIdFriendlyName = "Customer Note Id";
                    noteDetailNoteIdName = "CustomerNoteId";
                    noteDetailNoteStoredProcedureParameterPrefix = "customerNote";
                    noteDetailNoteTitleFriendlyName = "Customer Note Title";
                    noteDetailNoteTitleName = "CustomerNoteTitle";
                    noteDetailNoteTypeFriendlyName = "Customer Note Type";
                    noteDetailNoteTypeGetStoredProcedureName = "spGetAllCustomerNoteType";
                    noteDetailNoteTypeIdFriendlyName = "Customer Note Type Id";
                    noteDetailNoteTypeIdName = "CustomerNoteTypeId";
                    noteDetailNoteTypeName = "CustomerNoteType";
                    noteDetailStatusStripDataSubjectPlaceholder.Text = $"Customer: {_dataSubjectName} ({_dataSubjectId})";
                    break;
                case "CustomerLead":
                    this.BackColor = Color.LightGreen;
                    noteDetailModuleNoteTypeFriendlyName = "Customer Lead Note";
                    noteDetailModuleNoteTypeName = "CustomerLeadNote";
                    noteDetailNoteGetStoredProcedureName = "spGetCustomerLeadNote";
                    noteDetailNoteIdFriendlyName = "Customer Lead Note Id";
                    noteDetailNoteIdName = "CustomerLeadNoteId";
                    noteDetailNoteStoredProcedureParameterPrefix = "customerLeadNote";
                    noteDetailNoteTitleFriendlyName = "Customer Lead Note Title";
                    noteDetailNoteTitleName = "CustomerLeadNoteTitle";
                    noteDetailNoteTypeFriendlyName = "Customer Lead Note Type";
                    noteDetailNoteTypeGetStoredProcedureName = "spGetAllCustomerLeadNoteType";
                    noteDetailNoteTypeIdFriendlyName = "Customer Lead Note Type Id";
                    noteDetailNoteTypeIdName = "CustomerLeadNoteTypeId";
                    noteDetailNoteTypeName = "CustomerLeadNoteType";
                    noteDetailStatusStripDataSubjectPlaceholder.Text = $"Customer Lead: {_dataSubjectName} ({_dataSubjectId})";
                    break;
                case "Product":
                    this.BackColor = Color.SkyBlue;
                    noteDetailModuleNoteTypeFriendlyName = "Product Note";
                    noteDetailModuleNoteTypeName = "ProductNote";
                    noteDetailNoteGetStoredProcedureName = "spGetProductNote";
                    noteDetailNoteIdFriendlyName = "Product Note Id";
                    noteDetailNoteIdName = "ProductNoteId";
                    noteDetailNoteStoredProcedureParameterPrefix = "productNote";
                    noteDetailNoteTitleFriendlyName = "Product Note Title";
                    noteDetailNoteTitleName = "ProductNoteTitle";
                    noteDetailNoteTypeFriendlyName = "Product Note Type";
                    noteDetailNoteTypeGetStoredProcedureName = "spGetAllProductNoteType";
                    noteDetailNoteTypeIdFriendlyName = "Product Note Type Id";
                    noteDetailNoteTypeIdName = "ProductNoteTypeId";
                    noteDetailNoteTypeName = "ProductNoteType";
                    noteDetailStatusStripDataSubjectPlaceholder.Text = $"Product: {_dataSubjectName} ({_dataSubjectId})";
                    break;
                case "Supplier":
                    this.BackColor = Color.MediumAquamarine;
                    noteDetailModuleNoteTypeFriendlyName = "Supplier Note";
                    noteDetailModuleNoteTypeName = "SupplierNote";
                    noteDetailNoteGetStoredProcedureName = "spGetSupplierNote";
                    noteDetailNoteIdFriendlyName = "Supplier Note Id";
                    noteDetailNoteIdName = "SupplierNoteId";
                    noteDetailNoteStoredProcedureParameterPrefix = "supplierNote";
                    noteDetailNoteTitleFriendlyName = "Supplier Note Title";
                    noteDetailNoteTitleName = "SupplierNoteTitle";
                    noteDetailNoteTypeFriendlyName = "Supplier Note Type";
                    noteDetailNoteTypeGetStoredProcedureName = "spGetAllSupplierNoteType";
                    noteDetailNoteTypeIdFriendlyName = "Supplier Note Type Id";
                    noteDetailNoteTypeIdName = "SupplierNoteTypeId";
                    noteDetailNoteTypeName = "SupplierNoteType";
                    noteDetailStatusStripDataSubjectPlaceholder.Text = $"Supplier: {_dataSubjectName} ({_dataSubjectId})";
                    break;
            }

            this.Text = $"{applicationTitlePrefix}{noteDetailModuleNoteTypeFriendlyName}{titleLabelSuffix}";
            noteDetailTitleLabel.Text = $"{noteDetailModuleNoteTypeFriendlyName}{titleLabelSuffix}";
            noteDetailNoteIdTextboxLabel.Text = noteDetailNoteIdFriendlyName;
            noteDetailNoteTitleTextboxLabel.Text = $"{noteDetailNoteTitleFriendlyName}*";
            noteDetailNoteTypeComboBoxLabel.Text = $"{noteDetailNoteTypeFriendlyName}*";
            noteDetailUpdateNoteButton.Text = $"Update {noteDetailModuleNoteTypeFriendlyName}";
        }

        private async Task LoadNoteTypeAsync(Guid noteTypeId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(noteDetailNoteTypeComboBox, noteDetailNoteTypeGetStoredProcedureName, null, true, "Note Type Id", noteTypeId);
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
                new Parameter
                {
                    ParameterName = $"@{noteDetailNoteStoredProcedureParameterPrefix}Id",
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
                    noteDetailNoteIdTextbox.Text = noteDataRow[noteDetailNoteIdFriendlyName].ToString();
                    noteDetailNoteTitleTextbox.Text = noteDataRow[noteDetailNoteTitleFriendlyName].ToString();
                    Guid noteTypeId = (Guid)noteDataRow[noteDetailNoteTypeIdFriendlyName];
                    await LoadNoteTypeAsync(noteTypeId);
                    noteDetailNoteTextbox.Text = noteDataRow[noteDetailModuleNoteTypeFriendlyName].ToString();
                    noteDetailCreatedByTextbox.Text = noteDataRow["Created By"].ToString();
                    noteDetailCreatedTimestampTextbox.Text = noteDataRow["Created Timestamp UTC"].ToString();
                    noteDetailLastUpdatedByTextbox.Text = noteDataRow["Modified By"].ToString();
                    noteDetailLastUpdatedTimestampTextbox.Text = noteDataRow["Modified Timestamp UTC"].ToString();

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

        private async void noteDetailUpdateNoteButton_Click(object sender, EventArgs e)
        {
            string note = noteDetailNoteTextbox.Text.TrimEnd();
            string noteTitle = noteDetailNoteTitleTextbox.Text.TrimEnd();
            Guid noteTypeId = (Guid)noteDetailNoteTypeComboBox.SelectedValue;

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
                    Name = noteDetailModuleNoteTypeFriendlyName,
                    Value = note,
                    MaxLength = 4000,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = noteDetailNoteTitleFriendlyName,
                    Value = noteTitle,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = noteDetailNoteTypeIdFriendlyName,
                    Value = noteTypeId,
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
                        VariableName = noteDetailModuleNoteTypeFriendlyName,
                        VariableType = "string",
                        OriginalValue = noteDetailNoteOriginalValue,
                        NewValue = note
                    },
                    new ChangeDetail
                    {
                        VariableName = noteDetailNoteTitleFriendlyName,
                        VariableType = "string",
                        OriginalValue = noteDetailNoteTitleOriginalValue,
                        NewValue = noteTitle
                    },
                    new ChangeDetail
                    {
                        VariableName = noteDetailNoteTypeIdFriendlyName,
                        VariableType = "Guid",
                        OriginalValue = noteDetailNoteTypeIdOriginalValue,
                        NewValue = noteTypeId
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = UpdateConfirmationService.ConfirmChanges(changesList, noteDetailModuleNoteTypeFriendlyName);

                if (confirmed)
                {
                    var parameters = new[]
                    {
                        new Parameter
                        {
                            ParameterName = $"{noteDetailNoteStoredProcedureParameterPrefix}Id",
                            ParameterValue = _noteId
                        },
                        new Parameter
                        {
                            ParameterName = $"{noteDetailNoteStoredProcedureParameterPrefix}Title",
                            ParameterValue = noteTitle
                        },
                        new Parameter
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

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            NoteDetailNoteInformation_Load(this, EventArgs.Empty);
        }

        private void noteDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            noteDetailNoteTextbox.ReadOnly = !noteDetailNoteTextbox.ReadOnly;
            noteDetailNoteTitleTextbox.ReadOnly = !noteDetailNoteTitleTextbox.ReadOnly;
            noteDetailNoteTypeComboBox.Enabled = !noteDetailNoteTypeComboBox.Enabled;
            noteDetailUpdateNoteButton.Enabled = !noteDetailUpdateNoteButton.Enabled;
        }
    }
}