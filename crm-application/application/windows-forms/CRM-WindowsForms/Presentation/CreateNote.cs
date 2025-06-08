using CRM_WindowsForms.Interface;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreateNote : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _dataSubjectId;
        private readonly string _moduleGroup;
        private readonly string applicationTitlePrefix = "CRM - Create ";
        private string createNoteModuleNoteEntityFriendlyName;
        private string createNoteModuleNoteCreateStoredProcedureName;
        private string createNoteModuleNoteTypeFriendlyName;
        private string createNoteModuleNoteTypeName;
        private string? createNoteNoteTitleFriendlyName;
        private string createNoteNoteTitleName;
        private string createNoteNoteTypeFriendlyName;
        private string createNoteNoteTypeGetStoredProcedureName;
        private string createNoteNoteTypeIdFriendlyName;
        private string createNoteNoteTypeIdName;
        private string createNoteNoteTypeName;

        public CreateNote(Guid dataSubjectId, string moduleGroup)
        {
            InitializeComponent();
            InitializeCustomComponents();
            _dataSubjectId = dataSubjectId;
            _moduleGroup = moduleGroup;
            SetModuleTheme(_moduleGroup);
            CreateNoteLoadNoteTypeAsync();
        }

        private void InitializeCustomComponents()
        {
            createNoteNoteTypeComboBox.DropDown += new EventHandler(CreateNoteNoteTypeComboBox_DropDown);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void SetModuleTheme(string moduleGroup)
        {
            switch (moduleGroup)
            {
                case "CustomerManagement":
                    this.BackColor = Color.LightGreen;
                    createNoteModuleNoteEntityFriendlyName = "Customer";
                    createNoteModuleNoteCreateStoredProcedureName = "[dbo].[spCreateCustomerNote]";
                    createNoteModuleNoteTypeFriendlyName = "Customer Note";
                    createNoteModuleNoteTypeName = "CustomerNote";
                    createNoteNoteTitleFriendlyName = "Customer Note Title";
                    createNoteNoteTitleName = "CustomerNoteTitle";
                    createNoteNoteTypeFriendlyName = "Customer Note Type";
                    createNoteNoteTypeGetStoredProcedureName = "[dbo].[spGetAllCustomerNoteType]";
                    createNoteNoteTypeIdFriendlyName = "Customer Note Type Id";
                    createNoteNoteTypeIdName = "CustomerNoteTypeId";
                    createNoteNoteTypeName = "CustomerNoteType";
                    break;
                case "ProductManagement":
                    this.BackColor = Color.SkyBlue;
                    createNoteModuleNoteEntityFriendlyName = "Product";
                    createNoteModuleNoteCreateStoredProcedureName = "[dbo].[spCreateProductNote]";
                    createNoteModuleNoteTypeFriendlyName = "Product Note";
                    createNoteModuleNoteTypeName = "ProductNote";
                    createNoteNoteTitleFriendlyName = "Product Note Title";
                    createNoteNoteTitleName = "ProductNoteTitle";
                    createNoteNoteTypeFriendlyName = "Product Note Type";
                    createNoteNoteTypeGetStoredProcedureName = "[dbo].[spGetAllProductNoteType]";
                    createNoteNoteTypeIdFriendlyName = "Product Note Type Id";
                    createNoteNoteTypeIdName = "ProductNoteTypeId";
                    createNoteNoteTypeName = "ProductNoteType";
                    break;
                case "SupplierManagement":
                    this.BackColor = Color.MediumAquamarine;
                    createNoteModuleNoteEntityFriendlyName = "Supplier";
                    createNoteModuleNoteCreateStoredProcedureName = "[dbo].[spCreateSupplierNote]";
                    createNoteModuleNoteTypeFriendlyName = "Supplier Note";
                    createNoteModuleNoteTypeName = "SupplierNote";
                    createNoteNoteTitleFriendlyName = "Supplier Note Title";
                    createNoteNoteTitleName = "SupplierNoteTitle";
                    createNoteNoteTypeFriendlyName = "Supplier Note Type";
                    createNoteNoteTypeGetStoredProcedureName = "[dbo].[spGetAllSupplierNoteType]";
                    createNoteNoteTypeIdFriendlyName = "Supplier Note Type Id";
                    createNoteNoteTypeIdName = "SupplierNoteTypeId";
                    createNoteNoteTypeName = "SupplierNoteType";
                    break;
            }

            this.Text = $"{applicationTitlePrefix}{createNoteModuleNoteTypeFriendlyName}";
            createNoteTitleLabel.Text = createNoteModuleNoteTypeFriendlyName;
            createNoteNoteTitleLabel.Text = $"{createNoteNoteTitleFriendlyName}*";
            createNoteNoteTypeLabel.Text = $"{createNoteNoteTypeFriendlyName}*";
        }

        private async void CreateNoteLoadNoteTypeAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                DataTable? customerNoteTypeData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(createNoteNoteTypeGetStoredProcedureName, createNoteNoteTypeName, _databaseConnectionSettings.DatabaseConnectionString);

                var customerNoteTypeList = customerNoteTypeData.AsEnumerable()
                    .Select(row => new
                    {
                        NoteTypeId = row.Field<Guid>(createNoteNoteTypeIdFriendlyName),
                        NoteType = row.Field<string>(createNoteNoteTypeFriendlyName)
                    })
                    .OrderBy(item => item.NoteType)
                    .ToList();
                createNoteNoteTypeComboBox.DataSource = customerNoteTypeList;
                createNoteNoteTypeComboBox.DisplayMember = "NoteType";
                createNoteNoteTypeComboBox.ValueMember = "NoteTypeId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load {createNoteNoteTypeFriendlyName} data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateNoteNoteTypeComboBox_DropDown(object? sender, EventArgs e)
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
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var parameters = new List<Parameter>();

                switch (_moduleGroup)
                {
                    case "CustomerManagement":
                        parameters.Add(new Parameter
                        {
                            ParameterName = "@customerId",
                            ParameterValue = _dataSubjectId
                        });
                        parameters.Add(new Parameter
                        {
                            ParameterName = "@customerNote",
                            ParameterValue = note
                        });
                        parameters.Add(new Parameter
                        {
                            ParameterName = "@customerNoteTitle",
                            ParameterValue = noteTitle
                        });
                        parameters.Add(new Parameter
                        {
                            ParameterName = "@customerNoteTypeId",
                            ParameterValue = noteTypeId
                        });
                        break;
                    case "ProductManagement":
                        parameters.Add(new Parameter
                        {
                            ParameterName = "@productId",
                            ParameterValue = _dataSubjectId
                        });
                        parameters.Add(new Parameter
                        {
                            ParameterName = "@productNote",
                            ParameterValue = note
                        });
                        parameters.Add(new Parameter
                        {
                            ParameterName = "@productNoteTitle",
                            ParameterValue = noteTitle
                        });
                        parameters.Add(new Parameter
                        {
                            ParameterName = "@productNoteTypeId",
                            ParameterValue = noteTypeId
                        });
                        break;
                    case "SupplierManagement":
                        parameters.Add(new Parameter
                        {
                            ParameterName = "@supplierId",
                            ParameterValue = _dataSubjectId
                        });
                        parameters.Add(new Parameter
                        {
                            ParameterName = "@supplierNote",
                            ParameterValue = note
                        });
                        parameters.Add(new Parameter
                        {
                            ParameterName = "@supplierNoteTitle",
                            ParameterValue = noteTitle
                        });
                        parameters.Add(new Parameter
                        {
                            ParameterName = "@supplierNoteTypeId",
                            ParameterValue = noteTypeId
                        });
                        break;
                }

                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(
                    createNoteModuleNoteCreateStoredProcedureName,
                    parameters.ToArray(),
                    createNoteModuleNoteTypeFriendlyName,
                    _databaseConnectionSettings.DatabaseConnectionString,
                    operationType
                    );
                this.Close();
            }
        }
    }
}