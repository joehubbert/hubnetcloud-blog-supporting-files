using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class ProductDetail : Form
    {
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
            InitializeCustomComponents();
            LoadDatabaseConnectionSettingsAsync();
            _productId = productId;
        }

        private void InitializeCustomComponents()
        {
            productDetailTabControl.SelectedIndexChanged += new EventHandler(ProductDetailTabControl_SelectedIndexChanged);
            productDetailTabControlProductNoteTabPageDataGridView.CellContentClick += ProductDetailProductNotesExistingProductNotesDataGridView_CellContentClick;
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
                string storedProcedureName = "[dbo].[spGetAllSupplier]";               
                DataTable? supplierData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

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
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.ConnectionSettingsNotLoaded");
                return;
            }

            string storedProcedureName = "[dbo].[spGetProduct]";
            string dataSubject = "Product";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@productId",
                    ParameterValue = _productId
                }
            };
            try
            {
                DataTable? productDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (productDataTable != null)
                {
                    DataRow productDataRow = productDataTable.Rows[0];

                    productDetailTabControlOverviewTabPageActiveStatusCheckbox.Checked = (bool)productDataRow["Active Status"];
                    productDetailTabControlOverviewTabPageCreatedByTextbox.Text = productDataRow["Created By"].ToString();
                    productDetailTabControlOverviewTabPageCreatedTimestampTextbox.Text = productDataRow["Created Timestamp UTC"].ToString();
                    productDetailTabControlOverviewTabPageLastUpdatedByTextbox.Text = productDataRow["Modified By"].ToString();
                    productDetailTabControlOverviewTabPageLastUpdatedTimestampTextbox.Text = productDataRow["Modified Timestamp UTC"].ToString();
                    Guid productCategoryId = (Guid)productDataRow["Product Category Id"];
                    await ProductDetailOverviewLoadProductCategoryDataAsync(productCategoryId);
                    productDetailTabControlOverviewTabPageProductIdTextbox.Text = productDataRow["Product Id"].ToString();
                    productDetailTabControlOverviewTabPageProductNameTextbox.Text = productDataRow["Product Name"].ToString();
                    Guid productSupplierId = (Guid)productDataRow["Supplier Id"];
                    await ProductDetailOverviewLoadSupplierDataAsync(productSupplierId);
                    productDetailTabControlOverviewTabPageUnitMinimumOrderQuantityTextbox.Text = productDataRow["Unit Minimum Order Quantity"].ToString();
                    productDetailTabControlOverviewTabPageUnitMinimumStockQuantityTextbox.Text = productDataRow["Unit Minimum Stock Quantity"].ToString();
                    string unitPricePartA;
                    string unitPricePartB;
                    SplitDecimal.SplitDecimalUsingDelimiter((decimal)productDataRow["Unit Selling Price"], out unitPricePartA, out unitPricePartB);
                    productDetailTabControlOverviewTabPageUnitPriceTextboxA.Text = unitPricePartA;
                    productDetailTabControlOverviewTabPageUnitPriceTextboxB.Text = unitPricePartB;
                    productDetailTabControlOverviewTabPageUnitStockQuantityHeldTextbox.Text = productDataRow["Unit Stock Quantity Held"].ToString();
                    productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleCartonQuantityTextbox.Text = productDataRow["Wholesale Carton Stock Quantity Held"].ToString();
                    string wholesalePricePerUnitPartA;
                    string wholesalePricePerUnitPartB;
                    SplitDecimal.SplitDecimalUsingDelimiter((decimal)productDataRow["Wholesale Price Per Unit"], out wholesalePricePerUnitPartA, out wholesalePricePerUnitPartB);
                    productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesalePricePerUnitTextboxA.Text = wholesalePricePerUnitPartA;
                    productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesalePricePerUnitTextboxB.Text = wholesalePricePerUnitPartB;
                    productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleUnitQuantityPerCartonTextbox.Text = productDataRow["Wholesale Unit Quantity Per Carton"].ToString();
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
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.ConnectionSettingsNotLoaded");
                return;
            }

            string storedProcedureName = "[dbo].[spGetAllNoteForProduct]";
            string dataSubject = "Existing Product Notes";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@productId",
                    ParameterValue = _productId
                }
            };

            DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

            if (dataTable.Rows.Count == 0)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Information.NoDataFound", dataSubject);
            }
            else
            {
                dataTable.DefaultView.Sort = "Created Timestamp DESC";
                productDetailTabControlProductNoteTabPageDataGridView.AutoGenerateColumns = true;
                productDetailTabControlProductNoteTabPageDataGridView.DataSource = dataTable;
                productDetailTabControlProductNoteTabPageDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if (productDetailTabControlProductNoteTabPageDataGridView.Columns.Contains("Details"))
                {
                    productDetailTabControlProductNoteTabPageDataGridView.Columns.Remove("Details");
                }
                DataGridViewLinkColumn productNoteDetailLink = new DataGridViewLinkColumn
                {
                    HeaderText = "Details",
                    Text = "View Product Note",
                    UseColumnTextForLinkValue = true,
                    Name = "Details"
                };
                productDetailTabControlProductNoteTabPageDataGridView.Columns.Add(productNoteDetailLink);
            }
        }

        private void ProductDetailProductNotesExistingProductNotesDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == productDetailTabControlProductNoteTabPageDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                string dataSubject = "Product Note";

                try
                {
                    if (productDetailTabControlProductNoteTabPageDataGridView.Columns.Contains("Product Note Id"))
                    {
                        Guid productNoteId = (Guid)productDetailTabControlProductNoteTabPageDataGridView.Rows[e.RowIndex].Cells["Product Note Id"].Value;
                        NoteDetail noteDetail = new NoteDetail("Product", productNoteId);
                        noteDetail.Show();
                    }
                    else
                    {
                        ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.IdColumnNotFound", dataSubject);
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
                }
            }
        }

        private void CalulateUnitStockQuantityHeld(object? sender, EventArgs e)
        {
            productDetailTabControlOverviewTabPageUnitStockQuantityHeldTextbox.Text = (int.Parse(productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleCartonQuantityTextbox.Text.TrimEnd()) * int.Parse(productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleUnitQuantityPerCartonTextbox.Text.TrimEnd())).ToString();
        }

        private void productDetailProductImageChooseProductImageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    if (ValidateDataInput.IsValidImageFile(filePath, 1000, 1000, out string errorMessage))
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
            bool productDetailTabControlOverviewTabPageActiveStatus = productDetailTabControlOverviewTabPageActiveStatusCheckbox.Checked;
            Guid productDetailTabControlOverviewTabPageProductCategoryId = (Guid)productDetailTabControlOverviewTabPageProductCategoryComboBox.SelectedValue;
            string productDetailTabControlOverviewTabPageProductName = productDetailTabControlOverviewTabPageProductNameTextbox.Text.TrimEnd();
            Guid productDetailTabControlOverviewTabPageSupplierId = (Guid)productDetailTabControlOverviewTabPageSupplierComboBox.SelectedValue;
            int productDetailTabControlOverviewTabPageUnitMinimumOrderQuantity = int.Parse(productDetailTabControlOverviewTabPageUnitMinimumOrderQuantityTextbox.Text.TrimEnd());
            int productDetailTabControlOverviewTabPageUnitMinimumStockQuantity;
            if (productDetailTabControlOverviewTabPageUnitMinimumStockQuantityTextbox.Text.TrimEnd() == string.Empty)
            {
                productDetailTabControlOverviewTabPageUnitMinimumStockQuantity = 0;
            }
            else
            {
                productDetailTabControlOverviewTabPageUnitMinimumStockQuantity = int.Parse(productDetailTabControlOverviewTabPageUnitMinimumStockQuantityTextbox.Text.TrimEnd());
            }
            decimal productDetailTabControlOverviewTabPageUnitPrice = decimal.Parse($"{productDetailTabControlOverviewTabPageUnitPriceTextboxA.Text.TrimEnd()}.{productDetailTabControlOverviewTabPageUnitPriceTextboxB.Text.TrimEnd()}");
            int productDetailTabControlOverviewTabPageWholesaleCartonStockQuantityHeld = int.Parse(productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleCartonQuantityTextbox.Text.TrimEnd());
            decimal productDetailTabControlOverviewTabPageWholesalePricePerUnit = decimal.Parse($"{productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesalePricePerUnitTextboxA.Text.TrimEnd()}.{productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesalePricePerUnitTextboxB.Text.TrimEnd()}");
            int productDetailTabControlOverviewTabPageWholesaleUnitQuantityPerCarton = int.Parse(productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleUnitQuantityPerCartonTextbox.Text.TrimEnd());
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
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.ConnectionSettingsNotLoaded");
                return;
            }

            var dataToValidate = new List<ValidateDataInput.DataProperty>
            {
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewActiveStatus",
                    Value = productDetailTabControlOverviewTabPageActiveStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewProductCategoryId",
                    Value = productDetailTabControlOverviewTabPageProductCategoryId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewProductName",
                    Value = productDetailTabControlOverviewTabPageProductName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewSupplierId",
                    Value = productDetailTabControlOverviewTabPageSupplierId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewUnitMinimumOrderQuantity",
                    Value = productDetailTabControlOverviewTabPageUnitMinimumOrderQuantity,
                    ValueType = typeof(int)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewUnitMinimumStockQuantity",
                    Value = productDetailTabControlOverviewTabPageUnitMinimumStockQuantity,
                    ValueType = typeof(int)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewUnitPrice",
                    Value = productDetailTabControlOverviewTabPageUnitPrice,
                    ValueType = typeof(decimal)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewWholesaleCartonStockQuantityHeld",
                    Value = productDetailTabControlOverviewTabPageWholesaleCartonStockQuantityHeld,
                    ValueType = typeof(int)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewWholesaleCartonStockQuantityHeld",
                    Value = productDetailTabControlOverviewTabPageWholesaleCartonStockQuantityHeld,
                    ValueType = typeof(int)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewWholesalePricePerUnit",
                    Value = productDetailTabControlOverviewTabPageWholesalePricePerUnit,
                    ValueType = typeof(decimal)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewWholesaleUnitQuantityPerCarton",
                    Value = productDetailTabControlOverviewTabPageWholesaleUnitQuantityPerCarton,
                    ValueType = typeof(int)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewWholesaleReorderFlag",
                    Value = productDetailTabControlOverviewTabPageWholesaleReorderFlag,
                    ValueType = typeof(bool)
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

                bool confirmed = UpdateConfirmation.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
                {
                    var parameters = new List<Parameter>
                    {
                        new Parameter
                        {
                            ParameterName = "@activeStatus",
                            ParameterValue = productDetailTabControlOverviewTabPageActiveStatus
                        },
                        new Parameter
                        {
                            ParameterName = "@productCategoryId",
                            ParameterValue = productDetailTabControlOverviewTabPageProductCategoryId
                        },
                        new Parameter
                        {
                            ParameterName = "@productId",
                            ParameterValue = _productId
                        },
                        new Parameter
                        {
                            ParameterName = "@productName",
                            ParameterValue = productDetailTabControlOverviewTabPageProductName
                        },
                        new Parameter
                        {
                            ParameterName = "@supplierId",
                            ParameterValue = productDetailTabControlOverviewTabPageSupplierId
                        },
                        new Parameter
                        {
                            ParameterName = "@unitMinimumOrderQuantity",
                            ParameterValue = productDetailTabControlOverviewTabPageUnitMinimumOrderQuantity
                        },
                        new Parameter
                        {
                            ParameterName = "@unitMinimumStockQuantity",
                            ParameterValue = productDetailTabControlOverviewTabPageUnitMinimumStockQuantity
                        },
                        new Parameter
                        {
                            ParameterName = "@unitPrice",
                            ParameterValue = productDetailTabControlOverviewTabPageUnitPrice
                        },
                        new Parameter
                        {
                            ParameterName = "@unitStockQuantityHeld",
                            ParameterValue = productDetailTabControlOverviewTabPageUnitStockQuantityHeld
                        },
                        new Parameter
                        {
                            ParameterName = "@wholesaleCartonStockQuantityHeld",
                            ParameterValue = productDetailTabControlOverviewTabPageWholesaleCartonStockQuantityHeld
                        },
                        new Parameter
                        {
                            ParameterName = "@wholesalePricePerUnit",
                            ParameterValue = productDetailTabControlOverviewTabPageWholesalePricePerUnit
                        },
                        new Parameter
                        {
                            ParameterName = "@wholesaleReorderFlag",
                            ParameterValue = productDetailTabControlOverviewTabPageWholesaleReorderFlag
                        },
                        new Parameter
                        {
                            ParameterName = "@wholesaleUnitQuantityPerCarton",
                            ParameterValue = productDetailTabControlOverviewTabPageWholesaleUnitQuantityPerCarton
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

                    string storedProcedureName = "[dbo].[spUpdateProduct]";
                    string operationType = "update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters.ToArray(), dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
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
            productDetailTabControlOverviewTabPageActiveStatusCheckbox.Enabled = !productDetailTabControlOverviewTabPageActiveStatusCheckbox.Enabled;
            productDetailTabControlOverviewTabPageProductCategoryComboBox.Enabled = !productDetailTabControlOverviewTabPageProductCategoryComboBox.Enabled;
            productDetailTabControlOverviewTabPageProductNameTextbox.ReadOnly = !productDetailTabControlOverviewTabPageProductNameTextbox.ReadOnly;
            productDetailTabControlOverviewTabPageSupplierComboBox.Enabled = !productDetailTabControlOverviewTabPageSupplierComboBox.Enabled;
            productDetailTabControlOverviewTabPageUnitMinimumOrderQuantityTextbox.ReadOnly = !productDetailTabControlOverviewTabPageUnitMinimumOrderQuantityTextbox.ReadOnly;
            productDetailTabControlOverviewTabPageUnitMinimumStockQuantityTextbox.ReadOnly = !productDetailTabControlOverviewTabPageUnitMinimumStockQuantityTextbox.ReadOnly;
            productDetailTabControlOverviewTabPageUnitPriceTextboxA.ReadOnly = !productDetailTabControlOverviewTabPageUnitPriceTextboxA.ReadOnly;
            productDetailTabControlOverviewTabPageUnitPriceTextboxB.ReadOnly = !productDetailTabControlOverviewTabPageUnitPriceTextboxB.ReadOnly;
            productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleCartonQuantityTextbox.ReadOnly = !productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleCartonQuantityTextbox.ReadOnly;
            productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesalePricePerUnitTextboxA.ReadOnly = !productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesalePricePerUnitTextboxA.ReadOnly;
            productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesalePricePerUnitTextboxB.ReadOnly = !productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesalePricePerUnitTextboxB.ReadOnly;
            productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleReorderFlagPanelYesRadioButton.Enabled = !productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleReorderFlagPanelYesRadioButton.Enabled;
            productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleReorderFlagPanelNoRadioButton.Enabled = !productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleReorderFlagPanelNoRadioButton.Enabled;
            productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleUnitQuantityPerCartonTextbox.ReadOnly = !productDetailTabControlOverviewTabPageWholesaleGroupBoxWholesaleUnitQuantityPerCartonTextbox.ReadOnly;
            productDetailTabControlProductImageTabPageChooseProductImageButton.Enabled = !productDetailTabControlProductImageTabPageChooseProductImageButton.Enabled;
            productDetailUpdateProductButton.Enabled = !productDetailUpdateProductButton.Enabled;
        }

        private void productDetailProductNotesCreateNewProductNoteButton_Click(object sender, EventArgs e)
        {
            CreateNote createNote = new CreateNote(_productId, "ProductNote");
            createNote.Show();
        }

        private async void productDetailProductNotesRefreshDataButton_Click(object sender, EventArgs e)
        {
            await ProductDetailExistingProductNote_Load(sender, e);
        }
    }
}