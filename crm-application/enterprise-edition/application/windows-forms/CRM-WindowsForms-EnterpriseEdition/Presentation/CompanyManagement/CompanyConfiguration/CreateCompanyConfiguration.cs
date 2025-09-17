using CRM.Helpers;
using CRM.Interface;
using CRM.Services;
using System.Data;

namespace CRM.Presentation.CompanyManagement.CompanyConfiguration
{
    public partial class CreateCompanyConfiguration : Form
    {
        private byte[]? _companyLogoImageBytes = null;
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private TextBoxNumericCharacterDataValidationHelper _textBoxNumericHelper;

        public CreateCompanyConfiguration()
        {
            InitializeComponent();
            _textBoxNumericHelper = new TextBoxNumericCharacterDataValidationHelper();
            InitializeEventHandlers();
            LoadDatabaseConnectionSettingsAsync();
            LoadCountryAsync();
            LoadCurrencyDataAsync();
        }

        private void InitializeEventHandlers()
        {
            createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine1TextBox.TextChanged += AutoPopulateBankAccountAddressInformation;
            createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine2TextBox.TextChanged += AutoPopulateBankAccountAddressInformation;
            createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine3TextBox.TextChanged += AutoPopulateBankAccountAddressInformation;
            createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine4TextBox.TextChanged += AutoPopulateBankAccountAddressInformation;
            createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine5ComboBox.SelectedIndexChanged += AutoPopulateBankAccountAddressInformation;
            createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine5ComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox.TextChanged += AutoPopulateEmailAddressInformation;
            createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox.KeyPress += createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox_KeyPress;
            createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox.MouseDown += createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox_MouseDown;
            createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox.SelectionStart = 1;
            createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox.Text = "@";
            createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox.TextChanged += createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox_TextChanged;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.SelectedIndexChanged += createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox_SelectedIndexChanged;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountCurrencyComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountNumberTextBox.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxA.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxB.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxC.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxLabel.MouseHover += ToolTip_MouseHover;
            createCompanyConfigurationTabControlFinancialInformationTabPageOpeningBalanceTextBoxA.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            createCompanyConfigurationTabControlFinancialInformationTabPageOpeningBalanceTextBoxB.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBoxLabel.MouseHover += ToolTip_MouseHover;
            createCompanyConfigurationTabControlFinancialInformationTabPageVATRegisteredCheckBox.CheckedChanged += createCompanyConfigurationTabControlFinancialInformationTabPageVATRegisteredCheckBox_CheckedChanged;
        }

        private void AutoPopulateBankAccountAddressInformation(object? sender, EventArgs e)
        {
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine1TextBox.Text = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine1TextBox.Text;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine2TextBox.Text = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine2TextBox.Text;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine3TextBox.Text = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine3TextBox.Text;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine4TextBox.Text = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine4TextBox.Text;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.SelectedItem = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine5ComboBox.SelectedItem;
        }

        private void AutoPopulateEmailAddressInformation(object? sender, EventArgs e)
        {
            // Get the current username part (before the first '@')
            string currentEmail = createCompanyConfigurationTabControlGeneralInformationTabPageEmailAddressTextBox.Text;
            string username = currentEmail;
            int atIndex = currentEmail.IndexOf('@');
            if (atIndex >= 0)
            {
                username = currentEmail.Substring(0, atIndex);
            }

            // Get the current domain part (from the domain textbox)
            string domain = createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox.Text;

            // Only update if username or domain is not empty
            if (!string.IsNullOrWhiteSpace(username) || !string.IsNullOrWhiteSpace(domain))
            {
                createCompanyConfigurationTabControlGeneralInformationTabPageEmailAddressTextBox.Text = username + domain;
            }
        }

        private bool IsMouseOverControl(Control control)
        {
            if (control == null || !control.Visible)
                return false;

            Point mousePosition = control.PointToClient(Control.MousePosition);
            return control.ClientRectangle.Contains(mousePosition);
        }

        private async void LoadCountryAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox, "spGetAllCountry");
            await _dataAccessComboBoxHelper.LoadDataAsync();

            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine5ComboBox, "spGetAllCountry");
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async void LoadCurrencyDataAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountCurrencyComboBox, "spGetAllCurrency");
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void ToolTip_MouseHover(object? sender, EventArgs e)
        {
            // Show tooltip for Sort Code fields if mouse is over any of the relevant controls
            if (IsMouseOverControl(createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxLabel))
            {
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeToolTip.Show(
                    "Sort Code can only be assigned to Banks Accounts based in GB.",
                    createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxLabel, 5000);
            }

            // Show tooltip for Vipps Id fields if mouse is over any of the relevant controls
            if (IsMouseOverControl(createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBoxLabel))
            {
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdToolTip.Show(
                    "Vipps Id is only assignable to Bank Accounts registered in DK, FI, NO, SE.",
                    createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBoxLabel, 5000);
            }
        }

        private void createCompanyConfigurationTabControlCompanyLogoTabPageChooseCompanyLogoImageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    if (ValidateDataInputService.IsValidImageFile(filePath, 1000, 1000, out string errorMessage))
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

        private void createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox_SelectedIndexChanged(object? sender, EventArgs e)
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
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxA.Enabled = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxA.ReadOnly = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxB.Enabled = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxB.ReadOnly = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxC.Enabled = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxC.ReadOnly = false;
                
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBox.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBox.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBox.Text = string.Empty;
            }
            else if (isoCountryCode == "DK" || isoCountryCode == "FI" || isoCountryCode == "NO" || isoCountryCode == "SE")
            {
                // Enable Vipps, disable sort code fields
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBox.Enabled = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBox.ReadOnly = false;

                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxA.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxA.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxA.Text = string.Empty;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxB.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxB.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxB.Text = string.Empty;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxC.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxC.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxC.Text = string.Empty;
            }
            else
            {
                // Disable both
                
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxA.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxA.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxA.Text = string.Empty;           
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxB.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxB.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxB.Text = string.Empty;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxC.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxC.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxC.Text = string.Empty;
                
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBox.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBox.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBox.Text = string.Empty;
            }
        }

        private void createCompanyConfigurationTabControlFinancialInformationTabPageVATRegisteredCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (createCompanyConfigurationTabControlFinancialInformationTabPageVATRegisteredCheckBox.Checked)
            {
                createCompanyConfigurationTabControlFinancialInformationTabPageVATNumberTextBox.Enabled = true;
            }
            else
            {
                createCompanyConfigurationTabControlFinancialInformationTabPageVATNumberTextBox.Enabled = false;
                var result = MessageBox.Show(
                    "A VAT Number cannot be assigned if VAT Registered is false. Clicking OK will clear the VAT Number field. Clicking Cancel will reverse the changes.",
                    "Warning",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    createCompanyConfigurationTabControlFinancialInformationTabPageVATNumberTextBox.Text = string.Empty;
                }
                else
                {
                    createCompanyConfigurationTabControlFinancialInformationTabPageVATRegisteredCheckBox.Checked = true;
                    createCompanyConfigurationTabControlFinancialInformationTabPageVATNumberTextBox.Enabled = true;
                }
            }
        }

        private void createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            var textbox = createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox;
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

        private void createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox_MouseDown(object? sender, MouseEventArgs e)
        {
            var textbox = createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox;
            // Prevent caret from moving before '@'
            if (textbox.SelectionStart < 1)
            {
                textbox.SelectionStart = 1;
            }
        }

        private void createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox_TextChanged(object? sender, EventArgs e)
        {
            var textbox = createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox;
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

        private async void createCompanyConfigurationSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createCompanyConfigurationTabControlGeneralInformationTabPageActiveStatusCheckBox.Checked;
            string addressLine1 = TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine1TextBox);
            string addressLine2 = TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine2TextBox);
            string addressLine3 = TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine3TextBox);
            string addressLine4 = TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine4TextBox);
            Guid addressLine5 = (Guid)createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.SelectedValue;
            string bankAccountAddressLine1 = TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine1TextBox);
            string bankAccountAddressLine2 = null;
            if (createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine2TextBox != null)
            {
                bankAccountAddressLine2 = TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine2TextBox);
            }
            string bankAccountAddressLine3 = TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine3TextBox);
            string bankAccountAddressLine4 = TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine4TextBox);
            Guid bankAccountAddressLine5 = (Guid)createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.SelectedValue;
            Guid bankAccountCurrencyId = (Guid)createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountCurrencyComboBox.SelectedValue;
            string bankAccountIBAN = TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountIBANTextBox);
            string bankAccountName = TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountNameTextBox);
            string bankAccountNumber = TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountNumberTextBox);
            decimal bankAccountOpeningBalance = decimal.Parse($"{TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlFinancialInformationTabPageOpeningBalanceTextBoxA)}.{TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlFinancialInformationTabPageOpeningBalanceTextBoxB)}");
            string bankAccountSortCode = null;
            string bankAccountSortCodePartA = TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxA);
            string bankAccountSortCodePartB = TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxB);
            string bankAccountSortCodePartC = TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeMaskedTextBoxC);
            if (!string.IsNullOrEmpty(bankAccountSortCodePartA) && !string.IsNullOrEmpty(bankAccountSortCodePartB) && !string.IsNullOrEmpty(bankAccountSortCodePartC))
            {
                bankAccountSortCode = $"{bankAccountSortCodePartA}-{bankAccountSortCodePartB}-{bankAccountSortCodePartC}";
            }
            string bankAccountSWIFTCode = TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSWIFTCodeTextBox);
            string bankAccountVippsId = null;
            if (createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBox != null)
            {
                bankAccountVippsId = TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBox);
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
            string companyName = TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlGeneralInformationTabPageCompanyNameTextBox);
            string emailAddress = TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlGeneralInformationTabPageEmailAddressTextBox);
            string emailTopLevelDomain = TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox);
            string telephoneNumber = TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlGeneralInformationTabPageTelephoneNumberTextBox);
            string vatNumber = TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlFinancialInformationTabPageVATNumberTextBox);
            bool vatRegistered = createCompanyConfigurationTabControlFinancialInformationTabPageVATRegisteredCheckBox.Checked;
            string websiteURL = TextBoxCleanerHelper.GetTrimmedText(createCompanyConfigurationTabControlGeneralInformationTabPageWebsiteURLTextBox);

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
                    AllowNullValue = true,
                    Name = "Address Line 2",
                    Value = addressLine2,
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
                    AllowNullValue = true,
                    Name = "Bank Account Address Line 2",
                    Value = bankAccountAddressLine2,
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
                    Name = "Bank Account Opening Balance",
                    Value = bankAccountOpeningBalance,
                    ValueType = typeof(decimal)
                },
                new ValidateDataInputService.DataProperty
                {
                    AllowNullValue = true,
                    Name = "Bank Account Sort Code",
                    Value = bankAccountSortCode,
                    MaxLength = 8,
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
                    AllowNullValue = true,
                    Name = "Bank Account Vipps Id",
                    Value = bankAccountVippsId,
                    MaxLength = 50,
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
                    Name = "CompanyName",
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
                    AllowNullValue = true,
                    Name = "VAT Number",
                    Value = vatNumber,
                    MaxLength = 50,
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

            dataToValidate = dataToValidate.OrderBy(change => change.Name).ToList();

            var validationResult = ValidateDataInputService.ValidateInput(dataToValidate);

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
                        ParameterName = "activeStatus",
                        ParameterValue = activeStatus
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "addressLine1",
                        ParameterValue = addressLine1
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "addressLine3",
                        ParameterValue = addressLine3
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "addressLine4",
                        ParameterValue = addressLine4
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "addressLine5",
                        ParameterValue = addressLine5
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "bankAccountAddressLine1",
                        ParameterValue = bankAccountAddressLine1
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "bankAccountAddressLine3",
                        ParameterValue = bankAccountAddressLine3
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "bankAccountAddressLine4",
                        ParameterValue = bankAccountAddressLine4
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "bankAccountAddressLine5",
                        ParameterValue = bankAccountAddressLine5
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "bankAccountCurrencyId",
                        ParameterValue = bankAccountCurrencyId
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "bankAccountIBAN",
                        ParameterValue = bankAccountIBAN
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "bankAccountName",
                        ParameterValue = bankAccountName
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "bankAccountNumber",
                        ParameterValue = bankAccountNumber
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "bankAccountOpeningBalance",
                        ParameterValue = bankAccountOpeningBalance
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "bankAccountSWIFTCode",
                        ParameterValue = bankAccountSWIFTCode
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "companyLogo",
                        ParameterValue = companyLogo
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "companyName",
                        ParameterValue = companyName
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "emailAddress",
                        ParameterValue = emailAddress
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "emailTopLevelDomain",
                        ParameterValue = emailTopLevelDomain
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "telephoneNumber",
                        ParameterValue = telephoneNumber
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "vatRegistered",
                        ParameterValue = vatRegistered
                    },
                    new StoredProcedureParameter
                    {
                        ParameterName = "websiteURL",
                        ParameterValue = websiteURL
                    }
                };

                if (!string.IsNullOrEmpty(addressLine2))
                {
                    parameters.Add(new StoredProcedureParameter
                    {
                        ParameterName = "addressLine2",
                        ParameterValue = addressLine2
                    });
                }

                if (!string.IsNullOrEmpty(bankAccountAddressLine2))
                {
                    parameters.Add(new StoredProcedureParameter
                    {
                        ParameterName = "bankAccountAddressLine2",
                        ParameterValue = bankAccountAddressLine2
                    });
                }

                if (!string.IsNullOrEmpty(bankAccountSortCode))
                {
                    parameters.Add(new StoredProcedureParameter
                    {
                        ParameterName = "bankAccountSortCode",
                        ParameterValue = bankAccountSortCode
                    });
                }

                if (!string.IsNullOrEmpty(bankAccountVippsId))
                {
                    parameters.Add(new StoredProcedureParameter
                    {
                        ParameterName = "bankAccountVippsId",
                        ParameterValue = bankAccountVippsId
                    });
                }

                if (!string.IsNullOrEmpty(vatNumber))
                {
                    parameters.Add(new StoredProcedureParameter
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