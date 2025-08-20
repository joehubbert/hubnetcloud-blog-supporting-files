using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateCustomer : Form
    {
        private Guid _companyConfigurationId;
        private ActiveCompanyConfigurationHelper? _companyConfigHelper;
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreateCustomer()
        {
            InitializeComponent();
            InitializeEventHandlers();
            LoadDatabaseConnectionSettingsAsync();
            LoadActiveCompanyConfigurationAsync();
            LoadInitialDataAsync();
        }

        private void InitializeEventHandlers()
        {
            createCustomerTabControlBillingInformationTabPageAddressLine1Textbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerTabControlBillingInformationTabPageAddressLine2Textbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerTabControlBillingInformationTabPageAddressLine3Textbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerTabControlBillingInformationTabPageAddressLine4Textbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerTabControlBillingInformationTabPageAddressLine5ComboBox.SelectedIndexChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerTabControlBillingInformationTabPageCompanyNameTextbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerTabControlBillingInformationTabPageEmailAddressTextbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerTabControlBillingInformationTabPageFirstNameTextbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerTabControlBillingInformationTabPageLastNameTextbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerTabControlBillingInformationTabPageTelephoneNumberTextbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerTabControlFinanceTabPageCreditEnabledCheckbox.CheckedChanged += new EventHandler(CreateCustomerFinanceCreditEnabledCheckBox_CheckedChanged);
            createCustomerTabControlFinanceTabPagePaymentCurrencyComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            createCustomerTabControlFinanceTabPageVATRegisteredCheckbox.CheckedChanged += new EventHandler(CreateCustomerFinanceVATRegisteredCheckBox_CheckedChanged);
            createCustomerTabControlOverviewTabPageAccountManagerComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            createCustomerTabControlOverviewTabPageCompanyNameTextbox.TextChanged += new EventHandler(AutoPopulateBillingInformation);
            createCustomerTabControlOverviewTabPageCustomerTierComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            createCustomerTabControlOverviewTabPageCustomerTypeComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            createCustomerTabControlOverviewTabPageEmailAddressTextbox.TextChanged += new EventHandler(AutoPopulateBillingInformation);
            createCustomerTabControlOverviewTabPageExistingParentCompanyPanelNoRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewExistingParentCustomerRadioButton_CheckedChanged);
            createCustomerTabControlOverviewTabPageExistingParentCompanyPanelYesRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewExistingParentCustomerRadioButton_CheckedChanged);
            createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewExistingParentCompanyType_CheckedChanged);
            createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewRadioButtonValidation_CheckedChanged);
            createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewExistingParentCompanyType_CheckedChanged);
            createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewRadioButtonValidation_CheckedChanged);
            createCustomerTabControlOverviewTabPageFirstNameTextbox.TextChanged += new EventHandler(AutoPopulateBillingInformation);
            createCustomerTabControlOverviewTabPageLastNameTextbox.TextChanged += new EventHandler(AutoPopulateBillingInformation);
            createCustomerTabControlOverviewTabPageSalesRegionComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            createCustomerTabControlOverviewTabPageSalesRegionComboBox.SelectedIndexChanged += new EventHandler(CreateCustomerOverviewSalesRegionComboBox_SelectedIndexChanged);
            createCustomerTabControlOverviewTabPageTelephoneNumberTextbox.TextChanged += new EventHandler(AutoPopulateBillingInformation);
            createCustomerTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelNoRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewRadioButtonValidation_CheckedChanged);
            createCustomerTabControlOverviewTabPageWillBeParentTypePanelGlobalParentRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewRadioButtonValidation_CheckedChanged);
            createCustomerTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelYesRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewRadioButtonValidation_CheckedChanged);
            createCustomerTabControlOverviewTabPageWillBeParentTypePanelTopParentRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewRadioButtonValidation_CheckedChanged);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async void LoadActiveCompanyConfigurationAsync()
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(createCustomerStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.LoadAsync();
            _companyConfigurationId = _companyConfigHelper.CompanyConfigurationId;
        }

        private async Task LoadInitialDataAsync()
        {
            await LoadDatabaseConnectionSettingsAsync();

            var loadCountryTask = LoadCountryDataAsync();
            var loadCustomerTypeTask = LoadCustomerTypeAsync();
            var loadCustomerTierTask = LoadCustomerTierDataAsync();
            var loadSalesRegionTask = LoadSalesRegionDataAsync();
            var loadSalesSubRegionTask = LoadSalesRegionAndSubRegionDataAsync();
            var loadAccountManagerTask = LoadAccountManagerDataAsync();
            var loadCurrencyTask = LoadCurrencyDataAsync();

            await Task.WhenAll(loadCountryTask, loadCustomerTypeTask, loadCustomerTierTask, loadSalesRegionTask, loadAccountManagerTask, loadCurrencyTask);

            if (createCustomerTabControlOverviewTabPageSalesRegionComboBox.SelectedValue is Guid selectedSalesRegionId)
            {
                await LoadSalesSubRegionAsync(selectedSalesRegionId);
            }
        }

        private async Task LoadCustomerTypeAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCustomerTabControlOverviewTabPageCustomerTypeComboBox, "spGetAllCustomerType", _companyConfigurationId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDownHelper.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async Task LoadCountryDataAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCustomerTabControlBillingInformationTabPageAddressLine5ComboBox, "spGetAllCountry");
            await _dataAccessComboBoxHelper.LoadDataAsync();

            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCustomerTabControlShippingInformationTabPageAddressLine5ComboBox, "spGetAllCountry");
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadCustomerTierDataAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCustomerTabControlOverviewTabPageCustomerTierComboBox, "spGetAllCustomerTier", _companyConfigurationId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadSalesRegionDataAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCustomerTabControlOverviewTabPageSalesRegionComboBox, "spGetAllSalesRegion", _companyConfigurationId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadSalesSubRegionAsync(Guid salesRegionId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCustomerTabControlOverviewTabPageSalesSubRegionComboBox, "spGetAllSalesSubRegion", null, true, "Sales Region Id", salesRegionId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadSalesRegionAndSubRegionDataAsync()
        {
            await LoadSalesRegionDataAsync();
            if (createCustomerTabControlOverviewTabPageSalesRegionComboBox.SelectedValue is Guid selectedSalesRegionId)
            {
                await LoadSalesSubRegionAsync(selectedSalesRegionId);
            }
        }

        private async void CreateCustomerOverviewSalesRegionComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (createCustomerTabControlOverviewTabPageSalesRegionComboBox.SelectedValue is Guid selectedSalesRegionId)
            {
                await LoadSalesSubRegionAsync(selectedSalesRegionId);
            }
        }

        private async Task LoadAccountManagerDataAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCustomerTabControlOverviewTabPageAccountManagerComboBox, "spGetAllAccountManager", _companyConfigurationId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private void CreateCustomerOverviewExistingParentCustomerRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCustomerTabControlOverviewTabPageExistingParentCompanyPanelNoRadioButton.Checked)
            {
                createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.Enabled = false;
                createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.Enabled = false;
                createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.Checked = false;
                createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.Checked = false;
                createCustomerTabControlOverviewTabPageGlobalParentCustomerComboBox.Enabled = false;
                createCustomerTabControlOverviewTabPageGlobalParentCustomerComboBox.DataSource = null;
                createCustomerTabControlOverviewTabPageGlobalParentCustomerComboBox.Items.Clear();
                createCustomerTabControlOverviewTabPageTopParentCustomerComboBox.Enabled = false;
                createCustomerTabControlOverviewTabPageTopParentCustomerComboBox.DataSource = null;
                createCustomerTabControlOverviewTabPageTopParentCustomerComboBox.Items.Clear();
            }
            else if (createCustomerTabControlOverviewTabPageExistingParentCompanyPanelYesRadioButton.Checked)
            {
                createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.Enabled = true;
                createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.Enabled = true;
            }
        }

        private async void CreateCustomerOverviewExistingParentCompanyType_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.Checked)
            {
                await LoadGlobalParentCustomerDataAsync();
                createCustomerTabControlOverviewTabPageGlobalParentCustomerComboBox.Enabled = true;
                createCustomerTabControlOverviewTabPageTopParentCustomerComboBox.Enabled = false;
                createCustomerTabControlOverviewTabPageTopParentCustomerComboBox.DataSource = null;
                createCustomerTabControlOverviewTabPageTopParentCustomerComboBox.Items.Clear();

            }
            else if (createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.Checked)
            {
                await LoadTopParentCustomerDataAsync();
                createCustomerTabControlOverviewTabPageTopParentCustomerComboBox.Enabled = true;
                createCustomerTabControlOverviewTabPageGlobalParentCustomerComboBox.Enabled = false;
                createCustomerTabControlOverviewTabPageGlobalParentCustomerComboBox.DataSource = null;
                createCustomerTabControlOverviewTabPageGlobalParentCustomerComboBox.Items.Clear();
            }
        }

        private async Task LoadGlobalParentCustomerDataAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCustomerTabControlOverviewTabPageGlobalParentCustomerComboBox, "spGetAllGlobalParentCustomer");
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadTopParentCustomerDataAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCustomerTabControlOverviewTabPageTopParentCustomerComboBox, "spGetAllTopParentCustomer");
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private void CreateCustomerOverviewRadioButtonValidation_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.Checked)
            {
                createCustomerTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelYesRadioButton.Enabled = false;
                createCustomerTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelNoRadioButton.Enabled = false;
                createCustomerTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelYesRadioButton.Checked = false;
                createCustomerTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelNoRadioButton.Checked = false;
                createCustomerTabControlOverviewTabPageWillBeParentTypePanelGlobalParentRadioButton.Checked = false;
                createCustomerTabControlOverviewTabPageWillBeParentTypePanelGlobalParentRadioButton.Enabled = false;
                createCustomerTabControlOverviewTabPageWillBeParentTypePanelTopParentRadioButton.Checked = false;
                createCustomerTabControlOverviewTabPageWillBeParentTypePanelTopParentRadioButton.Enabled = false;

            }
            else if (createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.Checked && createCustomerTabControlOverviewTabPageWillBeParentTypePanelTopParentRadioButton.Checked)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Customer.TopParent.TopParentRelationshipValidation");
                createCustomerTabControlOverviewTabPageWillBeParentTypePanelTopParentRadioButton.Checked = false;
                createCustomerTabControlOverviewTabPageWillBeParentTypePanelTopParentRadioButton.Enabled = false;
                createCustomerTabControlOverviewTabPageWillBeParentTypePanelGlobalParentRadioButton.Checked = false;
                createCustomerTabControlOverviewTabPageWillBeParentTypePanelGlobalParentRadioButton.Enabled = false;
            }

            if (createCustomerTabControlOverviewTabPageWillBeParentTypePanelGlobalParentRadioButton.Checked)
            {
                var selectedCustomerType = createCustomerTabControlOverviewTabPageCustomerTypeComboBox.Text;
                if (selectedCustomerType != "Business - Multinational")
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Customer.GlobalParentType.CustomerTypeValidation");
                    createCustomerTabControlOverviewTabPageWillBeParentTypePanelGlobalParentRadioButton.Checked = false;
                }
            }
            else if (createCustomerTabControlOverviewTabPageWillBeParentTypePanelGlobalParentRadioButton.Checked && createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.Checked)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Customer.GlobalParent.GlobalParentRelationshipValidation");
                createCustomerTabControlOverviewTabPageWillBeParentTypePanelGlobalParentRadioButton.Checked = false;
                createCustomerTabControlOverviewTabPageWillBeParentTypePanelGlobalParentRadioButton.Enabled = false;
            }

            if (createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.Checked)
            {
                var selectedCustomerType = createCustomerTabControlOverviewTabPageCustomerTypeComboBox.Text;
                if (selectedCustomerType != "Business - Multinational")
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Customer.CustomerType.MultinationalValidation");
                    createCustomerTabControlOverviewTabPageWillBeParentTypePanelGlobalParentRadioButton.Checked = false;
                    createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.Checked = false;
                }
            }

            if (createCustomerTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelNoRadioButton.Checked)
            {
                createCustomerTabControlOverviewTabPageWillBeParentTypePanelGlobalParentRadioButton.Enabled = false;
                createCustomerTabControlOverviewTabPageWillBeParentTypePanelTopParentRadioButton.Enabled = false;
                createCustomerTabControlOverviewTabPageWillBeParentTypePanelGlobalParentRadioButton.Checked = false;
                createCustomerTabControlOverviewTabPageWillBeParentTypePanelTopParentRadioButton.Checked = false;
            }
            else if (createCustomerTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelYesRadioButton.Checked)
            {
                createCustomerTabControlOverviewTabPageWillBeParentTypePanelGlobalParentRadioButton.Enabled = true;
                createCustomerTabControlOverviewTabPageWillBeParentTypePanelTopParentRadioButton.Enabled = true;
            }

            if (createCustomerTabControlOverviewTabPageExistingParentCompanyPanelNoRadioButton.Checked)
            {
                createCustomerTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelNoRadioButton.Enabled = true;
                createCustomerTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelYesRadioButton.Enabled = true;
            }
        }

        private void AutoPopulateBillingInformation(object? sender, EventArgs e)
        {
            createCustomerTabControlBillingInformationTabPageFirstNameTextbox.Text = createCustomerTabControlOverviewTabPageFirstNameTextbox.Text;
            createCustomerTabControlBillingInformationTabPageLastNameTextbox.Text = createCustomerTabControlOverviewTabPageLastNameTextbox.Text;
            createCustomerTabControlBillingInformationTabPageCompanyNameTextbox.Text = createCustomerTabControlOverviewTabPageCompanyNameTextbox.Text;
            createCustomerTabControlBillingInformationTabPageEmailAddressTextbox.Text = createCustomerTabControlOverviewTabPageEmailAddressTextbox.Text;
            createCustomerTabControlBillingInformationTabPageTelephoneNumberTextbox.Text = createCustomerTabControlOverviewTabPageTelephoneNumberTextbox.Text;
        }

        private void AutoPopulateShippingInformation(object? sender, EventArgs e)
        {
            createCustomerTabControlShippingInformationTabPageAddressLine1Textbox.Text = createCustomerTabControlBillingInformationTabPageAddressLine1Textbox.Text;
            createCustomerTabControlShippingInformationTabPageAddressLine2Textbox.Text = createCustomerTabControlBillingInformationTabPageAddressLine2Textbox.Text;
            createCustomerTabControlShippingInformationTabPageAddressLine3Textbox.Text = createCustomerTabControlBillingInformationTabPageAddressLine3Textbox.Text;
            createCustomerTabControlShippingInformationTabPageAddressLine4Textbox.Text = createCustomerTabControlBillingInformationTabPageAddressLine4Textbox.Text;
            createCustomerTabControlShippingInformationTabPageAddressLine5ComboBox.SelectedValue = createCustomerTabControlBillingInformationTabPageAddressLine5ComboBox.SelectedValue;
            createCustomerTabControlShippingInformationTabPageCompanyNameTextbox.Text = createCustomerTabControlBillingInformationTabPageCompanyNameTextbox.Text;
            createCustomerTabControlShippingInformationTabPageEmailAddressTextbox.Text = createCustomerTabControlBillingInformationTabPageEmailAddressTextbox.Text;
            createCustomerTabControlShippingInformationTabPageFirstNameTextbox.Text = createCustomerTabControlBillingInformationTabPageFirstNameTextbox.Text;
            createCustomerTabControlShippingInformationTabPageLastNameTextbox.Text = createCustomerTabControlBillingInformationTabPageLastNameTextbox.Text;
            createCustomerTabControlShippingInformationTabPageTelephoneNumberTextbox.Text = createCustomerTabControlBillingInformationTabPageTelephoneNumberTextbox.Text;
        }

        private void CreateCustomerFinanceCreditEnabledCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCustomerTabControlFinanceTabPageCreditEnabledCheckbox.Checked)
            {
                createCustomerTabControlFinanceTabPageCreditLimitTextboxA.Enabled = true;
                createCustomerTabControlFinanceTabPageCreditLimitTextboxB.Enabled = true;
            }
            else
            {
                createCustomerTabControlFinanceTabPageCreditLimitTextboxA.Enabled = false;
                createCustomerTabControlFinanceTabPageCreditLimitTextboxB.Enabled = false;
            }
        }

        private void CreateCustomerFinanceVATRegisteredCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCustomerTabControlFinanceTabPageVATRegisteredCheckbox.Checked)
            {
                createCustomerTabControlFinanceTabPageVATNumberTextbox.Enabled = true;
            }
            else
            {
                createCustomerTabControlFinanceTabPageVATNumberTextbox.Enabled = false;
                createCustomerTabControlFinanceTabPageVATNumberTextbox.Text = string.Empty;
            }
        }

        private async Task LoadCurrencyDataAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCustomerTabControlFinanceTabPagePaymentCurrencyComboBox, "spGetAllCurrency");
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async void createCustomerSubmitButton_Click(object sender, EventArgs e)
        {
            string customerBillingInformationAddressLine1 = createCustomerTabControlBillingInformationTabPageAddressLine1Textbox.Text.TrimEnd();
            string? customerBillingInformationAddressLine2 = createCustomerTabControlBillingInformationTabPageAddressLine2Textbox.Text.TrimEnd();
            string customerBillingInformationAddressLine3 = createCustomerTabControlBillingInformationTabPageAddressLine3Textbox.Text.TrimEnd();
            string customerBillingInformationAddressLine4 = createCustomerTabControlBillingInformationTabPageAddressLine4Textbox.Text.TrimEnd();
            Guid customerBillingInformationAddressLine5 = Guid.Parse(createCustomerTabControlBillingInformationTabPageAddressLine5ComboBox.SelectedValue.ToString());
            string? customerBillingInformationCompanyName = createCustomerTabControlBillingInformationTabPageCompanyNameTextbox.Text.TrimEnd();
            string customerBillingInformationEmailAddress = createCustomerTabControlBillingInformationTabPageEmailAddressTextbox.Text.TrimEnd();
            string customerBillingInformationFirstName = createCustomerTabControlBillingInformationTabPageFirstNameTextbox.Text.TrimEnd();
            string customerBillingInformationLastName = createCustomerTabControlBillingInformationTabPageLastNameTextbox.Text.TrimEnd();
            string customerBillingInformationTelephoneNumber = createCustomerTabControlBillingInformationTabPageTelephoneNumberTextbox.Text.TrimEnd();
            bool customerFinanceCreditEnabled = createCustomerTabControlFinanceTabPageCreditEnabledCheckbox.Checked;
            if (!customerFinanceCreditEnabled)
            {
                createCustomerTabControlFinanceTabPageCreditLimitTextboxA.Text = "0";
                createCustomerTabControlFinanceTabPageCreditLimitTextboxB.Text = "00";
            }
            decimal customerFinanceCreditLimit = decimal.Parse($"{createCustomerTabControlFinanceTabPageCreditLimitTextboxA.Text.TrimEnd()}.{createCustomerTabControlFinanceTabPageCreditLimitTextboxB.Text.TrimEnd()}");
            Guid customerFinancePaymentCurrencyId = Guid.Parse(createCustomerTabControlFinanceTabPagePaymentCurrencyComboBox.SelectedValue.ToString());
            byte customerFinancePaymentDays = byte.Parse(createCustomerTabControlFinanceTabPagePaymentDaysTextbox.Text.TrimEnd());
            string? customerFinanceVATNumber = createCustomerTabControlFinanceTabPageVATNumberTextbox.Text.TrimEnd();

            Guid customerOverviewAccountManagerId = Guid.Parse(createCustomerTabControlOverviewTabPageAccountManagerComboBox.SelectedValue.ToString());
            bool customerOverviewActiveStatus = createCustomerOverviewActiveStatusCheckbox.Checked;
            string? customerOverviewCompanyName = createCustomerTabControlOverviewTabPageCompanyNameTextbox.Text.TrimEnd();
            DateTime customerOverviewCustomerSince = createCustomerTabControlOverviewTabPageCustomerSinceDatePicker.Value.Date;
            Guid customerOverviewCustomerTierId = Guid.Parse(createCustomerTabControlOverviewTabPageCustomerTierComboBox.SelectedValue.ToString());
            Guid customerOverviewCustomerTypeId = Guid.Parse(createCustomerTabControlOverviewTabPageCustomerTypeComboBox.SelectedValue.ToString());
            string customerOverviewEmailAddress = createCustomerTabControlOverviewTabPageEmailAddressTextbox.Text.TrimEnd();
            Guid? customerOverviewExistingGlobalParentCustomerId = null;
            if (createCustomerTabControlOverviewTabPageGlobalParentCustomerComboBox.SelectedValue != null)
            {
                customerOverviewExistingGlobalParentCustomerId = Guid.Parse(createCustomerTabControlOverviewTabPageGlobalParentCustomerComboBox.SelectedValue.ToString());
            }
            Guid? customerOverviewExistingTopParentCustomerId = null;
            if (createCustomerTabControlOverviewTabPageTopParentCustomerComboBox.SelectedValue != null)
            {
                customerOverviewExistingTopParentCustomerId = Guid.Parse(createCustomerTabControlOverviewTabPageTopParentCustomerComboBox.SelectedValue.ToString());
            }
            string customerOverviewFirstName = createCustomerTabControlOverviewTabPageFirstNameTextbox.Text.TrimEnd();
            string customerOverviewLastName = createCustomerTabControlOverviewTabPageLastNameTextbox.Text.TrimEnd();
            Guid customerOverviewSalesSubRegionId = Guid.Parse(createCustomerTabControlOverviewTabPageSalesSubRegionComboBox.SelectedValue.ToString());
            string customerOverviewTelephoneNumber = createCustomerTabControlOverviewTabPageTelephoneNumberTextbox.Text.TrimEnd();
            bool customerOverviewWillBeGlobalParent = createCustomerTabControlOverviewTabPageWillBeParentTypePanelGlobalParentRadioButton.Checked;
            bool customerOverviewWillBeTopParent = createCustomerTabControlOverviewTabPageWillBeParentTypePanelTopParentRadioButton.Checked;

            string customerShippingInformationAddressLine1 = createCustomerTabControlShippingInformationTabPageAddressLine1Textbox.Text.TrimEnd();
            string? customerShippingInformationAddressLine2 = createCustomerTabControlShippingInformationTabPageAddressLine2Textbox.Text.TrimEnd();
            string customerShippingInformationAddressLine3 = createCustomerTabControlShippingInformationTabPageAddressLine3Textbox.Text.TrimEnd();
            string customerShippingInformationAddressLine4 = createCustomerTabControlShippingInformationTabPageAddressLine4Textbox.Text.TrimEnd();
            Guid customerShippingInformationAddressLine5 = Guid.Parse(createCustomerTabControlShippingInformationTabPageAddressLine5ComboBox.SelectedValue.ToString());
            string? customerShippingInformationCompanyName = createCustomerTabControlShippingInformationTabPageCompanyNameTextbox.Text.TrimEnd();
            string customerShippingInformationEmailAddress = createCustomerTabControlShippingInformationTabPageEmailAddressTextbox.Text.TrimEnd();
            string customerShippingInformationFirstName = createCustomerTabControlShippingInformationTabPageFirstNameTextbox.Text.TrimEnd();
            string customerShippingInformationLastName = createCustomerTabControlShippingInformationTabPageLastNameTextbox.Text.TrimEnd();
            string customerShippingInformationTelephoneNumber = createCustomerTabControlShippingInformationTabPageTelephoneNumberTextbox.Text.TrimEnd();

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
                    Name = "Company Configuration Id",
                    Value = _companyConfigurationId,
                    ValueType = typeof(Guid)
                },
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
                    Name = "Custome Overview: Last Name",
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
                        ParameterName = "creditEnabled",
                        ParameterValue = customerFinanceCreditEnabled
                    },
                    new Parameter
                    {
                        ParameterName = "creditLimit",
                        ParameterValue = customerFinanceCreditLimit
                    },
                    new Parameter
                    {
                        ParameterName = "companyConfigurationId",
                        ParameterValue = _companyConfigurationId
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

                if (!string.IsNullOrEmpty(customerFinanceVATNumber))
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "vatNumber",
                        ParameterValue = customerFinanceVATNumber
                    });
                }

                string storedProcedureName = "spCreateCustomer";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters.ToArray(), dataSubject, operationType);
                this.Close();
            }
        }

        private async void changeActiveCompanyConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(createCustomerStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.ShowChangeDialogAndReloadAsync(this);
            _companyConfigurationId = _companyConfigHelper.CompanyConfigurationId;
        }
    }
}