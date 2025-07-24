using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CustomerDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _customerId;
        private string customerDetailBillingInformationAddressLine1OriginalValue;
        private string? customerDetailBillingInformationAddressLine2OriginalValue;
        private string customerDetailBillingInformationAddressLine3OriginalValue;
        private string customerDetailBillingInformationAddressLine4OriginalValue;
        private string customerDetailBillingInformationAddressLine5OriginalValue;
        private string customerDetailBillingInformationCompanyNameOriginalValue;
        private string customerDetailBillingInformationEmailAddressOriginalValue;
        private string customerDetailBillingInformationFirstNameOriginalValue;
        private string customerDetailBillingInformationLastNameOriginalValue;
        private string customerDetailBillingInformationTelephoneNumberOriginalValue;
        private bool customerDetailFinanceCreditEnabledOriginalValue;
        private decimal? customerDetailFinanceCreditLimitOriginalValue;
        private Guid customerDetailFinancePaymentCurrencyIdOriginalValue;
        private int customerDetailFinancePaymentDaysOriginalValue;
        private string? customerDetailFinanceVATNumberOriginalValue;
        private bool customerDetailFinanceVATRegisteredOriginalValue;
        private Guid customerDetailOverviewAccountManagerIdOriginalValue;
        private bool customerDetailOverviewActiveStatusOriginalValue;
        private string customerDetailOverviewCompanyNameOriginalValue;
        private DateTime customerDetailOverviewCustomerSinceOriginalValue;
        private Guid? customerDetailOverviewCustomerTierIdOriginalValue;
        private Guid? customerDetailOverviewCustomerTypeIdOriginalValue;
        private string customerDetailOverviewEmailAddressOriginalValue;
        private bool? customerDetailOverviewExistingParentCompanyTypeGlobalParentOriginalValue;
        private bool? customerDetailOverviewExistingParentCompanyTypeTopParentOriginalValue;
        private string customerDetailOverviewFirstNameOriginalValue;
        private Guid? customerDetailOverviewGlobalParentCustomerIdOriginalValue;
        private string customerDetailOverviewLastNameOriginalValue;
        private Guid customerDetailOverviewSalesRegionIdOriginalValue;
        private Guid customerDetailOverviewSalesSubRegionIdOriginalValue;
        private string customerDetailOverviewTelephoneNumberOriginalValue;
        private Guid? customerDetailOverviewTopParentCustomerIdOriginalValue;
        private bool? customerDetailOverviewWillBeParentInCustomerHierarchyOriginalValue;
        private string customerDetailShippingInformationAddressLine1OriginalValue;
        private string? customerDetailShippingInformationAddressLine2OriginalValue;
        private string customerDetailShippingInformationAddressLine3OriginalValue;
        private string customerDetailShippingInformationAddressLine4OriginalValue;
        private string customerDetailShippingInformationAddressLine5OriginalValue;
        private string customerDetailShippingInformationCompanyNameOriginalValue;
        private string customerDetailShippingInformationEmailAddressOriginalValue;
        private string customerDetailShippingInformationFirstNameOriginalValue;
        private string customerDetailShippingInformationLastNameOriginalValue;
        private string customerDetailShippingInformationTelephoneNumberOriginalValue;


        public CustomerDetail(Guid customerId)
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadDatabaseConnectionSettingsAsync();
            _customerId = customerId;
        }

        private void InitializeCustomComponents()
        {
            customerDetailFinanceCreditEnabledCheckbox.CheckedChanged += new EventHandler(CustomerDetailFinanceCreditEnabledCheckBox_CheckedChanged);
            customerDetailFinancePaymentCurrencyComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            customerDetailFinanceVATRegisteredCheckbox.CheckedChanged += new EventHandler(CustomerDetailFinanceVATRegisteredCheckbox_CheckedChanged);
            customerDetailOverviewAccountManagerComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            customerDetailOverviewCustomerTierComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            customerDetailOverviewCustomerTypeComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            customerDetailOverviewExistingCustomerIsParentNoRadioButton.CheckedChanged += new EventHandler(CustomerDetailOverviewExistingParentCustomerRadioButton_CheckedChanged);
            customerDetailOverviewExistingCustomerIsParentYesRadioButton.CheckedChanged += new EventHandler(CustomerDetailOverviewExistingParentCustomerRadioButton_CheckedChanged);
            customerDetailOverviewExistingParentCompanyTypeGlobalParentRadioButton.CheckedChanged += new EventHandler(CustomerDetailOverviewExistingParentCompanyType_CheckedChanged);
            customerDetailOverviewExistingParentCompanyTypeGlobalParentRadioButton.CheckedChanged += new EventHandler(CustomerDetailOverviewRadioButtonValidation_CheckedChanged);
            customerDetailOverviewExistingParentCompanyTypeTopParentRadioButton.CheckedChanged += new EventHandler(CustomerDetailOverviewExistingParentCompanyType_CheckedChanged);
            customerDetailOverviewExistingParentCompanyTypeTopParentRadioButton.CheckedChanged += new EventHandler(CustomerDetailOverviewRadioButtonValidation_CheckedChanged);
            customerDetailOverviewSalesRegionComboBox.DropDown += new EventHandler(CustomerDetailOverviewSalesRegionComboBox_DropDown);
            customerDetailOverviewSalesRegionComboBox.SelectedIndexChanged += new EventHandler(CustomerDetailOverviewSalesRegionComboBox_SelectedIndexChanged);
            customerDetailOverviewWillBeParentInCustomerHierarchyNoRadioButton.CheckedChanged += new EventHandler(CustomerDetailOverviewRadioButtonValidation_CheckedChanged);
            customerDetailOverviewWillBeGlobalParentRadioButton.CheckedChanged += new EventHandler(CustomerDetailOverviewRadioButtonValidation_CheckedChanged);
            customerDetailOverviewWillBeParentInCustomerHierarchyYesRadioButton.CheckedChanged += new EventHandler(CustomerDetailOverviewRadioButtonValidation_CheckedChanged);
            customerDetailOverviewWillBeTopParentRadioButton.CheckedChanged += new EventHandler(CustomerDetailOverviewRadioButtonValidation_CheckedChanged);
            customerDetailTabControl.SelectedIndexChanged += new EventHandler(CustomerDetailTabControl_SelectedIndexChanged);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task CustomerDetailOverviewLoadCustomerTypeAsync(Guid customerTypeId)
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
                customerDetailOverviewCustomerTypeComboBox.DataSource = customerTypeList;
                customerDetailOverviewCustomerTypeComboBox.DisplayMember = "CustomerType";
                customerDetailOverviewCustomerTypeComboBox.ValueMember = "CustomerTypeId";
                customerDetailOverviewCustomerTypeComboBox.SelectedValue = customerTypeId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Customer Type data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async Task CustomerDetailOverviewLoadCustomerTierDataAsync(Guid customerTierId)
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
                customerDetailOverviewCustomerTierComboBox.DataSource = customerTierList;
                customerDetailOverviewCustomerTierComboBox.DisplayMember = "DisplayText";
                customerDetailOverviewCustomerTierComboBox.ValueMember = "CustomerTierId";
                customerDetailOverviewCustomerTierComboBox.SelectedValue = customerTierId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Customer Tier data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CustomerDetailOverviewLoadSalesRegionDataAsync(Guid salesRegionId)
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
                customerDetailOverviewSalesRegionComboBox.DataSource = salesRegionList;
                customerDetailOverviewSalesRegionComboBox.DisplayMember = "SalesRegion";
                customerDetailOverviewSalesRegionComboBox.ValueMember = "SalesRegionId";
                customerDetailOverviewSalesRegionComboBox.SelectedValue = salesRegionId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Sales Region data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CustomerDetailOverviewSalesRegionComboBox_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
            await CustomerDetailLoadSalesSubRegionAsync((Guid)customerDetailOverviewSalesRegionComboBox.SelectedValue, (Guid)customerDetailOverviewSalesSubRegionComboBox.SelectedValue);
        }

        private async Task CustomerDetailLoadSalesSubRegionAsync(Guid salesRegionId, Guid salesSubRegionId)
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
                customerDetailOverviewSalesSubRegionComboBox.DataSource = salesSubRegionList;
                customerDetailOverviewSalesSubRegionComboBox.DisplayMember = "SalesSubRegion";
                customerDetailOverviewSalesSubRegionComboBox.ValueMember = "SalesSubRegionId";
                customerDetailOverviewSalesSubRegionComboBox.SelectedValue = salesSubRegionId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Sales Sub Region data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CustomerDetailOverviewSalesRegionComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            await CustomerDetailLoadSalesSubRegionAsync((Guid)customerDetailOverviewSalesRegionComboBox.SelectedValue, (Guid)customerDetailOverviewSalesSubRegionComboBox.SelectedValue);
        }

        private async Task CustomerDetailOverviewLoadAccountManagerDataAsync(Guid accountManagerId)
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
                customerDetailOverviewAccountManagerComboBox.DataSource = accountManagerList;
                customerDetailOverviewAccountManagerComboBox.DisplayMember = "DisplayText";
                customerDetailOverviewAccountManagerComboBox.ValueMember = "AccountManagerId";
                customerDetailOverviewAccountManagerComboBox.SelectedValue = accountManagerId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Account Manager data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomerDetailOverviewExistingParentCustomerRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (customerDetailOverviewExistingCustomerIsParentNoRadioButton.Checked)
            {
                customerDetailOverviewExistingParentCompanyTypeGlobalParentRadioButton.Enabled = false;
                customerDetailOverviewExistingParentCompanyTypeTopParentRadioButton.Enabled = false;
                customerDetailOverviewExistingParentCompanyTypeGlobalParentRadioButton.Checked = false;
                customerDetailOverviewExistingParentCompanyTypeTopParentRadioButton.Checked = false;
                customerDetailOverviewGlobalParentCustomerComboBox.Enabled = false;
                customerDetailOverviewGlobalParentCustomerComboBox.DataSource = null;
                customerDetailOverviewGlobalParentCustomerComboBox.Items.Clear();
                customerDetailOverviewTopParentCustomerComboBox.Enabled = false;
                customerDetailOverviewTopParentCustomerComboBox.DataSource = null;
                customerDetailOverviewTopParentCustomerComboBox.Items.Clear();
            }
            else if (customerDetailOverviewExistingCustomerIsParentYesRadioButton.Checked)
            {
                customerDetailOverviewExistingParentCompanyTypeGlobalParentRadioButton.Enabled = true;
                customerDetailOverviewExistingParentCompanyTypeTopParentRadioButton.Enabled = true;
            }
        }

        private async void CustomerDetailOverviewExistingParentCompanyType_CheckedChanged(object? sender, EventArgs e)
        {
            if (customerDetailOverviewExistingParentCompanyTypeGlobalParentRadioButton.Checked)
            {
                if (customerDetailOverviewGlobalParentCustomerComboBox.SelectedValue != null)
                {
                    await CustomerDetailOverviewLoadGlobalParentCustomerDataAsync((Guid)customerDetailOverviewGlobalParentCustomerComboBox.SelectedValue);
                }
                else
                {
                    MessageBox.Show("No item selected in the Global Parent Customer ComboBox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                customerDetailOverviewGlobalParentCustomerComboBox.Enabled = true;
                customerDetailOverviewTopParentCustomerComboBox.Enabled = false;
                customerDetailOverviewTopParentCustomerComboBox.DataSource = null;
                customerDetailOverviewTopParentCustomerComboBox.Items.Clear();

            }
            else if (customerDetailOverviewExistingParentCompanyTypeTopParentRadioButton.Checked)
            {
                if (customerDetailOverviewTopParentCustomerComboBox.SelectedValue != null)
                {
                    await CustomerDetailOverviewLoadTopParentCustomerDataAsync((Guid)customerDetailOverviewTopParentCustomerComboBox.SelectedValue);
                }
                else
                {
                    MessageBox.Show("No item selected in the Top Parent Customer ComboBox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                customerDetailOverviewTopParentCustomerComboBox.Enabled = true;
                customerDetailOverviewGlobalParentCustomerComboBox.Enabled = false;
                customerDetailOverviewGlobalParentCustomerComboBox.DataSource = null;
                customerDetailOverviewGlobalParentCustomerComboBox.Items.Clear();
            }
        }

        private async Task CustomerDetailOverviewLoadGlobalParentCustomerDataAsync(Guid globalParentCustomerId)
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
                customerDetailOverviewGlobalParentCustomerComboBox.DataSource = globalParentCustomerList;
                customerDetailOverviewGlobalParentCustomerComboBox.DisplayMember = "DisplayText";
                customerDetailOverviewGlobalParentCustomerComboBox.ValueMember = "CustomerId";
                customerDetailOverviewGlobalParentCustomerComboBox.SelectedValue = globalParentCustomerId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Global Parent Customer data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CustomerDetailOverviewLoadTopParentCustomerDataAsync(Guid topParentCustomerId)
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
                customerDetailOverviewTopParentCustomerComboBox.DataSource = topParentCustomerList;
                customerDetailOverviewTopParentCustomerComboBox.DisplayMember = "DisplayText";
                customerDetailOverviewTopParentCustomerComboBox.ValueMember = "CustomerId";
                customerDetailOverviewTopParentCustomerComboBox.SelectedValue = topParentCustomerId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Top Parent Customer data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomerDetailOverviewRadioButtonValidation_CheckedChanged(object? sender, EventArgs e)
        {
            if (customerDetailOverviewExistingParentCompanyTypeTopParentRadioButton.Checked)
            {
                customerDetailOverviewWillBeParentInCustomerHierarchyYesRadioButton.Enabled = false;
                customerDetailOverviewWillBeParentInCustomerHierarchyNoRadioButton.Enabled = false;
                customerDetailOverviewWillBeParentInCustomerHierarchyYesRadioButton.Checked = false;
                customerDetailOverviewWillBeParentInCustomerHierarchyNoRadioButton.Checked = false;
                customerDetailOverviewWillBeGlobalParentRadioButton.Checked = false;
                customerDetailOverviewWillBeGlobalParentRadioButton.Enabled = false;
                customerDetailOverviewWillBeTopParentRadioButton.Checked = false;
                customerDetailOverviewWillBeTopParentRadioButton.Enabled = false;

            }
            else if (customerDetailOverviewExistingParentCompanyTypeTopParentRadioButton.Checked && customerDetailOverviewWillBeTopParentRadioButton.Checked)
            {
                MessageBox.Show("Cannot select 'Top Parent Parent' as new customer parent type when existing Parent Company Type is 'Top Parent'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                customerDetailOverviewWillBeTopParentRadioButton.Checked = false;
                customerDetailOverviewWillBeTopParentRadioButton.Enabled = false;
                customerDetailOverviewWillBeGlobalParentRadioButton.Checked = false;
                customerDetailOverviewWillBeGlobalParentRadioButton.Enabled = false;
            }


            if (customerDetailOverviewWillBeGlobalParentRadioButton.Checked)
            {
                var selectedCustomerType = customerDetailOverviewCustomerTypeComboBox.Text;
                if (selectedCustomerType != "Business - Multinational")
                {
                    MessageBox.Show("The 'Global Parent' option can only be selected for a new customer if 'Business - Multinational' is selected in the Customer Type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    customerDetailOverviewWillBeGlobalParentRadioButton.Checked = false;
                }
            }
            else if (customerDetailOverviewWillBeGlobalParentRadioButton.Checked && customerDetailOverviewExistingParentCompanyTypeGlobalParentRadioButton.Checked)
            {
                MessageBox.Show("Cannot select 'Global Parent' as new customer parent tyoe when existing Parent Company Type is 'Global Parent'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                customerDetailOverviewWillBeGlobalParentRadioButton.Checked = false;
                customerDetailOverviewWillBeGlobalParentRadioButton.Enabled = false;
            }

            if (customerDetailOverviewExistingParentCompanyTypeGlobalParentRadioButton.Checked)
            {
                var selectedCustomerType = customerDetailOverviewCustomerTypeComboBox.Text;
                if (selectedCustomerType != "Business - Multinational")
                {
                    MessageBox.Show("'Business - Multinational' is can only be selected as the Customer Type if the parent customer is Global Parent.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    customerDetailOverviewWillBeGlobalParentRadioButton.Checked = false;
                    customerDetailOverviewExistingParentCompanyTypeGlobalParentRadioButton.Checked = false;
                }
            }

            if (customerDetailOverviewWillBeParentInCustomerHierarchyNoRadioButton.Checked)
            {
                customerDetailOverviewWillBeGlobalParentRadioButton.Enabled = false;
                customerDetailOverviewWillBeTopParentRadioButton.Enabled = false;
                customerDetailOverviewWillBeGlobalParentRadioButton.Checked = false;
                customerDetailOverviewWillBeTopParentRadioButton.Checked = false;
            }
            else if (customerDetailOverviewWillBeParentInCustomerHierarchyYesRadioButton.Checked)
            {
                customerDetailOverviewWillBeGlobalParentRadioButton.Enabled = true;
                customerDetailOverviewWillBeTopParentRadioButton.Enabled = true;
            }

            if (customerDetailOverviewExistingCustomerIsParentNoRadioButton.Checked)
            {
                customerDetailOverviewWillBeParentInCustomerHierarchyNoRadioButton.Enabled = true;
                customerDetailOverviewWillBeParentInCustomerHierarchyYesRadioButton.Enabled = true;
            }
        }

        private void CustomerDetailFinanceCreditEnabledCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (customerDetailFinanceCreditEnabledCheckbox.Checked)
            {
                customerDetailFinanceCreditLimitTextboxA.Enabled = true;
                customerDetailFinanceCreditLimitTextboxB.Enabled = true;
            }
            else
            {
                customerDetailFinanceCreditLimitTextboxA.Enabled = false;
                customerDetailFinanceCreditLimitTextboxB.Enabled = false;
            }
        }

        private void CustomerDetailFinanceVATRegisteredCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (customerDetailFinanceVATRegisteredCheckbox.Checked)
            {
                customerDetailFinanceVATNumberTextbox.Enabled = true;
            }
            else
            {
                customerDetailFinanceVATNumberTextbox.Enabled = false;
                customerDetailFinanceVATNumberTextbox.Text = string.Empty;
            }
        }

        private async Task CustomerDetailFinanceLoadCurrencyDataAsync(Guid paymentCurrencyId)
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

                customerDetailFinancePaymentCurrencyComboBox.DataSource = currencyList;
                customerDetailFinancePaymentCurrencyComboBox.DisplayMember = "DisplayText";
                customerDetailFinancePaymentCurrencyComboBox.ValueMember = "CurrencyId";
                customerDetailFinancePaymentCurrencyComboBox.SelectedValue = paymentCurrencyId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load Currency data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomerDetailFinanceVATRegisteredCheckbox_CheckedChanged(object? sender, EventArgs e)
        {
            if (!customerDetailFinanceVATRegisteredCheckbox.Checked)
            {
                var result = MessageBox.Show(
                    "A VAT Number cannot be assigned if VAT Registered is false. Clicking OK will clear the VAT Number field. Clicking Cancel will reverse the changes.",
                    "Warning",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    customerDetailFinanceVATNumberTextbox.Text = string.Empty;
                }
                else
                {
                    customerDetailFinanceVATRegisteredCheckbox.Checked = true;
                }
            }
        }

        private async void CustomerDetailCustomerInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string storedProcedureName = "[dbo].[spGetCustomer]";
            string dataSubject = "Customer";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@customerId",
                    ParameterValue = _customerId
                }
            };
            try
            {
                DataTable? customerDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                if (customerDataTable != null)
                {
                    DataRow customerDataRow = customerDataTable.Rows[0];

                    customerDetailBillingInformationAddressLine1Textbox.Text = customerDataRow["Billing Address Line 1"].ToString();
                    customerDetailBillingInformationAddressLine2Textbox.Text = customerDataRow["Billing Address Line 2"].ToString();
                    customerDetailBillingInformationAddressLine3Textbox.Text = customerDataRow["Billing Address Line 3"].ToString();
                    customerDetailBillingInformationAddressLine4Textbox.Text = customerDataRow["Billing Address Line 4"].ToString();
                    customerDetailBillingInformationAddressLine5Textbox.Text = customerDataRow["Billing Address Line 5"].ToString();
                    customerDetailBillingInformationCompanyNameTextbox.Text = customerDataRow["Billing Company Name"].ToString();
                    customerDetailBillingInformationEmailAddressTextbox.Text = customerDataRow["Billing Email Address"].ToString();
                    customerDetailBillingInformationFirstNameTextbox.Text = customerDataRow["Billing First Name"].ToString();
                    customerDetailBillingInformationLastNameTextbox.Text = customerDataRow["Billing Last Name"].ToString();
                    customerDetailBillingInformationTelephoneNumberTextbox.Text = customerDataRow["Billing Telephone Number"].ToString();
                    customerDetailFinanceCreditEnabledCheckbox.Checked = (bool)customerDataRow["Credit Enabled"];
                    string creditLimitPartA;
                    string creditLimitPartB;
                    SplitDecimal.SplitDecimalUsingDelimiter((decimal)customerDataRow["Credit Limit"], out creditLimitPartA, out creditLimitPartB);
                    customerDetailFinanceCreditLimitTextboxA.Text = creditLimitPartA;
                    customerDetailFinanceCreditLimitTextboxB.Text = creditLimitPartB;
                    string creditLimitUsedPartA;
                    string creditLimitUsedPartB;
                    SplitDecimal.SplitDecimalUsingDelimiter((decimal)customerDataRow["Credit Limit Used"], out creditLimitUsedPartA, out creditLimitUsedPartB);
                    customerDetailFinanceCreditLimitUsedTextboxA.Text = creditLimitUsedPartA;
                    customerDetailFinanceCreditLimitUsedTextboxB.Text = creditLimitUsedPartB;
                    string creditLimitUsedPercentagePartA;
                    string creditLimitUsedPercentagePartB;
                    SplitDecimal.SplitDecimalUsingDelimiter((decimal)customerDataRow["Credit Limit Used Percentage"], out creditLimitUsedPercentagePartA, out creditLimitUsedPercentagePartB);
                    customerDetailFinanceCreditLimitUsedPercentageTextboxA.Text = creditLimitUsedPercentagePartA;
                    customerDetailFinanceCreditLimitUsedPercentageTextboxB.Text = creditLimitUsedPercentagePartB;
                    customerDetailFinanceCreditEnabledCheckbox.Checked = (bool)customerDataRow["Credit Enabled"];
                    Guid paymentCurrencyId = (Guid)customerDataRow["Payment Currency Id"];
                    await CustomerDetailFinanceLoadCurrencyDataAsync(paymentCurrencyId);
                    customerDetailFinancePaymentDaysTextbox.Text = customerDataRow["Payment Days"].ToString();
                    customerDetailFinanceVATNumberTextbox.Text = customerDataRow["VAT Number"].ToString();
                    Guid accountManagerId = (Guid)customerDataRow["Account Manager Id"];
                    await CustomerDetailOverviewLoadAccountManagerDataAsync(accountManagerId);
                    customerDetailOverviewActiveStatusCheckbox.Checked = (bool)customerDataRow["Active Status"];
                    customerDetailOverviewCompanyNameTextbox.Text = customerDataRow["Company Name"].ToString();
                    customerDetailOverviewCreatedByTextbox.Text = customerDataRow["Created By"].ToString();
                    customerDetailOverviewCreatedTimestampTextbox.Text = customerDataRow["Created Timestamp UTC"].ToString();
                    customerDetailOverviewCustomerIdTextbox.Text = customerDataRow["Customer Id"].ToString();
                    customerDetailOverviewCustomerSinceDatePicker.Value = (DateTime)customerDataRow["Customer Since"];
                    Guid customerTierId = (Guid)customerDataRow["Customer Tier Id"];
                    await CustomerDetailOverviewLoadCustomerTierDataAsync(customerTierId);
                    Guid customerTypeId = (Guid)customerDataRow["Customer Type Id"];
                    await CustomerDetailOverviewLoadCustomerTypeAsync(customerTypeId);
                    customerDetailOverviewEmailAddressTextbox.Text = customerDataRow["Email Address"].ToString();
                    if ((bool)customerDataRow["Global Parent Customer"] || (bool)customerDataRow["Top Parent Customer"])
                    {
                        customerDetailOverviewExistingCustomerIsParentYesRadioButton.Checked = true;
                    }
                    else
                    {
                        customerDetailOverviewExistingCustomerIsParentNoRadioButton.Checked = true;
                    }
                    if ((bool)customerDataRow["Global Parent Customer"])
                    {
                        customerDetailOverviewExistingParentCompanyTypeGlobalParentRadioButton.Checked = true;
                        customerDetailOverviewWillBeGlobalParentRadioButton.Checked = true;
                    }
                    else
                    {
                        customerDetailOverviewExistingParentCompanyTypeGlobalParentRadioButton.Checked = false;
                        customerDetailOverviewWillBeGlobalParentRadioButton.Checked = false;
                    }
                    if ((bool)customerDataRow["Top Parent Customer"])
                    {
                        customerDetailOverviewExistingParentCompanyTypeTopParentRadioButton.Checked = true;
                        customerDetailOverviewWillBeTopParentRadioButton.Checked = true;
                    }
                    else
                    {
                        customerDetailOverviewExistingParentCompanyTypeTopParentRadioButton.Checked = false;
                        customerDetailOverviewWillBeTopParentRadioButton.Checked = false;
                    }
                    if (customerDataRow["Global Parent Customer Id"] != null)
                    {
                        Guid existingGlobalParentCustomerId = (Guid)customerDataRow["Global Parent Customer Id"];
                        await CustomerDetailOverviewLoadGlobalParentCustomerDataAsync(existingGlobalParentCustomerId);
                    }
                    if (customerDataRow["Top Parent Customer Id"] != null)
                    {
                        Guid existingTopParentCustomerId = (Guid)customerDataRow["Top Parent Customer Id"];
                        await CustomerDetailOverviewLoadTopParentCustomerDataAsync(existingTopParentCustomerId);
                    }
                    customerDetailOverviewFirstNameTextbox.Text = customerDataRow["First Name"].ToString();
                    customerDetailOverviewLastNameTextbox.Text = customerDataRow["Last Name"].ToString();
                    customerDetailOverviewLastUpdatedByTextbox.Text = customerDataRow["Modified By"].ToString();
                    customerDetailOverviewLastUpdatedTimestampTextbox.Text = customerDataRow["Modified Timestamp UTC"].ToString();
                    Guid salesRegionId = (Guid)customerDataRow["Sales Region Id"];
                    await CustomerDetailOverviewLoadSalesRegionDataAsync(salesRegionId);
                    Guid salesSubRegionid = (Guid)customerDataRow["Sales Sub Region Id"];
                    await CustomerDetailLoadSalesSubRegionAsync(salesRegionId, salesSubRegionid);
                    customerDetailOverviewTelephoneNumberTextbox.Text = customerDataRow["Telephone Number"].ToString();
                    customerDetailShippingInformationAddressLine1Textbox.Text = customerDataRow["Shipping Address Line 1"].ToString();
                    customerDetailShippingInformationAddressLine2Textbox.Text = customerDataRow["Shipping Address Line 2"].ToString();
                    customerDetailShippingInformationAddressLine3Textbox.Text = customerDataRow["Shipping Address Line 3"].ToString();
                    customerDetailShippingInformationAddressLine4Textbox.Text = customerDataRow["Shipping Address Line 4"].ToString();
                    customerDetailShippingInformationAddressLine5Textbox.Text = customerDataRow["Shipping Address Line 5"].ToString();
                    customerDetailShippingInformationCompanyNameTextbox.Text = customerDataRow["Shipping Company Name"].ToString();
                    customerDetailShippingInformationEmailAddressTextbox.Text = customerDataRow["Shipping Email Address"].ToString();
                    customerDetailShippingInformationFirstNameTextbox.Text = customerDataRow["Shipping First Name"].ToString();
                    customerDetailShippingInformationLastNameTextbox.Text = customerDataRow["Shipping Last Name"].ToString();
                    customerDetailShippingInformationTelephoneNumberTextbox.Text = customerDataRow["Shipping Telephone Number"].ToString();

                    customerDetailBillingInformationAddressLine1OriginalValue = customerDataRow["Billing Address Line 1"].ToString();
                    customerDetailBillingInformationAddressLine2OriginalValue = customerDataRow["Billing Address Line 2"].ToString();
                    customerDetailBillingInformationAddressLine3OriginalValue = customerDataRow["Billing Address Line 3"].ToString();
                    customerDetailBillingInformationAddressLine4OriginalValue = customerDataRow["Billing Address Line 4"].ToString();
                    customerDetailBillingInformationAddressLine5OriginalValue = customerDataRow["Billing Address Line 5"].ToString();
                    customerDetailBillingInformationCompanyNameOriginalValue = customerDataRow["Billing Company Name"].ToString();
                    customerDetailBillingInformationEmailAddressOriginalValue = customerDataRow["Billing Email Address"].ToString();
                    customerDetailBillingInformationFirstNameOriginalValue = customerDataRow["Billing First Name"].ToString();
                    customerDetailBillingInformationLastNameOriginalValue = customerDataRow["Billing Last Name"].ToString();
                    customerDetailBillingInformationTelephoneNumberOriginalValue = customerDataRow["Billing Telephone Number"].ToString();
                    customerDetailFinanceCreditEnabledOriginalValue = (bool)customerDataRow["Credit Enabled"];
                    customerDetailFinanceCreditLimitOriginalValue = (decimal)customerDataRow["Credit Limit"];
                    customerDetailFinancePaymentCurrencyIdOriginalValue = (Guid)customerDataRow["Payment Currency Id"];
                    customerDetailFinancePaymentDaysOriginalValue = (int)customerDataRow["Payment Days"];
                    if (customerDataRow["VAT Number"] != DBNull.Value && customerDataRow["VAT Number"] != null)
                    {
                        customerDetailFinanceVATNumberOriginalValue = customerDataRow["VAT Number"].ToString();
                        customerDetailFinanceVATRegisteredOriginalValue = true;
                    }
                    customerDetailOverviewAccountManagerIdOriginalValue = (Guid)customerDataRow["Account Manager Id"];
                    customerDetailOverviewActiveStatusOriginalValue = (bool)customerDataRow["Active Status"];
                    customerDetailOverviewCompanyNameOriginalValue = customerDataRow["Company Name"].ToString();
                    customerDetailOverviewCustomerTierIdOriginalValue = (Guid)customerDataRow["Customer Tier Id"];
                    customerDetailOverviewCustomerTypeIdOriginalValue = (Guid)customerDataRow["Customer Type Id"];
                    customerDetailOverviewEmailAddressOriginalValue = customerDataRow["Email Address"].ToString();
                    if ((bool)customerDataRow["Global Parent Customer"] || (bool)customerDataRow["Top Parent Customer"])
                    {
                        customerDetailOverviewWillBeParentInCustomerHierarchyOriginalValue = true;
                    }
                    else
                    {
                        customerDetailOverviewWillBeParentInCustomerHierarchyOriginalValue = false;
                    }
                    if ((bool)customerDataRow["Global Parent Customer"])
                    {
                        customerDetailOverviewExistingParentCompanyTypeGlobalParentOriginalValue = true;
                    }
                    else
                    {
                        customerDetailOverviewExistingParentCompanyTypeGlobalParentOriginalValue = false;
                    }
                    if ((bool)customerDataRow["Top Parent Customer"])
                    {
                        customerDetailOverviewExistingParentCompanyTypeTopParentOriginalValue = true;
                    }
                    else
                    {
                        customerDetailOverviewExistingParentCompanyTypeTopParentOriginalValue = false;
                    }
                    customerDetailOverviewFirstNameOriginalValue = customerDataRow["First Name"].ToString();
                    customerDetailOverviewGlobalParentCustomerIdOriginalValue = (Guid)customerDataRow["Global Parent Customer Id"];
                    customerDetailOverviewLastNameOriginalValue = customerDataRow["Last Name"].ToString();
                    customerDetailOverviewSalesRegionIdOriginalValue = (Guid)customerDataRow["Sales Region Id"];
                    customerDetailOverviewSalesSubRegionIdOriginalValue = (Guid)customerDataRow["Sales Sub Region Id"];
                    customerDetailOverviewTelephoneNumberOriginalValue = customerDataRow["Telephone Number"].ToString();
                    customerDetailOverviewTopParentCustomerIdOriginalValue = (Guid)customerDataRow["Top Parent Customer Id"];
                    customerDetailShippingInformationAddressLine1OriginalValue = customerDataRow["Shipping Address Line 1"].ToString();
                    customerDetailShippingInformationAddressLine2OriginalValue = customerDataRow["Shipping Address Line 2"].ToString();
                    customerDetailShippingInformationAddressLine3OriginalValue = customerDataRow["Shipping Address Line 3"].ToString();
                    customerDetailShippingInformationAddressLine4OriginalValue = customerDataRow["Shipping Address Line 4"].ToString();
                    customerDetailShippingInformationAddressLine5OriginalValue = customerDataRow["Shipping Address Line 5"].ToString();
                    customerDetailShippingInformationCompanyNameOriginalValue = customerDataRow["Shipping Company Name"].ToString();
                    customerDetailShippingInformationEmailAddressOriginalValue = customerDataRow["Shipping Email Address"].ToString();
                    customerDetailShippingInformationFirstNameOriginalValue = customerDataRow["Shipping First Name"].ToString();
                    customerDetailShippingInformationLastNameOriginalValue = customerDataRow["Shipping Last Name"].ToString();
                    customerDetailShippingInformationTelephoneNumberOriginalValue = customerDataRow["Shipping Telephone Number"].ToString();
                }
                else
                {
                    MessageBox.Show($"No data found for the specified {dataSubject}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load {dataSubject} details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CustomerDetailTabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (customerDetailTabControl.SelectedTab == customerDetailTabControl.TabPages["customerDetailTabControlCustomerContactPage"])
            {
                await CustomerDetailExistingCustomerContact_Load(sender, e);
            }
            if (customerDetailTabControl.SelectedTab == customerDetailTabControl.TabPages["customerDetailTabControlCustomerNotePage"])
            {
                await CustomerDetailExistingCustomerNote_Load(sender, e);
            }
        }

        private async Task CustomerDetailExistingCustomerContact_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string storedProcedureName = "[dbo].[spGetAllCustomerContactForCustomer]";
            string dataSubject = "Existing Customer Contacts";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@customerId",
                    ParameterValue = _customerId
                }
            };

            DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No Existing Customer Contacts found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataTable.DefaultView.Sort = "Created Timestamp DESC";
                customerDetailCustomerNoteExistingCustomerNoteDataGridView.AutoGenerateColumns = true;
                customerDetailCustomerNoteExistingCustomerNoteDataGridView.DataSource = dataTable;
                customerDetailCustomerNoteExistingCustomerNoteDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if (customerDetailCustomerNoteExistingCustomerNoteDataGridView.Columns.Contains("Details"))
                {
                    customerDetailCustomerNoteExistingCustomerNoteDataGridView.Columns.Remove("Details");
                }
                DataGridViewLinkColumn customerNoteDetailLink = new DataGridViewLinkColumn
                {
                    HeaderText = "Details",
                    Text = "View Customer Contact",
                    UseColumnTextForLinkValue = true,
                    Name = "Details"
                };
                customerDetailCustomerNoteExistingCustomerNoteDataGridView.Columns.Add(customerNoteDetailLink);
            }
        }

        private async Task CustomerDetailExistingCustomerNote_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string storedProcedureName = "[dbo].[spGetAllNoteForCustomer]";
            string dataSubject = "Existing Customer Notes";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@customerId",
                    ParameterValue = _customerId
                }
            };

            DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No Existing Customer Notes found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataTable.DefaultView.Sort = "Created Timestamp DESC";
                customerDetailCustomerNoteExistingCustomerNoteDataGridView.AutoGenerateColumns = true;
                customerDetailCustomerNoteExistingCustomerNoteDataGridView.DataSource = dataTable;
                customerDetailCustomerNoteExistingCustomerNoteDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if (customerDetailCustomerNoteExistingCustomerNoteDataGridView.Columns.Contains("Details"))
                {
                    customerDetailCustomerNoteExistingCustomerNoteDataGridView.Columns.Remove("Details");
                }
                DataGridViewLinkColumn customerNoteDetailLink = new DataGridViewLinkColumn
                {
                    HeaderText = "Details",
                    Text = "View Customer Note",
                    UseColumnTextForLinkValue = true,
                    Name = "Details"
                };
                customerDetailCustomerNoteExistingCustomerNoteDataGridView.Columns.Add(customerNoteDetailLink);
            }
        }

        private void customerDetailCustomerContactExistingCustomerContactDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == customerDetailCustomerContactExistingCustomerContactDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (customerDetailCustomerContactExistingCustomerContactDataGridView.Columns.Contains("Customer Contact Id"))
                    {
                        Guid customerContactId = (Guid)customerDetailCustomerContactExistingCustomerContactDataGridView.Rows[e.RowIndex].Cells["Customer Contact Id"].Value;
                        ContactDetail contactDetail = new ContactDetail("Customer", customerContactId);
                        contactDetail.Show();
                    }
                    else
                    {
                        MessageBox.Show("Customer Contact Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open Customer Contact details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void customerDetailCustomerNoteExistingCustomerNoteDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == customerDetailCustomerNoteExistingCustomerNoteDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (customerDetailCustomerNoteExistingCustomerNoteDataGridView.Columns.Contains("Customer Note Id"))
                    {
                        Guid customerNoteId = (Guid)customerDetailCustomerNoteExistingCustomerNoteDataGridView.Rows[e.RowIndex].Cells["Customer Note Id"].Value;
                        NoteDetail noteDetail = new NoteDetail("Customer", customerNoteId);
                        noteDetail.Show();
                    }
                    else
                    {
                        MessageBox.Show("Customer Note Id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open Customer Note details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void customerDetailUpdateCustomerButton_Click(object sender, EventArgs e)
        {
            string customerBillingInformationAddressLine1 = customerDetailBillingInformationAddressLine1Textbox.Text.TrimEnd();
            string? customerBillingInformationAddressLine2 = customerDetailBillingInformationAddressLine2Textbox.Text.TrimEnd();
            string customerBillingInformationAddressLine3 = customerDetailBillingInformationAddressLine3Textbox.Text.TrimEnd();
            string customerBillingInformationAddressLine4 = customerDetailBillingInformationAddressLine4Textbox.Text.TrimEnd();
            string customerBillingInformationAddressLine5 = customerDetailBillingInformationAddressLine5Textbox.Text.TrimEnd();
            string? customerBillingInformationCompanyName = customerDetailBillingInformationCompanyNameTextbox.Text.TrimEnd();
            string customerBillingInformationEmailAddress = customerDetailBillingInformationEmailAddressTextbox.Text.TrimEnd();
            string customerBillingInformationFirstName = customerDetailBillingInformationFirstNameTextbox.Text.TrimEnd();
            string customerBillingInformationLastName = customerDetailBillingInformationLastNameTextbox.Text.TrimEnd();
            string customerBillingInformationTelephoneNumber = customerDetailBillingInformationTelephoneNumberTextbox.Text.TrimEnd();

            bool customerFinanceCreditEnabled = customerDetailFinanceCreditEnabledCheckbox.Checked;
            decimal customerFinanceCreditLimit = decimal.Parse($"{customerDetailFinanceCreditLimitTextboxA.Text.TrimEnd()}.{customerDetailFinanceCreditLimitTextboxB.Text.TrimEnd()}");
            Guid customerFinancePaymentCurrencyId = Guid.Parse(customerDetailFinancePaymentCurrencyComboBox.SelectedValue.ToString());
            byte customerFinancePaymentDays = byte.Parse(customerDetailFinancePaymentDaysTextbox.Text.TrimEnd());
            string? customerFinanceVATNumber = customerDetailFinanceVATNumberTextbox.Text.TrimEnd();

            Guid customerOverviewAccountManagerId = Guid.Parse(customerDetailOverviewAccountManagerComboBox.SelectedValue.ToString());
            bool customerOverviewActiveStatus = customerDetailOverviewActiveStatusCheckbox.Checked;
            string? customerOverviewCompanyName = customerDetailOverviewCompanyNameTextbox.Text.TrimEnd();
            DateTime customerOverviewCustomerSince = customerDetailOverviewCustomerSinceDatePicker.Value.Date;
            Guid customerOverviewCustomerTierId = Guid.Parse(customerDetailOverviewCustomerTierComboBox.SelectedValue.ToString());
            Guid customerOverviewCustomerTypeId = Guid.Parse(customerDetailOverviewCustomerTypeComboBox.SelectedValue.ToString());
            string customerOverviewEmailAddress = customerDetailOverviewEmailAddressTextbox.Text.TrimEnd();
            Guid? customerOverviewExistingGlobalParentCustomerId = null;
            if (customerDetailOverviewGlobalParentCustomerComboBox.SelectedValue != null)
            {
                customerOverviewExistingGlobalParentCustomerId = Guid.Parse(customerDetailOverviewGlobalParentCustomerComboBox.SelectedValue.ToString());
            }
            Guid? customerOverviewExistingTopParentCustomerId = null;
            if (customerDetailOverviewTopParentCustomerComboBox.SelectedValue != null)
            {
                customerOverviewExistingTopParentCustomerId = Guid.Parse(customerDetailOverviewTopParentCustomerComboBox.SelectedValue.ToString());
            }
            string customerOverviewFirstName = customerDetailOverviewFirstNameTextbox.Text.TrimEnd();
            string customerOverviewLastName = customerDetailOverviewLastNameTextbox.Text.TrimEnd();
            Guid customerOverviewSalesSubRegionId = Guid.Parse(customerDetailOverviewSalesSubRegionComboBox.SelectedValue.ToString());
            string customerOverviewTelephoneNumber = customerDetailOverviewTelephoneNumberTextbox.Text.TrimEnd();
            bool customerOverviewWillBeGlobalParent = customerDetailOverviewWillBeGlobalParentRadioButton.Checked;
            bool customerOverviewWillBeTopParent = customerDetailOverviewWillBeTopParentRadioButton.Checked;

            string customerShippingInformationAddressLine1 = customerDetailShippingInformationAddressLine1Textbox.Text.TrimEnd();
            string? customerShippingInformationAddressLine2 = customerDetailShippingInformationAddressLine2Textbox.Text.TrimEnd();
            string customerShippingInformationAddressLine3 = customerDetailShippingInformationAddressLine3Textbox.Text.TrimEnd();
            string customerShippingInformationAddressLine4 = customerDetailShippingInformationAddressLine4Textbox.Text.TrimEnd();
            string customerShippingInformationAddressLine5 = customerDetailShippingInformationAddressLine5Textbox.Text.TrimEnd();
            string? customerShippingInformationCompanyName = customerDetailShippingInformationCompanyNameTextbox.Text.TrimEnd();
            string customerShippingInformationEmailAddress = customerDetailShippingInformationEmailAddressTextbox.Text.TrimEnd();
            string customerShippingInformationFirstName = customerDetailShippingInformationFirstNameTextbox.Text.TrimEnd();
            string customerShippingInformationLastName = customerDetailShippingInformationLastNameTextbox.Text.TrimEnd();
            string customerShippingInformationTelephoneNumber = customerDetailShippingInformationTelephoneNumberTextbox.Text.TrimEnd();

            string dataSubject = "Customer";

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
                    Name = "CustomerOverviewExistingGlobalParentCustomerId",
                    Value = customerOverviewExistingGlobalParentCustomerId,
                    ValueType = typeof(Guid)
                });
            }

            if (customerOverviewExistingTopParentCustomerId != null && customerOverviewExistingTopParentCustomerId != Guid.Empty)
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    Name = "CustomerOverviewExistingTopParentCustomerId",
                    Value = customerOverviewExistingTopParentCustomerId,
                    ValueType = typeof(Guid)
                });
            }

            if (!string.IsNullOrEmpty(customerShippingInformationAddressLine2))
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
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
                    }
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

                string storedProcedureName = "[dbo].[spUpdateCustomer]";
                string operationType = "update";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters.ToArray(), dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
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
            customerDetailBillingInformationAddressLine1Textbox.ReadOnly = !customerDetailBillingInformationAddressLine1Textbox.ReadOnly;
            customerDetailBillingInformationAddressLine2Textbox.ReadOnly = !customerDetailBillingInformationAddressLine2Textbox.ReadOnly;
            customerDetailBillingInformationAddressLine3Textbox.ReadOnly = !customerDetailBillingInformationAddressLine3Textbox.ReadOnly;
            customerDetailBillingInformationAddressLine4Textbox.ReadOnly = !customerDetailBillingInformationAddressLine4Textbox.ReadOnly;
            customerDetailBillingInformationAddressLine5Textbox.ReadOnly = !customerDetailBillingInformationAddressLine5Textbox.ReadOnly;
            customerDetailBillingInformationCompanyNameTextbox.ReadOnly = !customerDetailBillingInformationCompanyNameTextbox.ReadOnly;
            customerDetailBillingInformationEmailAddressTextbox.ReadOnly = !customerDetailBillingInformationEmailAddressTextbox.ReadOnly;
            customerDetailBillingInformationFirstNameTextbox.ReadOnly = !customerDetailBillingInformationFirstNameTextbox.ReadOnly;
            customerDetailBillingInformationLastNameTextbox.ReadOnly = !customerDetailBillingInformationLastNameTextbox.ReadOnly;
            customerDetailBillingInformationTelephoneNumberTextbox.ReadOnly = !customerDetailBillingInformationTelephoneNumberTextbox.ReadOnly;
            customerDetailFinanceCreditEnabledCheckbox.Enabled = !customerDetailFinanceCreditEnabledCheckbox.Enabled;
            customerDetailFinanceCreditLimitTextboxA.ReadOnly = !customerDetailFinanceCreditLimitTextboxA.ReadOnly;
            customerDetailFinanceCreditLimitTextboxB.ReadOnly = !customerDetailFinanceCreditLimitTextboxB.ReadOnly;
            customerDetailFinancePaymentCurrencyComboBox.Enabled = !customerDetailFinancePaymentCurrencyComboBox.Enabled;
            customerDetailFinancePaymentDaysTextbox.ReadOnly = !customerDetailFinancePaymentDaysTextbox.ReadOnly;
            customerDetailFinanceVATRegisteredCheckbox.Enabled = !customerDetailFinanceVATRegisteredCheckbox.Enabled;
            customerDetailFinanceVATNumberTextbox.ReadOnly = !customerDetailFinanceVATNumberTextbox.ReadOnly;
            customerDetailOverviewAccountManagerComboBox.Enabled = !customerDetailOverviewAccountManagerComboBox.Enabled;
            customerDetailOverviewActiveStatusCheckbox.Enabled = !customerDetailOverviewActiveStatusCheckbox.Enabled;
            customerDetailOverviewCompanyNameTextbox.ReadOnly = !customerDetailOverviewCompanyNameTextbox.ReadOnly;
            customerDetailOverviewCustomerSinceDatePicker.Enabled = !customerDetailOverviewCustomerSinceDatePicker.Enabled;
            customerDetailOverviewCustomerTierComboBox.Enabled = !customerDetailOverviewCustomerTierComboBox.Enabled;
            customerDetailOverviewCustomerTypeComboBox.Enabled = !customerDetailOverviewCustomerTypeComboBox.Enabled;
            customerDetailOverviewEmailAddressTextbox.ReadOnly = !customerDetailOverviewEmailAddressTextbox.ReadOnly;
            customerDetailOverviewExistingCustomerIsParentNoRadioButton.Enabled = !customerDetailOverviewExistingCustomerIsParentNoRadioButton.Enabled;
            customerDetailOverviewExistingCustomerIsParentYesRadioButton.Enabled = !customerDetailOverviewExistingCustomerIsParentYesRadioButton.Enabled;
            customerDetailOverviewExistingParentCompanyTypeGlobalParentRadioButton.Enabled = !customerDetailOverviewExistingParentCompanyTypeGlobalParentRadioButton.Enabled;
            customerDetailOverviewExistingParentCompanyTypeTopParentRadioButton.Enabled = !customerDetailOverviewExistingParentCompanyTypeTopParentRadioButton.Enabled;
            customerDetailOverviewFirstNameTextbox.ReadOnly = !customerDetailOverviewFirstNameTextbox.ReadOnly;
            customerDetailOverviewGlobalParentCustomerComboBox.Enabled = !customerDetailOverviewGlobalParentCustomerComboBox.Enabled;
            customerDetailOverviewLastNameTextbox.ReadOnly = !customerDetailOverviewLastNameTextbox.ReadOnly;
            customerDetailOverviewSalesRegionComboBox.Enabled = !customerDetailOverviewSalesRegionComboBox.Enabled;
            customerDetailOverviewSalesSubRegionComboBox.Enabled = !customerDetailOverviewSalesSubRegionComboBox.Enabled;
            customerDetailOverviewTelephoneNumberTextbox.ReadOnly = !customerDetailOverviewTelephoneNumberTextbox.ReadOnly;
            customerDetailOverviewTopParentCustomerComboBox.Enabled = !customerDetailOverviewTopParentCustomerComboBox.Enabled;
            customerDetailOverviewWillBeGlobalParentRadioButton.Enabled = !customerDetailOverviewWillBeGlobalParentRadioButton.Enabled;
            customerDetailOverviewWillBeTopParentRadioButton.Enabled = !customerDetailOverviewWillBeTopParentRadioButton.Enabled;
            customerDetailShippingInformationAddressLine1Textbox.ReadOnly = !customerDetailShippingInformationAddressLine1Textbox.ReadOnly;
            customerDetailShippingInformationAddressLine2Textbox.ReadOnly = !customerDetailShippingInformationAddressLine2Textbox.ReadOnly;
            customerDetailShippingInformationAddressLine3Textbox.ReadOnly = !customerDetailShippingInformationAddressLine3Textbox.ReadOnly;
            customerDetailShippingInformationAddressLine4Textbox.ReadOnly = !customerDetailShippingInformationAddressLine4Textbox.ReadOnly;
            customerDetailShippingInformationAddressLine5Textbox.ReadOnly = !customerDetailShippingInformationAddressLine5Textbox.ReadOnly;
            customerDetailShippingInformationCompanyNameTextbox.ReadOnly = !customerDetailShippingInformationCompanyNameTextbox.ReadOnly;
            customerDetailShippingInformationEmailAddressTextbox.ReadOnly = !customerDetailShippingInformationEmailAddressTextbox.ReadOnly;
            customerDetailShippingInformationFirstNameTextbox.ReadOnly = !customerDetailShippingInformationFirstNameTextbox.ReadOnly;
            customerDetailShippingInformationLastNameTextbox.ReadOnly = !customerDetailShippingInformationLastNameTextbox.ReadOnly;
            customerDetailShippingInformationTelephoneNumberTextbox.ReadOnly = !customerDetailShippingInformationTelephoneNumberTextbox.ReadOnly;
            customerDetailUpdateCustomerButton.Enabled = !customerDetailUpdateCustomerButton.Enabled;
        }

        private void customerDetailCustomerNoteCreateNewCustomerNoteButton_Click(object sender, EventArgs e)
        {
            CreateNote createNote = new CreateNote(_customerId, "CustomerNote");
            createNote.Show();
        }

        private async void customerDetailCustomerNoteRefreshDataButton_Click(object sender, EventArgs e)
        {
            await CustomerDetailExistingCustomerNote_Load(sender, e);
        }

        private void customerDetailCustomerContactCreateNewCustomerContactButton_Click(object sender, EventArgs e)
        {
            CreateContact createContact = new CreateContact(_customerId, "Customer");
            createContact.Show();
        }

        private async void customerDetailCustomerContactRefreshDataButton_Click(object sender, EventArgs e)
        {
            await CustomerDetailExistingCustomerContact_Load(sender, e);
        }
    }
}