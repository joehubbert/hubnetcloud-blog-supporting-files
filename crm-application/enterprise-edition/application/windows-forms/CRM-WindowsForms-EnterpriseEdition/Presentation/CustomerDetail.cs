using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CustomerDetail : Form
    {
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private readonly Guid _customerId;
        private string customerDetailTabControlBillingInformationTabPageAddressLine1OriginalValue;
        private string? customerDetailTabControlBillingInformationTabPageAddressLine2OriginalValue;
        private string customerDetailTabControlBillingInformationTabPageAddressLine3OriginalValue;
        private string customerDetailTabControlBillingInformationTabPageAddressLine4OriginalValue;
        private string customerDetailTabControlBillingInformationTabPageAddressLine5OriginalValue;
        private string customerDetailTabControlBillingInformationTabPageCompanyNameOriginalValue;
        private string customerDetailTabControlBillingInformationTabPageEmailAddressOriginalValue;
        private string customerDetailTabControlBillingInformationTabPageFirstNameOriginalValue;
        private string customerDetailTabControlBillingInformationTabPageLastNameOriginalValue;
        private string customerDetailTabControlBillingInformationTabPageTelephoneNumberOriginalValue;
        private bool customerDetailFinanceCreditEnabledOriginalValue;
        private decimal? customerDetailFinanceCreditLimitOriginalValue;
        private Guid customerDetailFinancePaymentCurrencyIdOriginalValue;
        private int customerDetailFinancePaymentDaysOriginalValue;
        private string? customerDetailFinanceVATNumberOriginalValue;
        private bool customerDetailFinanceVATRegisteredOriginalValue;
        private Guid customerDetailTabControlOverviewTabPageAccountManagerIdOriginalValue;
        private bool customerDetailTabControlOverviewTabPageActiveStatusOriginalValue;
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
            customerDetailTabControlFinanceTabPageCreditEnabledCheckbox.CheckedChanged += new EventHandler(CustomerDetailFinanceCreditEnabledCheckBox_CheckedChanged);
            customerDetailTabControlFinanceTabPagePaymentCurrencyComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            customerDetailTabControlFinanceTabPageVATRegisteredCheckbox.CheckedChanged += new EventHandler(CustomerDetailFinanceVATRegisteredCheckbox_CheckedChanged);
            customerDetailTabControlOverviewTabPageAccountManagerComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
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

            string dataSubject = "Customer Type";

            try
            {
                string storedProcedureName = "[dbo].[spGetAllCustomerType]";               
                DataTable? customerTypeData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var customerTypeList = customerTypeData.AsEnumerable()
                    .Select(row => new
                    {
                        CustomerTypeId = row.Field<Guid>("Customer Type Id"),
                        CustomerType = row.Field<string>("Customer Type")
                    })
                    .OrderBy(item => item.CustomerType)
                    .ToList();
                customerDetailTabControlOverviewTabPageCustomerTypeComboBox.DataSource = customerTypeList;
                customerDetailTabControlOverviewTabPageCustomerTypeComboBox.DisplayMember = "CustomerType";
                customerDetailTabControlOverviewTabPageCustomerTypeComboBox.ValueMember = "CustomerTypeId";
                customerDetailTabControlOverviewTabPageCustomerTypeComboBox.SelectedValue = customerTypeId;
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.Retrieval", dataSubject, ex.Message);
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

            string dataSubject = "Customer Tier";

            try
            {
                string storedProcedureName = "[dbo].[spGetAllCustomerTier]";                
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
                customerDetailTabControlOverviewTabPageCustomerTierComboBox.DataSource = customerTierList;
                customerDetailTabControlOverviewTabPageCustomerTierComboBox.DisplayMember = "DisplayText";
                customerDetailTabControlOverviewTabPageCustomerTierComboBox.ValueMember = "CustomerTierId";
                customerDetailTabControlOverviewTabPageCustomerTierComboBox.SelectedValue = customerTierId;
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async Task CustomerDetailOverviewLoadSalesRegionDataAsync(Guid salesRegionId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Sales Region";

            try
            {
                string storedProcedureName = "[dbo].[spGetAllSalesRegion]";               
                DataTable? salesRegionData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var salesRegionList = salesRegionData.AsEnumerable()
                    .Select(row => new
                    {
                        SalesRegionId = row.Field<Guid>("Sales Region Id"),
                        SalesRegion = row.Field<string>("Sales Region")
                    })
                    .OrderBy(item => item.SalesRegion)
                    .ToList();
                customerDetailTabControlOverviewTabPageSalesRegionComboBox.DataSource = salesRegionList;
                customerDetailTabControlOverviewTabPageSalesRegionComboBox.DisplayMember = "SalesRegion";
                customerDetailTabControlOverviewTabPageSalesRegionComboBox.ValueMember = "SalesRegionId";
                customerDetailTabControlOverviewTabPageSalesRegionComboBox.SelectedValue = salesRegionId;
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async void CustomerDetailOverviewSalesRegionComboBox_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
            await CustomerDetailLoadSalesSubRegionAsync((Guid)customerDetailTabControlOverviewTabPageSalesRegionComboBox.SelectedValue, (Guid)customerDetailTabControlOverviewTabPageSalesSubRegionComboBox.SelectedValue);
        }

        private async Task CustomerDetailLoadSalesSubRegionAsync(Guid salesRegionId, Guid salesSubRegionId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Sales Sub Region";

            try
            {
                string storedProcedureName = "[dbo].[spGetAllSalesSubRegion]";                
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
                customerDetailTabControlOverviewTabPageSalesSubRegionComboBox.DataSource = salesSubRegionList;
                customerDetailTabControlOverviewTabPageSalesSubRegionComboBox.DisplayMember = "SalesSubRegion";
                customerDetailTabControlOverviewTabPageSalesSubRegionComboBox.ValueMember = "SalesSubRegionId";
                customerDetailTabControlOverviewTabPageSalesSubRegionComboBox.SelectedValue = salesSubRegionId;
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async void CustomerDetailOverviewSalesRegionComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            await CustomerDetailLoadSalesSubRegionAsync((Guid)customerDetailTabControlOverviewTabPageSalesRegionComboBox.SelectedValue, (Guid)customerDetailTabControlOverviewTabPageSalesSubRegionComboBox.SelectedValue);
        }

        private async Task CustomerDetailOverviewLoadAccountManagerDataAsync(Guid accountManagerId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Account Manager";

            try
            {
                string storedProcedureName = "[dbo].[spGetAllAccountManager]";                
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
                customerDetailTabControlOverviewTabPageAccountManagerComboBox.DataSource = accountManagerList;
                customerDetailTabControlOverviewTabPageAccountManagerComboBox.DisplayMember = "DisplayText";
                customerDetailTabControlOverviewTabPageAccountManagerComboBox.ValueMember = "AccountManagerId";
                customerDetailTabControlOverviewTabPageAccountManagerComboBox.SelectedValue = accountManagerId;
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.Retrieval", dataSubject, ex.Message);
            }
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
                    await CustomerDetailOverviewLoadGlobalParentCustomerDataAsync((Guid)customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.SelectedValue);
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Warning.DataValidation.Selection", "Global Parent Customer");
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
                    await CustomerDetailOverviewLoadTopParentCustomerDataAsync((Guid)customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.SelectedValue);
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Warning.DataValidation.Selection", "Top Parent Customer");
                }
                customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.Enabled = true;
                customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.Enabled = false;
                customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.DataSource = null;
                customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.Items.Clear();
            }
        }

        private async Task CustomerDetailOverviewLoadGlobalParentCustomerDataAsync(Guid globalParentCustomerId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Global Parent Customer";

            try
            {
                string storedProcedureName = "[dbo].[spGetAllGlobalParentCustomer]";               
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
                customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.DataSource = globalParentCustomerList;
                customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.DisplayMember = "DisplayText";
                customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.ValueMember = "CustomerId";
                customerDetailTabControlOverviewTabPageGlobalParentCustomerComboBox.SelectedValue = globalParentCustomerId;
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async Task CustomerDetailOverviewLoadTopParentCustomerDataAsync(Guid topParentCustomerId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Top Parent Customer";

            try
            {
                string storedProcedureName = "[dbo].[spGetAllTopParentCustomer]";                
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
                customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.DataSource = topParentCustomerList;
                customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.DisplayMember = "DisplayText";
                customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.ValueMember = "CustomerId";
                customerDetailTabControlOverviewTabPageTopParentCustomerComboBox.SelectedValue = topParentCustomerId;
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.Retrieval", dataSubject, ex.Message);
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
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Customer.TopParent.TopParentRelationshipValidation");
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
                    ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Customer.GlobalParentType.CustomerTypeValidation");
                    customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Checked = false;
                }
            }
            else if (customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Checked && customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.Checked)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Customer.GlobalParent.GlobalParentRelationshipValidation");
                customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Checked = false;
                customerDetailTabControlOverviewTabPageWillBeParentRadioButtonPanelGlobalParentRadioButton.Enabled = false;
            }

            if (customerDetailTabControlOverviewTabPageExistingParentCompanyTypePanelGlobalParentRadioButton.Checked)
            {
                var selectedCustomerType = customerDetailTabControlOverviewTabPageCustomerTypeComboBox.Text;
                if (selectedCustomerType != "Business - Multinational")
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Customer.CustomerType.MultinationalValidation");
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

        private async Task CustomerDetailFinanceLoadCurrencyDataAsync(Guid paymentCurrencyId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Currency";

            try
            {
                string storedProcedureName = "[dbo].[spGetAllCurrency]";
                
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

                customerDetailTabControlFinanceTabPagePaymentCurrencyComboBox.DataSource = currencyList;
                customerDetailTabControlFinanceTabPagePaymentCurrencyComboBox.DisplayMember = "DisplayText";
                customerDetailTabControlFinanceTabPagePaymentCurrencyComboBox.ValueMember = "CurrencyId";
                customerDetailTabControlFinanceTabPagePaymentCurrencyComboBox.SelectedValue = paymentCurrencyId;
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.Retrieval", dataSubject, ex.Message);
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
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Database.ConnectionSettingsNotLoaded");
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

                    customerDetailTabControlBillingInformationTabPageAddressLine1Textbox.Text = customerDataRow["Billing Address Line 1"].ToString();
                    customerDetailTabControlBillingInformationTabPageAddressLine2Textbox.Text = customerDataRow["Billing Address Line 2"].ToString();
                    customerDetailTabControlBillingInformationTabPageAddressLine3Textbox.Text = customerDataRow["Billing Address Line 3"].ToString();
                    customerDetailTabControlBillingInformationTabPageAddressLine4Textbox.Text = customerDataRow["Billing Address Line 4"].ToString();
                    customerDetailTabControlBillingInformationTabPageAddressLine5Textbox.Text = customerDataRow["Billing Address Line 5"].ToString();
                    customerDetailTabControlBillingInformationTabPageCompanyNameTextbox.Text = customerDataRow["Billing Company Name"].ToString();
                    customerDetailTabControlBillingInformationTabPageEmailAddressTextbox.Text = customerDataRow["Billing Email Address"].ToString();
                    customerDetailTabControlBillingInformationTabPageFirstNameTextbox.Text = customerDataRow["Billing First Name"].ToString();
                    customerDetailTabControlBillingInformationTabPageLastNameTextbox.Text = customerDataRow["Billing Last Name"].ToString();
                    customerDetailTabControlBillingInformationTabPageTelephoneNumberTextbox.Text = customerDataRow["Billing Telephone Number"].ToString();
                    customerDetailTabControlFinanceTabPageCreditEnabledCheckbox.Checked = (bool)customerDataRow["Credit Enabled"];
                    string creditLimitPartA;
                    string creditLimitPartB;
                    SplitDecimal.SplitDecimalUsingDelimiter((decimal)customerDataRow["Credit Limit"], out creditLimitPartA, out creditLimitPartB);
                    customerDetailTabControlFinanceTabPageCreditLimitTextboxA.Text = creditLimitPartA;
                    customerDetailTabControlFinanceTabPageTextboxB.Text = creditLimitPartB;
                    string creditLimitUsedPartA;
                    string creditLimitUsedPartB;
                    SplitDecimal.SplitDecimalUsingDelimiter((decimal)customerDataRow["Credit Limit Used"], out creditLimitUsedPartA, out creditLimitUsedPartB);
                    customerDetailTabControlFinanceTabPageCreditLimitUsedTextboxA.Text = creditLimitUsedPartA;
                    customerDetailTabControlFinanceTabPageCreditLimitUsedTextboxB.Text = creditLimitUsedPartB;
                    string creditLimitUsedPercentagePartA;
                    string creditLimitUsedPercentagePartB;
                    SplitDecimal.SplitDecimalUsingDelimiter((decimal)customerDataRow["Credit Limit Used Percentage"], out creditLimitUsedPercentagePartA, out creditLimitUsedPercentagePartB);
                    customerDetailTabControlFinanceTabPageCreditLimitUsedPercentageTextboxA.Text = creditLimitUsedPercentagePartA;
                    customerDetailTabControlFinanceTabPageCreditLimitUsedPercentageTextboxB.Text = creditLimitUsedPercentagePartB;
                    customerDetailTabControlFinanceTabPageCreditEnabledCheckbox.Checked = (bool)customerDataRow["Credit Enabled"];
                    Guid paymentCurrencyId = (Guid)customerDataRow["Payment Currency Id"];
                    await CustomerDetailFinanceLoadCurrencyDataAsync(paymentCurrencyId);
                    customerDetailTabControlFinanceTabPagePaymentDaysTextbox.Text = customerDataRow["Payment Days"].ToString();
                    customerDetailTabControlFinanceTabPageVATNumberTextbox.Text = customerDataRow["VAT Number"].ToString();
                    Guid accountManagerId = (Guid)customerDataRow["Account Manager Id"];
                    await CustomerDetailOverviewLoadAccountManagerDataAsync(accountManagerId);
                    customerDetailTabControlOverviewTabPageActiveStatusCheckbox.Checked = (bool)customerDataRow["Active Status"];
                    customerDetailTabControlOverviewTabPageCompanyNameTextbox.Text = customerDataRow["Company Name"].ToString();
                    customerDetailTabControlOverviewTabPageCreatedByTextbox.Text = customerDataRow["Created By"].ToString();
                    customerDetailTabControlOverviewTabPageCreatedTimestampTextbox.Text = customerDataRow["Created Timestamp UTC"].ToString();
                    customerDetailTabControlOverviewTabPageCustomerIdTextbox.Text = customerDataRow["Customer Id"].ToString();
                    customerDetailTabControlOverviewTabPageCustomerSinceDatePicker.Value = (DateTime)customerDataRow["Customer Since"];
                    Guid customerTierId = (Guid)customerDataRow["Customer Tier Id"];
                    await CustomerDetailOverviewLoadCustomerTierDataAsync(customerTierId);
                    Guid customerTypeId = (Guid)customerDataRow["Customer Type Id"];
                    await CustomerDetailOverviewLoadCustomerTypeAsync(customerTypeId);
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
                        await CustomerDetailOverviewLoadGlobalParentCustomerDataAsync(existingGlobalParentCustomerId);
                    }
                    if (customerDataRow["Top Parent Customer Id"] != null)
                    {
                        Guid existingTopParentCustomerId = (Guid)customerDataRow["Top Parent Customer Id"];
                        await CustomerDetailOverviewLoadTopParentCustomerDataAsync(existingTopParentCustomerId);
                    }
                    customerDetailTabControlOverviewTabPageFirstNameTextbox.Text = customerDataRow["First Name"].ToString();
                    customerDetailTabControlOverviewTabPageLastNameTextbox.Text = customerDataRow["Last Name"].ToString();
                    customerDetailTabControlOverviewTabPageLastUpdatedByTextbox.Text = customerDataRow["Modified By"].ToString();
                    customerDetailTabControlOverviewTabPageLastUpdatedTimestampTextbox.Text = customerDataRow["Modified Timestamp UTC"].ToString();
                    Guid salesRegionId = (Guid)customerDataRow["Sales Region Id"];
                    await CustomerDetailOverviewLoadSalesRegionDataAsync(salesRegionId);
                    Guid salesSubRegionid = (Guid)customerDataRow["Sales Sub Region Id"];
                    await CustomerDetailLoadSalesSubRegionAsync(salesRegionId, salesSubRegionid);
                    customerDetailTabControlOverviewTabPageTelephoneNumberTextbox.Text = customerDataRow["Telephone Number"].ToString();
                    customerDetailTabControlShippingInformationTabPageAddressLine1Textbox.Text = customerDataRow["Shipping Address Line 1"].ToString();
                    customerDetailTabControlShippingInformationTabPageAddressLine2Textbox.Text = customerDataRow["Shipping Address Line 2"].ToString();
                    customerDetailTabControlShippingInformationTabPageAddressLine3Textbox.Text = customerDataRow["Shipping Address Line 3"].ToString();
                    customerDetailTabControlShippingInformationTabPageAddressLine4Textbox.Text = customerDataRow["Shipping Address Line 4"].ToString();
                    customerDetailTabControlShippingInformationTabPageAddressLine5Textbox.Text = customerDataRow["Shipping Address Line 5"].ToString();
                    customerDetailTabControlShippingInformationTabPageCompanyNameTextbox.Text = customerDataRow["Shipping Company Name"].ToString();
                    customerDetailTabControlShippingInformationTabPageEmailAddressTextbox.Text = customerDataRow["Shipping Email Address"].ToString();
                    customerDetailTabControlShippingInformationTabPageFirstNameTextbox.Text = customerDataRow["Shipping First Name"].ToString();
                    customerDetailTabControlShippingInformationTabPageLastNameTextbox.Text = customerDataRow["Shipping Last Name"].ToString();
                    customerDetailTabControlShippingInformationTabPageTelephoneNumberTextbox.Text = customerDataRow["Shipping Telephone Number"].ToString();

                    customerDetailTabControlBillingInformationTabPageAddressLine1OriginalValue = customerDataRow["Billing Address Line 1"].ToString();
                    customerDetailTabControlBillingInformationTabPageAddressLine2OriginalValue = customerDataRow["Billing Address Line 2"].ToString();
                    customerDetailTabControlBillingInformationTabPageAddressLine3OriginalValue = customerDataRow["Billing Address Line 3"].ToString();
                    customerDetailTabControlBillingInformationTabPageAddressLine4OriginalValue = customerDataRow["Billing Address Line 4"].ToString();
                    customerDetailTabControlBillingInformationTabPageAddressLine5OriginalValue = customerDataRow["Billing Address Line 5"].ToString();
                    customerDetailTabControlBillingInformationTabPageCompanyNameOriginalValue = customerDataRow["Billing Company Name"].ToString();
                    customerDetailTabControlBillingInformationTabPageEmailAddressOriginalValue = customerDataRow["Billing Email Address"].ToString();
                    customerDetailTabControlBillingInformationTabPageFirstNameOriginalValue = customerDataRow["Billing First Name"].ToString();
                    customerDetailTabControlBillingInformationTabPageLastNameOriginalValue = customerDataRow["Billing Last Name"].ToString();
                    customerDetailTabControlBillingInformationTabPageTelephoneNumberOriginalValue = customerDataRow["Billing Telephone Number"].ToString();
                    customerDetailFinanceCreditEnabledOriginalValue = (bool)customerDataRow["Credit Enabled"];
                    customerDetailFinanceCreditLimitOriginalValue = (decimal)customerDataRow["Credit Limit"];
                    customerDetailFinancePaymentCurrencyIdOriginalValue = (Guid)customerDataRow["Payment Currency Id"];
                    customerDetailFinancePaymentDaysOriginalValue = (int)customerDataRow["Payment Days"];
                    if (customerDataRow["VAT Number"] != DBNull.Value && customerDataRow["VAT Number"] != null)
                    {
                        customerDetailFinanceVATNumberOriginalValue = customerDataRow["VAT Number"].ToString();
                        customerDetailFinanceVATRegisteredOriginalValue = true;
                    }
                    customerDetailTabControlOverviewTabPageAccountManagerIdOriginalValue = (Guid)customerDataRow["Account Manager Id"];
                    customerDetailTabControlOverviewTabPageActiveStatusOriginalValue = (bool)customerDataRow["Active Status"];
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

                    this.Text += $" ({customerDetailShippingInformationCompanyNameOriginalValue})";
                }
                else
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Information.NoDataFound", dataSubject);
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.Retrieval", dataSubject, ex.Message);
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
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Database.ConnectionSettingsNotLoaded");
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
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Information.NoDataFound", dataSubject);
            }
            else
            {
                dataTable.DefaultView.Sort = "Created Timestamp DESC";
                customerDetailTabControlCustomerContactTabPageDataGridView.AutoGenerateColumns = true;
                customerDetailTabControlCustomerContactTabPageDataGridView.DataSource = dataTable;
                customerDetailTabControlCustomerContactTabPageDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if (customerDetailTabControlCustomerContactTabPageDataGridView.Columns.Contains("Details"))
                {
                    customerDetailTabControlCustomerContactTabPageDataGridView.Columns.Remove("Details");
                }
                DataGridViewLinkColumn customerContactDetailLink = new DataGridViewLinkColumn
                {
                    HeaderText = "Details",
                    Text = "View Customer Contact",
                    UseColumnTextForLinkValue = true,
                    Name = "Details"
                };
                customerDetailTabControlCustomerContactTabPageDataGridView.Columns.Add(customerContactDetailLink);
            }
        }

        private async Task CustomerDetailExistingCustomerLead_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Database.ConnectionSettingsNotLoaded");
                return;
            }

            string storedProcedureName = "[dbo].[spGetAllCustomerLeadForCustomer]";
            string dataSubject = "Existing Customer Leads";

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
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Information.NoDataFound", dataSubject);
            }
            else
            {
                dataTable.DefaultView.Sort = "Created Timestamp DESC";
                customerDetailTabControlCustomerLeadTabPageDataGridView.AutoGenerateColumns = true;
                customerDetailTabControlCustomerLeadTabPageDataGridView.DataSource = dataTable;
                customerDetailTabControlCustomerLeadTabPageDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if (customerDetailTabControlCustomerLeadTabPageDataGridView.Columns.Contains("Details"))
                {
                    customerDetailTabControlCustomerLeadTabPageDataGridView.Columns.Remove("Details");
                }
                DataGridViewLinkColumn customerLeadDetailLink = new DataGridViewLinkColumn
                {
                    HeaderText = "Details",
                    Text = "View Customer Lead",
                    UseColumnTextForLinkValue = true,
                    Name = "Details"
                };
                customerDetailTabControlCustomerLeadTabPageDataGridView.Columns.Add(customerLeadDetailLink);
            }
        }

        private async Task CustomerDetailExistingCustomerNote_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Database.ConnectionSettingsNotLoaded");
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
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Information.NoDataFound", dataSubject);
            }
            else
            {
                dataTable.DefaultView.Sort = "Created Timestamp DESC";
                customerDetailTabControlCustomerNoteTabPageDataGridView.AutoGenerateColumns = true;
                customerDetailTabControlCustomerNoteTabPageDataGridView.DataSource = dataTable;
                customerDetailTabControlCustomerNoteTabPageDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if (customerDetailTabControlCustomerNoteTabPageDataGridView.Columns.Contains("Details"))
                {
                    customerDetailTabControlCustomerNoteTabPageDataGridView.Columns.Remove("Details");
                }
                DataGridViewLinkColumn customerNoteDetailLink = new DataGridViewLinkColumn
                {
                    HeaderText = "Details",
                    Text = "View Customer Note",
                    UseColumnTextForLinkValue = true,
                    Name = "Details"
                };
                customerDetailTabControlCustomerNoteTabPageDataGridView.Columns.Add(customerNoteDetailLink);
            }
        }

        private void customerDetailCustomerContactExistingCustomerContactDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == customerDetailTabControlCustomerContactTabPageDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                string dataSubject = "Customer Contact";

                try
                {
                    if (customerDetailTabControlCustomerContactTabPageDataGridView.Columns.Contains("Customer Contact Id"))
                    {
                        Guid customerContactId = (Guid)customerDetailTabControlCustomerContactTabPageDataGridView.Rows[e.RowIndex].Cells["Customer Contact Id"].Value;
                        ContactDetail contactDetail = new ContactDetail("Customer", customerContactId);
                        contactDetail.Show();
                    }
                    else
                    {
                        ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.IdColumnNotFound", dataSubject);
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.Retrieval", dataSubject, ex.Message);
                }
            }
        }

        private void customerDetailTabControlCustomerLeadTabPageDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == customerDetailTabControlCustomerLeadTabPageDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                string dataSubject = "Customer Lead";

                try
                {
                    if (customerDetailTabControlCustomerLeadTabPageDataGridView.Columns.Contains("Customer Lead Id"))
                    {
                        Guid customerLeadId = (Guid)customerDetailTabControlCustomerLeadTabPageDataGridView.Rows[e.RowIndex].Cells["Customer Lead Id"].Value;
                        CustomerLeadDetail customerLeadDetail = new CustomerLeadDetail(_customerId, customerLeadId);
                        customerLeadDetail.Show();
                    }
                    else
                    {
                        ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.IdColumnNotFound", dataSubject);
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.Retrieval", dataSubject, ex.Message);
                }
            }
        }

        private void customerDetailTabControlCustomerNoteTabPageDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == customerDetailTabControlCustomerNoteTabPageDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                string dataSubject = "Customer Note";

                try
                {
                    if (customerDetailTabControlCustomerNoteTabPageDataGridView.Columns.Contains("Customer Note Id"))
                    {
                        Guid customerNoteId = (Guid)customerDetailTabControlCustomerNoteTabPageDataGridView.Rows[e.RowIndex].Cells["Customer Note Id"].Value;
                        NoteDetail noteDetail = new NoteDetail("Customer", customerNoteId);
                        noteDetail.Show();
                    }
                    else
                    {
                        ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.IdColumnNotFound", dataSubject);
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.Retrieval", dataSubject, ex.Message);
                }
            }
        }

        private async void customerDetailUpdateCustomerButton_Click(object sender, EventArgs e)
        {
            string customerBillingInformationAddressLine1 = customerDetailTabControlBillingInformationTabPageAddressLine1Textbox.Text.TrimEnd();
            string? customerBillingInformationAddressLine2 = customerDetailTabControlBillingInformationTabPageAddressLine2Textbox.Text.TrimEnd();
            string customerBillingInformationAddressLine3 = customerDetailTabControlBillingInformationTabPageAddressLine3Textbox.Text.TrimEnd();
            string customerBillingInformationAddressLine4 = customerDetailTabControlBillingInformationTabPageAddressLine4Textbox.Text.TrimEnd();
            string customerBillingInformationAddressLine5 = customerDetailTabControlBillingInformationTabPageAddressLine5Textbox.Text.TrimEnd();
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
            string customerShippingInformationAddressLine5 = customerDetailTabControlShippingInformationTabPageAddressLine5Textbox.Text.TrimEnd();
            string? customerShippingInformationCompanyName = customerDetailTabControlShippingInformationTabPageCompanyNameTextbox.Text.TrimEnd();
            string customerShippingInformationEmailAddress = customerDetailTabControlShippingInformationTabPageEmailAddressTextbox.Text.TrimEnd();
            string customerShippingInformationFirstName = customerDetailTabControlShippingInformationTabPageFirstNameTextbox.Text.TrimEnd();
            string customerShippingInformationLastName = customerDetailTabControlShippingInformationTabPageLastNameTextbox.Text.TrimEnd();
            string customerShippingInformationTelephoneNumber = customerDetailTabControlShippingInformationTabPageTelephoneNumberTextbox.Text.TrimEnd();

            string dataSubject = "Customer";

            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Database.ConnectionSettingsNotLoaded");
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
            customerDetailTabControlBillingInformationTabPageAddressLine1Textbox.ReadOnly = !customerDetailTabControlBillingInformationTabPageAddressLine1Textbox.ReadOnly;
            customerDetailTabControlBillingInformationTabPageAddressLine2Textbox.ReadOnly = !customerDetailTabControlBillingInformationTabPageAddressLine2Textbox.ReadOnly;
            customerDetailTabControlBillingInformationTabPageAddressLine3Textbox.ReadOnly = !customerDetailTabControlBillingInformationTabPageAddressLine3Textbox.ReadOnly;
            customerDetailTabControlBillingInformationTabPageAddressLine4Textbox.ReadOnly = !customerDetailTabControlBillingInformationTabPageAddressLine4Textbox.ReadOnly;
            customerDetailTabControlBillingInformationTabPageAddressLine5Textbox.ReadOnly = !customerDetailTabControlBillingInformationTabPageAddressLine5Textbox.ReadOnly;
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
            customerDetailTabControlShippingInformationTabPageAddressLine5Textbox.ReadOnly = !customerDetailTabControlShippingInformationTabPageAddressLine5Textbox.ReadOnly;
            customerDetailTabControlShippingInformationTabPageCompanyNameTextbox.ReadOnly = !customerDetailTabControlShippingInformationTabPageCompanyNameTextbox.ReadOnly;
            customerDetailTabControlShippingInformationTabPageEmailAddressTextbox.ReadOnly = !customerDetailTabControlShippingInformationTabPageEmailAddressTextbox.ReadOnly;
            customerDetailTabControlShippingInformationTabPageFirstNameTextbox.ReadOnly = !customerDetailTabControlShippingInformationTabPageFirstNameTextbox.ReadOnly;
            customerDetailTabControlShippingInformationTabPageLastNameTextbox.ReadOnly = !customerDetailTabControlShippingInformationTabPageLastNameTextbox.ReadOnly;
            customerDetailTabControlShippingInformationTabPageTelephoneNumberTextbox.ReadOnly = !customerDetailTabControlShippingInformationTabPageTelephoneNumberTextbox.ReadOnly;
            customerDetailUpdateCustomerButton.Enabled = !customerDetailUpdateCustomerButton.Enabled;
        }

        private void customerDetailTabControlCustomerContactTabPageCreateNewCustomerContactButton_Click(object sender, EventArgs e)
        {
            CreateContact createContact = new CreateContact(_customerId, "Customer");
            createContact.Show();
        }

        private async void customerDetailTabControlCustomerContactTabPageRefreshDataButton_Click(object sender, EventArgs e)
        {
            await CustomerDetailExistingCustomerContact_Load(sender, e);
        }

        private void customerDetailTabControlCustomerLeadTabPageCreateNewCustomerLeadButton_Click(object sender, EventArgs e)
        {
            CreateCustomerLead createCustomerLead = new CreateCustomerLead(_customerId);
            createCustomerLead.Show();
        }

        private async void customerDetailTabControlCustomerLeadTabPageRefreshDataButton_Click(object sender, EventArgs e)
        {
            await CustomerDetailExistingCustomerLead_Load(sender, e);
        }

        private void customerDetailTabControlCustomerNoteTabPageCreateNewCustomerNoteButton_Click(object sender, EventArgs e)
        {
            CreateNote createNote = new CreateNote(_customerId, "CustomerNote");
            createNote.Show();
        }

        private async void customerDetailTabControlCustomerNoteTabPageRefreshDataButton_Click(object sender, EventArgs e)
        {
            await CustomerDetailExistingCustomerNote_Load(sender, e);
        }
    }
}