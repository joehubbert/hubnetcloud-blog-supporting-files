using CRM.Model;
using CRM.Services;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using Npgsql;

namespace CRM.Interface
{
    public class DatabaseConnectionSettings
    {
        public DatabaseEngine? ActiveDatabaseEngine { get; private set; }

        public ApplicationConfigurationModel.ApplicationConfigurationServiceMSSQLConfiguration? MSSQLConfig { get; private set; }
        public ApplicationConfigurationModel.ApplicationConfigurationServiceMySQLConfiguration? MySQLConfig { get; private set; }
        public ApplicationConfigurationModel.ApplicationConfigurationServicePostgreSQLConfiguration? PostgreSQLConfig { get; private set; }

        public static async Task<DatabaseConnectionSettings> LoadAsync()
        {
            var settings = new DatabaseConnectionSettings();

            settings.ActiveDatabaseEngine = await ApplicationConfigurationService.GetActiveDatabaseEngineAsync();

            switch (settings.ActiveDatabaseEngine)
            {
                case DatabaseEngine.AzureSQLDatabase:
                case DatabaseEngine.AzureSQLManagedInstance:
                case DatabaseEngine.MicrosoftSQLServer:
                    settings.MSSQLConfig = await ApplicationConfigurationService.GetMSSQLConfigurationAsync();
                    break;
                case DatabaseEngine.AzureDatabaseForMySQL:
                case DatabaseEngine.MySQL:
                    settings.MySQLConfig = await ApplicationConfigurationService.GetMySQLConfigurationAsync();
                    break;
                case DatabaseEngine.AzureDatabaseForPostgreSQL:
                case DatabaseEngine.PostgreSQL:
                    settings.PostgreSQLConfig = await ApplicationConfigurationService.GetPostgreSQLConfigurationAsync();
                    break;
            }

            return settings;
        }

        public string DatabaseConnectionString
        {
            get
            {
                switch (ActiveDatabaseEngine)
                {
                    case DatabaseEngine.AzureSQLDatabase:
                    case DatabaseEngine.AzureSQLManagedInstance:
                    case DatabaseEngine.MicrosoftSQLServer:
                        if (MSSQLConfig == null)
                            throw new InvalidOperationException("MSSQL configuration not loaded.");
                        var mssqlBuilder = new SqlConnectionStringBuilder
                        {
                            DataSource = MSSQLConfig.serverName,
                            InitialCatalog = MSSQLConfig.databaseName,
                            IntegratedSecurity = MSSQLConfig.authenticationType == MSSQLAuthenticationType.Windows,
                            Encrypt = MSSQLConfig.encryptionEnabled,
                            TrustServerCertificate = MSSQLConfig.trustServerCertificate,
                            ApplicationName = "CRM - Enterprise Edition",
                            ConnectTimeout = MSSQLConfig.connectionTimeout
                        };

                        if (MSSQLConfig.authenticationType == MSSQLAuthenticationType.SQLServer || MSSQLConfig.authenticationType == MSSQLAuthenticationType.EntraId)
                        {
                            if (!string.IsNullOrWhiteSpace(MSSQLConfig.username))
                                mssqlBuilder.UserID = MSSQLConfig.username;
                            if (MSSQLConfig.authenticationType == MSSQLAuthenticationType.SQLServer && !string.IsNullOrWhiteSpace(MSSQLConfig.password))
                                mssqlBuilder.Password = MSSQLConfig.password;
                        }

                        if (ActiveDatabaseEngine == DatabaseEngine.AzureSQLDatabase || ActiveDatabaseEngine == DatabaseEngine.AzureSQLManagedInstance)
                        {
                            if (MSSQLConfig.authenticationType == MSSQLAuthenticationType.EntraId)
                                mssqlBuilder.Authentication = SqlAuthenticationMethod.ActiveDirectoryInteractive;
                        }
                        return mssqlBuilder.ConnectionString;
                    case DatabaseEngine.AzureDatabaseForMySQL:
                    case DatabaseEngine.MySQL:
                        if (MySQLConfig == null)
                            throw new InvalidOperationException("MySQL configuration not loaded.");
                        var mysqlBuilder = new MySqlConnectionStringBuilder
                        {
                            Server = MySQLConfig.serverName,
                            Port = (uint)MySQLConfig.portNumber,
                            Database = MySQLConfig.databaseName,
                            UserID = MySQLConfig.username,
                            Password = MySQLConfig.password,
                            SslMode = Enum.TryParse(MySQLConfig.sslMode.ToString(), out MySqlSslMode sslMode) ? sslMode : MySqlSslMode.Preferred,
                            ConnectionTimeout = (uint)MySQLConfig.connectionTimeout
                        };
                        if (ActiveDatabaseEngine == DatabaseEngine.AzureDatabaseForMySQL)
                        {
                            mysqlBuilder.SslMode = MySqlSslMode.Required;
                        }
                        return mysqlBuilder.ConnectionString;
                    case DatabaseEngine.AzureDatabaseForPostgreSQL:
                    case DatabaseEngine.PostgreSQL:
                        if (PostgreSQLConfig == null)
                            throw new InvalidOperationException("PostgreSQL configuration not loaded.");
                        var npgsqlBuilder = new NpgsqlConnectionStringBuilder
                        {
                            Host = PostgreSQLConfig.serverName,
                            Port = PostgreSQLConfig.portNumber,
                            Database = PostgreSQLConfig.databaseName,
                            Username = PostgreSQLConfig.username,
                            Password = PostgreSQLConfig.password,
                            SslMode = Enum.TryParse(PostgreSQLConfig.sslMode.ToString(), out SslMode pgSslMode) ? pgSslMode : SslMode.Prefer,
                            Timeout = PostgreSQLConfig.connectionTimeout
                        };
                        if (ActiveDatabaseEngine == DatabaseEngine.AzureDatabaseForPostgreSQL)
                        {
                            npgsqlBuilder.SslMode = SslMode.Require;
                        }
                        return npgsqlBuilder.ConnectionString;

                    default:
                        throw new InvalidOperationException("Unsupported or undefined database engine.");
                }
            }
        }
    }
}