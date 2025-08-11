using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateMasterDataSimple : Form
    {
        private readonly string _functionTitle;
        private readonly string _moduleGroup;
        private readonly string applicationTitlePrefix = "CRM - Create ";
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private string dataSubjectFriendlyName;
        private string dataSubjectName;
        private string dataSubjectStoredProcedureName;
        private string dataSubjectStoredProcedureParameterPrefix;
        private readonly string titleLabelPrefix = "Create ";

        public CreateMasterDataSimple(string functionTitle, string moduleGroup)
        {
            InitializeComponent();
            _functionTitle = functionTitle;
            LoadDatabaseConnectionSettingsAsync();
            _moduleGroup = moduleGroup;
            SetModuleTheme(_moduleGroup);
            SetParameters(_functionTitle);
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
                    dataSubjectStoredProcedureName = "spCreateCustomerLeadNoteType";
                    dataSubjectStoredProcedureParameterPrefix = "customerLeadNoteType";
                    break;
                case "CustomerLeadStatus":
                    dataSubjectFriendlyName = "Customer Lead Status";
                    dataSubjectStoredProcedureName = "spCreateCustomerLeadStatus";
                    dataSubjectStoredProcedureParameterPrefix = "customerLeadStatus";
                    break;
                case "CustomerNoteType":
                    dataSubjectFriendlyName = "Customer Note Type";
                    dataSubjectStoredProcedureName = "spCreateCustomerNoteType";
                    dataSubjectStoredProcedureParameterPrefix = "customerNoteType";
                    break;
                case "HTMLTemplateType":
                    dataSubjectFriendlyName = "HTML Template Type";
                    dataSubjectStoredProcedureName = "spCreateHTMLTemplateType";
                    dataSubjectStoredProcedureParameterPrefix = "htmlTemplateType";
                    break;
                case "MarketingCampaignStatus":
                    dataSubjectFriendlyName = "Marketing Campaign Status";
                    dataSubjectStoredProcedureName = "spCreateMarketingCampaignStatus";
                    dataSubjectStoredProcedureParameterPrefix = "marketingCampaignStatus";
                    break;
                case "MarketingCampaignType":
                    dataSubjectFriendlyName = "Marketing Campaign Tyoe";
                    dataSubjectStoredProcedureName = "spCreateMarketingCampaignType";
                    dataSubjectStoredProcedureParameterPrefix = "marketingCampaignType";
                    break;
                case "MarketingChannel":
                    dataSubjectFriendlyName = "Marketing Channel";
                    dataSubjectStoredProcedureName = "spCreateMarketingChannel";
                    dataSubjectStoredProcedureParameterPrefix = "marketingChannel";
                    break;
                case "OrderLineItemStatus":
                    dataSubjectFriendlyName = "Order Line Item Status";
                    dataSubjectStoredProcedureName = "spCreateOrderLineItemStatus";
                    dataSubjectStoredProcedureParameterPrefix = "orderLineItemStatus";
                    break;
                case "OrderPaymentStatus":
                    dataSubjectFriendlyName = "Order Payment Status";
                    dataSubjectStoredProcedureName = "spCreateOrderPaymentStatus";
                    dataSubjectStoredProcedureParameterPrefix = "orderPaymentStatus";
                    break;
                case "OrderStatus":
                    dataSubjectFriendlyName = "Order Status";
                    dataSubjectStoredProcedureName = "spCreateOrderStatus";
                    dataSubjectStoredProcedureParameterPrefix = "orderStatus";
                    break;
                case "OrderType":
                    dataSubjectFriendlyName = "Order Type";
                    dataSubjectStoredProcedureName = "spCreateOrderType";
                    dataSubjectStoredProcedureParameterPrefix = "orderType";
                    break;
                case "PaymentMethod":
                    dataSubjectFriendlyName = "Payment Method";
                    dataSubjectStoredProcedureName = "spCreatePaymentMethod";
                    dataSubjectStoredProcedureParameterPrefix = "paymentMethod";
                    break;
                case "ProductCategory":
                    dataSubjectFriendlyName = "Product Category";
                    dataSubjectStoredProcedureName = "spCreateProductCategory";
                    dataSubjectStoredProcedureParameterPrefix = "productCategory";
                    break;
                case "ProductFamily":
                    dataSubjectFriendlyName = "Product Family";
                    dataSubjectStoredProcedureName = "spCreateProductFamily";
                    dataSubjectStoredProcedureParameterPrefix = "productFamily";
                    break;
                case "ProductNoteType":
                    dataSubjectFriendlyName = "Product Note Type";
                    dataSubjectStoredProcedureName = "spCreateProductNoteType";
                    dataSubjectStoredProcedureParameterPrefix = "productNoteType";
                    break;
                case "PromotionType":
                    dataSubjectFriendlyName = "Promotion Type";
                    dataSubjectStoredProcedureName = "spCreatePromotionType";
                    dataSubjectStoredProcedureParameterPrefix = "promotionType";
                    break;
                case "SalesRegion":
                    dataSubjectFriendlyName = "Sales Region";
                    dataSubjectStoredProcedureName = "spCreateSalesRegion";
                    dataSubjectStoredProcedureParameterPrefix = "salesRegion";
                    break;
                case "SupplierNoteType":
                    dataSubjectFriendlyName = "Supplier Note Type";
                    dataSubjectStoredProcedureName = "spCreateSupplierNoteType";
                    dataSubjectStoredProcedureParameterPrefix = "supplierNoteType";
                    break;
                case "SupplierOrderLineItemStatus":
                    dataSubjectFriendlyName = "Supplier Order Line Item Status";
                    dataSubjectStoredProcedureName = "spCreateSupplierOrderLineItemStatus";
                    dataSubjectStoredProcedureParameterPrefix = "supplierOrderLineItemStatus";
                    break;
                case "SupplierOrderPaymentStatus":
                    dataSubjectFriendlyName = "Supplier Order Payment Status";
                    dataSubjectStoredProcedureName = "spCreateSupplierOrderPaymentStatus";
                    dataSubjectStoredProcedureParameterPrefix = "supplierOrderPaymentStatus";
                    break;
                case "SupplierOrderStatus":
                    dataSubjectFriendlyName = "Supplier Order Status";
                    dataSubjectStoredProcedureName = "spCreateSupplierOrderStatus";
                    dataSubjectStoredProcedureParameterPrefix = "supplierOrderStatus";
                    break;
                default:
                    this.Text = functionTitle;
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", functionTitle);
                    break;
            }

            dataSubjectName = functionTitle;

            createMasterDataSimpleTitleLabel.Text = $"{titleLabelPrefix}{dataSubjectFriendlyName}";
            createMasterDataSimpleMasterDataTypeTextboxLabel.Text = $"{dataSubjectFriendlyName}*";
            createMasterDataSimpleActiveStatusCheckbox.Text = $"Active {dataSubjectFriendlyName}";
            this.Text = $"{applicationTitlePrefix}{dataSubjectFriendlyName}";
        }

        private async void createMasterDataSimpleSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createMasterDataSimpleActiveStatusCheckbox.Checked;
            string dataSubjectValue = createMasterDataSimpleMasterDataTypeTextbox.Text.TrimEnd();

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
                var parameters = new[]
                {
                    new Parameter
                    {
                        ParameterName = "activeStatus",
                        ParameterValue = activeStatus
                    },
                    new Parameter
                    {
                        ParameterName = $"@{dataSubjectStoredProcedureParameterPrefix}",
                        ParameterValue = dataSubjectValue
                    }
                };

                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(dataSubjectStoredProcedureName, parameters, dataSubjectName, operationType);
                this.Close();
            }
        }
    }
}