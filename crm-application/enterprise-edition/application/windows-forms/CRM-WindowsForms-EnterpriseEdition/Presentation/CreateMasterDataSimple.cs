using CRM_WindowsForms_EnterpriseEdition.Helpers;
using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Services;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateMasterDataSimple : Form
    {
        private Guid? _companyConfigurationId;
        private ActiveCompanyConfigurationHelper? _companyConfigHelper;
        private readonly string _functionTitle;
        private readonly string _moduleGroup;
        private readonly string applicationTitlePrefix = "CRM - Create ";
        private List<string> companyConfigurationEnabledDataSubjects;
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
            SetModuleTheme();
            SetParameters(_functionTitle);
        }

        private async void LoadActiveCompanyConfigurationAsync()
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(createMasterDataSimpleStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.LoadAsync();
            _companyConfigurationId = _companyConfigHelper.CompanyConfigurationId;
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void SetModuleTheme()
        {
            ModuleThemeHelper.ApplyTheme(this, _moduleGroup);
        }

        private void SetParameters(string functionTitle)
        {
            companyConfigurationEnabledDataSubjects = new List<string>
            {
                "ProductCategory",
                "ProductFamily",
                "SalesRegion",
            };

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
                case "WholesaleDeliveryType":
                    dataSubjectFriendlyName = "Wholesale Delivery Type";
                    dataSubjectStoredProcedureName = "spCreateWholesaleDeliveryType";
                    dataSubjectStoredProcedureParameterPrefix = "wholesaleDeliveryType";
                    break;
                default:
                    this.Text = functionTitle;
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", functionTitle);
                    break;
            }

            if (companyConfigurationEnabledDataSubjects.Contains(_functionTitle))
            {
                LoadActiveCompanyConfigurationAsync();
            }
            else
            {
                this.Size = new Size(544, 293);
                createMasterDataSimpleStatusStrip.Visible = false;
                createMasterDataSimpleStatusStripCompanyConfigurationPlaceholder.Visible = false;
            }

            dataSubjectName = functionTitle;

            createMasterDataSimpleTitleLabel.Text = $"{titleLabelPrefix}{dataSubjectFriendlyName}";
            createMasterDataSimpleMasterDataTypeTextBoxLabel.Text = $"{dataSubjectFriendlyName}*";
            createMasterDataSimpleActiveStatusCheckBox.Text = $"Active {dataSubjectFriendlyName}*";
            this.Text = $"{applicationTitlePrefix}{dataSubjectFriendlyName}";
        }

        private async void changeActiveCompanyConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(createMasterDataSimpleStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.ShowChangeDialogAndReloadAsync(this);
            _companyConfigurationId = _companyConfigHelper.CompanyConfigurationId;
        }

        private async void createMasterDataSimpleSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createMasterDataSimpleActiveStatusCheckBox.Checked;
            string dataSubjectValue = TextBoxCleanerHelper.GetTrimmedText(createMasterDataSimpleMasterDataTypeTextBox);

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
                    Name = "Active Status",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Company Configuration Id",
                    Value = _companyConfigurationId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = dataSubjectFriendlyName,
                    Value = dataSubjectValue,
                    MaxLength = 50,
                    ValueType = typeof(string)
                }
            };

            dataToValidate = dataToValidate.OrderBy(change => change.Name).ToList();

            var validationResult = ValidateDataInputService.ValidateInput(dataToValidate);

            if (!validationResult.IsValid)
            {
                return;
            }
            else
            {
                var parameters = new List<StoredProcedureParameter>
                {
                    new StoredProcedureParameter
                    {
                        ParameterName = "activeStatus",
                        ParameterValue = activeStatus
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = $"{dataSubjectStoredProcedureParameterPrefix}",
                        ParameterValue = dataSubjectValue
                    }
                };

                if (companyConfigurationEnabledDataSubjects.Contains(_functionTitle))
                {
                    parameters.Add(new StoredProcedureParameter
                    {
                        ParameterName = "companyConfigurationId",
                        ParameterValue = _companyConfigurationId
                    });
                }

                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(dataSubjectStoredProcedureName, parameters.ToArray(), dataSubjectName, operationType);
                this.Close();
            }
        }
    }
}