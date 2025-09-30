using CRM.Helpers;
using CRM.Interface;
using CRM.Model;
using CRM.Presentation.CompanyManagement.AccountManagement;
using CRM.Presentation.CompanyManagement.CompanyConfiguration;
using CRM.Presentation.CompanyManagement.CurrencyConversion;
using CRM.Presentation.CompanyManagement.Customer;
using CRM.Presentation.CompanyManagement.CustomerTier;
using CRM.Presentation.CompanyManagement.HTMLTemplate;
using CRM.Presentation.CompanyManagement.MarketingCampaign;
using CRM.Presentation.CompanyManagement.Order;
using CRM.Presentation.CompanyManagement.Supplier;
using CRM.Presentation.CompanyManagement.SupplierOrder;
using CRM.Presentation.Manufacturer;
using CRM.Presentation.MasterDataManagement;
using CRM.Presentation.Product;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.General
{
    public partial class ViewAllData : Form
    {
        private Guid _companyConfigurationId;
		private ActiveCompanyConfigurationHelper? _companyConfigHelper;
        private DataGridViewQuickSearchHelper? _dataGridViewQuickSearchHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly FunctionTitle _functionTitle;
        private readonly ModuleGroup _moduleGroup;
        private UIModelHelper _uiModelHelper = new UIModelHelper();
        private readonly string applicationTitlePrefix = "CRM - ";
        private string dataSortingColumnName;
        private DataSortingOrder dataSortingColumnOrder;
        private readonly Guid? _dataSubjectFilterId;
        private string dataSubjectFriendlyName;
        private string dataSubjectIdentityColumnFriendlyName;
        private string? dataSubjectParentIdentityId;
        private string functionFriendlyName;
        private string storedProcedureName;
        private readonly string viewAllPrefix = "View All ";

        public ViewAllData(FunctionTitle functionTitle, ModuleGroup moduleGroup, Guid? dataSubjectFilterId = null)
        {
            InitializeComponent();
            IntializeEventHandlers();
            _dataSubjectFilterId = dataSubjectFilterId;
            _functionTitle = functionTitle;
            _moduleGroup = moduleGroup;
			SetModuleTheme();
            LoadActiveCompanyConfigurationAsync();
			SetParameters();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            await PopulateDataGridView_Load();
        }

        private void IntializeEventHandlers()
        {
            viewAllDataDataGridView.CellContentClick += viewAllDataDataGridView_CellContentClick;
            _dataGridViewQuickSearchHelper = new DataGridViewQuickSearchHelper(viewAllDataQuickFilterTextBox, viewAllDataDataGridView);
        }

        private async void LoadActiveCompanyConfigurationAsync()
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(viewAllDataStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.LoadAsync();
            _companyConfigurationId = _companyConfigHelper.CompanyConfigurationId;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task PopulateDataGridView_Load()
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            try
            {
                DataTable? dataTable;

                if (_dataSubjectFilterId != null)
                {
                    var parameters = new[]
                    {
                        new StoredProcedureParameter
                        {
                            ParameterName = $"@{dataSubjectParentIdentityId}",
                            ParameterValue = dataSubjectParentIdentityId
                        }
                    };

                    dataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(dataSubjectFriendlyName, _databaseConnectionSettings, storedProcedureName, parameters.ToArray());
                }
                else
                {
                    dataTable = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(dataSubjectFriendlyName, _databaseConnectionSettings, storedProcedureName);
                }

                if (dataTable.Rows.Count == 0)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.NoDataFound", functionFriendlyName);
                }
                else
                {
                    // Filter by _companyConfigurationId if column exists
                    if (dataTable.Columns.Contains("Company Configuration Id") &&
                         _functionTitle != FunctionTitle.CompanyConfiguration)
                    {
                        if (dataTable.Columns["Company Configuration Id"].DataType == typeof(Guid))
                        {
                            string filter = $"[Company Configuration Id] = '{_companyConfigurationId}'";
                            dataTable.DefaultView.RowFilter = filter;
                        }
                    }

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
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", functionFriendlyName, ex.Message);
            }
        }

        private void SetModuleTheme()
        {
            ModuleThemeHelper.ApplyTheme(this, _moduleGroup);

            switch (_moduleGroup)
            {
                case ModuleGroup.CompanyManagement:
                    viewAllDataDataGridView.BackgroundColor = Color.LemonChiffon;
                    break;
                case ModuleGroup.CustomerManagement:
                    viewAllDataDataGridView.BackgroundColor = Color.LightGreen;
                    break;
                case ModuleGroup.MarketingManagement:
                    viewAllDataDataGridView.BackgroundColor = Color.NavajoWhite;
                    break;
                case ModuleGroup.OrderManagement:
                    viewAllDataDataGridView.BackgroundColor = Color.LightSalmon;
                    break;
                case ModuleGroup.ProductManagement:
                    viewAllDataDataGridView.BackgroundColor = Color.SkyBlue;
                    break;
                case ModuleGroup.SupplierManagement:
                    viewAllDataDataGridView.BackgroundColor = Color.MediumAquamarine;
                    break;
                default:
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.NotImplemented", _moduleGroup.ToString());
                    break;
            }
        }

        private void SetParameters()
        {
            var dataSubjectProperties = _uiModelHelper.GetDataSubjectProperties(_functionTitle);
            if (dataSubjectProperties == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", _functionTitle.ToString());
                return;
            }

            dataSortingColumnName = dataSubjectProperties.DataSubject.DataSubjectSortingColumnName;
            dataSortingColumnOrder = dataSubjectProperties.DataSubject.DataSubjectSortingColumnOrder;
            dataSubjectFriendlyName = dataSubjectProperties.DataSubject.DataSubjectFriendlyName;

            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName))
            {
                dataSubjectIdentityColumnFriendlyName = dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName;
            }
            
            functionFriendlyName = dataSubjectProperties.DataSubject.DataSubjectPlural;
            storedProcedureName = dataSubjectProperties.DataSubject.DataSubjectSelectAllStoredProcedureName;

            this.Text = $"{applicationTitlePrefix}{viewAllPrefix}{functionFriendlyName}";
            viewAllDataTitleLabel.Text = $"{viewAllPrefix}{functionFriendlyName}";
        }

        private async void changeActiveCompanyConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(viewAllDataStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.ShowChangeDialogAndReloadAsync(this);
        }

        private void viewAllDataDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == viewAllDataDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumnFriendlyName))
                    {
                        switch (_functionTitle)
                        {
                            case FunctionTitle.AccountManager:
                                Guid accountManagerId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                AccountManagerDetail accountManagerDetail = new AccountManagerDetail(accountManagerId);
                                accountManagerDetail.Show();
                                break;
                            case FunctionTitle.CompanyConfiguration:
                                Guid companyConfigurationId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                CompanyConfigurationDetail companyConfigurationDetail = new CompanyConfigurationDetail(companyConfigurationId);
                                companyConfigurationDetail.Show();
                                break;
                            case FunctionTitle.Country:
                                Guid countryId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                CountryDetail countryDetail = new CountryDetail(countryId);
                                countryDetail.Show();
                                break;
                            case FunctionTitle.Currency:
                                Guid currencyId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                CurrencyDetail currencyDetail = new CurrencyDetail(currencyId);
                                currencyDetail.Show();
                                break;
                            case FunctionTitle.CurrencyConversion:
                                Guid currencyConversionId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                CurrencyConversionDetail currencyConversionDetail = new CurrencyConversionDetail(currencyConversionId);
                                currencyConversionDetail.Show();
                                break;
                            case FunctionTitle.Customer:
                                Guid customerId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                CustomerDetail customerDetail = new CustomerDetail(customerId);
                                customerDetail.Show();
                                break;
                            case FunctionTitle.CustomerLeadNoteType:
                                Guid customerLeadNoteTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailCustomerLeadNoteType = new MasterDataSimpleDetail(customerLeadNoteTypeId, _functionTitle, ModuleGroup.CustomerManagement);
                                masterDataSimpleDetailCustomerLeadNoteType.Show();
                                break;
                            case FunctionTitle.CustomerLeadStatus:
                                Guid customerLeadStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailCustomerLeadStatus = new MasterDataSimpleDetail(customerLeadStatusId, _functionTitle, ModuleGroup.CustomerManagement);
                                masterDataSimpleDetailCustomerLeadStatus.Show();
                                break;
                            case FunctionTitle.CustomerLeadType:
                                Guid customerLeadTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataEnhancedDetail masterDataEnhancedDetailCustomerLeadType = new MasterDataEnhancedDetail(customerLeadTypeId, _functionTitle, ModuleGroup.CustomerManagement);
                                masterDataEnhancedDetailCustomerLeadType.Show();
                                break;
                            case FunctionTitle.CustomerNoteType:
                                Guid customerNoteTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailCustomerNoteType = new MasterDataSimpleDetail(customerNoteTypeId, _functionTitle, ModuleGroup.CustomerManagement);
                                masterDataSimpleDetailCustomerNoteType.Show();
                                break;
                            case FunctionTitle.CustomerTier:
                                Guid customerTierId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                CustomerTierDetail customerTierDetail = new CustomerTierDetail(customerTierId);
                                customerTierDetail.Show();
                                break;
                            case FunctionTitle.CustomerType:
                                Guid customerTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataEnhancedDetail masterDataEnhancedDetailCustomerType = new MasterDataEnhancedDetail(customerTypeId, _functionTitle, ModuleGroup.CustomerManagement);
                                masterDataEnhancedDetailCustomerType.Show();
                                break;
                            case FunctionTitle.DeliveryMethod:
                                Guid deliveryMethodId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                DeliveryMethodDetail deliveryMethodDetail = new DeliveryMethodDetail(deliveryMethodId);
                                deliveryMethodDetail.Show();
                                break;
                            case FunctionTitle.HTMLTemplate:
                                Guid htmlTemplateId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                HTMLTemplateDetail htmlTemplateDetail = new HTMLTemplateDetail(htmlTemplateId);
                                htmlTemplateDetail.Show();
                                break;
                            case FunctionTitle.HTMLTemplateType:
                                Guid htmlTemplateTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailHTMLTemplateType = new MasterDataSimpleDetail(htmlTemplateTypeId, _functionTitle, ModuleGroup.CompanyManagement);
                                masterDataSimpleDetailHTMLTemplateType.Show();
                                break;
                            case FunctionTitle.Manufacturer:
                                Guid manufacturerId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                ManufacturerDetail manufacturerDetail = new ManufacturerDetail(manufacturerId);
                                manufacturerDetail.Show();
                                break;
                            case FunctionTitle.MarketingCampaign:
                                Guid marketingCampaignId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MarketingCampaignDetail marketingCampaignDetail = new MarketingCampaignDetail(marketingCampaignId);
                                marketingCampaignDetail.Show();
                                break;
                            case FunctionTitle.MarketingCampaignStatus:
                                Guid marketingCampaignStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailMarketingCampaignStatus = new MasterDataSimpleDetail(marketingCampaignStatusId, _functionTitle, ModuleGroup.MarketingManagement);
                                masterDataSimpleDetailMarketingCampaignStatus.Show();
                                break;
                            case FunctionTitle.MarketingCampaignType:
                                Guid marketingCampaignTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailMarketingCampaignType = new MasterDataSimpleDetail(marketingCampaignTypeId, _functionTitle, ModuleGroup.MarketingManagement);
                                masterDataSimpleDetailMarketingCampaignType.Show();
                                break;
                            case FunctionTitle.MarketingChannel:
                                Guid marketingChannelId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailMarketingChannel = new MasterDataSimpleDetail(marketingChannelId, _functionTitle, ModuleGroup.MarketingManagement);
                                masterDataSimpleDetailMarketingChannel.Show();
                                break;
                            case FunctionTitle.Order:
                                Guid orderId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                OrderDetail orderDetail = new OrderDetail(orderId);
                                orderDetail.Show();
                                break;
                            case FunctionTitle.OrderLineItemStatus:
                                Guid orderLineItemStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailOrderLineItemStatus = new MasterDataSimpleDetail(orderLineItemStatusId, _functionTitle, ModuleGroup.OrderManagement);
                                masterDataSimpleDetailOrderLineItemStatus.Show();
                                break;
                            case FunctionTitle.OrderPaymentStatus:
                                Guid orderPaymentStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailOrderPaymentStatus = new MasterDataSimpleDetail(orderPaymentStatusId, _functionTitle, ModuleGroup.OrderManagement);
                                masterDataSimpleDetailOrderPaymentStatus.Show();
                                break;
                            case FunctionTitle.OrderStatus:
                                Guid orderStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailOrderStatus = new MasterDataSimpleDetail(orderStatusId, _functionTitle, ModuleGroup.OrderManagement);
                                masterDataSimpleDetailOrderStatus.Show();
                                break;
                            case FunctionTitle.OrderType:
                                Guid orderTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailOrderType = new MasterDataSimpleDetail(orderTypeId, _functionTitle, ModuleGroup.OrderManagement);
                                masterDataSimpleDetailOrderType.Show();
                                break;
                            case FunctionTitle.PaymentMethod:
                                Guid paymentMethodId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailPaymentMethod = new MasterDataSimpleDetail(paymentMethodId, _functionTitle, ModuleGroup.CompanyManagement);
                                masterDataSimpleDetailPaymentMethod.Show();
                                break;
                            case FunctionTitle.Product:
                                Guid productId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                ProductDetail productDetail = new ProductDetail(productId);
                                productDetail.Show();
                                break;
                            case FunctionTitle.ProductCategory:
                                Guid productCategoryId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailProductCategory = new MasterDataSimpleDetail(productCategoryId, _functionTitle, ModuleGroup.ProductManagement);
                                masterDataSimpleDetailProductCategory.Show();
                                break;
                            case FunctionTitle.ProductFamily:
                                Guid productFamilyId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailProductFamily = new MasterDataSimpleDetail(productFamilyId, _functionTitle, ModuleGroup.ProductManagement);
                                masterDataSimpleDetailProductFamily.Show();
                                break;
                            case FunctionTitle.ProductNoteType:
                                Guid productNoteTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailProductNoteType = new MasterDataSimpleDetail(productNoteTypeId, _functionTitle, ModuleGroup.ProductManagement);
                                masterDataSimpleDetailProductNoteType.Show();
                                break;
                            case FunctionTitle.ProductSubCategory:
                                Guid productSubCategoryId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataAdvancedDetail masterDataAdvancedDetailProductSubCategory = new MasterDataAdvancedDetail(productSubCategoryId, _functionTitle, ModuleGroup.ProductManagement);
                                masterDataAdvancedDetailProductSubCategory.Show();
                                break;
                            case FunctionTitle.PromotionTargetType:
                                Guid promotionTargetTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataEnhancedDetail masterDataEnhancedDetailPromotionTargetType = new MasterDataEnhancedDetail(promotionTargetTypeId, _functionTitle, ModuleGroup.MarketingManagement);
                                masterDataEnhancedDetailPromotionTargetType.Show();
                                break;
                            case FunctionTitle.PromotionType:
                                Guid promotionTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailPromotionType = new MasterDataSimpleDetail(promotionTypeId, _functionTitle, ModuleGroup.MarketingManagement);
                                masterDataSimpleDetailPromotionType.Show();
                                break;
                            case FunctionTitle.SalesRegion:
                                Guid salesRegionId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailSalesRegion = new MasterDataSimpleDetail(salesRegionId, _functionTitle, ModuleGroup.CompanyManagement);
                                masterDataSimpleDetailSalesRegion.Show();
                                break;
                            case FunctionTitle.SalesSubRegion:
                                Guid salesSubRegionId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataAdvancedDetail masterDataAdvancedDetailSalesSubRegion = new MasterDataAdvancedDetail(salesSubRegionId, _functionTitle, ModuleGroup.CompanyManagement);
                                masterDataAdvancedDetailSalesSubRegion.Show();
                                break;
                            case FunctionTitle.Supplier:
                                Guid supplierId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                SupplierDetail supplierDetail = new SupplierDetail(supplierId);
                                supplierDetail.Show();
                                break;
                            case FunctionTitle.SupplierNoteType:
                                Guid supplierNoteTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailSupplierNoteType = new MasterDataSimpleDetail(supplierNoteTypeId, _functionTitle, ModuleGroup.SupplierManagement);
                                masterDataSimpleDetailSupplierNoteType.Show();
                                break;
                            case FunctionTitle.SupplierOrder:
                                Guid supplierOrderId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                SupplierOrderDetail supplierOrderDetail = new SupplierOrderDetail(supplierOrderId);
                                supplierOrderDetail.Show();
                                break;
                            case FunctionTitle.SupplierOrderLineItemStatus:
                                Guid supplierOrderLineItemStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailSupplierOrderLineItemStatus = new MasterDataSimpleDetail(supplierOrderLineItemStatusId, _functionTitle, ModuleGroup.SupplierManagement);
                                masterDataSimpleDetailSupplierOrderLineItemStatus.Show();
                                break;
                            case FunctionTitle.SupplierOrderPaymentStatus:
                                Guid supplierOrderPaymentStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailSupplierOrderPaymentStatus = new MasterDataSimpleDetail(supplierOrderPaymentStatusId, _functionTitle, ModuleGroup.SupplierManagement);
                                masterDataSimpleDetailSupplierOrderPaymentStatus.Show();
                                break;
                            case FunctionTitle.SupplierOrderStatus:
                                Guid supplierOrderStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailSupplierOrderStatus = new MasterDataSimpleDetail(supplierOrderStatusId, _functionTitle, ModuleGroup.SupplierManagement);
                                masterDataSimpleDetailSupplierOrderStatus.Show();
                                break;
                            case FunctionTitle.TaxProfile:
                                Guid taxProfileId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                TaxProfileDetail taxProfileDetail = new TaxProfileDetail(taxProfileId);
                                taxProfileDetail.Show();
                                break;
                            case FunctionTitle.WholesaleDeliveryType:
                                Guid wholesaleDeliveryTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumnFriendlyName].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailWholesaleDeliveryType = new MasterDataSimpleDetail(wholesaleDeliveryTypeId, _functionTitle, ModuleGroup.SupplierManagement);
                                masterDataSimpleDetailWholesaleDeliveryType.Show();
                                break;
                            default:
                                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", _functionTitle.ToString());
                                break;
                        }
                    }
                    else
                    {
                        ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.IdColumnNotFound", dataSubjectIdentityColumnFriendlyName);
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubjectFriendlyName, ex.Message);
                }
            }
        }

        private void viewAllDataExportCSVButton_Click(object sender, EventArgs e)
        {
            var exportDataGridView = new DataGridView();

            foreach (DataGridViewColumn col in viewAllDataDataGridView.Columns)
            {
                if (col.Name != "Details")
                {
                    exportDataGridView.Columns.Add((DataGridViewColumn)col.Clone());
                }
            }

            if (viewAllDataDataGridView.DataSource is DataTable dataTable)
            {
                DataView filteredView = dataTable.DefaultView;
                foreach (DataRowView rowView in filteredView)
                {
                    var newRow = new DataGridViewRow();
                    foreach (DataGridViewColumn col in exportDataGridView.Columns)
                    {
                        var cell = new DataGridViewTextBoxCell();
                        cell.Value = rowView.Row[col.Name];
                        newRow.Cells.Add(cell);
                    }
                    exportDataGridView.Rows.Add(newRow);
                }
            }
            else
            {
                foreach (DataGridViewRow row in viewAllDataDataGridView.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var newRow = new DataGridViewRow();
                        foreach (DataGridViewColumn col in exportDataGridView.Columns)
                        {
                            var cell = new DataGridViewTextBoxCell();
                            cell.Value = row.Cells[col.Name].Value;
                            newRow.Cells.Add(cell);
                        }
                        exportDataGridView.Rows.Add(newRow);
                    }
                }
            }
            CSVExportService.ExportDataGridViewToCSV(exportDataGridView, functionFriendlyName);
        }

        private async void viewAllDataRefreshDataButton_Click(object sender, EventArgs e)
        {
            await PopulateDataGridView_Load();
        }
    }
}