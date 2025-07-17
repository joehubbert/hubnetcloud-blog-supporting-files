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
            masterDataSimpleDetailToggleEditModeButton.Click += masterDataSimpleDetailToggleEditModeButton_Click;
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
                    MessageBox.Show($"Unrecognised module group - {moduleGroup} passed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void SetParameters(string functionTitle)
        {
            switch (functionTitle)
            {
                case "CustomerLeadNoteType":
                    dataSubjectFriendlyName = "Customer Lead Note Type";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetCustomerLeadNoteType]";
                    dataSubjectIdFriendlyName = "Customer Lead Note Type Id";
                    dataSubjectIdName = "CustomerLeadNoteTypeId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateCustomerLeadNoteType]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "customerLeadNoteType";
                    break;
                case "CustomerLeadStatus":
                    dataSubjectFriendlyName = "Customer Lead Status";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetCustomerLeadStatus]";
                    dataSubjectIdFriendlyName = "Customer Lead Status Id";
                    dataSubjectIdName = "CustomerLeadStatusId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateCustomerLeadStatus]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "customerLeadStatus";
                    break;
                case "CustomerNoteType":
                    dataSubjectFriendlyName = "Customer Note Type";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetCustomerNoteType]";
                    dataSubjectIdFriendlyName = "Customer Note Type Id";
                    dataSubjectIdName = "CustomerNoteTypeId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateCustomerNoteType]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "customerNoteType";
                    break;
                case "MarketingCampaignStatus":
                    dataSubjectFriendlyName = "Marketing Campaign Status";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetMarketingCampaignStatus]";
                    dataSubjectIdFriendlyName = "Marketing Campaign Status Id";
                    dataSubjectIdName = "MarketingCampaignStatusId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateMarketingCampaignStatus]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "marketingCampaignStatus";
                    break;
                case "MarketingCampaignType":
                    dataSubjectFriendlyName = "Marketing Campaign Type";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetMarketingCampaignType]";
                    dataSubjectIdFriendlyName = "Marketing Campaign Type Id";
                    dataSubjectIdName = "MarketingCampaignTypeId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateMarketingCampaignType]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "marketingCampaignType";
                    break;
                case "MarketingChannel":
                    dataSubjectFriendlyName = "Marketing Channel";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetMarketingChannel]";
                    dataSubjectIdFriendlyName = "Marketing Channel Id";
                    dataSubjectIdName = "MarketingChannelId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateMarketingChannel]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "marketingChannel";
                    break;
                case "OrderLineItemStatus":
                    dataSubjectFriendlyName = "Order Line Item Status";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetOrderLineItemStatus]";
                    dataSubjectIdFriendlyName = "Order Line Item Status Id";
                    dataSubjectIdName = "OrderLineItemStatusId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateOrderLineItemStatus]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "orderLineItemStatus";
                    break;
                case "OrderPaymentStatus":
                    dataSubjectFriendlyName = "Order Payment Status";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetOrderPaymentStatus]";
                    dataSubjectIdFriendlyName = "Order Payment Status Id";
                    dataSubjectIdName = "OrderPaymentStatusId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateOrderPaymentStatus]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "orderPaymentStatus";
                    break;
                case "OrderStatus":
                    dataSubjectFriendlyName = "Order Status";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetOrderStatus]";
                    dataSubjectIdFriendlyName = "Order Status Id";
                    dataSubjectIdName = "OrderStatusId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateOrderStatus]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "orderStatus";
                    break;
                case "OrderType":
                    dataSubjectFriendlyName = "Order Type";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetOrderType]";
                    dataSubjectIdFriendlyName = "Order Type Id";
                    dataSubjectIdName = "OrderTypeId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateOrderType]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "orderType";
                    break;
                case "PaymentMethod":
                    dataSubjectFriendlyName = "Payment Method";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetPaymentMethod]";
                    dataSubjectIdFriendlyName = "Payment Method Id";
                    dataSubjectIdName = "PaymentMethodId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdatePaymentMethod]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "paymentMethod";
                    break;
                case "ProductCategory":
                    dataSubjectFriendlyName = "Product Category";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetProductCategory]";
                    dataSubjectIdFriendlyName = "Product Category Id";
                    dataSubjectIdName = "ProductCategoryId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateProductCategory]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "productCategory";
                    break;
                case "ProductFamily":
                    dataSubjectFriendlyName = "Product Family";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetProductFamily]";
                    dataSubjectIdFriendlyName = "Product Family Id";
                    dataSubjectIdName = "ProductFamilyId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateProductFamily]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "productFamily";
                    break;
                case "ProductNoteType":
                    dataSubjectFriendlyName = "Product Note Type";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetProductNoteType]";
                    dataSubjectIdFriendlyName = "Product Note Type Id";
                    dataSubjectIdName = "ProductNoteTypeId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateProductNoteType]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "productNoteType";
                    break;
                case "PromotionType":
                    dataSubjectFriendlyName = "Promotion Type";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetPromotionType]";
                    dataSubjectIdFriendlyName = "Promotion Type Id";
                    dataSubjectIdName = "PromotionTypeId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdatePromotionType]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "promotionType";
                    break;
                case "SalesRegion":
                    dataSubjectFriendlyName = "Sales Region";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetSalesRegion]";
                    dataSubjectIdFriendlyName = "Sales Region Id";
                    dataSubjectIdName = "SalesRegionId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateSalesRegion]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "salesRegion";
                    break;
                case "SupplierNoteType":
                    dataSubjectFriendlyName = "Supplier Note Type";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetSupplierNoteType]";
                    dataSubjectIdFriendlyName = "Supplier Note Type Id";
                    dataSubjectIdName = "SupplierNoteTypeId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateSupplierNoteType]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "supplierNoteType";
                    break;
                case "SupplierOrderLineItemStatus":
                    dataSubjectFriendlyName = "Supplier Order Line Item Status";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetSupplierOrderLineItemStatus]";
                    dataSubjectIdFriendlyName = "Supplier Order Line Item Status Id";
                    dataSubjectIdName = "SupplierOrderLineItemStatusId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateSupplierOrderLineItemStatus]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "supplierOrderLineItemStatus";
                    break;
                case "SupplierOrderPaymentStatus":
                    dataSubjectFriendlyName = "Supplier Order Payment Status";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetSupplierOrderPaymentStatus]";
                    dataSubjectIdFriendlyName = "Supplier Order Payment Status Id";
                    dataSubjectIdName = "SupplierOrderPaymentStatusId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateSupplierOrderPaymentStatus]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "supplierOrderPaymentStatus";
                    break;
                case "SupplierOrderStatus":
                    dataSubjectFriendlyName = "Supplier Order Status";
                    dataSubjectGetStoredProcedureName = "[dbo].[spGetSupplierOrderStatus]";
                    dataSubjectIdFriendlyName = "Supplier Order Status Id";
                    dataSubjectIdName = "SupplierOrderStatusId";
                    dataSubjectUpdateStoredProcedureName = "[dbo].[spUpdateSupplierOrderStatus]";
                    dataSubjectUpdateStoredProcedureParameterPrefix = "supplierOrderStatus";
                    break;
                default:
                    this.Text = functionTitle;
                    MessageBox.Show($"{functionTitle} not onboarded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    dataSubjectName,
                    _databaseConnectionSettings.DatabaseConnectionString);

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

        private async void masterDataSimpleDetailUpdateDataSubjectButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = masterDataSimpleDetailActiveStatusCheckbox.Checked;
            string dataSubjectValue = masterDataSimpleDetailDataSubjectTextbox.Text.TrimEnd();

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