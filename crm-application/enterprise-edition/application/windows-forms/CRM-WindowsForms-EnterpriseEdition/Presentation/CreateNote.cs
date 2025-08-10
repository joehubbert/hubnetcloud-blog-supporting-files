using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateNote : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _dataSubjectId;
        private readonly string _functionTitle;
        private readonly string applicationTitlePrefix = "CRM - Create ";
        private string createNoteModuleNoteEntityFriendlyName;
        private string createNoteModuleNoteCreateStoredProcedureName;
        private string createNoteModuleNoteCreateStoredProcedureDataSubjectParentParameterPrefix;
        private string createNoteModuleNoteCreateStoredProcedureParameterPrefix;
        private string createNoteModuleNoteTypeFriendlyName;
        private string createNoteModuleNoteTypeName;
        private string? createNoteNoteTitleFriendlyName;
        private string createNoteNoteTitleName;
        private string createNoteNoteTypeFriendlyName;
        private string createNoteNoteTypeGetStoredProcedureName;
        private string createNoteNoteTypeIdFriendlyName;
        private string createNoteNoteTypeIdName;
        private string createNoteNoteTypeName;

        public CreateNote(Guid dataSubjectId, string functionTitle)
        {
            InitializeComponent();
            InitializeCustomComponents();
            _dataSubjectId = dataSubjectId;
            _functionTitle = functionTitle;
            SetModuleTheme(_functionTitle);
            LoadDatabaseConnectionSettingsAsync();
            CreateNoteLoadNoteTypeAsync();
        }

        private void InitializeCustomComponents()
        {
            createNoteNoteTypeComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void SetModuleTheme(string functionTitle)
        {
            switch (functionTitle)
            {
                case "CustomerNote":
                    this.BackColor = Color.LightGreen;
                    createNoteModuleNoteEntityFriendlyName = "Customer";
                    createNoteModuleNoteCreateStoredProcedureName = "spCreateCustomerNote";
                    createNoteModuleNoteCreateStoredProcedureDataSubjectParentParameterPrefix = "customer";
                    createNoteModuleNoteCreateStoredProcedureParameterPrefix = "customerNote";
                    createNoteModuleNoteTypeFriendlyName = "Customer Note";
                    createNoteModuleNoteTypeName = "CustomerNote";
                    createNoteNoteTitleFriendlyName = "Customer Note Title";
                    createNoteNoteTitleName = "CustomerNoteTitle";
                    createNoteNoteTypeFriendlyName = "Customer Note Type";
                    createNoteNoteTypeGetStoredProcedureName = "spGetAllCustomerNoteType";
                    createNoteNoteTypeIdFriendlyName = "Customer Note Type Id";
                    createNoteNoteTypeIdName = "CustomerNoteTypeId";
                    createNoteNoteTypeName = "CustomerNoteType";
                    break;
                case "CustomerLeadNote":
                    this.BackColor = Color.LightGreen;
                    createNoteModuleNoteEntityFriendlyName = "Customer Lead";
                    createNoteModuleNoteCreateStoredProcedureName = "spCreateCustomerLeadNote";
                    createNoteModuleNoteCreateStoredProcedureDataSubjectParentParameterPrefix = "customerLead";
                    createNoteModuleNoteCreateStoredProcedureParameterPrefix = "customerLeadNote";
                    createNoteModuleNoteTypeFriendlyName = "Customer Lead Note";
                    createNoteModuleNoteTypeName = "CustomerLeadNote";
                    createNoteNoteTitleFriendlyName = "Customer Lead Note Title";
                    createNoteNoteTitleName = "CustomerLeadNoteTitle";
                    createNoteNoteTypeFriendlyName = "Customer Lead Note Type";
                    createNoteNoteTypeGetStoredProcedureName = "spGetAllCustomerLeadNoteType";
                    createNoteNoteTypeIdFriendlyName = "Customer Lead Note Type Id";
                    createNoteNoteTypeIdName = "CustomerLeadNoteTypeId";
                    createNoteNoteTypeName = "CustomerLeadNoteType";
                    break;
                case "ProductNote":
                    this.BackColor = Color.SkyBlue;
                    createNoteModuleNoteEntityFriendlyName = "Product";
                    createNoteModuleNoteCreateStoredProcedureName = "spCreateProductNote";
                    createNoteModuleNoteCreateStoredProcedureDataSubjectParentParameterPrefix = "product";
                    createNoteModuleNoteCreateStoredProcedureParameterPrefix = "productNote";
                    createNoteModuleNoteTypeFriendlyName = "Product Note";
                    createNoteModuleNoteTypeName = "ProductNote";
                    createNoteNoteTitleFriendlyName = "Product Note Title";
                    createNoteNoteTitleName = "ProductNoteTitle";
                    createNoteNoteTypeFriendlyName = "Product Note Type";
                    createNoteNoteTypeGetStoredProcedureName = "spGetAllProductNoteType";
                    createNoteNoteTypeIdFriendlyName = "Product Note Type Id";
                    createNoteNoteTypeIdName = "ProductNoteTypeId";
                    createNoteNoteTypeName = "ProductNoteType";
                    break;
                case "SupplierNote":
                    this.BackColor = Color.MediumAquamarine;
                    createNoteModuleNoteEntityFriendlyName = "Supplier";
                    createNoteModuleNoteCreateStoredProcedureName = "spCreateSupplierNote";
                    createNoteModuleNoteCreateStoredProcedureDataSubjectParentParameterPrefix = "supplier";
                    createNoteModuleNoteCreateStoredProcedureParameterPrefix = "supplierNote";
                    createNoteModuleNoteTypeFriendlyName = "Supplier Note";
                    createNoteModuleNoteTypeName = "SupplierNote";
                    createNoteNoteTitleFriendlyName = "Supplier Note Title";
                    createNoteNoteTitleName = "SupplierNoteTitle";
                    createNoteNoteTypeFriendlyName = "Supplier Note Type";
                    createNoteNoteTypeGetStoredProcedureName = "spGetAllSupplierNoteType";
                    createNoteNoteTypeIdFriendlyName = "Supplier Note Type Id";
                    createNoteNoteTypeIdName = "SupplierNoteTypeId";
                    createNoteNoteTypeName = "SupplierNoteType";
                    break;
            }

            this.Text = $"{applicationTitlePrefix}{createNoteModuleNoteTypeFriendlyName}";
            createNoteTitleLabel.Text = createNoteModuleNoteTypeFriendlyName;
            createNoteNoteTitleTextboxLabel.Text = $"{createNoteNoteTitleFriendlyName}*";
            createNoteNoteTypeComboBoxLabel.Text = $"{createNoteNoteTypeFriendlyName}*";
        }

        private async void CreateNoteLoadNoteTypeAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            try
            {
                DataTable? noteTypeData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(createNoteNoteTypeGetStoredProcedureName, createNoteNoteTypeName);

                var noteTypeList = noteTypeData.AsEnumerable()
                    .Select(row => new
                    {
                        NoteTypeId = row.Field<Guid>(createNoteNoteTypeIdFriendlyName),
                        NoteType = row.Field<string>(createNoteNoteTypeFriendlyName)
                    })
                    .OrderBy(item => item.NoteType)
                    .ToList();
                createNoteNoteTypeComboBox.DataSource = noteTypeList;
                createNoteNoteTypeComboBox.DisplayMember = "NoteType";
                createNoteNoteTypeComboBox.ValueMember = "NoteTypeId";
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", createNoteNoteTypeFriendlyName, ex.Message);
            }
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void createNoteSubmitButton_Click(object sender, EventArgs e)
        {
            string note = createNoteNoteTextbox.Text.TrimEnd();
            string noteTitle = createNoteNoteTitleTextbox.Text.TrimEnd();
            Guid noteTypeId = Guid.Parse(createNoteNoteTypeComboBox.SelectedValue.ToString());

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
                    Name = createNoteModuleNoteTypeName,
                    Value = note,
                    MaxLength = 4000,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = createNoteNoteTitleName,
                    Value = noteTitle,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = createNoteNoteTypeIdName,
                    Value = noteTypeId,
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
                        ParameterName = $"@{createNoteModuleNoteCreateStoredProcedureDataSubjectParentParameterPrefix}Id",
                        ParameterValue = _dataSubjectId
                    },
                    new Parameter
                    {
                        ParameterName = $"@{createNoteModuleNoteCreateStoredProcedureParameterPrefix}",
                        ParameterValue = note
                    },
                    new Parameter
                    {
                        ParameterName = $"@{createNoteModuleNoteCreateStoredProcedureParameterPrefix}Title",
                        ParameterValue = noteTitle
                    },
                    new Parameter
                    {
                        ParameterName = $"@{createNoteModuleNoteCreateStoredProcedureParameterPrefix}TypeId",
                        ParameterValue = noteTypeId
                    }
                };

                string operationType = "create";

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