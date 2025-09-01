using CRM_WindowsForms_EnterpriseEdition.Model;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using Npgsql;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class AppConfiguration : Form
    {
        private TextBoxNumericCharacterDataValidationHelper _textBoxNumericHelper;
        private static readonly string configFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CRM-WindowsForms.EnterpriseEdition");
        private static readonly string configFilePath = Path.Combine(configFolderPath, "applicationConfiguration.json");
        private readonly Dictionary<int, string> databaseEngineOptions = new Dictionary<int, string>
        {
            { 0, "Azure Database for MySQL" },
            { 1, "Azure Database for PostgreSQL" },
            { 2, "Azure SQL Database" },
            { 3, "Azure SQL Managed Instance" },
            { 4, "Microsoft SQL Server" },
            { 5, "MySQL" },
            { 6, "PostgreSQL" }
        };
        private readonly Dictionary<int, string> delimeterOptions = new Dictionary<int, string>
        {
            { 0, "." },
            { 1, "," }
        };
        private readonly Dictionary<int, string> mysqlSSLMode = new Dictionary<int, string>
        {
            { 0, "Disabled" },
            { 1, "Required" },
            { 2, "Preferred" },
            { 3, "VerifyCA" },
            { 4, "VerifyFull" }
        };
        private int? mySQLSSLModeCode;
        private readonly Dictionary<int, string> postgresqlSSLMode = new Dictionary<int, string>
        {
            { 0, "Disable" },
            { 1, "VerifyCA" },
            { 2, "Require" },
            { 3, "VerifyFull" },
            { 4, "Allow" },
            { 5, "Prefer" }
        };
        private int? postgreSQLSSLModeCode;
        private readonly Dictionary<int, (string DisplayName, string LanguageCode)> regionLanguageOptions = new Dictionary<int, (string, string)>
        {
            { 0, ("Čeština", "cs-CZ") },
            { 1, ("Dansk", "da-DK") },
            { 2, ("Deutsch", "de-DE") },
            { 3, ("English", "en-GB") },
            { 5, ("Español", "es-ES") },
            { 6, ("Français", "fr-FR") },
            { 7, ("Italiano", "it-IT") },
            { 8, ("Nederlands", "nl-NL") },
            { 9, ("Norsk bokmål", "nb-NO") },
            { 10, ("Polski", "pl-PL") },
            { 11, ("Português", "pt-PT") },
            { 12, ("Suomi", "fi") },
            { 13, ("Svenska", "sv-SE") },
            { 14, ("한국어", "ko") },
            { 15, ("中文", "zh") },
            { 16, ("日本語", "ja-JP") }
        };

        private string? userProfileActiveDatabaseEngine;
        private string? userProfileActiveDelimeter;
        private string? userProfileActiveRegionLanguageCode;
        private string? userProfileActiveUnitType;

        public AppConfiguration()
        {
            InitializeComponent();
            _textBoxNumericHelper = new TextBoxNumericCharacterDataValidationHelper();
            //_translationService = new TranslationService();
            InitializeEventHandlers();
            ExistingConfigurationFileCheckAsync(); // Only this, no UI population calls here
        }

        private void InitializeEventHandlers()
        {
            appConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBox.DropDown += ResizeComboBoxDropDownHelper.ComboBoxDropDownResizeHandler;
            appConfigurationTabControlDatabaseTabPageTabControl.SelectedIndexChanged += appConfigurationTabControlDatabaseTabPageTabControl_SelectedIndexChanged;
            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelNativeRadioButton.CheckedChanged += AuthenticationTypeRadioButton_CheckedChanged;
            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelKerberosRadioButton.CheckedChanged += AuthenticationTypeRadioButton_CheckedChanged;
            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelEntraIdRadioButton.CheckedChanged += AuthenticationTypeRadioButton_CheckedChanged;
            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageAuthenticationTypePanelNativeRadioButton.CheckedChanged += AuthenticationTypeRadioButton_CheckedChanged;
            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageAuthenticationTypePanelEntraIdRadioButton.CheckedChanged += AuthenticationTypeRadioButton_CheckedChanged;
            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageAuthenticationTypePanelNativeRadioButton.CheckedChanged += AuthenticationTypeRadioButton_CheckedChanged;
            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageAuthenticationTypePanelEntraIdRadioButton.CheckedChanged += AuthenticationTypeRadioButton_CheckedChanged;
            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageConnectionTimeoutTextBox.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageConnectionTimeoutTextBox.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePortNumberTextBox.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageConnectionTimeoutTextBox.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePortNumberTextBox.KeyPress += _textBoxNumericHelper.NumericKeyPressHandler;
        }

        private void AppConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void ExistingConfigurationFileCheckAsync()
        {
            string dataSubject = "Application Configuration";

            if (File.Exists(configFilePath))
            {
                try
                {
                    userProfileActiveDatabaseEngine = await ApplicationConfigurationService.GetActiveDatabaseEngineAsync();
                    userProfileActiveDelimeter = await ApplicationConfigurationService.GetDelimeterAsync();
                    userProfileActiveRegionLanguageCode = await ApplicationConfigurationService.GetRegionLanguageCodeAsync();

                    // Populate combo boxes
                    appConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBoxPopulateData();
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageSSLModeComboBoxPopulateData();
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageSSLModeComboBoxPopulateData();
                    appConfigurationTabControlPersonalPreferencesTabPageDelimeterComboBoxPopulateData();
                    appConfigurationTabControlPersonalPreferencesTabPageRegionLanguageComboBoxPopulateData();

                    // Always load and populate all configurations
                    var mssqlConfig = await ApplicationConfigurationService.GetMSSQLConfigurationAsync();
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageServerNameTextBox.Text = mssqlConfig.serverName;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageDatabaseNameTextBox.Text = mssqlConfig.databaseName;
                    switch (mssqlConfig.authenticationType)
                    {
                        case "SQL":
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelNativeRadioButton.Checked = true;
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextBox.Text = mssqlConfig.username;
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextBox.Text = mssqlConfig.password;
                            break;
                        case "Kerberos":
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelKerberosRadioButton.Checked = true;
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextBox.Enabled = false;
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextBox.Enabled = false;
                            break;
                        case "EntraId":
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked = true;
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextBox.Text = mssqlConfig.username;
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextBox.Enabled = false;
                            break;
                        default:
                            throw new InvalidOperationException("Unsupported MSSQL authentication type in configuration file.");
                    }
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageCertificateHostnameTextBox.Text = mssqlConfig.certficateHostName;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageEncryptConnectionCheckBox.Checked = mssqlConfig.encryptionEnabled;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageTrustServerCertificateCheckBox.Checked = mssqlConfig.trustServerCertificate;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageConnectionTimeoutTextBox.Text = mssqlConfig.connectionTimeout.ToString();

                    var mysqlConfig = await ApplicationConfigurationService.GetMySQLConfigurationAsync();
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageServerNameTextBox.Text = mysqlConfig.serverName;
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePortNumberTextBox.Text = mysqlConfig.portNumber.ToString();
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageDatabaseNameTextBox.Text = mysqlConfig.databaseName;
                    switch (mysqlConfig.authenticationType)
                    {
                        case "native":
                            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageAuthenticationTypePanelNativeRadioButton.Checked = true;
                            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageUsernameTextBox.Text = mysqlConfig.username;
                            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePasswordTextBox.Text = mysqlConfig.password;
                            break;
                        case "EntraId":
                            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked = true;
                            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageUsernameTextBox.Text = mysqlConfig.username;
                            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePasswordTextBox.Enabled = false;
                            break;
                        default:
                            throw new InvalidOperationException("Unsupported MySQL authentication type in configuration file.");
                    }
                    mySQLSSLModeCode = mysqlSSLMode.FirstOrDefault(kvp => string.Equals(kvp.Value.ToString(), mysqlConfig.sslMode, StringComparison.OrdinalIgnoreCase)).Key;

                    var postgresqlConfig = await ApplicationConfigurationService.GetPostgreSQLConfigurationAsync();
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageServerNameTextBox.Text = postgresqlConfig.serverName;
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePortNumberTextBox.Text = postgresqlConfig.portNumber.ToString();
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageDatabaseNameTextBox.Text = postgresqlConfig.databaseName;
                    switch (postgresqlConfig.authenticationType)
                    {
                        case "native":
                            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageAuthenticationTypePanelNativeRadioButton.Checked = true;
                            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageUsernameTextBox.Text = postgresqlConfig.username;
                            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePasswordTextBox.Text = postgresqlConfig.password;
                            break;
                        case "EntraId":
                            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked = true;
                            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageUsernameTextBox.Text = postgresqlConfig.username;
                            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePasswordTextBox.Enabled = false;
                            break;
                        default:
                            throw new InvalidOperationException("Unsupported PostgreSQL authentication type in configuration file.");
                    }
                    postgreSQLSSLModeCode = postgresqlSSLMode.FirstOrDefault(kvp => string.Equals(kvp.Value.ToString(), postgresqlConfig.sslMode, StringComparison.OrdinalIgnoreCase)).Key;

                    // Set the tab focus based on the active engine
                    switch (userProfileActiveDatabaseEngine)
                    {
                        case "Microsoft SQL Server":
                        case "Azure SQL Database":
                        case "Azure SQL Managed Instance":
                            appConfigurationTabControlDatabaseTabPageTabControl.SelectedTab = appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPage;
                            break;
                        case "MySQL":
                        case "Azure Database for MySQL":
                            appConfigurationTabControlDatabaseTabPageTabControl.SelectedTab = appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPage;
                            break;
                        case "PostgreSQL":
                        case "Azure Database for PostgreSQL":
                            appConfigurationTabControlDatabaseTabPageTabControl.SelectedTab = appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPage;
                            break;
                        default:
                            throw new InvalidOperationException("Unsupported database engine in configuration file.");
                    }

                    // Logging radio buttons
                    var loggingEnabled = await ApplicationConfigurationService.GetLoggingEnabledAsync();
                    appConfigurationTabControlSystemTabPageTabControlLoggingTabPageLoggingEnabledPanelYesRadioButton.Checked = loggingEnabled;
                    appConfigurationTabControlSystemTabPageTabControlLoggingTabPageLoggingEnabledPanelNoRadioButton.Checked = !loggingEnabled;

                    // Unit Type radio buttons
                    userProfileActiveUnitType = await ApplicationConfigurationService.GetUnitTypeAsync();
                    appConfigurationTabControlPersonalPreferencesTabPageUnitTypePanelImperialRadioButton.Checked = userProfileActiveUnitType == "imperial";
                    appConfigurationTabControlPersonalPreferencesTabPageUnitTypePanelMetricRadioButton.Checked = userProfileActiveUnitType == "metric";

                    UpdateDatabaseTabAuthenticationUI();
                }
                catch (Exception ex)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
                }
            }
        }

        private async void appConfigurationSaveSettingsButton_Click(object sender, EventArgs e)
        {
            switch (appConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBox.Text)
            {
                case "Azure Database for MySQL":
                    await ApplicationConfigurationService.SetActiveDatabaseEngineAsync("Azure Database for MySQL");
                    await ApplicationConfigurationService.SetMySQLConfigurationAsync(CreateMySQLConfiguration());
                    break;
                case "Azure Database for PostgreSQL":
                    await ApplicationConfigurationService.SetActiveDatabaseEngineAsync("Azure Database for PostgreSQL");
                    await ApplicationConfigurationService.SetPostgreSQLConfigurationAsync(CreatePostgreSQLConfiguration());
                    break;
                case "Azure SQL Database":
                    await ApplicationConfigurationService.SetActiveDatabaseEngineAsync("Azure SQL Database");
                    await ApplicationConfigurationService.SetMSSQLConfigurationAsync(CreateMSSQLConfiguration());
                    break;
                case "Azure SQL Managed Instance":
                    await ApplicationConfigurationService.SetActiveDatabaseEngineAsync("Azure SQL Managed Instance");
                    await ApplicationConfigurationService.SetMSSQLConfigurationAsync(CreateMSSQLConfiguration());
                    break;
                case "Microsoft SQL Server":
                    await ApplicationConfigurationService.SetActiveDatabaseEngineAsync("Microsoft SQL Server");
                    await ApplicationConfigurationService.SetMSSQLConfigurationAsync(CreateMSSQLConfiguration());
                    break;
                case "MySQL":
                    await ApplicationConfigurationService.SetActiveDatabaseEngineAsync("MySQL");
                    await ApplicationConfigurationService.SetMySQLConfigurationAsync(CreateMySQLConfiguration());
                    break;
                case "PostgreSQL":
                    await ApplicationConfigurationService.SetActiveDatabaseEngineAsync("PostgreSQL");
                    await ApplicationConfigurationService.SetPostgreSQLConfigurationAsync(CreatePostgreSQLConfiguration());
                    break;
                default:
                    throw new InvalidOperationException("Unsupported database engine selected.");
            }
            await ApplicationConfigurationService.SetDelimeterAsync(appConfigurationTabControlPersonalPreferencesTabPageDelimeterComboBox.SelectedItem?.ToString() ?? ".");
            await ApplicationConfigurationService.SetRegionLanguageCodeAsync(appConfigurationTabControlPersonalPreferencesTabPageRegionLanguageComboBox.SelectedItem?.ToString()?.Split('(')[1].TrimEnd(')') ?? "en-GB");
            if (appConfigurationTabControlPersonalPreferencesTabPageUnitTypePanelImperialRadioButton.Checked)
            {
                await ApplicationConfigurationService.SetUnitTypeAsync("imperial");
            }
            else if (appConfigurationTabControlPersonalPreferencesTabPageUnitTypePanelMetricRadioButton.Checked)
            {
                await ApplicationConfigurationService.SetUnitTypeAsync("metric");
            }
            if (appConfigurationTabControlSystemTabPageTabControlLoggingTabPageLoggingEnabledPanelYesRadioButton.Checked)
            {
                await ApplicationConfigurationService.SetLoggingEnabledAsync(true);
            }
            else if (appConfigurationTabControlSystemTabPageTabControlLoggingTabPageLoggingEnabledPanelNoRadioButton.Checked)
            {
                await ApplicationConfigurationService.SetLoggingEnabledAsync(false);
            }

            ErrorMessageService errorMessageService = new ErrorMessageService("Information.ApplicationConfiguration.Settings.Saved");
        }

        private void appConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBoxPopulateData()
        {
            var ordered = databaseEngineOptions.OrderBy(kvp => kvp.Key).ToList();
            var comboBoxItems = ordered.Select(kvp => kvp.Value).ToList();
            appConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBox.DataSource = comboBoxItems;
            int selectedIndex = 4; // Default to MSSQL, which has key 4 in the dictionary
            if (userProfileActiveDatabaseEngine != null)
            {
                var idx = ordered.FindIndex(kvp => kvp.Value.Equals(userProfileActiveDatabaseEngine, StringComparison.OrdinalIgnoreCase));
                if (idx >= 0)
                    selectedIndex = idx;
            }
            appConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBox.SelectedIndex = selectedIndex;
        }

        private void UpdateDatabaseTabAuthenticationUI()
        {
            var selectedEngine = appConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBox.Text;
            var selectedTab = appConfigurationTabControlDatabaseTabPageTabControl.SelectedTab;
            if (selectedTab == appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPage)
            {
                if (appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelNativeRadioButton.Checked)
                {
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextBox.Enabled = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextBox.Enabled = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextBox.ReadOnly = false;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextBox.ReadOnly = false;
                }
                else if (appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelKerberosRadioButton.Checked)
                {
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextBox.Enabled = false;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextBox.Enabled = false;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextBox.ReadOnly = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextBox.ReadOnly = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextBox.Clear();
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextBox.Clear();
                }
                else if (appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked)
                {
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextBox.Enabled = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextBox.Enabled = false;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextBox.ReadOnly = false;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextBox.ReadOnly = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextBox.Clear();
                }

                if (selectedEngine == "Azure SQL Database" || selectedEngine == "Azure SQL Managed Instance")
                {
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageEncryptConnectionCheckBox.Checked = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageEncryptConnectionCheckBox.Enabled = false;
                }
                else
                {
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageEncryptConnectionCheckBox.Enabled = true;
                }

                if (selectedEngine == "Azure SQL Database")
                {
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelNativeRadioButton.Enabled = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelKerberosRadioButton.Checked = false;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelKerberosRadioButton.Enabled = false;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelEntraIdRadioButton.Enabled = true;
                }
                else if (selectedEngine == "Azure SQL Managed Instance" || selectedEngine == "Microsoft SQL Server")
                {
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelNativeRadioButton.Enabled = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelKerberosRadioButton.Enabled = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelEntraIdRadioButton.Enabled = true;
                }
            }
            else if (selectedTab == appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPage)
            {
                if (appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageAuthenticationTypePanelNativeRadioButton.Checked)
                {
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageUsernameTextBox.Enabled = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePasswordTextBox.Enabled = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageUsernameTextBox.ReadOnly = false;
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePasswordTextBox.ReadOnly = false;
                }
                else if (appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked)
                {
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageUsernameTextBox.Enabled = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePasswordTextBox.Enabled = false;
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageUsernameTextBox.ReadOnly = false;
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePasswordTextBox.ReadOnly = true;
                }

                if (selectedEngine == "Azure Database for MySQL")
                {
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageSSLModeComboBox.DataSource = null;
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageSSLModeComboBox.Items.Clear();
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageSSLModeComboBox.Items.Add(mysqlSSLMode[1]);
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageSSLModeComboBox.SelectedIndex = 0;
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageSSLModeComboBox.Enabled = false;
                }
                else
                {
                    // Restore normal SSLMode options and enable selection
                    var ordered = mysqlSSLMode.OrderBy(kvp => kvp.Key).ToList();
                    var comboBoxItems = ordered.Select(kvp => kvp.Value).ToList();
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageSSLModeComboBox.DataSource = comboBoxItems;
                    int selectedIndex = 2; // Default to Preferred
                    if (mySQLSSLModeCode != null)
                    {
                        var idx = ordered.FindIndex(kvp => kvp.Key == mySQLSSLModeCode.Value);
                        if (idx >= 0)
                            selectedIndex = idx;
                    }
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageSSLModeComboBox.SelectedIndex = selectedIndex;
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageSSLModeComboBox.Enabled = true;
                }
            }
            else if (selectedTab == appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPage)
            {
                if (appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageAuthenticationTypePanelNativeRadioButton.Checked)
                {
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageUsernameTextBox.Enabled = true;
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePasswordTextBox.Enabled = true;
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageUsernameTextBox.ReadOnly = false;
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePasswordTextBox.ReadOnly = false;
                }
                else if (appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked)
                {
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageUsernameTextBox.Enabled = true;
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePasswordTextBox.Enabled = false;
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageUsernameTextBox.ReadOnly = false;
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePasswordTextBox.ReadOnly = true;
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePasswordTextBox.Clear();
                }

                if (selectedEngine == "Azure Database for PostgreSQL")
                {
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageSSLModeComboBox.DataSource = null;
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageSSLModeComboBox.Items.Clear();
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageSSLModeComboBox.Items.Add(postgresqlSSLMode[2]);
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageSSLModeComboBox.SelectedIndex = 0;
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageSSLModeComboBox.Enabled = false;
                }
                else
                {
                    // Restore normal SSLMode options and enable selection
                    var ordered = postgresqlSSLMode.OrderBy(kvp => kvp.Key).ToList();
                    var comboBoxItems = ordered.Select(kvp => kvp.Value).ToList();
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageSSLModeComboBox.DataSource = comboBoxItems;
                    int selectedIndex = 5; // Default to Preferred
                    if (postgreSQLSSLModeCode != null)
                    {
                        var idx = ordered.FindIndex(kvp => kvp.Key == postgreSQLSSLModeCode.Value);
                        if (idx >= 0)
                            selectedIndex = idx;
                    }
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageSSLModeComboBox.SelectedIndex = selectedIndex;
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageSSLModeComboBox.Enabled = true;
                }
            }
        }

        private void appConfigurationTabControlDatabaseTabPageTabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            UpdateDatabaseTabAuthenticationUI();
        }

        private void AuthenticationTypeRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            UpdateDatabaseTabAuthenticationUI();
        }

        private void appConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedValue = appConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBox.SelectedItem?.ToString();
            if (selectedValue == null) return;
            userProfileActiveDatabaseEngine = selectedValue;
            // Show the appropriate tab based on the selected database engine
            switch (selectedValue)
            {
                case "Azure SQL Database":
                case "Azure SQL Managed Instance":
                case "Microsoft SQL Server":
                    appConfigurationTabControlDatabaseTabPageTabControl.SelectedTab = appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPage;
                    break;
                case "Azure Database for MySQL":
                case "MySQL":
                    appConfigurationTabControlDatabaseTabPageTabControl.SelectedTab = appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPage;
                    break;
                case "Azure Database for PostgreSQL":
                case "PostgreSQL":
                    appConfigurationTabControlDatabaseTabPageTabControl.SelectedTab = appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPage;
                    break;
                default:
                    throw new InvalidOperationException("Unsupported database engine selected.");
            }
            UpdateDatabaseTabAuthenticationUI();
        }

        private void appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageSSLModeComboBoxPopulateData()
        {
            var ordered = mysqlSSLMode.OrderBy(kvp => kvp.Key).ToList();
            var comboBoxItems = ordered.Select(kvp => kvp.Value).ToList();
            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageSSLModeComboBox.DataSource = comboBoxItems;
            int selectedIndex = 2; // Default to Preferred, which has key 2 in the dictionary
            if (mySQLSSLModeCode != null)
            {
                var idx = ordered.FindIndex(kvp => kvp.Key == mySQLSSLModeCode.Value);
                if (idx >= 0)
                    selectedIndex = idx;
            }

            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageSSLModeComboBox.SelectedIndex = selectedIndex;
        }

        private void appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageSSLModeComboBoxPopulateData()
        {
            var ordered = postgresqlSSLMode.OrderBy(kvp => kvp.Key).ToList();
            var comboBoxItems = ordered.Select(kvp => kvp.Value).ToList();
            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageSSLModeComboBox.DataSource = comboBoxItems;
            int selectedIndex = 5; // Default to Preferred, which has key 5 in the dictionary
            if (postgreSQLSSLModeCode != null)
            {
                var idx = ordered.FindIndex(kvp => kvp.Key == postgreSQLSSLModeCode.Value);
                if (idx >= 0)
                    selectedIndex = idx;
            }
            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageSSLModeComboBox.SelectedIndex = selectedIndex;
        }

        private void appConfigurationTabControlPersonalPreferencesTabPageDelimeterComboBoxPopulateData()
        {
            var ordered = delimeterOptions.OrderBy(kvp => kvp.Key).ToList();
            var comboBoxItems = ordered.Select(kvp => kvp.Value).ToList();
            appConfigurationTabControlPersonalPreferencesTabPageDelimeterComboBox.DataSource = comboBoxItems;
            var delimiterValue = userProfileActiveDelimeter?.Trim();

            if (!string.IsNullOrWhiteSpace(delimiterValue) && comboBoxItems.Contains(delimiterValue))
            {
                appConfigurationTabControlPersonalPreferencesTabPageDelimeterComboBox.SelectedItem = delimiterValue;
            }
            else
            {
                appConfigurationTabControlPersonalPreferencesTabPageDelimeterComboBox.SelectedIndex = 0;
            }
        }

        private void appConfigurationTabControlPersonalPreferencesTabPageRegionLanguageComboBoxPopulateData()
        {
            var ordered = regionLanguageOptions.OrderBy(kvp => kvp.Key).ToList();
            var comboBoxItems = ordered
                .Select(kvp => $"{kvp.Value.DisplayName} ({kvp.Value.LanguageCode})")
                .ToList();
            appConfigurationTabControlPersonalPreferencesTabPageRegionLanguageComboBox.DataSource = comboBoxItems;
            int selectedIndex = 3; // Default to English (en-GB), which has key 3 in the dictionary
            if (!string.IsNullOrWhiteSpace(userProfileActiveRegionLanguageCode))
            {
                var idx = ordered.FindIndex(kvp =>
                    kvp.Value.LanguageCode.Equals(userProfileActiveRegionLanguageCode, StringComparison.OrdinalIgnoreCase) ||
                    kvp.Value.LanguageCode.Equals(userProfileActiveRegionLanguageCode, StringComparison.InvariantCultureIgnoreCase) ||
                    kvp.Value.LanguageCode.ToLowerInvariant() == userProfileActiveRegionLanguageCode.ToLowerInvariant()
                );
                if (idx >= 0)
                    selectedIndex = idx;
            }

            appConfigurationTabControlPersonalPreferencesTabPageRegionLanguageComboBox.SelectedIndex = selectedIndex;
        }

        private void appConfigurationTabControlDatabaseTabPageTestConnectionButton_Click(object sender, EventArgs e)
        {
            switch (appConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBox.Text)
            {
                case "Azure SQL Database":
                case "Azure SQL Managed Instance":
                case "Microsoft SQL Server":
                    TestMSSQLConnection();
                    break;
                case "MySQL":
                case "Azure Database for MySQL":
                    TestMySQLConnection();
                    break;
                case "PostgreSQL":
                case "Azure Database for PostgreSQL":
                    TestPostgreSQLConnection();
                    break;
                default:
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.InvalidEngine");
                    break;
            }
        }

        private void appConfigurationTabControlSystemTabPageTabControlLoggingTabPageClearLogButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                    "This will delete all collected logs. Are you sure?",
                    "Warning",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                new ApplicationLoggingService("ClearLogFile");
                ErrorMessageService errorMessageService = new ErrorMessageService("Warning.LoggingService.Clear");
            }
            else
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Information.LoggingService.Clear.Cancellation");
            }

        }

        private void appConfigurationTabControlSystemTabPageTabControlLoggingTabPageViewLogButton_Click(object sender, EventArgs e)
        {
            new ApplicationLoggingService("CreateLogFileIfNotExists");
            new ApplicationLoggingService("OpenLogFile");
        }

        private ApplicationConfigurationModel.ApplicationConfigurationServiceMSSQLConfiguration CreateMSSQLConfiguration()
        {
            return new ApplicationConfigurationModel.ApplicationConfigurationServiceMSSQLConfiguration
            {
                serverName = appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageServerNameTextBox.Text,
                databaseName = appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageDatabaseNameTextBox.Text,
                username = appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextBox.Text,
                password = appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextBox.Text,
                certficateHostName = appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageCertificateHostnameTextBox.Text,
                encryptionEnabled = appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageEncryptConnectionCheckBox.Checked,
                trustServerCertificate = appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageTrustServerCertificateCheckBox.Checked,
                connectionTimeout = int.TryParse(appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageConnectionTimeoutTextBox.Text, out var timeout) ? timeout : 30,
                authenticationType = appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelNativeRadioButton.Checked ? "SQL" :
                                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelKerberosRadioButton.Checked ? "Kerberos" :
                                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked ? "EntraId" : ""
            };
        }

        private ApplicationConfigurationModel.ApplicationConfigurationServiceMySQLConfiguration CreateMySQLConfiguration()
        {
            return new ApplicationConfigurationModel.ApplicationConfigurationServiceMySQLConfiguration
            {
                serverName = appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageServerNameTextBox.Text,
                portNumber = int.TryParse(appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePortNumberTextBox.Text, out var port) ? port : 3306,
                databaseName = appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageDatabaseNameTextBox.Text,
                username = appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageUsernameTextBox.Text,
                password = appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePasswordTextBox.Text,
                connectionTimeout = int.TryParse(appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageConnectionTimeoutTextBox.Text, out var timeout) ? timeout : 30,
                sslMode = appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageSSLModeComboBox.SelectedItem?.ToString() ?? "If Available",
                authenticationType = appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageAuthenticationTypePanelNativeRadioButton.Checked ? "native" :
                                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked ? "EntraId" : ""
            };
        }

        private ApplicationConfigurationModel.ApplicationConfigurationServicePostgreSQLConfiguration CreatePostgreSQLConfiguration()
        {
            return new ApplicationConfigurationModel.ApplicationConfigurationServicePostgreSQLConfiguration
            {
                serverName = appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageServerNameTextBox.Text,
                portNumber = int.TryParse(appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePortNumberTextBox.Text, out var port) ? port : 5432,
                databaseName = appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageDatabaseNameTextBox.Text,
                username = appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageUsernameTextBox.Text,
                password = appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePasswordTextBox.Text,
                connectionTimeout = int.TryParse(appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageConnectionTimeoutTextBox.Text, out var timeout) ? timeout : 30,
                sslMode = appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageSSLModeComboBox.SelectedItem?.ToString() ?? "prefer",
                authenticationType = appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageAuthenticationTypePanelNativeRadioButton.Checked ? "native" :
                                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked ? "EntraId" : ""
            };
        }

        private void TestMSSQLConnection()
        {
            var mssqlConfig = CreateMSSQLConfiguration();
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = mssqlConfig.serverName,
                InitialCatalog = mssqlConfig.databaseName,
                Encrypt = mssqlConfig.encryptionEnabled,
                TrustServerCertificate = mssqlConfig.trustServerCertificate,
                ApplicationName = "CRM-WindowsForms-EnterpriseEdition",
                ConnectTimeout = mssqlConfig.connectionTimeout
            };

            var selectedEngine = appConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBox.Text;

            // Set authentication and credentials based on mssqlConfig
            if (mssqlConfig.authenticationType == "Kerberos")
            {
                builder.IntegratedSecurity = true; // Use Windows Authentication
            }
            else if (mssqlConfig.authenticationType == "SQL")
            {
                builder.IntegratedSecurity = false; // Use SQL Authentication
            }
            else if (mssqlConfig.authenticationType == "EntraId")
            {
                builder.IntegratedSecurity = false; // Use Entra ID Authentication
                builder.Authentication = SqlAuthenticationMethod.ActiveDirectoryInteractive;
            }
            else
            {
                throw new InvalidOperationException("Unsupported MSSQL authentication type in configuration file.");
            }
            if (mssqlConfig.authenticationType == "SQL" || mssqlConfig.authenticationType == "EntraId")
            {
                if (!string.IsNullOrWhiteSpace(mssqlConfig.username))
                    builder.UserID = mssqlConfig.username;
                if (mssqlConfig.authenticationType == "SQL" && !string.IsNullOrWhiteSpace(mssqlConfig.password))
                    builder.Password = mssqlConfig.password;
            }

            // Azure SQL specific settings
            if (selectedEngine == "Azure SQL Database" || selectedEngine == "Azure SQL Managed Instance")
            {
                builder.Encrypt = true;
            }

            var connectionString = builder.ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.Database.Connection.Test.Successful");
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.Failed", null, ex.Message);
            }
        }

        private void TestMySQLConnection()
        {
            var mySQLConfig = CreateMySQLConfiguration();
            var builder = new MySqlConnectionStringBuilder
            {
                Server = mySQLConfig.serverName,
                Port = (uint)mySQLConfig.portNumber,
                Database = mySQLConfig.databaseName,
                UserID = mySQLConfig.username,
                Password = mySQLConfig.password,
                SslMode = (MySqlSslMode)Enum.Parse(typeof(MySqlSslMode), mySQLConfig.sslMode, true),
                ConnectionTimeout = (uint)mySQLConfig.connectionTimeout
            };
            if (appConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBox.Text == "Azure Database for MySQL")
            {
                builder.SslMode = MySqlSslMode.Required;
            }
            var connectionString = builder.ConnectionString;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.Database.Connection.Test.Successful");
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.Failed", null, ex.Message);
            }
        }

        private void TestPostgreSQLConnection()
        {
            var postgreSQLConfig = CreatePostgreSQLConfiguration();
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = postgreSQLConfig.serverName,
                Port = postgreSQLConfig.portNumber,
                Database = postgreSQLConfig.databaseName,
                Username = postgreSQLConfig.username,
                Password = postgreSQLConfig.password,
                SslMode = (SslMode)Enum.Parse(typeof(SslMode), postgreSQLConfig.sslMode, true),
                Timeout = postgreSQLConfig.connectionTimeout
            };
            if (appConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBox.Text == "Azure Database for PostgreSQL")
            {
                builder.SslMode = SslMode.Require;
            }
            var connectionString = builder.ConnectionString;
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    ErrorMessageService errorMessageService = new ErrorMessageService("Information.Database.Connection.Test.Successful");
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Database.Connection.Failed", null, ex.Message);
            }
        }
    }
}