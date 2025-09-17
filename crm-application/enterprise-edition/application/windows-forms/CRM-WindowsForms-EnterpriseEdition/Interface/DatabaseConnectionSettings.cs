using CRM.Model;
using CRM.Services;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using Npgsql;

namespace CRM.Interface
{
    public class DatabaseConnectionSettings
    {
        public string? ActiveDatabaseEngine { get; private set; }

        public ApplicationConfigurationModel.ApplicationConfigurationServiceMSSQLConfiguration? MSSQLConfig { get; private set; }
        public ApplicationConfigurationModel.ApplicationConfigurationServiceMySQLConfiguration? MySQLConfig { get; private set; }
        public ApplicationConfigurationModel.ApplicationConfigurationServicePostgreSQLConfiguration? PostgreSQLConfig { get; private set; }

        public static async Task<DatabaseConnectionSettings> LoadAsync()
        {
            var settings = new DatabaseConnectionSettings();

            settings.ActiveDatabaseEngine = await ApplicationConfigurationService.GetActiveDatabaseEngineAsync();

            switch (settings.ActiveDatabaseEngine)
            {
                case "Microsoft SQL Server":
                case "Azure SQL Database":
                case "Azure SQL Managed Instance":
                    settings.MSSQLConfig = await ApplicationConfigurationService.GetMSSQLConfigurationAsync();
                    break;
                case "MySQL":
                case "Azure Database for MySQL":
                    settings.MySQLConfig = await ApplicationConfigurationService.GetMySQLConfigurationAsync();
                    break;
                case "PostgreSQL":
                case "Azure Database for PostgreSQL":
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
                    case "Microsoft SQL Server":
                    case "Azure SQL Database":
                    case "Azure SQL Managed Instance":
                        if (MSSQLConfig == null)
                            throw new InvalidOperationException("MSSQL configuration not loaded.");
                        var mssqlBuilder = new SqlConnectionStringBuilder
                        {
                            DataSource = MSSQLConfig.serverName,
                            InitialCatalog = MSSQLConfig.databaseName,
                            IntegratedSecurity = MSSQLConfig.authenticationType == "Kerberos",
                            Encrypt = MSSQLConfig.encryptionEnabled,
                            TrustServerCertificate = MSSQLConfig.trustServerCertificate,
                            ApplicationName = "CRM - Enterprise Edition",
                            ConnectTimeout = MSSQLConfig.connectionTimeout
                        };

                        if (MSSQLConfig.authenticationType == "SQL" || MSSQLConfig.authenticationType == "EntraId")
                        {
                            if (!string.IsNullOrWhiteSpace(MSSQLConfig.username))
                                mssqlBuilder.UserID = MSSQLConfig.username;
                            if (MSSQLConfig.authenticationType == "SQL" && !string.IsNullOrWhiteSpace(MSSQLConfig.password))
                                mssqlBuilder.Password = MSSQLConfig.password;
                        }

                        if (ActiveDatabaseEngine == "Azure SQL Database" || ActiveDatabaseEngine == "Azure SQL Managed Instance")
                        {
                            if (MSSQLConfig.authenticationType == "EntraId")
                                mssqlBuilder.Authentication = SqlAuthenticationMethod.ActiveDirectoryInteractive;
                        }
                        return mssqlBuilder.ConnectionString;
                    case "MySQL":
                    case "Azure Database for MySQL":
                        if (MySQLConfig == null)
                            throw new InvalidOperationException("MySQL configuration not loaded.");
                        var mysqlBuilder = new MySqlConnectionStringBuilder
                        {
                            Server = MySQLConfig.serverName,
                            Port = (uint)MySQLConfig.portNumber,
                            Database = MySQLConfig.databaseName,
                            UserID = MySQLConfig.username,
                            Password = MySQLConfig.password,
                            SslMode = Enum.TryParse(MySQLConfig.sslMode, out MySqlSslMode sslMode) ? sslMode : MySqlSslMode.Preferred,
                            ConnectionTimeout = (uint)MySQLConfig.connectionTimeout
                        };
                        if (ActiveDatabaseEngine == "Azure Database for MySQL")
                        {
                            mysqlBuilder.SslMode = MySqlSslMode.Required;
                        }
                        return mysqlBuilder.ConnectionString;
                    case "PostgreSQL":
                    case "Azure Database for PostgreSQL":
                        if (PostgreSQLConfig == null)
                            throw new InvalidOperationException("PostgreSQL configuration not loaded.");
                        var npgsqlBuilder = new NpgsqlConnectionStringBuilder
                        {
                            Host = PostgreSQLConfig.serverName,
                            Port = PostgreSQLConfig.portNumber,
                            Database = PostgreSQLConfig.databaseName,
                            Username = PostgreSQLConfig.username,
                            Password = PostgreSQLConfig.password,
                            SslMode = Enum.TryParse(PostgreSQLConfig.sslMode, out SslMode pgSslMode) ? pgSslMode : SslMode.Prefer,
                            Timeout = PostgreSQLConfig.connectionTimeout
                        };
                        if (ActiveDatabaseEngine == "Azure Database for PostgreSQL")
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