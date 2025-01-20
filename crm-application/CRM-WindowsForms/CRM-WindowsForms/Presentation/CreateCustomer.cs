using CRM_WindowsForms.Model;
using CRM_WindowsForms.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms.Presentation
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
            createCustomerOverviewCustomerTypeComboBox.DropDown += new EventHandler(CreateCustomerOverviewCustomerTypeComboBox_DropDown);
            createCustomerOverviewCustomerTierComboBox.DropDown += new EventHandler(CreateCustomerOverviewCustomerTierComboBox_DropDown);
            createCustomerOverviewAccountManagerComboBox.DropDown += new EventHandler(CreateCustomerOverviewAccountManagerComboBox_DropDown);
            createCustomerOverviewSalesRegionComboBox.DropDown += new EventHandler(CreateCustomerOverviewSalesRegionComboBox_DropDown);
            createCustomerOverviewSalesRegionComboBox.SelectedIndexChanged += new EventHandler(CreateCustomerOverviewSalesRegionComboBox_SelectedIndexChanged);
            createCustomerOverviewExistingCustomerIsParentNoRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewExistingParentCustomerRadioButton_CheckedChanged);
            createCustomerOverviewExistingCustomerIsParentYesRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewExistingParentCustomerRadioButton_CheckedChanged);
            createCustomerOverviewExistingParentCompanyTypeGlobalParentRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewExistingParentCompanyType_CheckedChanged);
            createCustomerOverviewExistingParentCompanyTypeGlobalParentRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewRadioButtonValidation_CheckedChanged);
            createCustomerOverviewExistingParentCompanyTypeTopParentRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewExistingParentCompanyType_CheckedChanged);
            createCustomerOverviewWillBeParentInCustomerHierarchyNoRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewRadioButtonValidation_CheckedChanged);
            createCustomerOverviewWillBeParentInCustomerHierarchyYesRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewRadioButtonValidation_CheckedChanged);
            createCustomerOverviewWillBeGlobalParentRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewRadioButtonValidation_CheckedChanged);
            createCustomerOverviewWillBeTopParentRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewRadioButtonValidation_CheckedChanged);
            createCustomerOverviewExistingParentCompanyTypeTopParentRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewRadioButtonValidation_CheckedChanged);
            createCustomerFinanceCreditEnabledCheckbox.CheckedChanged += new EventHandler(CreateCustomerFinanceCreditEnabledCheckBox_CheckedChanged);
            createCustomerFinancePaymentCurrencyComboBox.DropDown += new EventHandler(CreateCustomerFinancePaymentCurrencyComboBox_DropDown);
            createCustomerFinanceVATRegisteredCheckbox.CheckedChanged += new EventHandler(CreateCustomerFinanceVATRegisteredCheckBox_CheckedChanged);

            createCustomerOverviewFirstNameTextbox.TextChanged += new EventHandler(AutoPopulateBillingInformation);
            createCustomerOverviewLastNameTextbox.TextChanged += new EventHandler(AutoPopulateBillingInformation);
            createCustomerOverviewCompanyNameTextbox.TextChanged += new EventHandler(AutoPopulateBillingInformation);
            createCustomerOverviewEmailAddressTextbox.TextChanged += new EventHandler(AutoPopulateBillingInformation);
            createCustomerOverviewTelephoneNumberTextbox.TextChanged += new EventHandler(AutoPopulateBillingInformation);

            createCustomerBillingInformationAddressLine1Textbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerBillingInformationAddressLine2Textbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerBillingInformationAddressLine3Textbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerBillingInformationAddressLine4Textbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerBillingInformationAddressLine5Textbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerBillingInformationCompanyNameTextbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerBillingInformationEmailAddressTextbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerBillingInformationFirstNameTextbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerBillingInformationLastNameTextbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
            createCustomerBillingInformationTelephoneNumberTextbox.TextChanged += new EventHandler(AutoPopulateShippingInformation);
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

            if (createCustomerOverviewSalesRegionComboBox.SelectedValue is Guid selectedSalesRegionId)
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
            try
            {
                string storedProcedureName = "[dbo].[spGetAllCustomerType]";
                string dataSubject = "Customer Type";
                DataTable? customerTypeData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var customerTypeList = customerTypeData.AsEnumerable()
                    .Select(row => new
                    {
                        CustomerTypeId = row.Field<Guid>("Customer Type Id"),
                        CustomerType = row.Field<string>("Customer Type")
                    })
                    .OrderBy(item => item.CustomerType)
                    .ToList();
                createCustomerOverviewCustomerTypeComboBox.DataSource = customerTypeList;
                createCustomerOverviewCustomerTypeComboBox.DisplayMember = "CustomerType";
                createCustomerOverviewCustomerTypeComboBox.ValueMember = "CustomerTypeId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Customer Type data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateCustomerOverviewCustomerTypeComboBox_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async Task CreateCustomerOverviewLoadCustomerTierDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                string storedProcedureName = "[dbo].[spGetAllCustomerTier]";
                string dataSubject = "CustomerTier";
                DataTable? customerTierData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

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
                createCustomerOverviewCustomerTierComboBox.DataSource = customerTierList;
                createCustomerOverviewCustomerTierComboBox.DisplayMember = "DisplayText";
                createCustomerOverviewCustomerTierComboBox.ValueMember = "CustomerTierId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Customer Tier data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateCustomerOverviewCustomerTierComboBox_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async Task CreateCustomerOverviewLoadSalesRegionDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                string storedProcedureName = "[dbo].[spGetAllSalesRegion]";
                string dataSubject = "Sales Region";
                DataTable? salesRegionData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var salesRegionList = salesRegionData.AsEnumerable()
                    .Select(row => new
                    {
                        SalesRegionId = row.Field<Guid>("Sales Region Id"),
                        SalesRegion = row.Field<string>("Sales Region")
                    })
                    .OrderBy(item => item.SalesRegion)
                    .ToList();
                createCustomerOverviewSalesRegionComboBox.DataSource = salesRegionList;
                createCustomerOverviewSalesRegionComboBox.DisplayMember = "SalesRegion";
                createCustomerOverviewSalesRegionComboBox.ValueMember = "SalesRegionId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Sales Region data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CreateCustomerOverviewSalesRegionComboBox_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
            await CreateCustomernLoadSalesSubRegionAsync((Guid)createCustomerOverviewSalesRegionComboBox.SelectedValue);
        }

        private async Task CreateCustomernLoadSalesSubRegionAsync(Guid salesRegionId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                string storedProcedureName = "[dbo].[spGetAllSalesSubRegion]";
                string dataSubject = "Sales Sub Region";
                DataTable? salesSubRegionData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

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
                createCustomerOverviewSalesSubRegionComboBox.DataSource = salesSubRegionList;
                createCustomerOverviewSalesSubRegionComboBox.DisplayMember = "SalesSubRegion";
                createCustomerOverviewSalesSubRegionComboBox.ValueMember = "SalesSubRegionId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Sales Sub Region data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadSalesRegionAndSubRegionDataAsync()
        {
            await CreateCustomerOverviewLoadSalesRegionDataAsync();
            if (createCustomerOverviewSalesRegionComboBox.SelectedValue is Guid selectedSalesRegionId)
            {
                await CreateCustomernLoadSalesSubRegionAsync(selectedSalesRegionId);
            }
        }

        private async void CreateCustomerOverviewSalesRegionComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (createCustomerOverviewSalesRegionComboBox.SelectedValue is Guid selectedSalesRegionId)
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
            try
            {
                string storedProcedureName = "[dbo].[spGetAllAccountManager]";
                string dataSubject = "Account Manager";
                DataTable? accountManagerData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

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
                createCustomerOverviewAccountManagerComboBox.DataSource = accountManagerList;
                createCustomerOverviewAccountManagerComboBox.DisplayMember = "DisplayText";
                createCustomerOverviewAccountManagerComboBox.ValueMember = "AccountManagerId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Account Manager data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateCustomerOverviewAccountManagerComboBox_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private void CreateCustomerOverviewExistingParentCustomerRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCustomerOverviewExistingCustomerIsParentNoRadioButton.Checked)
            {
                createCustomerOverviewExistingParentCompanyTypeGlobalParentRadioButton.Enabled = false;
                createCustomerOverviewExistingParentCompanyTypeTopParentRadioButton.Enabled = false;
                createCustomerOverviewExistingParentCompanyTypeGlobalParentRadioButton.Checked = false;
                createCustomerOverviewExistingParentCompanyTypeTopParentRadioButton.Checked = false;
                createCustomerOverviewGlobalParentCustomerComboBox.Enabled = false;
                createCustomerOverviewGlobalParentCustomerComboBox.DataSource = null;
                createCustomerOverviewGlobalParentCustomerComboBox.Items.Clear();
                createCustomerOverviewTopParentCustomerComboBox.Enabled = false;
                createCustomerOverviewTopParentCustomerComboBox.DataSource = null;
                createCustomerOverviewTopParentCustomerComboBox.Items.Clear();
            }
            else if (createCustomerOverviewExistingCustomerIsParentYesRadioButton.Checked)
            {
                createCustomerOverviewExistingParentCompanyTypeGlobalParentRadioButton.Enabled = true;
                createCustomerOverviewExistingParentCompanyTypeTopParentRadioButton.Enabled = true;
            }
        }

        private async void CreateCustomerOverviewExistingParentCompanyType_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCustomerOverviewExistingParentCompanyTypeGlobalParentRadioButton.Checked)
            {
                await CreateCustomerOverviewLoadGlobalParentCustomerDataAsync();
                createCustomerOverviewGlobalParentCustomerComboBox.Enabled = true;
                createCustomerOverviewTopParentCustomerComboBox.Enabled = false;
                createCustomerOverviewTopParentCustomerComboBox.DataSource = null;
                createCustomerOverviewTopParentCustomerComboBox.Items.Clear();

            }
            else if (createCustomerOverviewExistingParentCompanyTypeTopParentRadioButton.Checked)
            {
                await CreateCustomerOverviewLoadTopParentCustomerDataAsync();
                createCustomerOverviewTopParentCustomerComboBox.Enabled = true;
                createCustomerOverviewGlobalParentCustomerComboBox.Enabled = false;
                createCustomerOverviewGlobalParentCustomerComboBox.DataSource = null;
                createCustomerOverviewGlobalParentCustomerComboBox.Items.Clear();
            }
        }

        private async Task CreateCustomerOverviewLoadGlobalParentCustomerDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                string storedProcedureName = "[dbo].[spGetAllGlobalParentCustomer]";
                string dataSubject = "Global Parent Customer";
                DataTable? globalParentCustomerData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var globalParentCustomerList = globalParentCustomerData.AsEnumerable()
                    .Select(row => new
                    {
                        CustomerId = row.Field<Guid>("Customer Id"),
                        CustomerCompanyName = row.Field<string>("Company Name"),
                        DisplayText = $"{row.Field<string>("Customer Id")} | {row.Field<string>("Company Name")}"
                    })
                    .OrderBy(item => item.DisplayText)
                    .ToList();
                createCustomerOverviewGlobalParentCustomerComboBox.DataSource = globalParentCustomerList;
                createCustomerOverviewGlobalParentCustomerComboBox.DisplayMember = "DisplayText";
                createCustomerOverviewGlobalParentCustomerComboBox.ValueMember = "CustomerId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Global Parent Customer data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateCustomerOverviewGlobalParentCustomerComboBox_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async Task CreateCustomerOverviewLoadTopParentCustomerDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                string storedProcedureName = "[dbo].[spGetAllTopParentCustomer]";
                string dataSubject = "Top Parent Customer";
                DataTable? topParentCustomerData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var topParentCustomerList = topParentCustomerData.AsEnumerable()
                    .Select(row => new
                    {
                        CustomerId = row.Field<Guid>("Customer Id"),
                        CustomerCompanyName = row.Field<string>("Company Name"),
                        DisplayText = $"{row.Field<string>("Customer Id")} | {row.Field<string>("Company Name")}"
                    })
                    .OrderBy(item => item.DisplayText)
                    .ToList();
                createCustomerOverviewTopParentCustomerComboBox.DataSource = topParentCustomerList;
                createCustomerOverviewTopParentCustomerComboBox.DisplayMember = "DisplayText";
                createCustomerOverviewTopParentCustomerComboBox.ValueMember = "CustomerId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Top Parent Customer data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateCustomerOverviewTopParentCustomerComboBox_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private void CreateCustomerOverviewRadioButtonValidation_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCustomerOverviewExistingParentCompanyTypeTopParentRadioButton.Checked)
            {
                createCustomerOverviewWillBeParentInCustomerHierarchyYesRadioButton.Enabled = false;
                createCustomerOverviewWillBeParentInCustomerHierarchyNoRadioButton.Enabled = false;
                createCustomerOverviewWillBeParentInCustomerHierarchyYesRadioButton.Checked = false;
                createCustomerOverviewWillBeParentInCustomerHierarchyNoRadioButton.Checked = false;
                createCustomerOverviewWillBeGlobalParentRadioButton.Checked = false;
                createCustomerOverviewWillBeGlobalParentRadioButton.Enabled = false;
                createCustomerOverviewWillBeTopParentRadioButton.Checked = false;
                createCustomerOverviewWillBeTopParentRadioButton.Enabled = false;

            }
            else if (createCustomerOverviewExistingParentCompanyTypeTopParentRadioButton.Checked && createCustomerOverviewWillBeTopParentRadioButton.Checked)
            {
                MessageBox.Show("Cannot select 'Top Parent Parent' as new customer parent type when existing Parent Company Type is 'Top Parent'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                createCustomerOverviewWillBeTopParentRadioButton.Checked = false;
                createCustomerOverviewWillBeTopParentRadioButton.Enabled = false;
                createCustomerOverviewWillBeGlobalParentRadioButton.Checked = false;
                createCustomerOverviewWillBeGlobalParentRadioButton.Enabled = false;
            }


            if (createCustomerOverviewWillBeGlobalParentRadioButton.Checked)
            {
                var selectedCustomerType = createCustomerOverviewCustomerTypeComboBox.Text;
                if (selectedCustomerType != "Business - Multinational")
                {
                    MessageBox.Show("The 'Global Parent' option can only be selected for a new customer if 'Business - Multinational' is selected in the Customer Type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    createCustomerOverviewWillBeGlobalParentRadioButton.Checked = false;
                }
            }
            else if (createCustomerOverviewWillBeGlobalParentRadioButton.Checked && createCustomerOverviewExistingParentCompanyTypeGlobalParentRadioButton.Checked)
            {
                MessageBox.Show("Cannot select 'Global Parent' as new customer parent tyoe when existing Parent Company Type is 'Global Parent'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                createCustomerOverviewWillBeGlobalParentRadioButton.Checked = false;
                createCustomerOverviewWillBeGlobalParentRadioButton.Enabled = false;
            }

            if (createCustomerOverviewExistingParentCompanyTypeGlobalParentRadioButton.Checked)
            {
                var selectedCustomerType = createCustomerOverviewCustomerTypeComboBox.Text;
                if (selectedCustomerType != "Business - Multinational")
                {
                    MessageBox.Show("'Business - Multinational' is can only be selected as the Customer Type if the parent customer is Global Parent.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    createCustomerOverviewWillBeGlobalParentRadioButton.Checked = false;
                    createCustomerOverviewExistingParentCompanyTypeGlobalParentRadioButton.Checked = false;
                }
            }

            if (createCustomerOverviewWillBeParentInCustomerHierarchyNoRadioButton.Checked)
            {
                createCustomerOverviewWillBeGlobalParentRadioButton.Enabled = false;
                createCustomerOverviewWillBeTopParentRadioButton.Enabled = false;
                createCustomerOverviewWillBeGlobalParentRadioButton.Checked = false;
                createCustomerOverviewWillBeTopParentRadioButton.Checked = false;
            }
            else if (createCustomerOverviewWillBeParentInCustomerHierarchyYesRadioButton.Checked)
            {
                createCustomerOverviewWillBeGlobalParentRadioButton.Enabled = true;
                createCustomerOverviewWillBeTopParentRadioButton.Enabled = true;
            }

            if (createCustomerOverviewExistingCustomerIsParentNoRadioButton.Checked)
            {
                createCustomerOverviewWillBeParentInCustomerHierarchyNoRadioButton.Enabled = true;
                createCustomerOverviewWillBeParentInCustomerHierarchyYesRadioButton.Enabled = true;
            }
        }

        private void AutoPopulateBillingInformation(object? sender, EventArgs e)
        {
            createCustomerBillingInformationFirstNameTextbox.Text = createCustomerOverviewFirstNameTextbox.Text;
            createCustomerBillingInformationLastNameTextbox.Text = createCustomerOverviewLastNameTextbox.Text;
            createCustomerBillingInformationCompanyNameTextbox.Text = createCustomerOverviewCompanyNameTextbox.Text;
            createCustomerBillingInformationEmailAddressTextbox.Text = createCustomerOverviewEmailAddressTextbox.Text;
            createCustomerBillingInformationTelephoneNumberTextbox.Text = createCustomerOverviewTelephoneNumberTextbox.Text;
        }

        private void AutoPopulateShippingInformation(object? sender, EventArgs e)
        {
            createCustomerShippingInformationAddressLine1Textbox.Text = createCustomerBillingInformationAddressLine1Textbox.Text;
            createCustomerShippingInformationAddressLine2Textbox.Text = createCustomerBillingInformationAddressLine2Textbox.Text;
            createCustomerShippingInformationAddressLine3Textbox.Text = createCustomerBillingInformationAddressLine3Textbox.Text;
            createCustomerShippingInformationAddressLine4Textbox.Text = createCustomerBillingInformationAddressLine4Textbox.Text;
            createCustomerShippingInformationAddressLine5Textbox.Text = createCustomerBillingInformationAddressLine5Textbox.Text;
            createCustomerShippingInformationCompanyNameTextbox.Text = createCustomerBillingInformationCompanyNameTextbox.Text;
            createCustomerShippingInformationEmailAddressTextbox.Text = createCustomerBillingInformationEmailAddressTextbox.Text;
            createCustomerShippingInformationFirstNameTextbox.Text = createCustomerBillingInformationFirstNameTextbox.Text;
            createCustomerShippingInformationLastNameTextbox.Text = createCustomerBillingInformationLastNameTextbox.Text;
            createCustomerShippingInformationTelephoneNumberTextbox.Text = createCustomerBillingInformationTelephoneNumberTextbox.Text;
        }

        private void CreateCustomerFinanceCreditEnabledCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCustomerFinanceCreditEnabledCheckbox.Checked)
            {
                createCustomerFinanceCreditLimitTextboxA.Enabled = true;
                createCustomerFinanceCreditLimitTextboxB.Enabled = true;
            }
            else
            {
                createCustomerFinanceCreditLimitTextboxA.Enabled = false;
                createCustomerFinanceCreditLimitTextboxB.Enabled = false;
            }
        }

        private void CreateCustomerFinanceVATRegisteredCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCustomerFinanceVATRegisteredCheckbox.Checked)
            {
                createCustomerFinanceVATNumberTextbox.Enabled = true;
            }
            else
            {
                createCustomerFinanceVATNumberTextbox.Enabled = false;
                createCustomerFinanceVATNumberTextbox.Text = string.Empty;
            }
        }

        private async Task CreateCustomerFinanceLoadCurrencyDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            try
            {
                string storedProcedureName = "[dbo].[spGetAllCurrency]";
                string dataSubject = "Currency";
                DataTable? currencyData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

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

                createCustomerFinancePaymentCurrencyComboBox.DataSource = currencyList;
                createCustomerFinancePaymentCurrencyComboBox.DisplayMember = "DisplayText";
                createCustomerFinancePaymentCurrencyComboBox.ValueMember = "CurrencyId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Currency data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateCustomerFinancePaymentCurrencyComboBox_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void createCustomerSubmitButton_Click(object sender, EventArgs e)
        {
            Guid customerOverviewAccountManagerId = Guid.Parse(createCustomerOverviewAccountManagerComboBox.SelectedValue.ToString());
            bool customerOverviewActiveStatus = createCustomerOverviewActiveStatusCheckbox.Checked;
            string? customerOverviewCompanyName = createCustomerOverviewCompanyNameTextbox.Text.TrimEnd();
            DateTime customerOverviewCustomerSince = createCustomerOverviewCustomerSinceDatePicker.Value;
            Guid customerOverviewCustomerTierId = Guid.Parse(createCustomerOverviewCustomerTierComboBox.SelectedValue.ToString());
            Guid customerOverviewCustomerTypeId = Guid.Parse(createCustomerOverviewCustomerTypeComboBox.SelectedValue.ToString());
            string customerOverviewEmailAddress = createCustomerOverviewEmailAddressTextbox.Text.TrimEnd();
            Guid? customerOverviewExistingGlobalParentCustomerId = null;
            if (createCustomerOverviewGlobalParentCustomerComboBox.SelectedValue != null)
            {
                customerOverviewExistingGlobalParentCustomerId = Guid.Parse(createCustomerOverviewGlobalParentCustomerComboBox.SelectedValue.ToString());
            }
            Guid? customerOverviewExistingTopParentCustomerId = null;
            if (createCustomerOverviewTopParentCustomerComboBox.SelectedValue != null)
            {
                customerOverviewExistingTopParentCustomerId = Guid.Parse(createCustomerOverviewTopParentCustomerComboBox.SelectedValue.ToString());
            }
            string customerOverviewFirstName = createCustomerOverviewFirstNameTextbox.Text.TrimEnd();
            string customerOverviewLastName = createCustomerOverviewLastNameTextbox.Text.TrimEnd();
            Guid customerOverviewSalesSubRegionId = Guid.Parse(createCustomerOverviewSalesSubRegionComboBox.SelectedValue.ToString());
            string customerOverviewTelephoneNumber = createCustomerOverviewTelephoneNumberTextbox.Text.TrimEnd();
            bool customerOverviewWillBeGlobalParent = createCustomerOverviewWillBeGlobalParentRadioButton.Checked;
            bool customerOverviewWillBeTopParent = createCustomerOverviewWillBeTopParentRadioButton.Checked;

            string customerBillingInformationAddressLine1 = createCustomerBillingInformationAddressLine1Textbox.Text.TrimEnd();
            string? customerBillingInformationAddressLine2 = createCustomerBillingInformationAddressLine2Textbox.Text.TrimEnd();
            string customerBillingInformationAddressLine3 = createCustomerBillingInformationAddressLine3Textbox.Text.TrimEnd();
            string customerBillingInformationAddressLine4 = createCustomerBillingInformationAddressLine4Textbox.Text.TrimEnd();
            string customerBillingInformationAddressLine5 = createCustomerBillingInformationAddressLine5Textbox.Text.TrimEnd();
            string? customerBillingInformationCompanyName = createCustomerBillingInformationCompanyNameTextbox.Text.TrimEnd();
            string customerBillingInformationEmailAddress = createCustomerBillingInformationEmailAddressTextbox.Text.TrimEnd();
            string customerBillingInformationFirstName = createCustomerBillingInformationFirstNameTextbox.Text.TrimEnd();
            string customerBillingInformationLastName = createCustomerBillingInformationLastNameTextbox.Text.TrimEnd();
            string customerBillingInformationTelephoneNumber = createCustomerBillingInformationTelephoneNumberTextbox.Text.TrimEnd();

            string customerShippingInformationAddressLine1 = createCustomerShippingInformationAddressLine1Textbox.Text.TrimEnd();
            string? customerShippingInformationAddressLine2 = createCustomerShippingInformationAddressLine2Textbox.Text.TrimEnd();
            string customerShippingInformationAddressLine3 = createCustomerShippingInformationAddressLine3Textbox.Text.TrimEnd();
            string customerShippingInformationAddressLine4 = createCustomerShippingInformationAddressLine4Textbox.Text.TrimEnd();
            string customerShippingInformationAddressLine5 = createCustomerShippingInformationAddressLine5Textbox.Text.TrimEnd();
            string? customerShippingInformationCompanyName = createCustomerShippingInformationCompanyNameTextbox.Text.TrimEnd();
            string customerShippingInformationEmailAddress = createCustomerShippingInformationEmailAddressTextbox.Text.TrimEnd();
            string customerShippingInformationFirstName = createCustomerShippingInformationFirstNameTextbox.Text.TrimEnd();
            string customerShippingInformationLastName = createCustomerShippingInformationLastNameTextbox.Text.TrimEnd();
            string customerShippingInformationTelephoneNumber = createCustomerShippingInformationTelephoneNumberTextbox.Text.TrimEnd();

            bool customerFinanceCreditEnabled = createCustomerFinanceCreditEnabledCheckbox.Checked;
            decimal customerFinanceCreditLimit = decimal.Parse(createCustomerFinanceCreditLimitTextboxA.Text.TrimEnd()) + (decimal.Parse(createCustomerFinanceCreditLimitTextboxB.Text.TrimEnd()));
            Guid customerFinancePaymentCurrencyId = Guid.Parse(createCustomerFinancePaymentCurrencyComboBox.SelectedValue.ToString());
            byte customerFinancePaymentDays = byte.Parse(createCustomerFinancePaymentDaysTextbox.Text.TrimEnd());
            string? customerFinanceVATNumber = createCustomerFinanceVATNumberTextbox.Text.TrimEnd();

            string dataSubject = "Customer";

            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var stringsToValidate = new List<ValidateStringInput.StringProperty>
            {
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerOverviewEmailAddress",
                    Value = customerOverviewEmailAddress,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerOverviewFirstName",
                    Value = customerOverviewFirstName,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerOverviewLastName",
                    Value = customerOverviewLastName,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerOverviewTelephoneNumber",
                    Value = customerOverviewTelephoneNumber,
                    MaxLength = 13
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerBillingInformationAddressLine1",
                    Value = customerBillingInformationAddressLine1,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerBillingInformationAddressLine3",
                    Value = customerBillingInformationAddressLine3,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerBillingInformationAddressLine4",
                    Value = customerBillingInformationAddressLine4,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerBillingInformationAddressLine5",
                    Value = customerBillingInformationAddressLine5,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerBillingInformationEmailAddress",
                    Value = customerBillingInformationEmailAddress,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerBillingInformationFirstName",
                    Value = customerBillingInformationFirstName,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerBillingInformationLastName",
                    Value = customerBillingInformationLastName,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerBillingInformationTelephoneNumber",
                    Value = customerBillingInformationTelephoneNumber,
                    MaxLength = 13
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerShippingInformationAddressLine1",
                    Value = customerShippingInformationAddressLine1,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerShippingInformationAddressLine3",
                    Value = customerShippingInformationAddressLine3,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerShippingInformationAddressLine4",
                    Value = customerShippingInformationAddressLine4,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerShippingInformationAddressLine5",
                    Value = customerShippingInformationAddressLine5,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerShippingInformationEmailAddress",
                    Value = customerShippingInformationEmailAddress,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerShippingInformationFirstName",
                    Value = customerShippingInformationFirstName,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerShippingInformationLastName",
                    Value = customerShippingInformationLastName,
                    MaxLength = 50
                },
                new ValidateStringInput.StringProperty
                {
                    Name = "CustomerShippingInformationTelephoneNumber",
                    Value = customerShippingInformationTelephoneNumber,
                    MaxLength = 13
                }
            };

            if (!string.IsNullOrEmpty(customerOverviewCompanyName))
            {
                stringsToValidate.Add(new ValidateStringInput.StringProperty
                {
                    Name = "CustomerOverviewCompanyName",
                    Value = customerOverviewCompanyName,
                    MaxLength = 50
                });
            }

            if (!string.IsNullOrEmpty(customerBillingInformationAddressLine2))
            {
                stringsToValidate.Add(new ValidateStringInput.StringProperty
                {
                    Name = "CustomerBillingInformationAddressLine2",
                    Value = customerBillingInformationAddressLine2,
                    MaxLength = 50
                });
            }

            if (!string.IsNullOrEmpty(customerBillingInformationCompanyName))
            {
                stringsToValidate.Add(new ValidateStringInput.StringProperty
                {
                    Name = "CustomerBillingInformationCompanyName",
                    Value = customerBillingInformationCompanyName,
                    MaxLength = 50
                });
            }

            if (!string.IsNullOrEmpty(customerShippingInformationAddressLine2))
            {
                stringsToValidate.Add(new ValidateStringInput.StringProperty
                {
                    Name = "CustomerShippingInformationAddressLine2",
                    Value = customerShippingInformationAddressLine2,
                    MaxLength = 50
                });
            }

            if (!string.IsNullOrEmpty(customerShippingInformationCompanyName))
            {
                stringsToValidate.Add(new ValidateStringInput.StringProperty
                {
                    Name = "CustomerShippingInformationCompanyName",
                    Value = customerShippingInformationCompanyName,
                    MaxLength = 50
                });
            }

            if (!string.IsNullOrEmpty(customerFinanceVATNumber))
            {
                stringsToValidate.Add(new ValidateStringInput.StringProperty
                {
                    Name = "CompanyFinanceVATNumber",
                    Value = customerFinanceVATNumber,
                    MaxLength = 50
                });
            }

            var validationResult = ValidateStringInput.ValidateInput(stringsToValidate);

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
                            ParameterName = "@accountManagerId",
                            ParameterValue = customerOverviewAccountManagerId
                        },
                        new Parameter
                        {
                            ParameterName = "@activeStatus",
                            ParameterValue = customerOverviewActiveStatus
                        },
                        new Parameter
                        {
                            ParameterName = "@billingFirstName",
                            ParameterValue = customerBillingInformationFirstName
                        },
                        new Parameter
                        {
                            ParameterName = "@billingLastName",
                            ParameterValue = customerBillingInformationLastName
                        },
                        new Parameter
                        {
                            ParameterName = "@billingAddressLine1",
                            ParameterValue = customerBillingInformationAddressLine1
                        },
                        new Parameter
                        {
                            ParameterName = "@billingAddressLine3",
                            ParameterValue = customerBillingInformationAddressLine3
                        },
                        new Parameter
                        {
                            ParameterName = "@billingAddressLine4",
                            ParameterValue = customerBillingInformationAddressLine4
                        },
                        new Parameter
                        {
                            ParameterName = "@billingAddressLine5",
                            ParameterValue = customerBillingInformationAddressLine5
                        },
                        new Parameter
                        {
                            ParameterName = "@billingTelephoneNumber",
                            ParameterValue = customerBillingInformationTelephoneNumber
                        },
                        new Parameter
                        {
                            ParameterName = "@billingEmailAddress",
                            ParameterValue = customerBillingInformationEmailAddress
                        },
                        new Parameter
                        {
                            ParameterName = "@creditEnabled",
                            ParameterValue = customerFinanceCreditEnabled
                        },
                        new Parameter
                        {
                            ParameterName = "@customerSince",
                            ParameterValue = customerOverviewCustomerSince
                        },
                        new Parameter
                        {
                            ParameterName = "@customerTierId",
                            ParameterValue = customerOverviewCustomerTierId
                        },
                        new Parameter
                        {
                            ParameterName = "@customerTypeId",
                            ParameterValue = customerOverviewCustomerTypeId
                        },
                        new Parameter
                        {
                            ParameterName = "@emailAddress",
                            ParameterValue = customerOverviewEmailAddress
                        },
                        new Parameter
                        {
                            ParameterName = "@firstName",
                            ParameterValue = customerOverviewFirstName
                        },
                        new Parameter
                        {
                            ParameterName = "@globalParentCustomer",
                            ParameterValue = customerOverviewWillBeGlobalParent
                        },
                        new Parameter
                        {
                            ParameterName = "@lastName",
                            ParameterValue = customerOverviewLastName
                        },
                        new Parameter
                        {
                            ParameterName = "@paymentCurrencyId",
                            ParameterValue = customerFinancePaymentCurrencyId
                        },
                        new Parameter
                        {
                            ParameterName = "@paymentDays",
                            ParameterValue = customerFinancePaymentDays
                        },
                        new Parameter
                        {
                            ParameterName = "@salesSubRegionId",
                            ParameterValue = customerOverviewSalesSubRegionId
                        },
                        new Parameter
                        {
                            ParameterName = "@shippingFirstName",
                            ParameterValue = customerShippingInformationFirstName
                        },
                        new Parameter
                        {
                            ParameterName = "@shippingLastName",
                            ParameterValue = customerShippingInformationLastName
                        },
                        new Parameter
                        {
                            ParameterName = "@shippingAddressLine1",
                            ParameterValue = customerShippingInformationAddressLine1
                        },
                        new Parameter
                        {
                            ParameterName = "@shippingAddressLine3",
                            ParameterValue = customerShippingInformationAddressLine3
                        },
                        new Parameter
                        {
                            ParameterName = "@shippingAddressLine4",
                            ParameterValue = customerShippingInformationAddressLine4
                        },
                        new Parameter
                        {
                            ParameterName = "@shippingAddressLine5",
                            ParameterValue = customerShippingInformationAddressLine5
                        },
                        new Parameter
                        {
                            ParameterName = "@shippingTelephoneNumber",
                            ParameterValue = customerShippingInformationTelephoneNumber
                        },
                        new Parameter
                        {
                            ParameterName = "@shippingEmailAddress",
                            ParameterValue = customerShippingInformationEmailAddress
                        },
                        new Parameter
                        {
                            ParameterName = "@telephoneNumber",
                            ParameterValue = customerOverviewTelephoneNumber
                        },
                        new Parameter
                        {
                            ParameterName = "@topParentCustomer",
                            ParameterValue = customerOverviewWillBeTopParent
                        },
                        new Parameter
                        {
                            ParameterName = "@vatNumber",
                            ParameterValue = customerFinanceVATNumber
                        },
                };

                if (!string.IsNullOrEmpty(customerOverviewCompanyName))
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@companyName",
                        ParameterValue = customerOverviewCompanyName
                    });
                }

                if (!string.IsNullOrEmpty(customerBillingInformationAddressLine2))
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@billingAddressLine2",
                        ParameterValue = customerBillingInformationAddressLine2
                    });
                }

                if (!string.IsNullOrEmpty(customerBillingInformationCompanyName))
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@billingCompanyName",
                        ParameterValue = customerBillingInformationCompanyName
                    });
                }

                if (customerOverviewExistingGlobalParentCustomerId != null && customerOverviewExistingGlobalParentCustomerId != Guid.Empty)
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@globalParentCustomerId",
                        ParameterValue = customerOverviewExistingGlobalParentCustomerId
                    });
                }

                if (!string.IsNullOrEmpty(customerShippingInformationAddressLine2))
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@shippingAddressLine2",
                        ParameterValue = customerShippingInformationAddressLine2
                    });
                }

                if (!string.IsNullOrEmpty(customerShippingInformationCompanyName))
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@shippingCompanyName",
                        ParameterValue = customerShippingInformationCompanyName
                    });
                }

                if (customerOverviewExistingTopParentCustomerId != null && customerOverviewExistingTopParentCustomerId != Guid.Empty)
                {
                    parameters.Add(new Parameter
                    {
                        ParameterName = "@topParentCustomerId",
                        ParameterValue = customerOverviewExistingTopParentCustomerId
                    });
                }

                string storedProcedureName = "[dbo].[spCreateCustomer]";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters.ToArray(), dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
                this.Close();
            }
        }
    }
}