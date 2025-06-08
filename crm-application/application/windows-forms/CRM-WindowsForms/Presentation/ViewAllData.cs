using CRM_WindowsForms.Interface;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
{
    public partial class ViewAllData : Form
    {
        private readonly string _functionTitle;
        private readonly string _moduleGroup;
        private readonly string applicationTitlePrefix = "CRM - ";
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private string dataSortingColumnName;
        private string dataSortingColumnOrder;
        private string dataSubjectFriendlyName;
        private string dataSubjectIdentityColumn;
        private string functionFriendlyName;
        private string storedProcedureName;
        private readonly string viewAllPrefix = "View All ";

        public ViewAllData(string functionTitle, string moduleGroup)
        {
            InitializeComponent();
            _functionTitle = functionTitle;
            _moduleGroup = moduleGroup;
            SetModuleTheme(_moduleGroup);
            SetParameters(_functionTitle);
            viewAllDataDataGridView.CellContentClick += viewAllDataDataGridView_CellContentClick;
            viewAllDataQuickFilterTextbox.TextChanged += viewAllDataQuickFilterTextbox_TextChanged;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void SetModuleTheme(string moduleGroup)
        {
            switch (moduleGroup)
            {
                case "CompanyManagement":
                    this.BackColor = Color.LemonChiffon;
                    viewAllDataDataGridView.BackgroundColor = Color.LemonChiffon;
                    break;
                case "CustomerManagement":
                    this.BackColor = Color.LightGreen;
                    viewAllDataDataGridView.BackgroundColor = Color.LightGreen;
                    break;
                case "MarketingManagement":
                    this.BackColor = Color.NavajoWhite;
                    viewAllDataDataGridView.BackgroundColor = Color.NavajoWhite;
                    break;
                case "OrderManagement":
                    this.BackColor = Color.Salmon;
                    viewAllDataDataGridView.BackgroundColor = Color.Salmon;
                    break;
                case "ProductManagement":
                    this.BackColor = Color.SkyBlue;
                    viewAllDataDataGridView.BackgroundColor = Color.SkyBlue;
                    break;
                case "SupplierManagement":
                    this.BackColor = Color.MediumAquamarine;
                    viewAllDataDataGridView.BackgroundColor = Color.MediumAquamarine;
                    break;
            }
        }

        private void SetParameters(string functionTitle)
        {
            switch (functionTitle)
            {
                case "AccountManager":
                    dataSortingColumnName = "Last Name";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Account Manager Id";
                    dataSubjectFriendlyName = "Account Manager";
                    functionFriendlyName = "Account Managers";
                    storedProcedureName = "[dbo].[spGetAllAccountManager]";
                    break;
                case "CompanyConfiguration":
                    dataSortingColumnName = "Company Name";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Company Configuration Id";
                    dataSubjectFriendlyName = "Company Configuration";
                    functionFriendlyName = "Company Configurations";
                    storedProcedureName = "[dbo].[spGetAllCompanyConfiguration]";
                    break;
                case "Currency":
                    dataSortingColumnName = "Currency Code";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Currency Id";
                    dataSubjectFriendlyName = "Currency";
                    functionFriendlyName = "Currencies";
                    storedProcedureName = "[dbo].[spGetAllCurrency]";
                    break;
                case "CurrencyConversion":
                    dataSortingColumnName = "Currency Conversion Friendly Name";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Currency Conversion Id";
                    dataSubjectFriendlyName = "Currency Conversion";
                    functionFriendlyName = "Currency Conversions";
                    storedProcedureName = "[dbo].[spGetAllCurrencyConversion]";
                    break;
                case "Customer":
                    dataSortingColumnName = "Customer Id";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Customer Id";
                    dataSubjectFriendlyName = "Customer";
                    functionFriendlyName = "Customers";
                    storedProcedureName = "[dbo].[spGetAllCustomer]";
                    break;
                case "CustomerNoteType":
                    dataSortingColumnName = "Customer Note Type";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Customer Note Type Id";
                    dataSubjectFriendlyName = "Customer Note Type";
                    functionFriendlyName = "Customer Note Types";
                    storedProcedureName = "[dbo].[spGetAllCustomerNoteType]";
                    break;
                case "CustomerTier":
                    dataSortingColumnName = "Customer Tier Description";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Customer Tier Id";
                    dataSubjectFriendlyName = "Customer Tier";
                    functionFriendlyName = "Customer Tiers";
                    storedProcedureName = "[dbo].[spGetAllCustomerTier]";
                    break;
                case "CustomerType":
                    dataSortingColumnName = "Customer Type";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Customer Type Id";
                    dataSubjectFriendlyName = "Customer Type";
                    functionFriendlyName = "Customer Types";
                    storedProcedureName = "[dbo].[spGetAllCustomerType]";
                    break;
                case "DeliveryMethod":
                    dataSortingColumnName = "Delivery Method";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Delivery Method Id";
                    dataSubjectFriendlyName = "Delivery Method";
                    functionFriendlyName = "Delivery Methods";
                    storedProcedureName = "[dbo].[spGetAllDeliveryMethod]";
                    break;
                case "MarketingCampaign":
                    dataSortingColumnName = "Marketing Campaign Id";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Marketing Campaign Id";
                    dataSubjectFriendlyName = "Marketing Campaign";
                    functionFriendlyName = "Marketing Campaigns";
                    storedProcedureName = "[dbo].[spGetAllMarketingCampaign]";
                    break;
                case "MarketingChannel":
                    dataSortingColumnName = "Marketing Channel Id";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Marketing Channel Id";
                    dataSubjectFriendlyName = "Marketing Channel";
                    functionFriendlyName = "Marketing Channelss";
                    storedProcedureName = "[dbo].[spGetAllMarketingChannel]";
                    break;
                case "Order":
                    dataSortingColumnName = "Order Id";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Order Id";
                    dataSubjectFriendlyName = "Order";
                    functionFriendlyName = "Orders";
                    storedProcedureName = "[dbo].[spGetAllOrder]";
                    break;
                case "OrderLineItemStatus":
                    dataSortingColumnName = "Order Line Item Status";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Order Line Item Status Id";
                    dataSubjectFriendlyName = "Order Line Item Status";
                    functionFriendlyName = "Order Line Item Statuses";
                    storedProcedureName = "[dbo].[spGetAllOrderLineItemStatus]";
                    break;
                case "OrderStatus":
                    dataSortingColumnName = "Order Status";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Order Status Id";
                    dataSubjectFriendlyName = "Order Status";
                    functionFriendlyName = "Order Statuses";
                    storedProcedureName = "[dbo].[spGetAllOrderStatus]";
                    break;
                case "PaymentMethod":
                    dataSortingColumnName = "Payment Method";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Payment Method Id";
                    dataSubjectFriendlyName = "Payment Method";
                    functionFriendlyName = "Payment Methods";
                    storedProcedureName = "[dbo].[spGetAllPaymentMethod]";
                    break;
                case "Product":
                    dataSortingColumnName = "Product Name";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Product Id";
                    dataSubjectFriendlyName = "Product";
                    functionFriendlyName = "Products";
                    storedProcedureName = "[dbo].[spGetAllProduct]";
                    break;
                case "ProductCategory":
                    dataSortingColumnName = "Product Category";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Product Category Id";
                    dataSubjectFriendlyName = "Product Category";
                    functionFriendlyName = "Product Categories";
                    storedProcedureName = "[dbo].[spGetAllProductCategory]";
                    break;
                case "ProductNoteType":
                    dataSortingColumnName = "Product Note Type";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Product Note Type Id";
                    dataSubjectFriendlyName = "Product Note Type";
                    functionFriendlyName = "Product Note Types";
                    storedProcedureName = "[dbo].[spGetAllProductNoteType]";
                    break;
                case "ProductSubCategory":
                    dataSortingColumnName = "Product Sub Category";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Product Sub Category Id";
                    dataSubjectFriendlyName = "Product Sub Category";
                    functionFriendlyName = "Product Sub Categories";
                    storedProcedureName = "[dbo].[spGetAllProductSubCategory]";
                    break;
                case "SalesRegion":
                    dataSortingColumnName = "Sales Region";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Sales Region Id";
                    dataSubjectFriendlyName = "Sales Region";
                    functionFriendlyName = "Sales Regions";
                    storedProcedureName = "[dbo].[spGetAllSalesRegion]";
                    break;
                case "SalesSubRegion":
                    dataSortingColumnName = "Sales Sub Region";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Sales Sub Region Id";
                    dataSubjectFriendlyName = "Sales Sub Region";
                    functionFriendlyName = "Sales Sub Regions";
                    storedProcedureName = "[dbo].[spGetAllSalesSubRegion]";
                    break;
                case "Supplier":
                    dataSortingColumnName = "Supplier Name";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Supplier Id";
                    dataSubjectFriendlyName = "Supplier";
                    functionFriendlyName = "Suppliers";
                    storedProcedureName = "[dbo].[spGetAllSupplier]";
                    break;
                case "SupplierNoteType":
                    dataSortingColumnName = "Supplier Note Type";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Supplier Note Type Id";
                    dataSubjectFriendlyName = "Supplier Note Type";
                    functionFriendlyName = "Supplier Note Types";
                    storedProcedureName = "[dbo].[spGetAllSupplierNoteType]";
                    break;
                case "TaxProfile":
                    dataSortingColumnName = "Tax Profile";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Tax Profile Id";
                    dataSubjectFriendlyName = "Tax Profile";
                    functionFriendlyName = "Tax Profiles";
                    storedProcedureName = "[dbo].[spGetAllTaxProfile]";
                    break;
                default:
                    this.Text = functionTitle;
                    break;
            }

            this.Text = $"{applicationTitlePrefix}{viewAllPrefix}{functionFriendlyName}";
            viewAllDataTitleLabel.Text = $"{viewAllPrefix}{functionFriendlyName}";
        }

        private async Task PopulateDataGrid_Load()
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubjectFriendlyName, _databaseConnectionSettings.DatabaseConnectionString);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataTable.DefaultView.Sort = $"{dataSortingColumnName} {dataSortingColumnOrder}";
                    viewAllDataDataGridView.AutoGenerateColumns = true;
                    viewAllDataDataGridView.DataSource = dataTable;
                    viewAllDataDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (viewAllDataDataGridView.Columns.Contains("Details"))
                    {
                        viewAllDataDataGridView.Columns.Remove("Details");
                    }
                    DataGridViewLinkColumn dataDetailLink = new DataGridViewLinkColumn
                    {
                        HeaderText = "Details",
                        Text = $"View {dataSubjectFriendlyName} Details",
                        UseColumnTextForLinkValue = true,
                        Name = "Details"
                    };
                    viewAllDataDataGridView.Columns.Add(dataDetailLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load {functionFriendlyName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void viewAllDataQuickFilterTextbox_TextChanged(object sender, EventArgs e)
        {
            if (viewAllDataDataGridView.DataSource is DataTable dataTable)
            {
                string filterText = viewAllDataQuickFilterTextbox.Text.Replace("'", "''");
                if (string.IsNullOrWhiteSpace(filterText))
                {
                    dataTable.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    var filterConditions = dataTable.Columns
                        .Cast<DataColumn>()
                        .Where(col => col.DataType == typeof(string) || col.DataType == typeof(object))
                        .Select(col => $"CONVERT([{col.ColumnName}], 'System.String') LIKE '%{filterText}%'");
                    dataTable.DefaultView.RowFilter = string.Join(" OR ", filterConditions);
                }
            }
        }

        private void viewAllDataDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == viewAllDataDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    switch(_functionTitle)
                    {
                        case "AccountManager":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid accountManagerId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                AccountManagerDetail accountManagerDetail = new AccountManagerDetail(accountManagerId);
                                accountManagerDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "CompanyConfiguration":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid companyConfigurationId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                CompanyConfigurationDetail companyConfigurationDetail = new CompanyConfigurationDetail(companyConfigurationId);
                                companyConfigurationDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "Currency":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid currencyId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                CurrencyDetail currencyDetail = new CurrencyDetail(currencyId);
                                currencyDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "CurrencyConversion":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid currencyConversionId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                CurrencyConversionDetail currencyConversionDetail = new CurrencyConversionDetail(currencyConversionId);
                                currencyConversionDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "Customer":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid customerId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                CustomerDetail customerDetail = new CustomerDetail(customerId);
                                customerDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "CustomerNoteType":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid customerNoteTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MetadataSimpleDetail metadataSimpleDetail = new MetadataSimpleDetail(customerNoteTypeId, _functionTitle);
                                metadataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "CustomerTier":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid customerTierId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                CustomerTierDetail customerTierDetail = new CustomerTierDetail(customerTierId);
                                customerTierDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "CustomerType":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid customerTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MetadataSimpleDetail metadataSimpleDetail = new MetadataSimpleDetail(customerTypeId, _functionTitle);
                                metadataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "DeliveryMethod":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid deliveryMethodId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                DeliveryMethodDetail deliveryMethodDetail = new DeliveryMethodDetail(deliveryMethodId);
                                deliveryMethodDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "MarketingCampaign":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid marketingCampaignId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MarketingCampaignDetail marketingCampaignDetail = new MarketingCampaignDetail(marketingCampaignId);
                                marketingCampaignDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "MarketingChannel":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid marketingChannelId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MetadataSimpleDetail metadataSimpleDetail = new MetadataSimpleDetail(marketingChannelId, _functionTitle);
                                metadataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "Order":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid orderId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                OrderDetail orderDetail = new OrderDetail(orderId);
                                orderDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "OrderLineItemStatus":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid orderLineItemStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MetadataSimpleDetail metadataSimpleDetail = new MetadataSimpleDetail(orderLineItemStatusId, _functionTitle);
                                metadataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "OrderStatus":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid orderStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MetadataSimpleDetail metadataSimpleDetail = new MetadataSimpleDetail(orderStatusId, _functionTitle);
                                metadataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "PaymentMethod":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid paymentMethodId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MetadataSimpleDetail metadataSimpleDetail = new MetadataSimpleDetail(paymentMethodId, _functionTitle);
                                metadataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "Product":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid productId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                ProductDetail productDetail = new ProductDetail(productId);
                                productDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "ProductCategory":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid productCategoryId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MetadataSimpleDetail metadataSimpleDetail = new MetadataSimpleDetail(productCategoryId, _functionTitle);
                                metadataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "ProductNoteType":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid productNoteTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MetadataSimpleDetail metadataSimpleDetail = new MetadataSimpleDetail(productNoteTypeId, _functionTitle);
                                metadataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "ProductSubCategory":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid productSubCategoryId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MetadataAdvancedDetail metadataAdvancedDetail = new MetadataAdvancedDetail(productSubCategoryId, _functionTitle);
                                metadataAdvancedDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "SalesRegion":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid salesRegionId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MetadataSimpleDetail metadataSimpleDetail = new MetadataSimpleDetail(salesRegionId, _functionTitle);
                                metadataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "SalesSubRegion":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid salesSubRegionId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MetadataAdvancedDetail metadataAdvancedDetail = new MetadataAdvancedDetail(salesSubRegionId, _functionTitle);
                                metadataAdvancedDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "Supplier":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid supplierId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                SupplierDetail supplierDetail = new SupplierDetail(supplierId);
                                supplierDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "SupplierNoteType":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid supplierNoteTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MetadataSimpleDetail metadataSimpleDetail = new MetadataSimpleDetail(supplierNoteTypeId, _functionTitle);
                                metadataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "TaxProfile":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid taxProfileId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                TaxProfileDetail taxProfileDetail = new TaxProfileDetail(taxProfileId);
                                taxProfileDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        default:
                            MessageBox.Show("Function not implemented.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open {dataSubjectFriendlyName} details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void viewAllDataRefreshDataButton_Click(object sender, EventArgs e)
        {
            await PopulateDataGrid_Load();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            await PopulateDataGrid_Load();
        }
    }
}