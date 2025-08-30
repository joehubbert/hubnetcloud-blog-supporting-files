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
            customerDetailTabControlBillingInformationTabPageAddressLine5ComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerDetailTabControlCustomerContactTabPageDataGridView.CellContentClick += customerDetailTabControlCustomerContactTabPageDataGridView_CellContentClick;
            customerDetailTabControlCustomerLeadTabPageDataGridView.CellContentClick += customerDetailTabControlCustomerLeadTabPageDataGridView_CellContentClick;
            customerDetailTabControlCustomerNoteTabPageDataGridView.CellContentClick += customerDetailTabControlCustomerNoteTabPageDataGridView_CellContentClick;
            customerDetailTabControlFinanceTabPageCreditEnabledCheckbox.CheckedChanged += CustomerDetailFinanceCreditEnabledCheckBox_CheckedChanged;
            customerDetailTabControlFinanceTabPagePaymentCurrencyComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerDetailTabControlFinanceTabPageVATRegisteredCheckbox.CheckedChanged += CustomerDetailFinanceVATRegisteredCheckbox_CheckedChanged;
            customerDetailTabControlOverviewTabPageAccountManagerComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerDetailTabControlOverviewTabPageCompanyConfigurationComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerDetailTabControlOverviewTabPageCustomerTierComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerDetailTabControlOverviewTabPageCustomerTypeComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerDetailTabControlOverviewTabPageExistingParentCompanyPanelNoRadioButton.CheckedChanged += CustomerDetailOverviewExistingParentCustomerRadioButton_CheckedChanged;
            customerDetailTabControlOverviewTabPageExistingParentCompanyPanelYesRadioButton.CheckedChanged += CustomerDetailOverviewExistingParentCustomerRadioButton_CheckedChanged;
            customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.CheckedChanged += CustomerDetailOverviewExistingParentCompanyType_CheckedChanged;
            customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.CheckedChanged += CustomerDetailOverviewRadioButtonValidation_CheckedChanged;
            customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.CheckedChanged += CustomerDetailOverviewExistingParentCompanyType_CheckedChanged;
            customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.CheckedChanged += CustomerDetailOverviewRadioButtonValidation_CheckedChanged;
            customerDetailTabControlOverviewTabPageSalesRegionComboBox.DropDown += CustomerDetailOverviewSalesRegionComboBox_DropDown;
            customerDetailTabControlOverviewTabPageSalesRegionComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerDetailTabControlOverviewTabPageSalesRegionComboBox.SelectedIndexChanged += CustomerDetailOverviewSalesRegionComboBox_SelectedIndexChanged;
            customerDetailTabControlOverviewTabPageSalesSubRegionComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerDetailTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelNoRadioButton.CheckedChanged += CustomerDetailOverviewRadioButtonValidation_CheckedChanged;
            customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.CheckedChanged += CustomerDetailOverviewRadioButtonValidation_CheckedChanged;
            customerDetailTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelYesRadioButton.CheckedChanged += CustomerDetailOverviewRadioButtonValidation_CheckedChanged;
            customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelTopParentRadioButton.CheckedChanged += CustomerDetailOverviewRadioButtonValidation_CheckedChanged;
            customerDetailTabControlShippingInformationTabPageAddressLine5ComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerDetailTabControl.SelectedIndexChanged += CustomerDetailTabControl_SelectedIndexChanged;
            customerDetailToggleEditModeButton.Click += customerDetailToggleEditModeButton_Click;
            _dataGridViewQuickSearchHelper = new DataGridViewQuickSearchHelper(customerDetailTabControlCustomerContactTabPageQuickFilterTextBox, customerDetailTabControlCustomerContactTabPageDataGridView);
            _dataGridViewQuickSearchHelper = new DataGridViewQuickSearchHelper(customerDetailTabControlCustomerLeadTabPageQuickFilterTextBox, customerDetailTabControlCustomerLeadTabPageDataGridView);
            _dataGridViewQuickSearchHelper = new DataGridViewQuickSearchHelper(customerDetailTabControlCustomerNoteTabPageQuickFilterTextBox, customerDetailTabControlCustomerNoteTabPageDataGridView);
        }

        private void CustomerDetailTabControlOverviewTabPageSalesSubRegionComboBox_DropDown(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
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

        private async void CustomerDetailOverviewSalesRegionComboBox_DropDown(object? sender, EventArgs e)
        {
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
                customerDetailTabControlFinanceTabPageCreditLimitTextBoxA.Enabled = true;
                customerDetailTabControlFinanceTabPageTextBoxB.Enabled = true;
            }
            else
            {
                customerDetailTabControlFinanceTabPageCreditLimitTextBoxA.Enabled = false;
                customerDetailTabControlFinanceTabPageTextBoxB.Enabled = false;
            }
        }

        private void CustomerDetailFinanceVATRegisteredCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (customerDetailTabControlFinanceTabPageVATRegisteredCheckbox.Checked)
            {
                customerDetailTabControlFinanceTabPageVATNumberTextBox.Enabled = true;
            }
            else
            {
                customerDetailTabControlFinanceTabPageVATNumberTextBox.Enabled = false;
                customerDetailTabControlFinanceTabPageVATNumberTextBox.Text = string.Empty;
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
                    customerDetailTabControlFinanceTabPageVATNumberTextBox.Text = string.Empty;
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
                new StoredProcedureParameter
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
                    customerDetailTabControlBillingInformationTabPageAddressLine1TextBox.Text = customerDataRow["Billing Address Line 1"].ToString();
                    customerDetailTabControlBillingInformationTabPageAddressLine2TextBox.Text = customerDataRow["Billing Address Line 2"].ToString();
                    customerDetailTabControlBillingInformationTabPageAddressLine3TextBox.Text = customerDataRow["Billing Address Line 3"].ToString();
                    customerDetailTabControlBillingInformationTabPageAddressLine4TextBox.Text = customerDataRow["Billing Address Line 4"].ToString();
                    Guid billingAddressLine5 = (Guid)customerDataRow["Billing Address Line 5"];
                    await LoadCountryDataAsync(billingAddressLine5, "billing");
                    customerDetailTabControlBillingInformationTabPageCompanyNameTextBox.Text = customerDataRow["Billing Company Name"].ToString();
                    customerDetailTabControlBillingInformationTabPageEmailAddressTextBox.Text = customerDataRow["Billing Email Address"].ToString();
                    customerDetailTabControlBillingInformationTabPageFirstNameTextBox.Text = customerDataRow["Billing First Name"].ToString();
                    customerDetailTabControlBillingInformationTabPageLastNameTextBox.Text = customerDataRow["Billing Last Name"].ToString();
                    customerDetailTabControlBillingInformationTabPageTelephoneNumberTextBox.Text = customerDataRow["Billing Telephone Number"].ToString();
                    customerDetailTabControlFinanceTabPageCreditEnabledCheckbox.Checked = (bool)customerDataRow["Credit Enabled"];
                    string creditLimitPartA;
                    string creditLimitPartB;
                    SplitDecimalHelper.SplitDecimalUsingDelimiter((decimal)customerDataRow["Credit Limit"], out creditLimitPartA, out creditLimitPartB);
                    customerDetailTabControlFinanceTabPageCreditLimitTextBoxA.Text = creditLimitPartA;
                    customerDetailTabControlFinanceTabPageTextBoxB.Text = creditLimitPartB;
                    string creditLimitUsedPartA;
                    string creditLimitUsedPartB;
                    SplitDecimalHelper.SplitDecimalUsingDelimiter((decimal)customerDataRow["Credit Limit Used"], out creditLimitUsedPartA, out creditLimitUsedPartB);
                    customerDetailTabControlFinanceTabPageCreditLimitUsedTextBoxA.Text = creditLimitUsedPartA;
                    customerDetailTabControlFinanceTabPageCreditLimitUsedTextBoxB.Text = creditLimitUsedPartB;
                    string creditLimitUsedPercentagePartA;
                    string creditLimitUsedPercentagePartB;
                    SplitDecimalHelper.SplitDecimalUsingDelimiter((decimal)customerDataRow["Credit Limit Used Percentage"], out creditLimitUsedPercentagePartA, out creditLimitUsedPercentagePartB);
                    customerDetailTabControlFinanceTabPageCreditLimitUsedPercentageTextBoxA.Text = creditLimitUsedPercentagePartA;
                    customerDetailTabControlFinanceTabPageCreditLimitUsedPercentageTextBoxB.Text = creditLimitUsedPercentagePartB;
                    customerDetailTabControlFinanceTabPageCreditEnabledCheckbox.Checked = (bool)customerDataRow["Credit Enabled"];
                    Guid paymentCurrencyId = (Guid)customerDataRow["Payment Currency Id"];
                    await LoadCurrencyDataAsync(paymentCurrencyId);
                    customerDetailTabControlFinanceTabPagePaymentDaysTextBox.Text = customerDataRow["Payment Days"].ToString();
                    customerDetailTabControlFinanceTabPageVATNumberTextBox.Text = customerDataRow["VAT Number"].ToString();
                    customerDetailTabControlFinanceTabPageVATRegisteredCheckbox.Checked = (bool)customerDataRow["VAT Registered"];
                    Guid accountManagerId = (Guid)customerDataRow["Account Manager Id"];
                    await LoadAccountManagerDataAsync(accountManagerId, companyConfigurationId);
                    customerDetailTabControlOverviewTabPageActiveStatusCheckbox.Checked = (bool)customerDataRow["Active Status"];
                    customerDetailTabControlOverviewTabPageCompanyNameTextBox.Text = customerDataRow["Company Name"].ToString();
                    customerDetailTabControlOverviewTabPageCreatedByTextBox.Text = customerDataRow["Created By"].ToString();
                    customerDetailTabControlOverviewTabPageCreatedTimestampTextBox.Text = customerDataRow["Created Timestamp UTC"].ToString();
                    customerDetailTabControlOverviewTabPageCustomerIdTextBox.Text = customerDataRow["Customer Id"].ToString();
                    customerDetailTabControlOverviewTabPageCustomerSinceDatePicker.Value = (DateTime)customerDataRow["Customer Since"];
                    Guid customerTierId = (Guid)customerDataRow["Customer Tier Id"];
                    await LoadCustomerTierDataAsync(companyConfigurationId, customerTierId);
                    Guid customerTypeId = (Guid)customerDataRow["Customer Type Id"];
                    await LoadCustomerTypeAsync(companyConfigurationId, customerTypeId);
                    customerDetailTabControlOverviewTabPageEmailAddressTextBox.Text = customerDataRow["Email Address"].ToString();
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
                    customerDetailTabControlOverviewTabPageFirstNameTextBox.Text = customerDataRow["First Name"].ToString();
                    customerDetailTabControlOverviewTabPageLastNameTextBox.Text = customerDataRow["Last Name"].ToString();
                    customerDetailTabControlOverviewTabPageLastUpdatedByTextBox.Text = customerDataRow["Modified By"].ToString();
                    customerDetailTabControlOverviewTabPageLastUpdatedTimestampTextBox.Text = customerDataRow["Modified Timestamp UTC"].ToString();
                    Guid salesRegionId = (Guid)customerDataRow["Sales Region Id"];
                    await LoadSalesRegionDataAsync(companyConfigurationId, salesRegionId);
                    Guid salesSubRegionid = (Guid)customerDataRow["Sales Sub Region Id"];
                    await LoadSalesSubRegionAsync(salesRegionId, salesSubRegionid);
                    customerDetailTabControlOverviewTabPageTelephoneNumberTextBox.Text = customerDataRow["Telephone Number"].ToString();
                    customerDetailTabControlShippingInformationTabPageAddressLine1TextBox.Text = customerDataRow["Shipping Address Line 1"].ToString();
                    customerDetailTabControlShippingInformationTabPageAddressLine2TextBox.Text = customerDataRow["Shipping Address Line 2"].ToString();
                    customerDetailTabControlShippingInformationTabPageAddressLine3TextBox.Text = customerDataRow["Shipping Address Line 3"].ToString();
                    customerDetailTabControlShippingInformationTabPageAddressLine4TextBox.Text = customerDataRow["Shipping Address Line 4"].ToString();
                    Guid shippingAddressLine5 = (Guid)customerDataRow["Shipping Address Line 5"];
                    await LoadCountryDataAsync(shippingAddressLine5, "shipping");
                    customerDetailTabControlShippingInformationTabPageCompanyNameTextBox.Text = customerDataRow["Shipping Company Name"].ToString();
                    customerDetailTabControlShippingInformationTabPageEmailAddressTextBox.Text = customerDataRow["Shipping Email Address"].ToString();
                    customerDetailTabControlShippingInformationTabPageFirstNameTextBox.Text = customerDataRow["Shipping First Name"].ToString();
                    customerDetailTabControlShippingInformationTabPageLastNameTextBox.Text = customerDataRow["Shipping Last Name"].ToString();
                    customerDetailTabControlShippingInformationTabPageTelephoneNumberTextBox.Text = customerDataRow["Shipping Telephone Number"].ToString();

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
                    customerDetailTabControlFinanceVATNumberOriginalValue = customerDataRow["VAT Number"].ToString();
                    customerDetailTabControlFinanceVATRegisteredOriginalValue = (bool)customerDataRow["VAT Registered"];
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
            string customerBillingInformationAddressLine1 = customerDetailTabControlBillingInformationTabPageAddressLine1TextBox.Text.TrimEnd();
            string? customerBillingInformationAddressLine2 = customerDetailTabControlBillingInformationTabPageAddressLine2TextBox.Text.TrimEnd();
            string customerBillingInformationAddressLine3 = customerDetailTabControlBillingInformationTabPageAddressLine3TextBox.Text.TrimEnd();
            string customerBillingInformationAddressLine4 = customerDetailTabControlBillingInformationTabPageAddressLine4TextBox.Text.TrimEnd();
            Guid customerBillingInformationAddressLine5 = Guid.Parse(customerDetailTabControlBillingInformationTabPageAddressLine5ComboBox.SelectedValue.ToString());
            string? customerBillingInformationCompanyName = customerDetailTabControlBillingInformationTabPageCompanyNameTextBox.Text.TrimEnd();
            string customerBillingInformationEmailAddress = customerDetailTabControlBillingInformationTabPageEmailAddressTextBox.Text.TrimEnd();
            string customerBillingInformationFirstName = customerDetailTabControlBillingInformationTabPageFirstNameTextBox.Text.TrimEnd();
            string customerBillingInformationLastName = customerDetailTabControlBillingInformationTabPageLastNameTextBox.Text.TrimEnd();
            string customerBillingInformationTelephoneNumber = customerDetailTabControlBillingInformationTabPageTelephoneNumberTextBox.Text.TrimEnd();

            bool customerFinanceCreditEnabled = customerDetailTabControlFinanceTabPageCreditEnabledCheckbox.Checked;
            decimal customerFinanceCreditLimit = decimal.Parse($"{customerDetailTabControlFinanceTabPageCreditLimitTextBoxA.Text.TrimEnd()}.{customerDetailTabControlFinanceTabPageTextBoxB.Text.TrimEnd()}");
            Guid customerFinancePaymentCurrencyId = Guid.Parse(customerDetailTabControlFinanceTabPagePaymentCurrencyComboBox.SelectedValue.ToString());
            byte customerFinancePaymentDays = byte.Parse(customerDetailTabControlFinanceTabPagePaymentDaysTextBox.Text.TrimEnd());
            string? customerFinanceVATNumber = customerDetailTabControlFinanceTabPageVATNumberTextBox.Text.TrimEnd();
            bool customerFinanceVATRegistered = customerDetailTabControlFinanceTabPageVATRegisteredCheckbox.Checked;

            Guid customerOverviewAccountManagerId = Guid.Parse(customerDetailTabControlOverviewTabPageAccountManagerComboBox.SelectedValue.ToString());
            bool customerOverviewActiveStatus = customerDetailTabControlOverviewTabPageActiveStatusCheckbox.Checked;
            Guid customerOverviewCompanyConfigurationId = Guid.Parse(customerDetailTabControlOverviewTabPageCompanyConfigurationComboBox.SelectedValue.ToString());
            string? customerOverviewCompanyName = customerDetailTabControlOverviewTabPageCompanyNameTextBox.Text.TrimEnd();
            DateTime customerOverviewCustomerSince = customerDetailTabControlOverviewTabPageCustomerSinceDatePicker.Value.Date;
            Guid customerOverviewCustomerTierId = Guid.Parse(customerDetailTabControlOverviewTabPageCustomerTierComboBox.SelectedValue.ToString());
            Guid customerOverviewCustomerTypeId = Guid.Parse(customerDetailTabControlOverviewTabPageCustomerTypeComboBox.SelectedValue.ToString());
            string customerOverviewEmailAddress = customerDetailTabControlOverviewTabPageEmailAddressTextBox.Text.TrimEnd();
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
            string customerOverviewFirstName = customerDetailTabControlOverviewTabPageFirstNameTextBox.Text.TrimEnd();
            string customerOverviewLastName = customerDetailTabControlOverviewTabPageLastNameTextBox.Text.TrimEnd();
            Guid customerOverviewSalesSubRegionId = Guid.Parse(customerDetailTabControlOverviewTabPageSalesSubRegionComboBox.SelectedValue.ToString());
            string customerOverviewTelephoneNumber = customerDetailTabControlOverviewTabPageTelephoneNumberTextBox.Text.TrimEnd();
            bool customerOverviewWillBeGlobalParent = customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Checked;
            bool customerOverviewWillBeTopParent = customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelTopParentRadioButton.Checked;

            string customerShippingInformationAddressLine1 = customerDetailTabControlShippingInformationTabPageAddressLine1TextBox.Text.TrimEnd();
            string? customerShippingInformationAddressLine2 = customerDetailTabControlShippingInformationTabPageAddressLine2TextBox.Text.TrimEnd();
            string customerShippingInformationAddressLine3 = customerDetailTabControlShippingInformationTabPageAddressLine3TextBox.Text.TrimEnd();
            string customerShippingInformationAddressLine4 = customerDetailTabControlShippingInformationTabPageAddressLine4TextBox.Text.TrimEnd();
            Guid customerShippingInformationAddressLine5 = Guid.Parse(customerDetailTabControlShippingInformationTabPageAddressLine5ComboBox.SelectedValue.ToString());
            string? customerShippingInformationCompanyName = customerDetailTabControlShippingInformationTabPageCompanyNameTextBox.Text.TrimEnd();
            string customerShippingInformationEmailAddress = customerDetailTabControlShippingInformationTabPageEmailAddressTextBox.Text.TrimEnd();
            string customerShippingInformationFirstName = customerDetailTabControlShippingInformationTabPageFirstNameTextBox.Text.TrimEnd();
            string customerShippingInformationLastName = customerDetailTabControlShippingInformationTabPageLastNameTextBox.Text.TrimEnd();
            string customerShippingInformationTelephoneNumber = customerDetailTabControlShippingInformationTabPageTelephoneNumberTextBox.Text.TrimEnd();

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
                    Name = "Customer Finance: VAT Registered",
                    Value = customerFinanceVATRegistered,
                    ValueType = typeof(bool)
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
                var parameters = new List<StoredProcedureParameter>
                {
                    new StoredProcedureParameter
                    {
                        ParameterName = "accountManagerId",
                        ParameterValue = customerOverviewAccountManagerId
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "activeStatus",
                        ParameterValue = customerOverviewActiveStatus
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "billingFirstName",
                        ParameterValue = customerBillingInformationFirstName
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "billingLastName",
                        ParameterValue = customerBillingInformationLastName
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "billingAddressLine1",
                        ParameterValue = customerBillingInformationAddressLine1
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "billingAddressLine3",
                        ParameterValue = customerBillingInformationAddressLine3
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "billingAddressLine4",
                        ParameterValue = customerBillingInformationAddressLine4
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "billingAddressLine5",
                        ParameterValue = customerBillingInformationAddressLine5
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "billingTelephoneNumber",
                        ParameterValue = customerBillingInformationTelephoneNumber
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "billingEmailAddress",
                        ParameterValue = customerBillingInformationEmailAddress
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "companyConfigurationId",
                        ParameterValue = customerOverviewCompanyConfigurationId
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "creditEnabled",
                        ParameterValue = customerFinanceCreditEnabled
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "customerSince",
                        ParameterValue = customerOverviewCustomerSince
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "customerTierId",
                        ParameterValue = customerOverviewCustomerTierId
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "customerTypeId",
                        ParameterValue = customerOverviewCustomerTypeId
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "emailAddress",
                        ParameterValue = customerOverviewEmailAddress
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "firstName",
                        ParameterValue = customerOverviewFirstName
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "globalParentCustomer",
                        ParameterValue = customerOverviewWillBeGlobalParent
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "lastName",
                        ParameterValue = customerOverviewLastName
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "paymentCurrencyId",
                        ParameterValue = customerFinancePaymentCurrencyId
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "paymentDays",
                        ParameterValue = customerFinancePaymentDays
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "salesSubRegionId",
                        ParameterValue = customerOverviewSalesSubRegionId
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "shippingFirstName",
                        ParameterValue = customerShippingInformationFirstName
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "shippingLastName",
                        ParameterValue = customerShippingInformationLastName
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "shippingAddressLine1",
                        ParameterValue = customerShippingInformationAddressLine1
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "shippingAddressLine3",
                        ParameterValue = customerShippingInformationAddressLine3
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "shippingAddressLine4",
                        ParameterValue = customerShippingInformationAddressLine4
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "shippingAddressLine5",
                        ParameterValue = customerShippingInformationAddressLine5
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "shippingTelephoneNumber",
                        ParameterValue = customerShippingInformationTelephoneNumber
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "shippingEmailAddress",
                        ParameterValue = customerShippingInformationEmailAddress
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "telephoneNumber",
                        ParameterValue = customerOverviewTelephoneNumber
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "topParentCustomer",
                        ParameterValue = customerOverviewWillBeTopParent
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "vatRegistered",
                        ParameterValue = customerFinanceVATRegistered
                    }
                };

                if (!string.IsNullOrEmpty(customerOverviewCompanyName))
                {
                    parameters.Add(new StoredProcedureParameter
                    {
                        ParameterName = "companyName",
                        ParameterValue = customerOverviewCompanyName
                    });
                }

                if (!string.IsNullOrEmpty(customerBillingInformationAddressLine2))
                {
                    parameters.Add(new StoredProcedureParameter
                    {
                        ParameterName = "billingAddressLine2",
                        ParameterValue = customerBillingInformationAddressLine2
                    });
                }

                if (!string.IsNullOrEmpty(customerBillingInformationCompanyName))
                {
                    parameters.Add(new StoredProcedureParameter
                    {
                        ParameterName = "billingCompanyName",
                        ParameterValue = customerBillingInformationCompanyName
                    });
                }

                if (customerOverviewExistingGlobalParentCustomerId != null && customerOverviewExistingGlobalParentCustomerId != Guid.Empty)
                {
                    parameters.Add(new StoredProcedureParameter
                    {
                        ParameterName = "globalParentCustomerId",
                        ParameterValue = customerOverviewExistingGlobalParentCustomerId
                    });
                }

                if (!string.IsNullOrEmpty(customerShippingInformationAddressLine2))
                {
                    parameters.Add(new StoredProcedureParameter
                    {
                        ParameterName = "shippingAddressLine2",
                        ParameterValue = customerShippingInformationAddressLine2
                    });
                }

                if (!string.IsNullOrEmpty(customerShippingInformationCompanyName))
                {
                    parameters.Add(new StoredProcedureParameter
                    {
                        ParameterName = "shippingCompanyName",
                        ParameterValue = customerShippingInformationCompanyName
                    });
                }

                if (customerOverviewExistingTopParentCustomerId != null && customerOverviewExistingTopParentCustomerId != Guid.Empty)
                {
                    parameters.Add(new StoredProcedureParameter
                    {
                        ParameterName = "topParentCustomerId",
                        ParameterValue = customerOverviewExistingTopParentCustomerId
                    });
                }

                if (string.IsNullOrEmpty(customerFinanceVATNumber))
                {
                    parameters.Add(new StoredProcedureParameter
                    {
                        ParameterName = "vatNumber",
                        ParameterValue = customerFinanceVATNumber
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
            customerDetailTabControlBillingInformationTabPageAddressLine1TextBox.ReadOnly = !customerDetailTabControlBillingInformationTabPageAddressLine1TextBox.ReadOnly;
            customerDetailTabControlBillingInformationTabPageAddressLine2TextBox.ReadOnly = !customerDetailTabControlBillingInformationTabPageAddressLine2TextBox.ReadOnly;
            customerDetailTabControlBillingInformationTabPageAddressLine3TextBox.ReadOnly = !customerDetailTabControlBillingInformationTabPageAddressLine3TextBox.ReadOnly;
            customerDetailTabControlBillingInformationTabPageAddressLine4TextBox.ReadOnly = !customerDetailTabControlBillingInformationTabPageAddressLine4TextBox.ReadOnly;
            customerDetailTabControlBillingInformationTabPageAddressLine5ComboBox.Enabled = !customerDetailTabControlBillingInformationTabPageAddressLine5ComboBox.Enabled;
            customerDetailTabControlBillingInformationTabPageCompanyNameTextBox.ReadOnly = !customerDetailTabControlBillingInformationTabPageCompanyNameTextBox.ReadOnly;
            customerDetailTabControlBillingInformationTabPageEmailAddressTextBox.ReadOnly = !customerDetailTabControlBillingInformationTabPageEmailAddressTextBox.ReadOnly;
            customerDetailTabControlBillingInformationTabPageFirstNameTextBox.ReadOnly = !customerDetailTabControlBillingInformationTabPageFirstNameTextBox.ReadOnly;
            customerDetailTabControlBillingInformationTabPageLastNameTextBox.ReadOnly = !customerDetailTabControlBillingInformationTabPageLastNameTextBox.ReadOnly;
            customerDetailTabControlBillingInformationTabPageTelephoneNumberTextBox.ReadOnly = !customerDetailTabControlBillingInformationTabPageTelephoneNumberTextBox.ReadOnly;
            customerDetailTabControlFinanceTabPageCreditEnabledCheckbox.Enabled = !customerDetailTabControlFinanceTabPageCreditEnabledCheckbox.Enabled;
            customerDetailTabControlFinanceTabPageCreditLimitTextBoxA.ReadOnly = !customerDetailTabControlFinanceTabPageCreditLimitTextBoxA.ReadOnly;
            customerDetailTabControlFinanceTabPageTextBoxB.ReadOnly = !customerDetailTabControlFinanceTabPageTextBoxB.ReadOnly;
            customerDetailTabControlFinanceTabPagePaymentCurrencyComboBox.Enabled = !customerDetailTabControlFinanceTabPagePaymentCurrencyComboBox.Enabled;
            customerDetailTabControlFinanceTabPagePaymentDaysTextBox.ReadOnly = !customerDetailTabControlFinanceTabPagePaymentDaysTextBox.ReadOnly;
            customerDetailTabControlFinanceTabPageVATRegisteredCheckbox.Enabled = !customerDetailTabControlFinanceTabPageVATRegisteredCheckbox.Enabled;
            customerDetailTabControlFinanceTabPageVATNumberTextBox.ReadOnly = !customerDetailTabControlFinanceTabPageVATNumberTextBox.ReadOnly;
            customerDetailTabControlOverviewTabPageAccountManagerComboBox.Enabled = !customerDetailTabControlOverviewTabPageAccountManagerComboBox.Enabled;
            customerDetailTabControlOverviewTabPageActiveStatusCheckbox.Enabled = !customerDetailTabControlOverviewTabPageActiveStatusCheckbox.Enabled;
            customerDetailTabControlOverviewTabPageCompanyConfigurationComboBox.Enabled = !customerDetailTabControlOverviewTabPageCompanyConfigurationComboBox.Enabled;
            customerDetailTabControlOverviewTabPageCompanyNameTextBox.ReadOnly = !customerDetailTabControlOverviewTabPageCompanyNameTextBox.ReadOnly;
            customerDetailTabControlOverviewTabPageCustomerSinceDatePicker.Enabled = !customerDetailTabControlOverviewTabPageCustomerSinceDatePicker.Enabled;
            customerDetailTabControlOverviewTabPageCustomerTierComboBox.Enabled = !customerDetailTabControlOverviewTabPageCustomerTierComboBox.Enabled;
            customerDetailTabControlOverviewTabPageCustomerTypeComboBox.Enabled = !customerDetailTabControlOverviewTabPageCustomerTypeComboBox.Enabled;
            customerDetailTabControlOverviewTabPageEmailAddressTextBox.ReadOnly = !customerDetailTabControlOverviewTabPageEmailAddressTextBox.ReadOnly;
            customerDetailTabControlOverviewTabPageExistingParentCompanyPanelNoRadioButton.Enabled = !customerDetailTabControlOverviewTabPageExistingParentCompanyPanelNoRadioButton.Enabled;
            customerDetailTabControlOverviewTabPageExistingParentCompanyPanelYesRadioButton.Enabled = !customerDetailTabControlOverviewTabPageExistingParentCompanyPanelYesRadioButton.Enabled;
            customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.Enabled = !customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.Enabled;
            customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.Enabled = !customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.Enabled;
            customerDetailTabControlOverviewTabPageFirstNameTextBox.ReadOnly = !customerDetailTabControlOverviewTabPageFirstNameTextBox.ReadOnly;
            customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.Enabled = !customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.Enabled;
            customerDetailTabControlOverviewTabPageLastNameTextBox.ReadOnly = !customerDetailTabControlOverviewTabPageLastNameTextBox.ReadOnly;
            customerDetailTabControlOverviewTabPageSalesRegionComboBox.Enabled = !customerDetailTabControlOverviewTabPageSalesRegionComboBox.Enabled;
            customerDetailTabControlOverviewTabPageSalesSubRegionComboBox.Enabled = !customerDetailTabControlOverviewTabPageSalesSubRegionComboBox.Enabled;
            customerDetailTabControlOverviewTabPageTelephoneNumberTextBox.ReadOnly = !customerDetailTabControlOverviewTabPageTelephoneNumberTextBox.ReadOnly;
            customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.Enabled = !customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.Enabled;
            customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Enabled = !customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Enabled;
            customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelTopParentRadioButton.Enabled = !customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelTopParentRadioButton.Enabled;
            customerDetailTabControlShippingInformationTabPageAddressLine1TextBox.ReadOnly = !customerDetailTabControlShippingInformationTabPageAddressLine1TextBox.ReadOnly;
            customerDetailTabControlShippingInformationTabPageAddressLine2TextBox.ReadOnly = !customerDetailTabControlShippingInformationTabPageAddressLine2TextBox.ReadOnly;
            customerDetailTabControlShippingInformationTabPageAddressLine3TextBox.ReadOnly = !customerDetailTabControlShippingInformationTabPageAddressLine3TextBox.ReadOnly;
            customerDetailTabControlShippingInformationTabPageAddressLine4TextBox.ReadOnly = !customerDetailTabControlShippingInformationTabPageAddressLine4TextBox.ReadOnly;
            customerDetailTabControlShippingInformationTabPageAddressLine5ComboBox.Enabled = !customerDetailTabControlShippingInformationTabPageAddressLine5ComboBox.Enabled;
            customerDetailTabControlShippingInformationTabPageCompanyNameTextBox.ReadOnly = !customerDetailTabControlShippingInformationTabPageCompanyNameTextBox.ReadOnly;
            customerDetailTabControlShippingInformationTabPageEmailAddressTextBox.ReadOnly = !customerDetailTabControlShippingInformationTabPageEmailAddressTextBox.ReadOnly;
            customerDetailTabControlShippingInformationTabPageFirstNameTextBox.ReadOnly = !customerDetailTabControlShippingInformationTabPageFirstNameTextBox.ReadOnly;
            customerDetailTabControlShippingInformationTabPageLastNameTextBox.ReadOnly = !customerDetailTabControlShippingInformationTabPageLastNameTextBox.ReadOnly;
            customerDetailTabControlShippingInformationTabPageTelephoneNumberTextBox.ReadOnly = !customerDetailTabControlShippingInformationTabPageTelephoneNumberTextBox.ReadOnly;
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