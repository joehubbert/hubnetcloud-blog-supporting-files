using CRM.Helpers;
using CRM.Interface;
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
		private readonly string _functionTitle;
        private readonly string applicationTitlePrefix = "CRM - Create ";
        private string createNoteModuleNoteCreateStoredProcedureName;
        private string createNoteModuleNoteCreateStoredProcedureDataSubjectParentParameterPrefix;
        private string createNoteModuleNoteCreateStoredProcedureParameterPrefix;
        private string createNoteModuleNoteTypeFriendlyName;
        private string? createNoteNoteTitleFriendlyName;
        private string createNoteNoteTypeFriendlyName;
        private string createNoteNoteTypeGetStoredProcedureName;
        private string createNoteNoteTypeIdFriendlyName;

        public CreateNote(Guid dataSubjectId, string functionTitle, string? dataSubjectName = null)
        {
            InitializeComponent();
            InitializeEventHandlers();
            _dataSubjectId = dataSubjectId;
            _dataSubjectName = dataSubjectName;
			_functionTitle = functionTitle;
            SetModuleTheme();
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
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createNoteNoteTypeComboBox, createNoteNoteTypeGetStoredProcedureName);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private void SetModuleTheme()
        {
            switch (_functionTitle)
            {
                case "CustomerNote":
                    this.BackColor = Color.LightGreen;
                    createNoteModuleNoteCreateStoredProcedureName = "spCreateCustomerNote";
                    createNoteModuleNoteCreateStoredProcedureDataSubjectParentParameterPrefix = "customer";
                    createNoteModuleNoteCreateStoredProcedureParameterPrefix = "customerNote";
                    createNoteModuleNoteTypeFriendlyName = "Customer Note";
                    createNoteNoteTitleFriendlyName = "Customer Note Title";
                    createNoteNoteTypeFriendlyName = "Customer Note Type";
                    createNoteNoteTypeGetStoredProcedureName = "spGetAllCustomerNoteType";
                    createNoteNoteTypeIdFriendlyName = "Customer Note Type Id";
                    createNoteStatusStripDataSubjectPlaceholder.Text = $"Customer: {_dataSubjectName} ({_dataSubjectId})";
					break;
                case "CustomerLeadNote":
                    this.BackColor = Color.LightGreen;
                    createNoteModuleNoteCreateStoredProcedureName = "spCreateCustomerLeadNote";
                    createNoteModuleNoteCreateStoredProcedureDataSubjectParentParameterPrefix = "customerLead";
                    createNoteModuleNoteCreateStoredProcedureParameterPrefix = "customerLeadNote";
                    createNoteModuleNoteTypeFriendlyName = "Customer Lead Note";
                    createNoteNoteTitleFriendlyName = "Customer Lead Note Title";
                    createNoteNoteTypeFriendlyName = "Customer Lead Note Type";
                    createNoteNoteTypeGetStoredProcedureName = "spGetAllCustomerLeadNoteType";
                    createNoteNoteTypeIdFriendlyName = "Customer Lead Note Type Id";
					createNoteStatusStripDataSubjectPlaceholder.Text = $"Customer Lead: {_dataSubjectName} ({_dataSubjectId})";
					break;
                case "ProductNote":
                    this.BackColor = Color.SkyBlue;
                    createNoteModuleNoteCreateStoredProcedureName = "spCreateProductNote";
                    createNoteModuleNoteCreateStoredProcedureDataSubjectParentParameterPrefix = "product";
                    createNoteModuleNoteCreateStoredProcedureParameterPrefix = "productNote";
                    createNoteModuleNoteTypeFriendlyName = "Product Note";
                    createNoteNoteTitleFriendlyName = "Product Note Title";
                    createNoteNoteTypeFriendlyName = "Product Note Type";
                    createNoteNoteTypeGetStoredProcedureName = "spGetAllProductNoteType";
                    createNoteNoteTypeIdFriendlyName = "Product Note Type Id";
					createNoteStatusStripDataSubjectPlaceholder.Text = $"Product: {_dataSubjectName} ({_dataSubjectId})";
					break;
                case "SupplierNote":
                    this.BackColor = Color.MediumAquamarine;
                    createNoteModuleNoteCreateStoredProcedureName = "spCreateSupplierNote";
                    createNoteModuleNoteCreateStoredProcedureDataSubjectParentParameterPrefix = "supplier";
                    createNoteModuleNoteCreateStoredProcedureParameterPrefix = "supplierNote";
                    createNoteModuleNoteTypeFriendlyName = "Supplier Note";
                    createNoteNoteTitleFriendlyName = "Supplier Note Title";
                    createNoteNoteTypeFriendlyName = "Supplier Note Type";
                    createNoteNoteTypeGetStoredProcedureName = "spGetAllSupplierNoteType";
                    createNoteNoteTypeIdFriendlyName = "Supplier Note Type Id";
					createNoteStatusStripDataSubjectPlaceholder.Text = $"Supplier: {_dataSubjectName} ({_dataSubjectId})";
					break;
            }

            this.Text = $"{applicationTitlePrefix}{createNoteModuleNoteTypeFriendlyName}";
            createNoteTitleLabel.Text = createNoteModuleNoteTypeFriendlyName;
            createNoteNoteTitleTextBoxLabel.Text = $"{createNoteNoteTitleFriendlyName}*";
            createNoteNoteTypeComboBoxLabel.Text = $"{createNoteNoteTypeFriendlyName}*";
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
                    Name = createNoteModuleNoteTypeFriendlyName,
                    Value = note,
                    MaxLength = 4000,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = createNoteNoteTitleFriendlyName,
                    Value = noteTitle,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = createNoteNoteTypeIdFriendlyName,
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
                        ParameterName = $"{createNoteModuleNoteCreateStoredProcedureDataSubjectParentParameterPrefix}Id",
                        ParameterValue = _dataSubjectId
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = $"{createNoteModuleNoteCreateStoredProcedureParameterPrefix}",
                        ParameterValue = note
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = $"{createNoteModuleNoteCreateStoredProcedureParameterPrefix}Title",
                        ParameterValue = noteTitle
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = $"{createNoteModuleNoteCreateStoredProcedureParameterPrefix}TypeId",
                        ParameterValue = noteTypeId
                    }
                };

                string operationType = "Create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(
                    createNoteModuleNoteCreateStoredProcedureName,
                    parameters.ToArray(),
                    createNoteModuleNoteTypeFriendlyName,
                    operationType
                    );
                this.Close();
            }
        }
    }
}