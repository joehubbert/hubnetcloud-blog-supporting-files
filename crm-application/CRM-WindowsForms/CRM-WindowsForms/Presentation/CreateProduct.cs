using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreateProduct : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string dataSubject = "Product";

        public CreateProduct()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadDatabaseConnectionSettingsAsync();
            LoadInitialDataAsync();
        }

        private void InitializeCustomComponents()
        {
            createProductProductCategoryComboBox.DropDown += new EventHandler(CreateProductProductCategoryComboBox_DropDown);
            createProductSupplierComboBox.DropDown += new EventHandler(CreateProductSupplierComboBox_DropDown);
            createProductWholesaleCartonQuantityTextbox.TextChanged += new EventHandler(CalulateUnitStockQuantityHeld);
            createProductWholesaleUnitQuantityPerCartonTextbox.TextChanged += new EventHandler(CalulateUnitStockQuantityHeld);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task LoadInitialDataAsync()
        {
            await LoadDatabaseConnectionSettingsAsync();

            var loadProductCategoryTask = CreateProductLoadProductCategoryDataAsync();
            var loadSupplierTask = CreateProductLoadSupplierDataAsync();

            await Task.WhenAll(loadProductCategoryTask, loadSupplierTask);
        }

        private async Task CreateProductLoadProductCategoryDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            try
            {
                string storedProcedureName = "[dbo].[spGetAllProductCategory]";
                string dataSubject = "Product Category";
                DataTable? productCategoryData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var productCategoryList = productCategoryData.AsEnumerable()
                    .Select(row => new
                    {
                        ProductCategoryId = row.Field<Guid>("Product Category Id"),
                        ProductCategory = row.Field<string>("Product Category")
                    })
                    .OrderBy(item => item.ProductCategory)
                    .ToList();

                createProductProductCategoryComboBox.DataSource = productCategoryList;
                createProductProductCategoryComboBox.DisplayMember = "ProductCategory";
                createProductProductCategoryComboBox.ValueMember = "ProductCategoryId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Product Category data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateProductProductCategoryComboBox_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async Task CreateProductLoadSupplierDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            try
            {
                string storedProcedureName = "[dbo].[spGetAllSupplier]";
                string dataSubject = "Supplier";
                DataTable? supplierData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var supplierList = supplierData.AsEnumerable()
                    .Select(row => new
                    {
                        SupplierId = row.Field<Guid>("Supplier Id"),
                        SupplierName = row.Field<string>("Supplier Name"),
                        DisplayText = $"{row.Field<string>("Supplier Id")} - {row.Field<string>("Supplier Name")}"
                    })
                    .OrderBy(item => item.DisplayText)
                    .ToList();

                createProductSupplierComboBox.DataSource = supplierList;
                createProductSupplierComboBox.DisplayMember = "DisplayText";
                createProductSupplierComboBox.ValueMember = "SupplierId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Supplier data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateProductSupplierComboBox_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private void CalulateUnitStockQuantityHeld(object? sender, EventArgs e)
        {
            createProductUnitStockQuantityHeldTextbox.Text = (int.Parse(createProductWholesaleCartonQuantityTextbox.Text) * int.Parse(createProductWholesaleUnitQuantityPerCartonTextbox.Text)).ToString();
        }

        private async void createProductSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createProductActiveStatusCheckbox.Checked;
            Guid productCategoryId = Guid.Parse(createProductProductCategoryComboBox.SelectedValue.ToString());
            string productName = createProductProductNameTextbox.Text.TrimEnd();
            decimal unitPrice = decimal.Parse(createProductWholesalePricePerUnitTextboxA.Text.TrimEnd() + decimal.Parse(createProductWholesalePricePerUnitTextboxB.Text.TrimEnd()));
            int unitStockQuantityHeld = int.Parse(createProductUnitStockQuantityHeldTextbox.Text.TrimEnd());
            decimal wholesalePricePerUnit = decimal.Parse(createProductWholesalePricePerUnitTextboxA.Text.TrimEnd() + decimal.Parse(createProductWholesalePricePerUnitTextboxB.Text.TrimEnd()));
            bool wholesaleReorderFlag;
            if (createProductWholesaleReorderFlagYesRadioButton.Checked)
            {
                wholesaleReorderFlag = true;
            }
            else
            {
                wholesaleReorderFlag = false;
            }
            int wholesaleUnitQuantityPerCarton = int.Parse(createProductWholesaleUnitQuantityPerCartonTextbox.Text.TrimEnd());
            Guid supplierId = Guid.Parse(createProductSupplierComboBox.SelectedValue.ToString());

            string dataSubject = "Product";

            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dataToValidate = new List<ValidateDataInput.DataProperty>
            {
                new ValidateDataInput.DataProperty
                {
                    Name = "ActiveStatus",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    Name = "ProductCategory",
                    Value = productCategoryId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    Name = "ProductName",
                    Value = productName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    Name = "UnitPrice",
                    Value = unitPrice,
                    ValueType = typeof(decimal)
                },
                new ValidateDataInput.DataProperty
                {
                    Name = "UnitStockQuantityHeld",
                    Value = unitStockQuantityHeld,
                    ValueType = typeof(int)
                },
                new ValidateDataInput.DataProperty
                {
                    Name = "WholesalePricePerUnit",
                    Value = wholesalePricePerUnit,
                    ValueType = typeof(decimal)
                },
                new ValidateDataInput.DataProperty
                {
                    Name = "WholesaleReorderFlag",
                    Value = wholesaleReorderFlag,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    Name = "WholesaleUnitQuantityPerCarton",
                    Value = wholesaleUnitQuantityPerCarton,
                    ValueType = typeof(int)
                },
                new ValidateDataInput.DataProperty
                {
                    Name = "SupplierId",
                    Value = supplierId,
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
                var parameters = new List<Parameter>
                {
                    new Parameter
                    {
                        ParameterName = "@activeStatus",
                        ParameterValue = activeStatus
                    },
                    new Parameter
                    {
                        ParameterName = "@productCategoryId",
                        ParameterValue = productCategoryId
                    },
                    new Parameter
                    {
                        ParameterName = "@productName",
                        ParameterValue = productName
                    },
                    new Parameter
                    {
                        ParameterName = "@supplierId",
                        ParameterValue = supplierId
                    },
                    new Parameter
                    {
                        ParameterName = "@unitPrice",
                        ParameterValue = unitPrice
                    },
                    new Parameter
                    {
                        ParameterName = "@unitStockQuantityHeld",
                        ParameterValue = unitStockQuantityHeld
                    },
                    new Parameter
                    {
                        ParameterName = "@wholesalePricePerUnit",
                        ParameterValue = wholesalePricePerUnit
                    },
                    new Parameter
                    {
                        ParameterName = "@wholesaleReorderFlag",
                        ParameterValue = wholesaleReorderFlag
                    },
                    new Parameter
                    {
                        ParameterName = "@wholesaleUnitQuantityPerCarton",
                        ParameterValue = wholesaleUnitQuantityPerCarton
                    }
                };

                string storedProcedureName = "[dbo].[spCreateProduct]";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters.ToArray(), dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                this.Close();
            }
        }
    }
}