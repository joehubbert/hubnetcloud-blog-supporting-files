using CRM_WindowsForms.Interface;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreateProductNote : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _productId;
        private readonly string dataSubject = "Product Note";

        public CreateProductNote(Guid productId)
        {
            InitializeComponent();
            InitializeCustomComponents();
            _productId = productId;
            CreateProductNoteLoadNoteTypeAsync();
        }

        private void InitializeCustomComponents()
        {
            createProductNoteProductNoteTypeComboBox.DropDown += new EventHandler(CreateProductNoteProductNoteTypeComboBox_DropDown);
        }

        private async void CreateProductNoteLoadNoteTypeAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                string storedProcedureName = "[dbo].[spGetAllProductNoteType]";
                string dataSubject = "Product Note Type";
                DataTable? productNoteTypeData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var productNoteTypeList = productNoteTypeData.AsEnumerable()
                    .Select(row => new
                    {
                        ProductNoteTypeId = row.Field<Guid>("Product Note Type Id"),
                        ProductNoteType = row.Field<string>("Product Note Type")
                    })
                    .OrderBy(item => item.ProductNoteType)
                    .ToList();
                createProductNoteProductNoteTypeComboBox.DataSource = productNoteTypeList;
                createProductNoteProductNoteTypeComboBox.DisplayMember = "ProductNoteType";
                createProductNoteProductNoteTypeComboBox.ValueMember = "ProductNoteTypeId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Product Note Type data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateProductNoteProductNoteTypeComboBox_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void createProductSubmitButton_Click(object sender, EventArgs e)
        {
            Guid productId = _productId;
            string productNote = createProductNoteProductNoteTextbox.Text.TrimEnd();
            string productNoteTitle = createProductNoteProductNoteTitleTextbox.Text.TrimEnd();
            Guid productNoteTypeId = Guid.Parse(createProductNoteProductNoteTypeComboBox.SelectedValue.ToString());

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
                    Name = "ProductId",
                    Value = productId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductNote",
                    Value = productNote,
                    MaxLength = 4000,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductNoteTitle",
                    Value = productNoteTitle,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductNoteTypeId",
                    Value = productNoteTypeId,
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
                        ParameterName = "@productId",
                        ParameterValue = productId
                    },
                    new Parameter
                    {
                        ParameterName = "@productNote",
                        ParameterValue = productNote
                    },
                    new Parameter
                    {
                        ParameterName = "@productNoteTitle",
                        ParameterValue = productNoteTitle
                    },
                    new Parameter
                    {
                        ParameterName = "@productNoteTypeId",
                        ParameterValue = productNoteTypeId
                    }
                };
                string storedProcedureName = "[dbo].[spCreateProductNote]";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                this.Close();
            }
        }
    }
}