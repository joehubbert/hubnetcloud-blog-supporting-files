using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateCompanyConfiguration : Form
    {
        private byte[]? _companyLogoImageBytes = null;
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreateCompanyConfiguration()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadInitialDataAsync();
        }

        private void InitializeCustomComponents()
        {
            createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine1Textbox.TextChanged += AutoPopulateBankAccountAddressInformation;
            createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine2Textbox.TextChanged += AutoPopulateBankAccountAddressInformation;
            createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine3Textbox.TextChanged += AutoPopulateBankAccountAddressInformation;
            createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine4Textbox.TextChanged += AutoPopulateBankAccountAddressInformation;
            createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine5ComboBox.SelectedIndexChanged += AutoPopulateBankAccountAddressInformation;
            createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine5ComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextbox.TextChanged += AutoPopulateEmailAddressInformation;
            createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextbox.KeyPress += EmailTopLevelDomainTextbox_KeyPress;
            createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextbox.MouseDown += EmailTopLevelDomainTextbox_MouseDown;
            createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextbox.SelectionStart = 1;
            createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextbox.Text = "@";
            createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextbox.TextChanged += EmailTopLevelDomainTextbox_TextChanged;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.SelectedIndexChanged += new EventHandler(CreateCompanyConfigurationFinancialInformationBankAccountAddressLine5ComboBox_SelectedIndexChanged);
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountCurrencyComboBox.DropDown += new EventHandler(AdjustComboBoxWidth_DropDown);
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxLabel.MouseHover += ToolTip_MouseHover;
            createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextboxLabel.MouseHover += ToolTip_MouseHover;
            createCompanyConfigurationTabControlFinancialInformationTabPageVATRegisteredCheckbox.CheckedChanged += new EventHandler(CreateCompanyConfigurationFinancialInformationVATRegisteredCheckBox_CheckedChanged);
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task LoadInitialDataAsync()
        {
            await LoadDatabaseConnectionSettingsAsync();

            var loadCountryTask = CreateCompanyConfigurationLoadCountryAsync();
            var loadCurrencyTask = CreateCompanyConfigurationLoadCurrencyDataAsync();

            await Task.WhenAll(loadCountryTask, loadCurrencyTask);
        }

        private async Task CreateCompanyConfigurationLoadCountryAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = "Country";

            try
            {
                string storedProcedureName = "spGetAllCountry";
                
                DataTable? countryData = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubject);
                var countryList = countryData.AsEnumerable()
                    .Select(row => new
                    {
                        CountryId = row.Field<Guid>("Country Id"),
                        DisplayText = $"{row.Field<string>("ISO 3166-1 Alpha 2 Country Code")} - {row.Field<string>("Country English Name")}"
                    })
                    .OrderBy(item => item.DisplayText)
                    .ToList();
                createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine5ComboBox.DataSource = countryList;
                createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine5ComboBox.DisplayMember = "DisplayText";
                createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine5ComboBox.ValueMember = "CountryId";

                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.DataSource = countryList;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.DisplayMember = "DisplayText";
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.ValueMember = "CountryId";
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

        private async Task CreateCompanyConfigurationLoadCurrencyDataAsync()
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

                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountCurrencyComboBox.DataSource = currencyList;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountCurrencyComboBox.DisplayMember = "DisplayText";
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountCurrencyComboBox.ValueMember = "CurrencyId";
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private void CreateCompanyConfigurationFinancialInformationVATRegisteredCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCompanyConfigurationTabControlFinancialInformationTabPageVATRegisteredCheckbox.Checked)
            {
                createCompanyConfigurationTabControlFinancialInformationTabPageVATRegisteredCheckbox.Enabled = true;
            }
            else
            {
                createCompanyConfigurationTabControlFinancialInformationTabPageVATRegisteredCheckbox.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageVATNumberTextbox.Text = string.Empty;
            }
        }

        private void CreateCompanyConfigurationFinancialInformationBankAccountAddressLine5ComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var selectedItem = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.SelectedItem;
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
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxA.Enabled = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxA.ReadOnly = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxB.Enabled = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxB.ReadOnly = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxC.Enabled = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxC.ReadOnly = false;
                
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextbox.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextbox.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextbox.Text = string.Empty;
            }
            else if (isoCountryCode == "DK" || isoCountryCode == "FI" || isoCountryCode == "NO" || isoCountryCode == "SE")
            {
                // Enable Vipps, disable sort code fields
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextbox.Enabled = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextbox.ReadOnly = false;

                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxA.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxA.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxA.Text = string.Empty;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxB.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxB.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxB.Text = string.Empty;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxC.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxC.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxC.Text = string.Empty;
            }
            else
            {
                // Disable both
                
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxA.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxA.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxA.Text = string.Empty;           
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxB.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxB.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxB.Text = string.Empty;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxC.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxC.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxC.Text = string.Empty;
                
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextbox.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextbox.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextbox.Text = string.Empty;
            }
        }

        private void AutoPopulateBankAccountAddressInformation(object? sender, EventArgs e)
        {
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine1Textbox.Text = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine1Textbox.Text;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine2Textbox.Text = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine2Textbox.Text;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine3Textbox.Text = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine3Textbox.Text;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine4Textbox.Text = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine4Textbox.Text;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.SelectedItem = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine5ComboBox.SelectedItem;
        }

        private void EmailTopLevelDomainTextbox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            var textbox = createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextbox;
            // Prevent backspace/delete at position 1 or before
            if ((e.KeyChar == (char)Keys.Back && textbox.SelectionStart <= 1) ||
                (e.KeyChar == (char)Keys.Delete && textbox.SelectionStart < 1))
            {
                e.Handled = true;
                return;
            }
            // Prevent typing before the '@'
            if (textbox.SelectionStart < 1)
            {
                e.Handled = true;
                textbox.SelectionStart = textbox.Text.Length;
            }
            // Prevent entering another '@'
            if (e.KeyChar == '@' && textbox.SelectionStart == 1)
            {
                e.Handled = true;
            }
        }

        private void EmailTopLevelDomainTextbox_TextChanged(object? sender, EventArgs e)
        {
            var textbox = createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextbox;
            // Always ensure text starts with '@'
            if (!textbox.Text.StartsWith("@"))
            {
                textbox.Text = "@" + textbox.Text.TrimStart('@');
                textbox.SelectionStart = textbox.Text.Length;
            }
            // Prevent deletion of '@'
            if (textbox.Text == "")
            {
                textbox.Text = "@";
                textbox.SelectionStart = 1;
            }
        }

        private void EmailTopLevelDomainTextbox_MouseDown(object? sender, MouseEventArgs e)
        {
            var textbox = createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextbox;
            // Prevent caret from moving before '@'
            if (textbox.SelectionStart < 1)
            {
                textbox.SelectionStart = 1;
            }
        }

        private void AutoPopulateEmailAddressInformation(object? sender, EventArgs e)
        {
            // Get the current username part (before the first '@')
            string currentEmail = createCompanyConfigurationTabControlGeneralInformationTabPageEmailAddressTextbox.Text;
            string username = currentEmail;
            int atIndex = currentEmail.IndexOf('@');
            if (atIndex >= 0)
            {
                username = currentEmail.Substring(0, atIndex);
            }

            // Get the current domain part (from the domain textbox)
            string domain = createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextbox.Text;

            // Only update if username or domain is not empty
            if (!string.IsNullOrWhiteSpace(username) || !string.IsNullOrWhiteSpace(domain))
            {
                createCompanyConfigurationTabControlGeneralInformationTabPageEmailAddressTextbox.Text = username + domain;
            }
        }

        private void ToolTip_MouseHover(object? sender, EventArgs e)
        {
            // Show tooltip for Sort Code fields if mouse is over any of the relevant controls
            if (IsMouseOverControl(createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxLabel))
            {
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeToolTip.Show(
                    "Sort Code can only be assigned to Banks Accounts based in GB.",
                    createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxLabel, 5000);
            }

            // Show tooltip for Vipps Id fields if mouse is over any of the relevant controls
            if (IsMouseOverControl(createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextboxLabel))
            {
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdToolTip.Show(
                    "Vipps Id is only assignable to Bank Accounts registered in DK, FI, NO, SE.",
                    createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextboxLabel, 5000);
            }
        }

        // Helper method to check if mouse is over a control
        private bool IsMouseOverControl(Control control)
        {
            if (control == null || !control.Visible)
                return false;

            Point mousePosition = control.PointToClient(Control.MousePosition);
            return control.ClientRectangle.Contains(mousePosition);
        }

        private void createCompanyConfigurationTabControlCompanyLogoTabPageChooseCompanyLogoImageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    if (ValidateDataInput.IsValidImageFile(filePath, 1000, 1000, out string errorMessage))
                    {
                        createCompanyConfigurationTabControlCompanyLogoTabPageCompanyLogoImagePictureBox.Image = Image.FromFile(filePath);
                        _companyLogoImageBytes = File.ReadAllBytes(filePath);
                    }
                    else
                    {
                        ErrorMessageService errorMessageService = new ErrorMessageService("Warning.Data.Validation.DataType", "Image");
                        createCompanyConfigurationTabControlCompanyLogoTabPageCompanyLogoImagePictureBox.Image = null;
                        _companyLogoImageBytes = null;
                    }
                }
            }
        }

        private void createCompanyConfigurationTabControlCompanyLogoTabPageRemoveCompanyLogoImageButton_Click(object sender, EventArgs e)
        {
            createCompanyConfigurationTabControlCompanyLogoTabPageCompanyLogoImagePictureBox.Image = null;
            _companyLogoImageBytes = null;
        }

        private async void createCompanyConfigurationSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createCompanyConfigurationTabControlGeneralInformationTabPageActiveStatusCheckbox.Checked;
            string addressLine1 = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine1Textbox.Text.TrimEnd();
            string addressLine2 = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine2Textbox.Text.TrimEnd();
            string addressLine3 = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine3Textbox.Text.TrimEnd();
            string addressLine4 = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine4Textbox.Text.TrimEnd();
            Guid addressLine5 = (Guid)createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.SelectedValue;
            string bankAccountAddressLine1 = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine1Textbox.Text.TrimEnd();
            string bankAccountAddressLine2 = null;
            if (createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine2Textbox != null)
            {
                bankAccountAddressLine2 = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine2Textbox.Text.TrimEnd();
            }
            string bankAccountAddressLine3 = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine3Textbox.Text.TrimEnd();
            string bankAccountAddressLine4 = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine4Textbox.Text.TrimEnd();
            Guid bankAccountAddressLine5 = (Guid)createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.SelectedValue;
            Guid bankAccountCurrencyId = (Guid)createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountCurrencyComboBox.SelectedValue;
            string bankAccountIBAN = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountIBANTextbox.Text.TrimEnd();
            string bankAccountName = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountNameTextbox.Text.TrimEnd();
            string bankAccountNumber = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountNumberTextbox.Text.TrimEnd();
            decimal bankAccountOpeningBalance = decimal.Parse($"{createCompanyConfigurationTabControlFinancialInformationTabPageOpeningBalanceTextboxA.Text.TrimEnd()}.{createCompanyConfigurationTabControlFinancialInformationTabPageOpeningBalanceTextboxB.Text.TrimEnd()}");
            string bankAccountSortCode = null;
            string bankAccountSortCodePartA = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxA?.Text.TrimEnd() ?? "";
            string bankAccountSortCodePartB = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxB?.Text.TrimEnd() ?? "";
            string bankAccountSortCodePartC = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextboxC?.Text.TrimEnd() ?? "";
            if (!string.IsNullOrEmpty(bankAccountSortCodePartA) && !string.IsNullOrEmpty(bankAccountSortCodePartB) && !string.IsNullOrEmpty(bankAccountSortCodePartC))
            {
                bankAccountSortCode = $"{bankAccountSortCodePartA}-{bankAccountSortCodePartB}-{bankAccountSortCodePartC}";
            }
            string bankAccountSWIFTCode = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSWIFTCodeTextbox.Text.TrimEnd();
            string bankAccountVippsId = null;
            if (createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextbox != null)
            {
                bankAccountVippsId = createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextbox.Text.TrimEnd();
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
            string companyName = createCompanyConfigurationTabControlGeneralInformationTabPageCompanyNameTextbox.Text.TrimEnd();
            string emailAddress = createCompanyConfigurationTabControlGeneralInformationTabPageEmailAddressTextbox.Text.TrimEnd();
            string emailTopLevelDomain = createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextbox.Text.TrimEnd();
            string telephoneNumber = createCompanyConfigurationTabControlGeneralInformationTabPageTelephoneNumberTextbox.Text.TrimEnd();
            string vatNumber = createCompanyConfigurationTabControlFinancialInformationTabPageVATNumberTextbox.Text.TrimEnd();
            string websiteURL = createCompanyConfigurationTabControlGeneralInformationTabPageWebsiteURLTextbox.Text.TrimEnd();

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
                    Name = "BankAccountOpeningBalance",
                    Value = bankAccountOpeningBalance,
                    ValueType = typeof(decimal)
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
                        ParameterName = "bankAccountOpeningBalance",
                        ParameterValue = bankAccountOpeningBalance
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

                string storedProcedureName = "spCreateCompanyConfiguration";
                string operationType = "create";

                await DBInterface.ExecuteCreateUpdateDeleteStoredProcedureAsync(storedProcedureName, parameters.ToArray(), dataSubject, operationType);
                this.Close();
            }
        }
    }
}