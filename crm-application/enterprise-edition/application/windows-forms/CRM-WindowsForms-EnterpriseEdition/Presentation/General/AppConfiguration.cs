using CRM.Helpers;
using CRM.Model;
using CRM.Services;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using Npgsql;
using System.Data;

namespace CRM.Presentation.General
{
    public partial class AppConfiguration : Form
    {
        private TextBoxNumericCharacterDataValidationHelper _textBoxNumericHelper = new TextBoxNumericCharacterDataValidationHelper();
        private TranslationService _translationService = new TranslationService();
        private static readonly string configFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CRM-WindowsForms.EnterpriseEdition");
        private static readonly string configFilePath = Path.Combine(configFolderPath, "applicationConfiguration.json");
        private readonly Dictionary<int, (DatabaseEngine Engine, string DisplayName)> databaseEngineOptions = new Dictionary<int, (DatabaseEngine, string)>
        {
            { 0, (DatabaseEngine.AzureDatabaseForMySQL, "Azure Database for MySQL") },
            { 1, (DatabaseEngine.AzureDatabaseForPostgreSQL, "Azure Database for PostgreSQL") },
            { 2, (DatabaseEngine.AzureSQLDatabase, "Azure SQL Database") },
            { 3, (DatabaseEngine.AzureSQLManagedInstance, "Azure SQL Managed Instance") },
            { 4, (DatabaseEngine.MicrosoftSQLServer, "Microsoft SQL Server") },
            { 5, (DatabaseEngine.MySQL, "MySQL") },
            { 6, (DatabaseEngine.PostgreSQL, "PostgreSQL") }
        };
        private readonly Dictionary<int, (Delimeter Delimeter, string DisplayName)> delimeterOptions = new Dictionary<int, (Delimeter, string)>
        {
            { 0, (Delimeter.Comma, ",") },
            { 1, (Delimeter.Period, ".") },
        };
        private readonly Dictionary<int, MySQLSSLMode> mysqlSSLMode = new Dictionary<int, MySQLSSLMode>
        {
            { 0, MySQLSSLMode.Disabled },
            { 1, MySQLSSLMode.Preferred },
            { 2, MySQLSSLMode.Required },
            { 3, MySQLSSLMode.VerifyCA },
            { 4, MySQLSSLMode.VerifyFull }
        };
        private int? mySQLSSLModeCode;
        private readonly Dictionary<int, PostgreSQLSSLMode> postgresqlSSLMode = new Dictionary<int, PostgreSQLSSLMode>
        {
            { 0, PostgreSQLSSLMode.Allow },
            { 1, PostgreSQLSSLMode.Disable },
            { 2, PostgreSQLSSLMode.Prefer },
            { 3, PostgreSQLSSLMode.Require },
            { 4, PostgreSQLSSLMode.VerifyCA },
            { 5, PostgreSQLSSLMode.VerifyFull }
        };
        private int? postgreSQLSSLModeCode;
        private readonly Dictionary<int, (string DisplayName, LanguageRegionCode LanguageRegionCode)> regionLanguageOptions = new Dictionary<int, (string, LanguageRegionCode)>
        {
            { 0, ("Čeština", LanguageRegionCode.czCZ) },
            { 1, ("Dansk", LanguageRegionCode.daDK) },
            { 2, ("Deutsch", LanguageRegionCode.deDE) },
            { 3, ("English", LanguageRegionCode.enGB) },
            { 5, ("Español", LanguageRegionCode.esES) },
            { 6, ("Français", LanguageRegionCode.frFR) },
            { 7, ("Italiano", LanguageRegionCode.itIT) },
            { 8, ("Nederlands", LanguageRegionCode.nlNL) },
            { 9, ("Norsk bokmål", LanguageRegionCode.nbNO) },
            { 10, ("Polski", LanguageRegionCode.plPL) },
            { 11, ("Português", LanguageRegionCode.ptPT) },
            { 12, ("Suomi", LanguageRegionCode.fi) },
            { 13, ("Svenska", LanguageRegionCode.svSE) },
            { 14, ("한국어", LanguageRegionCode.ko) },
            { 15, ("中文", LanguageRegionCode.zh) },
            { 16, ("日本語", LanguageRegionCode.jaJP) }
        };

        private DatabaseEngine? userProfileActiveDatabaseEngine;
        private string? userProfileActiveDelimeter;
        private LanguageRegionCode? userProfileActiveLanguageRegionCode;
        private UnitType? userProfileActiveUnitType;

        public AppConfiguration()
        {
            InitializeComponent();
            InitializeEventHandlers();
            ExistingConfigurationFileCheckAsync();
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

        private void AuthenticationTypeRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            UpdateDatabaseTabAuthenticationUI();
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
                    userProfileActiveLanguageRegionCode = await ApplicationConfigurationService.GetLanguageRegionCodeAsync();

                    // Populate combo boxes
                    appConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBoxPopulateData();
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageSSLModeComboBoxPopulateData();
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageSSLModeComboBoxPopulateData();
                    appConfigurationTabControlPersonalPreferencesTabPageDelimeterComboBoxPopulateData();
                    appConfigurationTabControlPersonalPreferencesTabPageRegionLanguageComboBoxPopulateData();

                    // Always load and populate all configurations
                    var mssqlConfig = await ApplicationConfigurationService.GetMSSQLConfigurationAsync();
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageServerNameTextBox.Text = mssqlConfig.serverName ?? string.Empty;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageDatabaseNameTextBox.Text = mssqlConfig.databaseName ?? string.Empty;
                    switch (mssqlConfig.authenticationType)
                    {
                        case MSSQLAuthenticationType.EntraId:
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked = true;
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextBox.Text = mssqlConfig.username ?? string.Empty;
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextBox.Enabled = false;
                            break;
                        case MSSQLAuthenticationType.SQLServer:
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelNativeRadioButton.Checked = true;
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextBox.Text = mssqlConfig.username ?? string.Empty;
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextBox.Text = mssqlConfig.password ?? string.Empty;
                            break;
                        case MSSQLAuthenticationType.Windows:
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelKerberosRadioButton.Checked = true;
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageUsernameTextBox.Enabled = false;
                            appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPagePasswordTextBox.Enabled = false;
                            break;
                        default:
                            throw new InvalidOperationException("Unsupported MSSQL authentication type in configuration file.");
                    }
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageCertificateHostnameTextBox.Text = mssqlConfig.certficateHostName ?? string.Empty;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageEncryptConnectionCheckBox.Checked = mssqlConfig.encryptionEnabled;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageTrustServerCertificateCheckBox.Checked = mssqlConfig.trustServerCertificate;
                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageConnectionTimeoutTextBox.Text = mssqlConfig.connectionTimeout.ToString();

                    var mysqlConfig = await ApplicationConfigurationService.GetMySQLConfigurationAsync();
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageServerNameTextBox.Text = mysqlConfig.serverName ?? string.Empty;
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePortNumberTextBox.Text = mysqlConfig.portNumber.ToString();
                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageDatabaseNameTextBox.Text = mysqlConfig.databaseName ?? string.Empty;
                    switch (mysqlConfig.authenticationType)
                    {
                        case MySQLAuthenticationType.EntraId:
                            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked = true;
                            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageUsernameTextBox.Text = mysqlConfig.username ?? string.Empty;
                            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePasswordTextBox.Enabled = false;
                            break;
                        case MySQLAuthenticationType.Native:
                            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageAuthenticationTypePanelNativeRadioButton.Checked = true;
                            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageUsernameTextBox.Text = mysqlConfig.username ?? string.Empty;
                            appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePasswordTextBox.Text = mysqlConfig.password ?? string.Empty;
                            break;
                        default:
                            throw new InvalidOperationException("Unsupported MySQL authentication type in configuration file.");
                    }
                    mySQLSSLModeCode = mysqlSSLMode.FirstOrDefault(kvp => string.Equals(kvp.Value.ToString(), mysqlConfig.sslMode.ToString(), StringComparison.OrdinalIgnoreCase)).Key;

                    var postgresqlConfig = await ApplicationConfigurationService.GetPostgreSQLConfigurationAsync();
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageServerNameTextBox.Text = postgresqlConfig.serverName ?? string.Empty;
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePortNumberTextBox.Text = postgresqlConfig.portNumber.ToString();
                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageDatabaseNameTextBox.Text = postgresqlConfig.databaseName ?? string.Empty;
                    switch (postgresqlConfig.authenticationType)
                    {
                        case PostgreSQLAuthenticationType.EntraId:
                            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked = true;
                            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageUsernameTextBox.Text = postgresqlConfig.username ?? string.Empty;
                            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePasswordTextBox.Enabled = false;
                            break;
                        case PostgreSQLAuthenticationType.Native:
                            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageAuthenticationTypePanelNativeRadioButton.Checked = true;
                            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageUsernameTextBox.Text = postgresqlConfig.username ?? string.Empty;
                            appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePasswordTextBox.Text = postgresqlConfig.password ?? string.Empty;
                            break;
                        default:
                            throw new InvalidOperationException("Unsupported PostgreSQL authentication type in configuration file.");
                    }
                    postgreSQLSSLModeCode = postgresqlSSLMode.FirstOrDefault(kvp => string.Equals(kvp.Value.ToString(), postgresqlConfig.sslMode.ToString(), StringComparison.OrdinalIgnoreCase)).Key;

                    // Set the tab focus based on the active engine
                    switch (userProfileActiveDatabaseEngine)
                    {
                        case DatabaseEngine.AzureSQLDatabase:
                        case DatabaseEngine.AzureSQLManagedInstance:
                        case DatabaseEngine.MicrosoftSQLServer:
                            appConfigurationTabControlDatabaseTabPageTabControl.SelectedTab = appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPage;
                            break;
                        case DatabaseEngine.AzureDatabaseForMySQL:
                        case DatabaseEngine.MySQL:
                            appConfigurationTabControlDatabaseTabPageTabControl.SelectedTab = appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPage;
                            break;
                        case DatabaseEngine.AzureDatabaseForPostgreSQL:
                        case DatabaseEngine.PostgreSQL:
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
                    appConfigurationTabControlPersonalPreferencesTabPageUnitTypePanelImperialRadioButton.Checked = userProfileActiveUnitType == UnitType.Imperial;
                    appConfigurationTabControlPersonalPreferencesTabPageUnitTypePanelMetricRadioButton.Checked = userProfileActiveUnitType == UnitType.Metric;

                    UpdateDatabaseTabAuthenticationUI();
                }
                catch (Exception ex)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
                }
            }
        }

        private LanguageRegionCode GetSelectedLanguageRegionCode()
        {
            var selectedItem = appConfigurationTabControlPersonalPreferencesTabPageRegionLanguageComboBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedItem))
                return LanguageRegionCode.enGB;

            // Extract the LanguageRegionCode from the formatted string "Language (Code)"
            var startIndex = selectedItem.LastIndexOf('(') + 1;
            var endIndex = selectedItem.LastIndexOf(')');

            if (startIndex > 0 && endIndex > startIndex)
            {
                var codeString = selectedItem.Substring(startIndex, endIndex - startIndex);
                if (Enum.TryParse<LanguageRegionCode>(codeString, out var regionCode))
                {
                    return regionCode;
                }
            }

            return LanguageRegionCode.enGB; // Default fallback
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
            if (mssqlConfig.authenticationType == MSSQLAuthenticationType.Windows)
            {
                builder.IntegratedSecurity = true; // Use Windows Authentication
            }
            else if (mssqlConfig.authenticationType == MSSQLAuthenticationType.SQLServer)
            {
                builder.IntegratedSecurity = false; // Use SQL Authentication
            }
            else if (mssqlConfig.authenticationType == MSSQLAuthenticationType.EntraId)
            {
                builder.IntegratedSecurity = false; // Use Entra ID Authentication
                builder.Authentication = SqlAuthenticationMethod.ActiveDirectoryInteractive;
            }
            else
            {
                throw new InvalidOperationException("Unsupported MSSQL authentication type in configuration file.");
            }
            if (mssqlConfig.authenticationType == MSSQLAuthenticationType.SQLServer || mssqlConfig.authenticationType == MSSQLAuthenticationType.EntraId)
            {
                if (!string.IsNullOrWhiteSpace(mssqlConfig.username))
                    builder.UserID = mssqlConfig.username;
                if (mssqlConfig.authenticationType == MSSQLAuthenticationType.SQLServer && !string.IsNullOrWhiteSpace(mssqlConfig.password))
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
                SslMode = (MySqlSslMode)Enum.Parse(typeof(MySqlSslMode), mySQLConfig.sslMode.ToString(), true),
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
                SslMode = (SslMode)Enum.Parse(typeof(SslMode), postgreSQLConfig.sslMode.ToString(), true),
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

        private async void appConfigurationSaveSettingsButton_Click(object sender, EventArgs e)
        {
            switch (appConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBox.Text)
            {
                case "Azure Database for MySQL":
                    await ApplicationConfigurationService.SetActiveDatabaseEngineAsync(DatabaseEngine.AzureDatabaseForMySQL);
                    await ApplicationConfigurationService.SetMySQLConfigurationAsync(CreateMySQLConfiguration());
                    break;
                case "Azure Database for PostgreSQL":
                    await ApplicationConfigurationService.SetActiveDatabaseEngineAsync(DatabaseEngine.AzureDatabaseForPostgreSQL);
                    await ApplicationConfigurationService.SetPostgreSQLConfigurationAsync(CreatePostgreSQLConfiguration());
                    break;
                case "Azure SQL Database":
                    await ApplicationConfigurationService.SetActiveDatabaseEngineAsync(DatabaseEngine.AzureSQLDatabase);
                    await ApplicationConfigurationService.SetMSSQLConfigurationAsync(CreateMSSQLConfiguration());
                    break;
                case "Azure SQL Managed Instance":
                    await ApplicationConfigurationService.SetActiveDatabaseEngineAsync(DatabaseEngine.AzureSQLManagedInstance);
                    await ApplicationConfigurationService.SetMSSQLConfigurationAsync(CreateMSSQLConfiguration());
                    break;
                case "Microsoft SQL Server":
                    await ApplicationConfigurationService.SetActiveDatabaseEngineAsync(DatabaseEngine.MicrosoftSQLServer);
                    await ApplicationConfigurationService.SetMSSQLConfigurationAsync(CreateMSSQLConfiguration());
                    break;
                case "MySQL":
                    await ApplicationConfigurationService.SetActiveDatabaseEngineAsync(DatabaseEngine.MySQL);
                    await ApplicationConfigurationService.SetMySQLConfigurationAsync(CreateMySQLConfiguration());
                    break;
                case "PostgreSQL":
                    await ApplicationConfigurationService.SetActiveDatabaseEngineAsync(DatabaseEngine.PostgreSQL);
                    await ApplicationConfigurationService.SetPostgreSQLConfigurationAsync(CreatePostgreSQLConfiguration());
                    break;
                default:
                    throw new InvalidOperationException("Unsupported database engine selected.");
            }
            await ApplicationConfigurationService.SetDelimeterAsync(appConfigurationTabControlPersonalPreferencesTabPageDelimeterComboBox.SelectedItem?.ToString() ?? ".");
            await ApplicationConfigurationService.SetLanguageRegionCodeAsync(GetSelectedLanguageRegionCode());
            if (appConfigurationTabControlPersonalPreferencesTabPageUnitTypePanelImperialRadioButton.Checked)
            {
                await ApplicationConfigurationService.SetUnitTypeAsync(UnitType.Imperial);
            }
            else if (appConfigurationTabControlPersonalPreferencesTabPageUnitTypePanelMetricRadioButton.Checked)
            {
                await ApplicationConfigurationService.SetUnitTypeAsync(UnitType.Metric);
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
            var comboBoxItems = ordered.Select(kvp => kvp.Value.DisplayName).ToList();
            appConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBox.DataSource = comboBoxItems;
            int selectedIndex = 4; // Default to MSSQL, which has key 4 in the dictionary
            if (userProfileActiveDatabaseEngine != null)
            {
                var matchingEngine = ordered.FirstOrDefault(kvp => kvp.Value.Engine == userProfileActiveDatabaseEngine);
                if (matchingEngine.Key != 0 || matchingEngine.Value.Engine == userProfileActiveDatabaseEngine)
                {
                    selectedIndex = ordered.FindIndex(kvp => kvp.Key == matchingEngine.Key);
                }
            }
            appConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBox.SelectedIndex = selectedIndex;
        }

        private void appConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedText = appConfigurationTabControlDatabaseTabPageDatabaseEngineChoiceComboBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedText)) return;

            // Find the corresponding database engine
            var selectedEngine = databaseEngineOptions.Values.FirstOrDefault(v => v.DisplayName == selectedText);
            if (selectedEngine.Engine == default) return;

            userProfileActiveDatabaseEngine = selectedEngine.Engine;

            // Show the appropriate tab based on the selected database engine
            switch (selectedEngine.Engine)
            {
                case DatabaseEngine.AzureSQLDatabase:
                case DatabaseEngine.AzureSQLManagedInstance:
                case DatabaseEngine.MicrosoftSQLServer:
                    appConfigurationTabControlDatabaseTabPageTabControl.SelectedTab = appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPage;
                    break;
                case DatabaseEngine.AzureDatabaseForMySQL:
                case DatabaseEngine.MySQL:
                    appConfigurationTabControlDatabaseTabPageTabControl.SelectedTab = appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPage;
                    break;
                case DatabaseEngine.AzureDatabaseForPostgreSQL:
                case DatabaseEngine.PostgreSQL:
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

        private void appConfigurationTabControlDatabaseTabPageTabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            UpdateDatabaseTabAuthenticationUI();
        }

        private void appConfigurationTabControlPersonalPreferencesTabPageDelimeterComboBoxPopulateData()
        {
            var ordered = delimeterOptions.OrderBy(kvp => kvp.Key).ToList();
            var comboBoxItems = ordered.Select(kvp => kvp.Value.DisplayName).ToList();
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
                .Select(kvp => $"{kvp.Value.DisplayName} ({kvp.Value.LanguageRegionCode})")
                .ToList();
            appConfigurationTabControlPersonalPreferencesTabPageRegionLanguageComboBox.DataSource = comboBoxItems;

            int selectedIndex = 3; // Default to English (en-GB), which has key 3 in the dictionary

            if (userProfileActiveLanguageRegionCode.HasValue)
            {
                var idx = ordered.FindIndex(kvp =>
                    kvp.Value.LanguageRegionCode == userProfileActiveLanguageRegionCode.Value);
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
                authenticationType = appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelNativeRadioButton.Checked ? MSSQLAuthenticationType.SQLServer :
                                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelKerberosRadioButton.Checked ? MSSQLAuthenticationType.Windows :
                                    appConfigurationTabControlDatabaseTabPageTabControlMSSQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked ? MSSQLAuthenticationType.EntraId :
                                    throw new InvalidOperationException("No authentication type selected for MSSQL.")
            };
        }

        private ApplicationConfigurationModel.ApplicationConfigurationServiceMySQLConfiguration CreateMySQLConfiguration()
        {
            // Get the selected SSL mode from the combo box and convert it to the enum
            var selectedSslMode = MySQLSSLMode.Preferred; // Default
            if (appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageSSLModeComboBox.SelectedItem != null)
            {
                var selectedItem = appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageSSLModeComboBox.SelectedItem;
                if (selectedItem is MySQLSSLMode sslModeEnum)
                {
                    selectedSslMode = sslModeEnum;
                }
            }

            return new ApplicationConfigurationModel.ApplicationConfigurationServiceMySQLConfiguration
            {
                serverName = appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageServerNameTextBox.Text,
                portNumber = int.TryParse(appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePortNumberTextBox.Text, out var port) ? port : 3306,
                databaseName = appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageDatabaseNameTextBox.Text,
                username = appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageUsernameTextBox.Text,
                password = appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPagePasswordTextBox.Text,
                connectionTimeout = int.TryParse(appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageConnectionTimeoutTextBox.Text, out var timeout) ? timeout : 30,
                sslMode = selectedSslMode,
                authenticationType = appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageAuthenticationTypePanelNativeRadioButton.Checked ? MySQLAuthenticationType.Native :
                                    appConfigurationTabControlDatabaseTabPageTabControlMySQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked ? MySQLAuthenticationType.EntraId :
                                    throw new InvalidOperationException("No authentication type selected for MySQL.")
            };
        }

        private ApplicationConfigurationModel.ApplicationConfigurationServicePostgreSQLConfiguration CreatePostgreSQLConfiguration()
        {
            // Get the selected SSL mode from the combo box and convert it to the enum
            var selectedSslMode = PostgreSQLSSLMode.Prefer; // Default
            if (appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageSSLModeComboBox.SelectedItem != null)
            {
                var selectedItem = appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageSSLModeComboBox.SelectedItem;
                if (selectedItem is PostgreSQLSSLMode sslModeEnum)
                {
                    selectedSslMode = sslModeEnum;
                }
            }

            return new ApplicationConfigurationModel.ApplicationConfigurationServicePostgreSQLConfiguration
            {
                serverName = appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageServerNameTextBox.Text,
                portNumber = int.TryParse(appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePortNumberTextBox.Text, out var port) ? port : 5432,
                databaseName = appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageDatabaseNameTextBox.Text,
                username = appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageUsernameTextBox.Text,
                password = appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPagePasswordTextBox.Text,
                connectionTimeout = int.TryParse(appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageConnectionTimeoutTextBox.Text, out var timeout) ? timeout : 30,
                sslMode = selectedSslMode,
                authenticationType = appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageAuthenticationTypePanelNativeRadioButton.Checked ? PostgreSQLAuthenticationType.Native :
                                    appConfigurationTabControlDatabaseTabPageTabControlPostgreSQLTabPageAuthenticationTypePanelEntraIdRadioButton.Checked ? PostgreSQLAuthenticationType.EntraId :
                                    throw new InvalidOperationException("No authentication type selected for PostgreSQL.")
            };
        }
    }
}