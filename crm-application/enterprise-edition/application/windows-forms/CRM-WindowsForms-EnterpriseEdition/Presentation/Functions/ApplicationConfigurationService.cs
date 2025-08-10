using CRM_WindowsForms_EnterpriseEdition.Interface;
using System.Text.Json;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation.Functions
{
    internal class ApplicationConfigurationService
    {
        private static readonly string ConfigFolderPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "CRM-WindowsForms.EnterpriseEdition");
        private static readonly string ConfigFilePath = Path.Combine(ConfigFolderPath, "applicationConfiguration.json");

        private static ApplicationConfigurationServiceRoot? _configuration;
        private static readonly object _lock = new();

        public static async Task<ApplicationConfigurationServiceRoot> LoadAsync()
        {
            if (!Directory.Exists(ConfigFolderPath))
                Directory.CreateDirectory(ConfigFolderPath);

            if (!File.Exists(ConfigFilePath))
            {
                _configuration = new ApplicationConfigurationServiceRoot();
                await SaveAsync();
            }
            else
            {
                var json = await File.ReadAllTextAsync(ConfigFilePath);
                _configuration = JsonSerializer.Deserialize<ApplicationConfigurationServiceRoot>(json)
                    ?? new ApplicationConfigurationServiceRoot();

                // Decrypt sensitive properties after loading
                _configuration.databaseConfiguration.mssqlConfiguration.password =
                    DPAPIHelper.Decrypt(_configuration.databaseConfiguration.mssqlConfiguration.password);
                _configuration.databaseConfiguration.mysqlConfiguration.password =
                    DPAPIHelper.Decrypt(_configuration.databaseConfiguration.mysqlConfiguration.password);
                _configuration.databaseConfiguration.postgresConfiguration.password =
                    DPAPIHelper.Decrypt(_configuration.databaseConfiguration.postgresConfiguration.password);
            }
            return _configuration;
        }

        public static async Task SaveAsync()
        {
            if (_configuration == null)
                _configuration = new ApplicationConfigurationServiceRoot();

            // Encrypt sensitive properties before saving
            _configuration.databaseConfiguration.mssqlConfiguration.password =
                DPAPIHelper.Encrypt(_configuration.databaseConfiguration.mssqlConfiguration.password);
            _configuration.databaseConfiguration.mysqlConfiguration.password =
                DPAPIHelper.Encrypt(_configuration.databaseConfiguration.mysqlConfiguration.password);
            _configuration.databaseConfiguration.postgresConfiguration.password =
                DPAPIHelper.Encrypt(_configuration.databaseConfiguration.postgresConfiguration.password);

            var json = JsonSerializer.Serialize(_configuration, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(ConfigFilePath, json);

            // Decrypt back in memory for runtime use
            _configuration.databaseConfiguration.mssqlConfiguration.password =
                DPAPIHelper.Decrypt(_configuration.databaseConfiguration.mssqlConfiguration.password);
            _configuration.databaseConfiguration.mysqlConfiguration.password =
                DPAPIHelper.Decrypt(_configuration.databaseConfiguration.mysqlConfiguration.password);
            _configuration.databaseConfiguration.postgresConfiguration.password =
                DPAPIHelper.Decrypt(_configuration.databaseConfiguration.postgresConfiguration.password);
        }

        public static ApplicationConfigurationServiceCompanyConfiguration CompanyConfiguration
        {
            get
            {
                EnsureLoaded();
                return _configuration!.companyConfiguration;
            }
            set
            {
                EnsureLoaded();
                _configuration!.companyConfiguration = value;
            }
        }

        public static string ActiveDatabaseEngine
        {
            get
            {
                EnsureLoaded();
                return _configuration!.databaseConfiguration.activeDatabaseEngine;
            }
            set
            {
                EnsureLoaded();
                _configuration!.databaseConfiguration.activeDatabaseEngine = value;
            }
        }

        public static string RegionLanguageCode
        {
            get
            {
                EnsureLoaded();
                return _configuration!.regionLanguageConfiguration.languageCode;
            }
            set
            {
                EnsureLoaded();
                _configuration!.regionLanguageConfiguration.languageCode = value;
            }
        }

        public static bool LoggingEnabled
        {
            get
            {
                EnsureLoaded();
                return _configuration!.systemConfiguration.loggingEnabled;
            }
            set
            {
                EnsureLoaded();
                _configuration!.systemConfiguration.loggingEnabled = value;
            }
        }

        public static async Task<ApplicationConfigurationServiceCompanyConfiguration> GetCompanyConfigurationAsync()
        {
            if (_configuration == null)
                await LoadAsync();
            return _configuration!.companyConfiguration;
        }

        public static async Task<string> GetActiveDatabaseEngineAsync()
        {
            if (_configuration == null)
                await LoadAsync();
            return _configuration!.databaseConfiguration.activeDatabaseEngine;
        }

        public static async Task<string> GetRegionLanguageCodeAsync()
        {
            if (_configuration == null)
                await LoadAsync();
            return _configuration!.regionLanguageConfiguration.languageCode;
        }

        public static async Task<bool> GetLoggingEnabledAsync()
        {
            if (_configuration == null)
                await LoadAsync();
            return _configuration!.systemConfiguration.loggingEnabled;
        }

        public static async Task<ApplicationConfigurationServiceMSSQLConfiguration> GetMSSQLConfigurationAsync()
        {
            if (_configuration == null)
                await LoadAsync();
            return _configuration!.databaseConfiguration.mssqlConfiguration;
        }

        public static async Task<ApplicationConfigurationServiceMySQLConfiguration> GetMySQLConfigurationAsync()
        {
            if (_configuration == null)
                await LoadAsync();
            return _configuration!.databaseConfiguration.mysqlConfiguration;
        }

        public static async Task<ApplicationConfigurationServicePostgreSQLConfiguration> GetPostgreSQLConfigurationAsync()
        {
            if (_configuration == null)
                await LoadAsync();
            return _configuration!.databaseConfiguration.postgresConfiguration;
        }

        public static async Task SetActiveDatabaseEngineAsync(string activeDatabaseEngine)
        {
            ActiveDatabaseEngine = activeDatabaseEngine;
            await SaveAsync();
        }

        public static async Task SetCompanyConfigurationAsync(ApplicationConfigurationServiceCompanyConfiguration companyConfiguration)
        {
            CompanyConfiguration = companyConfiguration;
            await SaveAsync();
        }

        public static async Task SetLoggingEnabledAsync(bool loggingEnabled)
        {
            LoggingEnabled = loggingEnabled;
            await SaveAsync();
        }

        public static ApplicationConfigurationServiceMSSQLConfiguration MSSQLConfiguration
        {
            get
            {
                EnsureLoaded();
                return _configuration!.databaseConfiguration.mssqlConfiguration;
            }
            set
            {
                EnsureLoaded();
                _configuration!.databaseConfiguration.mssqlConfiguration = value;
            }
        }

        public static async Task SetMSSQLConfigurationAsync(ApplicationConfigurationServiceMSSQLConfiguration config)
        {
            MSSQLConfiguration = config;
            await SaveAsync();
        }

        public static ApplicationConfigurationServiceMySQLConfiguration MySQLConfiguration
        {
            get
            {
                EnsureLoaded();
                return _configuration!.databaseConfiguration.mysqlConfiguration;
            }
            set
            {
                EnsureLoaded();
                _configuration!.databaseConfiguration.mysqlConfiguration = value;
            }
        }

        public static async Task SetMySQLConfigurationAsync(ApplicationConfigurationServiceMySQLConfiguration config)
        {
            MySQLConfiguration = config;
            await SaveAsync();
        }

        public static ApplicationConfigurationServicePostgreSQLConfiguration PostgreSQLConfiguration
        {
            get
            {
                EnsureLoaded();
                return _configuration!.databaseConfiguration.postgresConfiguration;
            }
            set
            {
                EnsureLoaded();
                _configuration!.databaseConfiguration.postgresConfiguration = value;
            }
        }

        public static async Task SetPostgreSQLConfigurationAsync(ApplicationConfigurationServicePostgreSQLConfiguration config)
        {
            PostgreSQLConfiguration = config;
            await SaveAsync();
        }

        public static async Task SetRegionLanguageCodeAsync(string languageCode)
        {
            RegionLanguageCode = languageCode;
            await SaveAsync();
        }

        private static void EnsureLoaded()
        {
            if (_configuration == null)
            {
                lock (_lock)
                {
                    if (_configuration == null)
                    {
                        var loadTask = LoadAsync();
                        loadTask.Wait();
                    }
                }
            }
        }
    }

    public class ApplicationConfigurationServiceRoot
    {
        public ApplicationConfigurationServiceCompanyConfiguration companyConfiguration { get; set; } = new();
        public ApplicationConfigurationServiceDatabaseConfiguration databaseConfiguration { get; set; } = new();
        public ApplicationConfigurationServiceRegionLanguageConfiguration regionLanguageConfiguration { get; set; } = new();
        public ApplicationConfigurationServiceSystemConfiguration systemConfiguration { get; set; } = new();
    }

    public class ApplicationConfigurationServiceCompanyConfiguration
    {
        public Guid companyConfigurationId { get; set; } = Guid.Empty;
        public string companyName { get; set; } = string.Empty;
    }

    public class ApplicationConfigurationServiceDatabaseConfiguration
    {
        public string activeDatabaseEngine { get; set; } = string.Empty;
        public ApplicationConfigurationServiceMSSQLConfiguration mssqlConfiguration { get; set; } = new();
        public ApplicationConfigurationServiceMySQLConfiguration mysqlConfiguration { get; set; } = new();
        public ApplicationConfigurationServicePostgreSQLConfiguration postgresConfiguration { get; set; } = new();
    }

    public class ApplicationConfigurationServiceMSSQLConfiguration
    {
        public string serverName { get; set; } = string.Empty;
        public string databaseName { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string certficateHostName { get; set; } = string.Empty;
        public bool encryptionEnabled { get; set; }
        public bool trustServerCertificate { get; set; }
        public int connectionTimeout { get; set; }
        public string authenticationType { get; set; } = string.Empty;
    }

    public class ApplicationConfigurationServiceMySQLConfiguration
    {
        public string serverName { get; set; } = string.Empty;
        public int portNumber { get; set; }
        public string databaseName { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public int connectionTimeout { get; set; }
        public string sslMode { get; set; } = string.Empty;
        public string authenticationType { get; set; } = string.Empty;
    }

    public class ApplicationConfigurationServicePostgreSQLConfiguration
    {
        public string serverName { get; set; } = string.Empty;
        public int portNumber { get; set; }
        public string databaseName { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public int connectionTimeout { get; set; }
        public string sslMode { get; set; } = string.Empty;
        public string authenticationType { get; set; } = string.Empty;
    }

    public class ApplicationConfigurationServiceRegionLanguageConfiguration
    {
        public string languageCode { get; set; } = string.Empty;
    }

    public class ApplicationConfigurationServiceSystemConfiguration
    {
        public bool loggingEnabled { get; set; }
    }
}