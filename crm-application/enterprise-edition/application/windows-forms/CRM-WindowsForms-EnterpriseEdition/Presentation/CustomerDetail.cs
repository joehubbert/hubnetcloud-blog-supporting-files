using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CustomerDetail : Form
    {
        private readonly Guid _customerId;
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DataGridViewQuickSearchHelper? _dataGridViewQuickSearchHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private string customerDetailTabControlBillingInformationTabPageAddressLine1OriginalValue;
        private string? customerDetailTabControlBillingInformationTabPageAddressLine2OriginalValue;
        private string customerDetailTabControlBillingInformationTabPageAddressLine3OriginalValue;
        private string customerDetailTabControlBillingInformationTabPageAddressLine4OriginalValue;
        private Guid customerDetailTabControlBillingInformationTabPageAddressLine5OriginalValue;
        private string customerDetailTabControlBillingInformationTabPageCompanyNameOriginalValue;
        private string customerDetailTabControlBillingInformationTabPageEmailAddressOriginalValue;
        private string customerDetailTabControlBillingInformationTabPageFirstNameOriginalValue;
        private string customerDetailTabControlBillingInformationTabPageLastNameOriginalValue;
        private string customerDetailTabControlBillingInformationTabPageTelephoneNumberOriginalValue;
        private bool customerDetailTabControlFinanceCreditEnabledOriginalValue;
        private decimal? customerDetailTabControlFinanceCreditLimitOriginalValue;
        private Guid customerDetailTabControlFinancePaymentCurrencyIdOriginalValue;
        private int customerDetailTabControlFinancePaymentDaysOriginalValue;
        private string? customerDetailTabControlFinanceVATNumberOriginalValue;
        private bool customerDetailTabControlFinanceVATRegisteredOriginalValue;
        private Guid customerDetailTabControlOverviewTabPageAccountManagerIdOriginalValue;
        private bool customerDetailTabControlOverviewTabPageActiveStatusOriginalValue;
        private Guid customerDetailTabControlOverviewTabPageCompanyConfigurationIdOriginalValue;
        private string customerDetailTabControlOverviewTabPageCompanyNameOriginalValue;
        private DateTime customerDetailTabControlOverviewTabPageCustomerSinceOriginalValue;
        private Guid? customerDetailTabControlOverviewTabPageCustomerTierIdOriginalValue;
        private Guid? customerDetailTabControlOverviewTabPageCustomerTypeIdOriginalValue;
        private string customerDetailTabControlOverviewTabPageEmailAddressOriginalValue;
        private bool? customerDetailTabControlOverviewTabPageExistingParentCompanyTypeGlobalParentOriginalValue;
        private bool? customerDetailTabControlOverviewTabPageExistingParentCompanyTypeTopParentOriginalValue;
        private string customerDetailTabControlOverviewTabPageFirstNameOriginalValue;
        private Guid? customerDetailTabControlOverviewTabPageGlobalParentCustomerIdOriginalValue;
        private string customerDetailTabControlOverviewTabPageLastNameOriginalValue;
        private Guid customerDetailTabControlOverviewTabPageSalesRegionIdOriginalValue;
        private Guid customerDetailTabControlOverviewTabPageSalesSubRegionIdOriginalValue;
        private string customerDetailTabControlOverviewTabPageTelephoneNumberOriginalValue;
        private Guid? customerDetailTabControlOverviewTabPageTopParentCustomerIdOriginalValue;
        private bool? customerDetailTabControlOverviewTabPageWillBeParentInCustomerHierarchyOriginalValue;
        private string customerDetailTabControlShippingInformationAddressLine1OriginalValue;
        private string? customerDetailTabControlShippingInformationAddressLine2OriginalValue;
        private string customerDetailTabControlShippingInformationAddressLine3OriginalValue;
        private string customerDetailTabControlShippingInformationAddressLine4OriginalValue;
        private Guid customerDetailTabControlShippingInformationAddressLine5OriginalValue;
        private string customerDetailTabControlShippingInformationCompanyNameOriginalValue;
        private string customerDetailTabControlShippingInformationEmailAddressOriginalValue;
        private string customerDetailTabControlShippingInformationFirstNameOriginalValue;
        private string customerDetailTabControlShippingInformationLastNameOriginalValue;
        private string customerDetailTabControlShippingInformationTelephoneNumberOriginalValue;
        private string customerDisplayName;

        public CustomerDetail(Guid customerId)
        {
            InitializeComponent();
            InitializeEventHandlers();
            LoadDatabaseConnectionSettingsAsync();
            _customerId = customerId;
        }

        private void InitializeEventHandlers()
        {
            customerDetailTabControlBillingInformationTabPageAddressLine5ComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            customerDetailTabControlCustomerContactTabPageDataGridView.CellContentClick += new DataGridViewCellEventHandler(customerDetailTabControlCustomerContactTabPageDataGridView_CellContentClick);
            customerDetailTabControlCustomerLeadTabPageDataGridView.CellContentClick += new DataGridViewCellEventHandler(customerDetailTabControlCustomerLeadTabPageDataGridView_CellContentClick);
            customerDetailTabControlCustomerNoteTabPageDataGridView.CellContentClick += new DataGridViewCellEventHandler(customerDetailTabControlCustomerNoteTabPageDataGridView_CellContentClick);
            customerDetailTabControlFinanceTabPageCreditEnabledCheckbox.CheckedChanged += new EventHandler(CustomerDetailFinanceCreditEnabledCheckBox_CheckedChanged);
            customerDetailTabControlFinanceTabPagePaymentCurrencyComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            customerDetailTabControlFinanceTabPageVATRegisteredCheckbox.CheckedChanged += new EventHandler(CustomerDetailFinanceVATRegisteredCheckbox_CheckedChanged);
            customerDetailTabControlOverviewTabPageAccountManagerComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            customerDetailTabControlOverviewTabPageCompanyConfigurationComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            customerDetailTabControlOverviewTabPageCustomerTierComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            customerDetailTabControlOverviewTabPageCustomerTypeComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            customerDetailTabControlOverviewTabPageExistingParentCompanyPanelNoRadioButton.CheckedChanged += new EventHandler(CustomerDetailOverviewExistingParentCustomerRadioButton_CheckedChanged);
            customerDetailTabControlOverviewTabPageExistingParentCompanyPanelYesRadioButton.CheckedChanged += new EventHandler(CustomerDetailOverviewExistingParentCustomerRadioButton_CheckedChanged);
            customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.CheckedChanged += new EventHandler(CustomerDetailOverviewExistingParentCompanyType_CheckedChanged);
            customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.CheckedChanged += new EventHandler(CustomerDetailOverviewRadioButtonValidation_CheckedChanged);
            customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.CheckedChanged += new EventHandler(CustomerDetailOverviewExistingParentCompanyType_CheckedChanged);
            customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.CheckedChanged += new EventHandler(CustomerDetailOverviewRadioButtonValidation_CheckedChanged);
            customerDetailTabControlOverviewTabPageSalesRegionComboBox.DropDown += new EventHandler(CustomerDetailOverviewSalesRegionComboBox_DropDown);
            customerDetailTabControlOverviewTabPageSalesRegionComboBox.SelectedIndexChanged += new EventHandler(CustomerDetailOverviewSalesRegionComboBox_SelectedIndexChanged);
            customerDetailTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelNoRadioButton.CheckedChanged += new EventHandler(CustomerDetailOverviewRadioButtonValidation_CheckedChanged);
            customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.CheckedChanged += new EventHandler(CustomerDetailOverviewRadioButtonValidation_CheckedChanged);
            customerDetailTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelYesRadioButton.CheckedChanged += new EventHandler(CustomerDetailOverviewRadioButtonValidation_CheckedChanged);
            customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelTopParentRadioButton.CheckedChanged += new EventHandler(CustomerDetailOverviewRadioButtonValidation_CheckedChanged);
            customerDetailTabControlShippingInformationTabPageAddressLine5ComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            customerDetailTabControl.SelectedIndexChanged += new EventHandler(CustomerDetailTabControl_SelectedIndexChanged);
            customerDetailToggleEditModeButton.Click += new EventHandler(customerDetailToggleEditModeButton_Click);
            _dataGridViewQuickSearchHelper = new DataGridViewQuickSearchHelper(customerDetailTabControlCustomerContactTabPageQuickFilterTextbox, customerDetailTabControlCustomerContactTabPageDataGridView);
            _dataGridViewQuickSearchHelper = new DataGridViewQuickSearchHelper(customerDetailTabControlCustomerLeadTabPageQuickFilterTextbox, customerDetailTabControlCustomerLeadTabPageDataGridView);
            _dataGridViewQuickSearchHelper = new DataGridViewQuickSearchHelper(customerDetailTabControlCustomerNoteTabPageQuickFilterTextbox, customerDetailTabControlCustomerNoteTabPageDataGridView);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task LoadCountryDataAsync(Guid countryId, string countryType)
        {
            switch (countryType)
            {
                case "Billing":
                    _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerDetailTabControlBillingInformationTabPageAddressLine5ComboBox, "spGetAllCountry", null, true, "Country Id", countryId);
                    break;
                case "Shipping":
                    _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerDetailTabControlShippingInformationTabPageAddressLine5ComboBox, "spGetAllCountry", null, true, "Country Id", countryId);
                    break;
                default:
                    throw new ArgumentException("Invalid country type specified.");
            }
        }

        private async Task LoadCustomerTierDataAsync(Guid companyConfigurationId, Guid customerTierId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerDetailTabControlOverviewTabPageCustomerTierComboBox, "spGetAllCustomerTier", companyConfigurationId, true, "Customer Tier Id", customerTierId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadCustomerTypeAsync(Guid companyConfigurationId, Guid customerTypeId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerDetailTabControlOverviewTabPageCustomerTierComboBox, "spGetAllCustomerType", companyConfigurationId, true, "Customer Type Id", customerTypeId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadSalesRegionDataAsync(Guid companyConfigurationId, Guid salesRegionId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerDetailTabControlOverviewTabPageSalesRegionComboBox, "spGetAllSalesRegion", companyConfigurationId, true, "Sales Region Id", salesRegionId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadSalesSubRegionAsync(Guid salesRegionId, Guid salesSubRegionId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerDetailTabControlOverviewTabPageSalesSubRegionComboBox, "spGetAllSalesSubRegion", null, true, "Sales Region Id", salesRegionId, true, "Sales Sub Region Id", salesSubRegionId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadGlobalParentCustomerDataAsync(Guid customerId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox, "spGetAllGlobalParentCustomer", null, true, "Customer Id", customerId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadTopParentCustomerDataAsync(Guid customerId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerDetailTabControlOverviewTabPageTopParentCustomerComboBox, "spGetAllTopParentCustomer", null, true, "Customer Id", customerId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadCurrencyDataAsync(Guid currencyId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerDetailTabControlFinanceTabPagePaymentCurrencyComboBox, "spGetAllCurrency", null, true, "Currency Id", currencyId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadAccountManagerDataAsync(Guid accountManagerId, Guid companyConfigurationId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerDetailTabControlOverviewTabPageAccountManagerComboBox, "spGetAllAccountManager", companyConfigurationId, true, "Account Manager Id", accountManagerId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadCompanyConfigurationAsync(Guid companyConfigurationId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerDetailTabControlOverviewTabPageCompanyConfigurationComboBox, "spGetAllCompanyConfiguration", null, true, "Company Configuration Id", companyConfigurationId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDownHelper.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void CustomerDetailOverviewSalesRegionComboBox_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDownHelper.AdjustComboBoxDropDownWidth(sender as ComboBox);
            await LoadSalesSubRegionAsync((Guid)customerDetailTabControlOverviewTabPageSalesRegionComboBox.SelectedValue, (Guid)customerDetailTabControlOverviewTabPageSalesSubRegionComboBox.SelectedValue);
        }

        private async void CustomerDetailOverviewSalesRegionComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            await LoadSalesSubRegionAsync((Guid)customerDetailTabControlOverviewTabPageSalesRegionComboBox.SelectedValue, (Guid)customerDetailTabControlOverviewTabPageSalesSubRegionComboBox.SelectedValue);
        }

        private void CustomerDetailOverviewExistingParentCustomerRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (customerDetailTabControlOverviewTabPageExistingParentCompanyPanelNoRadioButton.Checked)
            {
                customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.Enabled = false;
                customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.Enabled = false;
                customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.Checked = false;
                customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.Checked = false;
                customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.Enabled = false;
                customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.DataSource = null;
                customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.Items.Clear();
                customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.Enabled = false;
                customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.DataSource = null;
                customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.Items.Clear();
            }
            else if (customerDetailTabControlOverviewTabPageExistingParentCompanyPanelYesRadioButton.Checked)
            {
                customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.Enabled = true;
                customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.Enabled = true;
            }
        }

        private async void CustomerDetailOverviewExistingParentCompanyType_CheckedChanged(object? sender, EventArgs e)
        {
            if (customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.Checked)
            {
                if (customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.SelectedValue != null)
                {
                    await LoadGlobalParentCustomerDataAsync((Guid)customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.SelectedValue);
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Warning.DataValidation.Selection", "Global Parent Customer");
                }
                customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.Enabled = true;
                customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.Enabled = false;
                customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.DataSource = null;
                customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.Items.Clear();

            }
            else if (customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.Checked)
            {
                if (customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.SelectedValue != null)
                {
                    await LoadTopParentCustomerDataAsync((Guid)customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.SelectedValue);
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Warning.DataValidation.Selection", "Top Parent Customer");
                }
                customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.Enabled = true;
                customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.Enabled = false;
                customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.DataSource = null;
                customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.Items.Clear();
            }
        }

        private void CustomerDetailOverviewRadioButtonValidation_CheckedChanged(object? sender, EventArgs e)
        {
            if (customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.Checked)
            {
                customerDetailTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelYesRadioButton.Enabled = false;
                customerDetailTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelNoRadioButton.Enabled = false;
                customerDetailTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelYesRadioButton.Checked = false;
                customerDetailTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelNoRadioButton.Checked = false;
                customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Checked = false;
                customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Enabled = false;
                customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelTopParentRadioButton.Checked = false;
                customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelTopParentRadioButton.Enabled = false;

            }
            else if (customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.Checked && customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelTopParentRadioButton.Checked)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Customer.TopParent.TopParentRelationshipValidation");
                customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelTopParentRadioButton.Checked = false;
                customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelTopParentRadioButton.Enabled = false;
                customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Checked = false;
                customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Enabled = false;
            }


            if (customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Checked)
            {
                var selectedCustomerType = customerDetailTabControlOverviewTabPageCustomerTypeComboBox.Text;
                if (selectedCustomerType != "Business - Multinational")
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Customer.GlobalParentType.CustomerTypeValidation");
                    customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Checked = false;
                }
            }
            else if (customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Checked && customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.Checked)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Customer.GlobalParent.GlobalParentRelationshipValidation");
                customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Checked = false;
                customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Enabled = false;
            }

            if (customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.Checked)
            {
                var selectedCustomerType = customerDetailTabControlOverviewTabPageCustomerTypeComboBox.Text;
                if (selectedCustomerType != "Business - Multinational")
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Customer.CustomerType.MultinationalValidation");
                    customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Checked = false;
                    customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.Checked = false;
                }
            }

            if (customerDetailTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelNoRadioButton.Checked)
            {
                customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Enabled = false;
                customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelTopParentRadioButton.Enabled = false;
                customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Checked = false;
                customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelTopParentRadioButton.Checked = false;
            }
            else if (customerDetailTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelYesRadioButton.Checked)
            {
                customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Enabled = true;
                customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelTopParentRadioButton.Enabled = true;
            }

            if (customerDetailTabControlOverviewTabPageExistingParentCompanyPanelNoRadioButton.Checked)
            {
                customerDetailTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelNoRadioButton.Enabled = true;
                customerDetailTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelYesRadioButton.Enabled = true;
            }
        }

        private void CustomerDetailFinanceCreditEnabledCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (customerDetailTabControlFinanceTabPageCreditEnabledCheckbox.Checked)
            {
                customerDetailTabControlFinanceTabPageCreditLimitTextboxA.Enabled = true;
                customerDetailTabControlFinanceTabPageTextboxB.Enabled = true;
            }
            else
            {
                customerDetailTabControlFinanceTabPageCreditLimitTextboxA.Enabled = false;
                customerDetailTabControlFinanceTabPageTextboxB.Enabled = false;
            }
        }

        private void CustomerDetailFinanceVATRegisteredCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (customerDetailTabControlFinanceTabPageVATRegisteredCheckbox.Checked)
            {
                customerDetailTabControlFinanceTabPageVATNumberTextbox.Enabled = true;
            }
            else
            {
                customerDetailTabControlFinanceTabPageVATNumberTextbox.Enabled = false;
                customerDetailTabControlFinanceTabPageVATNumberTextbox.Text = string.Empty;
            }
        }

        private void CustomerDetailFinanceVATRegisteredCheckbox_CheckedChanged(object? sender, EventArgs e)
        {
            if (!customerDetailTabControlFinanceTabPageVATRegisteredCheckbox.Checked)
            {
                var result = MessageBox.Show(
                    "A VAT Number cannot be assigned if VAT Registered is false. Clicking OK will clear the VAT Number field. Clicking Cancel will reverse the changes.",
                    "Warning",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    customerDetailTabControlFinanceTabPageVATNumberTextbox.Text = string.Empty;
                }
                else
                {
                    customerDetailTabControlFinanceTabPageVATRegisteredCheckbox.Checked = true;
                }
            }
        }

        private async void CustomerDetailCustomerInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            string storedProcedureName = "spGetCustomer";
            string dataSubject = "Customer";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "customerId",
                    ParameterValue = _customerId
                }
            };
            try
            {
                DataTable? customerDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject);

                if (customerDataTable != null)
                {
                    DataRow customerDataRow = customerDataTable.Rows[0];

                    Guid companyConfigurationId = (Guid)customerDataRow["Company Configuration Id"];
                    await LoadCompanyConfigurationAsync(companyConfigurationId);
                    customerDetailTabControlBillingInformationTabPageAddressLine1Textbox.Text = customerDataRow["Billing Address Line 1"].ToString();
                    customerDetailTabControlBillingInformationTabPageAddressLine2Textbox.Text = customerDataRow["Billing Address Line 2"].ToString();
                    customerDetailTabControlBillingInformationTabPageAddressLine3Textbox.Text = customerDataRow["Billing Address Line 3"].ToString();
                    customerDetailTabControlBillingInformationTabPageAddressLine4Textbox.Text = customerDataRow["Billing Address Line 4"].ToString();
                    Guid billingAddressLine5 = (Guid)customerDataRow["Billing Address Line 5"];
                    await LoadCountryDataAsync(billingAddressLine5, "billing");
                    customerDetailTabControlBillingInformationTabPageCompanyNameTextbox.Text = customerDataRow["Billing Company Name"].ToString();
                    customerDetailTabControlBillingInformationTabPageEmailAddressTextbox.Text = customerDataRow["Billing Email Address"].ToString();
                    customerDetailTabControlBillingInformationTabPageFirstNameTextbox.Text = customerDataRow["Billing First Name"].ToString();
                    customerDetailTabControlBillingInformationTabPageLastNameTextbox.Text = customerDataRow["Billing Last Name"].ToString();
                    customerDetailTabControlBillingInformationTabPageTelephoneNumberTextbox.Text = customerDataRow["Billing Telephone Number"].ToString();
                    customerDetailTabControlFinanceTabPageCreditEnabledCheckbox.Checked = (bool)customerDataRow["Credit Enabled"];
                    string creditLimitPartA;
                    string creditLimitPartB;
                    SplitDecimalHelper.SplitDecimalUsingDelimiter((decimal)customerDataRow["Credit Limit"], out creditLimitPartA, out creditLimitPartB);
                    customerDetailTabControlFinanceTabPageCreditLimitTextboxA.Text = creditLimitPartA;
                    customerDetailTabControlFinanceTabPageTextboxB.Text = creditLimitPartB;
                    string creditLimitUsedPartA;
                    string creditLimitUsedPartB;
                    SplitDecimalHelper.SplitDecimalUsingDelimiter((decimal)customerDataRow["Credit Limit Used"], out creditLimitUsedPartA, out creditLimitUsedPartB);
                    customerDetailTabControlFinanceTabPageCreditLimitUsedTextboxA.Text = creditLimitUsedPartA;
                    customerDetailTabControlFinanceTabPageCreditLimitUsedTextboxB.Text = creditLimitUsedPartB;
                    string creditLimitUsedPercentagePartA;
                    string creditLimitUsedPercentagePartB;
                    SplitDecimalHelper.SplitDecimalUsingDelimiter((decimal)customerDataRow["Credit Limit Used Percentage"], out creditLimitUsedPercentagePartA, out creditLimitUsedPercentagePartB);
                    customerDetailTabControlFinanceTabPageCreditLimitUsedPercentageTextboxA.Text = creditLimitUsedPercentagePartA;
                    customerDetailTabControlFinanceTabPageCreditLimitUsedPercentageTextboxB.Text = creditLimitUsedPercentagePartB;
                    customerDetailTabControlFinanceTabPageCreditEnabledCheckbox.Checked = (bool)customerDataRow["Credit Enabled"];
                    Guid paymentCurrencyId = (Guid)customerDataRow["Payment Currency Id"];
                    await LoadCurrencyDataAsync(paymentCurrencyId);
                    customerDetailTabControlFinanceTabPagePaymentDaysTextbox.Text = customerDataRow["Payment Days"].ToString();
                    customerDetailTabControlFinanceTabPageVATNumberTextbox.Text = customerDataRow["VAT Number"].ToString();
                    Guid accountManagerId = (Guid)customerDataRow["Account Manager Id"];
                    await LoadAccountManagerDataAsync(accountManagerId, companyConfigurationId);
                    customerDetailTabControlOverviewTabPageActiveStatusCheckbox.Checked = (bool)customerDataRow["Active Status"];
                    customerDetailTabControlOverviewTabPageCompanyNameTextbox.Text = customerDataRow["Company Name"].ToString();
                    customerDetailTabControlOverviewTabPageCreatedByTextbox.Text = customerDataRow["Created By"].ToString();
                    customerDetailTabControlOverviewTabPageCreatedTimestampTextbox.Text = customerDataRow["Created Timestamp UTC"].ToString();
                    customerDetailTabControlOverviewTabPageCustomerIdTextbox.Text = customerDataRow["Customer Id"].ToString();
                    customerDetailTabControlOverviewTabPageCustomerSinceDatePicker.Value = (DateTime)customerDataRow["Customer Since"];
                    Guid customerTierId = (Guid)customerDataRow["Customer Tier Id"];
                    await LoadCustomerTierDataAsync(companyConfigurationId, customerTierId);
                    Guid customerTypeId = (Guid)customerDataRow["Customer Type Id"];
                    await LoadCustomerTypeAsync(companyConfigurationId, customerTypeId);
                    customerDetailTabControlOverviewTabPageEmailAddressTextbox.Text = customerDataRow["Email Address"].ToString();
                    if ((bool)customerDataRow["Global Parent Customer"] || (bool)customerDataRow["Top Parent Customer"])
                    {
                        customerDetailTabControlOverviewTabPageExistingParentCompanyPanelYesRadioButton.Checked = true;
                    }
                    else
                    {
                        customerDetailTabControlOverviewTabPageExistingParentCompanyPanelNoRadioButton.Checked = true;
                    }
                    if ((bool)customerDataRow["Global Parent Customer"])
                    {
                        customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.Checked = true;
                        customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Checked = true;
                    }
                    else
                    {
                        customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.Checked = false;
                        customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Checked = false;
                    }
                    if ((bool)customerDataRow["Top Parent Customer"])
                    {
                        customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.Checked = true;
                        customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelTopParentRadioButton.Checked = true;
                    }
                    else
                    {
                        customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.Checked = false;
                        customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelTopParentRadioButton.Checked = false;
                    }
                    if (customerDataRow["Global Parent Customer Id"] != null)
                    {
                        Guid existingGlobalParentCustomerId = (Guid)customerDataRow["Global Parent Customer Id"];
                        await LoadGlobalParentCustomerDataAsync(existingGlobalParentCustomerId);
                    }
                    if (customerDataRow["Top Parent Customer Id"] != null)
                    {
                        Guid existingTopParentCustomerId = (Guid)customerDataRow["Top Parent Customer Id"];
                        await LoadTopParentCustomerDataAsync(existingTopParentCustomerId);
                    }
                    customerDetailTabControlOverviewTabPageFirstNameTextbox.Text = customerDataRow["First Name"].ToString();
                    customerDetailTabControlOverviewTabPageLastNameTextbox.Text = customerDataRow["Last Name"].ToString();
                    customerDetailTabControlOverviewTabPageLastUpdatedByTextbox.Text = customerDataRow["Modified By"].ToString();
                    customerDetailTabControlOverviewTabPageLastUpdatedTimestampTextbox.Text = customerDataRow["Modified Timestamp UTC"].ToString();
                    Guid salesRegionId = (Guid)customerDataRow["Sales Region Id"];
                    await LoadSalesRegionDataAsync(companyConfigurationId, salesRegionId);
                    Guid salesSubRegionid = (Guid)customerDataRow["Sales Sub Region Id"];
                    await LoadSalesSubRegionAsync(salesRegionId, salesSubRegionid);
                    customerDetailTabControlOverviewTabPageTelephoneNumberTextbox.Text = customerDataRow["Telephone Number"].ToString();
                    customerDetailTabControlShippingInformationTabPageAddressLine1Textbox.Text = customerDataRow["Shipping Address Line 1"].ToString();
                    customerDetailTabControlShippingInformationTabPageAddressLine2Textbox.Text = customerDataRow["Shipping Address Line 2"].ToString();
                    customerDetailTabControlShippingInformationTabPageAddressLine3Textbox.Text = customerDataRow["Shipping Address Line 3"].ToString();
                    customerDetailTabControlShippingInformationTabPageAddressLine4Textbox.Text = customerDataRow["Shipping Address Line 4"].ToString();
                    Guid shippingAddressLine5 = (Guid)customerDataRow["Shipping Address Line 5"];
                    await LoadCountryDataAsync(shippingAddressLine5, "shipping");
                    customerDetailTabControlShippingInformationTabPageCompanyNameTextbox.Text = customerDataRow["Shipping Company Name"].ToString();
                    customerDetailTabControlShippingInformationTabPageEmailAddressTextbox.Text = customerDataRow["Shipping Email Address"].ToString();
                    customerDetailTabControlShippingInformationTabPageFirstNameTextbox.Text = customerDataRow["Shipping First Name"].ToString();
                    customerDetailTabControlShippingInformationTabPageLastNameTextbox.Text = customerDataRow["Shipping Last Name"].ToString();
                    customerDetailTabControlShippingInformationTabPageTelephoneNumberTextbox.Text = customerDataRow["Shipping Telephone Number"].ToString();

                    customerDetailTabControlBillingInformationTabPageAddressLine1OriginalValue = customerDataRow["Billing Address Line 1"].ToString();
                    customerDetailTabControlBillingInformationTabPageAddressLine2OriginalValue = customerDataRow["Billing Address Line 2"].ToString();
                    customerDetailTabControlBillingInformationTabPageAddressLine3OriginalValue = customerDataRow["Billing Address Line 3"].ToString();
                    customerDetailTabControlBillingInformationTabPageAddressLine4OriginalValue = customerDataRow["Billing Address Line 4"].ToString();
                    customerDetailTabControlBillingInformationTabPageAddressLine5OriginalValue = (Guid)customerDataRow["Billing Address Line 5"];
                    customerDetailTabControlBillingInformationTabPageCompanyNameOriginalValue = customerDataRow["Billing Company Name"].ToString();
                    customerDetailTabControlBillingInformationTabPageEmailAddressOriginalValue = customerDataRow["Billing Email Address"].ToString();
                    customerDetailTabControlBillingInformationTabPageFirstNameOriginalValue = customerDataRow["Billing First Name"].ToString();
                    customerDetailTabControlBillingInformationTabPageLastNameOriginalValue = customerDataRow["Billing Last Name"].ToString();
                    customerDetailTabControlBillingInformationTabPageTelephoneNumberOriginalValue = customerDataRow["Billing Telephone Number"].ToString();
                    customerDetailTabControlFinanceCreditEnabledOriginalValue = (bool)customerDataRow["Credit Enabled"];
                    customerDetailTabControlFinanceCreditLimitOriginalValue = (decimal)customerDataRow["Credit Limit"];
                    customerDetailTabControlFinancePaymentCurrencyIdOriginalValue = (Guid)customerDataRow["Payment Currency Id"];
                    customerDetailTabControlFinancePaymentDaysOriginalValue = (int)customerDataRow["Payment Days"];
                    if (customerDataRow["VAT Number"] != DBNull.Value && customerDataRow["VAT Number"] != null)
                    {
                        customerDetailTabControlFinanceVATNumberOriginalValue = customerDataRow["VAT Number"].ToString();
                        customerDetailTabControlFinanceVATRegisteredOriginalValue = true;
                    }
                    customerDetailTabControlOverviewTabPageAccountManagerIdOriginalValue = (Guid)customerDataRow["Account Manager Id"];
                    customerDetailTabControlOverviewTabPageActiveStatusOriginalValue = (bool)customerDataRow["Active Status"];
                    customerDetailTabControlOverviewTabPageCompanyConfigurationIdOriginalValue = (Guid)customerDataRow["Company Configuration Id"];
                    customerDetailTabControlOverviewTabPageCompanyNameOriginalValue = customerDataRow["Company Name"].ToString();
                    customerDetailTabControlOverviewTabPageCustomerTierIdOriginalValue = (Guid)customerDataRow["Customer Tier Id"];
                    customerDetailTabControlOverviewTabPageCustomerTypeIdOriginalValue = (Guid)customerDataRow["Customer Type Id"];
                    customerDetailTabControlOverviewTabPageEmailAddressOriginalValue = customerDataRow["Email Address"].ToString();
                    if ((bool)customerDataRow["Global Parent Customer"] || (bool)customerDataRow["Top Parent Customer"])
                    {
                        customerDetailTabControlOverviewTabPageWillBeParentInCustomerHierarchyOriginalValue = true;
                    }
                    else
                    {
                        customerDetailTabControlOverviewTabPageWillBeParentInCustomerHierarchyOriginalValue = false;
                    }
                    if ((bool)customerDataRow["Global Parent Customer"])
                    {
                        customerDetailTabControlOverviewTabPageExistingParentCompanyTypeGlobalParentOriginalValue = true;
                    }
                    else
                    {
                        customerDetailTabControlOverviewTabPageExistingParentCompanyTypeGlobalParentOriginalValue = false;
                    }
                    if ((bool)customerDataRow["Top Parent Customer"])
                    {
                        customerDetailTabControlOverviewTabPageExistingParentCompanyTypeTopParentOriginalValue = true;
                    }
                    else
                    {
                        customerDetailTabControlOverviewTabPageExistingParentCompanyTypeTopParentOriginalValue = false;
                    }
                    customerDetailTabControlOverviewTabPageFirstNameOriginalValue = customerDataRow["First Name"].ToString();
                    customerDetailTabControlOverviewTabPageGlobalParentCustomerIdOriginalValue = (Guid)customerDataRow["Global Parent Customer Id"];
                    customerDetailTabControlOverviewTabPageLastNameOriginalValue = customerDataRow["Last Name"].ToString();
                    customerDetailTabControlOverviewTabPageSalesRegionIdOriginalValue = (Guid)customerDataRow["Sales Region Id"];
                    customerDetailTabControlOverviewTabPageSalesSubRegionIdOriginalValue = (Guid)customerDataRow["Sales Sub Region Id"];
                    customerDetailTabControlOverviewTabPageTelephoneNumberOriginalValue = customerDataRow["Telephone Number"].ToString();
                    customerDetailTabControlOverviewTabPageTopParentCustomerIdOriginalValue = (Guid)customerDataRow["Top Parent Customer Id"];
                    customerDetailTabControlShippingInformationAddressLine1OriginalValue = customerDataRow["Shipping Address Line 1"].ToString();
                    customerDetailTabControlShippingInformationAddressLine2OriginalValue = customerDataRow["Shipping Address Line 2"].ToString();
                    customerDetailTabControlShippingInformationAddressLine3OriginalValue = customerDataRow["Shipping Address Line 3"].ToString();
                    customerDetailTabControlShippingInformationAddressLine4OriginalValue = customerDataRow["Shipping Address Line 4"].ToString();
                    customerDetailTabControlShippingInformationAddressLine5OriginalValue = (Guid)customerDataRow["Shipping Address Line 5"];
                    customerDetailTabControlShippingInformationCompanyNameOriginalValue = customerDataRow["Shipping Company Name"].ToString();
                    customerDetailTabControlShippingInformationEmailAddressOriginalValue = customerDataRow["Shipping Email Address"].ToString();
                    customerDetailTabControlShippingInformationFirstNameOriginalValue = customerDataRow["Shipping First Name"].ToString();
                    customerDetailTabControlShippingInformationLastNameOriginalValue = customerDataRow["Shipping Last Name"].ToString();
                    customerDetailTabControlShippingInformationTelephoneNumberOriginalValue = customerDataRow["Shipping Telephone Number"].ToString();

                    this.Text += $" ({customerDetailTabControlShippingInformationCompanyNameOriginalValue})";

					if (customerDetailTabControlOverviewTabPageCompanyNameOriginalValue == null)
					{
						customerDisplayName = $"{customerDetailTabControlOverviewTabPageLastNameOriginalValue}, {customerDetailTabControlOverviewTabPageFirstNameOriginalValue}";
					}
					else
					{
						customerDisplayName = customerDetailTabControlOverviewTabPageCompanyNameOriginalValue;
					}
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

        private async void CustomerDetailTabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (customerDetailTabControl.SelectedTab == customerDetailTabControl.TabPages["customerDetailTabControlCustomerContactTabPage"])
            {
                await CustomerDetailExistingCustomerContact_Load(sender, e);
            }
            if (customerDetailTabControl.SelectedTab == customerDetailTabControl.TabPages["customerDetailTabControlCustomerLeadTabPage"])
            {
                await CustomerDetailExistingCustomerLead_Load(sender, e);
            }
            if (customerDetailTabControl.SelectedTab == customerDetailTabControl.TabPages["customerDetailTabControlCustomerNoteTabPage"])
            {
                await CustomerDetailExistingCustomerNote_Load(sender, e);
            }
        }

        private async Task CustomerDetailExistingCustomerContact_Load(object sender, EventArgs e)
        {
            await DataAccessDataGridViewHelper.LoadDataGridViewAsync(
                _databaseConnectionSettings,
                _customerId,
                "customerId",
                "spGetAllCustomerContactForCustomer",
                "Existing Customer Contacts",
                customerDetailTabControlCustomerContactTabPageDataGridView,
                "Customer Contact Id",
                "View Customer Contact",
                "DESC",
                "Created Timestamp"
            );
        }

        private async Task CustomerDetailExistingCustomerLead_Load(object sender, EventArgs e)
        {
            await DataAccessDataGridViewHelper.LoadDataGridViewAsync(
                _databaseConnectionSettings,
                _customerId,
                "customerId",
                "spGetAllCustomerLeadForCustomer",
                "Existing Customer Leads",
                customerDetailTabControlCustomerLeadTabPageDataGridView,
                "Customer Lead Id",
                "View Customer Lead",
                "DESC",
                "Created Timestamp"
            );
        }

        private async Task CustomerDetailExistingCustomerNote_Load(object sender, EventArgs e)
        {
            await DataAccessDataGridViewHelper.LoadDataGridViewAsync(
                _databaseConnectionSettings,
                _customerId,
                "customerId",
                "spGetAllNoteForCustomer",
                "Existing Customer Notes",
                customerDetailTabControlCustomerNoteTabPageDataGridView,
                "Customer Note Id",
                "View Customer Note",
                "DESC",
                "Created Timestamp"
            );
        }

        private void customerDetailTabControlCustomerContactTabPageDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            DataAccessDataGridViewHelper.HandleDetailsCellClick(
            customerDetailTabControlCustomerContactTabPageDataGridView,
            e,
            "Customer Contact Id",
            "Customer Contact",
            id => {
                var contactDetail = new ContactDetail("CustomerContact", id, customerDisplayName, _customerId);
                contactDetail.Show();
            });
        }

        private void customerDetailTabControlCustomerLeadTabPageDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            DataAccessDataGridViewHelper.HandleDetailsCellClick(
            customerDetailTabControlCustomerLeadTabPageDataGridView,
            e,
            "Customer Lead Id",
            "Customer Lead",
            id => {
                var customerLeadDetail = new CustomerLeadDetail(_customerId, id, customerDisplayName);
                customerLeadDetail.Show();
            });
        }

        private void customerDetailTabControlCustomerNoteTabPageDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            DataAccessDataGridViewHelper.HandleDetailsCellClick(
            customerDetailTabControlCustomerNoteTabPageDataGridView,
            e,
            "Customer Note Id",
            "Customer Note",
            id => {
                var noteDetail = new NoteDetail(_customerId, "Customer", id, customerDisplayName);
                noteDetail.Show();
            });
        }

        private async void customerDetailUpdateCustomerButton_Click(object sender, EventArgs e)
        {
            string customerBillingInformationAddressLine1 = customerDetailTabControlBillingInformationTabPageAddressLine1Textbox.Text.TrimEnd();
            string? customerBillingInformationAddressLine2 = customerDetailTabControlBillingInformationTabPageAddressLine2Textbox.Text.TrimEnd();
            string customerBillingInformationAddressLine3 = customerDetailTabControlBillingInformationTabPageAddressLine3Textbox.Text.TrimEnd();
            string customerBillingInformationAddressLine4 = customerDetailTabControlBillingInformationTabPageAddressLine4Textbox.Text.TrimEnd();
            Guid customerBillingInformationAddressLine5 = Guid.Parse(customerDetailTabControlBillingInformationTabPageAddressLine5ComboBox.SelectedValue.ToString());
            string? customerBillingInformationCompanyName = customerDetailTabControlBillingInformationTabPageCompanyNameTextbox.Text.TrimEnd();
            string customerBillingInformationEmailAddress = customerDetailTabControlBillingInformationTabPageEmailAddressTextbox.Text.TrimEnd();
            string customerBillingInformationFirstName = customerDetailTabControlBillingInformationTabPageFirstNameTextbox.Text.TrimEnd();
            string customerBillingInformationLastName = customerDetailTabControlBillingInformationTabPageLastNameTextbox.Text.TrimEnd();
            string customerBillingInformationTelephoneNumber = customerDetailTabControlBillingInformationTabPageTelephoneNumberTextbox.Text.TrimEnd();

            bool customerFinanceCreditEnabled = customerDetailTabControlFinanceTabPageCreditEnabledCheckbox.Checked;
            decimal customerFinanceCreditLimit = decimal.Parse($"{customerDetailTabControlFinanceTabPageCreditLimitTextboxA.Text.TrimEnd()}.{customerDetailTabControlFinanceTabPageTextboxB.Text.TrimEnd()}");
            Guid customerFinancePaymentCurrencyId = Guid.Parse(customerDetailTabControlFinanceTabPagePaymentCurrencyComboBox.SelectedValue.ToString());
            byte customerFinancePaymentDays = byte.Parse(customerDetailTabControlFinanceTabPagePaymentDaysTextbox.Text.TrimEnd());
            string? customerFinanceVATNumber = customerDetailTabControlFinanceTabPageVATNumberTextbox.Text.TrimEnd();

            Guid customerOverviewAccountManagerId = Guid.Parse(customerDetailTabControlOverviewTabPageAccountManagerComboBox.SelectedValue.ToString());
            bool customerOverviewActiveStatus = customerDetailTabControlOverviewTabPageActiveStatusCheckbox.Checked;
            Guid customerOverviewCompanyConfigurationId = Guid.Parse(customerDetailTabControlOverviewTabPageCompanyConfigurationComboBox.SelectedValue.ToString());
            string? customerOverviewCompanyName = customerDetailTabControlOverviewTabPageCompanyNameTextbox.Text.TrimEnd();
            DateTime customerOverviewCustomerSince = customerDetailTabControlOverviewTabPageCustomerSinceDatePicker.Value.Date;
            Guid customerOverviewCustomerTierId = Guid.Parse(customerDetailTabControlOverviewTabPageCustomerTierComboBox.SelectedValue.ToString());
            Guid customerOverviewCustomerTypeId = Guid.Parse(customerDetailTabControlOverviewTabPageCustomerTypeComboBox.SelectedValue.ToString());
            string customerOverviewEmailAddress = customerDetailTabControlOverviewTabPageEmailAddressTextbox.Text.TrimEnd();
            Guid? customerOverviewExistingGlobalParentCustomerId = null;
            if (customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.SelectedValue != null)
            {
                customerOverviewExistingGlobalParentCustomerId = Guid.Parse(customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.SelectedValue.ToString());
            }
            Guid? customerOverviewExistingTopParentCustomerId = null;
            if (customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.SelectedValue != null)
            {
                customerOverviewExistingTopParentCustomerId = Guid.Parse(customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.SelectedValue.ToString());
            }
            string customerOverviewFirstName = customerDetailTabControlOverviewTabPageFirstNameTextbox.Text.TrimEnd();
            string customerOverviewLastName = customerDetailTabControlOverviewTabPageLastNameTextbox.Text.TrimEnd();
            Guid customerOverviewSalesSubRegionId = Guid.Parse(customerDetailTabControlOverviewTabPageSalesSubRegionComboBox.SelectedValue.ToString());
            string customerOverviewTelephoneNumber = customerDetailTabControlOverviewTabPageTelephoneNumberTextbox.Text.TrimEnd();
            bool customerOverviewWillBeGlobalParent = customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Checked;
            bool customerOverviewWillBeTopParent = customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelTopParentRadioButton.Checked;

            string customerShippingInformationAddressLine1 = customerDetailTabControlShippingInformationTabPageAddressLine1Textbox.Text.TrimEnd();
            string? customerShippingInformationAddressLine2 = customerDetailTabControlShippingInformationTabPageAddressLine2Textbox.Text.TrimEnd();
            string customerShippingInformationAddressLine3 = customerDetailTabControlShippingInformationTabPageAddressLine3Textbox.Text.TrimEnd();
            string customerShippingInformationAddressLine4 = customerDetailTabControlShippingInformationTabPageAddressLine4Textbox.Text.TrimEnd();
            Guid customerShippingInformationAddressLine5 = Guid.Parse(customerDetailTabControlShippingInformationTabPageAddressLine5ComboBox.SelectedValue.ToString());
            string? customerShippingInformationCompanyName = customerDetailTabControlShippingInformationTabPageCompanyNameTextbox.Text.TrimEnd();
            string customerShippingInformationEmailAddress = customerDetailTabControlShippingInformationTabPageEmailAddressTextbox.Text.TrimEnd();
            string customerShippingInformationFirstName = customerDetailTabControlShippingInformationTabPageFirstNameTextbox.Text.TrimEnd();
            string customerShippingInformationLastName = customerDetailTabControlShippingInformationTabPageLastNameTextbox.Text.TrimEnd();
            string customerShippingInformationTelephoneNumber = customerDetailTabControlShippingInformationTabPageTelephoneNumberTextbox.Text.TrimEnd();

            string dataSubject = "Customer";

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
                    Name = "Customer Billing Information: Address Line 1",
                    Value = customerBillingInformationAddressLine1,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Customer Billing Information: Address Line 2",
                    Value = customerBillingInformationAddressLine2,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Billing Information: Address Line 3",
                    Value = customerBillingInformationAddressLine3,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Billing Information: Address Line 4",
                    Value = customerBillingInformationAddressLine4,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Billing Information: Address Line 5",
                    Value = customerBillingInformationAddressLine5,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Customer Billing Information: Company Name",
                    Value = customerBillingInformationCompanyName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Billing Information: Email Address",
                    Value = customerBillingInformationEmailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Billing Information: First Name",
                    Value = customerBillingInformationFirstName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Billing Information: Last Name",
                    Value = customerBillingInformationLastName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Billing Information: Telephone Number",
                    Value = customerBillingInformationTelephoneNumber,
                    MaxLength = 13,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Finance: Credit Enabled",
                    Value = customerFinanceCreditEnabled,
                    ValueType = typeof(bool)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Finance: Credit Limit",
                    Value = customerFinanceCreditLimit,
                    ValueType = typeof(decimal)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Finance: Payment Currency Id",
                    Value = customerFinancePaymentCurrencyId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Finance: Payment Days",
                    Value = customerFinancePaymentDays,
                    ValueType = typeof(byte)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Company Finance: VAT Number",
                    Value = customerFinanceVATNumber,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Account Manager Id",
                    Value = customerOverviewAccountManagerId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Active Status",
                    Value = customerOverviewActiveStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Company Configuration Id",
                    Value = customerOverviewCompanyConfigurationId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Customer Overview: Company Name",
                    Value = customerOverviewCompanyName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Customer Since",
                    Value = customerOverviewCustomerSince,
                    ValueType = typeof(DateTime)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Customer Tier Id",
                    Value = customerOverviewCustomerTierId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Customer Type Id",
                    Value = customerOverviewCustomerTypeId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Email Address",
                    Value = customerOverviewEmailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Customer Overview: Existing Global Parent Customer Id",
                    Value = customerOverviewExistingGlobalParentCustomerId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Customer Overview: Existing Top Parent Customer Id",
                    Value = customerOverviewExistingTopParentCustomerId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: First Name",
                    Value = customerOverviewFirstName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Last Name",
                    Value = customerOverviewLastName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Sales Sub Region Id",
                    Value = customerOverviewSalesSubRegionId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Telephone Number",
                    Value = customerOverviewTelephoneNumber,
                    MaxLength = 13,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Will Be Global Parent",
                    Value = customerOverviewWillBeGlobalParent,
                    ValueType = typeof(bool)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Will Be Top Parent",
                    Value = customerOverviewWillBeTopParent,
                    ValueType = typeof(bool)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Telephone Number",
                    Value = customerOverviewTelephoneNumber,
                    MaxLength = 13,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Shipping Information: Address Line 1",
                    Value = customerShippingInformationAddressLine1,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Customer Shipping Information: Address Line 2",
                    Value = customerShippingInformationAddressLine2,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Shipping Information: Address Line 3",
                    Value = customerShippingInformationAddressLine3,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Shipping Information: Address Line 4",
                    Value = customerShippingInformationAddressLine4,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Shipping Information: Address Line 5",
                    Value = customerShippingInformationAddressLine5,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Customer Shipping Information: Company Name",
                    Value = customerShippingInformationCompanyName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Shipping Information: Email Address",
                    Value = customerShippingInformationEmailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Shipping Information: First Name",
                    Value = customerShippingInformationFirstName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Shipping Information: Last Name",
                    Value = customerShippingInformationLastName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Shipping Information: Telephone Number",
                    Value = customerShippingInformationTelephoneNumber,
                    MaxLength = 13,
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
                var parameters = new List<Parameter>
                {
                    new Parameter
                    {
                        ParameterName = "accountManagerId",
                        ParameterValue = customerOverviewAccountManagerId
                    },
                    new Parameter
                    {
                        ParameterName = "activeStatus",
                        ParameterValue = customerOverviewActiveStatus
                    },
                    new Parameter
                    {
                        ParameterName = "billingFirstName",
                        ParameterValue = customerBillingInformationFirstName
                    },
                    new Parameter
                    {
                        ParameterName = "billingLastName",
                        ParameterValue = customerBillingInformationLastName
                    },
                    new Parameter
                    {
                        ParameterName = "billingAddressLine1",
                        ParameterValue = customerBillingInformationAddressLine1
                    },
                    new Parameter
                    {
                        ParameterName = "billingAddressLine3",
                        ParameterValue = customerBillingInformationAddressLine3
                    },
                    new Parameter
                    {
                        ParameterName = "billingAddressLine4",
                        ParameterValue = customerBillingInformationAddressLine4
                    },
                    new Parameter
                    {
                        ParameterName = "billingAddressLine5",
                        ParameterValue = customerBillingInformationAddressLine5
                    },
                    new Parameter
                    {
                        ParameterName = "billingTelephoneNumber",
                        ParameterValue = customerBillingInformationTelephoneNumber
                    },
                    new Parameter
                    {
                        ParameterName = "billingEmailAddress",
                        ParameterValue = customerBillingInformationEmailAddress
                    },
                    new Parameter
                    {
                        ParameterName = "companyConfigurationId",
                        ParameterValue = customerOverviewCompanyConfigurationId
                    },
                    new Parameter
                    {
                        ParameterName = "creditEnabled",
                        ParameterValue = customerFinanceCreditEnabled
                    },
                    new Parameter
                    {
                        ParameterName = "customerSince",
                        ParameterValue = customerOverviewCustomerSince
                    },
                    new Parameter
                    {
                        ParameterName = "customerTierId",
                        ParameterValue = customerOverviewCustomerTierId
                    },
                    new Parameter
                    {
                        ParameterName = "customerTypeId",
                        ParameterValue = customerOverviewCustomerTypeId
                    },
                    new Parameter
                    {
                        ParameterName = "emailAddress",
                        ParameterValue = customerOverviewEmailAddress
                    },
                    new Parameter
                    {
                        ParameterName = "firstName",
                        ParameterValue = customerOverviewFirstName
                    },
                    new Parameter
                    {
                        ParameterName = "globalParentCustomer",
                        ParameterValue = customerOverviewWillBeGlobalParent
                    },
                    new Parameter
                    {
                        ParameterName = "lastName",
                        ParameterValue = customerOverviewLastName
                    },
                    new Parameter
                    {
                        ParameterName = "paymentCurrencyId",
                        ParameterValue = customerFinancePaymentCurrencyId
                    },
                    new Parameter
                    {
                        ParameterName = "paymentDays",
                        ParameterValue = customerFinancePaymentDays
                    },
                    new Parameter
                    {
                        ParameterName = "salesSubRegionId",
                        ParameterValue = customerOverviewSalesSubRegionId
                    },
                    new Parameter
                    {
                        ParameterName = "shippingFirstName",
                        ParameterValue = customerShippingInformationFirstName
                    },
                    new Parameter
                    {
                        ParameterName = "shippingLastName",
                        ParameterValue = customerShippingInformationLastName
                    },
                    new Parameter
                    {
                        ParameterName = "shippingAddressLine1",
                        ParameterValue = customerShippingInformationAddressLine1
                    },
                    new Parameter
                    {
                        ParameterName = "shippingAddressLine3",
                        ParameterValue = customerShippingInformationAddressLine3
                    },
                    new Parameter
                    {
                        ParameterName = "shippingAddressLine4",
                        ParameterValue = customerShippingInformationAddressLine4
                    },
                    new Parameter
                    {
                        ParameterName = "shippingAddressLine5",
                        ParameterValue = customerShippingInformationAddressLine5
                    },
                    new Parameter
                    {
                        ParameterName = "shippingTelephoneNumber",
                        ParameterValue = customerShippingInformationTelephoneNumber
                    },
                    new Parameter
                    {
                        ParameterName = "shippingEmailAddress",
                        ParameterValue = customerShippingInformationEmailAddress
                    },
                    new Parameter
                    {
                        ParameterName = "telephoneNumber",
                        ParameterValue = customerOverviewTelephoneNumber
                    },
                    new Parameter
                    {
                        ParameterName = "topParentCustomer",
                        ParameterValue = customerOverviewWillBeTopParent
                    },
                    new Parameter
                    {
                        ParameterName = "vatNumber",
                        ParameterValue = customerFinanceVATNumber
                    }
                };

                if (!string.IsNullOrEmpty(customerOverviewCompanyName))
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "companyName",
                        ParameterValue = customerOverviewCompanyName
                    });
                }

                if (!string.IsNullOrEmpty(customerBillingInformationAddressLine2))
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "billingAddressLine2",
                        ParameterValue = customerBillingInformationAddressLine2
                    });
                }

                if (!string.IsNullOrEmpty(customerBillingInformationCompanyName))
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "billingCompanyName",
                        ParameterValue = customerBillingInformationCompanyName
                    });
                }

                if (customerOverviewExistingGlobalParentCustomerId != null && customerOverviewExistingGlobalParentCustomerId != Guid.Empty)
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "globalParentCustomerId",
                        ParameterValue = customerOverviewExistingGlobalParentCustomerId
                    });
                }

                if (!string.IsNullOrEmpty(customerShippingInformationAddressLine2))
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "shippingAddressLine2",
                        ParameterValue = customerShippingInformationAddressLine2
                    });
                }

                if (!string.IsNullOrEmpty(customerShippingInformationCompanyName))
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "shippingCompanyName",
                        ParameterValue = customerShippingInformationCompanyName
                    });
                }

                if (customerOverviewExistingTopParentCustomerId != null && customerOverviewExistingTopParentCustomerId != Guid.Empty)
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "topParentCustomerId",
                        ParameterValue = customerOverviewExistingTopParentCustomerId
                    });
                }

                string storedProcedureName = "spUpdateCustomer";
                string operationType = "update";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters.ToArray(), dataSubject, operationType);
                this.Close();
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            CustomerDetailCustomerInformation_Load(this, EventArgs.Empty);
        }

        private void customerDetailToggleEditModeButton_Click(object sender, EventArgs e)
        {
            customerDetailTabControlBillingInformationTabPageAddressLine1Textbox.ReadOnly = !customerDetailTabControlBillingInformationTabPageAddressLine1Textbox.ReadOnly;
            customerDetailTabControlBillingInformationTabPageAddressLine2Textbox.ReadOnly = !customerDetailTabControlBillingInformationTabPageAddressLine2Textbox.ReadOnly;
            customerDetailTabControlBillingInformationTabPageAddressLine3Textbox.ReadOnly = !customerDetailTabControlBillingInformationTabPageAddressLine3Textbox.ReadOnly;
            customerDetailTabControlBillingInformationTabPageAddressLine4Textbox.ReadOnly = !customerDetailTabControlBillingInformationTabPageAddressLine4Textbox.ReadOnly;
            customerDetailTabControlBillingInformationTabPageAddressLine5ComboBox.Enabled = !customerDetailTabControlBillingInformationTabPageAddressLine5ComboBox.Enabled;
            customerDetailTabControlBillingInformationTabPageCompanyNameTextbox.ReadOnly = !customerDetailTabControlBillingInformationTabPageCompanyNameTextbox.ReadOnly;
            customerDetailTabControlBillingInformationTabPageEmailAddressTextbox.ReadOnly = !customerDetailTabControlBillingInformationTabPageEmailAddressTextbox.ReadOnly;
            customerDetailTabControlBillingInformationTabPageFirstNameTextbox.ReadOnly = !customerDetailTabControlBillingInformationTabPageFirstNameTextbox.ReadOnly;
            customerDetailTabControlBillingInformationTabPageLastNameTextbox.ReadOnly = !customerDetailTabControlBillingInformationTabPageLastNameTextbox.ReadOnly;
            customerDetailTabControlBillingInformationTabPageTelephoneNumberTextbox.ReadOnly = !customerDetailTabControlBillingInformationTabPageTelephoneNumberTextbox.ReadOnly;
            customerDetailTabControlFinanceTabPageCreditEnabledCheckbox.Enabled = !customerDetailTabControlFinanceTabPageCreditEnabledCheckbox.Enabled;
            customerDetailTabControlFinanceTabPageCreditLimitTextboxA.ReadOnly = !customerDetailTabControlFinanceTabPageCreditLimitTextboxA.ReadOnly;
            customerDetailTabControlFinanceTabPageTextboxB.ReadOnly = !customerDetailTabControlFinanceTabPageTextboxB.ReadOnly;
            customerDetailTabControlFinanceTabPagePaymentCurrencyComboBox.Enabled = !customerDetailTabControlFinanceTabPagePaymentCurrencyComboBox.Enabled;
            customerDetailTabControlFinanceTabPagePaymentDaysTextbox.ReadOnly = !customerDetailTabControlFinanceTabPagePaymentDaysTextbox.ReadOnly;
            customerDetailTabControlFinanceTabPageVATRegisteredCheckbox.Enabled = !customerDetailTabControlFinanceTabPageVATRegisteredCheckbox.Enabled;
            customerDetailTabControlFinanceTabPageVATNumberTextbox.ReadOnly = !customerDetailTabControlFinanceTabPageVATNumberTextbox.ReadOnly;
            customerDetailTabControlOverviewTabPageAccountManagerComboBox.Enabled = !customerDetailTabControlOverviewTabPageAccountManagerComboBox.Enabled;
            customerDetailTabControlOverviewTabPageActiveStatusCheckbox.Enabled = !customerDetailTabControlOverviewTabPageActiveStatusCheckbox.Enabled;
            customerDetailTabControlOverviewTabPageCompanyConfigurationComboBox.Enabled = !customerDetailTabControlOverviewTabPageCompanyConfigurationComboBox.Enabled;
            customerDetailTabControlOverviewTabPageCompanyNameTextbox.ReadOnly = !customerDetailTabControlOverviewTabPageCompanyNameTextbox.ReadOnly;
            customerDetailTabControlOverviewTabPageCustomerSinceDatePicker.Enabled = !customerDetailTabControlOverviewTabPageCustomerSinceDatePicker.Enabled;
            customerDetailTabControlOverviewTabPageCustomerTierComboBox.Enabled = !customerDetailTabControlOverviewTabPageCustomerTierComboBox.Enabled;
            customerDetailTabControlOverviewTabPageCustomerTypeComboBox.Enabled = !customerDetailTabControlOverviewTabPageCustomerTypeComboBox.Enabled;
            customerDetailTabControlOverviewTabPageEmailAddressTextbox.ReadOnly = !customerDetailTabControlOverviewTabPageEmailAddressTextbox.ReadOnly;
            customerDetailTabControlOverviewTabPageExistingParentCompanyPanelNoRadioButton.Enabled = !customerDetailTabControlOverviewTabPageExistingParentCompanyPanelNoRadioButton.Enabled;
            customerDetailTabControlOverviewTabPageExistingParentCompanyPanelYesRadioButton.Enabled = !customerDetailTabControlOverviewTabPageExistingParentCompanyPanelYesRadioButton.Enabled;
            customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.Enabled = !customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.Enabled;
            customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.Enabled = !customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.Enabled;
            customerDetailTabControlOverviewTabPageFirstNameTextbox.ReadOnly = !customerDetailTabControlOverviewTabPageFirstNameTextbox.ReadOnly;
            customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.Enabled = !customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.Enabled;
            customerDetailTabControlOverviewTabPageLastNameTextbox.ReadOnly = !customerDetailTabControlOverviewTabPageLastNameTextbox.ReadOnly;
            customerDetailTabControlOverviewTabPageSalesRegionComboBox.Enabled = !customerDetailTabControlOverviewTabPageSalesRegionComboBox.Enabled;
            customerDetailTabControlOverviewTabPageSalesSubRegionComboBox.Enabled = !customerDetailTabControlOverviewTabPageSalesSubRegionComboBox.Enabled;
            customerDetailTabControlOverviewTabPageTelephoneNumberTextbox.ReadOnly = !customerDetailTabControlOverviewTabPageTelephoneNumberTextbox.ReadOnly;
            customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.Enabled = !customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.Enabled;
            customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Enabled = !customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Enabled;
            customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelTopParentRadioButton.Enabled = !customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelTopParentRadioButton.Enabled;
            customerDetailTabControlShippingInformationTabPageAddressLine1Textbox.ReadOnly = !customerDetailTabControlShippingInformationTabPageAddressLine1Textbox.ReadOnly;
            customerDetailTabControlShippingInformationTabPageAddressLine2Textbox.ReadOnly = !customerDetailTabControlShippingInformationTabPageAddressLine2Textbox.ReadOnly;
            customerDetailTabControlShippingInformationTabPageAddressLine3Textbox.ReadOnly = !customerDetailTabControlShippingInformationTabPageAddressLine3Textbox.ReadOnly;
            customerDetailTabControlShippingInformationTabPageAddressLine4Textbox.ReadOnly = !customerDetailTabControlShippingInformationTabPageAddressLine4Textbox.ReadOnly;
            customerDetailTabControlShippingInformationTabPageAddressLine5ComboBox.Enabled = !customerDetailTabControlShippingInformationTabPageAddressLine5ComboBox.Enabled;
            customerDetailTabControlShippingInformationTabPageCompanyNameTextbox.ReadOnly = !customerDetailTabControlShippingInformationTabPageCompanyNameTextbox.ReadOnly;
            customerDetailTabControlShippingInformationTabPageEmailAddressTextbox.ReadOnly = !customerDetailTabControlShippingInformationTabPageEmailAddressTextbox.ReadOnly;
            customerDetailTabControlShippingInformationTabPageFirstNameTextbox.ReadOnly = !customerDetailTabControlShippingInformationTabPageFirstNameTextbox.ReadOnly;
            customerDetailTabControlShippingInformationTabPageLastNameTextbox.ReadOnly = !customerDetailTabControlShippingInformationTabPageLastNameTextbox.ReadOnly;
            customerDetailTabControlShippingInformationTabPageTelephoneNumberTextbox.ReadOnly = !customerDetailTabControlShippingInformationTabPageTelephoneNumberTextbox.ReadOnly;
            customerDetailUpdateCustomerButton.Enabled = !customerDetailUpdateCustomerButton.Enabled;
        }

        private void customerDetailTabControlCustomerContactTabPageCreateNewCustomerContactButton_Click(object sender, EventArgs e)
        {
            CreateContact createContact = new CreateContact(_customerId, "Customer", customerDisplayName);
            createContact.Show();
        }

        private async void customerDetailTabControlCustomerContactTabPageRefreshDataButton_Click(object sender, EventArgs e)
        {
            await CustomerDetailExistingCustomerContact_Load(sender, e);
        }

        private void customerDetailTabControlCustomerLeadTabPageCreateNewCustomerLeadButton_Click(object sender, EventArgs e)
        {
            CreateCustomerLead createCustomerLead = new CreateCustomerLead(_customerId, customerDisplayName);
            createCustomerLead.Show();
        }

        private async void customerDetailTabControlCustomerLeadTabPageRefreshDataButton_Click(object sender, EventArgs e)
        {
            await CustomerDetailExistingCustomerLead_Load(sender, e);
        }

        private void customerDetailTabControlCustomerNoteTabPageCreateNewCustomerNoteButton_Click(object sender, EventArgs e)
        {
            CreateNote createNote = new CreateNote(_customerId, "CustomerNote", customerDisplayName);
            createNote.Show();
        }

        private async void customerDetailTabControlCustomerNoteTabPageRefreshDataButton_Click(object sender, EventArgs e)
        {
            await CustomerDetailExistingCustomerNote_Load(sender, e);
        }
    }
}