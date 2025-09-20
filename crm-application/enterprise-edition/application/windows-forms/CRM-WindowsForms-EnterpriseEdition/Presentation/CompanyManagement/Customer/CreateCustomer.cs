using CRM.Helpers;
using CRM.Interface;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.CompanyManagement.Customer
{
    public partial class CreateCustomer : Form
    {
        private Guid _companyConfigurationId;
        private ActiveCompanyConfigurationHelper? _companyConfigHelper;
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private TextBoxNumericCharacterDataValidationHelper _textBoxNumericHelper;

        public CreateCustomer()
        {
            InitializeComponent();
            _textBoxNumericHelper = new TextBoxNumericCharacterDataValidationHelper();
            InitializeEventHandlers();
            LoadDatabaseConnectionSettingsAsync();
            LoadActiveCompanyConfigurationAsync();
            LoadCountryDataAsync();
            LoadCustomerTypeAsync();
            LoadCustomerTierDataAsync();
            LoadSalesRegionDataAsync();
            LoadSalesRegionAndSubRegionDataAsync();
            LoadAccountManagerDataAsync();
            LoadCurrencyDataAsync();
        }

        private void InitializeEventHandlers()
        {
            createCustomerTabControlBillingInformationTabPageAddressLine1TextBox.TextChanged += AutoPopulateShippingInformation;
            createCustomerTabControlBillingInformationTabPageAddressLine2TextBox.TextChanged += AutoPopulateShippingInformation;
            createCustomerTabControlBillingInformationTabPageAddressLine3TextBox.TextChanged += AutoPopulateShippingInformation;
            createCustomerTabControlBillingInformationTabPageAddressLine4TextBox.TextChanged += AutoPopulateShippingInformation;
            createCustomerTabControlBillingInformationTabPageAddressLine5ComboBox.SelectedIndexChanged += AutoPopulateShippingInformation;
            createCustomerTabControlBillingInformationTabPageCompanyNameTextBox.TextChanged += AutoPopulateShippingInformation;
            createCustomerTabControlBillingInformationTabPageEmailAddressTextBox.TextChanged += AutoPopulateShippingInformation;
            createCustomerTabControlBillingInformationTabPageFirstNameTextBox.TextChanged += AutoPopulateShippingInformation;
            createCustomerTabControlBillingInformationTabPageLastNameTextBox.TextChanged += AutoPopulateShippingInformation;
            createCustomerTabControlBillingInformationTabPageTelephoneNumberTextBox.TextChanged += AutoPopulateShippingInformation;
            createCustomerTabControlFinanceTabPageCreditEnabledCheckBox.CheckedChanged += createCustomerTabControlFinanceTabPageCreditEnabledCheckBox_CheckedChanged;
            createCustomerTabControlFinanceTabPageCreditLimitTextBoxA.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            createCustomerTabControlFinanceTabPageCreditLimitTextBoxB.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            createCustomerTabControlFinanceTabPagePaymentCurrencyComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            createCustomerTabControlFinanceTabPagePaymentDaysTextBox.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            createCustomerTabControlFinanceTabPageVATRegisteredCheckBox.CheckedChanged += createCustomerTabControlFinanceTabPageVATRegisteredCheckBox_CheckedChanged;
            createCustomerTabControlOverviewTabPageAccountManagerComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            createCustomerTabControlOverviewTabPageCompanyNameTextBox.TextChanged += AutoPopulateBillingInformation;
            createCustomerTabControlOverviewTabPageCustomerTierComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            createCustomerTabControlOverviewTabPageCustomerTypeComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            createCustomerTabControlOverviewTabPageEmailAddressTextBox.TextChanged += AutoPopulateBillingInformation;
            createCustomerTabControlOverviewTabPageExistingParentCompanyPanelNoRadioButton.CheckedChanged += createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelRadioButton_CheckedChanged;
            createCustomerTabControlOverviewTabPageExistingParentCompanyPanelYesRadioButton.CheckedChanged += createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelRadioButton_CheckedChanged;
            createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.CheckedChanged += createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelRadioButton_CheckedChanged;
            createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.CheckedChanged += createCustomerTabControlOverviewTabPageRadioButtonValidation_CheckedChanged;
            createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.CheckedChanged += createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelRadioButton_CheckedChanged;
            createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.CheckedChanged += createCustomerTabControlOverviewTabPageRadioButtonValidation_CheckedChanged;
            createCustomerTabControlOverviewTabPageFirstNameTextBox.TextChanged += AutoPopulateBillingInformation;
            createCustomerTabControlOverviewTabPageLastNameTextBox.TextChanged += AutoPopulateBillingInformation;
            createCustomerTabControlOverviewTabPageSalesRegionComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            createCustomerTabControlOverviewTabPageSalesRegionComboBox.SelectedIndexChanged += createCustomerTabControlOverviewTabPageSalesRegionComboBox_SelectedIndexChanged;
            createCustomerTabControlOverviewTabPageTelephoneNumberTextBox.TextChanged += AutoPopulateBillingInformation;
            createCustomerTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelNoRadioButton.CheckedChanged += createCustomerTabControlOverviewTabPageRadioButtonValidation_CheckedChanged;
            createCustomerTabControlOverviewTabPageWillBeParentTypePanelGlobalParentRadioButton.CheckedChanged += createCustomerTabControlOverviewTabPageRadioButtonValidation_CheckedChanged;
            createCustomerTabControlOverviewTabPageWillBeParentInCustomerHierarchyPanelYesRadioButton.CheckedChanged += createCustomerTabControlOverviewTabPageRadioButtonValidation_CheckedChanged;
            createCustomerTabControlOverviewTabPageWillBeParentTypePanelTopParentRadioButton.CheckedChanged += createCustomerTabControlOverviewTabPageRadioButtonValidation_CheckedChanged;
        }

        private void AutoPopulateBillingInformation(object? sender, EventArgs e)
        {
            createCustomerTabControlBillingInformationTabPageFirstNameTextBox.Text = createCustomerTabControlOverviewTabPageFirstNameTextBox.Text;
            createCustomerTabControlBillingInformationTabPageLastNameTextBox.Text = createCustomerTabControlOverviewTabPageLastNameTextBox.Text;
            createCustomerTabControlBillingInformationTabPageCompanyNameTextBox.Text = createCustomerTabControlOverviewTabPageCompanyNameTextBox.Text;
            createCustomerTabControlBillingInformationTabPageEmailAddressTextBox.Text = createCustomerTabControlOverviewTabPageEmailAddressTextBox.Text;
            createCustomerTabControlBillingInformationTabPageTelephoneNumberTextBox.Text = createCustomerTabControlOverviewTabPageTelephoneNumberTextBox.Text;
        }

        private void AutoPopulateShippingInformation(object? sender, EventArgs e)
        {
            createCustomerTabControlShippingInformationTabPageAddressLine1TextBox.Text = createCustomerTabControlBillingInformationTabPageAddressLine1TextBox.Text;
            createCustomerTabControlShippingInformationTabPageAddressLine2TextBox.Text = createCustomerTabControlBillingInformationTabPageAddressLine2TextBox.Text;
            createCustomerTabControlShippingInformationTabPageAddressLine3TextBox.Text = createCustomerTabControlBillingInformationTabPageAddressLine3TextBox.Text;
            createCustomerTabControlShippingInformationTabPageAddressLine4TextBox.Text = createCustomerTabControlBillingInformationTabPageAddressLine4TextBox.Text;
            createCustomerTabControlShippingInformationTabPageAddressLine5ComboBox.SelectedValue = createCustomerTabControlBillingInformationTabPageAddressLine5ComboBox.SelectedValue;
            createCustomerTabControlShippingInformationTabPageCompanyNameTextBox.Text = createCustomerTabControlBillingInformationTabPageCompanyNameTextBox.Text;
            createCustomerTabControlShippingInformationTabPageEmailAddressTextBox.Text = createCustomerTabControlBillingInformationTabPageEmailAddressTextBox.Text;
            createCustomerTabControlShippingInformationTabPageFirstNameTextBox.Text = createCustomerTabControlBillingInformationTabPageFirstNameTextBox.Text;
            createCustomerTabControlShippingInformationTabPageLastNameTextBox.Text = createCustomerTabControlBillingInformationTabPageLastNameTextBox.Text;
            createCustomerTabControlShippingInformationTabPageTelephoneNumberTextBox.Text = createCustomerTabControlBillingInformationTabPageTelephoneNumberTextBox.Text;
        }

        private async void LoadAccountManagerDataAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCustomerTabControlOverviewTabPageAccountManagerComboBox, "spGetAllAccountManager", _companyConfigurationId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async void LoadActiveCompanyConfigurationAsync()
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(createCustomerStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.LoadAsync();
            _companyConfigurationId = _companyConfigHelper.CompanyConfigurationId;
        }

        private async void LoadCountryDataAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCustomerTabControlBillingInformationTabPageAddressLine5ComboBox, "spGetAllCountry");
            await _dataAccessComboBoxHelper.LoadDataAsync();

            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCustomerTabControlShippingInformationTabPageAddressLine5ComboBox, "spGetAllCountry");
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async Task LoadCurrencyDataAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCustomerTabControlFinanceTabPagePaymentCurrencyComboBox, "spGetAllCurrency");
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async void LoadCustomerTierDataAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCustomerTabControlOverviewTabPageCustomerTierComboBox, "spGetAllCustomerTier", _companyConfigurationId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async void LoadCustomerTypeAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCustomerTabControlOverviewTabPageCustomerTypeComboBox, "spGetAllCustomerType", _companyConfigurationId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task LoadGlobalParentCustomerDataAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCustomerTabControlOverviewTabPageGlobalParentCustomerComboBox, "spGetAllGlobalParentCustomer");
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

        private async Task LoadTopParentCustomerDataAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCustomerTabControlOverviewTabPageTopParentCustomerComboBox, "spGetAllTopParentCustomer");
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async void changeActiveCompanyConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _companyConfigHelper = new ActiveCompanyConfigurationHelper(createCustomerStatusStripCompanyConfigurationPlaceholder);
            await _companyConfigHelper.ShowChangeDialogAndReloadAsync(this);
            _companyConfigurationId = _companyConfigHelper.CompanyConfigurationId;
        }

        private void createCustomerTabControlFinanceTabPageCreditEnabledCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCustomerTabControlFinanceTabPageCreditEnabledCheckBox.Checked)
            {
                createCustomerTabControlFinanceTabPageCreditLimitTextBoxA.Enabled = true;
                createCustomerTabControlFinanceTabPageCreditLimitTextBoxB.Enabled = true;
            }
            else
            {
                createCustomerTabControlFinanceTabPageCreditLimitTextBoxA.Enabled = false;
                createCustomerTabControlFinanceTabPageCreditLimitTextBoxB.Enabled = false;
            }
        }

        private void createCustomerTabControlFinanceTabPageVATRegisteredCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCustomerTabControlFinanceTabPageVATRegisteredCheckBox.Checked)
            {
                createCustomerTabControlFinanceTabPageVATNumberTextBox.Enabled = true;
            }
            else
            {
                createCustomerTabControlFinanceTabPageVATNumberTextBox.Enabled = false;
                var result = MessageBox.Show(
                    "A VAT Number cannot be assigned if VAT Registered is false. Clicking OK will clear the VAT Number field. Clicking Cancel will reverse the changes.",
                    "Warning",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    createCustomerTabControlFinanceTabPageVATNumberTextBox.Text = string.Empty;
                }
                else
                {
                    createCustomerTabControlFinanceTabPageVATRegisteredCheckBox.Checked = true;
                    createCustomerTabControlFinanceTabPageVATNumberTextBox.Enabled = true;
                }
            }
        }

        private async void createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelRadioButton_CheckedChanged(object? sender, EventArgs e)
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

        private void createCustomerTabControlOverviewTabPageRadioButtonValidation_CheckedChanged(object? sender, EventArgs e)
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

        private async void createCustomerTabControlOverviewTabPageSalesRegionComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (createCustomerTabControlOverviewTabPageSalesRegionComboBox.SelectedValue is Guid selectedSalesRegionId)
            {
                await LoadSalesSubRegionAsync(selectedSalesRegionId);
            }
        }

        private async void createCustomerSubmitButton_Click(object sender, EventArgs e)
        {
            string customerBillingInformationAddressLine1 = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlBillingInformationTabPageAddressLine1TextBox);
            string? customerBillingInformationAddressLine2 = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlBillingInformationTabPageAddressLine2TextBox);
            string customerBillingInformationAddressLine3 = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlBillingInformationTabPageAddressLine3TextBox);
            string customerBillingInformationAddressLine4 = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlBillingInformationTabPageAddressLine4TextBox);
            Guid customerBillingInformationAddressLine5 = (Guid)createCustomerTabControlBillingInformationTabPageAddressLine5ComboBox.SelectedValue;
            string? customerBillingInformationCompanyName = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlBillingInformationTabPageCompanyNameTextBox);
            string customerBillingInformationEmailAddress = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlBillingInformationTabPageEmailAddressTextBox);
            string customerBillingInformationFirstName = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlBillingInformationTabPageFirstNameTextBox);
            string customerBillingInformationLastName = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlBillingInformationTabPageLastNameTextBox);
            string customerBillingInformationTelephoneNumber = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlBillingInformationTabPageTelephoneNumberTextBox);
            bool customerFinanceCreditEnabled = createCustomerTabControlFinanceTabPageCreditEnabledCheckBox.Checked;
            if (!customerFinanceCreditEnabled)
            {
                createCustomerTabControlFinanceTabPageCreditLimitTextBoxA.Text = "0";
                createCustomerTabControlFinanceTabPageCreditLimitTextBoxB.Text = "00";
            }
            decimal customerFinanceCreditLimit = decimal.Parse($"{TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlFinanceTabPageCreditLimitTextBoxA)}.{TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlFinanceTabPageCreditLimitTextBoxB)}");
            Guid customerFinancePaymentCurrencyId = (Guid)createCustomerTabControlFinanceTabPagePaymentCurrencyComboBox.SelectedValue;
            byte customerFinancePaymentDays = byte.Parse(TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlFinanceTabPagePaymentDaysTextBox));
            string? customerFinanceVATNumber = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlFinanceTabPageVATNumberTextBox);
            bool customerFinanceVATRegistered = createCustomerTabControlFinanceTabPageVATRegisteredCheckBox.Checked;

            Guid customerOverviewAccountManagerId = (Guid)createCustomerTabControlOverviewTabPageAccountManagerComboBox.SelectedValue;
            bool customerOverviewActiveStatus = createCustomerTabControlOverviewTabPageActiveStatusCheckBox.Checked;
            string? customerOverviewCompanyName = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlOverviewTabPageCompanyNameTextBox);
            DateTime customerOverviewCustomerSince = createCustomerTabControlOverviewTabPageCustomerSinceDatePicker.Value.Date;
            Guid customerOverviewCustomerTierId = (Guid)createCustomerTabControlOverviewTabPageCustomerTierComboBox.SelectedValue;
            Guid customerOverviewCustomerTypeId = (Guid)createCustomerTabControlOverviewTabPageCustomerTypeComboBox.SelectedValue;
            string customerOverviewEmailAddress = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlOverviewTabPageEmailAddressTextBox);
            Guid? customerOverviewExistingGlobalParentCustomerId = null;
            if (createCustomerTabControlOverviewTabPageGlobalParentCustomerComboBox.SelectedValue != null)
            {
                customerOverviewExistingGlobalParentCustomerId = (Guid)createCustomerTabControlOverviewTabPageGlobalParentCustomerComboBox.SelectedValue;
            }
            Guid? customerOverviewExistingTopParentCustomerId = null;
            if (createCustomerTabControlOverviewTabPageTopParentCustomerComboBox.SelectedValue != null)
            {
                customerOverviewExistingTopParentCustomerId = (Guid)createCustomerTabControlOverviewTabPageTopParentCustomerComboBox.SelectedValue;
            }
            string customerOverviewFirstName = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlOverviewTabPageFirstNameTextBox);
            string customerOverviewLastName = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlOverviewTabPageLastNameTextBox);
            Guid customerOverviewSalesSubRegionId = (Guid)createCustomerTabControlOverviewTabPageSalesSubRegionComboBox.SelectedValue;
            string customerOverviewTelephoneNumber = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlOverviewTabPageTelephoneNumberTextBox);
            bool customerOverviewWillBeGlobalParent = createCustomerTabControlOverviewTabPageWillBeParentTypePanelGlobalParentRadioButton.Checked;
            bool customerOverviewWillBeTopParent = createCustomerTabControlOverviewTabPageWillBeParentTypePanelTopParentRadioButton.Checked;

            string customerShippingInformationAddressLine1 = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlShippingInformationTabPageAddressLine1TextBox);
            string? customerShippingInformationAddressLine2 = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlShippingInformationTabPageAddressLine2TextBox);
            string customerShippingInformationAddressLine3 = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlShippingInformationTabPageAddressLine3TextBox);
            string customerShippingInformationAddressLine4 = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlShippingInformationTabPageAddressLine4TextBox);
            Guid customerShippingInformationAddressLine5 = (Guid)createCustomerTabControlShippingInformationTabPageAddressLine5ComboBox.SelectedValue;
            string? customerShippingInformationCompanyName = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlShippingInformationTabPageCompanyNameTextBox);
            string customerShippingInformationEmailAddress = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlShippingInformationTabPageEmailAddressTextBox);
            string customerShippingInformationFirstName = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlShippingInformationTabPageFirstNameTextBox);
            string customerShippingInformationLastName = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlShippingInformationTabPageLastNameTextBox);
            string customerShippingInformationTelephoneNumber = TextBoxCleanerHelper.GetTrimmedText(createCustomerTabControlShippingInformationTabPageTelephoneNumberTextBox);

            string dataSubject = "Customer";

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
                    Name = "Company Configuration Id",
                    Value = _companyConfigurationId,
                    ValueType = typeof(Guid)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Billing Information: Address Line 1",
                    Value = customerBillingInformationAddressLine1,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Customer Billing Information: Address Line 2",
                    Value = customerBillingInformationAddressLine2,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Billing Information: Address Line 3",
                    Value = customerBillingInformationAddressLine3,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Billing Information: Address Line 4",
                    Value = customerBillingInformationAddressLine4,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Billing Information: Address Line 5",
                    Value = customerBillingInformationAddressLine5,
                    ValueType = typeof(Guid)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Customer Billing Information: Company Name",
                    Value = customerBillingInformationCompanyName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Billing Information: Email Address",
                    Value = customerBillingInformationEmailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Billing Information: First Name",
                    Value = customerBillingInformationFirstName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Billing Information: Last Name",
                    Value = customerBillingInformationLastName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Billing Information: Telephone Number",
                    Value = customerBillingInformationTelephoneNumber,
                    MaxLength = 13,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Finance: Credit Enabled",
                    Value = customerFinanceCreditEnabled,
                    ValueType = typeof(bool)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Finance: Credit Limit",
                    Value = customerFinanceCreditLimit,
                    ValueType = typeof(decimal)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Finance: Payment Currency Id",
                    Value = customerFinancePaymentCurrencyId,
                    ValueType = typeof(Guid)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Finance: Payment Days",
                    Value = customerFinancePaymentDays,
                    ValueType = typeof(byte)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Company Finance: VAT Number",
                    Value = customerFinanceVATNumber,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Finance: VAT Registered",
                    Value = customerFinanceVATRegistered,
                    ValueType = typeof(bool)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Account Manager Id",
                    Value = customerOverviewAccountManagerId,
                    ValueType = typeof(Guid)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Active Status",
                    Value = customerOverviewActiveStatus,
                    ValueType = typeof(bool)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Customer Overview: Company Name",
                    Value = customerOverviewCompanyName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Customer Since",
                    Value = customerOverviewCustomerSince,
                    ValueType = typeof(DateTime)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Customer Tier Id",
                    Value = customerOverviewCustomerTierId,
                    ValueType = typeof(Guid)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Customer Type Id",
                    Value = customerOverviewCustomerTypeId,
                    ValueType = typeof(Guid)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Email Address",
                    Value = customerOverviewEmailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Customer Overview: Existing Global Parent Customer Id",
                    Value = customerOverviewExistingGlobalParentCustomerId,
                    ValueType = typeof(Guid)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Customer Overview: Existing Top Parent Customer Id",
                    Value = customerOverviewExistingTopParentCustomerId,
                    ValueType = typeof(Guid)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: First Name",
                    Value = customerOverviewFirstName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Custome Overview: Last Name",
                    Value = customerOverviewLastName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Sales Sub Region Id",
                    Value = customerOverviewSalesSubRegionId,
                    ValueType = typeof(Guid)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Telephone Number",
                    Value = customerOverviewTelephoneNumber,
                    MaxLength = 13,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Will Be Global Parent",
                    Value = customerOverviewWillBeGlobalParent,
                    ValueType = typeof(bool)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Will Be Top Parent",
                    Value = customerOverviewWillBeTopParent,
                    ValueType = typeof(bool)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Overview: Telephone Number",
                    Value = customerOverviewTelephoneNumber,
                    MaxLength = 13,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Shipping Information: Address Line 1",
                    Value = customerShippingInformationAddressLine1,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Customer Shipping Information: Address Line 2",
                    Value = customerShippingInformationAddressLine2,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Shipping Information: Address Line 3",
                    Value = customerShippingInformationAddressLine3,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Shipping Information: Address Line 4",
                    Value = customerShippingInformationAddressLine4,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Shipping Information: Address Line 5",
                    Value = customerShippingInformationAddressLine5,
                    ValueType = typeof(Guid)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Customer Shipping Information: Company Name",
                    Value = customerShippingInformationCompanyName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Shipping Information: Email Address",
                    Value = customerShippingInformationEmailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Shipping Information: First Name",
                    Value = customerShippingInformationFirstName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Shipping Information: Last Name",
                    Value = customerShippingInformationLastName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new DataValidationService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Customer Shipping Information: Telephone Number",
                    Value = customerShippingInformationTelephoneNumber,
                    MaxLength = 13,
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
                        ParameterName = "creditEnabled",
                        ParameterValue = customerFinanceCreditEnabled
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "creditLimit",
                        ParameterValue = customerFinanceCreditLimit
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "companyConfigurationId",
                        ParameterValue = _companyConfigurationId
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

                if (!string.IsNullOrEmpty(customerFinanceVATNumber))
                {
                    parameters.Add(new StoredProcedureParameter
                    {
                        ParameterName = "vatNumber",
                        ParameterValue = customerFinanceVATNumber
                    });
                }

                string storedProcedureName = "spCreateCustomer";
                string operationType = "Create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(_databaseConnectionSettings, storedProcedureName, parameters.ToArray(), dataSubject, operationType);
                this.Close();
            }
        }  
    }
}