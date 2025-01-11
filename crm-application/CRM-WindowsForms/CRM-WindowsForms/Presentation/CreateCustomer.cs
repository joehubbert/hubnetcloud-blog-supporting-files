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
            createCustomerOverviewWillBeParentInCustomerHierarchyNoRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewWillBeParentInCustomerHierarchyRadioButton_CheckedChanged);
            createCustomerOverviewWillBeParentInCustomerHierarchyYesRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewWillBeParentInCustomerHierarchyRadioButton_CheckedChanged);
            createCustomerOverviewWillBeGlobalParentRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewWillBeGlobalParentRadioButton_CheckedChanged);
            createCustomerFinanceCreditEnabledCheckbox.CheckedChanged += new EventHandler(CreateCustomerFinanceCreditEnabledCheckBox_CheckedChanged);
            createCustomerFinancePaymentCurrencyComboBox.DropDown += new EventHandler(CreateCustomerFinancePaymentCurrencyComboBox_DropDown);
            createCustomerFinanceVATRegisteredCheckbox.CheckedChanged += new EventHandler(CreateCustomerFinanceVATRegisteredCheckBox_CheckedChanged);
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
            var loadGlobalParentCustomerTask = CreateCustomerOverviewLoadGlobalParentCustomerDataAsync();
            var loadTopParentCustomerTask = CreateCustomerOverviewLoadTopParentCustomerDataAsync();
            var loadCurrencyTask = CreateCustomerFinanceLoadCurrencyDataAsync();

            await Task.WhenAll(loadCustomerTypeTask, loadCustomerTierTask, loadSalesRegionTask, loadAccountManagerTask, loadGlobalParentCustomerTask, loadTopParentCustomerTask, loadCurrencyTask);

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
                MessageBox.Show($"Failed to load customer type data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Failed to load customer tier data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Failed to load sales region data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Failed to load account manager data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                createCustomerOverviewGlobalParentCustomerComboBox.Enabled = false;
                createCustomerOverviewTopParentCustomerComboBox.Enabled = false;
            }
            else if (createCustomerOverviewExistingCustomerIsParentYesRadioButton.Checked)
            {
                createCustomerOverviewGlobalParentCustomerComboBox.Enabled = true;
                createCustomerOverviewTopParentCustomerComboBox.Enabled = true;
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
                MessageBox.Show($"Failed to load global parent customer data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Failed to load top parent customer data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateCustomerOverviewTopParentCustomerComboBox_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private void CreateCustomerOverviewWillBeParentInCustomerHierarchyRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
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
        }

        private void CreateCustomerOverviewWillBeGlobalParentRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCustomerOverviewWillBeGlobalParentRadioButton.Checked)
            {
                var selectedCustomerType = createCustomerOverviewCustomerTypeComboBox.Text;
                if (selectedCustomerType != "Business - Multinational")
                {
                    MessageBox.Show("The 'Global Parent' option can only be selected if 'Business - Multinational' is selected in the Customer Type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    createCustomerOverviewWillBeGlobalParentRadioButton.Checked = false;
                }
            }
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
                createCustomerFinancePaymentCurrencyComboBox.ValueMember = "CurrencyCode";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load currency data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateCustomerFinancePaymentCurrencyComboBox_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }
    }
}