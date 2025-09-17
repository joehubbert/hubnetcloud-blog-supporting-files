using CRM_WindowsForms_EnterpriseEdition.Helpers;
using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Services;
using Microsoft.Identity.Client;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CustomerDetail : Form
    {
        private bool _customerContactsLoaded = false;
        private readonly Guid _customerId;
        private bool _customerLeadsLoaded = false;
        private bool _customerNotesLoaded = false;
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private List<DataGridViewQuickSearchHelper> _dataGridViewQuickSearchHelpers;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private TextBoxNumericCharacterDataValidationHelper _textBoxNumericHelper;
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
        private Guid customerDetailTabControlOverviewTabPageCustomerTierIdOriginalValue;
        private Guid customerDetailTabControlOverviewTabPageCustomerTypeIdOriginalValue;
        private string customerDetailTabControlOverviewTabPageEmailAddressOriginalValue;
        private string customerDetailTabControlOverviewTabPageFirstNameOriginalValue;
        private Guid? customerDetailTabControlOverviewTabPageGlobalParentCustomerIdOriginalValue;
        private string customerDetailTabControlOverviewTabPageLastNameOriginalValue;
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
            _dataGridViewQuickSearchHelpers = new List<DataGridViewQuickSearchHelper>();
            _textBoxNumericHelper = new TextBoxNumericCharacterDataValidationHelper();
            InitializeEventHandlers();
            LoadDatabaseConnectionSettingsAsync();
            _customerId = customerId;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            CustomerDetailCustomerInformation_Load(this, EventArgs.Empty);
        }

        private void InitializeEventHandlers()
        {
            customerDetailTabControlBillingInformationTabPageAddressLine5ComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerDetailTabControlCustomerContactTabPage.Enter += customerDetailTabControlCustomerContactTabPage_Enter;
            customerDetailTabControlCustomerContactTabPageDataGridView.CellContentClick += customerDetailTabControlCustomerContactTabPageDataGridView_CellContentClick;
            customerDetailTabControlCustomerLeadTabPage.Enter += customerDetailTabControlCustomerLeadTabPage_Enter;
            customerDetailTabControlCustomerLeadTabPageDataGridView.CellContentClick += customerDetailTabControlCustomerLeadTabPageDataGridView_CellContentClick;
            customerDetailTabControlCustomerNoteTabPage.Enter += customerDetailTabControlCustomerNoteTabPage_Enter;
            customerDetailTabControlCustomerNoteTabPageDataGridView.CellContentClick += customerDetailTabControlCustomerNoteTabPageDataGridView_CellContentClick;
            customerDetailTabControlFinanceTabPageCreditEnabledCheckBox.CheckedChanged += customerDetailTabControlFinanceTabPageCreditEnabledCheckBox_CheckedChanged;
            customerDetailTabControlFinanceTabPageCreditLimitTextBoxA.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            customerDetailTabControlFinanceTabPageCreditLimitTextBoxB.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            customerDetailTabControlFinanceTabPagePaymentCurrencyComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerDetailTabControlFinanceTabPagePaymentDaysTextBox.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            customerDetailTabControlFinanceTabPageVATRegisteredCheckBox.CheckedChanged += customerDetailTabControlFinanceTabPageVATRegisteredCheckBox_CheckedChanged;
            customerDetailTabControlOverviewTabPageAccountManagerComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerDetailTabControlOverviewTabPageCompanyConfigurationComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerDetailTabControlOverviewTabPageCustomerTierComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerDetailTabControlOverviewTabPageCustomerTypeComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerDetailTabControlOverviewTabPageExistingParentCompanyPanelNoRadioButton.CheckedChanged += customerDetailTabControlOverviewTabPageExistingParentCompanyPanelRadioButton_CheckedChanged;
            customerDetailTabControlOverviewTabPageExistingParentCompanyPanelYesRadioButton.CheckedChanged += customerDetailTabControlOverviewTabPageExistingParentCompanyPanelRadioButton_CheckedChanged;
            customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.CheckedChanged += customerDetailTabControlOverviewTabPageExistingParentCompanyPanelRadioButton_CheckedChanged;
            customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.CheckedChanged += customerDetailTabControlOverviewTabPageRadioButtonValidation_CheckedChanged;
            customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.CheckedChanged += customerDetailTabControlOverviewTabPageExistingParentCompanyPanelRadioButton_CheckedChanged;
            customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.CheckedChanged += customerDetailTabControlOverviewTabPageRadioButtonValidation_CheckedChanged;
            customerDetailTabControlOverviewTabPageSalesRegionComboBox.DropDown += customerDetailTabControlOverviewTabPageSalesRegionComboBox_DropDown;
            customerDetailTabControlOverviewTabPageSalesRegionComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerDetailTabControlOverviewTabPageSalesRegionComboBox.SelectedIndexChanged += customerDetailTabControlOverviewTabPageSalesRegionComboBox_SelectedIndexChanged;
            customerDetailTabControlOverviewTabPageSalesSubRegionComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            customerDetailTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelNoRadioButton.CheckedChanged += customerDetailTabControlOverviewTabPageRadioButtonValidation_CheckedChanged;
            customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.CheckedChanged += customerDetailTabControlOverviewTabPageRadioButtonValidation_CheckedChanged;
            customerDetailTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelYesRadioButton.CheckedChanged += customerDetailTabControlOverviewTabPageRadioButtonValidation_CheckedChanged;
            customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelTopParentRadioButton.CheckedChanged += customerDetailTabControlOverviewTabPageRadioButtonValidation_CheckedChanged;
            customerDetailTabControlShippingInformationTabPageAddressLine5ComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;           
            _dataGridViewQuickSearchHelpers.Add(new DataGridViewQuickSearchHelper(customerDetailTabControlCustomerContactTabPageQuickFilterTextBox, customerDetailTabControlCustomerContactTabPageDataGridView));
            _dataGridViewQuickSearchHelpers.Add(new DataGridViewQuickSearchHelper(customerDetailTabControlCustomerLeadTabPageQuickFilterTextBox, customerDetailTabControlCustomerLeadTabPageDataGridView));
            _dataGridViewQuickSearchHelpers.Add(new DataGridViewQuickSearchHelper(customerDetailTabControlCustomerNoteTabPageQuickFilterTextBox, customerDetailTabControlCustomerNoteTabPageDataGridView));
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
                    customerDetailTabControlFinanceTabPageCreditEnabledCheckBox.Checked = (bool)customerDataRow["Credit Enabled"];
                    string creditLimitPartA;
                    string creditLimitPartB;
                    SplitDecimalHelper.SplitDecimalUsingDelimiter((decimal)customerDataRow["Credit Limit"], out creditLimitPartA, out creditLimitPartB);
                    customerDetailTabControlFinanceTabPageCreditLimitTextBoxA.Text = creditLimitPartA;
                    customerDetailTabControlFinanceTabPageCreditLimitTextBoxB.Text = creditLimitPartB;
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
                    customerDetailTabControlFinanceTabPageCreditEnabledCheckBox.Checked = (bool)customerDataRow["Credit Enabled"];
                    Guid paymentCurrencyId = (Guid)customerDataRow["Payment Currency Id"];
                    await LoadCurrencyDataAsync(paymentCurrencyId);
                    customerDetailTabControlFinanceTabPagePaymentDaysTextBox.Text = customerDataRow["Payment Days"].ToString();
                    customerDetailTabControlFinanceTabPageVATNumberTextBox.Text = customerDataRow["VAT Number"].ToString();
                    customerDetailTabControlFinanceTabPageVATRegisteredCheckBox.Checked = (bool)customerDataRow["VAT Registered"];
                    Guid accountManagerId = (Guid)customerDataRow["Account Manager Id"];
                    await LoadAccountManagerDataAsync(accountManagerId, companyConfigurationId);
                    customerDetailTabControlOverviewTabPageActiveStatusCheckBox.Checked = (bool)customerDataRow["Active Status"];
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
                    customerDetailTabControlOverviewTabPageFirstNameOriginalValue = customerDataRow["First Name"].ToString();
                    customerDetailTabControlOverviewTabPageGlobalParentCustomerIdOriginalValue = (Guid)customerDataRow["Global Parent Customer Id"];
                    customerDetailTabControlOverviewTabPageLastNameOriginalValue = customerDataRow["Last Name"].ToString();
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
                "Created Timestamp UTC"
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
                "Created Timestamp UTC"
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
                "Created Timestamp UTC"
            );
        }

        private async Task LoadAccountManagerDataAsync(Guid accountManagerId, Guid companyConfigurationId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerDetailTabControlOverviewTabPageAccountManagerComboBox,
                "spGetAllAccountManager",
                companyConfigurationId,
                true,
                "Account Manager Id",
                accountManagerId,
                false,
                null,
                null,
                null,
                true);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadCompanyConfigurationAsync(Guid companyConfigurationId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerDetailTabControlOverviewTabPageCompanyConfigurationComboBox,
                "spGetAllCompanyConfiguration",
                null,
                true,
                "Company Configuration Id",
                companyConfigurationId,
                false,
                null,
                null,
                null,
                true);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadCountryDataAsync(Guid countryId, string countryType)
        {
            switch (countryType)
            {
                case "Billing":
                    _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerDetailTabControlBillingInformationTabPageAddressLine5ComboBox,
                        "spGetAllCountry",
                        null,
                        true,
                        "Country Id",
                        countryId, 
                        false,
                        null,
                        null,
                        null,
                        true);
                    break;
                case "Shipping":
                    _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerDetailTabControlShippingInformationTabPageAddressLine5ComboBox,
                        "spGetAllCountry",
                        null,
                        true,
                        "Country Id",
                        countryId,
                        false,
                        null,
                        null,
                        null,
                        true);
                    break;
                default:
                    throw new ArgumentException("Invalid country type specified.");
            }

            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadCurrencyDataAsync(Guid currencyId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerDetailTabControlFinanceTabPagePaymentCurrencyComboBox,
                "spGetAllCurrency",
                null,
                true,
                "Currency Id",
                currencyId,
                false,
                null,
                null,
                null,
                true);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadCustomerTierDataAsync(Guid companyConfigurationId, Guid customerTierId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerDetailTabControlOverviewTabPageCustomerTierComboBox,
                "spGetAllCustomerTier",
                companyConfigurationId,
                true,
                "Customer Tier Id",
                customerTierId,
                false,
                null,
                null,
                null,
                true);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadCustomerTypeAsync(Guid companyConfigurationId, Guid customerTypeId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerDetailTabControlOverviewTabPageCustomerTierComboBox,
                "spGetAllCustomerType",
                companyConfigurationId,
                true,
                "Customer Type Id",
                customerTypeId,
                false,
                null,
                null,
                null,
                true);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task LoadGlobalParentCustomerDataAsync(Guid customerId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox,
                "spGetAllGlobalParentCustomer",
                null,
                true,
                "Customer Id",
                customerId,
                false,
                null,
                null,
                null,
                true);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadSalesRegionDataAsync(Guid companyConfigurationId, Guid salesRegionId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerDetailTabControlOverviewTabPageSalesRegionComboBox,
                "spGetAllSalesRegion",
                companyConfigurationId,
                true,
                "Sales Region Id",
                salesRegionId,
                false,
                null,
                null,
                null,
                true);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadSalesSubRegionAsync(Guid salesRegionId, Guid salesSubRegionId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerDetailTabControlOverviewTabPageSalesSubRegionComboBox,
                "spGetAllSalesSubRegion",
                null,
                true,
                "Sales Region Id",
                salesRegionId,
                true,
                "Sales Sub Region Id",
                salesSubRegionId,
                null,
                true);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadTopParentCustomerDataAsync(Guid customerId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(customerDetailTabControlOverviewTabPageTopParentCustomerComboBox,
                "spGetAllTopParentCustomer",
                null,
                true,
                "Customer Id",
                customerId,
                false,
                null,
                null,
                null,
                true);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async void customerDetailTabControlCustomerContactTabPage_Enter(object? sender, EventArgs e)
        {
            if (!_customerContactsLoaded)
            {
                await CustomerDetailExistingCustomerContact_Load(this, EventArgs.Empty);
                _customerContactsLoaded = true;
            }
        }

        private void customerDetailTabControlCustomerContactTabPageCreateNewCustomerContactButton_Click(object sender, EventArgs e)
        {
            CreateContact createContact = new CreateContact(_customerId, "Customer", customerDisplayName);
            createContact.Show();
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

        private async void customerDetailTabControlCustomerContactTabPageRefreshDataButton_Click(object sender, EventArgs e)
        {
            await CustomerDetailExistingCustomerContact_Load(sender, e);
        }

        private async void customerDetailTabControlCustomerLeadTabPage_Enter(object? sender, EventArgs e)
        {
            if (!_customerLeadsLoaded)
            {
                await CustomerDetailExistingCustomerLead_Load(this, EventArgs.Empty);
                _customerLeadsLoaded = true;
            }
        }

        private void customerDetailTabControlCustomerLeadTabPageCreateNewCustomerLeadButton_Click(object sender, EventArgs e)
        {
            CreateCustomerLead createCustomerLead = new CreateCustomerLead(_customerId, customerDisplayName);
            createCustomerLead.Show();
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

        private async void customerDetailTabControlCustomerLeadTabPageRefreshDataButton_Click(object sender, EventArgs e)
        {
            await CustomerDetailExistingCustomerLead_Load(sender, e);
        }

        private async void customerDetailTabControlCustomerNoteTabPage_Enter(object? sender, EventArgs e)
        {
            if (!_customerNotesLoaded)
            {
                await CustomerDetailExistingCustomerNote_Load(this, EventArgs.Empty);
                _customerNotesLoaded = true;
            }
        }

        private void customerDetailTabControlCustomerNoteTabPageCreateNewCustomerNoteButton_Click(object sender, EventArgs e)
        {
            CreateNote createNote = new CreateNote(_customerId, "CustomerNote", customerDisplayName);
            createNote.Show();
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

        private async void customerDetailTabControlCustomerNoteTabPageRefreshDataButton_Click(object sender, EventArgs e)
        {
            await CustomerDetailExistingCustomerNote_Load(sender, e);
        }

        private void customerDetailTabControlFinanceTabPageCreditEnabledCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (customerDetailTabControlFinanceTabPageCreditEnabledCheckBox.Checked)
            {
                customerDetailTabControlFinanceTabPageCreditLimitTextBoxA.Enabled = true;
                customerDetailTabControlFinanceTabPageCreditLimitTextBoxB.Enabled = true;
            }
            else
            {
                customerDetailTabControlFinanceTabPageCreditLimitTextBoxA.Enabled = false;
                customerDetailTabControlFinanceTabPageCreditLimitTextBoxB.Enabled = false;
            }
        }

        private void customerDetailTabControlFinanceTabPageVATRegisteredCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (customerDetailTabControlFinanceTabPageVATRegisteredCheckBox.Checked)
            {
                customerDetailTabControlFinanceTabPageVATNumberTextBox.Enabled = true;
            }
            else
            {
                customerDetailTabControlFinanceTabPageVATNumberTextBox.Enabled = false;
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
                    customerDetailTabControlFinanceTabPageVATRegisteredCheckBox.Checked = true;
                    customerDetailTabControlFinanceTabPageVATNumberTextBox.Enabled = true;
                }
            }
        }

        private async void customerDetailTabControlOverviewTabPageExistingParentCompanyPanelRadioButton_CheckedChanged(object? sender, EventArgs e)
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

        private void customerDetailTabControlOverviewTabPageRadioButtonValidation_CheckedChanged(object? sender, EventArgs e)
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

        private async void customerDetailTabControlOverviewTabPageSalesRegionComboBox_DropDown(object? sender, EventArgs e)
        {
            await LoadSalesSubRegionAsync((Guid)customerDetailTabControlOverviewTabPageSalesRegionComboBox.SelectedValue, (Guid)customerDetailTabControlOverviewTabPageSalesSubRegionComboBox.SelectedValue);
        }

        private async void customerDetailTabControlOverviewTabPageSalesRegionComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            await LoadSalesSubRegionAsync((Guid)customerDetailTabControlOverviewTabPageSalesRegionComboBox.SelectedValue, (Guid)customerDetailTabControlOverviewTabPageSalesSubRegionComboBox.SelectedValue);
        }

        private void customerDetailToggleEditModeButton_Click(object? sender, EventArgs e)
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
            customerDetailTabControlFinanceTabPageCreditEnabledCheckBox.Enabled = !customerDetailTabControlFinanceTabPageCreditEnabledCheckBox.Enabled;
            customerDetailTabControlFinanceTabPageCreditLimitTextBoxA.ReadOnly = !customerDetailTabControlFinanceTabPageCreditLimitTextBoxA.ReadOnly;
            customerDetailTabControlFinanceTabPageCreditLimitTextBoxB.ReadOnly = !customerDetailTabControlFinanceTabPageCreditLimitTextBoxB.ReadOnly;
            customerDetailTabControlFinanceTabPagePaymentCurrencyComboBox.Enabled = !customerDetailTabControlFinanceTabPagePaymentCurrencyComboBox.Enabled;
            customerDetailTabControlFinanceTabPagePaymentDaysTextBox.ReadOnly = !customerDetailTabControlFinanceTabPagePaymentDaysTextBox.ReadOnly;
            customerDetailTabControlFinanceTabPageVATRegisteredCheckBox.Enabled = !customerDetailTabControlFinanceTabPageVATRegisteredCheckBox.Enabled;
            customerDetailTabControlFinanceTabPageVATNumberTextBox.ReadOnly = !customerDetailTabControlFinanceTabPageVATNumberTextBox.ReadOnly;
            customerDetailTabControlOverviewTabPageAccountManagerComboBox.Enabled = !customerDetailTabControlOverviewTabPageAccountManagerComboBox.Enabled;
            customerDetailTabControlOverviewTabPageActiveStatusCheckBox.Enabled = !customerDetailTabControlOverviewTabPageActiveStatusCheckBox.Enabled;
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

        private async void customerDetailUpdateCustomerButton_Click(object sender, EventArgs e)
        {
            string customerBillingInformationAddressLine1 = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlBillingInformationTabPageAddressLine1TextBox);
            string? customerBillingInformationAddressLine2 = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlBillingInformationTabPageAddressLine2TextBox);
            string customerBillingInformationAddressLine3 = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlBillingInformationTabPageAddressLine3TextBox);
            string customerBillingInformationAddressLine4 = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlBillingInformationTabPageAddressLine4TextBox);
            Guid customerBillingInformationAddressLine5 = (Guid)customerDetailTabControlBillingInformationTabPageAddressLine5ComboBox.SelectedValue;
            string? customerBillingInformationCompanyName = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlBillingInformationTabPageCompanyNameTextBox);
            string customerBillingInformationEmailAddress = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlBillingInformationTabPageEmailAddressTextBox);
            string customerBillingInformationFirstName = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlBillingInformationTabPageFirstNameTextBox);
            string customerBillingInformationLastName = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlBillingInformationTabPageLastNameTextBox);
            string customerBillingInformationTelephoneNumber = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlBillingInformationTabPageTelephoneNumberTextBox);

            bool customerFinanceCreditEnabled = customerDetailTabControlFinanceTabPageCreditEnabledCheckBox.Checked;
            decimal customerFinanceCreditLimit = decimal.Parse($"{TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlFinanceTabPageCreditLimitTextBoxA)}.{TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlFinanceTabPageCreditLimitTextBoxB)}");
            Guid customerFinancePaymentCurrencyId = (Guid)customerDetailTabControlFinanceTabPagePaymentCurrencyComboBox.SelectedValue;
            byte customerFinancePaymentDays = byte.Parse(TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlFinanceTabPagePaymentDaysTextBox));
            string? customerFinanceVATNumber = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlFinanceTabPageVATNumberTextBox);
            bool customerFinanceVATRegistered = customerDetailTabControlFinanceTabPageVATRegisteredCheckBox.Checked;

            Guid customerOverviewAccountManagerId = (Guid)customerDetailTabControlOverviewTabPageAccountManagerComboBox.SelectedValue;
            bool customerOverviewActiveStatus = customerDetailTabControlOverviewTabPageActiveStatusCheckBox.Checked;
            Guid customerOverviewCompanyConfigurationId = (Guid)customerDetailTabControlOverviewTabPageCompanyConfigurationComboBox.SelectedValue;
            string? customerOverviewCompanyName = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlOverviewTabPageCompanyNameTextBox);
            DateTime customerOverviewCustomerSince = customerDetailTabControlOverviewTabPageCustomerSinceDatePicker.Value.Date;
            Guid customerOverviewCustomerTierId = (Guid)customerDetailTabControlOverviewTabPageCustomerTierComboBox.SelectedValue;
            Guid customerOverviewCustomerTypeId = (Guid)customerDetailTabControlOverviewTabPageCustomerTypeComboBox.SelectedValue;
            string customerOverviewEmailAddress = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlOverviewTabPageEmailAddressTextBox);
            Guid? customerOverviewExistingGlobalParentCustomerId = null;
            if (customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.SelectedValue != null)
            {
                customerOverviewExistingGlobalParentCustomerId = (Guid)customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.SelectedValue;
            }
            Guid? customerOverviewExistingTopParentCustomerId = null;
            if (customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.SelectedValue != null)
            {
                customerOverviewExistingTopParentCustomerId = (Guid)customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.SelectedValue;
            }
            string customerOverviewFirstName = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlOverviewTabPageFirstNameTextBox);
            string customerOverviewLastName = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlOverviewTabPageLastNameTextBox);
            Guid customerOverviewSalesSubRegionId = (Guid)customerDetailTabControlOverviewTabPageSalesSubRegionComboBox.SelectedValue;
            string customerOverviewTelephoneNumber = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlOverviewTabPageTelephoneNumberTextBox);
            bool customerOverviewWillBeGlobalParent = customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Checked;
            bool customerOverviewWillBeTopParent = customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelTopParentRadioButton.Checked;

            string customerShippingInformationAddressLine1 = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlShippingInformationTabPageAddressLine1TextBox);
            string? customerShippingInformationAddressLine2 = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlShippingInformationTabPageAddressLine2TextBox);
            string customerShippingInformationAddressLine3 = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlShippingInformationTabPageAddressLine3TextBox);
            string customerShippingInformationAddressLine4 = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlShippingInformationTabPageAddressLine4TextBox);
            Guid customerShippingInformationAddressLine5 = (Guid)customerDetailTabControlShippingInformationTabPageAddressLine5ComboBox.SelectedValue;
            string? customerShippingInformationCompanyName = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlShippingInformationTabPageCompanyNameTextBox);
            string customerShippingInformationEmailAddress = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlShippingInformationTabPageEmailAddressTextBox);
            string customerShippingInformationFirstName = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlShippingInformationTabPageFirstNameTextBox);
            string customerShippingInformationLastName = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlShippingInformationTabPageLastNameTextBox);
            string customerShippingInformationTelephoneNumber = TextBoxCleanerHelper.GetTrimmedText(customerDetailTabControlShippingInformationTabPageTelephoneNumberTextBox);

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
                var changesList = new List<ChangeDetail>
                {
                    new ChangeDetail
                    {
                        VariableName = "Customer Billing Information: Address Line 1",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlBillingInformationTabPageAddressLine1OriginalValue,
                        NewValue = customerBillingInformationAddressLine1
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Billing Information: Address Line 3",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlBillingInformationTabPageAddressLine3OriginalValue,
                        NewValue = customerBillingInformationAddressLine3
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Billing Information: Address Line 4",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlBillingInformationTabPageAddressLine4OriginalValue,
                        NewValue = customerBillingInformationAddressLine4
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Billing Information: Address Line 5",
                        VariableType = "Guid",
                        OriginalValue = customerDetailTabControlBillingInformationTabPageAddressLine5OriginalValue,
                        NewValue = customerBillingInformationAddressLine5
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Billing Information: Email Address",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlBillingInformationTabPageEmailAddressOriginalValue,
                        NewValue = customerBillingInformationEmailAddress
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Billing Information: First Name",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlBillingInformationTabPageFirstNameOriginalValue,
                        NewValue = customerBillingInformationFirstName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Billing Information: Last Name",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlBillingInformationTabPageLastNameOriginalValue,
                        NewValue = customerBillingInformationLastName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Billing Information: Telephone Number",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlBillingInformationTabPageTelephoneNumberOriginalValue,
                        NewValue = customerBillingInformationTelephoneNumber
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Finance: Credit Enabled",
                        VariableType = "bool",
                        OriginalValue = customerDetailTabControlFinanceCreditEnabledOriginalValue,
                        NewValue = customerFinanceCreditEnabled
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Finance: Credit Limit",
                        VariableType = "decimal",
                        OriginalValue = customerDetailTabControlFinanceCreditLimitOriginalValue,
                        NewValue = customerFinanceCreditLimit
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Finance: Payment Currency Id",
                        VariableType = "Guid",
                        OriginalValue = customerDetailTabControlFinancePaymentCurrencyIdOriginalValue,
                        NewValue = customerFinancePaymentCurrencyId
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Finance: Payment Days",
                        VariableType = "int",
                        OriginalValue = customerDetailTabControlFinancePaymentDaysOriginalValue,
                        NewValue = customerFinancePaymentDays
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Finance: VAT Registered",
                        VariableType = "bool",
                        OriginalValue = customerDetailTabControlFinanceVATRegisteredOriginalValue,
                        NewValue = customerFinanceVATRegistered
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Overview: Account Manager Id",
                        VariableType = "Guid",
                        OriginalValue = customerDetailTabControlOverviewTabPageAccountManagerIdOriginalValue,
                        NewValue = customerOverviewAccountManagerId
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Overview: Active Status",
                        VariableType = "bool",
                        OriginalValue = customerDetailTabControlOverviewTabPageActiveStatusOriginalValue,
                        NewValue = customerOverviewActiveStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Overview: Company Configuration Id",
                        VariableType = "Guid",
                        OriginalValue = customerDetailTabControlOverviewTabPageCompanyConfigurationIdOriginalValue,
                        NewValue = customerOverviewCompanyConfigurationId
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Overview: Customer Since",
                        VariableType = "DateTime",
                        OriginalValue = customerDetailTabControlOverviewTabPageCustomerSinceOriginalValue,
                        NewValue = customerOverviewCustomerSince
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Overview: Customer Tier Id",
                        VariableType = "Guid",
                        OriginalValue = customerDetailTabControlOverviewTabPageCustomerTierIdOriginalValue,
                        NewValue = customerOverviewCustomerTierId
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Overview: Customer Type Id",
                        VariableType = "Guid",
                        OriginalValue = customerDetailTabControlOverviewTabPageCustomerTypeIdOriginalValue,
                        NewValue = customerOverviewCustomerTypeId
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Overview: Email Address",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlOverviewTabPageEmailAddressOriginalValue,
                        NewValue = customerOverviewEmailAddress
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Overview: First Name",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlOverviewTabPageFirstNameOriginalValue,
                        NewValue = customerOverviewFirstName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Overview: Last Name",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlOverviewTabPageLastNameOriginalValue,
                        NewValue = customerOverviewLastName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Overview: Sales Sub Region Id",
                        VariableType = "Guid",
                        OriginalValue = customerDetailTabControlOverviewTabPageSalesSubRegionIdOriginalValue,
                        NewValue = customerOverviewSalesSubRegionId
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Overview: Telephone Number",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlOverviewTabPageTelephoneNumberOriginalValue,
                        NewValue = customerOverviewTelephoneNumber
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Overview: Will Be Global Parent",
                        VariableType = "bool",
                        OriginalValue = customerDetailTabControlOverviewTabPageWillBeParentInCustomerHierarchyOriginalValue,
                        NewValue = customerOverviewWillBeGlobalParent
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Overview: Will Be Top Parent",
                        VariableType = "bool",
                        OriginalValue = customerDetailTabControlOverviewTabPageWillBeParentInCustomerHierarchyOriginalValue,
                        NewValue = customerOverviewWillBeTopParent
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Shipping Information: Address Line 1",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlShippingInformationAddressLine1OriginalValue,
                        NewValue = customerShippingInformationAddressLine1
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Shipping Information: Address Line 3",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlShippingInformationAddressLine3OriginalValue,
                        NewValue = customerShippingInformationAddressLine3
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Shipping Information: Address Line 4",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlShippingInformationAddressLine4OriginalValue,
                        NewValue = customerShippingInformationAddressLine4
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Shipping Information: Address Line 5",
                        VariableType = "Guid",
                        OriginalValue = customerDetailTabControlShippingInformationAddressLine5OriginalValue,
                        NewValue = customerShippingInformationAddressLine5
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Shipping Information: Email Address",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlShippingInformationEmailAddressOriginalValue,
                        NewValue = customerShippingInformationEmailAddress
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Shipping Information: First Name",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlShippingInformationFirstNameOriginalValue,
                        NewValue = customerShippingInformationFirstName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Shipping Information: Last Name",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlShippingInformationLastNameOriginalValue,
                        NewValue = customerShippingInformationLastName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Customer Shipping Information: Telephone Number",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlShippingInformationTelephoneNumberOriginalValue,
                        NewValue = customerShippingInformationTelephoneNumber
                    }
                };

                if (!string.IsNullOrEmpty(customerBillingInformationAddressLine2))
                {
                    changesList.Add(new ChangeDetail
                    {
                        VariableName = "Customer Billing Information: Address Line 2",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlBillingInformationTabPageAddressLine2OriginalValue,
                        NewValue = customerBillingInformationAddressLine2
                    });
                }
                if (!string.IsNullOrEmpty(customerBillingInformationCompanyName))
                {
                    changesList.Add(new ChangeDetail
                    {
                        VariableName = "Customer Billing Information: Company Name",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlBillingInformationTabPageCompanyNameOriginalValue,
                        NewValue = customerBillingInformationCompanyName
                    });
                }
                if (!string.IsNullOrEmpty(customerFinanceVATNumber))
                {
                    changesList.Add(new ChangeDetail
                    {
                        VariableName = "Customer Finance: VAT Number",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlFinanceVATNumberOriginalValue,
                        NewValue = customerFinanceVATNumber
                    });
                }
                if (!string.IsNullOrEmpty(customerOverviewCompanyName))
                {
                    changesList.Add(new ChangeDetail
                    {
                        VariableName = "Customer Overview: Company Name",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlOverviewTabPageCompanyNameOriginalValue,
                        NewValue = customerOverviewCompanyName
                    });
                }
                if (customerOverviewExistingGlobalParentCustomerId != null && customerOverviewExistingGlobalParentCustomerId != Guid.Empty)
                {
                    changesList.Add(new ChangeDetail
                    {
                        VariableName = "Customer Overview: Existing Global Parent Customer Id",
                        VariableType = "Guid",
                        OriginalValue = customerDetailTabControlOverviewTabPageGlobalParentCustomerIdOriginalValue,
                        NewValue = customerOverviewExistingGlobalParentCustomerId
                    });
                }
                if (customerOverviewExistingTopParentCustomerId != null && customerOverviewExistingTopParentCustomerId != Guid.Empty)
                {
                    changesList.Add(new ChangeDetail
                    {
                        VariableName = "Customer Overview: Existing Top Parent Customer Id",
                        VariableType = "Guid",
                        OriginalValue = customerDetailTabControlOverviewTabPageTopParentCustomerIdOriginalValue,
                        NewValue = customerOverviewExistingTopParentCustomerId
                    });
                }
                if (!string.IsNullOrEmpty(customerShippingInformationAddressLine2))
                {
                    changesList.Add(new ChangeDetail
                    {
                        VariableName = "Customer Shipping Information: Address Line 2",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlShippingInformationAddressLine2OriginalValue,
                        NewValue = customerShippingInformationAddressLine2
                    });
                }
                if (!string.IsNullOrEmpty(customerShippingInformationCompanyName))
                {
                    changesList.Add(new ChangeDetail
                    {
                        VariableName = "Customer Shipping Information: Company Name",
                        VariableType = "string",
                        OriginalValue = customerDetailTabControlShippingInformationCompanyNameOriginalValue,
                        NewValue = customerShippingInformationCompanyName
                    });
                }

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = UpdateConfirmationService.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
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
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.UpdateCancelled");
                    this.Close();
                }
            }
        }
    }
}