using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CompanyConfigurationDetail : Form
    {
        private readonly Guid _companyConfigurationId;
        private byte[]? _companyLogoImageBytes = null;
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private byte[]? companyLogoImageBytesOriginalValue;
        private bool? generalInformationActiveStatusOriginalValue;
        private string? generalInformationAddressLine1OriginalValue;
        private string? generalInformationAddressLine2OriginalValue;
        private string? generalInformationAddressLine3OriginalValue;
        private string? generalInformationAddressLine4OriginalValue;
        private Guid? generalInformationAddressLine5OriginalValue;
        private string? generalInformationCompanyNameOriginalValue;
        private string? generalInformationEmailAddressOriginalValue;
        private string? generalInformationEmailTopLevelDomainOriginalValue;
        private string? generalInformationTelephoneNumberOriginalValue;
        private string? generalInformationWebsiteURLOriginalValue;
        private string? financialInformationBankAccountAddressLine1OriginalValue;
        private string? financialInformationBankAccountAddressLine2OriginalValue;
        private string? financialInformationBankAccountAddressLine3OriginalValue;
        private string? financialInformationBankAccountAddressLine4OriginalValue;
        private Guid? financialInformationBankAccountAddressLine5OriginalValue;
        private string? financialInformationBankAccountIBANOriginalValue;
        private string? financialInformationBankAccountNameOriginalValue;
        private string? financialInformationBankAccountNumberOriginalValue;
        private string? financialInformationBankAccountSortCodeOriginalValue;
        private string? financialInformationBankAccountSWIFTCodeOriginalValue;
        private string? financialInformationBankAccountVippsIdOriginalValue;
        private string? financialInformationVATNumberOriginalValue;
        private bool? financialInformationVATRegisteredOriginalValue;

        // Track edit mode state
        private bool _isEditMode = false;

        public CompanyConfigurationDetail(Guid companyConfigurationId)
        {
            InitializeComponent();
            InitializeEventHandlers();
            _companyConfigurationId = companyConfigurationId;
        }

        private void InitializeEventHandlers()
        {
            companyConfigurationDetailTabControl.SelectedIndexChanged += CompanyConfigurationDetailTabControl_SelectedIndexChanged;
            companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine5ComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine5ComboBox.SelectedIndexChanged += companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine5ComboBox_SelectedIndexChanged;
            companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVATRegisteredCheckbox.CheckedChanged += companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVATRegisteredCheckBox_CheckedChanged;
            companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine5ComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            companyConfigurationDetailToggleEditModeButton.Click += companyConfigurationDetailToggleEditModeButton_Click;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task LoadCountryAsync(string countryContext, Guid countryId)
        {
            switch (countryContext)
            {
                case "FinancialInformation":
                    _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine5ComboBox, "spGetAllCountry", null, true, "Country Id", countryId);
                    await _dataAccessComboBoxHelper.LoadDataAsync();
                    break;
                case "GeneralInformation":
                    _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine5ComboBox, "spGetAllCountry", null, true, "Country Id", countryId);
                    await _dataAccessComboBoxHelper.LoadDataAsync();
                    break;
                default:
                    throw new ArgumentException("Invalid Country context specified.");
            }
        }

        private async Task LoadCurrencyDataAsync(Guid currencyId)
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountCurrencyComboBox, "spGetAllCurrency", null, true, "Currency Id", currencyId);
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private void companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVATRegisteredCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVATRegisteredCheckbox.Checked)
            {
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVATRegisteredCheckbox.Enabled = true;
            }
            else
            {
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVATRegisteredCheckbox.Enabled = false;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVATNumberTextBox.Text = string.Empty;
            }
        }

        private void companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine5ComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var selectedItem = companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine5ComboBox.SelectedItem;
            string? isoCountryCode = null;

            if (selectedItem != null)
            {
                var displayTextProp = selectedItem.GetType().GetProperty("DisplayText");
                if (displayTextProp != null)
                {
                    var displayText = displayTextProp.GetValue(selectedItem) as string;
                    if (!string.IsNullOrEmpty(displayText))
                    {
                        // ISO code is before the first " - "
                        isoCountryCode = displayText.Split(' ')[0];
                    }
                }
            }

            // Enable/disable controls based on the ISO country code
            if (isoCountryCode == "GB")
            {
                // Enable sort code fields, disable Vipps
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxA.Enabled = true;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxA.ReadOnly = false;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxB.Enabled = true;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxB.ReadOnly = false;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxC.Enabled = true;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxC.ReadOnly = false;
            }
            else if (isoCountryCode == "DK" || isoCountryCode == "FI" || isoCountryCode == "NO" || isoCountryCode == "SE")
            {
                // Enable Vipps, disable sort code fields
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxA.Enabled = false;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxA.ReadOnly = true;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxA.Text = string.Empty;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxB.Enabled = false;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxB.ReadOnly = true;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxB.Text = string.Empty;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxC.Enabled = false;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxC.ReadOnly = true;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxC.Text = string.Empty;
            }
            else
            {
                // Disable both
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxA.Enabled = false;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxA.ReadOnly = true;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxA.Text = string.Empty;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxB.Enabled = false;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxB.ReadOnly = true;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxB.Text = string.Empty;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxC.Enabled = false;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxC.ReadOnly = true;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxC.Text = string.Empty;
            }

            // Always update VippsId textbox state after country change
            UpdateVippsIdTextBoxState();
        }

        // Centralized logic for VippsId textbox state
        private void UpdateVippsIdTextBoxState()
        {
            var selectedItem = companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine5ComboBox.SelectedItem;
            string? isoCountryCode = null;

            if (selectedItem != null)
            {
                var displayTextProp = selectedItem.GetType().GetProperty("DisplayText");
                if (displayTextProp != null)
                {
                    var displayText = displayTextProp.GetValue(selectedItem) as string;
                    if (!string.IsNullOrEmpty(displayText))
                    {
                        isoCountryCode = displayText.Split(' ')[0];
                    }
                }
            }

            if (isoCountryCode == "DK" || isoCountryCode == "FI" || isoCountryCode == "NO" || isoCountryCode == "SE")
            {
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVippsIdTextBox.Enabled = _isEditMode;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVippsIdTextBox.ReadOnly = !_isEditMode;
            }
            else
            {
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVippsIdTextBox.Enabled = false;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVippsIdTextBox.ReadOnly = true;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVippsIdTextBox.Text = string.Empty;
            }
        }

        private async void CompanyConfigurationDetailCompanyConfigurationInformation_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            string dataSubject = "Company Configuration";
            string storedProcedureName = "spGetCompanyConfiguration";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "companyConfigurationId",
                    ParameterValue = _companyConfigurationId
                }
            };

            try
            {
                DataTable? companyConfigurationDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject);

                if (companyConfigurationDataTable != null)
                {
                    DataRow companyConfigurationDataRow = companyConfigurationDataTable.Rows[0];
                    if (companyConfigurationDataRow["Company Logo"] != DBNull.Value)
                    {
                        companyConfigurationDetailTabControlCompanyLogoTabPageCompanyLogoImagePictureBox.Image = ImageHelper.ByteArrayToImage((byte[])companyConfigurationDataRow["Company Logo"]);
                    }
                    else
                    {
                        companyConfigurationDetailTabControlCompanyLogoTabPageCompanyLogoImagePictureBox.Image = null;
                    }
                    companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine1TextBox.Text = companyConfigurationDataRow["Bank Account Address Line 1"].ToString();
                    companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine2TextBox.Text = companyConfigurationDataRow["Bank Account Address Line 2"].ToString();
                    companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine3TextBox.Text = companyConfigurationDataRow["Bank Account Address Line 3"].ToString();
                    companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine4TextBox.Text = companyConfigurationDataRow["Bank Account Address Line 4"].ToString();
                    Guid bankAccountAddressLine5 = (Guid)companyConfigurationDataRow["Bank Account Address Line 5"];
                    await LoadCountryAsync("FinancialInformation", bankAccountAddressLine5);
                    string bankAccountBalanceA;
                    string bankAccountBalanceB;
                    SplitDecimalHelper.SplitDecimalUsingDelimiter((decimal)companyConfigurationDataRow["Bank Account Balance"], out bankAccountBalanceA, out bankAccountBalanceB);
                    companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountBalanceTextBoxA.Text = bankAccountBalanceA;
                    companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountBalanceTextBoxB.Text = bankAccountBalanceB;
                    Guid bankAccountCurrencyId = (Guid)companyConfigurationDataRow["Bank Account Currency Id"];
                    await LoadCurrencyDataAsync(bankAccountCurrencyId);
                    companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountIBANTextBox.Text = companyConfigurationDataRow["Bank Account IBAN"].ToString();
                    companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountNameTextBox.Text = companyConfigurationDataRow["Bank Account Name"].ToString();
                    companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountNumberTextBox.Text = companyConfigurationDataRow["Bank Account Number"].ToString();
                    string bankAccountSortCode = companyConfigurationDataRow["Bank Account Sort Code"].ToString();
                    string bankAccountSortCodeA = string.Empty;
                    string bankAccountSortCodeB = string.Empty;
                    string bankAccountSortCodeC = string.Empty;
                    if (!string.IsNullOrEmpty(bankAccountSortCode))
                    {
                        var parts = bankAccountSortCode.Split('-');
                        if (parts.Length == 3)
                        {
                            bankAccountSortCodeA = parts[0];
                            bankAccountSortCodeB = parts[1];
                            bankAccountSortCodeC = parts[2];
                        }
                    }
                    companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxA.Text = bankAccountSortCodeA;
                    companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxB.Text = bankAccountSortCodeB;
                    companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxC.Text = bankAccountSortCodeC;
                    companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSWIFTCodeTextBox.Text = companyConfigurationDataRow["Bank Account SWIFT Code"].ToString();
                    companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVATNumberTextBox.Text = companyConfigurationDataRow["VAT Number"].ToString();
                    if (companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVATNumberTextBox != null)
                    {
                        companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVATRegisteredCheckbox.Checked = true;
                    }
                    else
                    {
                        companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVATRegisteredCheckbox.Checked = false;
                    }
                    if (companyConfigurationDataRow["Bank Account Vipps Id"].ToString() != null)
                    {
                        companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVippsIdTextBox.Text = companyConfigurationDataRow["Bank Account Vipps Id"].ToString();
                    }
                    else
                    {
                        companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVippsIdTextBox.Text = null;
                    }
                    companyConfigurationDetailTabControlGeneralInformationTabPageActiveStatusCheckbox.Checked = (bool)companyConfigurationDataRow["Active Status"];
                    companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine1TextBox.Text = companyConfigurationDataRow["Address Line 1"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine2TextBox.Text = companyConfigurationDataRow["Address Line 2"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine3TextBox.Text = companyConfigurationDataRow["Address Line 3"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine4TextBox.Text = companyConfigurationDataRow["Address Line 4"].ToString();
                    Guid addressLine5 = (Guid)companyConfigurationDataRow["Address Line 5"];
                    await LoadCountryAsync("GeneralInformation", addressLine5);
                    companyConfigurationDetailTabControlGeneralInformationTabPageCompanyConfigurationIdTextBox.Text = companyConfigurationDataRow["Company Configuration Id"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageCompanyNameTextBox.Text = companyConfigurationDataRow["Company Name"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageCreatedByTextBox.Text = companyConfigurationDataRow["Created By"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageCreatedTimestampTextBox.Text = companyConfigurationDataRow["Created Timestamp UTC"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageEmailAddressTextBox.Text = companyConfigurationDataRow["Email Address"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox.Text = companyConfigurationDataRow["Email Top Level Domain"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageLastUpdatedByTextBox.Text = companyConfigurationDataRow["Modified By"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageLastUpdatedTimestampTextBox.Text = companyConfigurationDataRow["Modified Timestamp UTC"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageTelephoneNumberTextBox.Text = companyConfigurationDataRow["Telephone Number"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageWebsiteURLTextBox.Text = companyConfigurationDataRow["Website URL"].ToString();

                    companyLogoImageBytesOriginalValue = (byte[])companyConfigurationDataRow["Company Logo"];
                    financialInformationBankAccountAddressLine1OriginalValue = companyConfigurationDataRow["Bank Account Address Line 1"].ToString();
                    financialInformationBankAccountAddressLine2OriginalValue = companyConfigurationDataRow["Bank Account Address Line 2"].ToString();
                    financialInformationBankAccountAddressLine3OriginalValue = companyConfigurationDataRow["Bank Account Address Line 3"].ToString();
                    financialInformationBankAccountAddressLine4OriginalValue = companyConfigurationDataRow["Bank Account Address Line 4"].ToString();
                    financialInformationBankAccountAddressLine5OriginalValue = (Guid)companyConfigurationDataRow["Bank Account Address Line 5"];
                    financialInformationBankAccountIBANOriginalValue = companyConfigurationDataRow["Bank Account IBAN"].ToString();
                    financialInformationBankAccountNameOriginalValue = companyConfigurationDataRow["Bank Account Name"].ToString();
                    financialInformationBankAccountNumberOriginalValue = companyConfigurationDataRow["Bank Account Number"].ToString();
                    financialInformationBankAccountSortCodeOriginalValue = companyConfigurationDataRow["Bank Account Sort Code"].ToString();
                    financialInformationBankAccountSWIFTCodeOriginalValue = companyConfigurationDataRow["Bank Account SWIFT Code"].ToString();
                    if (companyConfigurationDataRow["Bank Account Vipps Id"].ToString() != null)
                    {
                        financialInformationBankAccountVippsIdOriginalValue = companyConfigurationDataRow["Bank Account Vipps Id"].ToString();
                    }
                    else
                    {
                        financialInformationBankAccountVippsIdOriginalValue = null;
                    }
                    financialInformationVATNumberOriginalValue = companyConfigurationDataRow["VAT Number"].ToString();
                    financialInformationVATRegisteredOriginalValue = (bool)companyConfigurationDataRow["VAT Registered"];
                    generalInformationActiveStatusOriginalValue = (bool)companyConfigurationDataRow["Active Status"];
                    generalInformationAddressLine1OriginalValue = companyConfigurationDataRow["Address Line 1"].ToString();
                    generalInformationAddressLine2OriginalValue = companyConfigurationDataRow["Address Line 2"].ToString();
                    generalInformationAddressLine3OriginalValue = companyConfigurationDataRow["Address Line 3"].ToString();
                    generalInformationAddressLine4OriginalValue = companyConfigurationDataRow["Address Line 4"].ToString();
                    generalInformationAddressLine5OriginalValue = (Guid)companyConfigurationDataRow["Address Line 5"];
                    generalInformationCompanyNameOriginalValue = companyConfigurationDataRow["Company Name"].ToString();
                    generalInformationEmailAddressOriginalValue = companyConfigurationDataRow["Email Address"].ToString();
                    generalInformationEmailTopLevelDomainOriginalValue = companyConfigurationDataRow["Email Top Level Domain"].ToString();
                    generalInformationTelephoneNumberOriginalValue = companyConfigurationDataRow["Telephone Number"].ToString();
                    generalInformationWebsiteURLOriginalValue = companyConfigurationDataRow["Website URL"].ToString();

                    this.Text += $" ({generalInformationCompanyNameOriginalValue})";
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

        private async void CompanyConfigurationDetailTabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (companyConfigurationDetailTabControl.SelectedTab == companyConfigurationDetailTabControl.TabPages["companyConfigurationDetailTabControlHTMLTemplateTabPage"])
            {
                await CompanyConfigurationDetailExistingHTMLTemplate_Load(sender, e);
            }
        }

        private async Task CompanyConfigurationDetailExistingHTMLTemplate_Load(object sender, EventArgs e)
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            string dataSubject = "Existing HTML Templates";
            string storedProcedureName = "spGetAllHTMLTemplateForCompanyConfiguration";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "companyConfigurationId",
                    ParameterValue = _companyConfigurationId
                }
            };

            DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject);

            if (dataTable.Rows.Count == 0)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Information.NoDataFound", dataSubject);
            }
            else
            {
                dataTable.DefaultView.Sort = "Created Timestamp DESC";
                companyConfigurationDetailTabControlHTMLTemplateTabPageDataGridView.AutoGenerateColumns = true;
                companyConfigurationDetailTabControlHTMLTemplateTabPageDataGridView.DataSource = dataTable;
                companyConfigurationDetailTabControlHTMLTemplateTabPageDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if (companyConfigurationDetailTabControlHTMLTemplateTabPageDataGridView.Columns.Contains("Details"))
                {
                    companyConfigurationDetailTabControlHTMLTemplateTabPageDataGridView.Columns.Remove("Details");
                }
                DataGridViewLinkColumn htmlTemplateDetailLink = new DataGridViewLinkColumn
                {
                    HeaderText = "Details",
                    Text = "View HTML Template",
                    UseColumnTextForLinkValue = true,
                    Name = "Details"
                };
                companyConfigurationDetailTabControlHTMLTemplateTabPageDataGridView.Columns.Add(htmlTemplateDetailLink);
            }
        }

        private async void companyConfigurationDetailUpdateCompanyConfigurationButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = companyConfigurationDetailTabControlGeneralInformationTabPageActiveStatusCheckbox.Checked;
            string addressLine1 = companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine1TextBox.Text.TrimEnd();
            string addressLine2 = companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine2TextBox.Text.TrimEnd();
            string addressLine3 = companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine3TextBox.Text.TrimEnd();
            string addressLine4 = companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine4TextBox.Text.TrimEnd();
            Guid addressLine5 = (Guid)companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine5ComboBox.SelectedValue;
            string bankAccountAddressLine1 = companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine1TextBox.Text.TrimEnd();
            string bankAccountAddressLine2 = null;
            if (companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine2TextBox != null)
            {
                bankAccountAddressLine2 = companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine2TextBox.Text.TrimEnd();
            }
            string bankAccountAddressLine3 = companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine3TextBox.Text.TrimEnd();
            string bankAccountAddressLine4 = companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine4TextBox.Text.TrimEnd();
            Guid bankAccountAddressLine5 = (Guid)companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine5ComboBox.SelectedValue;
            Guid bankAccountCurrencyId = (Guid)companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountCurrencyComboBox.SelectedValue;
            string bankAccountIBAN = companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountIBANTextBox.Text.TrimEnd();
            string bankAccountName = companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountNameTextBox.Text.TrimEnd();
            string bankAccountNumber = companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountNumberTextBox.Text.TrimEnd();
            string bankAccountSortCode = null;
            string bankAccountSortCodePartA = companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxA?.Text.TrimEnd() ?? "";
            string bankAccountSortCodePartB = companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxB?.Text.TrimEnd() ?? "";
            string bankAccountSortCodePartC = companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxC?.Text.TrimEnd() ?? "";
            if (!string.IsNullOrEmpty(bankAccountSortCodePartA) && !string.IsNullOrEmpty(bankAccountSortCodePartB) && !string.IsNullOrEmpty(bankAccountSortCodePartC))
            {
                bankAccountSortCode = $"{bankAccountSortCodePartA}-{bankAccountSortCodePartB}-{bankAccountSortCodePartC}";
            }
            string bankAccountSWIFTCode = companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSWIFTCodeTextBox.Text.TrimEnd();
            string bankAccountVippsId = null;
            if (companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVippsIdTextBox != null)
            {
                bankAccountVippsId = companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVippsIdTextBox.Text.TrimEnd();
            }
            byte[] companyLogo = null;
            if (_companyLogoImageBytes != null)
            {
                companyLogo = _companyLogoImageBytes;
            }
            else
            {
                companyLogo = Array.Empty<byte>();
            }
            string companyName = companyConfigurationDetailTabControlGeneralInformationTabPageCompanyNameTextBox.Text.TrimEnd();
            string emailAddress = companyConfigurationDetailTabControlGeneralInformationTabPageEmailAddressTextBox.Text.TrimEnd();
            string emailTopLevelDomain = companyConfigurationDetailTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox.Text.TrimEnd();
            string telephoneNumber = companyConfigurationDetailTabControlGeneralInformationTabPageTelephoneNumberTextBox.Text.TrimEnd();
            string vatNumber = companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVATNumberTextBox.Text.TrimEnd();
            bool vatRegistered = companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVATRegisteredCheckbox.Checked;
            string websiteURL = companyConfigurationDetailTabControlGeneralInformationTabPageWebsiteURLTextBox.Text.TrimEnd();

            string dataSubject = "Company Configuration";

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
                    Name = "Active Status",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Address Line 1",
                    Value = addressLine1,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Address Line 3",
                    Value = addressLine3,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Address Line 4",
                    Value = addressLine4,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Address Line 5",
                    Value = addressLine5,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Bank Account Address Line 1",
                    Value = bankAccountAddressLine1,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Bank Account Address Line 3",
                    Value = bankAccountAddressLine3,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Bank Account Address Line 4",
                    Value = bankAccountAddressLine4,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Bank Account Address Line 5",
                    Value = bankAccountAddressLine5,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Bank Account Currency Id",
                    Value = bankAccountCurrencyId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Bank Account IBAN",
                    Value = bankAccountIBAN,
                    MaxLength = 34,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Bank Account Name",
                    Value = bankAccountName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Bank Account Number",
                    Value = bankAccountNumber,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Bank Account SWIFT Code",
                    Value = bankAccountSWIFTCode,
                    MaxLength = 11,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Company Logo",
                    Value = companyLogo,
                    ValueType = typeof(byte[])
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Company Name",
                    Value = companyName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Email Address",
                    Value = emailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Email Top Level Domain",
                    Value = emailTopLevelDomain,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Telephone Number",
                    Value = telephoneNumber,
                    MaxLength = 13,
                    ValueType = typeof(string)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "VAT Registered",
                    Value = vatRegistered,
                    ValueType = typeof(bool)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Website URL",
                    Value = websiteURL,
                    MaxLength = 50,
                    ValueType = typeof(string)
                }
            };

            if (!string.IsNullOrEmpty(addressLine2))
            {
                dataToValidate.Add(new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Address Line 2",
                    Value = addressLine2,
                    MaxLength = 50,
                    ValueType = typeof(string)
                });
            }

            if (!string.IsNullOrEmpty(bankAccountAddressLine2))
            {
                dataToValidate.Add(new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Bank Account Address Line 2",
                    Value = bankAccountAddressLine2,
                    MaxLength = 50,
                    ValueType = typeof(string)
                });
            }

            if (!string.IsNullOrEmpty(bankAccountSortCode))
            {
                dataToValidate.Add(new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Bank Account Sort Code",
                    Value = bankAccountSortCode,
                    MaxLength = 8,
                    ValueType = typeof(string)
                });
            }

            if (!string.IsNullOrEmpty(bankAccountVippsId))
            {
                dataToValidate.Add(new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Bank Account Vipps Id",
                    Value = bankAccountVippsId,
                    MaxLength = 50,
                    ValueType = typeof(string)
                });
            }

            if (!string.IsNullOrEmpty(vatNumber))
            {
                dataToValidate.Add(new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "VAT Number",
                    Value = vatNumber,
                    MaxLength = 50,
                    ValueType = typeof(string)
                });
            }

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
                        VariableName = "Active Status",
                        VariableType = "bool",
                        OriginalValue = generalInformationActiveStatusOriginalValue,
                        NewValue = activeStatus
                    },
                    new ChangeDetail
                    {
                        VariableName = "Address Line 1",
                        VariableType = "string",
                        OriginalValue = generalInformationAddressLine1OriginalValue,
                        NewValue = addressLine1
                    },
                    new ChangeDetail
                    {
                        VariableName = "Address Line 3",
                        VariableType = "string",
                        OriginalValue = generalInformationAddressLine3OriginalValue,
                        NewValue = addressLine3
                    },
                    new ChangeDetail
                    {
                        VariableName = "Address Line 4",
                        VariableType = "string",
                        OriginalValue = generalInformationAddressLine4OriginalValue,
                        NewValue = addressLine4
                    },
                    new ChangeDetail
                    {
                        VariableName = "Address Line 5",
                        VariableType = "Guid",
                        OriginalValue = generalInformationAddressLine5OriginalValue,
                        NewValue = addressLine5
                    },
                    new ChangeDetail
                    {
                        VariableName = "Bank Account Address Line 1",
                        VariableType = "string",
                        OriginalValue = financialInformationBankAccountAddressLine1OriginalValue,
                        NewValue = bankAccountAddressLine1
                    },
                    new ChangeDetail
                    {
                        VariableName = "Bank Account Address Line 3",
                        VariableType = "string",
                        OriginalValue = financialInformationBankAccountAddressLine3OriginalValue,
                        NewValue = bankAccountAddressLine3
                    },
                    new ChangeDetail
                    {
                        VariableName = "Bank Account Address Line 4",
                        VariableType = "string",
                        OriginalValue = financialInformationBankAccountAddressLine4OriginalValue,
                        NewValue = bankAccountAddressLine4
                    },
                    new ChangeDetail
                    {
                        VariableName = "Bank Account Address Line 5",
                        VariableType = "Guid",
                        OriginalValue = financialInformationBankAccountAddressLine5OriginalValue,
                        NewValue = bankAccountAddressLine5
                    },
                    new ChangeDetail
                    {
                        VariableName = "Bank Account IBAN",
                        VariableType = "string",
                        OriginalValue = financialInformationBankAccountIBANOriginalValue,
                        NewValue = bankAccountIBAN
                    },
                    new ChangeDetail
                    {
                        VariableName = "Bank Account Name",
                        VariableType = "string",
                        OriginalValue = financialInformationBankAccountNameOriginalValue,
                        NewValue = bankAccountName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Bank Account Number",
                        VariableType = "string",
                        OriginalValue = financialInformationBankAccountNumberOriginalValue,
                        NewValue = bankAccountNumber
                    },
                    new ChangeDetail
                    {
                        VariableName = "Bank Account SWIFT Code",
                        VariableType = "string",
                        OriginalValue = financialInformationBankAccountSWIFTCodeOriginalValue,
                        NewValue = bankAccountSWIFTCode
                    },
                    new ChangeDetail
                    {
                        VariableName = "Company Logo",
                        VariableType = "byte[]",
                        OriginalValue = companyLogoImageBytesOriginalValue,
                        NewValue = companyLogo
                    },
                    new ChangeDetail
                    {
                        VariableName = "Company Name",
                        VariableType = "string",
                        OriginalValue = generalInformationCompanyNameOriginalValue,
                        NewValue = companyName
                    },
                    new ChangeDetail
                    {
                        VariableName = "Email Address",
                        VariableType = "string",
                        OriginalValue = generalInformationEmailAddressOriginalValue,
                        NewValue = emailAddress
                    },
                    new ChangeDetail
                    {
                        VariableName = "Email Top Level Domain",
                        VariableType = "string",
                        OriginalValue = generalInformationEmailTopLevelDomainOriginalValue,
                        NewValue = emailTopLevelDomain
                    },
                    new ChangeDetail
                    {
                        VariableName = "Telephone Number",
                        VariableType = "string",
                        OriginalValue = generalInformationTelephoneNumberOriginalValue,
                        NewValue = telephoneNumber
                    },
                    new ChangeDetail
                    {
                        VariableName = "VAT Registered",
                        VariableType = "bool",
                        OriginalValue = financialInformationVATRegisteredOriginalValue,
                        NewValue = vatRegistered
                    },
                    new ChangeDetail
                    {
                        VariableName = "Website URL",
                        VariableType = "string",
                        OriginalValue = generalInformationWebsiteURLOriginalValue,
                        NewValue = websiteURL
                    }
                };

                if (!string.IsNullOrEmpty(addressLine2))
                {
                    changesList.Add(new ChangeDetail
                    {
                        VariableName = "Address Line 2",
                        VariableType = "string",
                        OriginalValue = generalInformationAddressLine2OriginalValue,
                        NewValue = addressLine2
                    });
                }

                if (!string.IsNullOrEmpty(bankAccountAddressLine2))
                {
                    changesList.Add(new ChangeDetail
                    {
                        VariableName = "Bank Account Address Line 2",
                        VariableType = "string",
                        OriginalValue = financialInformationBankAccountAddressLine2OriginalValue,
                        NewValue = bankAccountAddressLine2
                    });
                }

                if (!string.IsNullOrEmpty(bankAccountSortCode))
                {
                    changesList.Add(new ChangeDetail
                    {
                        VariableName = "Bank Account Sort Code",
                        VariableType = "string",
                        OriginalValue = financialInformationBankAccountSortCodeOriginalValue,
                        NewValue = bankAccountSortCode
                    });
                }

                if (!string.IsNullOrEmpty(bankAccountVippsId))
                {
                    changesList.Add(new ChangeDetail
                    {
                        VariableName = "Bank Account Vipps Id",
                        VariableType = "string",
                        OriginalValue = financialInformationBankAccountVippsIdOriginalValue,
                        NewValue = bankAccountVippsId
                    });
                }

                if (!string.IsNullOrEmpty(vatNumber))
                {
                    changesList.Add(new ChangeDetail
                    {
                        VariableName = "VAT Number",
                        VariableType = "string",
                        OriginalValue = financialInformationVATNumberOriginalValue,
                        NewValue = bankAccountVippsId
                    });
                }

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = UpdateConfirmationService.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
                {
                    var parameters = new List<Parameter>
                    {
                        new Parameter
                        {
                            ParameterName = "activeStatus",
                            ParameterValue = activeStatus
                        },
                        new Parameter
                        {
                            ParameterName = "addressLine1",
                            ParameterValue = addressLine1
                        },
                        new Parameter
                        {
                            ParameterName = "addressLine3",
                            ParameterValue = addressLine3
                        },
                        new Parameter
                        {
                            ParameterName = "addressLine4",
                            ParameterValue = addressLine4
                        },
                        new Parameter
                        {
                            ParameterName = "addressLine5",
                            ParameterValue = addressLine5
                        },
                        new Parameter
                        {
                            ParameterName = "bankAccountAddressLine1",
                            ParameterValue = bankAccountAddressLine1
                        },
                        new Parameter
                        {
                            ParameterName = "bankAccountAddressLine3",
                            ParameterValue = bankAccountAddressLine3
                        },
                        new Parameter
                        {
                            ParameterName = "bankAccountAddressLine4",
                            ParameterValue = bankAccountAddressLine4
                        },
                        new Parameter
                        {
                            ParameterName = "bankAccountAddressLine5",
                            ParameterValue = bankAccountAddressLine5
                        },
                        new Parameter
                        {
                            ParameterName = "bankAccountCurrencyId",
                            ParameterValue = bankAccountCurrencyId
                        },
                        new Parameter
                        {
                            ParameterName = "bankAccountIBAN",
                            ParameterValue = bankAccountIBAN
                        },
                        new Parameter
                        {
                            ParameterName = "bankAccountName",
                            ParameterValue = bankAccountName
                        },
                        new Parameter
                        {
                            ParameterName = "bankAccountNumber",
                            ParameterValue = bankAccountNumber
                        },
                        new Parameter
                        {
                            ParameterName = "bankAccountSWIFTCode",
                            ParameterValue = bankAccountSWIFTCode
                        },
                        new Parameter
                        {
                            ParameterName = "companyLogo",
                            ParameterValue = companyLogo
                        },
                        new Parameter
                        {
                            ParameterName = "companyName",
                            ParameterValue = companyName
                        },
                        new Parameter
                        {
                            ParameterName = "emailAddress",
                            ParameterValue = emailAddress
                        },
                        new Parameter
                        {
                            ParameterName = "emailTopLevelDomain",
                            ParameterValue = emailTopLevelDomain
                        },
                        new Parameter
                        {
                            ParameterName = "telephoneNumber",
                            ParameterValue = telephoneNumber
                        },
                        new Parameter
                        {
                            ParameterName = "vatRegistered",
                            ParameterValue = vatRegistered
                        },
                        new Parameter
                        {
                            ParameterName = "websiteURL",
                            ParameterValue = websiteURL
                        }
                    };

                    if (!string.IsNullOrEmpty(addressLine2))
                    {
                        parameters.Add(new Parameter
                        {
                            ParameterName = "addressLine2",
                            ParameterValue = addressLine2
                        });
                    }

                    if (!string.IsNullOrEmpty(bankAccountAddressLine2))
                    {
                        parameters.Add(new Parameter
                        {
                            ParameterName = "bankAccountAddressLine2",
                            ParameterValue = bankAccountAddressLine2
                        });
                    }

                    if (!string.IsNullOrEmpty(bankAccountSortCode))
                    {
                        parameters.Add(new Parameter
                        {
                            ParameterName = "bankAccountSortCode",
                            ParameterValue = bankAccountSortCode
                        });
                    }

                    if (!string.IsNullOrEmpty(bankAccountVippsId))
                    {
                        parameters.Add(new Parameter
                        {
                            ParameterName = "bankAccountVippsId",
                            ParameterValue = bankAccountVippsId
                        });
                    }

                    if (!string.IsNullOrEmpty(vatNumber))
                    {
                        parameters.Add(new Parameter
                        {
                            ParameterName = "vatNumber",
                            ParameterValue = vatNumber
                        });
                    }

                    string storedProcedureName = "spUpdateCompanyConfiguration";
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

        private void companyConfigurationDetailTabControlHTMLTemplateTabPageCreateHTMLTemplateButton_Click(object sender, EventArgs e)
        {
            CreateHTMLTemplate createHTMLTemplate = new CreateHTMLTemplate(_companyConfigurationId, generalInformationCompanyNameOriginalValue);
            createHTMLTemplate.Show();
        }

        private async void companyConfigurationDetailTabControlHTMLTemplateTabPageRefreshDataButton_Click(object sender, EventArgs e)
        {
            await CompanyConfigurationDetailExistingHTMLTemplate_Load(sender, e);
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            CompanyConfigurationDetailCompanyConfigurationInformation_Load(this, EventArgs.Empty);
        }

        private void companyConfigurationDetailToggleEditModeButton_Click(object sender, EventArgs e)
        {
            _isEditMode = !_isEditMode;

            companyConfigurationDetailTabControlCompanyLogoTabPageChooseCompanyLogoImageButton.Enabled = !companyConfigurationDetailTabControlCompanyLogoTabPageChooseCompanyLogoImageButton.Enabled;
            companyConfigurationDetailTabControlCompanyLogoTabPageRemoveCompanyLogoImageButton.Enabled = !companyConfigurationDetailTabControlCompanyLogoTabPageRemoveCompanyLogoImageButton.Enabled;
            companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine1TextBox.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine1TextBox.ReadOnly;
            companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine2TextBox.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine2TextBox.ReadOnly;
            companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine3TextBox.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine3TextBox.ReadOnly;
            companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine4TextBox.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine4TextBox.ReadOnly;
            companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine5ComboBox.Enabled = !companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountAddressLine5ComboBox.Enabled;
            companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountIBANTextBox.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountIBANTextBox.ReadOnly;
            companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountNameTextBox.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountNameTextBox.ReadOnly;
            companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountNumberTextBox.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountNumberTextBox.ReadOnly;
            if (companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxA != null &&
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxB != null &&
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxC != null)
            {
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxA.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxA.ReadOnly;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxB.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxB.ReadOnly;
                companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxC.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSortCodeMaskedTextBoxC.ReadOnly;
            }
            companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSWIFTCodeTextBox.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageBankAccountSWIFTCodeTextBox.ReadOnly;
            companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVATNumberTextBox.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVATNumberTextBox.ReadOnly;
            companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVATRegisteredCheckbox.Enabled = !companyConfigurationDetailTabControlFinancialInformationTabPageTabControlGeneralTabPageVATRegisteredCheckbox.Enabled;

            // Update VippsId textbox state based on edit mode and country
            UpdateVippsIdTextBoxState();

            companyConfigurationDetailTabControlGeneralInformationTabPageActiveStatusCheckbox.Enabled = !companyConfigurationDetailTabControlGeneralInformationTabPageActiveStatusCheckbox.Enabled;
            companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine1TextBox.ReadOnly = !companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine1TextBox.ReadOnly;
            companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine2TextBox.ReadOnly = !companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine2TextBox.ReadOnly;
            companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine3TextBox.ReadOnly = !companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine3TextBox.ReadOnly;
            companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine4TextBox.ReadOnly = !companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine4TextBox.ReadOnly;
            companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine5ComboBox.Enabled = !companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine5ComboBox.Enabled;
            companyConfigurationDetailTabControlGeneralInformationTabPageCompanyNameTextBox.ReadOnly = !companyConfigurationDetailTabControlGeneralInformationTabPageCompanyNameTextBox.ReadOnly;
            companyConfigurationDetailTabControlGeneralInformationTabPageEmailAddressTextBox.ReadOnly = !companyConfigurationDetailTabControlGeneralInformationTabPageEmailAddressTextBox.ReadOnly;
            companyConfigurationDetailTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox.ReadOnly = !companyConfigurationDetailTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox.ReadOnly;
            companyConfigurationDetailTabControlGeneralInformationTabPageTelephoneNumberTextBox.ReadOnly = !companyConfigurationDetailTabControlGeneralInformationTabPageTelephoneNumberTextBox.ReadOnly;
            companyConfigurationDetailTabControlGeneralInformationTabPageWebsiteURLTextBox.ReadOnly = !companyConfigurationDetailTabControlGeneralInformationTabPageWebsiteURLTextBox.ReadOnly;
            companyConfigurationDetailUpdateCompanyConfigurationButton.Enabled = !companyConfigurationDetailUpdateCompanyConfigurationButton.Enabled;
        }
    }
}