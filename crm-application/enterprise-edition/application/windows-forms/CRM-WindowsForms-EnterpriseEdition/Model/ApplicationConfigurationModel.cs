namespace CRM.Model
{
    public class ApplicationConfigurationModel
    {
        public class ApplicationConfigurationServiceRoot
        {
            public ApplicationConfigurationServiceCompanyConfiguration companyConfiguration { get; set; } = new();
            public ApplicationConfigurationServiceDatabaseConfiguration databaseConfiguration { get; set; } = new();
            public ApplicationConfigurationServicePersonalPreferenceConfiguration personalPreferenceConfiguration { get; set; } = new();
            public ApplicationConfigurationServiceSystemConfiguration systemConfiguration { get; set; } = new();
        }

        public class ApplicationConfigurationServiceCompanyConfiguration
        {
            public Guid companyConfigurationId { get; set; } = Guid.Empty;
            public string companyName { get; set; } = string.Empty;
        }

        public class ApplicationConfigurationServiceDatabaseConfiguration
        {
            public DatabaseEngine activeDatabaseEngine { get; set; }
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
            public MSSQLAuthenticationType authenticationType { get; set; }
        }

        public class ApplicationConfigurationServiceMySQLConfiguration
        {
            public string serverName { get; set; } = string.Empty;
            public int portNumber { get; set; }
            public string databaseName { get; set; } = string.Empty;
            public string username { get; set; } = string.Empty;
            public string password { get; set; } = string.Empty;
            public int connectionTimeout { get; set; }
            public MySQLSSLMode sslMode { get; set; }
            public MySQLAuthenticationType authenticationType { get; set; }
        }

        public class ApplicationConfigurationServicePostgreSQLConfiguration
        {
            public string serverName { get; set; } = string.Empty;
            public int portNumber { get; set; }
            public string databaseName { get; set; } = string.Empty;
            public string username { get; set; } = string.Empty;
            public string password { get; set; } = string.Empty;
            public int connectionTimeout { get; set; }
            public PostgreSQLSSLMode sslMode { get; set; }
            public PostgreSQLAuthenticationType authenticationType { get; set; }
        }

        public class ApplicationConfigurationServicePersonalPreferenceConfiguration
        {
            public string delimeter {  get; set; } = string.Empty;
            public LanguageRegionCode languageRegionCode { get; set; }
            public UnitType unitType {  get; set; }
        }

        public class ApplicationConfigurationServiceSystemConfiguration
        {
            public bool loggingEnabled { get; set; }
        }
    }
}