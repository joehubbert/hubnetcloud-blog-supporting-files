using CRM_WindowsForms.Model;
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
            CreateCustomerOverviewLoadCustomerTypeAsync();
            CreateCustomerOverviewLoadCustomerTierDataAsync();
            CreateCustomerOverviewLoadSalesRegionDataAsync();
            CreateCustomerOverviewLoadAccountManagerDataAsync();
            CreateCustomerOverviewLoadGlobalParentCustomerDataAsync();
            CreateCustomerOverviewLoadTopParentCustomerDataAsync();
            CreateCustomerFinanceLoadCurrencyDataAsync();
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void InitializeCustomComponents()
        {
            createCustomerOverviewCustomerTypeComboBox.DropDown += new EventHandler(CreateCustomerOverviewCustomerTypeComboBox_DropDown);
            createCustomerOverviewCustomerTierComboBox.DropDown += new EventHandler(CreateCustomerOverviewCustomerTierComboBox_DropDown);
            createCustomerOverviewAccountManagerComboBox.DropDown += new EventHandler(CreateCustomerOverviewAccountManagerComboBox_DropDown);
            createCustomerOverviewSalesRegionComboBox.DropDown += new EventHandler(CreateCustomerOverviewSalesRegionComboBox_DropDown);
            createCustomerOverviewExistingCustomerIsParentNoRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewExistingParentCustomerRadioButton_CheckedChanged);
            createCustomerOverviewExistingCustomerIsParentYesRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewExistingParentCustomerRadioButton_CheckedChanged);
            createCustomerOverviewWillBeParentInCustomerHierarchyNoRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewWillBeParentInCustomerHierarchyRadioButton_CheckedChanged);
            createCustomerOverviewWillBeParentInCustomerHierarchyYesRadioButton.CheckedChanged += new EventHandler(CreateCustomerOverviewWillBeParentInCustomerHierarchyRadioButton_CheckedChanged);
            createCustomerFinanceCreditEnabledCheckbox.CheckedChanged += new EventHandler(CreateCustomerFinanceCreditEnabledCheckBox_CheckedChanged);
            createCustomerFinancePaymentCurrencyComboBox.DropDown += new EventHandler(CreateCustomerFinancePaymentCurrencyComboBox_DropDown);
        }

        private void AdjustComboBoxDropDownWidth(ComboBox comboBox)
        {
            int comboBoxWidth = comboBox.DropDownWidth;
            Graphics comboBoxGraphics = comboBox.CreateGraphics();
            Font comboBoxFont = comboBox.Font;

            int verticalScrollBarWidth = (comboBox.Items.Count > comboBox.MaxDropDownItems) ? SystemInformation.VerticalScrollBarWidth : 0;
            int dynamicComboBoxWidth;

            foreach (var item in comboBox.Items)
            {
                dynamicComboBoxWidth = (int)comboBoxGraphics.MeasureString(comboBox.GetItemText(item), comboBoxFont).Width + verticalScrollBarWidth;
                if (comboBoxWidth < dynamicComboBoxWidth)
                {
                    comboBoxWidth = dynamicComboBoxWidth;
                }
            }
            comboBox.DropDownWidth = comboBoxWidth;
        }

        private async void CreateCustomerOverviewLoadCustomerTypeAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                DataTable customerTypeData = await executor.ExecuteAsync("[dbo].[spGetAllCustomerType]");
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

        private void CreateCustomerOverviewCustomerTypeComboBox_DropDown(object sender, EventArgs e)
        {
            AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void CreateCustomerOverviewLoadCustomerTierDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                DataTable customerTierData = await executor.ExecuteAsync("[dbo].[spGetAllCustomerTier]");
                var customerTierList = customerTierData.AsEnumerable()
                    .Select(row => new
                    {
                        CustomerTierId = row.Field<Guid>("Customer Tier Id"),
                        CustomerTier = row.Field<string>("Customer Tier")
                    })
                    .OrderBy(item => item.CustomerTier)
                    .ToList();
                createCustomerOverviewCustomerTierComboBox.DataSource = customerTierList;
                createCustomerOverviewCustomerTierComboBox.DisplayMember = "CustomerTier";
                createCustomerOverviewCustomerTierComboBox.ValueMember = "CustomerTierId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load customer tier data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateCustomerOverviewCustomerTierComboBox_DropDown(object sender, EventArgs e)
        {
            AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void CreateCustomerOverviewLoadSalesRegionDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                DataTable salesRegionData = await executor.ExecuteAsync("[dbo].[spGetAllSalesRegion]");
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

        private void CreateCustomerOverviewSalesRegionComboBox_DropDown(object sender, EventArgs e)
        {
            AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void CreateCustomerOverviewLoadAccountManagerDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                DataTable accountManagerData = await executor.ExecuteAsync("[dbo].[spGetAllAccountManager]");
                var accountManagerList = accountManagerData.AsEnumerable()
                    .Select(row => new
                    {
                        AccountManagerId = row.Field<Guid>("Account Manager Id"),
                        AccountManagerFirstName = row.Field<string>("First Name"),
                        AccountManagerLastName = row.Field<string>("Last Name"),
                        AccountManagerEmailAddress = row.Field<string>("Email Address"),
                        DisplayText = $"{row.Field<Guid>("Account Manager Id")} | {row.Field<string>("Last Name")}, {row.Field<string>("First Name")} | {row.Field<string>("Email Address")}"
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

        private void CreateCustomerOverviewAccountManagerComboBox_DropDown(object sender, EventArgs e)
        {
            AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private void CreateCustomerOverviewExistingParentCustomerRadioButton_CheckedChanged(object sender, EventArgs e)
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

        private async void CreateCustomerOverviewLoadGlobalParentCustomerDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                DataTable globalParentCustomerData = await executor.ExecuteAsync("[dbo].[spGetAllGlobalParentCustomer]");
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

        private void CreateCustomerOverviewGlobalParentCustomerComboBox_DropDown(object sender, EventArgs e)
        {
            AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async void CreateCustomerOverviewLoadTopParentCustomerDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }
            try
            {
                ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                DataTable topParentCustomerData = await executor.ExecuteAsync("[dbo].[spGetAllTopParentCustomer]");
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

        private void CreateCustomerOverviewTopParentCustomerComboBox_DropDown(object sender, EventArgs e)
        {
            AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private void CreateCustomerOverviewWillBeParentInCustomerHierarchyRadioButton_CheckedChanged(object sender, EventArgs e)
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

        private void CreateCustomerFinanceCreditEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
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

        private async void CreateCustomerFinanceLoadCurrencyDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            try
            {
                ExecuteStoredProcedure executor = new ExecuteStoredProcedure(_databaseConnectionSettings.DatabaseConnectionString);
                DataTable currencyData = await executor.ExecuteAsync("[dbo].[spGetAllCurrency]");

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

        private void CreateCustomerFinancePaymentCurrencyComboBox_DropDown(object sender, EventArgs e)
        {
            AdjustComboBoxDropDownWidth(sender as ComboBox);
        }
    }
}