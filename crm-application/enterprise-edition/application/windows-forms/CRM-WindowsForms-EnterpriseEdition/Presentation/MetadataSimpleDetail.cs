using CRM_WindowsForms.Interface;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class MetadataSimpleDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _dataSubjectId;
        private readonly string _functionTitle;
        private readonly string applicationTitlePrefix = "CRM - ";
        private bool? dataSubjectActiveStatusOriginalValue;
        private string dataSubjectFriendlyName;
        private string dataSubjectGetStoredProcedureName;
        private string dataSubjectIdFriendlyName;
        private string dataSubjectIdName;
        private string dataSubjectName;
        private string? dataSubjectOriginalValue;
        private string dataSubjectUpdateStoredProcedureName;
        private readonly string titleLabelSuffix= " Detail";

        public MetadataSimpleDetail(Guid dataSubjectId, string functionTitle)
        {
            InitializeComponent();
            _dataSubjectId = dataSubjectId;
            _functionTitle = functionTitle;
            metadataSimpleDetailToggleEditModeButton.Click += metadataSimpleDetailToggleEditModeButton_Click;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void SetParameters(string functionTitle)
        {
            switch (functionTitle)
            {
                case "CustomerNoteType":
                    dataSubjectFriendlyName = "Customer Note Type";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetCustomerNoteType]";
                    dataSubjectIdFriendlyName = "Customer Note Type Id";
                    dataSubjectIdName = "CustomerNoteTypeId";
                    dataSubjectName = functionTitle;
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateCustomerNoteType]";
                    break;
                case "CustomerType":
                    dataSubjectFriendlyName = "Customer Type";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetCustomerType]";
                    dataSubjectIdFriendlyName = "Customer Type Id";
                    dataSubjectIdName = "CustomerTypeId";
                    dataSubjectName = functionTitle;
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateCustomerType]";
                    break;
                case "MarketingChannel":
                    dataSubjectFriendlyName = "Marketing Channel";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetMarketingChannel]";
                    dataSubjectIdFriendlyName = "Marketing Channel Id";
                    dataSubjectIdName = "MarketingChannelId";
                    dataSubjectName = functionTitle;
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateMarketingChannel]";
                    break;
                case "OrderLineItemStatus":
                    dataSubjectFriendlyName = "Order Line Item Status";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetOrderLineItemStatus]";
                    dataSubjectIdFriendlyName = "Order Line Item Status Id";
                    dataSubjectIdName = "OrderLineItemStatusId";
                    dataSubjectName = functionTitle;
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateOrderLineItemStatus]";
                    break;
                case "OrderStatus":
                    dataSubjectFriendlyName = "Order Status";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetOrderStatus]";
                    dataSubjectIdFriendlyName = "Order Status Id";
                    dataSubjectIdName = "OrderStatusId";
                    dataSubjectName = functionTitle;
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateOrderStatus]";
                    break;
                case "PaymentMethod":
                    dataSubjectFriendlyName = "Payment Method";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetPaymentMethod]";
                    dataSubjectIdFriendlyName = "Payment Method Id";
                    dataSubjectIdName = "PaymentMethodId";
                    dataSubjectName = functionTitle;
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdatePaymentMethod]";
                    break;
                case "ProductCategory":
                    dataSubjectFriendlyName = "Product Category";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetProductCategory]";
                    dataSubjectIdFriendlyName = "Product Category Id";
                    dataSubjectIdName = "ProductCategoryId";
                    dataSubjectName = functionTitle;
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateProductCategory]";
                    break;
                case "ProductNoteType":
                    dataSubjectFriendlyName = "Product Note Type";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetProductNoteType]";
                    dataSubjectIdFriendlyName = "Product Note Type Id";
                    dataSubjectIdName = "ProductNoteTypeId";
                    dataSubjectName = functionTitle;
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateProductNoteType]";
                    break;
                case "SalesRegion":
                    dataSubjectFriendlyName = "Sales Region";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetSalesRegion]";
                    dataSubjectIdFriendlyName = "Sales Region Id";
                    dataSubjectIdName = "SalesRegionId";
                    dataSubjectName = functionTitle;
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateSalesRegion]";
                    break;
                case "SupplierNoteType":
                    dataSubjectFriendlyName = "Supplier Note Type";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetSupplierNoteType]";
                    dataSubjectIdFriendlyName = "Supplier Note Type Id";
                    dataSubjectIdName = "SupplierNoteTypeId";
                    dataSubjectName = functionTitle;
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateSupplierNoteType]";
                    break;
            }

            metadataSimpleDetailTitleLabel.Text = $"{dataSubjectFriendlyName}{titleLabelSuffix}";
            metadataSimpleDetailDataSubjectIdTextboxLabel.Text = dataSubjectIdFriendlyName;
            metadataSimpleDetailDataSubjectTextboxLabel.Text = dataSubjectFriendlyName;
            metadataSimpleDetailActiveStatusCheckbox.Text = $"Active {dataSubjectFriendlyName}";
            metadataSimpleDetailUpdateDataSubjectButton.Text = $"Update {dataSubjectFriendlyName}";
            this.Text = $"{applicationTitlePrefix}{dataSubjectFriendlyName}{titleLabelSuffix}";
        }

        private async void ViewMetadataSimpleDetailMetadataInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var parameters = new List<Parameter>();

            switch (_functionTitle)
            {
                case "CustomerNoteType":
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@customerNoteTypeId",
                        ParameterValue = _dataSubjectId
                    });
                    break;
                case "CustomerType":
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@customerTypeId",
                        ParameterValue = _dataSubjectId
                    });
                    break;
                case "MarketingChannel":
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@marketingChannelId",
                        ParameterValue = _dataSubjectId
                    });
                    break;
                case "OrderLineItemStatus":
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@orderLineItemStatusId",
                        ParameterValue = _dataSubjectId
                    });
                    break;
                case "OrderStatus":
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@orderStatusId",
                        ParameterValue = _dataSubjectId
                    });
                    break;
                case "PaymentMethod":
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@paymentMethodId",
                        ParameterValue = _dataSubjectId
                    });
                    break;
                case "ProductCategory":
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@productCategoryId",
                        ParameterValue = _dataSubjectId
                    });
                    break;
                case "ProductNoteType":
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@productNoteTypeId",
                        ParameterValue = _dataSubjectId
                    });
                    break;
                case "SalesRegion":
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@salesRegionId",
                        ParameterValue = _dataSubjectId
                    });
                    break;
                case "SupplierNoteType":
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@supplierNoteTypeId",
                        ParameterValue = _dataSubjectId
                    });
                    break;
            }

            try
            {
                DataTable? metadataSimpleDetailDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(
                    dataSubjectGetStoredProcedureName,
                    parameters.ToArray(),
                    dataSubjectName,
                    _databaseConnectionSettings.DatabaseConnectionString);

                if (metadataSimpleDetailDataTable != null)
                {
                    DataRow metadataSimpleDetailDataRow = metadataSimpleDetailDataTable.Rows[0];
                    metadataSimpleDetailDataSubjectIdTextbox.Text = metadataSimpleDetailDataRow[dataSubjectIdFriendlyName].ToString();
                    metadataSimpleDetailDataSubjectTextbox.Text = metadataSimpleDetailDataRow[dataSubjectFriendlyName].ToString();
                    metadataSimpleDetailCreatedByTextbox.Text = metadataSimpleDetailDataRow["Created By"].ToString();
                    metadataSimpleDetailCreatedTimestampTextbox.Text = metadataSimpleDetailDataRow["Created Timestamp"].ToString();
                    metadataSimpleDetailLastUpdatedByTextbox.Text = metadataSimpleDetailDataRow["Modified By"].ToString();
                    metadataSimpleDetailLastUpdatedTimestampTextbox.Text = metadataSimpleDetailDataRow["Modified Timestamp"].ToString();
                    metadataSimpleDetailActiveStatusCheckbox.Checked = (bool)metadataSimpleDetailDataRow["Active Status"];

                    dataSubjectOriginalValue = metadataSimpleDetailDataRow[dataSubjectFriendlyName].ToString();
                    dataSubjectActiveStatusOriginalValue = (bool)metadataSimpleDetailDataRow["Active Status"];
                }
                else
                {
                    MessageBox.Show($"No data found for the specified {dataSubjectFriendlyName}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load {dataSubjectFriendlyName} details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void metadataSimpleDetailUpdateDataSubjectButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = metadataSimpleDetailActiveStatusCheckbox.Checked;
            string dataSubjectValue = metadataSimpleDetailDataSubjectTextbox.Text.TrimEnd();

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
                    Name = dataSubjectName,
                    Value = dataSubjectValue,
                    MaxLength = 50,
                    ValueType = typeof(string)
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
                var changesList = new List<ChangeDetail>
                {
                    new ChangeDetail
                    {
                        VariableName = "Active Status",
                        VariableType = "bool",
                        OriginalValue = dataSubjectActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = dataSubjectFriendlyName,
                        VariableType = "string",
                        OriginalValue = dataSubjectOriginalValue,
                        NewValue = dataSubjectValue
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = UpdateConfirmation.ConfirmChanges(changesList, dataSubjectName);

                if (confirmed)
                {
                    var parameters = new[]
                    {
                        new Parameter
                        {
                            ParameterName = "@activeStatus",
                            ParameterValue = activeStatus
                        }
                    };

                    switch (_functionTitle)
                    {
                        case "CustomerNoteType":
                            parameters = parameters.Append(new Parameter
                            {
                                ParameterName = "@customerNoteType",
                                ParameterValue = dataSubjectValue
                            }).ToArray();
                            break;
                        case "CustomerType":
                            parameters = parameters.Append(new Parameter
                            {
                                ParameterName = "@customerType",
                                ParameterValue = dataSubjectValue
                            }).ToArray();
                            break;
                        case "MarketingChannel":
                            parameters = parameters.Append(new Parameter
                            {
                                ParameterName = "@marketingChannel",
                                ParameterValue = dataSubjectValue
                            }).ToArray();
                            break;
                        case "OrderLineItemStatus":
                            parameters = parameters.Append(new Parameter
                            {
                                ParameterName = "@orderLineItemStatus",
                                ParameterValue = dataSubjectValue
                            }).ToArray();
                            break;
                        case "OrderStatus":
                            parameters = parameters.Append(new Parameter
                            {
                                ParameterName = "@orderStatus",
                                ParameterValue = dataSubjectValue
                            }).ToArray();
                            break;
                        case "PaymentMethod":
                            parameters = parameters.Append(new Parameter
                            {
                                ParameterName = "@paymentMethod",
                                ParameterValue = dataSubjectValue
                            }).ToArray();
                            break;
                        case "ProductCategory":
                            parameters = parameters.Append(new Parameter
                            {
                                ParameterName = "@productCategory",
                                ParameterValue = dataSubjectValue
                            }).ToArray();
                            break;
                        case "ProductNoteType":
                            parameters = parameters.Append(new Parameter
                            {
                                ParameterName = "@productNoteType",
                                ParameterValue = dataSubjectValue
                            }).ToArray();
                            break;
                        case "SalesRegion":
                            parameters = parameters.Append(new Parameter
                            {
                                ParameterName = "@salesRegion",
                                ParameterValue = dataSubjectValue
                            }).ToArray();
                            break;
                        case "SupplierNoteType":
                            parameters = parameters.Append(new Parameter
                            {
                                ParameterName = "@supplierNoteType",
                                ParameterValue = dataSubjectValue
                            }).ToArray();
                            break;
                    }

                    string operationType = "update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(dataSubjectUpdateStoredProcedureName, parameters, dataSubjectName, _databaseConnectionSettings.DatabaseConnectionString, operationType);
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
            SetParameters(_functionTitle);
            ViewMetadataSimpleDetailMetadataInformation_Load(this, EventArgs.Empty);
        }

        private void metadataSimpleDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            metadataSimpleDetailDataSubjectTextbox.ReadOnly = !metadataSimpleDetailDataSubjectTextbox.ReadOnly;
            metadataSimpleDetailActiveStatusCheckbox.Enabled = !metadataSimpleDetailActiveStatusCheckbox.Enabled;
            metadataSimpleDetailUpdateDataSubjectButton.Enabled = !metadataSimpleDetailUpdateDataSubjectButton.Enabled;
        }
    }
}