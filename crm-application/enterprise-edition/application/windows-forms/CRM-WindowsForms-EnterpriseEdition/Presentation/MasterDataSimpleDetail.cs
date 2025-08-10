using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class MasterDataSimpleDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _dataSubjectId;
        private readonly string _functionTitle;
        private readonly string _moduleGroup;
        private readonly string applicationTitlePrefix = "CRM - ";
        private bool? dataSubjectActiveStatusOriginalValue;
        private string dataSubjectFriendlyName;
        private string dataSubjectGetStoredProcedureName;
        private string dataSubjectIdFriendlyName;
        private string dataSubjectIdName;
        private string dataSubjectName;
        private string? dataSubjectOriginalValue;
        private string dataSubjectUpdateStoredProcedureName;
        private string dataSubjectUpdateStoredProcedureParameterPrefix;
        private readonly string titleLabelSuffix= " Detail";

        public MasterDataSimpleDetail(Guid dataSubjectId, string functionTitle, string moduleGroup)
        {
            InitializeComponent();
            _dataSubjectId = dataSubjectId;
            _functionTitle = functionTitle;
            _moduleGroup = moduleGroup;
            SetModuleTheme(_moduleGroup);
            masterDataSimpleDetailToggleEditModeButton.Click += new EventHandler(masterDataSimpleDetailToggleEditModeButton_Click);
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
                    break;
                case "CustomerManagement":
                    this.BackColor = Color.LightGreen;
                    break;
                case "MarketingManagement":
                    this.BackColor = Color.NavajoWhite;
                    break;
                case "OrderManagement":
                    this.BackColor = Color.LightSalmon;
                    break;
                case "ProductManagement":
                    this.BackColor = Color.SkyBlue;
                    break;
                case "SupplierManagement":
                    this.BackColor = Color.MediumAquamarine;
                    break;
                default:
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.NotImplemented", moduleGroup);
                    break;
            }
        }

        private void SetParameters(string functionTitle)
        {
            switch (functionTitle)
            {
                case "CustomerLeadNoteType":
                    dataSubjectFriendlyName = "Customer Lead Note Type";
                    dataSubjectGetStoredProcedureName = "spGetCustomerLeadNoteType";
                    dataSubjectIdFriendlyName = "Customer Lead Note Type Id";
                    dataSubjectIdName = "CustomerLeadNoteTypeId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateCustomerLeadNoteType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "customerLeadNoteType";
                    break;
                case "CustomerLeadStatus":
                    dataSubjectFriendlyName = "Customer Lead Status";
                    dataSubjectGetStoredProcedureName = "spGetCustomerLeadStatus";
                    dataSubjectIdFriendlyName = "Customer Lead Status Id";
                    dataSubjectIdName = "CustomerLeadStatusId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateCustomerLeadStatus";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "customerLeadStatus";
                    break;
                case "CustomerNoteType":
                    dataSubjectFriendlyName = "Customer Note Type";
                    dataSubjectGetStoredProcedureName = "spGetCustomerNoteType";
                    dataSubjectIdFriendlyName = "Customer Note Type Id";
                    dataSubjectIdName = "CustomerNoteTypeId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateCustomerNoteType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "customerNoteType";
                    break;
                case "HTMLTemplateType":
                    dataSubjectFriendlyName = "HTML Template Type";
                    dataSubjectGetStoredProcedureName = "spGetHTMLTemplateType";
                    dataSubjectIdFriendlyName = "HTML Template Type Id";
                    dataSubjectIdName = "HTMLTemplateTypeId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateHTMLTemplateType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "htmlTemplateType";
                    break;
                case "MarketingCampaignStatus":
                    dataSubjectFriendlyName = "Marketing Campaign Status";
                    dataSubjectGetStoredProcedureName = "spGetMarketingCampaignStatus";
                    dataSubjectIdFriendlyName = "Marketing Campaign Status Id";
                    dataSubjectIdName = "MarketingCampaignStatusId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateMarketingCampaignStatus";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "marketingCampaignStatus";
                    break;
                case "MarketingCampaignType":
                    dataSubjectFriendlyName = "Marketing Campaign Type";
                    dataSubjectGetStoredProcedureName = "spGetMarketingCampaignType";
                    dataSubjectIdFriendlyName = "Marketing Campaign Type Id";
                    dataSubjectIdName = "MarketingCampaignTypeId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateMarketingCampaignType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "marketingCampaignType";
                    break;
                case "MarketingChannel":
                    dataSubjectFriendlyName = "Marketing Channel";
                    dataSubjectGetStoredProcedureName = "spGetMarketingChannel";
                    dataSubjectIdFriendlyName = "Marketing Channel Id";
                    dataSubjectIdName = "MarketingChannelId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateMarketingChannel";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "marketingChannel";
                    break;
                case "OrderLineItemStatus":
                    dataSubjectFriendlyName = "Order Line Item Status";
                    dataSubjectGetStoredProcedureName = "spGetOrderLineItemStatus";
                    dataSubjectIdFriendlyName = "Order Line Item Status Id";
                    dataSubjectIdName = "OrderLineItemStatusId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateOrderLineItemStatus";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "orderLineItemStatus";
                    break;
                case "OrderPaymentStatus":
                    dataSubjectFriendlyName = "Order Payment Status";
                    dataSubjectGetStoredProcedureName = "spGetOrderPaymentStatus";
                    dataSubjectIdFriendlyName = "Order Payment Status Id";
                    dataSubjectIdName = "OrderPaymentStatusId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateOrderPaymentStatus";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "orderPaymentStatus";
                    break;
                case "OrderStatus":
                    dataSubjectFriendlyName = "Order Status";
                    dataSubjectGetStoredProcedureName = "spGetOrderStatus";
                    dataSubjectIdFriendlyName = "Order Status Id";
                    dataSubjectIdName = "OrderStatusId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateOrderStatus";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "orderStatus";
                    break;
                case "OrderType":
                    dataSubjectFriendlyName = "Order Type";
                    dataSubjectGetStoredProcedureName = "spGetOrderType";
                    dataSubjectIdFriendlyName = "Order Type Id";
                    dataSubjectIdName = "OrderTypeId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateOrderType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "orderType";
                    break;
                case "PaymentMethod":
                    dataSubjectFriendlyName = "Payment Method";
                    dataSubjectGetStoredProcedureName = "spGetPaymentMethod";
                    dataSubjectIdFriendlyName = "Payment Method Id";
                    dataSubjectIdName = "PaymentMethodId";
                    dataSubjectUpdateStoredProcedureName = "spUpdatePaymentMethod";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "paymentMethod";
                    break;
                case "ProductCategory":
                    dataSubjectFriendlyName = "Product Category";
                    dataSubjectGetStoredProcedureName = "spGetProductCategory";
                    dataSubjectIdFriendlyName = "Product Category Id";
                    dataSubjectIdName = "ProductCategoryId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateProductCategory";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "productCategory";
                    break;
                case "ProductFamily":
                    dataSubjectFriendlyName = "Product Family";
                    dataSubjectGetStoredProcedureName = "spGetProductFamily";
                    dataSubjectIdFriendlyName = "Product Family Id";
                    dataSubjectIdName = "ProductFamilyId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateProductFamily";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "productFamily";
                    break;
                case "ProductNoteType":
                    dataSubjectFriendlyName = "Product Note Type";
                    dataSubjectGetStoredProcedureName = "spGetProductNoteType";
                    dataSubjectIdFriendlyName = "Product Note Type Id";
                    dataSubjectIdName = "ProductNoteTypeId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateProductNoteType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "productNoteType";
                    break;
                case "PromotionType":
                    dataSubjectFriendlyName = "Promotion Type";
                    dataSubjectGetStoredProcedureName = "spGetPromotionType";
                    dataSubjectIdFriendlyName = "Promotion Type Id";
                    dataSubjectIdName = "PromotionTypeId";
                    dataSubjectUpdateStoredProcedureName = "spUpdatePromotionType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "promotionType";
                    break;
                case "SalesRegion":
                    dataSubjectFriendlyName = "Sales Region";
                    dataSubjectGetStoredProcedureName = "spGetSalesRegion";
                    dataSubjectIdFriendlyName = "Sales Region Id";
                    dataSubjectIdName = "SalesRegionId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateSalesRegion";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "salesRegion";
                    break;
                case "SupplierNoteType":
                    dataSubjectFriendlyName = "Supplier Note Type";
                    dataSubjectGetStoredProcedureName = "spGetSupplierNoteType";
                    dataSubjectIdFriendlyName = "Supplier Note Type Id";
                    dataSubjectIdName = "SupplierNoteTypeId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateSupplierNoteType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "supplierNoteType";
                    break;
                case "SupplierOrderLineItemStatus":
                    dataSubjectFriendlyName = "Supplier Order Line Item Status";
                    dataSubjectGetStoredProcedureName = "spGetSupplierOrderLineItemStatus";
                    dataSubjectIdFriendlyName = "Supplier Order Line Item Status Id";
                    dataSubjectIdName = "SupplierOrderLineItemStatusId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrderLineItemStatus";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "supplierOrderLineItemStatus";
                    break;
                case "SupplierOrderPaymentStatus":
                    dataSubjectFriendlyName = "Supplier Order Payment Status";
                    dataSubjectGetStoredProcedureName = "spGetSupplierOrderPaymentStatus";
                    dataSubjectIdFriendlyName = "Supplier Order Payment Status Id";
                    dataSubjectIdName = "SupplierOrderPaymentStatusId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrderPaymentStatus";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "supplierOrderPaymentStatus";
                    break;
                case "SupplierOrderStatus":
                    dataSubjectFriendlyName = "Supplier Order Status";
                    dataSubjectGetStoredProcedureName = "spGetSupplierOrderStatus";
                    dataSubjectIdFriendlyName = "Supplier Order Status Id";
                    dataSubjectIdName = "SupplierOrderStatusId";
                    dataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrderStatus";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "supplierOrderStatus";
                    break;
                default:
                    this.Text = functionTitle;
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", functionTitle);
                    break;
            }

            dataSubjectName = functionTitle;

            masterDataSimpleDetailTitleLabel.Text = $"{dataSubjectFriendlyName}{titleLabelSuffix}";
            masterDataSimpleDetailDataSubjectIdTextboxLabel.Text = dataSubjectIdFriendlyName;
            masterDataSimpleDetailDataSubjectTextboxLabel.Text = dataSubjectFriendlyName;
            masterDataSimpleDetailActiveStatusCheckbox.Text = $"Active {dataSubjectFriendlyName}";
            masterDataSimpleDetailUpdateDataSubjectButton.Text = $"Update {dataSubjectFriendlyName}";
            this.Text = $"{applicationTitlePrefix}{dataSubjectFriendlyName}{titleLabelSuffix}";
        }

        private async void MasterDataSimpleDetailMasterDataInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = $"@{dataSubjectUpdateStoredProcedureParameterPrefix}Id",
                    ParameterValue = _dataSubjectId
                }
            };

            try
            {
                DataTable? masterDataSimpleDetailDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(
                    dataSubjectGetStoredProcedureName,
                    parameters.ToArray(),
                    dataSubjectName);

                if (masterDataSimpleDetailDataTable != null)
                {
                    DataRow masterDataSimpleDetailDataRow = masterDataSimpleDetailDataTable.Rows[0];
                    masterDataSimpleDetailDataSubjectIdTextbox.Text = masterDataSimpleDetailDataRow[dataSubjectIdFriendlyName].ToString();
                    masterDataSimpleDetailDataSubjectTextbox.Text = masterDataSimpleDetailDataRow[dataSubjectFriendlyName].ToString();
                    masterDataSimpleDetailCreatedByTextbox.Text = masterDataSimpleDetailDataRow["Created By"].ToString();
                    masterDataSimpleDetailCreatedTimestampTextbox.Text = masterDataSimpleDetailDataRow["Created Timestamp UTC"].ToString();
                    masterDataSimpleDetailLastUpdatedByTextbox.Text = masterDataSimpleDetailDataRow["Modified By"].ToString();
                    masterDataSimpleDetailLastUpdatedTimestampTextbox.Text = masterDataSimpleDetailDataRow["Modified Timestamp UTC"].ToString();
                    masterDataSimpleDetailActiveStatusCheckbox.Checked = (bool)masterDataSimpleDetailDataRow["Active Status"];

                    dataSubjectOriginalValue = masterDataSimpleDetailDataRow[dataSubjectFriendlyName].ToString();
                    dataSubjectActiveStatusOriginalValue = (bool)masterDataSimpleDetailDataRow["Active Status"];

                    this.Text += $" ({dataSubjectOriginalValue})";
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.NoDataFound", dataSubjectFriendlyName);
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubjectFriendlyName, ex.Message);
            }
        }

        private async void masterDataSimpleDetailUpdateDataSubjectButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = masterDataSimpleDetailActiveStatusCheckbox.Checked;
            string dataSubjectValue = masterDataSimpleDetailDataSubjectTextbox.Text.TrimEnd();

            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
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
                            ParameterName = "activeStatus",
                            ParameterValue = activeStatus
                        },
                        new Parameter
                        {
                            ParameterName = $"@{dataSubjectUpdateStoredProcedureParameterPrefix}Id",
                            ParameterValue = _dataSubjectId
                        },
                        new Parameter
                        {
                            ParameterName = $"@{dataSubjectUpdateStoredProcedureParameterPrefix}",
                            ParameterValue = dataSubjectValue
                        }
                    };

                    string operationType = "update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(dataSubjectUpdateStoredProcedureName, parameters, dataSubjectName, operationType);
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
            SetParameters(_functionTitle);
            MasterDataSimpleDetailMasterDataInformation_Load(this, EventArgs.Empty);
        }

        private void masterDataSimpleDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            masterDataSimpleDetailDataSubjectTextbox.ReadOnly = !masterDataSimpleDetailDataSubjectTextbox.ReadOnly;
            masterDataSimpleDetailActiveStatusCheckbox.Enabled = !masterDataSimpleDetailActiveStatusCheckbox.Enabled;
            masterDataSimpleDetailUpdateDataSubjectButton.Enabled = !masterDataSimpleDetailUpdateDataSubjectButton.Enabled;
        }
    }
}