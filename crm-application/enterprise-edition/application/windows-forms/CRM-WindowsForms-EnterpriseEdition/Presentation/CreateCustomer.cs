using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateCustomer : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreateCustomer()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadDatabaseConnectionSettingsAsync();
            LoadInitialDataAsync();
        }

        private void InitializeCustomComponents()
        {
            createCustomerTabControlBillingInformationTabPageAddressLine1Textbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerTabControlBillingInformationTabPageAddressLine2Textbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerTabControlBillingInformationTabPageAddressLine3Textbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerTabControlBillingInformationTabPageAddressLine4Textbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerTabControlBillingInformationTabPageAddressLine5Textbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
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

        private async Task LoadInitialDataAsync()
        {
            await LoadDatabaseConnectionSettingsAsync();

            var loadCustomerTypeTask = CreateCustomerOverviewLoadCustomerTypeAsync();
            var loadCustomerTierTask = CreateCustomerOverviewLoadCustomerTierDataAsync();
            var loadSalesRegionTask = CreateCustomerOverviewLoadSalesRegionDataAsync();
            var loadSalesSubRegionTask = LoadSalesRegionAndSubRegionDataAsync();
            var loadAccountManagerTask = CreateCustomerOverviewLoadAccountManagerDataAsync();
            var loadCurrencyTask = CreateCustomerFinanceLoadCurrencyDataAsync();

            await Task.WhenAll(loadCustomerTypeTask, loadCustomerTierTask, loadSalesRegionTask, loadAccountManagerTask, loadCurrencyTask);

            if (createCustomerTabControlOverviewTabPageSalesRegionComboBox.SelectedValue is Guid selectedSalesRegionId)
            {
                await CreateCustomernLoadSalesSubRegionAsync(selectedSalesRegionId);
            }
        }

        private async Task CreateCustomerOverviewLoadCustomerTypeAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Customer Type";

            try
            {
                string storedProcedureName = "spGetAllCustomerType";    
                DataTable? customerTypeData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject);

                var customerTypeList = customerTypeData.AsEnumerable()
                    .Select(row => new
                    {
                        CustomerTypeId = row.Field<Guid>("Customer Type Id"),
                        CustomerType = row.Field<string>("Customer Type")
                    })
                    .OrderBy(item => item.CustomerType)
                    .ToList();
                createCustomerTabControlOverviewTabPageCustomerTypeComboBox.DataSource = customerTypeList;
                createCustomerTabControlOverviewTabPageCustomerTypeComboBox.DisplayMember = "CustomerType";
                createCustomerTabControlOverviewTabPageCustomerTypeComboBox.ValueMember = "CustomerTypeId";
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async Task CreateCustomerOverviewLoadCustomerTierDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "CustomerTier";

            try
            {
                string storedProcedureName = "spGetAllCustomerTier";
                DataTable? customerTierData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject);

                var customerTierList = customerTierData.AsEnumerable()
                    .Select(row => new
                    {
                        CustomerTierId = row.Field<Guid>("Customer Tier Id"),
                        CustomerTierCode = row.Field<string>("Customer Tier Code"),
                        CustomerTierDescription = row.Field<string>("Customer Tier Description"),
                        DisplayText = $"{row.Field<string>("Customer Tier Code")} - {row.Field<string>("Customer Tier Description")}"
                    })
                    .OrderBy(item => item.DisplayText)
                    .ToList();
                createCustomerTabControlOverviewTabPageCustomerTierComboBox.DataSource = customerTierList;
                createCustomerTabControlOverviewTabPageCustomerTierComboBox.DisplayMember = "DisplayText";
                createCustomerTabControlOverviewTabPageCustomerTierComboBox.ValueMember = "CustomerTierId";
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async Task CreateCustomerOverviewLoadSalesRegionDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Sales Region";

            try
            {
                string storedProcedureName = "spGetAllSalesRegion";               
                DataTable? salesRegionData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject);

                var salesRegionList = salesRegionData.AsEnumerable()
                    .Select(row => new
                    {
                        SalesRegionId = row.Field<Guid>("Sales Region Id"),
                        SalesRegion = row.Field<string>("Sales Region")
                    })
                    .OrderBy(item => item.SalesRegion)
                    .ToList();
                createCustomerTabControlOverviewTabPageSalesRegionComboBox.DataSource = salesRegionList;
                createCustomerTabControlOverviewTabPageSalesRegionComboBox.DisplayMember = "SalesRegion";
                createCustomerTabControlOverviewTabPageSalesRegionComboBox.ValueMember = "SalesRegionId";
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async Task CreateCustomernLoadSalesSubRegionAsync(Guid salesRegionId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Sales Sub Region";

            try
            {
                string storedProcedureName = "spGetAllSalesSubRegion";          
                DataTable? salesSubRegionData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject);

                var salesSubRegionList = salesSubRegionData.AsEnumerable()
                    .Where(row => row.Field<Guid>("Sales Region Id") == salesRegionId)
                    .Select(row => new
                    {
                        SalesRegionId = row.Field<Guid>("Sales Region Id"),
                        SalesSubRegionId = row.Field<Guid>("Sales Sub Region Id"),
                        SalesSubRegion = row.Field<string>("Sales Sub Region")
                    })
                    .OrderBy(item => item.SalesSubRegion)
                    .ToList();
                createCustomerTabControlOverviewTabPageSalesSubRegionComboBox.DataSource = salesSubRegionList;
                createCustomerTabControlOverviewTabPageSalesSubRegionComboBox.DisplayMember = "SalesSubRegion";
                createCustomerTabControlOverviewTabPageSalesSubRegionComboBox.ValueMember = "SalesSubRegionId";
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async Task LoadSalesRegionAndSubRegionDataAsync()
        {
            await CreateCustomerOverviewLoadSalesRegionDataAsync();
            if (createCustomerTabControlOverviewTabPageSalesRegionComboBox.SelectedValue is Guid selectedSalesRegionId)
            {
                await CreateCustomernLoadSalesSubRegionAsync(selectedSalesRegionId);
            }
        }

        private async void CreateCustomerOverviewSalesRegionComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (createCustomerTabControlOverviewTabPageSalesRegionComboBox.SelectedValue is Guid selectedSalesRegionId)
            {
                await CreateCustomernLoadSalesSubRegionAsync(selectedSalesRegionId);
            }
        }

        private async Task CreateCustomerOverviewLoadAccountManagerDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Account Manager";

            try
            {
                string storedProcedureName = "spGetAllAccountManager";
                
                DataTable? accountManagerData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject);

                var accountManagerList = accountManagerData.AsEnumerable()
                    .Select(row => new
                    {
                        AccountManagerId = row.Field<Guid>("Account Manager Id"),
                        AccountManagerFirstName = row.Field<string>("First Name"),
                        AccountManagerLastName = row.Field<string>("Last Name"),
                        AccountManagerEmailAddress = row.Field<string>("Email Address"),
                        DisplayText = $"{row.Field<string>("Last Name")}, {row.Field<string>("First Name")} | {row.Field<string>("Email Address")}"
                    })
                    .OrderBy(item => item.DisplayText)
                    .ToList();
                createCustomerTabControlOverviewTabPageAccountManagerComboBox.DataSource = accountManagerList;
                createCustomerTabControlOverviewTabPageAccountManagerComboBox.DisplayMember = "DisplayText";
                createCustomerTabControlOverviewTabPageAccountManagerComboBox.ValueMember = "AccountManagerId";
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
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
                await CreateCustomerOverviewLoadGlobalParentCustomerDataAsync();
                createCustomerTabControlOverviewTabPageGlobalParentCustomerComboBox.Enabled = true;
                createCustomerTabControlOverviewTabPageTopParentCustomerComboBox.Enabled = false;
                createCustomerTabControlOverviewTabPageTopParentCustomerComboBox.DataSource = null;
                createCustomerTabControlOverviewTabPageTopParentCustomerComboBox.Items.Clear();

            }
            else if (createCustomerTabControlOverviewTabPageExistingParentCompanyTypePanelTopParentRadioButton.Checked)
            {
                await CreateCustomerOverviewLoadTopParentCustomerDataAsync();
                createCustomerTabControlOverviewTabPageTopParentCustomerComboBox.Enabled = true;
                createCustomerTabControlOverviewTabPageGlobalParentCustomerComboBox.Enabled = false;
                createCustomerTabControlOverviewTabPageGlobalParentCustomerComboBox.DataSource = null;
                createCustomerTabControlOverviewTabPageGlobalParentCustomerComboBox.Items.Clear();
            }
        }

        private async Task CreateCustomerOverviewLoadGlobalParentCustomerDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Global Parent Customer";

            try
            {
                string storedProcedureName = "spGetAllGlobalParentCustomer";                
                DataTable? globalParentCustomerData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject);

                var globalParentCustomerList = globalParentCustomerData.AsEnumerable()
                    .Select(row => new
                    {
                        CustomerId = row.Field<Guid>("Customer Id"),
                        CustomerCompanyName = row.Field<string>("Company Name"),
                        DisplayText = $"{row.Field<string>("Customer Id")} | {row.Field<string>("Company Name")}"
                    })
                    .OrderBy(item => item.DisplayText)
                    .ToList();
                createCustomerTabControlOverviewTabPageGlobalParentCustomerComboBox.DataSource = globalParentCustomerList;
                createCustomerTabControlOverviewTabPageGlobalParentCustomerComboBox.DisplayMember = "DisplayText";
                createCustomerTabControlOverviewTabPageGlobalParentCustomerComboBox.ValueMember = "CustomerId";
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async Task CreateCustomerOverviewLoadTopParentCustomerDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Top Parent Customer";

            try
            {
                string storedProcedureName = "spGetAllTopParentCustomer";               
                DataTable? topParentCustomerData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject);

                var topParentCustomerList = topParentCustomerData.AsEnumerable()
                    .Select(row => new
                    {
                        CustomerId = row.Field<Guid>("Customer Id"),
                        CustomerCompanyName = row.Field<string>("Company Name"),
                        DisplayText = $"{row.Field<string>("Customer Id")} | {row.Field<string>("Company Name")}"
                    })
                    .OrderBy(item => item.DisplayText)
                    .ToList();
                createCustomerTabControlOverviewTabPageTopParentCustomerComboBox.DataSource = topParentCustomerList;
                createCustomerTabControlOverviewTabPageTopParentCustomerComboBox.DisplayMember = "DisplayText";
                createCustomerTabControlOverviewTabPageTopParentCustomerComboBox.ValueMember = "CustomerId";
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
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
            createCustomerTabControlShippingInformationTabPageAddressLine5Textbox.Text = createCustomerTabControlBillingInformationTabPageAddressLine5Textbox.Text;
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

        private async Task CreateCustomerFinanceLoadCurrencyDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Currency";

            try
            {
                string storedProcedureName = "spGetAllCurrency";
                
                DataTable? currencyData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject);
                var currencyList = currencyData.AsEnumerable()
                    .Select(row => new
                    {
                        CurrencyId = row.Field<Guid>("Currency Id"),
                        CurrencyCode = row.Field<string>("Currency Code"),
                        CurrencyName = row.Field<string>("Currency Name"),
                        DisplayText = $"{row.Field<string>("Currency Code")} - {row.Field<string>("Currency Name")}"
                    })
                    .OrderBy(item => item.DisplayText)
                    .ToList();

                createCustomerTabControlFinanceTabPagePaymentCurrencyComboBox.DataSource = currencyList;
                createCustomerTabControlFinanceTabPagePaymentCurrencyComboBox.DisplayMember = "DisplayText";
                createCustomerTabControlFinanceTabPagePaymentCurrencyComboBox.ValueMember = "CurrencyId";
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async void createCustomerSubmitButton_Click(object sender, EventArgs e)
        {
            string customerBillingInformationAddressLine1 = createCustomerTabControlBillingInformationTabPageAddressLine1Textbox.Text.TrimEnd();
            string? customerBillingInformationAddressLine2 = createCustomerTabControlBillingInformationTabPageAddressLine2Textbox.Text.TrimEnd();
            string customerBillingInformationAddressLine3 = createCustomerTabControlBillingInformationTabPageAddressLine3Textbox.Text.TrimEnd();
            string customerBillingInformationAddressLine4 = createCustomerTabControlBillingInformationTabPageAddressLine4Textbox.Text.TrimEnd();
            string customerBillingInformationAddressLine5 = createCustomerTabControlBillingInformationTabPageAddressLine5Textbox.Text.TrimEnd();
            string? customerBillingInformationCompanyName = createCustomerTabControlBillingInformationTabPageCompanyNameTextbox.Text.TrimEnd();
            string customerBillingInformationEmailAddress = createCustomerTabControlBillingInformationTabPageEmailAddressTextbox.Text.TrimEnd();
            string customerBillingInformationFirstName = createCustomerTabControlBillingInformationTabPageFirstNameTextbox.Text.TrimEnd();
            string customerBillingInformationLastName = createCustomerTabControlBillingInformationTabPageLastNameTextbox.Text.TrimEnd();
            string customerBillingInformationTelephoneNumber = createCustomerTabControlBillingInformationTabPageTelephoneNumberTextbox.Text.TrimEnd();
            bool customerFinanceCreditEnabled = createCustomerTabControlFinanceTabPageCreditEnabledCheckbox.Checked;
            if(!customerFinanceCreditEnabled)
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
            string customerShippingInformationAddressLine5 = createCustomerTabControlShippingInformationTabPageAddressLine5Textbox.Text.TrimEnd();
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

            var dataToValidate = new List<ValidateDataInput.DataProperty>
            {
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerBillingInformationAddressLine1",
                    Value = customerBillingInformationAddressLine1,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerBillingInformationAddressLine3",
                    Value = customerBillingInformationAddressLine3,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerBillingInformationAddressLine4",
                    Value = customerBillingInformationAddressLine4,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerBillingInformationAddressLine5",
                    Value = customerBillingInformationAddressLine5,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerBillingInformationEmailAddress",
                    Value = customerBillingInformationEmailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerBillingInformationFirstName",
                    Value = customerBillingInformationFirstName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerBillingInformationLastName",
                    Value = customerBillingInformationLastName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerBillingInformationTelephoneNumber",
                    Value = customerBillingInformationTelephoneNumber,
                    MaxLength = 13,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerFinanceCreditEnabled",
                    Value = customerFinanceCreditEnabled,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerFinanceCreditLimit",
                    Value = customerFinanceCreditLimit,
                    ValueType = typeof(decimal)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerFinancePaymentCurrencyId",
                    Value = customerFinancePaymentCurrencyId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerFinancePaymentDays",
                    Value = customerFinancePaymentDays,
                    ValueType = typeof(byte)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerOverviewAccountManagerId",
                    Value = customerOverviewAccountManagerId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerOverviewActiveStatus",
                    Value = customerOverviewActiveStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerOverviewCustomerSince",
                    Value = customerOverviewCustomerSince,
                    ValueType = typeof(DateTime)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerOverviewCustomerTierId",
                    Value = customerOverviewCustomerTierId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerOverviewCustomerTypeId",
                    Value = customerOverviewCustomerTypeId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerOverviewEmailAddress",
                    Value = customerOverviewEmailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerOverviewFirstName",
                    Value = customerOverviewFirstName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerOverviewLastName",
                    Value = customerOverviewLastName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerOverviewSalesSubRegionId",
                    Value = customerOverviewSalesSubRegionId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerOverviewTelephoneNumber",
                    Value = customerOverviewTelephoneNumber,
                    MaxLength = 13,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerOverviewWillBeGlobalParent",
                    Value = customerOverviewWillBeGlobalParent,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerOverviewWillBeTopParent",
                    Value = customerOverviewWillBeTopParent,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerOverviewTelephoneNumber",
                    Value = customerOverviewTelephoneNumber,
                    MaxLength = 13,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerShippingInformationAddressLine1",
                    Value = customerShippingInformationAddressLine1,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerShippingInformationAddressLine3",
                    Value = customerShippingInformationAddressLine3,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerShippingInformationAddressLine4",
                    Value = customerShippingInformationAddressLine4,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerShippingInformationAddressLine5",
                    Value = customerShippingInformationAddressLine5,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerShippingInformationEmailAddress",
                    Value = customerShippingInformationEmailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerShippingInformationFirstName",
                    Value = customerShippingInformationFirstName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerShippingInformationLastName",
                    Value = customerShippingInformationLastName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CustomerShippingInformationTelephoneNumber",
                    Value = customerShippingInformationTelephoneNumber,
                    MaxLength = 13,
                    ValueType = typeof(string)
                }
            };

            if (!string.IsNullOrEmpty(customerBillingInformationAddressLine2))
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "CustomerBillingInformationAddressLine2",
                    Value = customerBillingInformationAddressLine2,
                    MaxLength = 50,
                    ValueType = typeof(string)
                });
            }

            if (!string.IsNullOrEmpty(customerBillingInformationCompanyName))
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "CustomerBillingInformationCompanyName",
                    Value = customerBillingInformationCompanyName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                });
            }

            if (!string.IsNullOrEmpty(customerFinanceVATNumber))
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "CompanyFinanceVATNumber",
                    Value = customerFinanceVATNumber,
                    MaxLength = 50,
                    ValueType = typeof(string)
                });
            }

            if (!string.IsNullOrEmpty(customerOverviewCompanyName))
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "CustomerOverviewCompanyName",
                    Value = customerOverviewCompanyName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                });
            }

            if (customerOverviewExistingGlobalParentCustomerId != null && customerOverviewExistingGlobalParentCustomerId != Guid.Empty)
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "CustomerOverviewExistingGlobalParentCustomerId",
                    Value = customerOverviewExistingGlobalParentCustomerId,
                    ValueType = typeof(Guid)
                });
            }

            if (customerOverviewExistingTopParentCustomerId != null && customerOverviewExistingTopParentCustomerId != Guid.Empty)
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "CustomerOverviewExistingTopParentCustomerId",
                    Value = customerOverviewExistingTopParentCustomerId,
                    ValueType = typeof(Guid)
                });
            }

            if (!string.IsNullOrEmpty(customerShippingInformationAddressLine2))
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "CustomerShippingInformationAddressLine2",
                    Value = customerShippingInformationAddressLine2,
                    MaxLength = 50,
                    ValueType = typeof(string)
                });
            }

            if (!string.IsNullOrEmpty(customerShippingInformationCompanyName))
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "CustomerShippingInformationCompanyName",
                    Value = customerShippingInformationCompanyName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                });
            }

            dataToValidate = dataToValidate.OrderBy(change => change.Name).ToList();

            var validationResult = ValidateDataInput.ValidateInput(dataToValidate);

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
    }
}