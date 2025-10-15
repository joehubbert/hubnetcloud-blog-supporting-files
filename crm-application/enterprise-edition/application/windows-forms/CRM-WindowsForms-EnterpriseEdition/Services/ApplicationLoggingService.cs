using CRM.Model;

namespace CRM.Services
{
    internal class ApplicationLoggingService
    {
        private LogAction _action;
        private string? _errorCode;
        private string? _errorException;
        private static readonly string ConfigFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CRM-WindowsForms.EnterpriseEdition");
        private static readonly string ApplicationLogFilePath = Path.Combine(ConfigFolderPath, "CRM-WindowsForms-EnterpriseEdition-Log-", $"{DateTime.UtcNow:yyyy-MM-dd}", ".txt");

        public ApplicationLoggingService(LogAction action, string? errorCode = null, string? errorException = null)
        {
            _action = action;
            if (errorCode != null)
            {
                _errorCode = errorCode;
            }
            if (errorException != null)
            {
                _errorException = errorException;
            }
            Orchestrator(_action);
        }

        private void Orchestrator(LogAction action)
        {
            switch (action)
            {
                case LogAction.AppendToLogFile:
                    AppendToLogFile(_errorCode ?? string.Empty, _errorException ?? string.Empty);
                    break;
                case LogAction.CreateLogFileIfNotExists:
                    CreateLogFileIfNotExists();
                    break;
                case LogAction.ClearLogFile:
                    ClearLogFile();
                    break;
                case LogAction.OpenLogFile:
                    OpenLogFile();
                    break;
                default:
                    throw new ArgumentException("Invalid action specified.");
            }
        }

        private void AppendToLogFile(string errorCode, string errorException)
        {
            CreateLogFileIfNotExists();
            using (var streamWriter = new StreamWriter(ApplicationLogFilePath, true))
            {
                streamWriter.WriteLine($"{DateTime.UtcNow:yyyy-MM-dd-HH-mm-ss} Error Code: {errorCode}, Exception: {errorException}");
            }
        }

        private void ClearLogFile()
        {
            if (File.Exists(ApplicationLogFilePath))
            {
                using (var stream = File.Open(ApplicationLogFilePath, FileMode.Truncate))
                {
                    // Truncate the file to zero length
                }
            }
            CreateLogFileIfNotExists();
        }

        private void CreateLogFileIfNotExists()
        {
            if (!Directory.Exists(ConfigFolderPath))
            {
                Directory.CreateDirectory(ConfigFolderPath);
            }
            if (!File.Exists(ApplicationLogFilePath))
            {
                using (var stream = File.Create(ApplicationLogFilePath))
                {
                    // Create the log file
                }
                using (var streamWriter = new StreamWriter(ApplicationLogFilePath, true))
                {
                    streamWriter.WriteLine($"CRM-Forms-EnterpriseEdition Log File Created At: {DateTime.UtcNow:yyyy-MM-dd-HH-mm-ss}");
                }
            }
        }

        private void OpenLogFile()
        {
            if (File.Exists(ApplicationLogFilePath))
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = ApplicationLogFilePath,
                    UseShellExecute = true
                });
            }
            else
            {
                throw new FileNotFoundException("Log file does not exist.");
            }
        }
    }
}