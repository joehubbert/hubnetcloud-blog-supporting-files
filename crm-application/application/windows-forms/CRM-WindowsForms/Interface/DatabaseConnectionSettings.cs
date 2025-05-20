using Microsoft.Data.SqlClient;
using System.Text.Json;

namespace CRM_WindowsForms.Interface
{
    public class DatabaseConnectionSettings
    {
        public string? ServerName { get; set; }
        public string? DatabaseName { get; set; }
        public bool EncryptConnection { get; set; }

        private static readonly string ConfigFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"CRM-WindowsForms");
        private static readonly string ConfigFilePath = Path.Combine(ConfigFolderPath, "config.json");

        public static async Task<DatabaseConnectionSettings> LoadAsync()
        {
            if (File.Exists(ConfigFilePath))
            {
                string json = await File.ReadAllTextAsync(ConfigFilePath);
                return JsonSerializer.Deserialize<DatabaseConnectionSettings>(json);
            }
            return new DatabaseConnectionSettings();
        }

        public async Task SaveAsync()
        {
            if (!Directory.Exists(ConfigFolderPath))
            {
                Directory.CreateDirectory(ConfigFolderPath);
            }
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(ConfigFilePath, json);
        }

        public string DatabaseConnectionString
        {
            get
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = ServerName,
                    InitialCatalog = DatabaseName,
                    IntegratedSecurity = true,
                    Encrypt = EncryptConnection,
                    TrustServerCertificate = true,
                    ApplicationName = "CRM-WindowsForms"
                };
                return builder.ConnectionString;
            }
        }
    }
}