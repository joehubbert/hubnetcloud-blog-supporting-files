using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class CreateCompanyConfiguration : Form
    {
        private byte[]? _companyLogoImageBytes = null;
        private DataAccessComboBoxHelper? _dataAccessComboBoxHelper;
        private DatabaseConnectionSettings? _databaseConnectionSettings;

        public CreateCompanyConfiguration()
        {
            InitializeComponent();
            InitializeEventHandlers();
            LoadInitialDataAsync();
        }

        private void InitializeEventHandlers()
        {
            createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine1TextBox.TextChanged += AutoPopulateBankAccountAddressInformation;
            createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine2TextBox.TextChanged += AutoPopulateBankAccountAddressInformation;
            createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine3TextBox.TextChanged += AutoPopulateBankAccountAddressInformation;
            createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine4TextBox.TextChanged += AutoPopulateBankAccountAddressInformation;
            createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine5ComboBox.SelectedIndexChanged += AutoPopulateBankAccountAddressInformation;
            createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine5ComboBox.DropDown += AdjustComboBoxWidth_DropDown;
            createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox.TextChanged += AutoPopulateEmailAddressInformation;
            createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox.KeyPress += EmailTopLevelDomainTextBox_KeyPress;
            createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox.MouseDown += EmailTopLevelDomainTextBox_MouseDown;
            createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox.SelectionStart = 1;
            createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox.Text = "@";
            createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox.TextChanged += EmailTopLevelDomainTextBox_TextChanged;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.DropDown += AdjustComboBoxWidth_DropDown;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.SelectedIndexChanged += CreateCompanyConfigurationFinancialInformationBankAccountAddressLine5ComboBox_SelectedIndexChanged;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountCurrencyComboBox.DropDown += AdjustComboBoxWidth_DropDown;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxLabel.MouseHover += ToolTip_MouseHover;
            createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBoxLabel.MouseHover += ToolTip_MouseHover;
            createCompanyConfigurationTabControlFinancialInformationTabPageVATRegisteredCheckbox.CheckedChanged += CreateCompanyConfigurationFinancialInformationVATRegisteredCheckBox_CheckedChanged;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private async Task LoadInitialDataAsync()
        {
            await LoadDatabaseConnectionSettingsAsync();
            await LoadCountryAsync();
            await LoadCurrencyDataAsync();
        }

        private async Task LoadCountryAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox, "spGetAllCountry");
            await _dataAccessComboBoxHelper.LoadDataAsync();

            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine5ComboBox, "spGetAllCountry");
            await _dataAccessComboBoxHelper.LoadDataAsync();
        }

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDownHelper.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private async Task LoadCurrencyDataAsync()
        {
            _dataAccessComboBoxHelper = new DataAccessComboBoxHelper(createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountCurrencyComboBox, "spGetAllCurrency");
            await _dataAccessComboBoxHelper.LoadDataAsync();
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
                createCompanyConfigurationTabControlFinancialInformationTabPageVATNumberTextBox.Text = string.Empty;
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
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxA.Enabled = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxA.ReadOnly = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxB.Enabled = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxB.ReadOnly = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxC.Enabled = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxC.ReadOnly = false;
                
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBox.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBox.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBox.Text = string.Empty;
            }
            else if (isoCountryCode == "DK" || isoCountryCode == "FI" || isoCountryCode == "NO" || isoCountryCode == "SE")
            {
                // Enable Vipps, disable sort code fields
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBox.Enabled = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBox.ReadOnly = false;

                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxA.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxA.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxA.Text = string.Empty;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxB.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxB.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxB.Text = string.Empty;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxC.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxC.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxC.Text = string.Empty;
            }
            else
            {
                // Disable both
                
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxA.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxA.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxA.Text = string.Empty;           
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxB.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxB.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxB.Text = string.Empty;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxC.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxC.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxC.Text = string.Empty;
                
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBox.Enabled = false;
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBox.ReadOnly = true;
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBox.Text = string.Empty;
            }
        }

        private void AutoPopulateBankAccountAddressInformation(object? sender, EventArgs e)
        {
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine1TextBox.Text = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine1TextBox.Text;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine2TextBox.Text = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine2TextBox.Text;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine3TextBox.Text = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine3TextBox.Text;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine4TextBox.Text = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine4TextBox.Text;
            createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.SelectedItem = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine5ComboBox.SelectedItem;
        }

        private void EmailTopLevelDomainTextBox_KeyPress(object? sender, KeyPressEventArgs e)
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

        private void EmailTopLevelDomainTextBox_TextChanged(object? sender, EventArgs e)
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

        private void EmailTopLevelDomainTextBox_MouseDown(object? sender, MouseEventArgs e)
        {
            var textbox = createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox;
            // Prevent caret from moving before '@'
            if (textbox.SelectionStart < 1)
            {
                textbox.SelectionStart = 1;
            }
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

        private void ToolTip_MouseHover(object? sender, EventArgs e)
        {
            // Show tooltip for Sort Code fields if mouse is over any of the relevant controls
            if (IsMouseOverControl(createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxLabel))
            {
                createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeToolTip.Show(
                    "Sort Code can only be assigned to Banks Accounts based in GB.",
                    createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxLabel, 5000);
            }

            // Show tooltip for Vipps Id fields if mouse is over any of the relevant controls
            if (IsMouseOverControl(createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBoxLabel))
            {
                createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdToolTip.Show(
                    "Vipps Id is only assignable to Bank Accounts registered in DK, FI, NO, SE.",
                    createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBoxLabel, 5000);
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

        private async void createCompanyConfigurationSubmitButton_Click(object sender, EventArgs e)
        {
            bool activeStatus = createCompanyConfigurationTabControlGeneralInformationTabPageActiveStatusCheckbox.Checked;
            string addressLine1 = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine1TextBox.Text.TrimEnd();
            string addressLine2 = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine2TextBox.Text.TrimEnd();
            string addressLine3 = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine3TextBox.Text.TrimEnd();
            string addressLine4 = createCompanyConfigurationTabControlGeneralInformationTabPageAddressLine4TextBox.Text.TrimEnd();
            Guid addressLine5 = (Guid)createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.SelectedValue;
            string bankAccountAddressLine1 = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine1TextBox.Text.TrimEnd();
            string bankAccountAddressLine2 = null;
            if (createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine2TextBox != null)
            {
                bankAccountAddressLine2 = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine2TextBox.Text.TrimEnd();
            }
            string bankAccountAddressLine3 = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine3TextBox.Text.TrimEnd();
            string bankAccountAddressLine4 = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine4TextBox.Text.TrimEnd();
            Guid bankAccountAddressLine5 = (Guid)createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountAddressLine5ComboBox.SelectedValue;
            Guid bankAccountCurrencyId = (Guid)createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountCurrencyComboBox.SelectedValue;
            string bankAccountIBAN = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountIBANTextBox.Text.TrimEnd();
            string bankAccountName = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountNameTextBox.Text.TrimEnd();
            string bankAccountNumber = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountNumberTextBox.Text.TrimEnd();
            decimal bankAccountOpeningBalance = decimal.Parse($"{createCompanyConfigurationTabControlFinancialInformationTabPageOpeningBalanceTextBoxA.Text.TrimEnd()}.{createCompanyConfigurationTabControlFinancialInformationTabPageOpeningBalanceTextBoxB.Text.TrimEnd()}");
            string bankAccountSortCode = null;
            string bankAccountSortCodePartA = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxA?.Text.TrimEnd() ?? "";
            string bankAccountSortCodePartB = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxB?.Text.TrimEnd() ?? "";
            string bankAccountSortCodePartC = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSortCodeTextBoxC?.Text.TrimEnd() ?? "";
            if (!string.IsNullOrEmpty(bankAccountSortCodePartA) && !string.IsNullOrEmpty(bankAccountSortCodePartB) && !string.IsNullOrEmpty(bankAccountSortCodePartC))
            {
                bankAccountSortCode = $"{bankAccountSortCodePartA}-{bankAccountSortCodePartB}-{bankAccountSortCodePartC}";
            }
            string bankAccountSWIFTCode = createCompanyConfigurationTabControlFinancialInformationTabPageBankAccountSWIFTCodeTextBox.Text.TrimEnd();
            string bankAccountVippsId = null;
            if (createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBox != null)
            {
                bankAccountVippsId = createCompanyConfigurationTabControlFinancialInformationTabPageVippsIdTextBox.Text.TrimEnd();
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
            string companyName = createCompanyConfigurationTabControlGeneralInformationTabPageCompanyNameTextBox.Text.TrimEnd();
            string emailAddress = createCompanyConfigurationTabControlGeneralInformationTabPageEmailAddressTextBox.Text.TrimEnd();
            string emailTopLevelDomain = createCompanyConfigurationTabControlGeneralInformationTabPageEmailTopLevelDomainTextBox.Text.TrimEnd();
            string telephoneNumber = createCompanyConfigurationTabControlGeneralInformationTabPageTelephoneNumberTextBox.Text.TrimEnd();
            string vatNumber = createCompanyConfigurationTabControlFinancialInformationTabPageVATNumberTextBox.Text.TrimEnd();
            string websiteURL = createCompanyConfigurationTabControlGeneralInformationTabPageWebsiteURLTextBox.Text.TrimEnd();

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