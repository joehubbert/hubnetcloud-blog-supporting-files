using CRM_WindowsForms_EnterpriseEdition.Interface;
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
            { 0, ("Čeština", "cs-cz") },
            { 1, ("Dansk", "da-dk") },
            { 2, ("Deutsch", "de-de") },
            { 3, ("English", "en-gb") },
            { 5, ("Español", "es-es") },
            { 6, ("Français", "fr-fr") },
            { 7, ("Italiano", "it-it") },
            { 8, ("Nederlands", "nl-nl") },
            { 9, ("Norsk bokmål", "nb-no") },
            { 10, ("Norsk nynorsk", "nn-no") },
            { 11, ("Polski", "pl-pl") },
            { 12, ("Português", "pt-pt") },
            { 13, ("Suomi", "fi") },
            { 14, ("Svenska", "sv-se") },
            { 15, ("한국어", "ko") },
            { 16, ("中文", "zh") },
            { 17, ("日本語", "ja-jp") }
        };
        private string? userProfileActiveDatabaseEngine;
        private string? userProfileActiveRegionLanguageCode;

        public AppConfiguration()
        {
            InitializeComponent();
            InitializeEventHandlers();
            ExistingConfigurationFileCheckAsync(); // Only this, no UI population calls here
        }

        private void InitializeEventHandlers()
        {
            appConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBox.DropDown += AdjustComboBoxWidth_DropDown;
            appConfigurationTabControlDatabaseTabPageTabControl.SelectedIndexChanged += appConfigurationTabControlDatabaseTabPageTabControl_SelectedIndexChanged;
            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelNativeRadioButton.CheckedChanged += AuthenticationTypeRadioButton_CheckedChanged;
            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelKerberosRadioButton.CheckedChanged += AuthenticationTypeRadioButton_CheckedChanged;
            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelEntraIdRadioButton.CheckedChanged += AuthenticationTypeRadioButton_CheckedChanged;
            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageAuthenticationTypePanelNativeRadioButton.CheckedChanged += AuthenticationTypeRadioButton_CheckedChanged;
            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageAuthenticationTypePanelEntraIdRadioButton.CheckedChanged += AuthenticationTypeRadioButton_CheckedChanged;
            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageAuthenticationTypePanelNativeRadioButton.CheckedChanged += AuthenticationTypeRadioButton_CheckedChanged;
            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageAuthenticationTypePanelEntraIdRadioButton.CheckedChanged += AuthenticationTypeRadioButton_CheckedChanged;
            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageConnectionTimeoutTextbox.KeyPress += NumericStringTextbox_KeyPress;
            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageConnectionTimeoutTextbox.KeyPress += NumericStringTextbox_KeyPress;
            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePortNumberTextbox.KeyPress += NumericStringTextbox_KeyPress;
            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageConnectionTimeoutTextbox.KeyPress += NumericStringTextbox_KeyPress;
            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePortNumberTextbox.KeyPress += NumericStringTextbox_KeyPress;
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
                    userProfileActiveRegionLanguageCode = await ApplicationConfigurationService.GetRegionLanguageCodeAsync();

                    // Populate combo boxes
                    appConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBoxPopulateData();
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageSSLModeComboBoxPopulateData();
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageSSLModeComboBoxPopulateData();
                    appConfigurationTabControlRegionLanguageTabPageRegionLanguageComboBoxPopulateData();

                    // Always load and populate all configurations
                    var mssqlConfig = await ApplicationConfigurationService.GetMSSQLConfigurationAsync();
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageServerNameTextbox.Text = mssqlConfig.serverName;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageDatabaseNameTextbox.Text = mssqlConfig.databaseName;
                    switch (mssqlConfig.authenticationType)
                    {
                        case "SQL":
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelNativeRadioButton.Checked = true;
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextbox.Text = mssqlConfig.username;
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextbox.Text = mssqlConfig.password;
                            break;
                        case "Kerberos":
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelKerberosRadioButton.Checked = true;
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextbox.Enabled = false;
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextbox.Enabled = false;
                            break;
                        case "EntraId":
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked = true;
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextbox.Text = mssqlConfig.username;
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextbox.Enabled = false;
                            break;
                        default:
                            throw new InvalidOperationException("Unsupported MSSQL authentication type in configuration file.");
                    }
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageCertificateHostnameTextbox.Text = mssqlConfig.certficateHostName;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageEncryptConnectionCheckbox.Checked = mssqlConfig.encryptionEnabled;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageTrustServerCertificateCheckbox.Checked = mssqlConfig.trustServerCertificate;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageConnectionTimeoutTextbox.Text = mssqlConfig.connectionTimeout.ToString();

                    var mysqlConfig = await ApplicationConfigurationService.GetMySQLConfigurationAsync();
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageServerNameTextbox.Text = mysqlConfig.serverName;
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePortNumberTextbox.Text = mysqlConfig.portNumber.ToString();
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageDatabaseNameTextbox.Text = mysqlConfig.databaseName;
                    switch (mysqlConfig.authenticationType)
                    {
                        case "native":
                            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageAuthenticationTypePanelNativeRadioButton.Checked = true;
                            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageUsernameTextbox.Text = mysqlConfig.username;
                            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePasswordTextbox.Text = mysqlConfig.password;
                            break;
                        case "EntraId":
                            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked = true;
                            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageUsernameTextbox.Text = mysqlConfig.username;
                            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePasswordTextbox.Enabled = false;
                            break;
                        default:
                            throw new InvalidOperationException("Unsupported MySQL authentication type in configuration file.");
                    }
                    mySQLSSLModeCode = mysqlSSLMode.FirstOrDefault(kvp => string.Equals(kvp.Value.ToString(), mysqlConfig.sslMode, StringComparison.OrdinalIgnoreCase)).Key;

                    var postgresqlConfig = await ApplicationConfigurationService.GetPostgreSQLConfigurationAsync();
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageServerNameTextbox.Text = postgresqlConfig.serverName;
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePortNumberTextbox.Text = postgresqlConfig.portNumber.ToString();
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageDatabaseNameTextbox.Text = postgresqlConfig.databaseName;
                    switch (postgresqlConfig.authenticationType)
                    {
                        case "native":
                            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageAuthenticationTypePanelNativeRadioButton.Checked = true;
                            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageUsernameTextbox.Text = postgresqlConfig.username;
                            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePasswordTextbox.Text = postgresqlConfig.password;
                            break;
                        case "EntraId":
                            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked = true;
                            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageUsernameTextbox.Text = postgresqlConfig.username;
                            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePasswordTextbox.Enabled = false;
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
            await ApplicationConfigurationService.SetRegionLanguageCodeAsync(appConfigurationTabControlRegionLanguageTabPageRegionLanguageChoiceComboBox.SelectedItem?.ToString()?.Split('(')[1].TrimEnd(')') ?? "en-GB");
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

        private void NumericStringTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control characters (like backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Prevent the character from being entered
                new ErrorMessageService("Warning.DataValidation.Dynamic", "Only numeric characters allowed");
            }
        }

        private void UpdateDatabaseTabAuthenticationUI()
        {
            var selectedEngine = appConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBox.Text;
            var selectedTab = appConfigurationTabControlDatabaseTabPageTabControl.SelectedTab;
            if (selectedTab == appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPage)
            {
                if (appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelNativeRadioButton.Checked)
                {
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextbox.Enabled = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextbox.Enabled = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextbox.ReadOnly = false;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextbox.ReadOnly = false;
                }
                else if (appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelKerberosRadioButton.Checked)
                {
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextbox.Enabled = false;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextbox.Enabled = false;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextbox.ReadOnly = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextbox.ReadOnly = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextbox.Clear();
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextbox.Clear();
                }
                else if (appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked)
                {
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextbox.Enabled = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextbox.Enabled = false;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextbox.ReadOnly = false;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextbox.ReadOnly = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextbox.Clear();
                }

                if (selectedEngine == "Azure SQL Database" || selectedEngine == "Azure SQL Managed Instance")
                {
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageEncryptConnectionCheckbox.Checked = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageEncryptConnectionCheckbox.Enabled = false;
                }
                else
                {
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageEncryptConnectionCheckbox.Enabled = true;
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
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageUsernameTextbox.Enabled = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePasswordTextbox.Enabled = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageUsernameTextbox.ReadOnly = false;
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePasswordTextbox.ReadOnly = false;
                }
                else if (appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked)
                {
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageUsernameTextbox.Enabled = true;
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePasswordTextbox.Enabled = false;
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageUsernameTextbox.ReadOnly = false;
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePasswordTextbox.ReadOnly = true;
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
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageUsernameTextbox.Enabled = true;
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePasswordTextbox.Enabled = true;
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageUsernameTextbox.ReadOnly = false;
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePasswordTextbox.ReadOnly = false;
                }
                else if (appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked)
                {
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageUsernameTextbox.Enabled = true;
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePasswordTextbox.Enabled = false;
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageUsernameTextbox.ReadOnly = false;
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePasswordTextbox.ReadOnly = true;
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePasswordTextbox.Clear();
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

        private void appConfigurationTabControlDatabaseTabPageTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDatabaseTabAuthenticationUI();
        }

        private void AuthenticationTypeRadioButton_CheckedChanged(object sender, EventArgs e)
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

        private void appConfigurationTabControlRegionLanguageTabPageRegionLanguageComboBoxPopulateData()
        {
            var ordered = regionLanguageOptions.OrderBy(kvp => kvp.Key).ToList();
            var comboBoxItems = ordered
                .Select(kvp => $"{kvp.Value.DisplayName} ({kvp.Value.LanguageCode})")
                .ToList();
            appConfigurationTabControlRegionLanguageTabPageRegionLanguageChoiceComboBox.DataSource = comboBoxItems;
            int selectedIndex = 3; // Default to English (en-gb), which has key 3 in the dictionary
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

            appConfigurationTabControlRegionLanguageTabPageRegionLanguageChoiceComboBox.SelectedIndex = selectedIndex;
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

        private void AdjustComboBoxWidth_DropDown(object? sender, EventArgs e)
        {
            ResizeComboBoxDropDownHelper.AdjustComboBoxDropDownWidth(sender as ComboBox);
        }

        private ApplicationConfigurationModel.ApplicationConfigurationServiceMSSQLConfiguration CreateMSSQLConfiguration()
        {
            return new ApplicationConfigurationModel.ApplicationConfigurationServiceMSSQLConfiguration
            {
                serverName = appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageServerNameTextbox.Text,
                databaseName = appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageDatabaseNameTextbox.Text,
                username = appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextbox.Text,
                password = appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextbox.Text,
                certficateHostName = appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageCertificateHostnameTextbox.Text,
                encryptionEnabled = appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageEncryptConnectionCheckbox.Checked,
                trustServerCertificate = appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageTrustServerCertificateCheckbox.Checked,
                connectionTimeout = int.TryParse(appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageConnectionTimeoutTextbox.Text, out var timeout) ? timeout : 30,
                authenticationType = appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelNativeRadioButton.Checked ? "SQL" :
                                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelKerberosRadioButton.Checked ? "Kerberos" :
                                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked ? "EntraId" : ""
            };
        }

        private ApplicationConfigurationModel.ApplicationConfigurationServiceMySQLConfiguration CreateMySQLConfiguration()
        {
            return new ApplicationConfigurationModel.ApplicationConfigurationServiceMySQLConfiguration
            {
                serverName = appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageServerNameTextbox.Text,
                portNumber = int.TryParse(appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePortNumberTextbox.Text, out var port) ? port : 3306,
                databaseName = appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageDatabaseNameTextbox.Text,
                username = appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageUsernameTextbox.Text,
                password = appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePasswordTextbox.Text,
                connectionTimeout = int.TryParse(appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageConnectionTimeoutTextbox.Text, out var timeout) ? timeout : 30,
                sslMode = appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageSSLModeComboBox.SelectedItem?.ToString() ?? "If Available",
                authenticationType = appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageAuthenticationTypePanelNativeRadioButton.Checked ? "native" :
                                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked ? "EntraId" : ""
            };
        }

        private ApplicationConfigurationModel.ApplicationConfigurationServicePostgreSQLConfiguration CreatePostgreSQLConfiguration()
        {
            return new ApplicationConfigurationModel.ApplicationConfigurationServicePostgreSQLConfiguration
            {
                serverName = appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageServerNameTextbox.Text,
                portNumber = int.TryParse(appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePortNumberTextbox.Text, out var port) ? port : 5432,
                databaseName = appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageDatabaseNameTextbox.Text,
                username = appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageUsernameTextbox.Text,
                password = appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePasswordTextbox.Text,
                connectionTimeout = int.TryParse(appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageConnectionTimeoutTextbox.Text, out var timeout) ? timeout : 30,
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