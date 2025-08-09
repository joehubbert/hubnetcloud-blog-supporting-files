using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CompanyConfigurationDetail : Form
    {
        private readonly Guid _companyConfigurationId;
        private byte[]? _companyLogoImageBytes = null;
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
            InitializeCustomComponents();
            _companyConfigurationId = companyConfigurationId;
        }

        private void InitializeCustomComponents()
        {
            companyConfigurationDetailTabControl.SelectedIndexChanged += new EventHandler(CompanyConfigurationDetailTabControl_SelectedIndexChanged);
            companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.SelectedIndexChanged += new EventHandler(CompanyConfigurationDetailFinancialInformationBankAccountAddressLine5ComboBox_SelectedIndexChanged);
            companyConfigurationDetailTabControlFinancialInformationTabPageVATRegisteredCheckbox.CheckedChanged += new EventHandler(CompanyConfigurationDetailFinancialInformationVATRegisteredCheckBox_CheckedChanged);
            companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine5ComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDown.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async Task CompanyConfigurationDetailLoadCountryAsync(string countryContext, Guid countryId)
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Country";

            try
            {
                string storedProcedureName = "[dbo].[spGetAllCountry]";
                DataTable? countryData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

                var countryList = countryData.AsEnumerable()
                    .Select(row => new
                    {
                        CountryId = row.Field<Guid>("Country Id"),
                        DisplayText = $"{row.Field<string>("ISO 3166-1 Alpha 2 Country Code")} - {row.Field<string>("Country English Name")}"
                    })
                    .OrderBy(item => item.DisplayText)
                    .ToList();
                switch (countryContext)
                {
                    case "FinancialInformation":
                        companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.DataSource = countryList;
                        companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.DisplayMember = "DisplayText";
                        companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.ValueMember = "CountryId";
                        companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.SelectedValue = countryId;
                        break;
                    case "GeneralInformation":
                        companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine5ComboBox.DataSource = countryList;
                        companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine5ComboBox.DisplayMember = "DisplayText";
                        companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine5ComboBox.ValueMember = "CountryId";
                        companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine5ComboBox.SelectedValue = countryId;
                        break;
                    default:
                        throw new ArgumentException("Invalid Country context specified.");
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private async Task CompanyConfigurationDetailLoadCurrencyDataAsync(Guid currencyId)
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

                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountCurrencyComboBox.DataSource = currencyList;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountCurrencyComboBox.DisplayMember = "DisplayText";
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountCurrencyComboBox.ValueMember = "CurrencyId";
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountCurrencyComboBox.SelectedValue = currencyId;
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private void CompanyConfigurationDetailFinancialInformationVATRegisteredCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (companyConfigurationDetailTabControlFinancialInformationTabPageVATRegisteredCheckbox.Checked)
            {
                companyConfigurationDetailTabControlFinancialInformationTabPageVATRegisteredCheckbox.Enabled = true;
            }
            else
            {
                companyConfigurationDetailTabControlFinancialInformationTabPageVATRegisteredCheckbox.Enabled = false;
                companyConfigurationDetailTabControlFinancialInformationTabPageVATNumberTextbox.Text = string.Empty;
            }
        }

        private void CompanyConfigurationDetailFinancialInformationBankAccountAddressLine5ComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var selectedItem = companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.SelectedItem;
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
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxA.Enabled = true;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxA.ReadOnly = false;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxB.Enabled = true;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxB.ReadOnly = false;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxC.Enabled = true;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxC.ReadOnly = false;
            }
            else if (isoCountryCode == "DK" || isoCountryCode == "FI" || isoCountryCode == "NO" || isoCountryCode == "SE")
            {
                // Enable Vipps, disable sort code fields
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxA.Enabled = false;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxA.ReadOnly = true;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxA.Text = string.Empty;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxB.Enabled = false;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxB.ReadOnly = true;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxB.Text = string.Empty;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxC.Enabled = false;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxC.ReadOnly = true;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxC.Text = string.Empty;
            }
            else
            {
                // Disable both
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxA.Enabled = false;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxA.ReadOnly = true;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxA.Text = string.Empty;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxB.Enabled = false;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxB.ReadOnly = true;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxB.Text = string.Empty;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxC.Enabled = false;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxC.ReadOnly = true;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxC.Text = string.Empty;
            }

            // Always update VippsId textbox state after country change
            UpdateVippsIdTextboxState();
        }

        // Centralized logic for VippsId textbox state
        private void UpdateVippsIdTextboxState()
        {
            var selectedItem = companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.SelectedItem;
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
                companyConfigurationDetailTabControlFinancialInformationTabPageVippsIdTextbox.Enabled = _isEditMode;
                companyConfigurationDetailTabControlFinancialInformationTabPageVippsIdTextbox.ReadOnly = !_isEditMode;
            }
            else
            {
                companyConfigurationDetailTabControlFinancialInformationTabPageVippsIdTextbox.Enabled = false;
                companyConfigurationDetailTabControlFinancialInformationTabPageVippsIdTextbox.ReadOnly = true;
                companyConfigurationDetailTabControlFinancialInformationTabPageVippsIdTextbox.Text = string.Empty;
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
            string storedProcedureName = "[dbo].[spGetCompanyConfiguration]";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@companyConfigurationId",
                    ParameterValue = _companyConfigurationId
                }
            };

            try
            {
                DataTable? companyConfigurationDataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

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
                    companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine1Textbox.Text = companyConfigurationDataRow["Bank Account Address Line 1"].ToString();
                    companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine2Textbox.Text = companyConfigurationDataRow["Bank Account Address Line 2"].ToString();
                    companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine3Textbox.Text = companyConfigurationDataRow["Bank Account Address Line 3"].ToString();
                    companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine4Textbox.Text = companyConfigurationDataRow["Bank Account Address Line 4"].ToString();
                    Guid bankAccountAddressLine5 = (Guid)companyConfigurationDataRow["Bank Account Address Line 5"];
                    await CompanyConfigurationDetailLoadCountryAsync("FinancialInformation", bankAccountAddressLine5);
                    string bankAccountBalanceA;
                    string bankAccountBalanceB;
                    SplitDecimal.SplitDecimalUsingDelimiter((decimal)companyConfigurationDataRow["Bank Account Balance"], out bankAccountBalanceA, out bankAccountBalanceB);
                    companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountBalanceTextboxA.Text = bankAccountBalanceA;
                    companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountBalanceTextboxB.Text = bankAccountBalanceB;
                    Guid bankAccountCurrencyId = (Guid)companyConfigurationDataRow["Bank Account Currency Id"];
                    await CompanyConfigurationDetailLoadCurrencyDataAsync(bankAccountCurrencyId);
                    companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountIBANTextbox.Text = companyConfigurationDataRow["Bank Account IBAN"].ToString();
                    companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountNameTextbox.Text = companyConfigurationDataRow["Bank Account Name"].ToString();
                    companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountNumberTextbox.Text = companyConfigurationDataRow["Bank Account Number"].ToString();
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
                    companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxA.Text = bankAccountSortCodeA;
                    companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxB.Text = bankAccountSortCodeB;
                    companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxC.Text = bankAccountSortCodeC;
                    companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSWIFTCodeTextbox.Text = companyConfigurationDataRow["Bank Account SWIFT Code"].ToString();
                    companyConfigurationDetailTabControlFinancialInformationTabPageVATNumberTextbox.Text = companyConfigurationDataRow["VAT Number"].ToString();
                    if (companyConfigurationDetailTabControlFinancialInformationTabPageVATNumberTextbox != null)
                    {
                        companyConfigurationDetailTabControlFinancialInformationTabPageVATRegisteredCheckbox.Checked = true;
                    }
                    else
                    {
                        companyConfigurationDetailTabControlFinancialInformationTabPageVATRegisteredCheckbox.Checked = false;
                    }
                    if (companyConfigurationDataRow["Bank Account Vipps Id"].ToString() != null)
                    {
                        companyConfigurationDetailTabControlFinancialInformationTabPageVippsIdTextbox.Text = companyConfigurationDataRow["Bank Account Vipps Id"].ToString();
                    }
                    else
                    {
                        companyConfigurationDetailTabControlFinancialInformationTabPageVippsIdTextbox.Text = null;
                    }
                    companyConfigurationDetailTabControlGeneralInformationTabPageActiveStatusCheckbox.Checked = (bool)companyConfigurationDataRow["Active Status"];
                    companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine1Textbox.Text = companyConfigurationDataRow["Address Line 1"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine2Textbox.Text = companyConfigurationDataRow["Address Line 2"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine3Textbox.Text = companyConfigurationDataRow["Address Line 3"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine4Textbox.Text = companyConfigurationDataRow["Address Line 4"].ToString();
                    Guid addressLine5 = (Guid)companyConfigurationDataRow["Address Line 5"];
                    await CompanyConfigurationDetailLoadCountryAsync("GeneralInformation", addressLine5);
                    companyConfigurationDetailTabControlGeneralInformationTabPageCompanyConfigurationIdTextbox.Text = companyConfigurationDataRow["Company Configuration Id"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageCompanyNameTextbox.Text = companyConfigurationDataRow["Company Name"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageCreatedByTextbox.Text = companyConfigurationDataRow["Created By"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageCreatedTimestampTextbox.Text = companyConfigurationDataRow["Created Timestamp UTC"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageEmailAddressTextbox.Text = companyConfigurationDataRow["Email Address"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageEmailTopLevelDomainTextbox.Text = companyConfigurationDataRow["Email Top Level Domain"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageLastUpdatedByTextbox.Text = companyConfigurationDataRow["Modified By"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageLastUpdatedTimestampTextbox.Text = companyConfigurationDataRow["Modified Timestamp UTC"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageTelephoneNumberTextbox.Text = companyConfigurationDataRow["Telephone Number"].ToString();
                    companyConfigurationDetailTabControlGeneralInformationTabPageWebsiteURLTextbox.Text = companyConfigurationDataRow["Website URL"].ToString();

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
                    if (financialInformationVATNumberOriginalValue != null)
                    {
                        financialInformationVATRegisteredOriginalValue = true;
                    }
                    else
                    {
                        financialInformationVATRegisteredOriginalValue = false;
                    }
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
            string storedProcedureName = "[dbo].[spGetAllHTMLTemplateForCompanyConfiguration]";

            var parameters = new[]
            {
                new Parameter
                {
                    ParameterName = "@companyConfigurationId",
                    ParameterValue = _companyConfigurationId
                }
            };

            DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject, _databaseConnectionSettings.DatabaseConnectionString);

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

        private void companyConfigurationDetailTabControlFinancialInformationTabPageAccountsPayableButton_Click(object sender, EventArgs e)
        {
            AccountsPayable accountsPayable = new AccountsPayable(_companyConfigurationId);
            accountsPayable.Show();
        }

        private void companyConfigurationDetailTabControlFinancialInformationTabPageAccountsReceivableButton_Click(object sender, EventArgs e)
        {
            AccountsReceivable accountsReceivable = new AccountsReceivable(_companyConfigurationId);
            accountsReceivable.Show();
        }

        private async void companyConfigurationDetailUpdateCompanyConfigurationButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = companyConfigurationDetailTabControlGeneralInformationTabPageActiveStatusCheckbox.Checked;
            string addressLine1 = companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine1Textbox.Text.TrimEnd();
            string addressLine2 = companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine2Textbox.Text.TrimEnd();
            string addressLine3 = companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine3Textbox.Text.TrimEnd();
            string addressLine4 = companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine4Textbox.Text.TrimEnd();
            Guid addressLine5 = (Guid)companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.SelectedValue;
            string bankAccountAddressLine1 = companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine1Textbox.Text.TrimEnd();
            string bankAccountAddressLine2 = null;
            if (companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine2Textbox != null)
            {
                bankAccountAddressLine2 = companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine2Textbox.Text.TrimEnd();
            }
            string bankAccountAddressLine3 = companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine3Textbox.Text.TrimEnd();
            string bankAccountAddressLine4 = companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine4Textbox.Text.TrimEnd();
            Guid bankAccountAddressLine5 = (Guid)companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.SelectedValue;
            Guid bankAccountCurrencyId = (Guid)companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountCurrencyComboBox.SelectedValue;
            string bankAccountIBAN = companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountIBANTextbox.Text.TrimEnd();
            string bankAccountName = companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountNameTextbox.Text.TrimEnd();
            string bankAccountNumber = companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountNumberTextbox.Text.TrimEnd();
            string bankAccountSortCode = null;
            string bankAccountSortCodePartA = companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxA?.Text.TrimEnd() ?? "";
            string bankAccountSortCodePartB = companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxB?.Text.TrimEnd() ?? "";
            string bankAccountSortCodePartC = companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxC?.Text.TrimEnd() ?? "";
            if (!string.IsNullOrEmpty(bankAccountSortCodePartA) && !string.IsNullOrEmpty(bankAccountSortCodePartB) && !string.IsNullOrEmpty(bankAccountSortCodePartC))
            {
                bankAccountSortCode = $"{bankAccountSortCodePartA}-{bankAccountSortCodePartB}-{bankAccountSortCodePartC}";
            }
            string bankAccountSWIFTCode = companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSWIFTCodeTextbox.Text.TrimEnd();
            string bankAccountVippsId = null;
            if (companyConfigurationDetailTabControlFinancialInformationTabPageVippsIdTextbox != null)
            {
                bankAccountVippsId = companyConfigurationDetailTabControlFinancialInformationTabPageVippsIdTextbox.Text.TrimEnd();
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
            string companyName = companyConfigurationDetailTabControlGeneralInformationTabPageCompanyNameTextbox.Text.TrimEnd();
            string emailAddress = companyConfigurationDetailTabControlGeneralInformationTabPageEmailAddressTextbox.Text.TrimEnd();
            string emailTopLevelDomain = companyConfigurationDetailTabControlGeneralInformationTabPageEmailTopLevelDomainTextbox.Text.TrimEnd();
            string telephoneNumber = companyConfigurationDetailTabControlGeneralInformationTabPageTelephoneNumberTextbox.Text.TrimEnd();
            string vatNumber = companyConfigurationDetailTabControlFinancialInformationTabPageVATNumberTextbox.Text.TrimEnd();
            string websiteURL = companyConfigurationDetailTabControlGeneralInformationTabPageWebsiteURLTextbox.Text.TrimEnd();

            string dataSubject = "Company Configuration";

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
                    Name = "ActiveStatus",
                    Value = activeStatus,
                    ValueType = typeof(bool)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "AddressLine1",
                    Value = addressLine1,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "AddressLine3",
                    Value = addressLine3,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "AddressLine4",
                    Value = addressLine4,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "AddressLine5",
                    Value = addressLine5,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "BankAccountAddressLine1",
                    Value = bankAccountAddressLine1,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "BankAccountAddressLine3",
                    Value = bankAccountAddressLine3,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "BankAccountAddressLine4",
                    Value = bankAccountAddressLine4,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "BankAccountAddressLine5",
                    Value = bankAccountAddressLine5,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "BankAccountCurrencyId",
                    Value = bankAccountCurrencyId,
                    ValueType = typeof(Guid)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "BankAccountIBAN",
                    Value = bankAccountIBAN,
                    MaxLength = 34,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "BankAccountName",
                    Value = bankAccountName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "BankAccountNumber",
                    Value = bankAccountNumber,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "BankAccountSWIFTCode",
                    Value = bankAccountSWIFTCode,
                    MaxLength = 11,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "Companylogo",
                    Value = companyLogo,
                    ValueType = typeof(byte[])
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "CompanyName",
                    Value = companyName,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "EmailAddress",
                    Value = emailAddress,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "EmailTopLevelDomain",
                    Value = emailTopLevelDomain,
                    MaxLength = 50,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "TelephoneNumber",
                    Value = telephoneNumber,
                    MaxLength = 13,
                    ValueType = typeof(string)
                },
                new ValidateDataInput.DataProperty
                {
                    AllowNullValue = false,
                    Name = "WebsiteURL",
                    Value = websiteURL,
                    MaxLength = 50,
                    ValueType = typeof(string)
                }
            };

            if (!string.IsNullOrEmpty(addressLine2))
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "AddressLine2",
                    Value = addressLine2,
                    MaxLength = 50,
                    ValueType = typeof(string)
                });
            }

            if (!string.IsNullOrEmpty(bankAccountAddressLine2))
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "BankAccountAddressLine2",
                    Value = bankAccountAddressLine2,
                    MaxLength = 50,
                    ValueType = typeof(string)
                });
            }

            if (!string.IsNullOrEmpty(bankAccountSortCode))
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "BankAccountSortCode",
                    Value = bankAccountSortCode,
                    MaxLength = 8,
                    ValueType = typeof(string)
                });
            }

            if (!string.IsNullOrEmpty(bankAccountVippsId))
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "BankAccountVippsId",
                    Value = bankAccountVippsId,
                    MaxLength = 50,
                    ValueType = typeof(string)
                });
            }

            if (!string.IsNullOrEmpty(vatNumber))
            {
                dataToValidate.Add(new ValidateDataInput.DataProperty
                {
                    AllowNullValue = true,
                    Name = "VATNumber",
                    Value = vatNumber,
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
                        VariableName = "Bank Account VAT Number",
                        VariableType = "string",
                        OriginalValue = financialInformationVATNumberOriginalValue,
                        NewValue = bankAccountVippsId
                    });
                }

                changesList = changesList.OrderBy(change => change.VariableName).ToList();

                bool confirmed = UpdateConfirmation.ConfirmChanges(changesList, dataSubject);

                if (confirmed)
                {
                    var parameters = new List<Parameter>
                    {
                        new Parameter
                        {
                            ParameterName = "@activeStatus",
                            ParameterValue = activeStatus
                        },
                        new Parameter
                        {
                            ParameterName = "@addressLine1",
                            ParameterValue = addressLine1
                        },
                        new Parameter
                        {
                            ParameterName = "@addressLine3",
                            ParameterValue = addressLine3
                        },
                        new Parameter
                        {
                            ParameterName = "@addressLine4",
                            ParameterValue = addressLine4
                        },
                        new Parameter
                        {
                            ParameterName = "@addressLine5",
                            ParameterValue = addressLine5
                        },
                        new Parameter
                        {
                            ParameterName = "@bankAccountAddressLine1",
                            ParameterValue = bankAccountAddressLine1
                        },
                        new Parameter
                        {
                            ParameterName = "@bankAccountAddressLine3",
                            ParameterValue = bankAccountAddressLine3
                        },
                        new Parameter
                        {
                            ParameterName = "@bankAccountAddressLine4",
                            ParameterValue = bankAccountAddressLine4
                        },
                        new Parameter
                        {
                            ParameterName = "@bankAccountAddressLine5",
                            ParameterValue = bankAccountAddressLine5
                        },
                        new Parameter
                        {
                            ParameterName = "@bankAccountCurrencyId",
                            ParameterValue = bankAccountCurrencyId
                        },
                        new Parameter
                        {
                            ParameterName = "@bankAccountIBAN",
                            ParameterValue = bankAccountIBAN
                        },
                        new Parameter
                        {
                            ParameterName = "@bankAccountName",
                            ParameterValue = bankAccountName
                        },
                        new Parameter
                        {
                            ParameterName = "@bankAccountNumber",
                            ParameterValue = bankAccountNumber
                        },
                        new Parameter
                        {
                            ParameterName = "@bankAccountSWIFTCode",
                            ParameterValue = bankAccountSWIFTCode
                        },
                        new Parameter
                        {
                            ParameterName = "@companyLogo",
                            ParameterValue = companyLogo
                        },
                        new Parameter
                        {
                            ParameterName = "@companyName",
                            ParameterValue = companyName
                        },
                        new Parameter
                        {
                            ParameterName = "@emailAddress",
                            ParameterValue = emailAddress
                        },
                        new Parameter
                        {
                            ParameterName = "@emailTopLevelDomain",
                            ParameterValue = emailTopLevelDomain
                        },
                        new Parameter
                        {
                            ParameterName = "@telephoneNumber",
                            ParameterValue = telephoneNumber
                        },
                        new Parameter
                        {
                            ParameterName = "@websiteURL",
                            ParameterValue = websiteURL
                        }
                    };

                    if (!string.IsNullOrEmpty(addressLine2))
                    {
                        parameters.Add(new Parameter
                        {
                            ParameterName = "@addressLine2",
                            ParameterValue = addressLine2
                        });
                    }

                    if (!string.IsNullOrEmpty(bankAccountAddressLine2))
                    {
                        parameters.Add(new Parameter
                        {
                            ParameterName = "@bankAccountAddressLine2",
                            ParameterValue = bankAccountAddressLine2
                        });
                    }

                    if (!string.IsNullOrEmpty(bankAccountSortCode))
                    {
                        parameters.Add(new Parameter
                        {
                            ParameterName = "@bankAccountSortCode",
                            ParameterValue = bankAccountSortCode
                        });
                    }

                    if (!string.IsNullOrEmpty(bankAccountVippsId))
                    {
                        parameters.Add(new Parameter
                        {
                            ParameterName = "@bankAccountVippsId",
                            ParameterValue = bankAccountVippsId
                        });
                    }

                    if (!string.IsNullOrEmpty(vatNumber))
                    {
                        parameters.Add(new Parameter
                        {
                            ParameterName = "@vatNumber",
                            ParameterValue = vatNumber
                        });
                    }

                    string storedProcedureName = "[dbo].[spUpdateCompanyConfiguration]";
                    string operationType = "update";

                    await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters.ToArray(), dataSubject, _databaseConnectionSettings.DatabaseConnectionString, operationType);
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
            CreateHTMLTemplate createHTMLTemplate = new CreateHTMLTemplate(_companyConfigurationId);
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
            companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine1Textbox.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine1Textbox.ReadOnly;
            companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine2Textbox.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine2Textbox.ReadOnly;
            companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine3Textbox.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine3Textbox.ReadOnly;
            companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine4Textbox.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine4Textbox.ReadOnly;
            companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.Enabled = !companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.Enabled;
            companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountIBANTextbox.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountIBANTextbox.ReadOnly;
            companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountNameTextbox.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountNameTextbox.ReadOnly;
            companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountNumberTextbox.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountNumberTextbox.ReadOnly;
            if (companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxA != null &&
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxB != null &&
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxC != null)
            {
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxA.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxA.ReadOnly;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxB.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxB.ReadOnly;
                companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxC.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSortCodeTextboxC.ReadOnly;
            }
            companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSWIFTCodeTextbox.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageBankAccountSWIFTCodeTextbox.ReadOnly;
            companyConfigurationDetailTabControlFinancialInformationTabPageVATNumberTextbox.ReadOnly = !companyConfigurationDetailTabControlFinancialInformationTabPageVATNumberTextbox.ReadOnly;
            companyConfigurationDetailTabControlFinancialInformationTabPageVATRegisteredCheckbox.Enabled = !companyConfigurationDetailTabControlFinancialInformationTabPageVATRegisteredCheckbox.Enabled;

            // Update VippsId textbox state based on edit mode and country
            UpdateVippsIdTextboxState();

            companyConfigurationDetailTabControlGeneralInformationTabPageActiveStatusCheckbox.Enabled = !companyConfigurationDetailTabControlGeneralInformationTabPageActiveStatusCheckbox.Enabled;
            companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine1Textbox.ReadOnly = !companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine1Textbox.ReadOnly;
            companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine2Textbox.ReadOnly = !companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine2Textbox.ReadOnly;
            companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine3Textbox.ReadOnly = !companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine3Textbox.ReadOnly;
            companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine4Textbox.ReadOnly = !companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine4Textbox.ReadOnly;
            companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine5ComboBox.Enabled = !companyConfigurationDetailTabControlGeneralInformationTabPageAddressLine5ComboBox.Enabled;
            companyConfigurationDetailTabControlGeneralInformationTabPageCompanyNameTextbox.ReadOnly = !companyConfigurationDetailTabControlGeneralInformationTabPageCompanyNameTextbox.ReadOnly;
            companyConfigurationDetailTabControlGeneralInformationTabPageEmailAddressTextbox.ReadOnly = !companyConfigurationDetailTabControlGeneralInformationTabPageEmailAddressTextbox.ReadOnly;
            companyConfigurationDetailTabControlGeneralInformationTabPageEmailTopLevelDomainTextbox.ReadOnly = !companyConfigurationDetailTabControlGeneralInformationTabPageEmailTopLevelDomainTextbox.ReadOnly;
            companyConfigurationDetailTabControlGeneralInformationTabPageTelephoneNumberTextbox.ReadOnly = !companyConfigurationDetailTabControlGeneralInformationTabPageTelephoneNumberTextbox.ReadOnly;
            companyConfigurationDetailTabControlGeneralInformationTabPageWebsiteURLTextbox.ReadOnly = !companyConfigurationDetailTabControlGeneralInformationTabPageWebsiteURLTextbox.ReadOnly;
            companyConfigurationDetailUpdateCompanyConfigurationButton.Enabled = !companyConfigurationDetailUpdateCompanyConfigurationButton.Enabled;
        }
    }
}