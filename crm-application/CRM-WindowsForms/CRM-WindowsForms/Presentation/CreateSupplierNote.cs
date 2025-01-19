using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreateSupplierNote : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _supplierId;
        private readonly string dataSubject = "Supplier Note";

        public CreateSupplierNote(Guid supplierId)
        {
            InitializeComponent();
            InitializeCustomComponents();
            _supplierId = supplierId;
            CreateSupplierNoteLoadNoteTypeAsync();
        }

        private void InitializeCustomComponents()
        {
            createSupplierNoteSupplierNoteTypeComboBox.DropDown += new EventHandler(CreateSupplierNoteSupplierNoteTypeComboBox_DropDown);
        }

        private async void CreateSupplierNoteLoadNoteTypeAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                string storedProcedureName = "[dbo].[spGetAllSupplierNoteType]";
                string dataSubject = "Supplier Note Type";
                DataTable? supplierNoteTypeData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var supplierNoteTypeList = supplierNoteTypeData.AsEnumerable()
                    .Select(row => new
                    {
                        SupplierNoteTypeId = row.Field<Guid>("Supplier Note Type Id"),
                        SupplierNoteType = row.Field<string>("Supplier Note Type")
                    })
                    .OrderBy(item => item.SupplierNoteType)
                    .ToList();
                createSupplierNoteSupplierNoteTypeComboBox.DataSource = supplierNoteTypeList;
                createSupplierNoteSupplierNoteTypeComboBox.DisplayMember = "SupplierNoteType";
                createSupplierNoteSupplierNoteTypeComboBox.ValueMember = "SupplierNoteTypeId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Supplier Note Type data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateSupplierNoteSupplierNoteTypeComboBox_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void createSupplierSubmitButton_Click(object sender, EventArgs e)
        {
            Guid supplierId = _supplierId;
            string supplierNote = createSupplierNoteSupplierNoteTextbox.Text.TrimEnd();
            string supplierNoteTitle = createSupplierNoteSupplierNoteTitleTextbox.Text.TrimEnd();
            Guid supplierNoteTypeId = Guid.Parse(createSupplierNoteSupplierNoteTypeComboBox.SelectedValue.ToString());

            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var stringsToValidate = new List<ValidateStringInput.StringProperty>
            {
                new ValidateStringInput.StringProperty
                {
                    Name = "SupplierNoteTitle",
                    Value = supplierNoteTitle,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "SupplierNote",
                    Value = supplierNote,
                    MaxLength = 1073741823
                }
            };

            var validationResult = ValidateStringInput.ValidateInput(stringsToValidate);

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
                            ParameterName = "@supplierId",
                            ParameterValue = supplierId
                        },
                        new Parameter
                        {
                            ParameterName = "@supplierNote",
                            ParameterValue = supplierNote
                        },
                        new Parameter
                        {
                            ParameterName = "@supplierNoteTitle",
                            ParameterValue = supplierNoteTitle
                        },
                        new Parameter
                        {
                            ParameterName = "@supplierNoteTypeId",
                            ParameterValue = supplierNoteTypeId
                        }
                };
                string storedProcedureName = "[dbo].[spCreateSupplierNote]";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                this.Close();
            }
        }
    }
}