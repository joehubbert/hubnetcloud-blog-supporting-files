using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
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
            createProductTabControlProductDetailTabPageProductCategoryComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            createProductTabControlProductDetailTabPageSupplierComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            createProductTabControlProductDetailTabPageWholesaleGroupBoxWholesaleCartonQuantityTextbox.TextChanged += new EventHandler(CalculateUnitStockQuantityHeld);
            createProductTabControlProductDetailTabPageWholesaleGroupBoxWholesaleUnitQuantityPerCartonTextbox.TextChanged += new EventHandler(CalculateUnitStockQuantityHeld);
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

            string dataSubject = "Product Category";

            try
            {
                string storedProcedureName = "[dbo].[spGetAllProductCategory]";               
                DataTable? productCategoryData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var productCategoryList = productCategoryData.AsEnumerable()
                    .Select(row => new
                    {
                        ProductCategoryId = row.Field<Guid>("Product Category Id"),
                        ProductCategory = row.Field<string>("Product Category")
                    })
                    .OrderBy(item => item.ProductCategory)
                    .ToList();

                createProductTabControlProductDetailTabPageProductCategoryComboBox.DataSource = productCategoryList;
                createProductTabControlProductDetailTabPageProductCategoryComboBox.DisplayMember = "ProductCategory";
                createProductTabControlProductDetailTabPageProductCategoryComboBox.ValueMember = "ProductCategoryId";
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async Task CreateProductLoadSupplierDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Supplier";

            try
            {
                string storedProcedureName = "[dbo].[spGetAllSupplier]";           
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

                createProductTabControlProductDetailTabPageSupplierComboBox.DataSource = supplierList;
                createProductTabControlProductDetailTabPageSupplierComboBox.DisplayMember = "DisplayText";
                createProductTabControlProductDetailTabPageSupplierComboBox.ValueMember = "SupplierId";
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private void CalculateUnitStockQuantityHeld(object? sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageWholesaleGroupBoxWholesaleCartonQuantityTextbox.Text) &&
                !string.IsNullOrWhiteSpace(createProductTabControlProductDetailTabPageWholesaleGroupBoxWholesaleUnitQuantityPerCartonTextbox.Text))
            {
                if (int.TryParse(createProductTabControlProductDetailTabPageWholesaleGroupBoxWholesaleCartonQuantityTextbox.Text, out int cartonQty) &&
                    int.TryParse(createProductTabControlProductDetailTabPageWholesaleGroupBoxWholesaleUnitQuantityPerCartonTextbox.Text, out int unitPerCarton))
                {
                    createProductTabControlProductDetailTabPagePerUnitGroupBoxUnitStockQuantityHeldTextbox.Text = (cartonQty * unitPerCarton).ToString();
                }
                else
                {
                    createProductTabControlProductDetailTabPagePerUnitGroupBoxUnitStockQuantityHeldTextbox.Text = string.Empty;
                }
            }
            else
            {
                createProductTabControlProductDetailTabPagePerUnitGroupBoxUnitStockQuantityHeldTextbox.Text = string.Empty;
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

                    if (ValidateDataInput.IsValidImageFile(filePath, 1000, 1000, out string errorMessage))
                    {
                        createProductTabControlProductImageTabPageProductImagePictureBox.Image = Image.FromFile(filePath);
                        _productImageBytes = File.ReadAllBytes(filePath);
                    }
                    else
                    {
                        ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Warning.Data.Validation.DataType", "Image");
                        createProductTabControlProductImageTabPageProductImagePictureBox.Image = null;
                        _productImageBytes = null;
                    }
                }
            }
        }

        private void createProductRemoveProductImageButton_Click(object sender, EventArgs e)
        {
            createProductTabControlProductImageTabPageProductImagePictureBox.Image = null;
            _productImageBytes = null;
        }

        private async void createProductSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createProductTabControlProductDetailTabPageActiveStatusCheckbox.Checked;
            Guid productCategoryId = Guid.Parse(createProductTabControlProductDetailTabPageProductCategoryComboBox.SelectedValue.ToString());
            byte[] productImage = _productImageBytes ?? Array.Empty<byte>();
            string productName = createProductTabControlProductDetailTabPageProductNameTextbox.Text.TrimEnd();
            int unitMinimumOrderQuantity = int.Parse(createProductTabControlProductDetailTabPagePerUnitGroupBoxUnitMinimumOrderQuantityTextbox.Text.TrimEnd());
            int unitMinimumStockQuantity;
            if (int.TryParse(createProductTabControlProductDetailTabPagePerUnitGroupBoxUnitMinimumStockQuantityTextbox.Text.Trim(), out unitMinimumStockQuantity))
            {

            }
            else
            {
                unitMinimumStockQuantity = 0;
            }
            decimal unitPrice = decimal.Parse($"{createProductTabControlProductDetailTabPageWholesaleGroupBoxWholesalePricePerUnitTextboxA.Text.TrimEnd()}.{createProductTabControlProductDetailTabPageWholesaleGroupBoxWholesalePricePerUnitTextboxB.Text.TrimEnd()}");
            int unitStockQuantityHeld = int.Parse(createProductTabControlProductDetailTabPagePerUnitGroupBoxUnitStockQuantityHeldTextbox.Text.TrimEnd());
            decimal wholesalePricePerUnit = decimal.Parse($"{createProductTabControlProductDetailTabPageWholesaleGroupBoxWholesalePricePerUnitTextboxA.Text.TrimEnd()}.{createProductTabControlProductDetailTabPageWholesaleGroupBoxWholesalePricePerUnitTextboxB.Text.TrimEnd()}");
            bool wholesaleReorderFlag;
            if (createProductTabControlProductDetailTabPageWholesaleGroupBoxWholesaleReorderFlagPanelYesRadioButton.Checked)
            {
                wholesaleReorderFlag = true;
            }
            else
            {
                wholesaleReorderFlag = false;
            }
            int wholesaleUnitQuantityPerCarton = int.Parse(createProductTabControlProductDetailTabPageWholesaleGroupBoxWholesaleUnitQuantityPerCartonTextbox.Text.TrimEnd());
            int wholesaleCartonStockQuantityHeld = int.Parse(createProductTabControlProductDetailTabPageWholesaleGroupBoxWholesaleCartonQuantityTextbox.Text.TrimEnd());
            Guid supplierId = Guid.Parse(createProductTabControlProductDetailTabPageSupplierComboBox.SelectedValue.ToString());

            string dataSubject = "Product";

            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Database.ConnectionSettingsNotLoaded");
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