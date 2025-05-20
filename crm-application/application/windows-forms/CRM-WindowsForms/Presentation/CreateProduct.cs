using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class CreateProduct : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private byte[]? _productImageBytes = null;
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
                        DisplayText = row.Field<string>("VAT Number") != null
                            ? $"{row.Field<string>("Supplier Name")} | {row.Field<string>("VAT Number")}"
                            : row.Field<string>("Supplier Name")
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
            if (!string.IsNullOrWhiteSpace(createProductWholesaleCartonQuantityTextbox.Text) &&
                !string.IsNullOrWhiteSpace(createProductWholesaleUnitQuantityPerCartonTextbox.Text))
            {
                if (int.TryParse(createProductWholesaleCartonQuantityTextbox.Text, out int cartonQty) &&
                    int.TryParse(createProductWholesaleUnitQuantityPerCartonTextbox.Text, out int unitPerCarton))
                {
                    createProductUnitStockQuantityHeldTextbox.Text = (cartonQty * unitPerCarton).ToString();
                }
                else
                {
                    createProductUnitStockQuantityHeldTextbox.Text = string.Empty;
                }
            }
            else
            {
                createProductUnitStockQuantityHeldTextbox.Text = string.Empty;
            }
        }

        private void createProductChooseProductImageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    if (ValidateDataInput.IsValidImageFile(filePath, out string errorMessage))
                    {
                        createProductProductImagePictureBox.Image = Image.FromFile(filePath);
                        _productImageBytes = File.ReadAllBytes(filePath);
                    }
                    else
                    {
                        MessageBox.Show(errorMessage, "Invalid Image", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        createProductProductImagePictureBox.Image = null;
                        _productImageBytes = null;
                    }
                }
            }
        }

        private async void createProductSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createProductActiveStatusCheckbox.Checked;
            Guid productCategoryId = Guid.Parse(createProductProductCategoryComboBox.SelectedValue.ToString());
            byte[] productImage = _productImageBytes ?? Array.Empty<byte>();
            string productName = createProductProductNameTextbox.Text.TrimEnd();
            int unitMinimumOrderQuantity = int.Parse(createProductUnitMinimumOrderQuantityTextbox.Text.TrimEnd());
            int unitMinimumStockQuantity;
            if (int.TryParse(createProductUnitMinimumStockQuantityTextbox.Text.Trim(), out unitMinimumStockQuantity))
            {

            }
            else
            {
                unitMinimumStockQuantity = 0;
            }
            decimal unitPrice = decimal.Parse($"{createProductWholesalePricePerUnitTextboxA.Text.TrimEnd()}.{createProductWholesalePricePerUnitTextboxB.Text.TrimEnd()}");
            int unitStockQuantityHeld = int.Parse(createProductUnitStockQuantityHeldTextbox.Text.TrimEnd());
            decimal wholesalePricePerUnit = decimal.Parse($"{createProductWholesalePricePerUnitTextboxA.Text.TrimEnd()}.{createProductWholesalePricePerUnitTextboxB.Text.TrimEnd()}");
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
            int wholesaleCartonStockQuantityHeld = int.Parse(createProductWholesaleCartonQuantityTextbox.Text.TrimEnd());
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
                    AllowNullValue = false,
                    Name = "ActiveStatus",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductCategory",
                    Value = productCategoryId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductName",
                    Value = productName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "UnitMinimumOrderQuantity",
                    Value = unitMinimumOrderQuantity,
                    ValueType = typeof(int)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "UnitPrice",
                    Value = unitPrice,
                    ValueType = typeof(decimal)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "UnitStockQuantityHeld",
                    Value = unitStockQuantityHeld,
                    ValueType = typeof(int)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "WholesaleCartonStockQuantityHeld",
                    Value = wholesaleCartonStockQuantityHeld,
                    ValueType = typeof(int)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "WholesalePricePerUnit",
                    Value = wholesalePricePerUnit,
                    ValueType = typeof(decimal)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "WholesaleReorderFlag",
                    Value = wholesaleReorderFlag,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "WholesaleUnitQuantityPerCarton",
                    Value = wholesaleUnitQuantityPerCarton,
                    ValueType = typeof(int)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "SupplierId",
                    Value = supplierId,
                    ValueType = typeof(Guid)
                }
            };

            if (productImage != null && productImage.Length > 0)
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "ProductImage",
                    Value = productImage,
                    ValueType = typeof(byte[])
                });
            }

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
                        ParameterName = "@unitMinimumOrderQuantity",
                        ParameterValue = unitMinimumOrderQuantity
                    },
                    new Parameter
                    {
                        ParameterName = "@unitMinimumStockQuantity",
                        ParameterValue = unitMinimumStockQuantity
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
                        ParameterName = "@wholesaleCartonStockQuantityHeld",
                        ParameterValue = wholesaleCartonStockQuantityHeld
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

                if (productImage != null && productImage.Length > 0)
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@productImage",
                        ParameterValue = productImage
                    });
                }

                string storedProcedureName = "[dbo].[spCreateProduct]";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters.ToArray(), dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                this.Close();
            }
        }
    }
}