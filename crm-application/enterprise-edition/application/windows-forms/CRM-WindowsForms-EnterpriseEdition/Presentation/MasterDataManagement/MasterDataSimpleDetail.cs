using CRM.Helpers;
using CRM.Interface;
using CRM.Model;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.MasterDataManagement
{
    public partial class MasterDataSimpleDetail : Form
    {
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private readonly Guid _dataSubjectId;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly string _functionTitle;
        private readonly string _moduleGroup;
        private readonly string applicationTitlePrefix = "CRM - ";
        private bool dataSubjectActiveStatusOriginalValue;
        private List<string> companyConfigurationEnabledDataSubjects;
        private Guid? dataSubjectCompanyConfigurationIdOriginalValue;
        private string dataSubjectFriendlyName;
        private string dataSubjectGetStoredProcedureName;
        private string dataSubjectIdFriendlyName;
        private string dataSubjectName;
        private string dataSubjectOriginalValue;
        private string dataSubjectUpdateStoredProcedureName;
        private string dataSubjectUpdateStoredProcedureParameterPrefix;
        private readonly string titleLabelSuffix= " Detail";

        public MasterDataSimpleDetail(Guid dataSubjectId, string functionTitle, string moduleGroup)
        {
            InitializeComponent();
            InitializeEventHandlers();
            _dataSubjectId = dataSubjectId;
            _functionTitle = functionTitle;
            _moduleGroup = moduleGroup;
            SetModuleTheme();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            SetParameters(_functionTitle);
            MasterDataSimpleDetailMasterDataInformation_Load(this, EventArgs.Empty);
        }

        private void InitializeEventHandlers()
        {
            
        }

        private async Task LoadCompanyConfigurationAsync(Guid companyConfigurationId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(masterDataSimpleDetailCompanyConfigurationComboBox, "spGetAllCompanyConfiguration", null, true, "Company Configuration Id", companyConfigurationId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
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
                new StoredProcedureParameter
                {
                    ParameterName = $"{dataSubjectUpdateStoredProcedureParameterPrefix}Id",
                    ParameterValue = _dataSubjectId
                }
            };

            try
            {
                DataTable? masterDataSimpleDetailDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(
                    _databaseConnectionSettings,
                    dataSubjectGetStoredProcedureName,
                    parameters.ToArray(),
                    dataSubjectName);

                if (masterDataSimpleDetailDataTable != null)
                {
                    DataRow masterDataSimpleDetailDataRow = masterDataSimpleDetailDataTable.Rows[0];
                    masterDataSimpleDetailDataSubjectIdTextBox.Text = masterDataSimpleDetailDataRow[dataSubjectIdFriendlyName].ToString();
                    masterDataSimpleDetailDataSubjectTextBox.Text = masterDataSimpleDetailDataRow[dataSubjectFriendlyName].ToString();
                    masterDataSimpleDetailCreatedByTextBox.Text = masterDataSimpleDetailDataRow["Created By"].ToString();
                    masterDataSimpleDetailCreatedTimestampTextBox.Text = masterDataSimpleDetailDataRow["Created Timestamp UTC"].ToString();
                    masterDataSimpleDetailLastUpdatedByTextBox.Text = masterDataSimpleDetailDataRow["Modified By"].ToString();
                    masterDataSimpleDetailLastUpdatedTimestampTextBox.Text = masterDataSimpleDetailDataRow["Modified Timestamp UTC"].ToString();
                    masterDataSimpleDetailActiveStatusCheckBox.Checked = (bool)masterDataSimpleDetailDataRow["Active Status"];
                    if (companyConfigurationEnabledDataSubjects.Contains(_functionTitle))
                    {
                        Guid companyConfigurationId = (Guid)masterDataSimpleDetailDataRow["Company Configuration Id"];
                        await LoadCompanyConfigurationAsync(companyConfigurationId);
                    }

                    dataSubjectOriginalValue = masterDataSimpleDetailDataRow[dataSubjectFriendlyName].ToString();
                    if (companyConfigurationEnabledDataSubjects.Contains(_functionTitle))
                    {
                        dataSubjectCompanyConfigurationIdOriginalValue = (Guid)masterDataSimpleDetailDataRow["Company Configuration Id"];
                    }

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
                    dataSubjectGetStoredProcedureName = "spGetCustomerLeadNoteType";
                    dataSubjectIdFriendlyName = "Customer Lead Note Type Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdateCustomerLeadNoteType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "customerLeadNoteType";
                    break;
                case "CustomerLeadStatus":
                    dataSubjectFriendlyName = "Customer Lead Status";
                    dataSubjectGetStoredProcedureName = "spGetCustomerLeadStatus";
                    dataSubjectIdFriendlyName = "Customer Lead Status Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdateCustomerLeadStatus";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "customerLeadStatus";
                    break;
                case "CustomerNoteType":
                    dataSubjectFriendlyName = "Customer Note Type";
                    dataSubjectGetStoredProcedureName = "spGetCustomerNoteType";
                    dataSubjectIdFriendlyName = "Customer Note Type Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdateCustomerNoteType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "customerNoteType";
                    break;
                case "HTMLTemplateType":
                    dataSubjectFriendlyName = "HTML Template Type";
                    dataSubjectGetStoredProcedureName = "spGetHTMLTemplateType";
                    dataSubjectIdFriendlyName = "HTML Template Type Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdateHTMLTemplateType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "htmlTemplateType";
                    break;
                case "MarketingCampaignStatus":
                    dataSubjectFriendlyName = "Marketing Campaign Status";
                    dataSubjectGetStoredProcedureName = "spGetMarketingCampaignStatus";
                    dataSubjectIdFriendlyName = "Marketing Campaign Status Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdateMarketingCampaignStatus";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "marketingCampaignStatus";
                    break;
                case "MarketingCampaignType":
                    dataSubjectFriendlyName = "Marketing Campaign Type";
                    dataSubjectGetStoredProcedureName = "spGetMarketingCampaignType";
                    dataSubjectIdFriendlyName = "Marketing Campaign Type Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdateMarketingCampaignType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "marketingCampaignType";
                    break;
                case "MarketingChannel":
                    dataSubjectFriendlyName = "Marketing Channel";
                    dataSubjectGetStoredProcedureName = "spGetMarketingChannel";
                    dataSubjectIdFriendlyName = "Marketing Channel Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdateMarketingChannel";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "marketingChannel";
                    break;
                case "OrderLineItemStatus":
                    dataSubjectFriendlyName = "Order Line Item Status";
                    dataSubjectGetStoredProcedureName = "spGetOrderLineItemStatus";
                    dataSubjectIdFriendlyName = "Order Line Item Status Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdateOrderLineItemStatus";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "orderLineItemStatus";
                    break;
                case "OrderPaymentStatus":
                    dataSubjectFriendlyName = "Order Payment Status";
                    dataSubjectGetStoredProcedureName = "spGetOrderPaymentStatus";
                    dataSubjectIdFriendlyName = "Order Payment Status Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdateOrderPaymentStatus";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "orderPaymentStatus";
                    break;
                case "OrderStatus":
                    dataSubjectFriendlyName = "Order Status";
                    dataSubjectGetStoredProcedureName = "spGetOrderStatus";
                    dataSubjectIdFriendlyName = "Order Status Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdateOrderStatus";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "orderStatus";
                    break;
                case "OrderType":
                    dataSubjectFriendlyName = "Order Type";
                    dataSubjectGetStoredProcedureName = "spGetOrderType";
                    dataSubjectIdFriendlyName = "Order Type Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdateOrderType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "orderType";
                    break;
                case "PaymentMethod":
                    dataSubjectFriendlyName = "Payment Method";
                    dataSubjectGetStoredProcedureName = "spGetPaymentMethod";
                    dataSubjectIdFriendlyName = "Payment Method Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdatePaymentMethod";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "paymentMethod";
                    break;
                case "ProductCategory":
                    dataSubjectFriendlyName = "Product Category";
                    dataSubjectGetStoredProcedureName = "spGetProductCategory";
                    dataSubjectIdFriendlyName = "Product Category Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdateProductCategory";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "productCategory";
                    break;
                case "ProductFamily":
                    dataSubjectFriendlyName = "Product Family";
                    dataSubjectGetStoredProcedureName = "spGetProductFamily";
                    dataSubjectIdFriendlyName = "Product Family Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdateProductFamily";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "productFamily";
                    break;
                case "ProductNoteType":
                    dataSubjectFriendlyName = "Product Note Type";
                    dataSubjectGetStoredProcedureName = "spGetProductNoteType";
                    dataSubjectIdFriendlyName = "Product Note Type Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdateProductNoteType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "productNoteType";
                    break;
                case "PromotionType":
                    dataSubjectFriendlyName = "Promotion Type";
                    dataSubjectGetStoredProcedureName = "spGetPromotionType";
                    dataSubjectIdFriendlyName = "Promotion Type Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdatePromotionType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "promotionType";
                    break;
                case "SalesRegion":
                    dataSubjectFriendlyName = "Sales Region";
                    dataSubjectGetStoredProcedureName = "spGetSalesRegion";
                    dataSubjectIdFriendlyName = "Sales Region Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdateSalesRegion";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "salesRegion";
                    break;
                case "SupplierNoteType":
                    dataSubjectFriendlyName = "Supplier Note Type";
                    dataSubjectGetStoredProcedureName = "spGetSupplierNoteType";
                    dataSubjectIdFriendlyName = "Supplier Note Type Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdateSupplierNoteType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "supplierNoteType";
                    break;
                case "SupplierOrderLineItemStatus":
                    dataSubjectFriendlyName = "Supplier Order Line Item Status";
                    dataSubjectGetStoredProcedureName = "spGetSupplierOrderLineItemStatus";
                    dataSubjectIdFriendlyName = "Supplier Order Line Item Status Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrderLineItemStatus";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "supplierOrderLineItemStatus";
                    break;
                case "SupplierOrderPaymentStatus":
                    dataSubjectFriendlyName = "Supplier Order Payment Status";
                    dataSubjectGetStoredProcedureName = "spGetSupplierOrderPaymentStatus";
                    dataSubjectIdFriendlyName = "Supplier Order Payment Status Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrderPaymentStatus";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "supplierOrderPaymentStatus";
                    break;
                case "SupplierOrderStatus":
                    dataSubjectFriendlyName = "Supplier Order Status";
                    dataSubjectGetStoredProcedureName = "spGetSupplierOrderStatus";
                    dataSubjectIdFriendlyName = "Supplier Order Status Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdateSupplierOrderStatus";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "supplierOrderStatus";
                    break;
                case "WholesaleDeliveryType":
                    dataSubjectFriendlyName = "Wholesale Delivery Type";
                    dataSubjectGetStoredProcedureName = "spGetWholesaleDeliveryType";
                    dataSubjectIdFriendlyName = "Wholesale Delivery Type Id";
                    dataSubjectUpdateStoredProcedureName = "spUpdateWholesaleDeliveryType";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "wholesaleDeliveryType";
                    break;
                default:
                    this.Text = functionTitle;
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", functionTitle);
                    break;
            }

            if (!companyConfigurationEnabledDataSubjects.Contains(_functionTitle))
            {
                masterDataSimpleDetailCompanyConfigurationComboBox.Visible = false;
                masterDataSimpleDetailCompanyConfigurationComboBoxLabel.Visible = false;
            }

            dataSubjectName = functionTitle;

            masterDataSimpleDetailTitleLabel.Text = $"{dataSubjectFriendlyName}{titleLabelSuffix}";
            masterDataSimpleDetailDataSubjectIdTextBoxLabel.Text = dataSubjectIdFriendlyName;
            masterDataSimpleDetailDataSubjectTextBoxLabel.Text = dataSubjectFriendlyName;
            masterDataSimpleDetailActiveStatusCheckBox.Text = $"Active {dataSubjectFriendlyName}";
            masterDataSimpleDetailUpdateDataSubjectButton.Text = $"Update {dataSubjectFriendlyName}";
            this.Text = $"{applicationTitlePrefix}{dataSubjectFriendlyName}{titleLabelSuffix}";
        }

        private void masterDataSimpleDetailToggleEditModeButton_Click(object? sender, EventArgs e)
        {
            masterDataSimpleDetailDataSubjectTextBox.ReadOnly = !masterDataSimpleDetailDataSubjectTextBox.ReadOnly;
            masterDataSimpleDetailActiveStatusCheckBox.Enabled = !masterDataSimpleDetailActiveStatusCheckBox.Enabled;
            masterDataSimpleDetailUpdateDataSubjectButton.Enabled = !masterDataSimpleDetailUpdateDataSubjectButton.Enabled;
            if (companyConfigurationEnabledDataSubjects.Contains(_functionTitle))
            {
                masterDataSimpleDetailCompanyConfigurationComboBox.Enabled = !masterDataSimpleDetailCompanyConfigurationComboBox.Enabled;
            }
        }

        private async void masterDataSimpleDetailUpdateDataSubjectButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = masterDataSimpleDetailActiveStatusCheckBox.Checked;
            Guid? companyConfigurationId = (Guid?)masterDataSimpleDetailCompanyConfigurationComboBox.SelectedValue;
            string dataSubjectValue = TextBoxCleanerHelper.GetTrimmedText(masterDataSimpleDetailDataSubjectTextBox);

            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            var dataToValidate = new List<DataValidationService.DataProperty>
            {
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Active Status",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = companyConfigurationEnabledDataSubjects.Contains(_functionTitle) ? false : true,
                    Name = "Company Configuration Id",
                    Value = companyConfigurationId,
                    ValueType = typeof(Guid)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = dataSubjectFriendlyName,
                    Value = dataSubjectValue,
                    MaxLength = 50,
                    ValueType = typeof(string)
                }
            };

            dataToValidate = dataToValidate.OrderBy(change => change.Name).ToList();

            var validationResult = DataValidationService.ValidateInput(dataToValidate);

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
                        OriginalValue = dataSubjectActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Company Configuration Id",
                        OriginalValue = dataSubjectCompanyConfigurationIdOriginalValue,
                        NewValue = companyConfigurationId
                    },
                    new ChangeDetail
                    {
                        VariableName = dataSubjectFriendlyName,
                        OriginalValue = dataSubjectOriginalValue,
                        NewValue = dataSubjectValue
                    }
                };

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = ChangeValidationService.ConfirmChanges(changesList, dataSubjectName);

                if (confirmed)
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
                            ParameterName = $"{dataSubjectUpdateStoredProcedureParameterPrefix}Id",
                            ParameterValue = _dataSubjectId
                        },
                        new StoredProcedureParameter
                        {
                            ParameterName = $"{dataSubjectUpdateStoredProcedureParameterPrefix}",
                            ParameterValue = dataSubjectValue
                        }
                    };

                    if (companyConfigurationEnabledDataSubjects.Contains(_functionTitle))
                    {
                        parameters.Add(new StoredProcedureParameter
                        {
                            ParameterName = "companyConfigurationId",
                            ParameterValue = companyConfigurationId
                        });
                    }

                    string operationType = "Update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(_databaseConnectionSettings,dataSubjectUpdateStoredProcedureName, parameters.ToArray(), dataSubjectName, operationType);
                    this.Close();
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.UpdateCancelled");
                    this.Close();
                }
            }
        }
    }
}