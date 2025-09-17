using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Model;
using System.Text.Json;

namespace CRM_WindowsForms_EnterpriseEdition.Services
{
    internal class ApplicationConfigurationService
    {
        private static readonly string ConfigFolderPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "CRM-WindowsForms.EnterpriseEdition");
        private static readonly string ConfigFilePath = Path.Combine(ConfigFolderPath, "applicationConfiguration.json");

        private static ApplicationConfigurationModel.ApplicationConfigurationServiceRoot? _configuration;
        private static readonly object _lock = new();

        public static async Task<ApplicationConfigurationModel.ApplicationConfigurationServiceRoot> LoadAsync()
        {
            if (!Directory.Exists(ConfigFolderPath))
                Directory.CreateDirectory(ConfigFolderPath);

            if (!File.Exists(ConfigFilePath))
            {
                _configuration = new ApplicationConfigurationModel.ApplicationConfigurationServiceRoot();
                await SaveAsync();
            }
            else
            {
                var json = await File.ReadAllTextAsync(ConfigFilePath);
                _configuration = JsonSerializer.Deserialize<ApplicationConfigurationModel.ApplicationConfigurationServiceRoot>(json)
                    ?? new ApplicationConfigurationModel.ApplicationConfigurationServiceRoot();

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
                _configuration = new ApplicationConfigurationModel.ApplicationConfigurationServiceRoot();

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

        public static ApplicationConfigurationModel.ApplicationConfigurationServiceCompanyConfiguration CompanyConfiguration
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

        public static string Delimeter
        {
            get
            {
                EnsureLoaded();
                return _configuration!.personalPreferenceConfiguration.delimeter;
            }
            set
            {
                EnsureLoaded();
                _configuration!.personalPreferenceConfiguration.delimeter = value;
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

        public static string RegionLanguageCode
        {
            get
            {
                EnsureLoaded();
                return _configuration!.personalPreferenceConfiguration.languageCode;
            }
            set
            {
                EnsureLoaded();
                _configuration!.personalPreferenceConfiguration.languageCode = value;
            }
        }

        public static string unitType
        {
            get
            {
                EnsureLoaded();
                return _configuration!.personalPreferenceConfiguration.unitType;
            }
            set
            {
                EnsureLoaded();
                _configuration!.personalPreferenceConfiguration.unitType = value;
            }
        }

        public static async Task<ApplicationConfigurationModel.ApplicationConfigurationServiceCompanyConfiguration> GetCompanyConfigurationAsync()
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

        public static async Task<string> GetDelimeterAsync()
        {
            if (_configuration == null)
                await LoadAsync();
            return _configuration!.personalPreferenceConfiguration.delimeter;
        }

        public static async Task<bool> GetLoggingEnabledAsync()
        {
            if (_configuration == null)
                await LoadAsync();
            return _configuration!.systemConfiguration.loggingEnabled;
        }

        public static async Task<string> GetRegionLanguageCodeAsync()
        {
            if (_configuration == null)
                await LoadAsync();
            return _configuration!.personalPreferenceConfiguration.languageCode;
        }

        public static async Task<string> GetUnitTypeAsync()
        {
            if (_configuration == null)
                await LoadAsync();
            return _configuration!.personalPreferenceConfiguration.unitType;
        }

        public static async Task<ApplicationConfigurationModel.ApplicationConfigurationServiceMSSQLConfiguration> GetMSSQLConfigurationAsync()
        {
            if (_configuration == null)
                await LoadAsync();
            return _configuration!.databaseConfiguration.mssqlConfiguration;
        }

        public static async Task<ApplicationConfigurationModel.ApplicationConfigurationServiceMySQLConfiguration> GetMySQLConfigurationAsync()
        {
            if (_configuration == null)
                await LoadAsync();
            return _configuration!.databaseConfiguration.mysqlConfiguration;
        }

        public static async Task<ApplicationConfigurationModel.ApplicationConfigurationServicePostgreSQLConfiguration> GetPostgreSQLConfigurationAsync()
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

        public static async Task SetCompanyConfigurationAsync(ApplicationConfigurationModel.ApplicationConfigurationServiceCompanyConfiguration companyConfiguration)
        {
            CompanyConfiguration = companyConfiguration;
            await SaveAsync();
        }

        public static async Task SetDelimeterAsync(string delimeter)
        {
            Delimeter = delimeter;
            await SaveAsync();
        }

        public static async Task SetLoggingEnabledAsync(bool loggingEnabled)
        {
            LoggingEnabled = loggingEnabled;
            await SaveAsync();
        }

        public static ApplicationConfigurationModel.ApplicationConfigurationServiceMSSQLConfiguration MSSQLConfiguration
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

        public static async Task SetMSSQLConfigurationAsync(ApplicationConfigurationModel.ApplicationConfigurationServiceMSSQLConfiguration config)
        {
            MSSQLConfiguration = config;
            await SaveAsync();
        }

        public static ApplicationConfigurationModel.ApplicationConfigurationServiceMySQLConfiguration MySQLConfiguration
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

        public static async Task SetMySQLConfigurationAsync(ApplicationConfigurationModel.ApplicationConfigurationServiceMySQLConfiguration config)
        {
            MySQLConfiguration = config;
            await SaveAsync();
        }

        public static ApplicationConfigurationModel.ApplicationConfigurationServicePostgreSQLConfiguration PostgreSQLConfiguration
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

        public static async Task SetPostgreSQLConfigurationAsync(ApplicationConfigurationModel.ApplicationConfigurationServicePostgreSQLConfiguration config)
        {
            PostgreSQLConfiguration = config;
            await SaveAsync();
        }

        public static async Task SetRegionLanguageCodeAsync(string languageCode)
        {
            RegionLanguageCode = languageCode;
            await SaveAsync();
        }

        public static async Task SetUnitTypeAsync(string unitType)
        {
            ApplicationConfigurationService.unitType = unitType;
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
                        loadTask.GetAwaiter().GetResult();
                    }
                }
            }
        }
    }
}