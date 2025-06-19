using CRM_WindowsForms.Interface;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class ProductDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _productId;
        private bool? productDetailOverviewActiveStatusOriginalValue;
        private Guid? productDetailOverviewProductCategoryIdOriginalValue;
        private string? productDetailOverviewProductNameOriginalValue;
        private Guid? productDetailOverviewSupplierIdOriginalValue;
        private int? productDetailOverviewUnitMinimumOrderQuantityOriginalValue;
        private int? productDetailOverviewUnitMinimumStockQuantityOriginalValue;
        private decimal? productDetailOverviewUnitPriceOriginalValue;
        private int? productDetailOverviewUnitStockQuantityHeldOriginalValue;
        private int? productDetailOverviewWholesaleCartonStockQuantityHeldOriginalValue;
        private decimal? productDetailOverviewWholesalePricePerUnitOriginalValue;
        private bool? productDetailOverviewWholesaleReorderFlagOriginalValue;
        private int? productDetailOverviewWholesaleUnitQuantityPerCartonOriginalValue;
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
            productDetailTabControl.SelectedIndexChanged += ProductDetailTabControl_SelectedIndexChanged;
            productDetailProductNotesExistingProductNotesDataGridView.CellContentClick += ProductDetailProductNotesExistingProductNotesDataGridView_CellContentClick;
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

                productDetailOverviewProductCategoryComboBox.DataSource = productCategoryList;
                productDetailOverviewProductCategoryComboBox.DisplayMember = "ProductCategory";
                productDetailOverviewProductCategoryComboBox.ValueMember = "ProductCategoryId";
                productDetailOverviewProductCategoryComboBox.SelectedValue = productCategoryId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Product Category data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ProductDetailOverviewLoadSupplierDataAsync(Guid productSupplierId)
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
                        Supplier = row.Field<string>("Supplier Name"),
                        DisplayText = row.Field<string>("VAT Number") != null
                            ? $"{row.Field<string>("Supplier Name")} | {row.Field<string>("VAT Number")}"
                            : row.Field<string>("Supplier Name")
                    })
                    .OrderBy(item => item.Supplier)
                    .ToList();

                productDetailOverviewSupplierComboBox.DataSource = supplierList;
                productDetailOverviewSupplierComboBox.DisplayMember = "DisplayText";
                productDetailOverviewSupplierComboBox.ValueMember = "SupplierId";
                productDetailOverviewSupplierComboBox.SelectedValue = productSupplierId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Supplier data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ViewProductDetailProductInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    productDetailOverviewActiveStatusCheckbox.Checked = (bool)productDataRow["Active Status"];
                    productDetailOverviewCreatedByTextbox.Text = productDataRow["Created By"].ToString();
                    productDetailOverviewCreatedTimestampTextbox.Text = productDataRow["Created Timestamp UTC"].ToString();
                    productDetailOverviewLastUpdatedByTextbox.Text = productDataRow["Modified By"].ToString();
                    productDetailOverviewLastUpdatedTimestampTextbox.Text = productDataRow["Modified Timestamp UTC"].ToString();
                    Guid productCategoryId = (Guid)productDataRow["Product Category Id"];
                    await ProductDetailOverviewLoadProductCategoryDataAsync(productCategoryId);
                    productDetailOverviewProductIdTextbox.Text = productDataRow["Product Id"].ToString();
                    productDetailOverviewProductNameTextbox.Text = productDataRow["Product Name"].ToString();
                    Guid productSupplierId = (Guid)productDataRow["Supplier Id"];
                    await ProductDetailOverviewLoadSupplierDataAsync(productSupplierId);
                    productDetailOverviewUnitMinimumOrderQuantityTextbox.Text = productDataRow["Unit Minimum Order Quantity"].ToString();
                    productDetailOverviewUnitMinimumStockQuantityTextbox.Text = productDataRow["Unit Minimum Stock Quantity"].ToString();
                    string unitPricePartA;
                    string unitPricePartB;
                    SplitDecimal.SplitDecimalUsingDelimiter((decimal)productDataRow["Unit Selling Price"], out unitPricePartA, out unitPricePartB);
                    productDetailOverviewUnitPriceTextboxA.Text = unitPricePartA;
                    productDetailOverviewUnitPriceTextboxB.Text = unitPricePartB;
                    productDetailOverviewUnitStockQuantityHeldTextbox.Text = productDataRow["Unit Stock Quantity Held"].ToString();
                    productDetailOverviewWholesaleCartonQuantityTextbox.Text = productDataRow["Wholesale Carton Stock Quantity Held"].ToString();
                    string wholesalePricePerUnitPartA;
                    string wholesalePricePerUnitPartB;
                    SplitDecimal.SplitDecimalUsingDelimiter((decimal)productDataRow["Wholesale Price Per Unit"], out wholesalePricePerUnitPartA, out wholesalePricePerUnitPartB);
                    productDetailOverviewWholesalePricePerUnitTextboxA.Text = wholesalePricePerUnitPartA;
                    productDetailOverviewWholesalePricePerUnitTextboxB.Text = wholesalePricePerUnitPartB;
                    productDetailOverviewWholesaleUnitQuantityPerCartonTextbox.Text = productDataRow["Wholesale Unit Quantity Per Carton"].ToString();
                    if ((bool)productDataRow["Wholesale Reorder Flag"])
                    {
                        productDetailOverviewWholesaleReorderFlagYesRadioButton.Checked = true;
                    }
                    else
                    {
                        productDetailOverviewWholesaleReorderFlagNoRadioButton.Checked = true;
                    }
                    if (productDataRow["Product Image"] != DBNull.Value)
                    {
                        productDetailProductImagePictureBox.Image = ImageHelper.ByteArrayToImage((byte[])productDataRow["Product Image"]);
                    }
                    else
                    {
                        productDetailProductImagePictureBox.Image = null;
                    }

                    productDetailOverviewActiveStatusOriginalValue = (bool)productDataRow["Active Status"];
                    productDetailOverviewProductCategoryIdOriginalValue = (Guid)productDataRow["Product Category Id"];
                    productDetailOverviewProductNameOriginalValue = productDataRow["Product Name"].ToString();
                    productDetailOverviewSupplierIdOriginalValue = (Guid)productDataRow["Supplier Id"];
                    productDetailOverviewUnitMinimumOrderQuantityOriginalValue = (int)productDataRow["Unit Minimum Order Quantity"];
                    productDetailOverviewUnitMinimumStockQuantityOriginalValue = (int)productDataRow["Unit Minimum Stock Quantity"];
                    productDetailOverviewUnitPriceOriginalValue = (decimal)productDataRow["Unit Selling Price"];
                    productDetailOverviewUnitStockQuantityHeldOriginalValue = (int)productDataRow["Unit Stock Quantity Held"];
                    productDetailOverviewWholesaleCartonStockQuantityHeldOriginalValue = (int)productDataRow["Wholesale Carton Stock Quantity Held"];
                    productDetailOverviewWholesalePricePerUnitOriginalValue = (decimal)productDataRow["Wholesale Price Per Unit"];
                    productDetailOverviewWholesaleUnitQuantityPerCartonOriginalValue = (int)productDataRow["Wholesale Unit Quantity Per Carton"];
                    productDetailOverviewWholesaleReorderFlagOriginalValue = (bool)productDataRow["Wholesale Reorder Flag"];
                    productDetailProductImageOriginalValue = productDataRow["Product Image"] as byte[];
                }
                else
                {
                    MessageBox.Show($"No data found for the specified {dataSubject}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load {dataSubject} details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ProductDetailTabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (productDetailTabControl.SelectedTab == productDetailTabControl.TabPages["productDetailTabControlProductNotesPage"])
            {
                await ViewProductDetailExistingProductNote_Load(sender, e);
            }
        }

        private async Task ViewProductDetailExistingProductNote_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("No Existing Product Notes found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataTable.DefaultView.Sort = "Created Timestamp DESC";
                productDetailProductNotesExistingProductNotesDataGridView.AutoGenerateColumns = true;
                productDetailProductNotesExistingProductNotesDataGridView.DataSource = dataTable;
                productDetailProductNotesExistingProductNotesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if (productDetailProductNotesExistingProductNotesDataGridView.Columns.Contains("Details"))
                {
                    productDetailProductNotesExistingProductNotesDataGridView.Columns.Remove("Details");
                }
                DataGridViewLinkColumn productNoteDetailLink = new DataGridViewLinkColumn
                {
                    HeaderText = "Details",
                    Text = "View Product Note",
                    UseColumnTextForLinkValue = true,
                    Name = "Details"
                };
                productDetailProductNotesExistingProductNotesDataGridView.Columns.Add(productNoteDetailLink);
            }
        }

        private void ProductDetailProductNotesExistingProductNotesDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == productDetailProductNotesExistingProductNotesDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (productDetailProductNotesExistingProductNotesDataGridView.Columns.Contains("Product Note Id"))
                    {
                        Guid productNoteId = (Guid)productDetailProductNotesExistingProductNotesDataGridView.Rows[e.RowIndex].Cells["Product Note Id"].Value;
                        NoteDetail noteDetail = new NoteDetail("Product", productNoteId);
                        noteDetail.Show();
                    }
                    else
                    {
                        MessageBox.Show("Product Note Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open Product Note details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CalulateUnitStockQuantityHeld(object? sender, EventArgs e)
        {
            productDetailOverviewUnitStockQuantityHeldTextbox.Text = (int.Parse(productDetailOverviewWholesaleCartonQuantityTextbox.Text.TrimEnd()) * int.Parse(productDetailOverviewWholesaleUnitQuantityPerCartonTextbox.Text.TrimEnd())).ToString();
        }

        private void productDetailProductImageChooseProductImageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    if (ValidateDataInput.IsValidImageFile(filePath, out string errorMessage))
                    {
                        productDetailProductImagePictureBox.Image = Image.FromFile(filePath);
                        productDetailProductImageRuntimeValue = File.ReadAllBytes(filePath);
                    }
                    else
                    {
                        MessageBox.Show(errorMessage, "Invalid Image", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        productDetailProductImagePictureBox.Image = null;
                        productDetailProductImageRuntimeValue = null;
                    }
                }
            }
        }

        private void productDetailProductImageRemoveProductImageButton_Click(object sender, EventArgs e)
        {
            productDetailProductImagePictureBox.Image = null;
            productDetailProductImageRuntimeValue = null;
        }

        private async void productDetailUpdateProductButton_Click(object sender, EventArgs e)
        {
            bool productDetailOverviewActiveStatus = productDetailOverviewActiveStatusCheckbox.Checked;
            Guid productDetailOverviewProductCategoryId = (Guid)productDetailOverviewProductCategoryComboBox.SelectedValue;
            string productDetailOverviewProductName = productDetailOverviewProductNameTextbox.Text.TrimEnd();
            Guid productDetailOverviewSupplierId = (Guid)productDetailOverviewSupplierComboBox.SelectedValue;
            int productDetailOverviewUnitMinimumOrderQuantity = int.Parse(productDetailOverviewUnitMinimumOrderQuantityTextbox.Text.TrimEnd());
            int productDetailOverviewUnitMinimumStockQuantity;
            if (productDetailOverviewUnitMinimumStockQuantityTextbox.Text.TrimEnd() == string.Empty)
            {
                productDetailOverviewUnitMinimumStockQuantity = 0;
            }
            else
            {
                productDetailOverviewUnitMinimumStockQuantity = int.Parse(productDetailOverviewUnitMinimumStockQuantityTextbox.Text.TrimEnd());
            }
            decimal productDetailOverviewUnitPrice = decimal.Parse($"{productDetailOverviewUnitPriceTextboxA.Text.TrimEnd()}.{productDetailOverviewUnitPriceTextboxB.Text.TrimEnd()}");
            int productDetailOverviewWholesaleCartonStockQuantityHeld = int.Parse(productDetailOverviewWholesaleCartonQuantityTextbox.Text.TrimEnd());
            decimal productDetailOverviewWholesalePricePerUnit = decimal.Parse($"{productDetailOverviewWholesalePricePerUnitTextboxA.Text.TrimEnd()}.{productDetailOverviewWholesalePricePerUnitTextboxB.Text.TrimEnd()}");
            int productDetailOverviewWholesaleUnitQuantityPerCarton = int.Parse(productDetailOverviewWholesaleUnitQuantityPerCartonTextbox.Text.TrimEnd());
            bool productDetailOverviewWholesaleReorderFlag;
            if (productDetailOverviewWholesaleReorderFlagYesRadioButton.Checked)
            {
                productDetailOverviewWholesaleReorderFlag = true;
            }
            else
            {
                productDetailOverviewWholesaleReorderFlag = false;
            }
            byte[] productImage = productDetailProductImageRuntimeValue ?? Array.Empty<byte>();
            int productDetailOverviewUnitStockQuantityHeld = (productDetailOverviewWholesaleCartonStockQuantityHeld * productDetailOverviewWholesaleUnitQuantityPerCarton);

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
                    Name = "ProductDetailOverviewActiveStatus",
                    Value = productDetailOverviewActiveStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewProductCategoryId",
                    Value = productDetailOverviewProductCategoryId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewProductName",
                    Value = productDetailOverviewProductName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewSupplierId",
                    Value = productDetailOverviewSupplierId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewUnitMinimumOrderQuantity",
                    Value = productDetailOverviewUnitMinimumOrderQuantity,
                    ValueType = typeof(int)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewUnitMinimumStockQuantity",
                    Value = productDetailOverviewUnitMinimumStockQuantity,
                    ValueType = typeof(int)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewUnitPrice",
                    Value = productDetailOverviewUnitPrice,
                    ValueType = typeof(decimal)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewWholesaleCartonStockQuantityHeld",
                    Value = productDetailOverviewWholesaleCartonStockQuantityHeld,
                    ValueType = typeof(int)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewWholesaleCartonStockQuantityHeld",
                    Value = productDetailOverviewWholesaleCartonStockQuantityHeld,
                    ValueType = typeof(int)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewWholesalePricePerUnit",
                    Value = productDetailOverviewWholesalePricePerUnit,
                    ValueType = typeof(decimal)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewWholesaleUnitQuantityPerCarton",
                    Value = productDetailOverviewWholesaleUnitQuantityPerCarton,
                    ValueType = typeof(int)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "ProductDetailOverviewWholesaleReorderFlag",
                    Value = productDetailOverviewWholesaleReorderFlag,
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
                        OriginalValue = productDetailOverviewActiveStatusOriginalValue,
                        NewValue = productDetailOverviewActiveStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Detail Overview: Product Category Id",
                        VariableType = "Guid",
                        OriginalValue = productDetailOverviewProductCategoryIdOriginalValue,
                        NewValue = productDetailOverviewProductCategoryId
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
                        OriginalValue = productDetailOverviewProductNameOriginalValue,
                        NewValue = productDetailOverviewProductName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Detail Overview: Supplier Id",
                        VariableType = "Guid",
                        OriginalValue = productDetailOverviewSupplierIdOriginalValue,
                        NewValue = productDetailOverviewSupplierId
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Detail Overview: Unit Minimum Order Quantity",
                        VariableType = "int",
                        OriginalValue = productDetailOverviewUnitMinimumOrderQuantityOriginalValue,
                        NewValue = productDetailOverviewUnitMinimumOrderQuantity
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Detail Overview: Unit Minimum Stock Quantity",
                        VariableType = "int",
                        OriginalValue = productDetailOverviewUnitMinimumStockQuantityOriginalValue,
                        NewValue = productDetailOverviewUnitMinimumStockQuantity
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Detail Overview: Unit Price",
                        VariableType = "string",
                        OriginalValue = productDetailOverviewUnitPriceOriginalValue,
                        NewValue = productDetailOverviewUnitPrice
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Detail Overview: Unit Stock Quantity Held",
                        VariableType = "string",
                        OriginalValue = productDetailOverviewUnitStockQuantityHeldOriginalValue,
                        NewValue = productDetailOverviewUnitStockQuantityHeld
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Detail Overview: Wholesale Carton Stock Quantity Held",
                        VariableType = "int",
                        OriginalValue = productDetailOverviewWholesaleCartonStockQuantityHeldOriginalValue,
                        NewValue = productDetailOverviewWholesaleCartonStockQuantityHeld
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Detail Overview: Wholesale Price Per Unit",
                        VariableType = "decimal",
                        OriginalValue = productDetailOverviewWholesalePricePerUnitOriginalValue,
                        NewValue = productDetailOverviewWholesalePricePerUnit
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Detail Overview: Wholesale Unit Quantity Per Carton",
                        VariableType = "int",
                        OriginalValue = productDetailOverviewWholesaleUnitQuantityPerCartonOriginalValue,
                        NewValue = productDetailOverviewWholesaleUnitQuantityPerCarton
                    },
                    new ChangeDetail
                    {
                        VariableName = "Product Detail Overview: Wholesale Reorder Flag",
                        VariableType = "bool",
                        OriginalValue = productDetailOverviewWholesaleReorderFlagOriginalValue,
                        NewValue = productDetailOverviewWholesaleReorderFlag
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
                            ParameterValue = productDetailOverviewActiveStatus
                        },
                        new Parameter
                        {
                            ParameterName = "@productCategoryId",
                            ParameterValue = productDetailOverviewProductCategoryId
                        },
                        new Parameter
                        {
                            ParameterName = "@productId",
                            ParameterValue = _productId
                        },
                        new Parameter
                        {
                            ParameterName = "@productName",
                            ParameterValue = productDetailOverviewProductName
                        },
                        new Parameter
                        {
                            ParameterName = "@supplierId",
                            ParameterValue = productDetailOverviewSupplierId
                        },
                        new Parameter
                        {
                            ParameterName = "@unitMinimumOrderQuantity",
                            ParameterValue = productDetailOverviewUnitMinimumOrderQuantity
                        },
                        new Parameter
                        {
                            ParameterName = "@unitMinimumStockQuantity",
                            ParameterValue = productDetailOverviewUnitMinimumStockQuantity
                        },
                        new Parameter
                        {
                            ParameterName = "@unitPrice",
                            ParameterValue = productDetailOverviewUnitPrice
                        },
                        new Parameter
                        {
                            ParameterName = "@unitStockQuantityHeld",
                            ParameterValue = productDetailOverviewUnitStockQuantityHeld
                        },
                        new Parameter
                        {
                            ParameterName = "@wholesaleCartonStockQuantityHeld",
                            ParameterValue = productDetailOverviewWholesaleCartonStockQuantityHeld
                        },
                        new Parameter
                        {
                            ParameterName = "@wholesalePricePerUnit",
                            ParameterValue = productDetailOverviewWholesalePricePerUnit
                        },
                        new Parameter
                        {
                            ParameterName = "@wholesaleReorderFlag",
                            ParameterValue = productDetailOverviewWholesaleReorderFlag
                        },
                        new Parameter
                        {
                            ParameterName = "@wholesaleUnitQuantityPerCarton",
                            ParameterValue = productDetailOverviewWholesaleUnitQuantityPerCarton
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
                    MessageBox.Show("Updates were cancelled, no changes have been made to the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            ViewProductDetailProductInformation_Load(this, EventArgs.Empty);
        }

        private void ProductDetailToggleEditModeButton_Click(object sender, EventArgs e)
        {
            productDetailOverviewActiveStatusCheckbox.Enabled = !productDetailOverviewActiveStatusCheckbox.Enabled;
            productDetailOverviewProductCategoryComboBox.Enabled = !productDetailOverviewProductCategoryComboBox.Enabled;
            productDetailOverviewProductNameTextbox.ReadOnly = !productDetailOverviewProductNameTextbox.ReadOnly;
            productDetailOverviewSupplierComboBox.Enabled = !productDetailOverviewSupplierComboBox.Enabled;
            productDetailOverviewUnitMinimumOrderQuantityTextbox.ReadOnly = !productDetailOverviewUnitMinimumOrderQuantityTextbox.ReadOnly;
            productDetailOverviewUnitMinimumStockQuantityTextbox.ReadOnly = !productDetailOverviewUnitMinimumStockQuantityTextbox.ReadOnly;
            productDetailOverviewUnitPriceTextboxA.ReadOnly = !productDetailOverviewUnitPriceTextboxA.ReadOnly;
            productDetailOverviewUnitPriceTextboxB.ReadOnly = !productDetailOverviewUnitPriceTextboxB.ReadOnly;
            productDetailOverviewWholesaleCartonQuantityTextbox.ReadOnly = !productDetailOverviewWholesaleCartonQuantityTextbox.ReadOnly;
            productDetailOverviewWholesalePricePerUnitTextboxA.ReadOnly = !productDetailOverviewWholesalePricePerUnitTextboxA.ReadOnly;
            productDetailOverviewWholesalePricePerUnitTextboxB.ReadOnly = !productDetailOverviewWholesalePricePerUnitTextboxB.ReadOnly;
            productDetailOverviewWholesaleReorderFlagYesRadioButton.Enabled = !productDetailOverviewWholesaleReorderFlagYesRadioButton.Enabled;
            productDetailOverviewWholesaleReorderFlagNoRadioButton.Enabled = !productDetailOverviewWholesaleReorderFlagNoRadioButton.Enabled;
            productDetailOverviewWholesaleUnitQuantityPerCartonTextbox.ReadOnly = !productDetailOverviewWholesaleUnitQuantityPerCartonTextbox.ReadOnly;
            productDetailProductImageChooseProductImageButton.Enabled = !productDetailProductImageChooseProductImageButton.Enabled;
            productDetailUpdateProductButton.Enabled = !productDetailUpdateProductButton.Enabled;
        }

        private void ProductDetailProductNotesCreateNewProductNoteButton_Click(object sender, EventArgs e)
        {
            CreateNote createNote = new CreateNote(_productId, "ProductNote");
            createNote.Show();
        }

        private async void ProductDetailProductNotesRefreshDataButton_Click(object sender, EventArgs e)
        {
            await ViewProductDetailExistingProductNote_Load(sender, e);
        }
    }
}