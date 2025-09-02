using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class ProductDetail : Form
    {
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DataGridViewQuickSearchHelper? _dataGridViewQuickSearchHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _productId;
        private bool? productDetailTabControlOverviewTabPageActiveStatusOriginalValue;
        private Guid? productDetailTabControlOverviewTabPageProductCategoryIdOriginalValue;
        private string? productDetailTabControlOverviewTabPageProductNameOriginalValue;
        private Guid? productDetailTabControlOverviewTabPageSupplierIdOriginalValue;
        private int? productDetailTabControlOverviewTabPageUnitMinimumOrderQuantityOriginalValue;
        private int? productDetailTabControlOverviewTabPageUnitMinimumStockQuantityOriginalValue;
        private decimal? productDetailTabControlOverviewTabPageUnitPriceOriginalValue;
        private int? productDetailTabControlOverviewTabPageUnitStockQuantityHeldOriginalValue;
        private int? productDetailTabControlOverviewTabPageWholesaleCartonStockQuantityHeldOriginalValue;
        private decimal? productDetailTabControlOverviewTabPageWholesalePricePerUnitOriginalValue;
        private bool? productDetailTabControlOverviewTabPageWholesaleReorderFlagOriginalValue;
        private int? productDetailTabControlOverviewTabPageWholesaleUnitQuantityPerCartonOriginalValue;
        private byte[]? productDetailProductImageOriginalValue;
        private byte[]? productDetailProductImageRuntimeValue;

        public ProductDetail(Guid productId)
        {
            InitializeComponent();
            InitializeEventHandlers();
            LoadDatabaseConnectionSettingsAsync();
            _productId = productId;
        }

        private void InitializeEventHandlers()
        {
            productDetailTabControl.SelectedIndexChanged += ProductDetailTabControl_SelectedIndexChanged;
            productDetailTabControlProductNoteTabPageDataGridView.CellContentClick += productDetailTabControlProductNoteTabPageDataGridView_CellContentClick;
            productDetailToggleEditModeButton.Click += productDetailToggleEditModeButton_Click;
            _dataGridViewQuickSearchHelper = new DataGridViewQuickSearchHelper(productDetailTabControlProductNoteTabPageQuickFilterTextBox, productDetailTabControlProductNoteTabPageDataGridView);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task ProductDetailOverviewLoadProductCategoryDataAsync(Guid productCategoryId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Product Category";

            try
            {
                string storedProcedureName = "spGetAllProductCategory";               
                DataTable? productCategoryData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject);

                var productCategoryList = productCategoryData.AsEnumerable()
                    .Select(row => new
                    {
                        ProductCategoryId = row.Field<Guid>("Product Category Id"),
                        ProductCategory = row.Field<string>("Product Category")
                    })
                    .OrderBy(item => item.ProductCategory)
                    .ToList();

                productDetailTabControlOverviewTabPageProductCategoryComboBox.DataSource = productCategoryList;
                productDetailTabControlOverviewTabPageProductCategoryComboBox.DisplayMember = "ProductCategory";
                productDetailTabControlOverviewTabPageProductCategoryComboBox.ValueMember = "ProductCategoryId";
                productDetailTabControlOverviewTabPageProductCategoryComboBox.SelectedValue = productCategoryId;
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async Task ProductDetailOverviewLoadSupplierDataAsync(Guid productSupplierId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Supplier";

            try
            {
                string storedProcedureName = "spGetAllSupplier";               
                DataTable? supplierData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject);

                var supplierList = supplierData.AsEnumerable()
                    .Select(row => new
                    {
                        SupplierId = row.Field<Guid>("Supplier Id"),
                        Supplier = row.Field<string>("Supplier Name"),
                        DisplayText = row.Field<string>("VAT Number") != null
                            ? $"{row.Field<string>("Supplier Name")} | {row.Field<string>("VAT Number")}"
                            : row.Field<string>("Supplier Name")
                    })
                    .OrderBy(item => item.Supplier)
                    .ToList();

                productDetailTabControlOverviewTabPageSupplierComboBox.DataSource = supplierList;
                productDetailTabControlOverviewTabPageSupplierComboBox.DisplayMember = "DisplayText";
                productDetailTabControlOverviewTabPageSupplierComboBox.ValueMember = "SupplierId";
                productDetailTabControlOverviewTabPageSupplierComboBox.SelectedValue = productSupplierId;
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async void ProductDetailProductInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            string storedProcedureName = "spGetProduct";
            string dataSubject = "Product";

            var parameters = new[]
            {
                new StoredProcedureParameter
                {
                    ParameterName = "productId",
                    ParameterValue = _productId
                }
            };
            try
            {
                DataTable? productDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject);

                if (productDataTable != null)
                {
                    DataRow productDataRow = productDataTable.Rows[0];

                    productDetailTabControlOverviewTabPageActiveStatusCheckBox.Checked = (bool)productDataRow["Active Status"];
                    productDetailTabControlOverviewTabPageCreatedByTextBox.Text = productDataRow["Created By"].ToString();
                    productDetailTabControlOverviewTabPageCreatedTimestampTextBox.Text = productDataRow["Created Timestamp UTC"].ToString();
                    productDetailTabControlOverviewTabPageLastUpdatedByTextBox.Text = productDataRow["Modified By"].ToString();
                    productDetailTabControlOverviewTabPageLastUpdatedTimestampTextBox.Text = productDataRow["Modified Timestamp UTC"].ToString();
                    Guid productCategoryId = (Guid)productDataRow["Product Category Id"];
                    await ProductDetailOverviewLoadProductCategoryDataAsync(productCategoryId);
                    productDetailTabControlOverviewTabPageProductIdTextBox.Text = productDataRow["Product Id"].ToString();
                    productDetailTabControlOverviewTabPageProductNameTextBox.Text = productDataRow["Product Name"].ToString();
                    Guid productSupplierId = (Guid)productDataRow["Supplier Id"];
                    await ProductDetailOverviewLoadSupplierDataAsync(productSupplierId);
                    productDetailTabControlOverviewTabPageUnitMinimumOrderQuantityTextBox.Text = productDataRow["Unit Minimum Order Quantity"].ToString();
                    productDetailTabControlOverviewTabPageUnitMinimumStockQuantityTextBox.Text = productDataRow["Unit Minimum Stock Quantity"].ToString();
                    string unitPricePartA;
                    string unitPricePartB;
                    SplitDecimalHelper.SplitDecimalUsingDelimiter((decimal)productDataRow["Unit Selling Price"], out unitPricePartA, out unitPricePartB);
                    productDetailTabControlOverviewTabPageUnitPriceTextBoxA.Text = unitPricePartA;
                    productDetailTabControlOverviewTabPageUnitPriceTextBoxB.Text = unitPricePartB;
                    productDetailTabControlOverviewTabPageUnitStockQuantityHeldTextBox.Text = productDataRow["Unit Stock Quantity Held"].ToString();
                    productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleCartonQuantityTextBox.Text = productDataRow["Wholesale Carton Stock Quantity Held"].ToString();
                    string wholesalePricePerUnitPartA;
                    string wholesalePricePerUnitPartB;
                    SplitDecimalHelper.SplitDecimalUsingDelimiter((decimal)productDataRow["Wholesale Price Per Unit"], out wholesalePricePerUnitPartA, out wholesalePricePerUnitPartB);
                    productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesalePricePerUnitTextBoxA.Text = wholesalePricePerUnitPartA;
                    productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesalePricePerUnitTextBoxB.Text = wholesalePricePerUnitPartB;
                    productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleUnitQuantityPerCartonTextBox.Text = productDataRow["Wholesale Unit Quantity Per Carton"].ToString();
                    if ((bool)productDataRow["Wholesale Reorder Flag"])
                    {
                        productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleReorderFlagPanelYesRadioButton.Checked = true;
                    }
                    else
                    {
                        productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleReorderFlagPanelNoRadioButton.Checked = true;
                    }
                    if (productDataRow["Product Image"] != DBNull.Value)
                    {
                        productDetailTabControlProductImageTabPageProductImagePictureBox.Image = ImageHelper.ByteArrayToImage((byte[])productDataRow["Product Image"]);
                    }
                    else
                    {
                        productDetailTabControlProductImageTabPageProductImagePictureBox.Image = null;
                    }

                    productDetailTabControlOverviewTabPageActiveStatusOriginalValue = (bool)productDataRow["Active Status"];
                    productDetailTabControlOverviewTabPageProductCategoryIdOriginalValue = (Guid)productDataRow["Product Category Id"];
                    productDetailTabControlOverviewTabPageProductNameOriginalValue = productDataRow["Product Name"].ToString();
                    productDetailTabControlOverviewTabPageSupplierIdOriginalValue = (Guid)productDataRow["Supplier Id"];
                    productDetailTabControlOverviewTabPageUnitMinimumOrderQuantityOriginalValue = (int)productDataRow["Unit Minimum Order Quantity"];
                    productDetailTabControlOverviewTabPageUnitMinimumStockQuantityOriginalValue = (int)productDataRow["Unit Minimum Stock Quantity"];
                    productDetailTabControlOverviewTabPageUnitPriceOriginalValue = (decimal)productDataRow["Unit Selling Price"];
                    productDetailTabControlOverviewTabPageUnitStockQuantityHeldOriginalValue = (int)productDataRow["Unit Stock Quantity Held"];
                    productDetailTabControlOverviewTabPageWholesaleCartonStockQuantityHeldOriginalValue = (int)productDataRow["Wholesale Carton Stock Quantity Held"];
                    productDetailTabControlOverviewTabPageWholesalePricePerUnitOriginalValue = (decimal)productDataRow["Wholesale Price Per Unit"];
                    productDetailTabControlOverviewTabPageWholesaleUnitQuantityPerCartonOriginalValue = (int)productDataRow["Wholesale Unit Quantity Per Carton"];
                    productDetailTabControlOverviewTabPageWholesaleReorderFlagOriginalValue = (bool)productDataRow["Wholesale Reorder Flag"];
                    productDetailProductImageOriginalValue = productDataRow["Product Image"] as byte[];

                    this.Text += $" ({productDetailTabControlOverviewTabPageProductNameOriginalValue})";
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.NoDataFound", dataSubject);
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async void ProductDetailTabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (productDetailTabControl.SelectedTab == productDetailTabControl.TabPages["productDetailTabControlProductNotesPage"])
            {
                await ProductDetailExistingProductNote_Load(sender, e);
            }
        }

        private async Task ProductDetailExistingProductNote_Load(object sender, EventArgs e)
        {
            await DataAccessDataGridViewHelper.LoadDataGridViewAsync(
                _databaseConnectionSettings,
                _productId,
                "productId",
                "spGetAllNoteForProduct",
                "Existing Product Notes",
                productDetailTabControlProductNoteTabPageDataGridView,
                "Product Note Id",
                "View Product Note",
                "DESC",
                "Created Timestamp UTC"
            );
        }

        private void productDetailTabControlProductNoteTabPageDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            DataAccessDataGridViewHelper.HandleDetailsCellClick(
            productDetailTabControlProductNoteTabPageDataGridView,
            e,
            "Product Note Id",
            "Product Note",
            id => {
                var noteDetail = new NoteDetail(_productId, "Product", id, productDetailTabControlOverviewTabPageProductNameOriginalValue);
                noteDetail.Show();
            });
        }

        private void CalulateUnitStockQuantityHeld(object? sender, EventArgs e)
        {
            productDetailTabControlOverviewTabPageUnitStockQuantityHeldTextBox.Text = (int.Parse(productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleCartonQuantityTextBox.Text.TrimEnd()) * int.Parse(productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleUnitQuantityPerCartonTextBox.Text.TrimEnd())).ToString();
        }

        private void productDetailProductImageChooseProductImageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    if (ValidateDataInputService.IsValidImageFile(filePath, 1000, 1000, out string errorMessage))
                    {
                        productDetailTabControlProductImageTabPageProductImagePictureBox.Image = Image.FromFile(filePath);
                        productDetailProductImageRuntimeValue = File.ReadAllBytes(filePath);
                    }
                    else
                    {
                        ErrorMessageService errorMessageService = new ErrorMessageService("Warning.Data.Validation.DataType", "Image");
                        productDetailTabControlProductImageTabPageProductImagePictureBox.Image = null;
                        productDetailProductImageRuntimeValue = null;
                    }
                }
            }
        }

        private void productDetailProductImageRemoveProductImageButton_Click(object sender, EventArgs e)
        {
            productDetailTabControlProductImageTabPageProductImagePictureBox.Image = null;
            productDetailProductImageRuntimeValue = null;
        }

        private async void productDetailUpdateProductButton_Click(object sender, EventArgs e)
        {
            bool productDetailTabControlOverviewTabPageActiveStatus = productDetailTabControlOverviewTabPageActiveStatusCheckBox.Checked;
            Guid productDetailTabControlOverviewTabPageProductCategoryId = (Guid)productDetailTabControlOverviewTabPageProductCategoryComboBox.SelectedValue;
            string productDetailTabControlOverviewTabPageProductName = productDetailTabControlOverviewTabPageProductNameTextBox.Text.TrimEnd();
            Guid productDetailTabControlOverviewTabPageSupplierId = (Guid)productDetailTabControlOverviewTabPageSupplierComboBox.SelectedValue;
            int productDetailTabControlOverviewTabPageUnitMinimumOrderQuantity = int.Parse(productDetailTabControlOverviewTabPageUnitMinimumOrderQuantityTextBox.Text.TrimEnd());
            int productDetailTabControlOverviewTabPageUnitMinimumStockQuantity;
            if (productDetailTabControlOverviewTabPageUnitMinimumStockQuantityTextBox.Text.TrimEnd() == string.Empty)
            {
                productDetailTabControlOverviewTabPageUnitMinimumStockQuantity = 0;
            }
            else
            {
                productDetailTabControlOverviewTabPageUnitMinimumStockQuantity = int.Parse(productDetailTabControlOverviewTabPageUnitMinimumStockQuantityTextBox.Text.TrimEnd());
            }
            decimal productDetailTabControlOverviewTabPageUnitPrice = decimal.Parse($"{productDetailTabControlOverviewTabPageUnitPriceTextBoxA.Text.TrimEnd()}.{productDetailTabControlOverviewTabPageUnitPriceTextBoxB.Text.TrimEnd()}");
            int productDetailTabControlOverviewTabPageWholesaleCartonStockQuantityHeld = int.Parse(productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleCartonQuantityTextBox.Text.TrimEnd());
            decimal productDetailTabControlOverviewTabPageWholesalePricePerUnit = decimal.Parse($"{productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesalePricePerUnitTextBoxA.Text.TrimEnd()}.{productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesalePricePerUnitTextBoxB.Text.TrimEnd()}");
            int productDetailTabControlOverviewTabPageWholesaleUnitQuantityPerCarton = int.Parse(productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleUnitQuantityPerCartonTextBox.Text.TrimEnd());
            bool productDetailTabControlOverviewTabPageWholesaleReorderFlag;
            if (productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleReorderFlagPanelYesRadioButton.Checked)
            {
                productDetailTabControlOverviewTabPageWholesaleReorderFlag = true;
            }
            else
            {
                productDetailTabControlOverviewTabPageWholesaleReorderFlag = false;
            }
            byte[] productImage = productDetailProductImageRuntimeValue ?? Array.Empty<byte>();
            int productDetailTabControlOverviewTabPageUnitStockQuantityHeld = (productDetailTabControlOverviewTabPageWholesaleCartonStockQuantityHeld * productDetailTabControlOverviewTabPageWholesaleUnitQuantityPerCarton);

            string dataSubject = "Product";

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
                    Name = "ProductDetailOverviewActiveStatus",
                    Value = productDetailTabControlOverviewTabPageActiveStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewProductCategoryId",
                    Value = productDetailTabControlOverviewTabPageProductCategoryId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewProductName",
                    Value = productDetailTabControlOverviewTabPageProductName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewSupplierId",
                    Value = productDetailTabControlOverviewTabPageSupplierId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewUnitMinimumOrderQuantity",
                    Value = productDetailTabControlOverviewTabPageUnitMinimumOrderQuantity,
                    ValueType = typeof(int)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewUnitMinimumStockQuantity",
                    Value = productDetailTabControlOverviewTabPageUnitMinimumStockQuantity,
                    ValueType = typeof(int)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewUnitPrice",
                    Value = productDetailTabControlOverviewTabPageUnitPrice,
                    ValueType = typeof(decimal)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewWholesaleCartonStockQuantityHeld",
                    Value = productDetailTabControlOverviewTabPageWholesaleCartonStockQuantityHeld,
                    ValueType = typeof(int)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewWholesaleCartonStockQuantityHeld",
                    Value = productDetailTabControlOverviewTabPageWholesaleCartonStockQuantityHeld,
                    ValueType = typeof(int)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewWholesalePricePerUnit",
                    Value = productDetailTabControlOverviewTabPageWholesalePricePerUnit,
                    ValueType = typeof(decimal)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewWholesaleUnitQuantityPerCarton",
                    Value = productDetailTabControlOverviewTabPageWholesaleUnitQuantityPerCarton,
                    ValueType = typeof(int)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewWholesaleReorderFlag",
                    Value = productDetailTabControlOverviewTabPageWholesaleReorderFlag,
                    ValueType = typeof(bool)
                }
            };

            if (productImage != null && productImage.Length > 0)
            {
                dataToValidate.Add(new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "ProductImage",
                    Value = productImage,
                    ValueType = typeof(byte[])
                });
            }

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
                        VariableName = "Product Detail Overview: Active Status",
                        VariableType = "bool",
                        OriginalValue = productDetailTabControlOverviewTabPageActiveStatusOriginalValue,
                        NewValue = productDetailTabControlOverviewTabPageActiveStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Detail Overview: Product Category Id",
                        VariableType = "Guid",
                        OriginalValue = productDetailTabControlOverviewTabPageProductCategoryIdOriginalValue,
                        NewValue = productDetailTabControlOverviewTabPageProductCategoryId
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Detail Product Image: Product Image",
                        VariableType = "byte",
                        OriginalValue = productDetailProductImageOriginalValue,
                        NewValue = productDetailProductImageRuntimeValue
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Detail Overview: Product Name",
                        VariableType = "string",
                        OriginalValue = productDetailTabControlOverviewTabPageProductNameOriginalValue,
                        NewValue = productDetailTabControlOverviewTabPageProductName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Detail Overview: Supplier Id",
                        VariableType = "Guid",
                        OriginalValue = productDetailTabControlOverviewTabPageSupplierIdOriginalValue,
                        NewValue = productDetailTabControlOverviewTabPageSupplierId
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Detail Overview: Unit Minimum Order Quantity",
                        VariableType = "int",
                        OriginalValue = productDetailTabControlOverviewTabPageUnitMinimumOrderQuantityOriginalValue,
                        NewValue = productDetailTabControlOverviewTabPageUnitMinimumOrderQuantity
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Detail Overview: Unit Minimum Stock Quantity",
                        VariableType = "int",
                        OriginalValue = productDetailTabControlOverviewTabPageUnitMinimumStockQuantityOriginalValue,
                        NewValue = productDetailTabControlOverviewTabPageUnitMinimumStockQuantity
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Detail Overview: Unit Price",
                        VariableType = "string",
                        OriginalValue = productDetailTabControlOverviewTabPageUnitPriceOriginalValue,
                        NewValue = productDetailTabControlOverviewTabPageUnitPrice
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Detail Overview: Unit Stock Quantity Held",
                        VariableType = "string",
                        OriginalValue = productDetailTabControlOverviewTabPageUnitStockQuantityHeldOriginalValue,
                        NewValue = productDetailTabControlOverviewTabPageUnitStockQuantityHeld
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Detail Overview: Wholesale Carton Stock Quantity Held",
                        VariableType = "int",
                        OriginalValue = productDetailTabControlOverviewTabPageWholesaleCartonStockQuantityHeldOriginalValue,
                        NewValue = productDetailTabControlOverviewTabPageWholesaleCartonStockQuantityHeld
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Detail Overview: Wholesale Price Per Unit",
                        VariableType = "decimal",
                        OriginalValue = productDetailTabControlOverviewTabPageWholesalePricePerUnitOriginalValue,
                        NewValue = productDetailTabControlOverviewTabPageWholesalePricePerUnit
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Detail Overview: Wholesale Unit Quantity Per Carton",
                        VariableType = "int",
                        OriginalValue = productDetailTabControlOverviewTabPageWholesaleUnitQuantityPerCartonOriginalValue,
                        NewValue = productDetailTabControlOverviewTabPageWholesaleUnitQuantityPerCarton
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Detail Overview: Wholesale Reorder Flag",
                        VariableType = "bool",
                        OriginalValue = productDetailTabControlOverviewTabPageWholesaleReorderFlagOriginalValue,
                        NewValue = productDetailTabControlOverviewTabPageWholesaleReorderFlag
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = UpdateConfirmationService.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
                {
                    var parameters = new List<StoredProcedureParameter>
                    {
                        new StoredProcedureParameter
                        {
                            ParameterName = "activeStatus",
                            ParameterValue = productDetailTabControlOverviewTabPageActiveStatus
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "productCategoryId",
                            ParameterValue = productDetailTabControlOverviewTabPageProductCategoryId
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "productId",
                            ParameterValue = _productId
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "productName",
                            ParameterValue = productDetailTabControlOverviewTabPageProductName
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "supplierId",
                            ParameterValue = productDetailTabControlOverviewTabPageSupplierId
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "unitMinimumOrderQuantity",
                            ParameterValue = productDetailTabControlOverviewTabPageUnitMinimumOrderQuantity
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "unitMinimumStockQuantity",
                            ParameterValue = productDetailTabControlOverviewTabPageUnitMinimumStockQuantity
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "unitPrice",
                            ParameterValue = productDetailTabControlOverviewTabPageUnitPrice
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "unitStockQuantityHeld",
                            ParameterValue = productDetailTabControlOverviewTabPageUnitStockQuantityHeld
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "wholesaleCartonStockQuantityHeld",
                            ParameterValue = productDetailTabControlOverviewTabPageWholesaleCartonStockQuantityHeld
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "wholesalePricePerUnit",
                            ParameterValue = productDetailTabControlOverviewTabPageWholesalePricePerUnit
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "wholesaleReorderFlag",
                            ParameterValue = productDetailTabControlOverviewTabPageWholesaleReorderFlag
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = "wholesaleUnitQuantityPerCarton",
                            ParameterValue = productDetailTabControlOverviewTabPageWholesaleUnitQuantityPerCarton
                        }
                    };

                    if (productImage != null && productImage.Length > 0)
                    {
                        parameters.Add(new StoredProcedureParameter
                        {
                            ParameterName = "productImage",
                            ParameterValue = productImage
                        });
                    }

                    string storedProcedureName = "spUpdateProduct";
                    string operationType = "update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters.ToArray(), dataSubject, operationType);
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
            ProductDetailProductInformation_Load(this, EventArgs.Empty);
        }

        private void productDetailToggleEditModeButton_Click(object sender, EventArgs e)
        {
            productDetailTabControlOverviewTabPageActiveStatusCheckBox.Enabled = !productDetailTabControlOverviewTabPageActiveStatusCheckBox.Enabled;
            productDetailTabControlOverviewTabPageProductCategoryComboBox.Enabled = !productDetailTabControlOverviewTabPageProductCategoryComboBox.Enabled;
            productDetailTabControlOverviewTabPageProductNameTextBox.ReadOnly = !productDetailTabControlOverviewTabPageProductNameTextBox.ReadOnly;
            productDetailTabControlOverviewTabPageSupplierComboBox.Enabled = !productDetailTabControlOverviewTabPageSupplierComboBox.Enabled;
            productDetailTabControlOverviewTabPageUnitMinimumOrderQuantityTextBox.ReadOnly = !productDetailTabControlOverviewTabPageUnitMinimumOrderQuantityTextBox.ReadOnly;
            productDetailTabControlOverviewTabPageUnitMinimumStockQuantityTextBox.ReadOnly = !productDetailTabControlOverviewTabPageUnitMinimumStockQuantityTextBox.ReadOnly;
            productDetailTabControlOverviewTabPageUnitPriceTextBoxA.ReadOnly = !productDetailTabControlOverviewTabPageUnitPriceTextBoxA.ReadOnly;
            productDetailTabControlOverviewTabPageUnitPriceTextBoxB.ReadOnly = !productDetailTabControlOverviewTabPageUnitPriceTextBoxB.ReadOnly;
            productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleCartonQuantityTextBox.ReadOnly = !productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleCartonQuantityTextBox.ReadOnly;
            productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesalePricePerUnitTextBoxA.ReadOnly = !productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesalePricePerUnitTextBoxA.ReadOnly;
            productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesalePricePerUnitTextBoxB.ReadOnly = !productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesalePricePerUnitTextBoxB.ReadOnly;
            productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleReorderFlagPanelYesRadioButton.Enabled = !productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleReorderFlagPanelYesRadioButton.Enabled;
            productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleReorderFlagPanelNoRadioButton.Enabled = !productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleReorderFlagPanelNoRadioButton.Enabled;
            productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleUnitQuantityPerCartonTextBox.ReadOnly = !productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleUnitQuantityPerCartonTextBox.ReadOnly;
            productDetailTabControlProductImageTabPageChooseProductImageButton.Enabled = !productDetailTabControlProductImageTabPageChooseProductImageButton.Enabled;
            productDetailUpdateProductButton.Enabled = !productDetailUpdateProductButton.Enabled;
        }

        private void productDetailProductNotesCreateNewProductNoteButton_Click(object sender, EventArgs e)
        {
            CreateNote createNote = new CreateNote(_productId, "ProductNote", productDetailTabControlOverviewTabPageProductNameOriginalValue);
            createNote.Show();
        }

        private async void productDetailProductNotesRefreshDataButton_Click(object sender, EventArgs e)
        {
            await ProductDetailExistingProductNote_Load(sender, e);
        }
    }
}